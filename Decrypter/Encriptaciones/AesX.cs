using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Enigma.Encriptaciones {
    public static class AesX {

        public static string Codifica(string llaveEncriptado, object dato) {
            // Convertimos la llave de encriptación obtenida a un arreglo de bytes.
            byte[] bytesClave = Encoding.UTF8.GetBytes(llaveEncriptado);

            using (Aes aes = Aes.Create()) {
                aes.KeySize = 256;  // Configuramos el tamaño de la clave a 256 bits.
                aes.Key = bytesClave; // Asignamos la clave de cifrado.
                aes.IV = new byte[16]; // Inicializamos el vector de inicialización (IV) con ceros.

                // Creamos un encriptador con la clave y el IV.
                using (ICryptoTransform encriptador = aes.CreateEncryptor(aes.Key, aes.IV)) {
                    using (MemoryStream memoriaStream = new MemoryStream()) {
                        using (CryptoStream cryptoStream = new CryptoStream(memoriaStream, encriptador, CryptoStreamMode.Write)) {
                            using (StreamWriter escritorStream = new StreamWriter(cryptoStream)) {
                                // Escribimos los datos a encriptar en el stream.
                                escritorStream.Write(dato);
                            }

                            // Obtenemos el IV y los datos encriptados del stream.
                            byte[] iv = aes.IV;
                            byte[] datosEncriptados = memoriaStream.ToArray();
                            byte[] resultado = new byte[iv.Length + datosEncriptados.Length];

                            // Copiamos el IV y los datos encriptados en el arreglo resultado.
                            Buffer.BlockCopy(iv, 0, resultado, 0, iv.Length);
                            Buffer.BlockCopy(datosEncriptados, 0, resultado, iv.Length, datosEncriptados.Length);

                            // Convertimos el resultado a una cadena en base64 y lo retornamos.
                            return Convert.ToBase64String(resultado);
                        }
                    }
                }
            }
        }

        public static string Descodifica(string llaveEncriptado, string datoEncriptado) {
            try {
                // Convertimos la cadena codificada en base64 en un arreglo de bytes
                byte[] datosCodificados = Convert.FromBase64String(datoEncriptado);

                // Extraemos el vector de inicialización (IV) que está en los primeros 16 bytes
                byte[] iv = new byte[16];
                byte[] datosCifrados = new byte[datosCodificados.Length - iv.Length];
                Buffer.BlockCopy(datosCodificados, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(datosCodificados, iv.Length, datosCifrados, 0, datosCodificados.Length - iv.Length);

                // Obtenemos la clave de cifrado convertida a bytes
                byte[] clave = Encoding.UTF8.GetBytes(llaveEncriptado);

                using (Aes aes = Aes.Create()) {
                    aes.KeySize = 256;
                    aes.Key = clave;
                    aes.IV = iv; // Usamos el IV extraído de los datos cifrados

                    // Creamos un objeto para desencriptar
                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV)) {
                        using (MemoryStream memoryStream = new MemoryStream(datosCifrados)) {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)) {
                                using (StreamReader streamReader = new StreamReader(cryptoStream)) {
                                    try {
                                        // Leemos todos los datos desencriptados
                                        return streamReader.ReadToEnd();
                                    } catch (Exception) {
                                        // Manejar la excepción o registrarla si es necesario
                                        return string.Empty;
                                    }
                                }
                            }
                        }
                    }
                }
            } catch (Exception excepcion) when (excepcion is FormatException || excepcion is OverflowException) {
                MessageBox.Show("Ha ocurrido un error al Desencriptar, debido a que la cadena encriptada no es valida.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}
