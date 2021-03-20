﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_WhatsApp_Marketing.View
{
    public partial class FrmMain : Form
    {
        #region Variaveis
        int x, y;
        Point Point = new Point();
        bool move = false;
        private Form activeForm = null;
        #endregion
        #region Funções
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(ChildForm);
            panelForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        #endregion
        #region Eventos
        public FrmMain()
        {
            InitializeComponent();
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            pInterface.Visible = true;
            pInterface.Location = new Point(160, btnEnvio.Location.Y);
            openChildForm(new FrmEnvio());
        }
        private void btnBancoDedados_Click(object sender, EventArgs e)
        {
            pInterface.Visible = true;
            pInterface.Location = new Point(160, btnBancoDedados.Location.Y);
            openChildForm(new FrmBancoDeDados());
        }
        private void btnContatosEmuladores_Click(object sender, EventArgs e)
        {
            pInterface.Visible = true;
            pInterface.Location = new Point(160, btnContatosEmuladores.Location.Y);
            openChildForm(new FrmContatosEmuladores());
        }
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            pInterface.Visible = true;
            pInterface.Location = new Point(160, btnAjuda.Location.Y);
            openChildForm(new FrmAjuda());
        }
        private void btnFeedback_Click(object sender, EventArgs e)
        {
            pInterface.Visible = true;
            pInterface.Location = new Point(160, btnFeedback.Location.Y);
            openChildForm(new FrmFeedBack());
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


    }
}