
namespace Trabalho_WhatsApp_Marketing.View
{
    partial class FrmBancoDeDados
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEstadoMunicipioBairro = new System.Windows.Forms.Button();
            this.btnEmulador = new System.Windows.Forms.Button();
            this.btnContato = new System.Windows.Forms.Button();
            this.panelForm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.panel1);
            this.panelForm.Controls.Add(this.btnEstadoMunicipioBairro);
            this.panelForm.Controls.Add(this.btnEmulador);
            this.panelForm.Controls.Add(this.btnContato);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(725, 598);
            this.panelForm.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 55);
            this.panel1.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 27);
            this.label1.TabIndex = 45;
            this.label1.Text = "Tabelas do Banco de Dados";
            // 
            // btnEstadoMunicipioBairro
            // 
            this.btnEstadoMunicipioBairro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnEstadoMunicipioBairro.FlatAppearance.BorderSize = 0;
            this.btnEstadoMunicipioBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoMunicipioBairro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoMunicipioBairro.ForeColor = System.Drawing.Color.White;
            this.btnEstadoMunicipioBairro.Location = new System.Drawing.Point(59, 259);
            this.btnEstadoMunicipioBairro.Name = "btnEstadoMunicipioBairro";
            this.btnEstadoMunicipioBairro.Size = new System.Drawing.Size(157, 53);
            this.btnEstadoMunicipioBairro.TabIndex = 44;
            this.btnEstadoMunicipioBairro.Text = "Estado - Municipio - Bairro";
            this.btnEstadoMunicipioBairro.UseVisualStyleBackColor = false;
            this.btnEstadoMunicipioBairro.Click += new System.EventHandler(this.btnEstadoMunicipioBairro_Click);
            // 
            // btnEmulador
            // 
            this.btnEmulador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnEmulador.FlatAppearance.BorderSize = 0;
            this.btnEmulador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmulador.ForeColor = System.Drawing.Color.White;
            this.btnEmulador.Location = new System.Drawing.Point(59, 119);
            this.btnEmulador.Name = "btnEmulador";
            this.btnEmulador.Size = new System.Drawing.Size(157, 53);
            this.btnEmulador.TabIndex = 40;
            this.btnEmulador.Text = "Emulador";
            this.btnEmulador.UseVisualStyleBackColor = false;
            this.btnEmulador.Click += new System.EventHandler(this.btnEmulador_Click);
            // 
            // btnContato
            // 
            this.btnContato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnContato.FlatAppearance.BorderSize = 0;
            this.btnContato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContato.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContato.ForeColor = System.Drawing.Color.White;
            this.btnContato.Location = new System.Drawing.Point(59, 189);
            this.btnContato.Name = "btnContato";
            this.btnContato.Size = new System.Drawing.Size(157, 53);
            this.btnContato.TabIndex = 39;
            this.btnContato.Text = "Contato";
            this.btnContato.UseVisualStyleBackColor = false;
            this.btnContato.Click += new System.EventHandler(this.btnContato_Click);
            // 
            // FrmBancoDeDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 598);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBancoDeDados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEnvio";
            this.panelForm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnEstadoMunicipioBairro;
        private System.Windows.Forms.Button btnEmulador;
        private System.Windows.Forms.Button btnContato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}