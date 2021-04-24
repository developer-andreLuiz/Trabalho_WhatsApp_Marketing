using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp_Marketing.Service;
using Trabalho_WhatsApp_Marketing.Model;
using Trabalho_WhatsApp_Marketing.Dao;

namespace Trabalho_WhatsApp_Marketing.View
{
    public partial class FrmContatosEmuladores : Form
    {
        #region Variaveis
        List<Tb_emulador_Model> ListaEmulador = new List<Tb_emulador_Model>();
        List<string> ListaContatosEmail = new List<string>();
        int ContatosTotais = 0;
        int ContatosSemWhatsApp = 0;
        bool Processo = false;




        #endregion
        #region Funcoes
        void CarregarComboxBoxEmuladores()
        {
            List<Tb_emulador_Model> ListaEmulador = Banco.Tb_emulador.RetornoCompletoHabilitado();
            cbEmulador.DataSource = null;
            if (ListaEmulador.Count > 0)
            {
                cbEmulador.DisplayMember = "nome";
                cbEmulador.ValueMember = "id";
                cbEmulador.DataSource = ListaEmulador;
            }
        }
        void ExibirInformacoes()
        {
            lblContatosTotaisInfo.Text = ContatosTotais.ToString();
            lblContatosSelecionados.Text = Global.ListContactsExcel.Count.ToString();
            lblContatosSemWhatsAppInfo.Text = ContatosSemWhatsApp.ToString();
            lblContatosComWhatsInfo.Text = ListaContatosEmail.Count.ToString();
            lblContatosRestantes.Text = Global.ListContactsExcel.Count.ToString();

        }
        void Evento()
        {
            if (Global.ListContactsExcel.Count>0)
            {
                WhatsApp.DigitarBarraPesquisarContatos(Global.ListContactsExcel[0]);
                if (WhatsApp.ContatoEncontrado() == true)
                {
                    Banco.Tb_contato.Deletar(Banco.Tb_contato.Retorno(Global.ListContactsExcel[0]));
                    ContatosSemWhatsApp++;
                }
                else
                {
                    int index = ListaContatosEmail.FindIndex(x => x.Equals(Global.ListContactsExcel[0]));
                    if (index ==-1)
                    {
                        ListaContatosEmail.Add(Global.ListContactsExcel[0]);
                    }
                }
                Global.ListContactsExcel.RemoveAt(0);
                WhatsApp.LimparBarraPesquisarContatos();
            }
            else
            {
                //processo finalizado
                
                btnIniciarVerificacao.BackColor = Color.FromArgb(100, 39, 100);
                btnIniciarVerificacao.Text = "Iniciar Verificação";
                WhatsApp.Close();
                Processo = false;
                MessageBox.Show("Verificação Finalizada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Eventos
        public FrmContatosEmuladores()
        {
            InitializeComponent();
            ListaEmulador = Banco.Tb_emulador.RetornoCompletoHabilitado();
            CarregarComboxBoxEmuladores();
            ContatosTotais = Global.ListContactsExcel.Count;
            lblContatosSelecionados.Text = ContatosTotais.ToString();

        }
        private void btnExportarParaVerificacao_Click(object sender, EventArgs e)
        {
            if (ExcelService.CreateVerification()==false)
            {
                MessageBox.Show("Erro ao Criar Tabela para Verificar Contatos","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Tabela de Verificação Criada com Sucesso", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAbrirEmulador_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEmulador.Text)==false)
            {
                ProgramService.OpenEmulador(cbEmulador.Text);
            }
            else
            {
                MessageBox.Show("Erro: Nenhum Emulador Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnIniciarVerificacao_Click(object sender, EventArgs e)
        {
            if (Processo==false)
            {
                if (ListaEmulador.Count > 0)
                {
                    if (Global.ListContactsExcel.Count>0)
                    {
                        btnIniciarVerificacao.BackColor = Color.FromArgb(52, 25, 51);
                        btnIniciarVerificacao.Text = "Parar Verificação";
                        ExibirInformacoes();
                        WhatsApp.OpenApp(ListaEmulador[ListaEmulador.FindIndex(x => x.nome.Equals(cbEmulador.Text))].udid);
                        WhatsApp.ClicarContatos();
                        WhatsApp.ClicarLupaProcurarContatos();

                        Processo = true;
                    }
                    else
                    {
                        MessageBox.Show("Erro: Nenhum Contato Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erro: Nenhum Emulador Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Processo = false;
                MessageBox.Show("Verificação Pausada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIniciarVerificacao.BackColor = Color.FromArgb(100, 39, 100);
                btnIniciarVerificacao.Text = "Iniciar Verificação";
            }
         
        }
        private void btnExportarParaEmail_Click(object sender, EventArgs e)
        {
            if (Processo)
            {
                Processo = false;
                MessageBox.Show("Verificação Pausada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIniciarVerificacao.BackColor = Color.FromArgb(100, 39, 100);
                btnIniciarVerificacao.Text = "Iniciar Verificação";
            }
            if (ListaContatosEmail.Count>0 || Global.ListContactsExcel.Count > 0)
            {
                Banco.Tb_contato_email.Truncate();

                if (ListaContatosEmail.Count > 0)
                {
                    ExcelService.CreateEmail(ListaContatosEmail);
                    foreach (string item in ListaContatosEmail)
                    {
                        Banco.Tb_contato_email.Inserir(new Tb_contato_email_Model(item,1));
                    }
                }
                else
                {
                    if (Global.ListContactsExcel.Count > 0)
                    {
                        ExcelService.CreateEmail(Global.ListContactsExcel);
                        foreach (string item in Global.ListContactsExcel)
                        {
                            Banco.Tb_contato_email.Inserir(new Tb_contato_email_Model(item,1));
                        }
                    }
                }
                MessageBox.Show("Exportado com Sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro: Nenhum Contato Selecionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           



           
        }
        private void timerProcesso_Tick(object sender, EventArgs e)
        {
            if (Processo)
            {
                
                Evento();
                ExibirInformacoes();
            }
        }





        #endregion

       
    }
}
