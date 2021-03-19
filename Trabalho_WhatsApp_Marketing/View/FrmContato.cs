using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp_Marketing.Dao;
using Trabalho_WhatsApp_Marketing.Model;

namespace Trabalho_WhatsApp_Marketing.View
{
    public partial class FrmContato : Form
    {
        #region Variaveis 
        List<Tb_estado_Model> ltEstadoCompleto = new List<Tb_estado_Model>();
        List<Tb_municipio_Model> ltMunicipioCompleto = new List<Tb_municipio_Model>();
        List<Tb_bairro_Model> ltBairroCompleto = new List<Tb_bairro_Model>();
        List<Tb_contato_Model> ltContatosCompleto = new List<Tb_contato_Model>();
        bool novoBool = false;
        #endregion

        #region Funções
        void ExibirRegistro(Tb_contato_Model tb_Contatos_Model)
        {
            if (tb_Contatos_Model.id != 0)
            {
                lblSituacao.Text = "Cadastrado";
                lblId.Text = tb_Contatos_Model.id.ToString();
                txtTelefone.Text = tb_Contatos_Model.telefone.ToString();

                CarregarComboBox(cbEstado);
                cbEstado.SelectedValue = tb_Contatos_Model.uf;

                CarregarComboBox(cbMunicipio, tb_Contatos_Model.uf);
                cbMunicipio.SelectedValue = tb_Contatos_Model.municipio;

                CarregarComboBox(cbBairro, tb_Contatos_Model.uf, tb_Contatos_Model.municipio);
                cbBairro.SelectedValue = tb_Contatos_Model.bairro;
            }
            else
            {
                LimparInterface();
                lblSituacao.Text = "Não Cadastrado";
            }
        }
        void CarregarComboBox(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DisplayMember = "nome";
            cb.ValueMember = "uf";
            List<Tb_estado_Model> ltEstadoCompletoLocal = new List<Tb_estado_Model>();
            foreach (Tb_estado_Model temp in ltEstadoCompleto)
            {
                ltEstadoCompletoLocal.Add(temp);
            }
            cb.DataSource = ltEstadoCompletoLocal;

        }
        void CarregarComboBox(ComboBox cb, string estado)
        {
            List<Tb_municipio_Model> ltMunicipioFiltro = new List<Tb_municipio_Model>();
            foreach (Tb_municipio_Model tb_Municipio_Model in ltMunicipioCompleto)
            {
                if (tb_Municipio_Model.uf.ToUpper().Equals(estado.ToUpper()))
                {
                    ltMunicipioFiltro.Add(tb_Municipio_Model);
                }
            }
            cb.DataSource = null;
            cb.DisplayMember = "nome";
            cb.ValueMember = "codigo";
            cb.DataSource = ltMunicipioFiltro;
        }
        void CarregarComboBox(ComboBox cb, string estado, string codigo)
        {
            List<Tb_bairro_Model> ltBairroFiltro = new List<Tb_bairro_Model>();

            foreach (Tb_bairro_Model tb_Bairro_Model in ltBairroCompleto)
            {
                if (tb_Bairro_Model.uf.ToUpper().Equals(estado.ToUpper()) && tb_Bairro_Model.codigo.Substring(0, 7).Equals(codigo))
                {
                    ltBairroFiltro.Add(tb_Bairro_Model);
                }
            }
            cb.DataSource = null;
            cb.DisplayMember = "nome";
            cb.ValueMember = "codigo";
            cb.DataSource = ltBairroFiltro;
        }
        void CarregarGrid(DataGridView dt, string estado)
        {
            dataGridView.DataSource = null;
            List<Tb_contato_Model> ltTb_Contatos_ModelFiltro = new List<Tb_contato_Model>();
            foreach (Tb_contato_Model tb_Contatos_Model in ltContatosCompleto)
            {
                if (tb_Contatos_Model.uf.ToUpper().Equals(estado.ToUpper()))
                {
                    ltTb_Contatos_ModelFiltro.Add(tb_Contatos_Model);
                }
            }
            if (ltTb_Contatos_ModelFiltro.Count > 0)
            {
                dataGridView.DataSource = ltTb_Contatos_ModelFiltro;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 235;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;


            }
            else
            {
                dataGridView.DataSource = new List<Tb_contato_Model>();
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 235;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
            }


        }
        void CarregarGrid(DataGridView dt, string estado, string municipio)
        {
            dataGridView.DataSource = null;
            List<Tb_contato_Model> ltTb_Contatos_ModelFiltro = new List<Tb_contato_Model>();
            foreach (Tb_contato_Model tb_Contatos_Model in ltContatosCompleto)
            {
                if (tb_Contatos_Model.uf.ToUpper().Equals(estado.ToUpper()) && tb_Contatos_Model.municipio.Equals(municipio))
                {
                    ltTb_Contatos_ModelFiltro.Add(tb_Contatos_Model);
                }
            }
            if (ltTb_Contatos_ModelFiltro.Count > 0)
            {
                dataGridView.DataSource = ltTb_Contatos_ModelFiltro;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 235;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;


            }
            else
            {
                dataGridView.DataSource = new List<Tb_contato_Model>();
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 235;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
            }

        }
        void CarregarGrid(DataGridView dt, string estado, string municipio, string bairro)
        {
            dataGridView.DataSource = null;
            List<Tb_contato_Model> ltTb_Contatos_ModelFiltro = new List<Tb_contato_Model>();
            foreach (Tb_contato_Model tb_Contatos_Model in ltContatosCompleto)
            {
                if (tb_Contatos_Model.uf.ToUpper().Equals(estado.ToUpper()) && tb_Contatos_Model.municipio.Equals(municipio) && tb_Contatos_Model.bairro.Equals(bairro))
                {
                    ltTb_Contatos_ModelFiltro.Add(tb_Contatos_Model);
                }
            }
            if (ltTb_Contatos_ModelFiltro.Count > 0)
            {
                dataGridView.DataSource = ltTb_Contatos_ModelFiltro;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 235;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;


            }
            else
            {
                dataGridView.DataSource = new List<Tb_contato_Model>();
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 235;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
            }

        }
        void Novo()
        {
            novoBool = true;
            LimparInterface();
            CarregarComboBox(cbEstado);

            txtTelefone.Enabled = true;
            cbEstado.Enabled = true;
            cbMunicipio.Enabled = true;
            cbBairro.Enabled = true;

            btnGravar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        void Atualizar()
        {
            novoBool = false;

            txtTelefone.Enabled = true;
            cbEstado.Enabled = true;
            cbMunicipio.Enabled = true;
            cbBairro.Enabled = true;

            btnGravar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        void Gravar()
        {
            if (novoBool)
            {
                Tb_contato_Model contatos = new Tb_contato_Model();
                string vUf = string.Empty;
                string vMunicipio = string.Empty;
                string vBairro = string.Empty;

                try { vUf = cbEstado.SelectedValue.ToString(); } catch { }
                try { vMunicipio = cbMunicipio.SelectedValue.ToString(); } catch { }
                try { vBairro = cbBairro.SelectedValue.ToString(); } catch { }

                contatos.telefone = txtTelefone.Text;

                contatos.uf = vUf;
                contatos.municipio = vMunicipio;
                contatos.bairro = vBairro;

                if (string.IsNullOrEmpty(txtTelefone.Text) == false)
                {

                    if (Convert.ToString(Banco.Tb_contato.Retorno(contatos.telefone).id).Equals("0"))
                    {
                        Banco.Tb_contato.Inserir(contatos);

                        ltContatosCompleto = Banco.Tb_contato.RetornoCompleto();

                        InicioInterface();

                        LimparInterface();
                    }
                }
            }
            else
            {
                Tb_contato_Model contatos = new Tb_contato_Model();
                string vUf = string.Empty;
                string vMunicipio = string.Empty;
                string vBairro = string.Empty;

                try { vUf = cbEstado.SelectedValue.ToString(); } catch { }
                try { vMunicipio = cbMunicipio.SelectedValue.ToString(); } catch { }
                try { vBairro = cbBairro.SelectedValue.ToString(); } catch { }

                contatos.telefone = txtTelefone.Text;
                contatos.id = Convert.ToInt32(lblId.Text);
                contatos.uf = vUf;
                contatos.municipio = vMunicipio;
                contatos.bairro = vBairro;

                if (string.IsNullOrEmpty(txtTelefone.Text) == false)
                {

                    if (Convert.ToString(Banco.Tb_contato.Retorno(Convert.ToInt32(lblId.Text)).id).Equals("0") == false)
                    {
                        Banco.Tb_contato.Atualizar(contatos);

                        ltContatosCompleto = Banco.Tb_contato.RetornoCompleto();

                        InicioInterface();

                        LimparInterface();
                    }
                }
            }
        }
        void Importar()
        {

            Tb_contato_Model tb = new Tb_contato_Model();

            tb.uf = Convert.ToString(cbEstado.SelectedValue);
            tb.municipio = Convert.ToString(cbMunicipio.SelectedValue);
            tb.bairro = Convert.ToString(cbBairro.SelectedValue);

            List<string> ltContatosLocal = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                openFileDialog.Dispose();
                string[] conteudo = File.ReadAllLines(path);
                foreach (string numero in conteudo)
                {
                    if (numero.Length == 11)
                    {
                        ltContatosLocal.Add(numero);

                    }
                }
            }
            
            if (ltContatosLocal.Count > 0)
            {
                foreach (string c in ltContatosLocal)
                {
                    if (Banco.Tb_contato.Retorno(c).id == 0)
                    {
                        tb.telefone = c;
                        Banco.Tb_contato.Inserir(tb);
                    }
                }
                InicioInterface();
                LimparInterface();
                ltContatosCompleto = Banco.Tb_contato.RetornoCompleto();
            }


        }
        void Deletar()
        {
            if (Convert.ToString(lblId.Text).Equals("0") == false)
            {
                if (MessageBox.Show("Deseja Excluir este Regitro ?", "Deletar Número", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Banco.Tb_contato.Deletar(Banco.Tb_contato.Retorno(Convert.ToInt32(lblId.Text)));
                    InicioInterface();
                    LimparInterface();
                    ltContatosCompleto = Banco.Tb_contato.RetornoCompleto();
                }
            }


        }
        void InicioInterface()
        {
            txtTelefone.Enabled = false;
            cbEstado.Enabled = false;
            cbMunicipio.Enabled = false;
            cbBairro.Enabled = false;
            btnGravar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        void LimparInterface()
        {
            lblSituacao.Text = "xxxxxxxxxxx";
            lblId.Text = "0";
            txtTelefone.Text = string.Empty;
            cbEstado.DataSource = null;
            cbMunicipio.DataSource = null;
            cbBairro.DataSource = null;
        }
        #endregion

        #region Eventos
        public FrmContato()
        {
            InitializeComponent();
        }
        private void FrmContato_Load(object sender, EventArgs e)
        {
            ltEstadoCompleto = Banco.Tb_estado.RetornoCompleto();
            ltMunicipioCompleto = Banco.Tb_municipio.RetornoCompleto();
            ltBairroCompleto = Banco.Tb_bairro.RetornoCompleto();
            ltContatosCompleto = Banco.Tb_contato.RetornoCompleto();

            CarregarComboBox(cbEstadoFiltro);
            InicioInterface();
        }
        private void cbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstadoFiltro.Text) == false)
            {
                CarregarGrid(dataGridView, Convert.ToString(cbEstadoFiltro.SelectedValue));
                CarregarComboBox(cbMunicipioFiltro, Convert.ToString(cbEstadoFiltro.SelectedValue));
            }
        }
        private void cbMunicipioFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMunicipioFiltro.Text) == false)
            {
                CarregarGrid(dataGridView, Convert.ToString(cbEstadoFiltro.SelectedValue), Convert.ToString(cbMunicipioFiltro.SelectedValue));
                CarregarComboBox(cbBairroFiltro, Convert.ToString(cbEstadoFiltro.SelectedValue), Convert.ToString(cbMunicipioFiltro.SelectedValue));
            }
        }
        private void cbBairroFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBairroFiltro.Text) == false)
            {
                CarregarGrid(dataGridView, Convert.ToString(cbEstadoFiltro.SelectedValue), Convert.ToString(cbMunicipioFiltro.SelectedValue), Convert.ToString(cbBairroFiltro.SelectedValue));
            }
        }
        private void btnBuscarEstado_Click(object sender, EventArgs e)
        {
            CarregarGrid(dataGridView, Convert.ToString(cbEstadoFiltro.SelectedValue));
        }
        private void btnBuscarMunicipio_Click(object sender, EventArgs e)
        {
            CarregarGrid(dataGridView, Convert.ToString(cbEstadoFiltro.SelectedValue), Convert.ToString(cbMunicipioFiltro.SelectedValue));
        }
        private void btnBuscarBairro_Click(object sender, EventArgs e)
        {
            CarregarGrid(dataGridView, Convert.ToString(cbEstadoFiltro.SelectedValue), Convert.ToString(cbMunicipioFiltro.SelectedValue), Convert.ToString(cbBairroFiltro.SelectedValue));
        }
        private void dataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            lblTotalLinha.Text = $"Total de Linhas: {dataGridView.Rows.Count}";
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefoneFiltro.Text) == false)
            {
                Tb_contato_Model tb_Contatos_Model = Banco.Tb_contato.Retorno(txtTelefoneFiltro.Text.Trim());
                ExibirRegistro(tb_Contatos_Model);
            }
        }














        #endregion

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Gravar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InicioInterface();
            LimparInterface();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                Importar();
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
            
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Deletar();
        }

        private void btnZerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Apagar Todos os Registro de Contatos?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Banco.Tb_contato.Truncate();
                ltContatosCompleto = Banco.Tb_contato.RetornoCompleto();
            }
        }
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstado.Text) == false)
            {
                CarregarComboBox(cbMunicipio, Convert.ToString(cbEstado.SelectedValue));
            }
        }
        private void cbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMunicipio.Text) == false)
            {
                CarregarComboBox(cbBairro, Convert.ToString(cbEstado.SelectedValue), Convert.ToString(cbMunicipio.SelectedValue));
            }
        }
    }
}
