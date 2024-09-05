using Enigma.Modelo;
using Enigma.Vista;
using System.Windows.Forms;
using static Enigma.Apoyo.Utils;
using static Enigma.Encriptaciones.Rsa;

namespace Enigma.Controlador {
    public class ControladorRsa {
        DiseñoRsa diseño;
        Validaciones validar;

        public TableLayoutPanel ObtenerDiseño() {
            diseño = new DiseñoRsa();
            TableLayoutPanel contenedor = diseño.tlpContenedorRsa;

            return contenedor;
        }

        public int ObtenerOperacion() {
            return diseño.txtDesencriptar.ReadOnly ? 0 : 1;
        }

        private void IniciarValidar() {
            validar = new Validaciones(diseño.txtEncriptar, diseño.txtDesencriptar, diseño.txtResultado);
        }

        public void Encriptar() {
            if (validar == null) {
                IniciarValidar();
            }

            if (validar.SonValidosTextboxesOperacion() && ValidarComboboxesCifrados()) {
                validar.LimpiarTextBoxResultado();

                string cadenaEncriptar = diseño.txtEncriptar.Text;

                string longitudLlave = diseño.comboxLongitudesLlave.SelectedItem.ToString();
                string tipoCifrado = diseño.comboxTipoCifrados.SelectedItem.ToString();
                string llavePublica = diseño.txtLlavePublica.Text;

                string cadenaEncriptada = Codifica(cadenaEncriptar, longitudLlave, llavePublica, tipoCifrado);

                diseño.txtResultado.Text = cadenaEncriptada;
            }
        }

        public void Desencriptar() {
            string formatoIdentificado;
            if (validar == null) {
                IniciarValidar();
            }

            if (validar.SonValidosTextboxesOperacion() && ValidarComboboxesCifrados()) {
                validar.LimpiarTextBoxResultado();

                string cadenaEncriptada = diseño.txtDesencriptar.Text;

                string longitudLlave = diseño.comboxLongitudesLlave.SelectedItem.ToString();
                string tipoCifrado = diseño.comboxTipoCifrados.SelectedItem.ToString();
                string llavePrivada = diseño.txtLlavePrivada.Text;

                string cadenaDesencriptada = Descodifica(cadenaEncriptada, longitudLlave, llavePrivada, tipoCifrado);

                if (!string.IsNullOrEmpty(cadenaDesencriptada)) {
                    formatoIdentificado = IdentificarFormato(cadenaDesencriptada);

                    if (!string.IsNullOrEmpty(formatoIdentificado) && validar.PreguntarDarFormato(formatoIdentificado)) {
                        cadenaDesencriptada = DarFormatoCorrespondiente(cadenaDesencriptada);
                    }
                }

                diseño.txtResultado.Text = cadenaDesencriptada;
            }
        }

        public bool ValidarComboboxesCifrados() {
            if (diseño.comboxTipoCifrados.SelectedIndex < 0) {
                MessageBox.Show("Por favor seleccione un tipo de cifrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (diseño.comboxLongitudesLlave.SelectedIndex < 0) {
                MessageBox.Show("Por favor seleccione una longitud de llave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
