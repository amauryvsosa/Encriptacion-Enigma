using System;
using System.Drawing;
using System.Windows.Forms;

namespace Enigma.Diseños {
    public partial class DiseñoBase64 : UserControl {
        public DiseñoBase64() {
            InitializeComponent();
        }

        private void txtEncriptar_Enter(object sender, EventArgs e) {
            txtDesencriptar.ReadOnly = true;
            txtEncriptar.ReadOnly = false;
        }

        private void txtDesencriptar_Enter(object sender, EventArgs e) {
            txtDesencriptar.ReadOnly = false;
            txtEncriptar.ReadOnly = true;
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
