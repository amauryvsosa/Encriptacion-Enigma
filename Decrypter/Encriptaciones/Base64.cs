using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Enigma.Encriptaciones {
    public static class Base64 {

        public static string Codifica(Object dato) {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert
                .SerializeObject(dato)));
        }

        public static T Descodifica<T>(string datoCodificado) {
            try {
                if (string.IsNullOrEmpty(datoCodificado)) {
                    throw new ArgumentException("");
                }
                return JsonConvert.DeserializeObject<T>(System.Text.Encoding.UTF8.GetString(Convert
                .FromBase64String(datoCodificado)));
            } catch (ArgumentException) {
                // Mostrar mensaje de error indicando que no se ingresó texto para desencriptar
                MessageBox.Show("Por favor, ingrese texto en el cuadro de Desencriptar antes de realizar la operación.",
                                "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return default(T);
            } catch (JsonReaderException) {
                MessageBox.Show("El mensaje a desencriptar no es válido. Asegúrese de que el formato sea correcto.",
                                            "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
    }
}
