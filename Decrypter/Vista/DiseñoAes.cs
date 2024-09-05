using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma.Vista {
    public partial class DiseñoAes : UserControl {
        public DiseñoAes() {
            InitializeComponent();
        }

        private void txtEncriptar_Enter(object sender, EventArgs e) {
            txtEncriptar.ReadOnly = false;
            txtDesencriptar.ReadOnly = true;
        }

        private void txtDesencriptar_Enter(object sender, EventArgs e) {
            txtEncriptar.ReadOnly = true;
            txtDesencriptar.ReadOnly = false;
        }

        private void txtLlaveEncriptado_TextChanged(object sender, EventArgs e) {
            int longitud = txtLlaveEncriptado.Text.Length;

            if (longitud < 4) {
                txtLlaveEncriptado.ForeColor = Color.Red;
                txtLlaveEncriptado.Font = new Font(txtLlaveEncriptado.Font, FontStyle.Regular);

                txtEncriptar.ForeColor = Color.Red;
                txtDesencriptar.ForeColor = Color.Red;

                txtEncriptar.Font = new Font(txtEncriptar.Font, FontStyle.Regular);
                txtDesencriptar.Font = new Font(txtDesencriptar.Font, FontStyle.Regular);
            } else if (longitud != 32 && longitud != 48 && longitud != 64) {
                txtLlaveEncriptado.ForeColor = Color.Orange;
                txtLlaveEncriptado.Font = new Font(txtLlaveEncriptado.Font, FontStyle.Regular);

                txtEncriptar.ForeColor = Color.Red;
                txtDesencriptar.ForeColor = Color.Red;

                txtEncriptar.Font = new Font(txtEncriptar.Font, FontStyle.Regular);
                txtDesencriptar.Font = new Font(txtDesencriptar.Font, FontStyle.Regular);
            } else {
                txtLlaveEncriptado.ForeColor = Color.Black;
                txtLlaveEncriptado.Font = new Font(txtLlaveEncriptado.Font, FontStyle.Bold);

                txtEncriptar.ForeColor = Color.Green;
                txtDesencriptar.ForeColor = Color.Green;

                txtEncriptar.Font = new Font(txtEncriptar.Font, FontStyle.Bold);
                txtDesencriptar.Font = new Font(txtDesencriptar.Font, FontStyle.Bold);
            }
        }

        private void txtLlaveEncriptado_Enter(object sender, EventArgs e) {
            txtLlaveEncriptado.BackColor = Color.BlanchedAlmond; // Fondo ligeramente más claro al enfocarse

            // Crear resplandor
            txtLlaveEncriptado.Invalidate();
        }

        private void txtLlaveEncriptado_Leave(object sender, EventArgs e) {
            txtLlaveEncriptado.BackColor = Color.Wheat;

            // Quitar resplandor
            txtLlaveEncriptado.Invalidate();
        }

        private void txtEncriptar_MouseEnter(object sender, EventArgs e) {
            txtEncriptar.BackColor = Color.LightCyan;
        }

        private void txtDesencriptar_MouseEnter(object sender, EventArgs e) {
            txtDesencriptar.BackColor = Color.LightCyan;
        }

        private void txtResultado_MouseEnter(object sender, EventArgs e) {
            txtResultado.BackColor = Color.LightCyan;
        }

        private void txtEncriptar_MouseLeave(object sender, EventArgs e) {
            txtEncriptar.BackColor = Color.Azure;
        }

        private void txtDesencriptar_MouseLeave(object sender, EventArgs e) {
            txtDesencriptar.BackColor = Color.Azure;
        }

        private void txtResultado_MouseLeave(object sender, EventArgs e) {
            txtResultado.BackColor = Color.Azure;
        }

        private void txtLlaveEncriptado_MouseEnter(object sender, EventArgs e) {
            txtLlaveEncriptado.BackColor = Color.BlanchedAlmond;
        }

        private void txtLlaveEncriptado_MouseLeave(object sender, EventArgs e) {
            txtLlaveEncriptado.BackColor = Color.Wheat;
        }
    }
}
