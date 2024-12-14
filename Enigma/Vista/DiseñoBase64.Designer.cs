namespace Enigma.Diseños {
    partial class DiseñoBase64 {
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
            this.tlpContenedorBase64 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEncriptar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesencriptar = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.tlpContenedorBase64.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContenedorBase64
            // 
            this.tlpContenedorBase64.BackColor = System.Drawing.Color.MidnightBlue;
            this.tlpContenedorBase64.ColumnCount = 3;
            this.tlpContenedorBase64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tlpContenedorBase64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tlpContenedorBase64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tlpContenedorBase64.Controls.Add(this.label1, 0, 0);
            this.tlpContenedorBase64.Controls.Add(this.splitter1, 1, 0);
            this.tlpContenedorBase64.Controls.Add(this.label2, 2, 0);
            this.tlpContenedorBase64.Controls.Add(this.txtEncriptar, 0, 1);
            this.tlpContenedorBase64.Controls.Add(this.label3, 0, 2);
            this.tlpContenedorBase64.Controls.Add(this.txtDesencriptar, 0, 3);
            this.tlpContenedorBase64.Controls.Add(this.txtResultado, 2, 1);
            this.tlpContenedorBase64.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenedorBase64.Location = new System.Drawing.Point(0, 0);
            this.tlpContenedorBase64.Name = "tlpContenedorBase64";
            this.tlpContenedorBase64.RowCount = 4;
            this.tlpContenedorBase64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpContenedorBase64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpContenedorBase64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpContenedorBase64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpContenedorBase64.Size = new System.Drawing.Size(150, 150);
            this.tlpContenedorBase64.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encriptar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.splitter1.Location = new System.Drawing.Point(95, 4);
            this.splitter1.Name = "splitter1";
            this.tlpContenedorBase64.SetRowSpan(this.splitter1, 4);
            this.splitter1.Size = new System.Drawing.Size(1, 180);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resultado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEncriptar
            // 
            this.txtEncriptar.AllowDrop = true;
            this.txtEncriptar.BackColor = System.Drawing.Color.Azure;
            this.txtEncriptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEncriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEncriptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncriptar.HideSelection = false;
            this.txtEncriptar.Location = new System.Drawing.Point(3, 18);
            this.txtEncriptar.Multiline = true;
            this.txtEncriptar.Name = "txtEncriptar";
            this.txtEncriptar.Size = new System.Drawing.Size(67, 54);
            this.txtEncriptar.TabIndex = 3;
            this.txtEncriptar.Enter += new System.EventHandler(this.txtEncriptar_Enter);
            this.txtEncriptar.MouseEnter += new System.EventHandler(this.txtEncriptar_MouseEnter);
            this.txtEncriptar.MouseLeave += new System.EventHandler(this.txtEncriptar_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Desencriptar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDesencriptar
            // 
            this.txtDesencriptar.BackColor = System.Drawing.Color.Azure;
            this.txtDesencriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesencriptar.HideSelection = false;
            this.txtDesencriptar.Location = new System.Drawing.Point(3, 93);
            this.txtDesencriptar.Multiline = true;
            this.txtDesencriptar.Name = "txtDesencriptar";
            this.txtDesencriptar.Size = new System.Drawing.Size(67, 54);
            this.txtDesencriptar.TabIndex = 5;
            this.txtDesencriptar.Enter += new System.EventHandler(this.txtDesencriptar_Enter);
            this.txtDesencriptar.MouseEnter += new System.EventHandler(this.txtDesencriptar_MouseEnter);
            this.txtDesencriptar.MouseLeave += new System.EventHandler(this.txtDesencriptar_MouseLeave);
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.Azure;
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.HideSelection = false;
            this.txtResultado.Location = new System.Drawing.Point(82, 20);
            this.txtResultado.Margin = new System.Windows.Forms.Padding(5);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.tlpContenedorBase64.SetRowSpan(this.txtResultado, 3);
            this.txtResultado.Size = new System.Drawing.Size(63, 125);
            this.txtResultado.TabIndex = 6;
            this.txtResultado.MouseEnter += new System.EventHandler(this.txtResultado_MouseEnter);
            this.txtResultado.MouseLeave += new System.EventHandler(this.txtResultado_MouseLeave);
            // 
            // DiseñoBase64
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpContenedorBase64);
            this.Name = "DiseñoBase64";
            this.tlpContenedorBase64.ResumeLayout(false);
            this.tlpContenedorBase64.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlpContenedorBase64;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtEncriptar;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDesencriptar;
        public System.Windows.Forms.TextBox txtResultado;
    }
}
