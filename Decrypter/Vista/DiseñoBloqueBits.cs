using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma.Vista {
    public partial class DiseñoBloqueBits : UserControl {
        public DiseñoBloqueBits() {
            InitializeComponent();
        }

        private void txtEncriptar_Enter(object sender, EventArgs e) {
            txtDesencriptar.ReadOnly = true;
            txtEncriptar.ReadOnly = false;

            txtEncriptar.ForeColor = Color.Green;

            txtEncriptar.Font = new Font(txtEncriptar.Font, FontStyle.Bold);

            if (comboxTipoEncriptacion.SelectedIndex < 0) {
                txtEncriptar.ForeColor = Color.Red;

                txtEncriptar.Font = new Font(txtEncriptar.Font, FontStyle.Regular);
            }
        }

        private void txtDesencriptar_Enter(object sender, EventArgs e) {
            txtDesencriptar.ReadOnly = false;
            txtEncriptar.ReadOnly = true;

            txtDesencriptar.ForeColor = Color.Green;

            txtDesencriptar.Font = new Font(txtDesencriptar.Font, FontStyle.Bold);

            if (comboxTipoEncriptacion.SelectedIndex < 0) {
                txtDesencriptar.ForeColor = Color.Red;

                txtDesencriptar.Font = new Font(txtDesencriptar.Font, FontStyle.Regular);
            }
        }

        private void comboxTipoEncriptacion_Enter(object sender, EventArgs e) {
            comboxTipoEncriptacion.BackColor = Color.LightSteelBlue;
        }

        private void comboxTipoEncriptacion_MouseEnter(object sender, EventArgs e) {
            comboxTipoEncriptacion.BackColor = Color.LightSteelBlue;
        }

        private void comboxTipoEncriptacion_Leave(object sender, EventArgs e) {
            comboxTipoEncriptacion.BackColor = Color.White;
        }

        private void comboxTipoEncriptacion_MouseLeave(object sender, EventArgs e) {
            comboxTipoEncriptacion.BackColor = Color.White;
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
    }
}
