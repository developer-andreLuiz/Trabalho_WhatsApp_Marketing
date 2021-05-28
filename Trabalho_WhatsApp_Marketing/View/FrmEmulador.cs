using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp_Marketing.Dao;
using Trabalho_WhatsApp_Marketing.Model;
using Trabalho_WhatsApp_Marketing.Service;

namespace Trabalho_WhatsApp_Marketing.View
{
    public partial class FrmEmulador : Form
    {
        #region Variaveis
        bool novo = false;
        #endregion

        #region Funções
        void ExibirRegistro(Tb_emulador_Model emulador)
        {
            lblId.Text = Convert.ToString(emulador.id);
            txtNomeAparelho.Text = Convert.ToString(emulador.nome);
            txtNumeroWhatsApp.Text = Convert.ToString(emulador.numero_whatsapp);
            txtNumeroWhatsAppBusiness.Text = Convert.ToString(emulador.numero_whatsapp_business);
            cbIdAndroid.DataSource = null;
            List<string> lst = new List<string>();
            lst.Add(emulador.udid);
            cbIdAndroid.DataSource = lst;
            if (emulador.habilitado == 0)
            {
                chkHabilitado.Checked = false;
            }
            else
            {
                chkHabilitado.Checked = true;
            }
        }
        void GravarObj(Tb_emulador_Model tb_Emulador_Model)
        {
            //todo tratamento 01
            tb_Emulador_Model.id = Convert.ToInt32(lblId.Text);
            tb_Emulador_Model.nome = txtNomeAparelho.Text;
            tb_Emulador_Model.numero_whatsapp = txtNumeroWhatsApp.Text;
            tb_Emulador_Model.numero_whatsapp_business = txtNumeroWhatsAppBusiness.Text;
            tb_Emulador_Model.udid = cbIdAndroid.Text;
            if (chkHabilitado.Checked)
            {
                tb_Emulador_Model.habilitado = 1;
            }
            else
            {
                tb_Emulador_Model.habilitado = 0;
            }

        }
        void InterfaceAbrir()
        {
            gbRegistro.Enabled = false;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnGravar.Enabled = false;
            BtnCancelar.Enabled = false;
        }
        void InterfaceNovo()
        {
            gbRegistro.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnGravar.Enabled = true;
            BtnCancelar.Enabled = true;
        }
        void InterfaceAtualizar()
        {
            gbRegistro.Enabled = true;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnGravar.Enabled = true;
            BtnCancelar.Enabled = true;
        }
        void InterfaceGravar()
        {
            gbRegistro.Enabled = false;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnGravar.Enabled = false;
            BtnCancelar.Enabled = false;
        }
        void InterfaceCancelar()
        {
            gbRegistro.Enabled = false;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnGravar.Enabled = false;
            BtnCancelar.Enabled = false;
        }
        void Limpar()
        {
            lblId.Text = "0";
            txtNumeroWhatsApp.Text = string.Empty;
            txtNumeroWhatsAppBusiness.Text = string.Empty;
            txtNomeAparelho.Text = string.Empty;

        }
        void CarregarGrid()
        {
            dataGridView.DataSource = Banco.Tb_emulador.RetornoCompleto();
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 140;
            dataGridView.Columns[2].Width = 140;
            dataGridView.Columns[3].Width = 140;
            dataGridView.Columns[4].Width = 140;
            dataGridView.Columns[5].Width = 50;
            lblTotalRegistro.Text = dataGridView.Rows.Count.ToString();
        }
        #endregion

        #region Eventos
        public FrmEmulador()
        {
            InitializeComponent();
            
        }
        private void FrmEmulador_Load(object sender, EventArgs e)
        {
            InterfaceAbrir();
            CarregarGrid();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            InterfaceNovo();
            Limpar();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            novo = false;
            InterfaceAtualizar();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            //todo tratamento 02
            Tb_emulador_Model emulador = new Tb_emulador_Model();
            GravarObj(emulador);
            if (novo)
            {
                Banco.Tb_emulador.Inserir(emulador);
                Limpar();
            }
            else
            {
                Banco.Tb_emulador.Atualizar(emulador);
            }
            InterfaceGravar();
            CarregarGrid();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            InterfaceCancelar();
            CarregarGrid();
        }
        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            Tb_emulador_Model emulador = new Tb_emulador_Model();
            GravarObj(emulador);
            Banco.Tb_emulador.Deletar(emulador);
            Limpar();
            InterfaceCancelar();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void cbIdAndroid_Click(object sender, EventArgs e)
        {
            try
            {
                AdbClient adbClient = new AdbClient();
                List<DeviceData> listDevices = adbClient.GetDevices();
                List<string> lst = new List<string>();
                foreach (DeviceData devices in listDevices)
                {
                    lst.Add(devices.Serial);
                }
                cbIdAndroid.DataSource = lst;
            }
            catch { }
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Tb_emulador_Model emulador = new Tb_emulador_Model();
            emulador.id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            emulador.nome = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            emulador.numero_whatsapp = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[2].Value);
            emulador.numero_whatsapp_business = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[3].Value);
            emulador.udid = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[4].Value);
            emulador.habilitado = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[5].Value);
            ExibirRegistro(emulador);
        }

        #endregion

       
    }
}
