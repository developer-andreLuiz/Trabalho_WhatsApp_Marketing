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

namespace Trabalho_WhatsApp_Marketing.View
{
    public partial class FrmEnvio : Form
    {
        //1000 envios em  2h 20 minutos
        #region Variaveis
        string pathImagem = @"C:\Users\Public\Pictures"; //camilho da pasta de imgs
        List<string> ListaTeste = new List<string>();//lista provosória para teste
        #endregion
        #region Funções
        void ExibirInformacoes()
        {
            //limite de envios por zap
            //limite de compartilhamento
            //Emuladores Habilitados
            //Total de WhatsApp
            //Total de Contatos Email
            //Maximo Envio

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
            //Emulador Atual
            //Mensagens Enviadas
            //Contatos nao Encontratos
            //Mensagens Restantes

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
        #endregion
        #region Eventos
        public FrmEnvio()
        {
            InitializeComponent();
            ListaTeste.Add("21984757079");
            ListaTeste.Add("21970122979");
            ListaTeste.Add("21993907972");
            ListaTeste.Add("21984989288");
            ListaTeste.Add("21985423027");
            ListaTeste.Add("21985844377");
            ListaTeste.Add("21987788440");
            ListaTeste.Add("21988164726");
            ListaTeste.Add("21988369042");
            ListaTeste.Add("21988406076");
            ListaTeste.Add("21989143626");
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
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var listaContatos = Banco.Tb_contato_email.RetornoCompletoParaEnvio();
            bool Continuar = true;
            string messagemFinal = string.Empty;
            int Enviado = 0;
            int Limite = 50;
           
            if (listaContatos.Count > 0)
            {
                WhatsApp.OpenApp();
                WhatsApp.ResolverBackupTermos();
                WhatsApp.ClicarContatos();
                WhatsApp.ClicarLupaProcurarContatos();
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
                            messagemFinal = "Terminou os Contatos";
                            break;
                        }
                    }
                }
                //Primeiro Envio
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
                        messagemFinal = "Terminou os Contatos";
                    }
                }
                //Compartilhamento
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
                            messagemFinal = "Terminou os Contatos";
                            if (compartilhar > 0)
                            {
                                WhatsApp.ClicarEnviar();
                            }
                            WhatsApp.Close();
                            break;
                        }
                        else
                        {
                            if (Enviado==Limite)
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
                                if (compartilhar==5)
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
                        messagemFinal = "Terminou os Contatos";
                    }
                }
                
                //Bussiness
                if (Continuar)
                {
                    Enviado = 0;
                    WhatsAppBusiness.OpenApp();
                    WhatsAppBusiness.ResolverBackupTermos();
                    WhatsAppBusiness.ClicarContatos();
                    WhatsAppBusiness.ClicarLupaProcurarContatos();
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
                                messagemFinal = "Terminou os Contatos";
                                break;
                            }
                        }
                    }
                    //Primeiro Envio
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
                            messagemFinal = "Terminou os Contatos";
                        }
                    }
                    //Compartilhamento
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
                                messagemFinal = "Terminou os Contatos";
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
                            messagemFinal = "Terminou os Contatos";
                        }
                    }
                }


                if (Continuar == false)
                {
                    ProgramService.CloseEmulador();
                    MessageBox.Show(messagemFinal);
                    //
                }
            }
            ExibirInformacoes();
            ExibirStatus();
        }
        #endregion
    }
}
