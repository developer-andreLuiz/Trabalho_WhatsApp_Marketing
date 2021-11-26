
namespace Trabalho_WhatsApp.View
{
    partial class FrmSorteio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarInformacao = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nUD = new System.Windows.Forms.NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTotalCurti = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalNumeros = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVolumeCurti = new System.Windows.Forms.Label();
            this.lblQuantidadeTexto = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 46);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sorteio";
            // 
            // btnBuscarInformacao
            // 
            this.btnBuscarInformacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnBuscarInformacao.FlatAppearance.BorderSize = 0;
            this.btnBuscarInformacao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.btnBuscarInformacao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(69)))), ((int)(((byte)(98)))));
            this.btnBuscarInformacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInformacao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarInformacao.ForeColor = System.Drawing.Color.White;
            this.btnBuscarInformacao.Location = new System.Drawing.Point(573, 110);
            this.btnBuscarInformacao.Name = "btnBuscarInformacao";
            this.btnBuscarInformacao.Size = new System.Drawing.Size(152, 49);
            this.btnBuscarInformacao.TabIndex = 74;
            this.btnBuscarInformacao.Text = "Buscar Informação";
            this.btnBuscarInformacao.UseVisualStyleBackColor = false;
            this.btnBuscarInformacao.Click += new System.EventHandler(this.btnBuscarInformacao_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label3.Location = new System.Drawing.Point(18, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 19);
            this.label3.TabIndex = 75;
            this.label3.Text = "Números de Curti";
            // 
            // nUD
            // 
            this.nUD.BackColor = System.Drawing.Color.White;
            this.nUD.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUD.Location = new System.Drawing.Point(18, 110);
            this.nUD.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD.Name = "nUD";
            this.nUD.Size = new System.Drawing.Size(128, 41);
            this.nUD.TabIndex = 76;
            this.nUD.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(12, 182);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(107, 22);
            this.panel6.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(2, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 19);
            this.label12.TabIndex = 15;
            this.label12.Text = "Informações";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblTotalCurti);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.lblTotalNumeros);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.lblVolumeCurti);
            this.panel7.Controls.Add(this.lblQuantidadeTexto);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Location = new System.Drawing.Point(12, 219);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(713, 153);
            this.panel7.TabIndex = 78;
            // 
            // lblTotalCurti
            // 
            this.lblTotalCurti.AutoSize = true;
            this.lblTotalCurti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCurti.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalCurti.Location = new System.Drawing.Point(245, 110);
            this.lblTotalCurti.Name = "lblTotalCurti";
            this.lblTotalCurti.Size = new System.Drawing.Size(20, 22);
            this.lblTotalCurti.TabIndex = 39;
            this.lblTotalCurti.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label8.Location = new System.Drawing.Point(5, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 19);
            this.label8.TabIndex = 38;
            this.label8.Text = "Total de Curti :";
            // 
            // lblTotalNumeros
            // 
            this.lblTotalNumeros.AutoSize = true;
            this.lblTotalNumeros.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNumeros.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalNumeros.Location = new System.Drawing.Point(245, 58);
            this.lblTotalNumeros.Name = "lblTotalNumeros";
            this.lblTotalNumeros.Size = new System.Drawing.Size(20, 22);
            this.lblTotalNumeros.TabIndex = 37;
            this.lblTotalNumeros.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label7.Location = new System.Drawing.Point(5, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 19);
            this.label7.TabIndex = 35;
            this.label7.Text = "Total de Números :";
            // 
            // lblVolumeCurti
            // 
            this.lblVolumeCurti.AutoSize = true;
            this.lblVolumeCurti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeCurti.ForeColor = System.Drawing.Color.Maroon;
            this.lblVolumeCurti.Location = new System.Drawing.Point(245, 12);
            this.lblVolumeCurti.Name = "lblVolumeCurti";
            this.lblVolumeCurti.Size = new System.Drawing.Size(20, 22);
            this.lblVolumeCurti.TabIndex = 34;
            this.lblVolumeCurti.Text = "0";
            // 
            // lblQuantidadeTexto
            // 
            this.lblQuantidadeTexto.AutoSize = true;
            this.lblQuantidadeTexto.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeTexto.ForeColor = System.Drawing.Color.Black;
            this.lblQuantidadeTexto.Location = new System.Drawing.Point(105, 10);
            this.lblQuantidadeTexto.Name = "lblQuantidadeTexto";
            this.lblQuantidadeTexto.Size = new System.Drawing.Size(20, 22);
            this.lblQuantidadeTexto.TabIndex = 33;
            this.lblQuantidadeTexto.Text = "3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.label18.Location = new System.Drawing.Point(3, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(239, 19);
            this.label18.TabIndex = 22;
            this.label18.Text = "Números com          ou mais Curti :";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(123)))), ((int)(((byte)(179)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(69)))), ((int)(((byte)(98)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(462, 515);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(263, 49);
            this.btnImprimir.TabIndex = 79;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmSorteio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(737, 595);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUD);
            this.Controls.Add(this.btnBuscarInformacao);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSorteio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSorteio";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarInformacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUD;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotalNumeros;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblVolumeCurti;
        private System.Windows.Forms.Label lblQuantidadeTexto;
        private System.Windows.Forms.Label lblTotalCurti;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnImprimir;
    }
}