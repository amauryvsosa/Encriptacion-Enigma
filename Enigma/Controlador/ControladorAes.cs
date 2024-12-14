using Enigma.Modelo;
using Enigma.Vista;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Enigma.Apoyo.Utils;
using static Enigma.Encriptaciones.AesX;

namespace Enigma.Controlador {
    public class ControladorAes {
        DiseñoAes diseño;
        Validaciones validar;

        public TableLayoutPanel ObtenerDiseño() {
            diseño = new DiseñoAes();
            TableLayoutPanel contenedor = diseño.tlpContenedorAes;

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

            if (validar.SonValidosTextboxesOperacion() && EsLlaveEncriptadoCorrecta()) {
                validar.LimpiarTextBoxResultado();

                string llaveEncriptado = diseño.txtLlaveEncriptado.Text;
                string cadenaEncriptar = diseño.txtEncriptar.Text;
                string cadenaEncriptada = Codifica(llaveEncriptado, cadenaEncriptar);

                diseño.txtResultado.Text = cadenaEncriptada;
            }
        }

        public void Desencriptar() {
            string formatoIdentificado;
            if (validar == null) {
                IniciarValidar();
            }

            if (validar.SonValidosTextboxesOperacion() && EsLlaveEncriptadoCorrecta()) {
                validar.LimpiarTextBoxResultado();

                string llaveEncriptado = diseño.txtLlaveEncriptado.Text;
                string cadenaEncriptada = diseño.txtDesencriptar.Text;
                string cadenaDesencriptada = Descodifica(llaveEncriptado, cadenaEncriptada);

                if (!string.IsNullOrEmpty(cadenaDesencriptada)) {
                    formatoIdentificado = IdentificarFormato(cadenaDesencriptada);

                    if (!string.IsNullOrEmpty(formatoIdentificado) && validar.PreguntarDarFormato(formatoIdentificado)) {
                        cadenaDesencriptada = DarFormatoCorrespondiente(cadenaDesencriptada);
                    }
                }

                diseño.txtResultado.Text = cadenaDesencriptada;
            }
        }

        private bool EsLlaveEncriptadoCorrecta() {
            string llaveEncriptado = diseño.txtLlaveEncriptado.Text;
            int longitudMaximaLlaveEncriptado = 64;

            if (string.IsNullOrWhiteSpace(llaveEncriptado.Trim())) {
                MessageBox.Show("Por favor ingrese una Llave de encriptación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool esLlaveCorrecta = Regex.IsMatch(llaveEncriptado, @"^([a-fA-F0-9]{3,})$", RegexOptions.None, TimeSpan.FromSeconds(5));
            if (!esLlaveCorrecta) {
                MessageBox.Show("La llave de encriptación que ingresó no es correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon
                    .Error);
                return false;
            }

            if (llaveEncriptado.Length > longitudMaximaLlaveEncriptado) {
                DialogResult resultadoPregunta = MessageBox.Show("La llave de encriptación que estás utilizando puede no ser correcta" +
                    " debido a que excede el número máximo de caracteres permitido. ¿Deseas continuar?", "Advertencia",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                return resultadoPregunta == DialogResult.Yes;
            }

            return true;
        }
    }
}
