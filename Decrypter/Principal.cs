using Enigma.Apoyo;
using Enigma.Controlador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Enigma.Apoyo.Inactividad;
using static Enigma.Apoyo.Utils;

namespace Decrypter {
    public partial class Principal : Form {
        private JsonConfiguracion configuracion = new JsonConfiguracion();
        private List<Control> controlesDinamicos = new List<Control>();

        //Controladores
        ControladorBase64 controladorB64 = new ControladorBase64();
        ControladorAes controladorAes = new ControladorAes();
        ControladorRsa controladorRsa = new ControladorRsa();
        ControladorBloqueDeBits controladorBloqueBits = new ControladorBloqueDeBits();

        public Principal() {
            InitializeComponent();
            comboxEncriptaciones.SelectedIndex = 0;
            ValidarConfiguracionInicial();
            CapturarClicks(Controls, UserActivity);
            IniciarContadorActividad(InactivityTimer_Tick);
        }

        #region Metodos de Validacion
        public void ValidarConfiguracionInicial() {
            string ruta = ObtenerRutaDocumentos() + "\\Enigma";
            string rutaJson = $"{ruta}\\ConfiguracionEnigma.json";

            if (!ExisteCarpeta(ruta)) {
                CrearCarpeta(ruta);
            }

            if (!ExisteArchivo(rutaJson)) {
                JsonPorDefecto iniciarJson = new JsonPorDefecto();
                CrearArchivo(rutaJson);

                configuracion = iniciarJson.ObtenerJsonBienvenida();

                string jsonConfiguracion = ConvertirObjetoCadenaJson(configuracion);

                EscribirReemplazarContenidoJson(rutaJson, jsonConfiguracion);
            } else {
                string jsonConfiguracion = ObtenerContenidoJson(rutaJson);
                configuracion = ConvertirCadenaJsonObjeto<JsonConfiguracion>(jsonConfiguracion);
            }

            controlesDinamicos.Add(textBoxEncriptar);
        }

        #endregion

        #region Metodos principales
        public void Encriptar() {
            int indice = comboxEncriptaciones.SelectedIndex;

            switch (indice) {
                case 0:
                controladorB64.Encriptar();
                break;
                case 1:
                controladorAes.Encriptar();
                break;
                case 2:
                controladorRsa.Encriptar();
                break;
                case 3:
                controladorBloqueBits.Encriptar();
                break;
                default:
                //NOSONAR
                break;

            }
        }

        public void Desencriptar() {
            int indice = comboxEncriptaciones.SelectedIndex;
            switch (indice) {
                case 0:
                controladorB64.Desencriptar();
                break;
                case 1:
                controladorAes.Desencriptar();
                break;
                case 2:
                controladorRsa.Desencriptar();
                break;
                case 3:
                controladorBloqueBits.Desencriptar();
                break;
                default:
                break;
                ////return default;
            }
        }

        public void AcomodarDiseñoExterno(TableLayoutPanel contenedorExterno) {
            Control tlpExistente = tlpDiseñoPrincipal.GetControlFromPosition(1, 1);

            if (tlpExistente != null) {
                tlpDiseñoPrincipal.Controls.Remove(tlpExistente);
                tlpExistente.Dispose();
            }

            tlpDiseñoPrincipal.Controls.Add(contenedorExterno, 1, 1);

            tlpDiseñoPrincipal.SetColumnSpan(contenedorExterno, 7);
            contenedorExterno.Dock = DockStyle.Fill;
        }
        #endregion

        private void UserActivity(object sender, EventArgs e) {
            TiempoInactividad.Stop();
            TiempoInactividad.Start();
        }

        private void InactivityTimer_Tick(object sender, EventArgs e) {
            TiempoInactividad.Stop();

            DialogResult resultadoDecisionInactividad = MessageBox.Show("No se han realizado operaciones en 5 minutos.\n" +
                "¿Desea cerrar el programa?", "Inactividad Detectada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultadoDecisionInactividad == DialogResult.Yes) {
                Application.Exit();
            } else {
                TiempoInactividad.Start();
            }
        }

        private void comboxEncriptaciones_SelectedIndexChanged(object sender, EventArgs e) {
            int indice = comboxEncriptaciones.SelectedIndex;

            switch (indice) {
                case 0:
                AcomodarDiseñoExterno(controladorB64.ObtenerDiseño());
                break;
                case 1:
                AcomodarDiseñoExterno(controladorAes.ObtenerDiseño());
                break;
                case 2:
                AcomodarDiseñoExterno(controladorRsa.ObtenerDiseño());
                break;
                case 3:
                AcomodarDiseñoExterno(controladorBloqueBits.ObtenerDiseño());
                break;
            }
        }

        private void botonRealizar_Click(object sender, EventArgs e) {
            int idOperacion = ObtenerOperacion();


            if (idOperacion == 0) {
                Encriptar();
            } else {
                Desencriptar();
            }
        }

        public int ObtenerOperacion() {
            int indice = comboxEncriptaciones.SelectedIndex;

            switch (indice) {
                case 0:
                return controladorB64.ObtenerOperacion();
                case 1:
                return controladorAes.ObtenerOperacion();
                case 2:
                return controladorRsa.ObtenerOperacion();
                case 3:
                return controladorBloqueBits.ObtenerOperacion();
                default:
                return -1;
            }
        }

        private void botonRealizar_MouseEnter(object sender, EventArgs e) {
            botonRealizar.BackColor = Color.FromArgb(70, 130, 180);
        }

        private void botonRealizar_MouseLeave(object sender, EventArgs e) {
            botonRealizar.BackColor = Color.RoyalBlue;
        }

        private void comboxEncriptaciones_Enter(object sender, EventArgs e) {
            comboxEncriptaciones.BackColor = Color.LightSteelBlue;
        }

        private void comboxEncriptaciones_Leave(object sender, EventArgs e) {
            comboxEncriptaciones.BackColor = Color.White;
        }

        private void botonRealizar_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(e.Graphics, botonRealizar.ClientRectangle,
                            Color.Transparent, 0, ButtonBorderStyle.None,
                            Color.Transparent, 0, ButtonBorderStyle.None,
                            Color.DarkGray, 2, ButtonBorderStyle.Solid,
                            Color.DarkGray, 2, ButtonBorderStyle.Solid);
        }

        private void comboxEncriptaciones_MouseEnter(object sender, EventArgs e) {
            comboxEncriptaciones.BackColor = Color.LightSteelBlue;
        }

        private void comboxEncriptaciones_MouseLeave(object sender, EventArgs e) {
            comboxEncriptaciones.BackColor = Color.White;
        }
    }
}
