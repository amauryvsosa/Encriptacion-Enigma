using System.Drawing;
using System.Windows.Forms;

namespace Decrypter {
    partial class Principal {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tlpDiseñoPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.botonRealizar = new System.Windows.Forms.Button();
            this.comboxEncriptaciones = new System.Windows.Forms.ComboBox();
            this.tlpDiseñoPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpDiseñoPrincipal
            // 
            this.tlpDiseñoPrincipal.AutoSize = true;
            this.tlpDiseñoPrincipal.BackColor = System.Drawing.Color.MidnightBlue;
            this.tlpDiseñoPrincipal.ColumnCount = 9;
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpDiseñoPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDiseñoPrincipal.Controls.Add(this.botonRealizar, 1, 2);
            this.tlpDiseñoPrincipal.Controls.Add(this.comboxEncriptaciones, 7, 0);
            this.tlpDiseñoPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiseñoPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpDiseñoPrincipal.Name = "tlpDiseñoPrincipal";
            this.tlpDiseñoPrincipal.RowCount = 4;
            this.tlpDiseñoPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89F));
            this.tlpDiseñoPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpDiseñoPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tlpDiseñoPrincipal.Size = new System.Drawing.Size(1070, 741);
            this.tlpDiseñoPrincipal.TabIndex = 0;
            // 
            // botonRealizar
            // 
            this.botonRealizar.AutoSize = true;
            this.botonRealizar.BackColor = System.Drawing.Color.RoyalBlue;
            this.tlpDiseñoPrincipal.SetColumnSpan(this.botonRealizar, 7);
            this.botonRealizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonRealizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botonRealizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.botonRealizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonRealizar.ForeColor = System.Drawing.Color.White;
            this.botonRealizar.Location = new System.Drawing.Point(13, 699);
            this.botonRealizar.Name = "botonRealizar";
            this.botonRealizar.Size = new System.Drawing.Size(1039, 31);
            this.botonRealizar.TabIndex = 0;
            this.botonRealizar.Text = "Realizar";
            this.botonRealizar.UseVisualStyleBackColor = false;
            this.botonRealizar.Click += new System.EventHandler(this.botonRealizar_Click);
            this.botonRealizar.Paint += new System.Windows.Forms.PaintEventHandler(this.botonRealizar_Paint);
            this.botonRealizar.MouseEnter += new System.EventHandler(this.botonRealizar_MouseEnter);
            this.botonRealizar.MouseLeave += new System.EventHandler(this.botonRealizar_MouseLeave);
            // 
            // comboxEncriptaciones
            // 
            this.comboxEncriptaciones.BackColor = System.Drawing.Color.White;
            this.comboxEncriptaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboxEncriptaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboxEncriptaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxEncriptaciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboxEncriptaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxEncriptaciones.ForeColor = System.Drawing.Color.Black;
            this.comboxEncriptaciones.FormattingEnabled = true;
            this.comboxEncriptaciones.Items.AddRange(new object[] {
            "Encriptacion Normal",
            "Encriptacion NuGet",
            "Encriptacion Devglan",
            "Encriptacion Url"});
            this.comboxEncriptaciones.Location = new System.Drawing.Point(898, 3);
            this.comboxEncriptaciones.Name = "comboxEncriptaciones";
            this.comboxEncriptaciones.Size = new System.Drawing.Size(154, 36);
            this.comboxEncriptaciones.TabIndex = 1;
            this.comboxEncriptaciones.SelectedIndexChanged += new System.EventHandler(this.comboxEncriptaciones_SelectedIndexChanged);
            this.comboxEncriptaciones.Enter += new System.EventHandler(this.comboxEncriptaciones_Enter);
            this.comboxEncriptaciones.Leave += new System.EventHandler(this.comboxEncriptaciones_Leave);
            this.comboxEncriptaciones.MouseEnter += new System.EventHandler(this.comboxEncriptaciones_MouseEnter);
            this.comboxEncriptaciones.MouseLeave += new System.EventHandler(this.comboxEncriptaciones_MouseLeave);
            // 
            // Principal
            // 
            this.ClientSize = new System.Drawing.Size(1070, 741);
            this.Controls.Add(this.tlpDiseñoPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enigma v3.0.050924";
            this.tlpDiseñoPrincipal.ResumeLayout(false);
            this.tlpDiseñoPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblEncrypt;
        private Panel separator1;
        private Label lblDecrypt;
        private Panel separator2;
        private TextBox txtResult;
        private TextBox textBox1;
        private TextBox textBox2;
        private TableLayoutPanel tableLayoutPanel;
        private TextBox txtEncrypt;
        private TextBox txtDecrypt;
        private Label lblResult;
        private Button btnPerform;
        private TextBox textBoxEncriptar;
        private Label separacion1;
        private Label labelDesencriptar;
        private TextBox textBoxDesencriptar;
        private Label separacion2;
        private Label labelResultado;
        private TextBox textBoxResultado;
        private Button btnRealizar;
        private Panel panelSeparador1;
        private Panel panelSeparador2;
        private Panel panelSeparador3;
        private Label labelLlaveEncriPrivada;
        private Panel panelEspecial;
        private Label labelLlavePublica;
        private ComboBox comboBoxLongitudesLlave;
        private ComboBox comboBoxCifrados;
        private TableLayoutPanel tlpDiseñoPrincipal;
        private Button botonRealizar;
        private ComboBox comboxEncriptaciones;
    }
}

