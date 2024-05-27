using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Enigma.Encriptaciones {
    public static class Rsa {
        public static readonly string CIFRADO_1AND = "RSA/ECB/OAEPWithSHA-1AndMGF1Padding";
        public static readonly string CIFRADO_256AND = "RSA/ECB/OAEPWithSHA-256AndMGF1Padding";
        public static readonly string CIFRADO_PKCS1 = "RSA/ECB/PKCS1Padding";

        public static string Codifica(object dato, string tamanioLlave, string llavePublica, string tipoCifrado) {
            if (string.IsNullOrEmpty(tipoCifrado)) {
                tipoCifrado = CIFRADO_PKCS1;
            }

            // Convertimos los datos a un arreglo de bytes
            byte[] datosAEncriptarBytes = Encoding.UTF8.GetBytes(dato.ToString());

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(int.Parse(tamanioLlave))) {
                try {
                    // Importamos la clave pública
                    string llavePublicaXml = ConvertirLlavePemEnXml(llavePublica, true);
                    if (!string.IsNullOrEmpty(llavePublicaXml)) {
                        rsa.FromXmlString(llavePublicaXml); // Asegúrate de que la clave pública esté en formato XML

                        // Determinamos el tipo de relleno
                        RSAEncryptionPadding relleno;
                        if (tipoCifrado == CIFRADO_1AND) {
                            relleno = RSAEncryptionPadding.OaepSHA1;
                        } else if (tipoCifrado == CIFRADO_256AND) {
                            relleno = RSAEncryptionPadding.OaepSHA256;
                        } else {
                            relleno = RSAEncryptionPadding.Pkcs1;
                        }

                        // Encriptamos los datos
                        byte[] datosEncriptados = rsa.Encrypt(datosAEncriptarBytes, relleno);

                        // Convertimos los datos encriptados a Base64 para facilitar su almacenamiento o transmisión
                        return Convert.ToBase64String(datosEncriptados);
                    }
                    return string.Empty;
                } catch (CryptographicException excepcion) {
                    MessageBox.Show($"Ocurrio un error general al intentar Encriptar la informacion.\nError: {excepcion.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
        }

        public static string Descodifica(string datoEncriptado, string tamanioLlave, string llavePrivada, string tipoCifrado) {
            if (string.IsNullOrEmpty(tipoCifrado)) {
                tipoCifrado = CIFRADO_PKCS1;
            }

            // Convertimos los datos encriptados (Base64) a un arreglo de bytes
            byte[] datosEncriptadosBytes = Convert.FromBase64String(datoEncriptado);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(int.Parse(tamanioLlave))) {
                try {
                    // Importamos la clave privada
                    string llavePrivadaXml = ConvertirLlavePemEnXml(llavePrivada, false);

                    if (!string.IsNullOrEmpty(llavePrivadaXml)) {
                        rsa.FromXmlString(llavePrivadaXml); // Asegúrate de que la clave privada esté en formato XML

                        // Determinamos el tipo de relleno
                        RSAEncryptionPadding relleno;
                        if (tipoCifrado == CIFRADO_1AND) {
                            relleno = RSAEncryptionPadding.OaepSHA1;
                        } else if (tipoCifrado == CIFRADO_256AND) {
                            relleno = RSAEncryptionPadding.OaepSHA256;
                        } else {
                            relleno = RSAEncryptionPadding.Pkcs1;
                        }

                        // Desencriptamos los datos
                        byte[] datosDesencriptados = rsa.Decrypt(datosEncriptadosBytes, relleno);

                        // Convertimos los datos desencriptados a una cadena UTF-8
                        return Encoding.UTF8.GetString(datosDesencriptados);
                    }
                    return string.Empty;
                } catch (CryptographicException excepcion) {
                    MessageBox.Show($"Ocurrio un error general al intentar Desencriptar la informacion.\nError: {excepcion.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
        }

        private static string ConvertirLlavePemEnXml(string llave, bool esPublica) {
            string tipoLlave = esPublica ? "Llave Publica" : "Llave Privada";
            string tipoOperacion = esPublica ? "Encriptacion" : "Desencriptacion";

            try {
                // Verificar y añadir encabezados y pies de página si falta alguno
                if (!llave.StartsWith("-----BEGIN")) {
                    if (!esPublica) {
                        llave = $"-----BEGIN PRIVATE KEY-----\n{llave}\n-----END PRIVATE KEY-----";
                    } else {
                        llave = $"-----BEGIN PUBLIC KEY-----\n{llave}\n-----END PUBLIC KEY-----";
                    }
                }

                using (TextReader reader = new StringReader(llave)) {
                    PemReader pr = new PemReader(reader);
                    object keyObject = pr.ReadObject();

                    if (esPublica && keyObject is AsymmetricKeyParameter publicKey) {
                        RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);
                        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                            rsa.ImportParameters(rsaParams);
                            return rsa.ToXmlString(false); // Solo clave pública
                        }
                    } else if (!esPublica && keyObject is RsaPrivateCrtKeyParameters privateKey) {
                        RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(privateKey);
                        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
                            rsa.ImportParameters(rsaParams);
                            return rsa.ToXmlString(true); // Clave privada
                        }
                    } else {
                        throw new InvalidCastException("El objeto leído no es una clave RSA válida.");
                    }
                }
            } catch (Exception excepcion) when (excepcion is EndOfStreamException || excepcion is PemException) {
                MessageBox.Show($"Ha ocurrido un error en la {tipoOperacion}, debido a que la {tipoLlave} no tiene un tamaño correcto.",
                    "Error en Llave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception excepcion) when (excepcion is FormatException || excepcion is NullReferenceException) {
                MessageBox.Show($"Ha ocurrido un error en la {tipoOperacion}, debido a que la {tipoLlave} no es valida.",
                    "Error en Llave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception excepcion) {
                MessageBox.Show($"Ha ocurrido un error en la {tipoOperacion}\nError: {excepcion.Message}",
                    "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
