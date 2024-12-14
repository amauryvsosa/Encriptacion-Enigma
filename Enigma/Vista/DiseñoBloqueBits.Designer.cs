namespace Enigma.Vista {
    partial class DiseñoBloqueBits {
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.tlpBloqueBits = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboxTipoEncriptacion = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtEncriptar = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtDesencriptar = new System.Windows.Forms.TextBox();
            this.tlpBloqueBits.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBloqueBits
            // 
            this.tlpBloqueBits.BackColor = System.Drawing.Color.MidnightBlue;
            this.tlpBloqueBits.ColumnCount = 4;
            this.tlpBloqueBits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBloqueBits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBloqueBits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tlpBloqueBits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpBloqueBits.Controls.Add(this.label1, 0, 0);
            this.tlpBloqueBits.Controls.Add(this.label2, 3, 0);
            this.tlpBloqueBits.Controls.Add(this.label3, 0, 2);
            this.tlpBloqueBits.Controls.Add(this.label4, 0, 3);
            this.tlpBloqueBits.Controls.Add(this.comboxTipoEncriptacion, 1, 2);
            this.tlpBloqueBits.Controls.Add(this.splitter1, 2, 0);
            this.tlpBloqueBits.Controls.Add(this.txtEncriptar, 0, 1);
            this.tlpBloqueBits.Controls.Add(this.txtResultado, 3, 1);
            this.tlpBloqueBits.Controls.Add(this.txtDesencriptar, 0, 4);
            this.tlpBloqueBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBloqueBits.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tlpBloqueBits.Location = new System.Drawing.Point(0, 0);
            this.tlpBloqueBits.Name = "tlpBloqueBits";
            this.tlpBloqueBits.RowCount = 4;
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBloqueBits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBloqueBits.Size = new System.Drawing.Size(150, 150);
            this.tlpBloqueBits.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tlpBloqueBits.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 7);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encriptar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(81, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 7);
            this.label2.TabIndex = 1;
            this.label2.Text = "Resultado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 7);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Encriptación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tlpBloqueBits.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 7);
            this.label4.TabIndex = 3;
            this.label4.Text = "Desencriptar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboxTipoEncriptacion
            // 
            this.comboxTipoEncriptacion.BackColor = System.Drawing.Color.White;
            this.comboxTipoEncriptacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboxTipoEncriptacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboxTipoEncriptacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxTipoEncriptacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboxTipoEncriptacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxTipoEncriptacion.ForeColor = System.Drawing.Color.Black;
            this.comboxTipoEncriptacion.FormattingEnabled = true;
            this.comboxTipoEncriptacion.Items.AddRange(new object[] {
            "Encriptación Basica",
            "Encriptación Avanzada"});
            this.comboxTipoEncriptacion.Location = new System.Drawing.Point(40, 74);
            this.comboxTipoEncriptacion.Name = "comboxTipoEncriptacion";
            this.comboxTipoEncriptacion.Size = new System.Drawing.Size(31, 36);
            this.comboxTipoEncriptacion.TabIndex = 4;
            this.comboxTipoEncriptacion.Enter += new System.EventHandler(this.comboxTipoEncriptacion_Enter);
            this.comboxTipoEncriptacion.Leave += new System.EventHandler(this.comboxTipoEncriptacion_Leave);
            this.comboxTipoEncriptacion.MouseEnter += new System.EventHandler(this.comboxTipoEncriptacion_MouseEnter);
            this.comboxTipoEncriptacion.MouseLeave += new System.EventHandler(this.comboxTipoEncriptacion_MouseLeave);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.splitter1.Location = new System.Drawing.Point(77, 3);
            this.splitter1.Name = "splitter1";
            this.tlpBloqueBits.SetRowSpan(this.splitter1, 5);
            this.splitter1.Size = new System.Drawing.Size(1, 144);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // txtEncriptar
            // 
            this.txtEncriptar.AllowDrop = true;
            this.txtEncriptar.BackColor = System.Drawing.Color.Azure;
            this.tlpBloqueBits.SetColumnSpan(this.txtEncriptar, 2);
            this.txtEncriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEncriptar.HideSelection = false;
            this.txtEncriptar.Location = new System.Drawing.Point(3, 10);
            this.txtEncriptar.Multiline = true;
            this.txtEncriptar.Name = "txtEncriptar";
            this.txtEncriptar.Size = new System.Drawing.Size(68, 58);
            this.txtEncriptar.TabIndex = 6;
            this.txtEncriptar.Enter += new System.EventHandler(this.txtEncriptar_Enter);
            this.txtEncriptar.MouseEnter += new System.EventHandler(this.txtEncriptar_MouseEnter);
            this.txtEncriptar.MouseLeave += new System.EventHandler(this.txtEncriptar_MouseLeave);
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.Azure;
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.HideSelection = false;
            this.txtResultado.Location = new System.Drawing.Point(81, 10);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.tlpBloqueBits.SetRowSpan(this.txtResultado, 4);
            this.txtResultado.Size = new System.Drawing.Size(66, 137);
            this.txtResultado.TabIndex = 7;
            this.txtResultado.MouseEnter += new System.EventHandler(this.txtResultado_MouseEnter);
            this.txtResultado.MouseLeave += new System.EventHandler(this.txtResultado_MouseLeave);
            // 
            // txtDesencriptar
            // 
            this.txtDesencriptar.AllowDrop = true;
            this.txtDesencriptar.BackColor = System.Drawing.Color.Azure;
            this.tlpBloqueBits.SetColumnSpan(this.txtDesencriptar, 2);
            this.txtDesencriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesencriptar.HideSelection = false;
            this.txtDesencriptar.Location = new System.Drawing.Point(3, 88);
            this.txtDesencriptar.Multiline = true;
            this.txtDesencriptar.Name = "txtDesencriptar";
            this.txtDesencriptar.Size = new System.Drawing.Size(68, 59);
            this.txtDesencriptar.TabIndex = 8;
            this.txtDesencriptar.Enter += new System.EventHandler(this.txtDesencriptar_Enter);
            this.txtDesencriptar.MouseEnter += new System.EventHandler(this.txtDesencriptar_MouseEnter);
            this.txtDesencriptar.MouseLeave += new System.EventHandler(this.txtDesencriptar_MouseLeave);
            // 
            // DiseñoBloqueBits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpBloqueBits);
            this.Name = "DiseñoBloqueBits";
            this.tlpBloqueBits.ResumeLayout(false);
            this.tlpBloqueBits.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlpBloqueBits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboxTipoEncriptacion;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.TextBox txtEncriptar;
        public System.Windows.Forms.TextBox txtResultado;
        public System.Windows.Forms.TextBox txtDesencriptar;
    }
}
