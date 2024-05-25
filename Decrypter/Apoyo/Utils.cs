using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace Enigma.Apoyo {
    public static class Utils {

        public static string ObtenerNombreUsuario() {
            return Environment.UserName;
        }

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

        public static void LlenarComboBoxEncriptaciones(ComboBox caja, List<DatosEncriptacion> elementos) {
            caja.Items.Clear();

            foreach (DatosEncriptacion elemento in elementos) {
                caja.Items.Add(elemento.NombreComun);
            }
            caja.SelectedIndex = 0;
        }

        public static string LlenarComboBoxLogitudes(ComboBox caja, List<int> elementos) {
            caja.Items.Clear();

            foreach (int elemento in elementos) {
                caja.Items.Add(elemento);
            }
            caja.SelectedIndex = 1;

            return caja.SelectedItem.ToString();
        }

        public static string LlenarComboBoxCifrados(ComboBox caja, List<string> elementos) {
            caja.Items.Clear();

            foreach (string elemento in elementos) {
                caja.Items.Add(elemento);
            }
            caja.SelectedIndex = 0;

            return caja.SelectedItem.ToString();
        }

        public static List<Control> ObtenerControladoresEspeciales(TableLayoutPanel panel, int columnaInicio, int filaInicio, int columnaFin, int filaFin) {
            List<Control> controlesEspeciales = new List<Control>();

            foreach (Control control in panel.Controls) {
                TableLayoutPanelCellPosition posicion = panel.GetPositionFromControl(control);

                if (posicion.Column >= columnaInicio && posicion.Column <= columnaFin && posicion.Row >= filaInicio && posicion.Row <= filaFin) {
                    controlesEspeciales.Add(control);
                }
            }
            return controlesEspeciales;
        }

        public static Control ObtenerControlEspecifico(TableLayoutControlCollection controles, string nombre) {
            Control control = controles.Find(nombre, true).FirstOrDefault();
            return control;
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

        public static void ActualizarComponentes(List<Control> controles, List<DatosEncriptacion> elementos, int indice) {
            Control textBoxEncriptar = controles[controles.Count - 1];
            TableLayoutPanel panel = ObtenerTableLayoutPanelDeControl(textBoxEncriptar);
            Control labelTitulo = controles.Find(control => control.Name == "labelLlaveEncriPrivada");
            Control textBoxLlaveEncriptacion = controles.Find(control => control.Name == "textBoxLlaveEncriPrivada");

            OcultarMostarElementosEspeciales(controles, false);
            panel.SetRowSpan(textBoxEncriptar, 1);
            textBoxEncriptar.Visible = true;

            switch (indice) {
                case 1:
                    //Encriptacion Normal

                    panel.SetRowSpan(textBoxEncriptar, 3);
                break;
                case 2:
                    if(textBoxLlaveEncriptacion == null) {
                        textBoxLlaveEncriptacion = panel.Controls.Find("textBoxLlaveEncriPrivada", true)[0];
                    }

                    labelTitulo.Text = "Llave Encriptado";

                    LlenarTextBox(textBoxLlaveEncriptacion, elementos[indice - 1].Propiedades.LlaveEncriptado);

                    labelTitulo.Visible = true;
                    textBoxLlaveEncriptacion.Visible = true;
                    ((TextBox)textBoxLlaveEncriptacion).ReadOnly = true;
                break;
                case 3:
                    Control textBoxLlavePublica = controles.Find(control => control.Name == "textBoxLlavePublica");

                    labelTitulo.Text = "Llave Privada";

                    LlenarTextBox(textBoxLlavePublica, elementos[indice - 1].Propiedades.LlavePublica);
                    LlenarTextBox(textBoxLlaveEncriptacion, elementos[indice - 1].Propiedades.LlavePrivada);

                    OcultarMostarElementosEspeciales(controles, true);

                    ((TextBox)textBoxLlavePublica).ReadOnly = false;
                    ((TextBox)textBoxLlaveEncriptacion).ReadOnly = false;
                break;
            }
        }

        public static void LlenarTextBox(Control control, string texto) {
            control.Text = string.Empty;

            control.Text = string.IsNullOrEmpty(texto) ? string.Empty : texto;
        }
    }
}
