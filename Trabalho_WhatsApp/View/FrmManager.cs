using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp.Service;

namespace Trabalho_WhatsApp.View
{
    public partial class FrmManager : Form
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
            panelCentral.Controls.Add(ChildForm);
            panelCentral.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        void InterfaceBtn(object button)
        {
            Button btn = (Button)button;
            Color neutro = Color.FromArgb(30, 32, 44);
            Color selecionado = Color.FromArgb(25, 123, 179);
           
            btnInicio.BackColor = neutro;
            btnEnvio.BackColor = neutro;
            btnResposta.BackColor = neutro;
            btnSorteio.BackColor = neutro;
            btnBancoDeDados.BackColor = neutro;
            btnExportarContatos.BackColor = neutro;
            btnAjuda.BackColor = neutro;

            btn.BackColor = selecionado;

        }
        void EncerrarThread()
        {
            foreach (var item in Global.Lista_threads)
            {
                if (item.Name.Equals("Verificacao"))
                {
                    try
                    {
                        item.Abort();
                    }
                    catch { }
                    Global.Lista_threads.Remove(item);
                  
                    break;
                }
            }
        }
        #endregion

        #region Eventos
        public FrmManager()
        {
            InitializeComponent();
            openChildForm(new FrmInicio());
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtTelefone.Text.Trim().Length==11)
            {
                InterfaceBtn(sender);
                string telefone = txtTelefone.Text;
                txtTelefone.Text = string.Empty;
                openChildForm(new FrmContato(telefone));
            }
            else
            {
                if (txtTelefone.Text.Trim().Length == 0)
                {
                    DialogResult dialog = MessageBox.Show("Deseja Ir Para Tela de Contatos?", "Nenhum Número Digitado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog==DialogResult.Yes)
                    {
                        openChildForm(new FrmContato());
                    }
                }
                else
                {
                    MessageBox.Show("Número digitado Incorreto!", "Formato Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefone.Focus();
                }
               
            }
            
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmInicio());
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmEnvio());
        }
        private void btnResposta_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmResposta());
        }
        private void btnSorteio_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmSorteio());
        }
        private void btnBancoDeDados_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmBancoDeDados());
        }
        private void btnExportarContatos_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmExportarContatos());
        }
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            InterfaceBtn(sender);
            openChildForm(new FrmAjuda());
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region Movimentação do Form
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    move = true;
                    Application.DoEvents();
                }
            }
            catch { }
        }
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void panelLogo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    move = true;
                    Application.DoEvents();
                }
            }
            catch { }
        }
        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void panelLateral_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    move = true;
                    Application.DoEvents();
                }
            }
            catch { }
        }

        private void FrmManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            EncerrarThread();
        }

       

        private void panelLateral_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        #endregion
        
        #endregion


    }
}
