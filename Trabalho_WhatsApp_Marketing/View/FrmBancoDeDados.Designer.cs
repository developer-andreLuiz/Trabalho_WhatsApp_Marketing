
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
            this.btnEstadoMunicipioBairro = new System.Windows.Forms.Button();
            this.btnEmulador = new System.Windows.Forms.Button();
            this.btnContato = new System.Windows.Forms.Button();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.btnEstadoMunicipioBairro);
            this.panelForm.Controls.Add(this.btnEmulador);
            this.panelForm.Controls.Add(this.btnContato);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(725, 598);
            this.panelForm.TabIndex = 2;
            // 
            // btnEstadoMunicipioBairro
            // 
            this.btnEstadoMunicipioBairro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEstadoMunicipioBairro.FlatAppearance.BorderSize = 0;
            this.btnEstadoMunicipioBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoMunicipioBairro.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoMunicipioBairro.ForeColor = System.Drawing.Color.White;
            this.btnEstadoMunicipioBairro.Location = new System.Drawing.Point(502, 61);
            this.btnEstadoMunicipioBairro.Name = "btnEstadoMunicipioBairro";
            this.btnEstadoMunicipioBairro.Size = new System.Drawing.Size(157, 53);
            this.btnEstadoMunicipioBairro.TabIndex = 44;
            this.btnEstadoMunicipioBairro.Text = "Estado / Municipio / Bairro";
            this.btnEstadoMunicipioBairro.UseVisualStyleBackColor = false;
            this.btnEstadoMunicipioBairro.Click += new System.EventHandler(this.btnEstadoMunicipioBairro_Click);
            // 
            // btnEmulador
            // 
            this.btnEmulador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEmulador.FlatAppearance.BorderSize = 0;
            this.btnEmulador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmulador.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmulador.ForeColor = System.Drawing.Color.White;
            this.btnEmulador.Location = new System.Drawing.Point(69, 61);
            this.btnEmulador.Name = "btnEmulador";
            this.btnEmulador.Size = new System.Drawing.Size(157, 53);
            this.btnEmulador.TabIndex = 40;
            this.btnEmulador.Text = "Emulador";
            this.btnEmulador.UseVisualStyleBackColor = false;
            this.btnEmulador.Click += new System.EventHandler(this.btnEmulador_Click);
            // 
            // btnContato
            // 
            this.btnContato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContato.FlatAppearance.BorderSize = 0;
            this.btnContato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContato.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContato.ForeColor = System.Drawing.Color.White;
            this.btnContato.Location = new System.Drawing.Point(288, 61);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnEstadoMunicipioBairro;
        private System.Windows.Forms.Button btnEmulador;
        private System.Windows.Forms.Button btnContato;
    }
}