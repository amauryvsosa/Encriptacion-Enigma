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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelEncriptar = new System.Windows.Forms.Label();
            this.textBoxEncriptar = new System.Windows.Forms.TextBox();
            this.comboBoxEncriptaciones = new System.Windows.Forms.ComboBox();
            this.panelSeparador1 = new System.Windows.Forms.Panel();
            this.panelSeparador2 = new System.Windows.Forms.Panel();
            this.panelSeparador3 = new System.Windows.Forms.Panel();
            this.labelDesencriptar = new System.Windows.Forms.Label();
            this.textBoxDesencriptar = new System.Windows.Forms.TextBox();
            this.labelResultado = new System.Windows.Forms.Label();
            this.textBoxResultado = new System.Windows.Forms.TextBox();
            this.btnRealizar = new System.Windows.Forms.Button();
            this.labelLlaveEncriPrivada = new System.Windows.Forms.Label();
            this.panelEspecial = new System.Windows.Forms.Panel();
            this.panelEspecial2 = new System.Windows.Forms.Panel();
            this.textBoxLlaveEncriPrivada = new System.Windows.Forms.TextBox();
            this.labelLlavePublica = new System.Windows.Forms.Label();
            this.textBoxLlavePublica = new System.Windows.Forms.TextBox();
            this.comboBoxLongitudesLlave = new System.Windows.Forms.ComboBox();
            this.comboBoxCifrados = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.Controls.Add(this.labelEncriptar, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxEncriptar, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.comboBoxEncriptaciones, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.panelSeparador1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.panelSeparador2, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.panelSeparador3, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.labelDesencriptar, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.textBoxDesencriptar, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.labelResultado, 6, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxResultado, 6, 1);
            this.tableLayoutPanel.Controls.Add(this.btnRealizar, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.labelLlaveEncriPrivada, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.panelEspecial, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.panelEspecial2, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxLlaveEncriPrivada, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.labelLlavePublica, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxLlavePublica, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.comboBoxLongitudesLlave, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.comboBoxCifrados, 4, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1064, 555);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelEncriptar
            // 
            this.labelEncriptar.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.SetColumnSpan(this.labelEncriptar, 3);
            this.labelEncriptar.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEncriptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncriptar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEncriptar.Location = new System.Drawing.Point(3, 0);
            this.labelEncriptar.Name = "labelEncriptar";
            this.labelEncriptar.Size = new System.Drawing.Size(408, 21);
            this.labelEncriptar.TabIndex = 0;
            this.labelEncriptar.Text = "Encriptar";
            this.labelEncriptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEncriptar
            // 
            this.textBoxEncriptar.AllowDrop = true;
            this.tableLayoutPanel.SetColumnSpan(this.textBoxEncriptar, 5);
            this.textBoxEncriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEncriptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEncriptar.Location = new System.Drawing.Point(3, 31);
            this.textBoxEncriptar.Multiline = true;
            this.textBoxEncriptar.Name = "textBoxEncriptar";
            this.textBoxEncriptar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEncriptar.Size = new System.Drawing.Size(620, 128);
            this.textBoxEncriptar.TabIndex = 1;
            this.textBoxEncriptar.Enter += new System.EventHandler(this.textBoxEncriptar_Enter);
            // 
            // comboBoxEncriptaciones
            // 
            this.tableLayoutPanel.SetColumnSpan(this.comboBoxEncriptaciones, 2);
            this.comboBoxEncriptaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEncriptaciones.FormattingEnabled = true;
            this.comboBoxEncriptaciones.Location = new System.Drawing.Point(417, 3);
            this.comboBoxEncriptaciones.Name = "comboBoxEncriptaciones";
            this.comboBoxEncriptaciones.Size = new System.Drawing.Size(206, 24);
            this.comboBoxEncriptaciones.TabIndex = 13;
            this.comboBoxEncriptaciones.SelectedIndexChanged += new System.EventHandler(this.comboBoxEncriptaciones_SelectedIndexChanged);
            // 
            // panelSeparador1
            // 
            this.panelSeparador1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSeparador1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeparador1.Location = new System.Drawing.Point(629, 3);
            this.panelSeparador1.Name = "panelSeparador1";
            this.tableLayoutPanel.SetRowSpan(this.panelSeparador1, 7);
            this.panelSeparador1.Size = new System.Drawing.Size(4, 479);
            this.panelSeparador1.TabIndex = 2;
            // 
            // panelSeparador2
            // 
            this.panelSeparador2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel.SetColumnSpan(this.panelSeparador2, 5);
            this.panelSeparador2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeparador2.Location = new System.Drawing.Point(3, 321);
            this.panelSeparador2.Name = "panelSeparador2";
            this.panelSeparador2.Size = new System.Drawing.Size(620, 5);
            this.panelSeparador2.TabIndex = 5;
            // 
            // panelSeparador3
            // 
            this.panelSeparador3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel.SetColumnSpan(this.panelSeparador3, 7);
            this.panelSeparador3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSeparador3.Location = new System.Drawing.Point(3, 488);
            this.panelSeparador3.Name = "panelSeparador3";
            this.panelSeparador3.Size = new System.Drawing.Size(1058, 5);
            this.panelSeparador3.TabIndex = 5;
            // 
            // labelDesencriptar
            // 
            this.tableLayoutPanel.SetColumnSpan(this.labelDesencriptar, 5);
            this.labelDesencriptar.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDesencriptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesencriptar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDesencriptar.Location = new System.Drawing.Point(3, 329);
            this.labelDesencriptar.Name = "labelDesencriptar";
            this.labelDesencriptar.Size = new System.Drawing.Size(620, 20);
            this.labelDesencriptar.TabIndex = 3;
            this.labelDesencriptar.Text = "Desencriptar";
            this.labelDesencriptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDesencriptar
            // 
            this.textBoxDesencriptar.AllowDrop = true;
            this.tableLayoutPanel.SetColumnSpan(this.textBoxDesencriptar, 5);
            this.textBoxDesencriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDesencriptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDesencriptar.Location = new System.Drawing.Point(3, 360);
            this.textBoxDesencriptar.Multiline = true;
            this.textBoxDesencriptar.Name = "textBoxDesencriptar";
            this.textBoxDesencriptar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDesencriptar.Size = new System.Drawing.Size(620, 122);
            this.textBoxDesencriptar.TabIndex = 4;
            this.textBoxDesencriptar.Enter += new System.EventHandler(this.textBoxDesencriptar_Enter);
            // 
            // labelResultado
            // 
            this.labelResultado.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.ForeColor = System.Drawing.Color.Green;
            this.labelResultado.Location = new System.Drawing.Point(639, 0);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(422, 21);
            this.labelResultado.TabIndex = 6;
            this.labelResultado.Text = "Resultado";
            this.labelResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxResultado
            // 
            this.textBoxResultado.AllowDrop = true;
            this.textBoxResultado.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResultado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxResultado.HideSelection = false;
            this.textBoxResultado.Location = new System.Drawing.Point(639, 31);
            this.textBoxResultado.Multiline = true;
            this.textBoxResultado.Name = "textBoxResultado";
            this.textBoxResultado.ReadOnly = true;
            this.tableLayoutPanel.SetRowSpan(this.textBoxResultado, 6);
            this.textBoxResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResultado.Size = new System.Drawing.Size(422, 451);
            this.textBoxResultado.TabIndex = 6;
            // 
            // btnRealizar
            // 
            this.btnRealizar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.tableLayoutPanel.SetColumnSpan(this.btnRealizar, 7);
            this.btnRealizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRealizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnRealizar.Location = new System.Drawing.Point(3, 499);
            this.btnRealizar.Name = "btnRealizar";
            this.btnRealizar.Size = new System.Drawing.Size(1058, 53);
            this.btnRealizar.TabIndex = 1;
            this.btnRealizar.Text = "Realizar";
            this.btnRealizar.UseVisualStyleBackColor = false;
            this.btnRealizar.Click += new System.EventHandler(this.btnRealizar_Click_1);
            // 
            // labelLlaveEncriPrivada
            // 
            this.labelLlaveEncriPrivada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLlaveEncriPrivada.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLlaveEncriPrivada.Location = new System.Drawing.Point(215, 162);
            this.labelLlaveEncriPrivada.Name = "labelLlaveEncriPrivada";
            this.labelLlaveEncriPrivada.Size = new System.Drawing.Size(196, 28);
            this.labelLlaveEncriPrivada.TabIndex = 7;
            this.labelLlaveEncriPrivada.Text = "Llave X";
            this.labelLlaveEncriPrivada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEspecial
            // 
            this.panelEspecial.BackColor = System.Drawing.Color.Black;
            this.panelEspecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEspecial.Location = new System.Drawing.Point(205, 165);
            this.panelEspecial.Name = "panelEspecial";
            this.tableLayoutPanel.SetRowSpan(this.panelEspecial, 2);
            this.panelEspecial.Size = new System.Drawing.Size(4, 150);
            this.panelEspecial.TabIndex = 8;
            // 
            // panelEspecial2
            // 
            this.panelEspecial2.BackColor = System.Drawing.Color.Black;
            this.panelEspecial2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEspecial2.Location = new System.Drawing.Point(417, 165);
            this.panelEspecial2.Name = "panelEspecial2";
            this.tableLayoutPanel.SetRowSpan(this.panelEspecial2, 2);
            this.panelEspecial2.Size = new System.Drawing.Size(4, 150);
            this.panelEspecial2.TabIndex = 9;
            // 
            // textBoxLlaveEncriPrivada
            // 
            this.textBoxLlaveEncriPrivada.AllowDrop = true;
            this.textBoxLlaveEncriPrivada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLlaveEncriPrivada.HideSelection = false;
            this.textBoxLlaveEncriPrivada.Location = new System.Drawing.Point(215, 193);
            this.textBoxLlaveEncriPrivada.Multiline = true;
            this.textBoxLlaveEncriPrivada.Name = "textBoxLlaveEncriPrivada";
            this.textBoxLlaveEncriPrivada.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLlaveEncriPrivada.Size = new System.Drawing.Size(196, 122);
            this.textBoxLlaveEncriPrivada.TabIndex = 10;
            this.textBoxLlaveEncriPrivada.Enter += new System.EventHandler(this.textBoxLlaveEncriPrivada_Enter);
            this.textBoxLlaveEncriPrivada.Leave += new System.EventHandler(this.textBoxLlaveEncriPrivada_Leave);
            // 
            // labelLlavePublica
            // 
            this.labelLlavePublica.AutoSize = true;
            this.labelLlavePublica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLlavePublica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLlavePublica.Location = new System.Drawing.Point(3, 162);
            this.labelLlavePublica.Name = "labelLlavePublica";
            this.labelLlavePublica.Size = new System.Drawing.Size(196, 28);
            this.labelLlavePublica.TabIndex = 11;
            this.labelLlavePublica.Text = "Llave Publica";
            this.labelLlavePublica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxLlavePublica
            // 
            this.textBoxLlavePublica.AllowDrop = true;
            this.textBoxLlavePublica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLlavePublica.HideSelection = false;
            this.textBoxLlavePublica.Location = new System.Drawing.Point(3, 193);
            this.textBoxLlavePublica.Multiline = true;
            this.textBoxLlavePublica.Name = "textBoxLlavePublica";
            this.textBoxLlavePublica.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLlavePublica.Size = new System.Drawing.Size(196, 122);
            this.textBoxLlavePublica.TabIndex = 12;
            this.textBoxLlavePublica.Text = " ";
            this.textBoxLlavePublica.Enter += new System.EventHandler(this.textBoxLlavePublica_Enter);
            // 
            // comboBoxLongitudesLlave
            // 
            this.comboBoxLongitudesLlave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLongitudesLlave.FormattingEnabled = true;
            this.comboBoxLongitudesLlave.Location = new System.Drawing.Point(427, 165);
            this.comboBoxLongitudesLlave.Name = "comboBoxLongitudesLlave";
            this.comboBoxLongitudesLlave.Size = new System.Drawing.Size(196, 24);
            this.comboBoxLongitudesLlave.TabIndex = 14;
            this.comboBoxLongitudesLlave.SelectedIndexChanged += new System.EventHandler(this.comboBoxLongitudesLlave_SelectedIndexChanged);
            // 
            // comboBoxCifrados
            // 
            this.comboBoxCifrados.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxCifrados.FormattingEnabled = true;
            this.comboBoxCifrados.Location = new System.Drawing.Point(427, 193);
            this.comboBoxCifrados.Name = "comboBoxCifrados";
            this.comboBoxCifrados.Size = new System.Drawing.Size(196, 24);
            this.comboBoxCifrados.TabIndex = 15;
            this.comboBoxCifrados.SelectedIndexChanged += new System.EventHandler(this.comboBoxCifrados_SelectedIndexChanged);
            // 
            // Principal
            // 
            this.ClientSize = new System.Drawing.Size(1064, 555);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enigma v2.0.270524avs";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

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
        private Label labelEncriptar;
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
        private Panel panelEspecial2;
        private TextBox textBoxLlaveEncriPrivada;
        private Label labelLlavePublica;
        private TextBox textBoxLlavePublica;
        private ComboBox comboBoxEncriptaciones;
        private ComboBox comboBoxLongitudesLlave;
        private ComboBox comboBoxCifrados;
    }
}

