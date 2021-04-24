
namespace Trabalho_WhatsApp_Marketing.View
{
    partial class FrmContatosEmuladores
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblContatosSelecionados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportarParaVerificacao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAbrirEmulador = new System.Windows.Forms.Button();
            this.cbEmulador = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciarVerificacao = new System.Windows.Forms.Button();
            this.btnExportarParaEmail = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblContatosTotaisInfo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblContatosSemWhatsAppInfo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblContatosComWhatsInfo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblContatosRestantes = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timerProcesso = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 55);
            this.panel1.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 27);
            this.label7.TabIndex = 45;
            this.label7.Text = "Contatos - Emuladores";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblContatosSelecionados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.btnExportarParaVerificacao);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 117);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // lblContatosSelecionados
            // 
            this.lblContatosSelecionados.AutoSize = true;
            this.lblContatosSelecionados.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatosSelecionados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.lblContatosSelecionados.Location = new System.Drawing.Point(246, 63);
            this.lblContatosSelecionados.Name = "lblContatosSelecionados";
            this.lblContatosSelecionados.Size = new System.Drawing.Size(21, 24);
            this.lblContatosSelecionados.TabIndex = 60;
            this.lblContatosSelecionados.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(17, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 24);
            this.label4.TabIndex = 46;
            this.label4.Text = "Contatos Selecionados :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 23);
            this.panel2.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "Contatos para Verificar";
            // 
            // btnExportarParaVerificacao
            // 
            this.btnExportarParaVerificacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnExportarParaVerificacao.FlatAppearance.BorderSize = 0;
            this.btnExportarParaVerificacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarParaVerificacao.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarParaVerificacao.ForeColor = System.Drawing.Color.White;
            this.btnExportarParaVerificacao.Location = new System.Drawing.Point(354, 34);
            this.btnExportarParaVerificacao.Name = "btnExportarParaVerificacao";
            this.btnExportarParaVerificacao.Size = new System.Drawing.Size(320, 53);
            this.btnExportarParaVerificacao.TabIndex = 40;
            this.btnExportarParaVerificacao.Text = "Exportar para Verificação";
            this.btnExportarParaVerificacao.UseVisualStyleBackColor = false;
            this.btnExportarParaVerificacao.Click += new System.EventHandler(this.btnExportarParaVerificacao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAbrirEmulador);
            this.groupBox2.Controls.Add(this.cbEmulador);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.btnIniciarVerificacao);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 117);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.label5.Location = new System.Drawing.Point(9, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 71;
            this.label5.Text = "Emuladores";
            // 
            // btnAbrirEmulador
            // 
            this.btnAbrirEmulador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnAbrirEmulador.FlatAppearance.BorderSize = 0;
            this.btnAbrirEmulador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirEmulador.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirEmulador.ForeColor = System.Drawing.Color.White;
            this.btnAbrirEmulador.Location = new System.Drawing.Point(354, 48);
            this.btnAbrirEmulador.Name = "btnAbrirEmulador";
            this.btnAbrirEmulador.Size = new System.Drawing.Size(157, 53);
            this.btnAbrirEmulador.TabIndex = 62;
            this.btnAbrirEmulador.Text = "Abrir Emulador";
            this.btnAbrirEmulador.UseVisualStyleBackColor = false;
            this.btnAbrirEmulador.Click += new System.EventHandler(this.btnAbrirEmulador_Click);
            // 
            // cbEmulador
            // 
            this.cbEmulador.BackColor = System.Drawing.Color.White;
            this.cbEmulador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmulador.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmulador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.cbEmulador.FormattingEnabled = true;
            this.cbEmulador.Location = new System.Drawing.Point(13, 74);
            this.cbEmulador.Name = "cbEmulador";
            this.cbEmulador.Size = new System.Drawing.Size(246, 27);
            this.cbEmulador.TabIndex = 61;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(6, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 23);
            this.panel3.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 45;
            this.label2.Text = "Processo de Verificar";
            // 
            // btnIniciarVerificacao
            // 
            this.btnIniciarVerificacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnIniciarVerificacao.FlatAppearance.BorderSize = 0;
            this.btnIniciarVerificacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarVerificacao.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarVerificacao.ForeColor = System.Drawing.Color.White;
            this.btnIniciarVerificacao.Location = new System.Drawing.Point(517, 48);
            this.btnIniciarVerificacao.Name = "btnIniciarVerificacao";
            this.btnIniciarVerificacao.Size = new System.Drawing.Size(157, 53);
            this.btnIniciarVerificacao.TabIndex = 41;
            this.btnIniciarVerificacao.Text = "Iniciar Verificação";
            this.btnIniciarVerificacao.UseVisualStyleBackColor = false;
            this.btnIniciarVerificacao.Click += new System.EventHandler(this.btnIniciarVerificacao_Click);
            // 
            // btnExportarParaEmail
            // 
            this.btnExportarParaEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(39)))), ((int)(((byte)(100)))));
            this.btnExportarParaEmail.FlatAppearance.BorderSize = 0;
            this.btnExportarParaEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarParaEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarParaEmail.ForeColor = System.Drawing.Color.White;
            this.btnExportarParaEmail.Location = new System.Drawing.Point(354, 187);
            this.btnExportarParaEmail.Name = "btnExportarParaEmail";
            this.btnExportarParaEmail.Size = new System.Drawing.Size(320, 53);
            this.btnExportarParaEmail.TabIndex = 42;
            this.btnExportarParaEmail.Text = "Exportar para Email";
            this.btnExportarParaEmail.UseVisualStyleBackColor = false;
            this.btnExportarParaEmail.Click += new System.EventHandler(this.btnExportarParaEmail_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(6, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(167, 23);
            this.panel4.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 45;
            this.label3.Text = "Infrmações";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.label6.Location = new System.Drawing.Point(17, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 24);
            this.label6.TabIndex = 62;
            this.label6.Text = "Contatos Totais :";
            // 
            // lblContatosTotaisInfo
            // 
            this.lblContatosTotaisInfo.AutoSize = true;
            this.lblContatosTotaisInfo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatosTotaisInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.lblContatosTotaisInfo.Location = new System.Drawing.Point(269, 68);
            this.lblContatosTotaisInfo.Name = "lblContatosTotaisInfo";
            this.lblContatosTotaisInfo.Size = new System.Drawing.Size(21, 24);
            this.lblContatosTotaisInfo.TabIndex = 63;
            this.lblContatosTotaisInfo.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.label9.Location = new System.Drawing.Point(17, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 24);
            this.label9.TabIndex = 64;
            this.label9.Text = "Contatos Sem WhatsApp :";
            // 
            // lblContatosSemWhatsAppInfo
            // 
            this.lblContatosSemWhatsAppInfo.AutoSize = true;
            this.lblContatosSemWhatsAppInfo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatosSemWhatsAppInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.lblContatosSemWhatsAppInfo.Location = new System.Drawing.Point(269, 117);
            this.lblContatosSemWhatsAppInfo.Name = "lblContatosSemWhatsAppInfo";
            this.lblContatosSemWhatsAppInfo.Size = new System.Drawing.Size(21, 24);
            this.lblContatosSemWhatsAppInfo.TabIndex = 65;
            this.lblContatosSemWhatsAppInfo.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.label11.Location = new System.Drawing.Point(17, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 24);
            this.label11.TabIndex = 66;
            this.label11.Text = "Contatos com WhatsApp :";
            // 
            // lblContatosComWhatsInfo
            // 
            this.lblContatosComWhatsInfo.AutoSize = true;
            this.lblContatosComWhatsInfo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatosComWhatsInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.lblContatosComWhatsInfo.Location = new System.Drawing.Point(269, 168);
            this.lblContatosComWhatsInfo.Name = "lblContatosComWhatsInfo";
            this.lblContatosComWhatsInfo.Size = new System.Drawing.Size(21, 24);
            this.lblContatosComWhatsInfo.TabIndex = 67;
            this.lblContatosComWhatsInfo.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbStatus);
            this.groupBox3.Controls.Add(this.lblContatosComWhatsInfo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblContatosSemWhatsAppInfo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblContatosTotaisInfo);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Controls.Add(this.btnExportarParaEmail);
            this.groupBox3.Location = new System.Drawing.Point(12, 322);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 255);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.lblContatosRestantes);
            this.gbStatus.Controls.Add(this.label13);
            this.gbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.gbStatus.Location = new System.Drawing.Point(354, 41);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(320, 100);
            this.gbStatus.TabIndex = 70;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // lblContatosRestantes
            // 
            this.lblContatosRestantes.AutoSize = true;
            this.lblContatosRestantes.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContatosRestantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.lblContatosRestantes.Location = new System.Drawing.Point(218, 47);
            this.lblContatosRestantes.Name = "lblContatosRestantes";
            this.lblContatosRestantes.Size = new System.Drawing.Size(21, 24);
            this.lblContatosRestantes.TabIndex = 71;
            this.lblContatosRestantes.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
            this.label13.Location = new System.Drawing.Point(17, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(195, 24);
            this.label13.TabIndex = 69;
            this.label13.Text = "Contatos Restantes :";
            // 
            // timerProcesso
            // 
            this.timerProcesso.Enabled = true;
            this.timerProcesso.Interval = 1000;
            this.timerProcesso.Tick += new System.EventHandler(this.timerProcesso_Tick);
            // 
            // FrmContatosEmuladores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 598);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmContatosEmuladores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEnvio";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarParaVerificacao;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciarVerificacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblContatosSelecionados;
        private System.Windows.Forms.Button btnAbrirEmulador;
        private System.Windows.Forms.ComboBox cbEmulador;
        private System.Windows.Forms.Button btnExportarParaEmail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblContatosTotaisInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblContatosSemWhatsAppInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblContatosComWhatsInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timerProcesso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblContatosRestantes;
    }
}