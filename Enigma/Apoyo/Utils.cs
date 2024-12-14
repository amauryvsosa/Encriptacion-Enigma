using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Enigma.Apoyo {
    public static class Utils {

        public static string ObtenerRutaDocumentos() {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static void CrearCarpeta(string ruta) {
            if (!Directory.Exists(ruta)) {
                Directory.CreateDirectory(ruta);
            }
        }

        public static void CrearArchivo(string ruta) {
            using (FileStream fs = File.Create(ruta)) {
                // El archivo se crea y se cierra automáticamente al salir del bloque using.
            }
        }

        public static bool ExisteCarpeta(string ruta) {
            return Directory.Exists(ruta);
        }

        public static bool ExisteArchivo(string ruta) {
            return File.Exists(ruta);
        }

        public static string ConvertirObjetoCadenaJson(object objeto) {
            try {
                string json = JsonConvert.SerializeObject(objeto, Formatting.Indented);
                return json;
            } catch (Exception exception) {
                Console.WriteLine("Error al convertir a JSON: " + exception.Message);
                return null;
                throw;
            }
        }

        public static T ConvertirCadenaJsonObjeto<T>(string cadenaJson) {
            try {
                T objeto = JsonConvert.DeserializeObject<T>(cadenaJson);
                return objeto;
            } catch (Exception exception) {
                Console.WriteLine("Error al convertir de JSON a objeto: " + exception.Message);
                return default;  // Retorna el valor por defecto para el tipo T si la conversión falla
            }
        }

        public static string ObtenerContenidoJson(string ruta) {
            try {
                string contenidoJson = File.ReadAllText(ruta);
                return contenidoJson;
            } catch (Exception exception) {
                Console.WriteLine("Error al leer el archivo: " + exception.Message);
                return null;
            }
        }

        public static void EscribirReemplazarContenidoJson(string ruta, string contenido) {
            try {
                File.WriteAllText(ruta, contenido);
            } catch (Exception exception) {
                Console.WriteLine("Error al escribir en el archivo: " + exception.Message);
            }
        }

        public static TableLayoutPanel ObtenerTableLayoutPanelDeControl(Control control) {
            if (control.Parent is TableLayoutPanel) {
                return (TableLayoutPanel)control.Parent;
            } else {
                return ObtenerTableLayoutPanelDeControl(control.Parent);
            }
        }

        public static void OcultarMostarElementosEspeciales(List<Control> controles, bool estado) {
            foreach (Control control in controles) {
                control.Visible = estado;
            }
        }

        public static void LlenarTextBox(Control control, string texto) {
            control.Text = string.Empty;

            control.Text = string.IsNullOrEmpty(texto) ? string.Empty : texto;
        }

        public static string IdentificarFormato(string cadenaResultado) {
            string tipoFormato = string.Empty;

            if (ResultadoEsJson(cadenaResultado)) {
                tipoFormato = "JSON";
            } else if (ResultadoEsXml(cadenaResultado)) {
                tipoFormato = "XML";
            } else if (ResultadoEsHtml(cadenaResultado)) {
                tipoFormato = "HTML";
            } else if (ResultadoEsYaml(cadenaResultado)) {
                tipoFormato = "YAML";
            }

            return tipoFormato;
        }

        public static string DarFormatoCorrespondiente(string cadenaResultado) {
            string cadenaFormateada = cadenaResultado;
            if (ResultadoEsJson(cadenaResultado)) {
                cadenaFormateada = JsonConvert.SerializeObject(JsonConvert
                    .DeserializeObject(cadenaResultado), Formatting.Indented);
            } else if (ResultadoEsXml(cadenaResultado)) {
                cadenaFormateada = XDocument.Parse(cadenaResultado).ToString();
            } else if (ResultadoEsHtml(cadenaResultado)) {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(cadenaResultado);
                cadenaFormateada = htmlDoc.DocumentNode.OuterHtml;
            } else if (ResultadoEsYaml(cadenaResultado)) {
                //Fase de pruebas para formato yaml
                // Definir una expresión regular
                string nivel1 = @"(\w+:)";

                cadenaFormateada = Regex.Replace(cadenaResultado, nivel1, "$1\n\r", RegexOptions.Multiline);
            }
            return cadenaFormateada;
        }

        private static bool ResultadoEsJson(string cadenaResultado) {
            try {
                JsonConvert.DeserializeObject(cadenaResultado);
                return true;
            } catch (JsonException) {
                return false;
            }
        }

        private static bool ResultadoEsXml(string cadenaResultado) {
            try {
                XElement.Parse(cadenaResultado);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        private static bool ResultadoEsYaml(string cadenaResultado) {
            string patronYaml = @"^(\w+\d*:\r*\n*¬*)|\r* +-* [a-z]*:¬* *.*¬*";
            try {
                // Crear un objeto Regex con el patrón
                Regex regex = new Regex(patronYaml);

                // Evaluar si la cadena coincide con la expresión regular
                bool coincide = regex.IsMatch(cadenaResultado);

                // Mostrar el resultado
                return coincide;
                //var yaml = new YamlDotNet.RepresentationModel.YamlStream();
                //yaml.Load(new StringReader(cadenaResultado));
                //return true;
            } catch (Exception) {
                return false;
            }
        }

        private static bool ResultadoEsHtml(string cadenaResultado) {
            // Definir una expresión regular
            string patronHtml = @"<\/?[a-z][\s\S]*>";
            try {
                // Crear un objeto Regex con el patrón
                Regex regex = new Regex(patronHtml);

                // Evaluar si la cadena coincide con la expresión regular
                bool coincide = regex.IsMatch(cadenaResultado);

                // Mostrar el resultado
                return coincide;
            } catch (Exception) {
                return false;
            }
        }

        public static Color ObtenerColorIntermedio(Color color, Color color2) {
            int red = (color.R + color2.R) / 2;
            int green = (color.G + color2.G) / 2;
            int blue = (color.B + color2.B) / 2;

            return Color.FromArgb(red, green, blue);
        }

        public static (int columna, int fila) ObtenerCoordenadas(Control control) {
            if(control.Parent is TableLayoutPanel tableLayoutPanel) {
                var posicion = tableLayoutPanel.GetPositionFromControl(control);
                return (posicion.Column, posicion.Row);
            }
            return default;
        }

        public static void PosicionarControl(Control control, int columna, int fila, int columnaFin, int filaFin) {
            if(control.Parent is TableLayoutPanel tableLayoutPanel) {
                tableLayoutPanel.SetColumn(control, columna);
                tableLayoutPanel.SetRow(control, fila);

                tableLayoutPanel.SetColumnSpan(control, columnaFin - columna + 1);
                tableLayoutPanel.SetRowSpan(control, filaFin - fila + 1);
            }
        }
    }
}
