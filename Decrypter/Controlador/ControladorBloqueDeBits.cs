using Enigma.Modelo;
using Enigma.Vista;
using System.Windows.Forms;
using static Enigma.Apoyo.Utils;
using static Enigma.Encriptaciones.BloqueDeBits;

namespace Enigma.Controlador {
    public class ControladorBloqueDeBits {
        DiseñoBloqueBits diseño;
        Validaciones validar;

        public TableLayoutPanel ObtenerDiseño() {
            diseño = new DiseñoBloqueBits();
            TableLayoutPanel contenedor = diseño.tlpBloqueBits;

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

            if (validar.SonValidosTextboxesOperacion() && ValidarTipoEncriptacion()) {
                validar.LimpiarTextBoxResultado();

                string cadenaEncriptar = diseño.txtEncriptar.Text;

                int idEncriptacion = ObtenerTipoEncriptacion();

                if (idEncriptacion == 0) {
                    UsarEncriptacionBasica();
                } else {
                    UsarEncriptacionAvanzada();
                }

                string cadenaEncriptada = Codifica(cadenaEncriptar);

                diseño.txtResultado.Text = cadenaEncriptada;
            }
        }

        public void Desencriptar() {
            string formatoIdentificado;
            if (validar == null) {
                IniciarValidar();
            }

            if (validar.SonValidosTextboxesOperacion() && ValidarTipoEncriptacion()) {
                validar.LimpiarTextBoxResultado();

                string cadenaEncriptada = diseño.txtDesencriptar.Text;

                int idEncriptacion = ObtenerTipoEncriptacion();

                if (idEncriptacion == 0) {
                    UsarEncriptacionBasica();
                } else {
                    UsarEncriptacionAvanzada();
                }

                if (!EsTextoEncriptadoValido(cadenaEncriptada)) {
                    MessageBox.Show("El texto a desencriptar no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string cadenaDesencriptada = Descodifica(cadenaEncriptada);

                if (!string.IsNullOrEmpty(cadenaDesencriptada)) {
                    formatoIdentificado = IdentificarFormato(cadenaDesencriptada);

                    if (!string.IsNullOrEmpty(formatoIdentificado) && validar.PreguntarDarFormato(formatoIdentificado)) {
                        cadenaDesencriptada = DarFormatoCorrespondiente(cadenaDesencriptada);
                    }
                }

                diseño.txtResultado.Text = cadenaDesencriptada;
            }
        }

        public int ObtenerTipoEncriptacion() {
            return diseño.comboxTipoEncriptacion.SelectedIndex;
        }

        public bool ValidarTipoEncriptacion() {
            int idEncriptacion = ObtenerTipoEncriptacion();

            if (idEncriptacion < 0) {
                MessageBox.Show("Por favor seleccione un tipo de cifrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
