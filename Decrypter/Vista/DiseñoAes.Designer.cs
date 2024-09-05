using System.Drawing;

namespace Enigma.Vista {
    partial class DiseñoAes {
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
            this.tlpContenedorAes = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEncriptar = new System.Windows.Forms.TextBox();
            this.txtLlaveEncriptado = new System.Windows.Forms.TextBox();
            this.txtDesencriptar = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.tlpContenedorAes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContenedorAes
            // 
            this.tlpContenedorAes.BackColor = System.Drawing.Color.MidnightBlue;
            this.tlpContenedorAes.ColumnCount = 3;
            this.tlpContenedorAes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContenedorAes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tlpContenedorAes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlpContenedorAes.Controls.Add(this.label1, 0, 0);
            this.tlpContenedorAes.Controls.Add(this.splitter1, 1, 0);
            this.tlpContenedorAes.Controls.Add(this.label2, 2, 0);
            this.tlpContenedorAes.Controls.Add(this.label3, 0, 2);
            this.tlpContenedorAes.Controls.Add(this.label4, 0, 4);
            this.tlpContenedorAes.Controls.Add(this.txtEncriptar, 0, 1);
            this.tlpContenedorAes.Controls.Add(this.txtLlaveEncriptado, 0, 3);
            this.tlpContenedorAes.Controls.Add(this.txtDesencriptar, 0, 5);
            this.tlpContenedorAes.Controls.Add(this.txtResultado, 2, 1);
            this.tlpContenedorAes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenedorAes.Location = new System.Drawing.Point(0, 0);
            this.tlpContenedorAes.Name = "tlpContenedorAes";
            this.tlpContenedorAes.RowCount = 6;
            this.tlpContenedorAes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpContenedorAes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpContenedorAes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpContenedorAes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpContenedorAes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpContenedorAes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tlpContenedorAes.Size = new System.Drawing.Size(150, 150);
            this.tlpContenedorAes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 7);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encriptar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Info;
            this.splitter1.Location = new System.Drawing.Point(78, 3);
            this.splitter1.Name = "splitter1";
            this.tlpContenedorAes.SetRowSpan(this.splitter1, 6);
            this.splitter1.Size = new System.Drawing.Size(1, 144);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(82, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 7);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resultado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 7);
            this.label3.TabIndex = 3;
            this.label3.Text = "Llave Encriptado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 7);
            this.label4.TabIndex = 4;
            this.label4.Text = "Desencriptar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEncriptar
            // 
            this.txtEncriptar.BackColor = System.Drawing.Color.Azure;
            this.txtEncriptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEncriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEncriptar.HideSelection = false;
            this.txtEncriptar.Location = new System.Drawing.Point(3, 10);
            this.txtEncriptar.Multiline = true;
            this.txtEncriptar.Name = "txtEncriptar";
            this.txtEncriptar.Size = new System.Drawing.Size(69, 51);
            this.txtEncriptar.TabIndex = 5;
            this.txtEncriptar.Enter += new System.EventHandler(this.txtEncriptar_Enter);
            this.txtEncriptar.MouseEnter += new System.EventHandler(this.txtEncriptar_MouseEnter);
            this.txtEncriptar.MouseLeave += new System.EventHandler(this.txtEncriptar_MouseLeave);
            // 
            // txtLlaveEncriptado
            // 
            this.txtLlaveEncriptado.BackColor = System.Drawing.Color.Wheat;
            this.txtLlaveEncriptado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLlaveEncriptado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLlaveEncriptado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLlaveEncriptado.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLlaveEncriptado.ForeColor = System.Drawing.Color.LightGray;
            this.txtLlaveEncriptado.HideSelection = false;
            this.txtLlaveEncriptado.Location = new System.Drawing.Point(3, 74);
            this.txtLlaveEncriptado.Name = "txtLlaveEncriptado";
            this.txtLlaveEncriptado.Size = new System.Drawing.Size(69, 31);
            this.txtLlaveEncriptado.TabIndex = 6;
            this.txtLlaveEncriptado.TextChanged += new System.EventHandler(this.txtLlaveEncriptado_TextChanged);
            this.txtLlaveEncriptado.Enter += new System.EventHandler(this.txtLlaveEncriptado_Enter);
            this.txtLlaveEncriptado.Leave += new System.EventHandler(this.txtLlaveEncriptado_Leave);
            this.txtLlaveEncriptado.MouseEnter += new System.EventHandler(this.txtLlaveEncriptado_MouseEnter);
            this.txtLlaveEncriptado.MouseLeave += new System.EventHandler(this.txtLlaveEncriptado_MouseLeave);
            // 
            // txtDesencriptar
            // 
            this.txtDesencriptar.BackColor = System.Drawing.Color.Azure;
            this.txtDesencriptar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesencriptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesencriptar.HideSelection = false;
            this.txtDesencriptar.Location = new System.Drawing.Point(3, 96);
            this.txtDesencriptar.Multiline = true;
            this.txtDesencriptar.Name = "txtDesencriptar";
            this.txtDesencriptar.Size = new System.Drawing.Size(69, 51);
            this.txtDesencriptar.TabIndex = 7;
            this.txtDesencriptar.Enter += new System.EventHandler(this.txtDesencriptar_Enter);
            this.txtDesencriptar.MouseEnter += new System.EventHandler(this.txtDesencriptar_MouseEnter);
            this.txtDesencriptar.MouseLeave += new System.EventHandler(this.txtDesencriptar_MouseLeave);
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.Color.Azure;
            this.txtResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.HideSelection = false;
            this.txtResultado.Location = new System.Drawing.Point(82, 10);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.tlpContenedorAes.SetRowSpan(this.txtResultado, 5);
            this.txtResultado.Size = new System.Drawing.Size(65, 137);
            this.txtResultado.TabIndex = 8;
            this.txtResultado.MouseEnter += new System.EventHandler(this.txtResultado_MouseEnter);
            this.txtResultado.MouseLeave += new System.EventHandler(this.txtResultado_MouseLeave);
            // 
            // DiseñoAes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpContenedorAes);
            this.Name = "DiseñoAes";
            this.tlpContenedorAes.ResumeLayout(false);
            this.tlpContenedorAes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlpContenedorAes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtEncriptar;
        public System.Windows.Forms.TextBox txtLlaveEncriptado;
        public System.Windows.Forms.TextBox txtDesencriptar;
        public System.Windows.Forms.TextBox txtResultado;
    }
}
