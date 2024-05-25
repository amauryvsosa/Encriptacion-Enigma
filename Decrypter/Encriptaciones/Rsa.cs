using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;

namespace Enigma.Encriptaciones {
    internal class Rsa {
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
                } catch (CryptographicException e) {
                    Console.WriteLine(e.Message);
                    return null; // O manejar de otra manera
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
                } catch (CryptographicException e) {
                    Console.WriteLine(e.Message);
                    return null; // O manejar de otra manera
                }
            }
        }

        protected static string ConvertirLlavePemEnXml(string llave, bool esPublica) {
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
        }
    }
}
