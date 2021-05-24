using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp_Marketing.Model;
using Trabalho_WhatsApp_Marketing.Dao;
using System.Diagnostics;
using System.IO;
using Trabalho_WhatsApp_Marketing.Service;
using System.Threading;
using System.Drawing.Imaging;

namespace Trabalho_WhatsApp_Marketing.View
{
    public partial class FrmEnvio : Form
    {
        #region Variaveis
        string pathImagem = @"C:\Users\Public\Pictures"; //camilho da pasta de imgs
        Thread thread;
        bool Finalizado = false;

        #endregion
        #region Funções
        void ExibirInformacoes()
        {
            lblEnvioPorWhatsApp.Text = "50";
            lblLimiteCompartilhamento.Text = "5";
            lblEmuladoresHabilitados.Text = Banco.Tb_emulador.RetornoCompletoHabilitado().Count.ToString();
            lblTotalWhatsApp.Text = (int.Parse(lblEmuladoresHabilitados.Text) * 2).ToString();
            lblTotalContatosEmail.Text = Banco.Tb_contato_email.RetornoCompleto().Count.ToString();
            lblMaximoEnvio.Text = (int.Parse(lblTotalWhatsApp.Text) * 50).ToString();
            lblTotalImagens.Text = TotalImagens().ToString();
        }
        void ExibirStatus()
        {
            lblEmuladorAtual.Text = string.Empty;
            lblMensagensEnviadas.Text = Banco.Tb_contato_email.RetornoCompletoEnviado().Count.ToString();
            lblContatosNaoEncontrados.Text = Banco.Tb_contato_email.RetornoCompletoDesabilitado().Count.ToString();
            lblMensagensRestantes.Text = Banco.Tb_contato_email.RetornoCompletoParaEnvio().Count.ToString();
        }
        int TotalImagens()
        {
            int total = 0;
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(pathImagem);
                FileInfo[] Arquivos = diretorio.GetFiles("*.*");
                total = Arquivos.Length-1;
            }
            catch { } 
            return total;
        }
        void Processo()
        {
            Finalizado = false;
            var listaContatos = Banco.Tb_contato_email.RetornoCompletoParaEnvio();
            if (listaContatos.Count > 0)
            {
                bool Continuar = true;
                string mensagemFinal = "Processo Finalizado";
                int Enviado = 0;
                int Limite = 50;
                //----------------------------------------------------//

                //Inicio WhatsApp
                if (Continuar)
                {
                    WhatsApp.OpenApp();
                    WhatsApp.ResolverBackupTermos();
                    WhatsApp.ApagarConversas();
                    WhatsApp.ClicarContatos();
                    WhatsApp.ClicarLupaProcurarContatos();

                    //Descobrir Primeiro Numero Com WhatsApp
                    while (true)
                    {
                        WhatsApp.DigitarBarraPesquisarContatos(listaContatos[0].telefone);
                        if (WhatsApp.ContatoEncontrado() == false)
                        {
                            WhatsApp.LimparBarraPesquisarContatos();
                            Banco.Tb_contato.Deletar(listaContatos[0].telefone);
                            Banco.Tb_contato_email.Desabilitar(listaContatos[0]);
                            listaContatos.RemoveAt(0);
                            if (listaContatos.Count == 0)
                            {
                                Continuar = false;
                                mensagemFinal = "Terminou os Contatos";
                                Finalizado = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                //Primeiro Envio WhatsApp
                if (Continuar)
                {
                    WhatsApp.ClicarEmContatoEncontrato();
                    WhatsApp.EnvioDentroDaConversa();
                    Enviado++;
                    Banco.Tb_contato_email.SetWhatsApp(listaContatos[0]);
                    listaContatos.RemoveAt(0);
                    if (listaContatos.Count == 0)
                    {
                        Continuar = false;
                        mensagemFinal = "Terminou os Contatos";
                        Finalizado = true;
                    }
                }

                //Compartilhamento WhatsApp
                if (Continuar)
                {
                    WhatsApp.CompartilharDentroDaConversa();
                    int compartilhar = 0;

                    while (true)
                    {
                        WhatsApp.DigitarBarraPesquisarContatos(listaContatos[0].telefone);

                        if (WhatsApp.ContatoEncontrado() == false)
                        {
                            WhatsApp.LimparBarraPesquisarContatos();
                            Banco.Tb_contato.Deletar(listaContatos[0].telefone);
                            Banco.Tb_contato_email.Desabilitar(listaContatos[0]);
                            listaContatos.RemoveAt(0);
                        }
                        else
                        {
                            WhatsApp.ClicarEmContatoEncontrato();
                            WhatsApp.LimparBarraPesquisarContatos();
                            compartilhar++;
                            Enviado++;
                            Banco.Tb_contato_email.SetWhatsApp(listaContatos[0]);
                            listaContatos.RemoveAt(0);
                        }

                        if (listaContatos.Count == 0)
                        {
                            Continuar = false;
                            mensagemFinal = "Terminou os Contatos";
                            Finalizado = true;
                            if (compartilhar > 0)
                            {
                                WhatsApp.ClicarEnviar();
                            }
                            WhatsApp.Close();
                            break;
                        }
                        else
                        {
                            if (Enviado == Limite)
                            {
                                if (compartilhar > 0)
                                {
                                    WhatsApp.ClicarEnviar();
                                }
                                WhatsApp.Close();
                                break;
                            }
                            else
                            {
                                if (compartilhar == 5)
                                {
                                    WhatsApp.ClicarEnviar();
                                    compartilhar = 0;
                                    WhatsApp.CompartilharDentroDaMidia();
                                }
                            }
                        }
                    }
                    if (listaContatos.Count == 0)
                    {
                        Continuar = false;
                        mensagemFinal = "Terminou os Contatos";
                        Finalizado = true;
                    }
                }

                //----------------------------------------------------//

                //Inicio Bussiness
                if (Continuar)
                {
                    Enviado = 0;
                    WhatsAppBusiness.OpenApp();
                    WhatsAppBusiness.ResolverBackupTermos();
                    WhatsAppBusiness.ApagarConversas();
                    WhatsAppBusiness.ClicarContatos();
                    WhatsAppBusiness.ClicarLupaProcurarContatos();

                    //Descobrir Primeiro Numero Com WhatsApp
                    while (true)
                    {
                        WhatsAppBusiness.DigitarBarraPesquisarContatos(listaContatos[0].telefone);
                        if (WhatsAppBusiness.ContatoEncontrado() == false)
                        {
                            WhatsAppBusiness.LimparBarraPesquisarContatos();
                            Banco.Tb_contato.Deletar(listaContatos[0].telefone);
                            Banco.Tb_contato_email.Desabilitar(listaContatos[0]);
                            listaContatos.RemoveAt(0);
                            if (listaContatos.Count == 0)
                            {
                                Continuar = false;
                                mensagemFinal = "Terminou os Contatos";
                                Finalizado = true;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                //Primeiro Envio Bussiness
                if (Continuar)
                {
                    WhatsAppBusiness.ClicarEmContatoEncontrato();
                    WhatsAppBusiness.EnvioDentroDaConversa();
                    Enviado++;
                    Banco.Tb_contato_email.SetWhatsApp(listaContatos[0]);
                    listaContatos.RemoveAt(0);
                    if (listaContatos.Count == 0)
                    {
                        Continuar = false;
                        mensagemFinal = "Terminou os Contatos";
                        Finalizado = true;
                    }
                }

                //Compartilhamento Bussiness
                if (Continuar)
                {
                    WhatsAppBusiness.CompartilharDentroDaConversa();
                    int compartilhar = 0;
                    while (true)
                    {
                        WhatsAppBusiness.DigitarBarraPesquisarContatos(listaContatos[0].telefone);

                        if (WhatsAppBusiness.ContatoEncontrado() == false)
                        {
                            WhatsAppBusiness.LimparBarraPesquisarContatos();
                            Banco.Tb_contato.Deletar(listaContatos[0].telefone);
                            Banco.Tb_contato_email.Desabilitar(listaContatos[0]);
                            listaContatos.RemoveAt(0);
                        }
                        else
                        {
                            WhatsAppBusiness.ClicarEmContatoEncontrato();
                            WhatsAppBusiness.LimparBarraPesquisarContatos();
                            compartilhar++;
                            Enviado++;
                            Banco.Tb_contato_email.SetWhatsApp(listaContatos[0]);
                            listaContatos.RemoveAt(0);
                        }

                        if (listaContatos.Count == 0)
                        {
                            Continuar = false;
                            mensagemFinal = "Terminou os Contatos";
                            Finalizado = true;
                            if (compartilhar > 0)
                            {
                                WhatsAppBusiness.ClicarEnviar();
                            }
                            WhatsAppBusiness.Close();
                            break;
                        }
                        else
                        {
                            if (Enviado == Limite)
                            {
                                if (compartilhar > 0)
                                {
                                    WhatsAppBusiness.ClicarEnviar();
                                }
                                WhatsAppBusiness.Close();
                                break;
                            }
                            else
                            {
                                if (compartilhar == 5)
                                {
                                    WhatsAppBusiness.ClicarEnviar();
                                    compartilhar = 0;
                                    WhatsAppBusiness.CompartilharDentroDaMidia();
                                }
                            }
                        }
                    }
                    if (listaContatos.Count == 0)
                    {
                        Continuar = false;
                        mensagemFinal = "Terminou os Contatos";
                    }
                }

                //----------------------------------------------------//

                ProgramService.CloseEmulador();
            }
            else
            {
                if (MessageBox.Show("Deseja Iniciar um Novo Envio ? Todo o histório de envios será deletado.", "Novo Envio", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Banco.Tb_contato_email.Resetar();

                }
            }
        }
        #endregion
        #region Eventos
        public FrmEnvio()
        {
            InitializeComponent();
            ExibirInformacoes();
            ExibirStatus();
        }
        private void btnAbrirPasta_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Explorer", pathImagem);
            }
            catch
            {
                MessageBox.Show("Erro: Caminho da pasta não Encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNovoEnvio_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Iniciar um Novo Envio ? Todo o histório de envios será deletado.", "Novo Envio", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Banco.Tb_contato_email.Resetar();
                ExibirInformacoes();
                ExibirStatus();
            }

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ExibirInformacoes();
            ExibirStatus();
            try
            {
                thread.Abort();
            }
            catch { }
            try
            {
                thread = new Thread(Processo);
                thread.Start();
            }
            catch { }
        }
        private void btnInterromperEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                thread.Abort();
            }
            catch { }
            Finalizado = true;
            MessageBox.Show("Envio Interrompido","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Finalizado)
            {
                ExibirInformacoes();
                ExibirStatus();
                Finalizado = false;
            }
        }
    }
}
