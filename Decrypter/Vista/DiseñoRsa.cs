using System;
using System.Drawing;
using System.Windows.Forms;
using static Enigma.Apoyo.Utils;

namespace Enigma.Vista {
    public partial class DiseñoRsa : UserControl {
        public DiseñoRsa() {
            InitializeComponent();
        }

        private void txtEncriptar_Enter(object sender, EventArgs e) {
                CambiarEstadoDeTextBoxes(true);
        }

        private void txtDesencriptar_Enter(object sender, EventArgs e) {
                CambiarEstadoDeTextBoxes(false);

        }

        private void txtEncriptar_TextChanged(object sender, EventArgs e) {
            string llavePublica = txtLlavePublica.Text;

            // Verifica si el contenido del TextBox requiere una barra de desplazamiento vertical
            if (txtEncriptar.GetLineFromCharIndex(txtEncriptar.Text.Length) > (txtEncriptar.Height / txtEncriptar.Font.Height) - 4) {
                txtEncriptar.ScrollBars = ScrollBars.Vertical;  // Muestra la barra de desplazamiento vertical solo si es necesario
            } else {
                txtEncriptar.ScrollBars = ScrollBars.None;  // Oculta la barra si no es necesaria
            }

            ManejarColorTexto(txtEncriptar, llavePublica);
        }

        private void txtDesencriptar_TextChanged(object sender, EventArgs e) {
            string llavePrivada = txtLlavePrivada.Text;

            // Verifica si el contenido del TextBox requiere una barra de desplazamiento vertical
            if (txtDesencriptar.GetLineFromCharIndex(txtDesencriptar.Text.Length) > (txtDesencriptar.Height / txtDesencriptar.Font.Height) - 4) {
                txtDesencriptar.ScrollBars = ScrollBars.Vertical;  // Muestra la barra de desplazamiento vertical solo si es necesario
            } else {
                txtDesencriptar.ScrollBars = ScrollBars.None;  // Oculta la barra si no es necesaria
            }

            ManejarColorTexto(txtDesencriptar, llavePrivada);
        }

        private void ManejarColorTexto(TextBox textBox, string llave) {
            int idTipoCifrado = comboxTipoCifrados.SelectedIndex;
            int idLongitudLlave = comboxLongitudesLlave.SelectedIndex;

            Color colorFinal = Color.Green; // Color por defecto para éxito
            FontStyle estiloFuente = FontStyle.Bold; // Estilo por defecto

            if (string.IsNullOrWhiteSpace(llave)) {
                colorFinal = ObtenerColorIntermedio(colorFinal, Color.Red); // Error grave
                estiloFuente = FontStyle.Regular;
            }

            if (idTipoCifrado < 0 || idLongitudLlave < 0) {
                colorFinal = ObtenerColorIntermedio(colorFinal, Color.Orange); // Advertencia
                estiloFuente = FontStyle.Regular;
            }

            // Aplicar el color final y el estilo
            textBox.ForeColor = colorFinal;
            textBox.Font = new Font(textBox.Font.FontFamily, txtEncriptar.Font.Size, estiloFuente);
        }

        private void txtEncriptar_MouseEnter(object sender, EventArgs e) {
            txtEncriptar.BackColor = Color.LightCyan;
        }

        private void txtEncriptar_MouseLeave(object sender, EventArgs e) {
            txtEncriptar.BackColor = Color.Azure;
        }

        private void txtDesencriptar_MouseEnter(object sender, EventArgs e) {
            txtDesencriptar.BackColor = Color.LightCyan;
        }

        private void txtDesencriptar_MouseLeave(object sender, EventArgs e) {
            txtDesencriptar.BackColor = Color.Azure;
        }

        private void txtResultado_MouseEnter(object sender, EventArgs e) {
            txtResultado.BackColor = Color.LightCyan;
        }

        private void txtResultado_MouseLeave(object sender, EventArgs e) {
            txtResultado.BackColor = Color.Azure;
        }

        private void comboxTipoCifrados_Enter(object sender, EventArgs e) {
            comboxTipoCifrados.BackColor = Color.LightSteelBlue;
        }

        private void comboxTipoCifrados_Leave(object sender, EventArgs e) {
            comboxTipoCifrados.BackColor = Color.White;
        }

        private void comboxTipoCifrados_MouseEnter(object sender, EventArgs e) {
            comboxTipoCifrados.BackColor = Color.LightSteelBlue;
        }

        private void comboxTipoCifrados_MouseLeave(object sender, EventArgs e) {
            comboxTipoCifrados.BackColor = Color.White;
        }

