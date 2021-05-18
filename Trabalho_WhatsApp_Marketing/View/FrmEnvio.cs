﻿using System;
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
            ExibirInformacoes();
            ExibirStatus();
            InternetService.Habilitar();
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
            string messagemFinal = "Processo Finalizado";
            int Enviado = 0;
            int Limite = 50;
            if (listaContatos.Count > 0)
            {
                WhatsApp.OpenApp();
                WhatsApp.ResolverBackupTermos();
                Thread.Sleep(TimeSpan.FromSeconds(10));
                InternetService.Desabilitar();
                WhatsApp.ApagarConversas();
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
                    else
                    {
                        break;
                    }
                }
              
                //Primeiro Envio
                if (Continuar)
                {
                    WhatsApp.ClicarEmContatoEncontrato();
                    WhatsApp.EnvioDentroDaConversa();
                    Enviado++;
                    InternetService.Habilitar();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    InternetService.Desabilitar();
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
                                InternetService.Habilitar();
                                Thread.Sleep(TimeSpan.FromSeconds(3));
                                InternetService.Desabilitar();
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
                                    InternetService.Habilitar();
                                    Thread.Sleep(TimeSpan.FromSeconds(3));
                                    InternetService.Desabilitar();
                                }
                                WhatsApp.Close();
                                break;
                            }
                            else
                            {
                                if (compartilhar==5)
                                {
                                    WhatsApp.ClicarEnviar();
                                    InternetService.Habilitar();
                                    Thread.Sleep(TimeSpan.FromSeconds(3));
                                    InternetService.Desabilitar();
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

                    InternetService.Habilitar();
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    InternetService.Desabilitar();
                    
                    WhatsAppBusiness.ApagarConversas();
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
                        else
                        {
                            break;
                        }
                    }
                    //Primeiro Envio
                    if (Continuar)
                    {
                        WhatsAppBusiness.ClicarEmContatoEncontrato();
                        WhatsAppBusiness.EnvioDentroDaConversa();
                        Enviado++;
                        InternetService.Habilitar();
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        InternetService.Desabilitar();
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
                                    InternetService.Habilitar();
                                    Thread.Sleep(TimeSpan.FromSeconds(3));
                                    InternetService.Desabilitar();
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
                                        InternetService.Habilitar();
                                        Thread.Sleep(TimeSpan.FromSeconds(3));
                                        InternetService.Desabilitar();
                                    }
                                    WhatsAppBusiness.Close();
                                    break;
                                }
                                else
                                {
                                    if (compartilhar == 5)
                                    {
                                        WhatsAppBusiness.ClicarEnviar();
                                        InternetService.Habilitar();
                                        Thread.Sleep(TimeSpan.FromSeconds(3));
                                        InternetService.Desabilitar();
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

                ProgramService.CloseEmulador();
                MessageBox.Show(messagemFinal);
            }
            else
            {
                if (listaContatos.Count == 0)
                {
                    Banco.Tb_contato_email.Resetar();
                }
                MessageBox.Show("Tabela de Envio Resetada");
            }
            ExibirInformacoes();
            ExibirStatus();
            InternetService.Habilitar();
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
        private void btnCriarImagem_Click(object sender, EventArgs e)
        {
            Bitmap imagem = CriarImagemService.ConvertTextToImage(txtMensagen.Text, "Times New Roman", 10, Color.White, Color.Black, 300, 100);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.FilterIndex = 2; //define o padrão como sendo bitmap
            saveFileDialog1.Title = "Salvar arquivo imagem";
            saveFileDialog1.FileName = "img";
            saveFileDialog1.ShowDialog();
            if (!string.IsNullOrWhiteSpace(saveFileDialog1.FileName))
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                Image image = (Image)imagem;
                imagem.Save(fs, ImageFormat.Jpeg);

                MessageBox.Show("Arquivo imagem salvo com sucesso", "Imagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //fecha arquivo
                fs.Close();
            }
            else
            {
                MessageBox.Show("Arquivo inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