        private void comboxLongitudesLlave_Enter(object sender, EventArgs e) {
            comboxLongitudesLlave.BackColor = Color.LightSteelBlue;
        }

        private void comboxLongitudesLlave_Leave(object sender, EventArgs e) {
            comboxLongitudesLlave.BackColor = Color.White;
        }

        private void comboxLongitudesLlave_MouseEnter(object sender, EventArgs e) {
            comboxLongitudesLlave.BackColor = Color.LightSteelBlue;
        }

        private void comboxLongitudesLlave_MouseLeave(object sender, EventArgs e) {
            comboxLongitudesLlave.BackColor = Color.White;
        }

        private void txtLlavePrivada_Enter(object sender, EventArgs e) {
            txtLlavePrivada.BackColor = Color.BlanchedAlmond;
        }

        private void txtLlavePrivada_Leave(object sender, EventArgs e) {
            txtLlavePrivada.BackColor = Color.Wheat;
        }

        private void txtLlavePublica_Enter(object sender, EventArgs e) {
            txtLlavePublica.BackColor = Color.BlanchedAlmond;
            ////var handle = this.Handle;
            ////this.BeginInvoke((MethodInvoker)delegate {
            ////    txtLlavePublica.BackColor = Color.BlanchedAlmond;

            ////    var posicionInicial = ObtenerCoordenadas(label4);

            ////    label4.Visible = false;
            ////    comboxTipoCifrados.Visible = false;

            ////    tlpContenedorRsa.SetColumn(label6, posicionInicial.columna);
            ////    tlpContenedorRsa.SetRow(label6, posicionInicial.fila);

            ////    PosicionarControl(txtLlavePublica, posicionInicial.columna, posicionInicial.fila + 1, posicionInicial.columna, 4);


            ////});
        }

        private void txtLlavePublica_Leave(object sender, EventArgs e) {
            txtLlavePublica.BackColor = Color.Wheat;
        }

        private void CambiarEstadoDeTextBoxes(bool encriptarActivo) {
            if (encriptarActivo) {
                txtEncriptar.ReadOnly = false;
                txtEncriptar.Focus();
                txtDesencriptar.ReadOnly = true;
            } else {
                txtEncriptar.ReadOnly = true;
                txtDesencriptar.ReadOnly = false;
                txtDesencriptar.Focus();
            }

            string llave = encriptarActivo ? txtLlavePublica.Text : txtLlavePrivada.Text;
            ManejarColorTexto(encriptarActivo ? txtEncriptar : txtDesencriptar, llave);
        }

        private void txtLlavePublica_TextChanged(object sender, EventArgs e) {
            // Verifica si el contenido del TextBox requiere una barra de desplazamiento vertical
            //-4 indica el numero de lineas menos de las normales para que aparezcan las scrollbar
            if (txtLlavePublica.GetLineFromCharIndex(txtLlavePublica.Text.Length) > (txtLlavePublica.Height / txtLlavePublica.Font.Height) -4) {
                txtLlavePublica.ScrollBars = ScrollBars.Vertical;  // Muestra la barra de desplazamiento vertical solo si es necesario
            } else {
                txtLlavePublica.ScrollBars = ScrollBars.None;  // Oculta la barra si no es necesaria
            }
        }

        private void txtLlavePrivada_TextChanged(object sender, EventArgs e) {
            // Verifica si el contenido del TextBox requiere una barra de desplazamiento vertical
            if (txtLlavePrivada.GetLineFromCharIndex(txtLlavePrivada.Text.Length) > (txtLlavePrivada.Height / txtLlavePrivada.Font.Height) -4) {
                txtLlavePrivada.ScrollBars = ScrollBars.Vertical;  // Muestra la barra de desplazamiento vertical solo si es necesario
            } else {
                txtLlavePrivada.ScrollBars = ScrollBars.None;  // Oculta la barra si no es necesaria
            }
        }

        private void txtLlavePublica_MouseEnter(object sender, EventArgs e) {
            txtLlavePublica.BackColor = Color.BlanchedAlmond;
        }

        private void txtLlavePublica_MouseLeave(object sender, EventArgs e) {
            txtLlavePublica.BackColor = Color.Wheat;
        }

        private void txtLlavePrivada_MouseEnter(object sender, EventArgs e) {
            txtLlavePrivada.BackColor = Color.BlanchedAlmond;
        }

        private void txtLlavePrivada_MouseLeave(object sender, EventArgs e) {
            txtLlavePrivada.BackColor = Color.Wheat;
        }
    }
}
