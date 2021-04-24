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
        #region Variaveis

        int EnvioPorWhatsApp = 50; //limite de envio por numero
        int LimiteCompartilharmento = 5; //limite de comportilhamento do zap
        int MaximoEnvio = 0;//valor gerado pelo calculo de emuladores x limite por numero
        string pathImagem = @"C:\Users\Public\Pictures"; //camilho da pasta de imgs
       
        
        
        List<Tb_emulador_Model> ListaEmuladores; //lista de emuladores ativos
        List<Tb_contato_email_Model> ListaContatosEmailCompleta; //tabela completa do banco
        List<Tb_contato_email_Model> ListaContatosEmailHabilitato = new List<Tb_contato_email_Model>();//Lista completa habilitada
        List<Tb_contato_email_Model> ListaContatosEmailFaltaEnviar = new List<Tb_contato_email_Model>();//Lista de contatos restantes

        List<string> ListaTeste = new List<string>();//lista provosória para teste

        string EmuladorAtual = String.Empty; //apenas informa o nome do emulador atual
        int MensagensEnviadas = 0; 
        int MensagensRestantes = 0;
        int ContatosNaoEncontrados = 0;

        //Variaveis Auxiliares

        int contatorEmulador = 0;  //auxilia na abertura do emulador pela lista de emuladores habilitados
        int contadorEnvio = 0;     //controla o numero de envios por numero para nao passar do limite
        
        bool AbrirEmulador = true;
        bool AbrirZap = true;
       

       

        #endregion
       
        #region Funções
        void ExibirInformacoes()
        {
            ListaEmuladores = Banco.Tb_emulador.RetornoCompletoHabilitado();
            ListaContatosEmailCompleta = Banco.Tb_contato_email.RetornoCompleto();
            foreach (Tb_contato_email_Model item in ListaContatosEmailCompleta)
            {
                if (item.habilitado==1)
                {
                    ListaContatosEmailHabilitato.Add(item);
                    if (item.whatsapp == 0 && item.business == 0)
                    {
                        ListaContatosEmailFaltaEnviar.Add(item);
                    }
                }
            }


            lblEnvioPorWhatsApp.Text = EnvioPorWhatsApp.ToString();
            lblLimiteCompartilhamento.Text = LimiteCompartilharmento.ToString();

            lblEmuladoresHabilitados.Text = ListaEmuladores.Count.ToString();
            int totalWhatsApp = ListaEmuladores.Count * 2;
            lblTotalWhatsApp.Text =totalWhatsApp.ToString();


            lblTotalContatosEmail.Text = ListaContatosEmailHabilitato.Count.ToString();
            MaximoEnvio = totalWhatsApp * EnvioPorWhatsApp;
            lblMaximoEnvio.Text = MaximoEnvio.ToString();
        }
        void ExibirTotalImagens()
        {
            lblTotalImagens.Text = TotalImagens().ToString();
        }
        void ExibirStatus()
        {
            lblEmuladorAtual.Text = EmuladorAtual;
            lblMensagensEnviadas.Text = MensagensEnviadas.ToString();
            lblMensagensRestantes.Text = MensagensRestantes.ToString();
            lblContatosNaoEncontrados.Text = ContatosNaoEncontrados.ToString();
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
        void Envio()
        {
            int compartilhar = 0;
            foreach (string n in ListaTeste)
            {

                //if (abrirEmulador)
                //{
                //    abrirEmulador = false;
                //    ProgramService.OpenEmulador(ListaEmuladores[contatorEmulador].nome);
                //    Thread.Sleep(TimeSpan.FromMinutes(1));
                //}
                if (AbrirZap)
                {
                    AbrirZap = false;
                    WhatsApp.OpenApp(ListaEmuladores[contatorEmulador].udid);
                    WhatsApp.ResolverBackupTermos();
                    WhatsApp.ClicarContatos();
                    WhatsApp.ClicarLupaProcurarContatos();
                    WhatsApp.DigitarBarraPesquisarContatos(n);
                    if (WhatsApp.ContatoEncontrado())
                    {
                        WhatsApp.ClicarEmContatoEncontrato();
                        WhatsApp.EnvioDentroDaConversa();
                        contadorEnvio++;
                    }
                    else
                    {
                        WhatsApp.LimparBarraPesquisarContatos();
                        ListaTeste.Remove(n);//provissório
                        //função para pensar de contato nao encontrado 
                    }
                }
                else
                {
                    if (compartilhar==0)
                    {
                        WhatsApp.CompartilharDentroDaConversa();//depois de enviar as 5 primeiras vc fica dentro da midia
                    }
                    if (compartilhar<5)
                    {
                        if (contadorEnvio < EnvioPorWhatsApp)
                        {
                            WhatsApp.DigitarBarraPesquisarContatos(n);
                            if (WhatsApp.ContatoEncontrado())
                            {
                                WhatsApp.ClicarEmContatoEncontrato();
                                WhatsApp.LimparBarraPesquisarContatos();
                                compartilhar++;
                                contadorEnvio++;
                            }
                            else
                            {
                                //função para pensar de contato nao encontrado 
                            }


                        }
                    }
                    //função de compartilhar com menos de 5 tambem
                    if (compartilhar == 5) 
                    {
                        WhatsApp.ClicarEnviar();
                        WhatsApp.ClicarVoltarCompartilhar();
                        compartilhar = 0;
                       
                        //provissório
                    }
                }
                //1000 envios em  2h 20 minutos  142 minutos 2h 30


                //10000 envios em   1420 minutos 23 h 







            }
        }







        #endregion
        #region Eventos
        public FrmEnvio()
        {
            InitializeComponent();
            ExibirInformacoes();
            ExibirTotalImagens();
            
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
            WhatsApp.OpenApp(ListaEmuladores[contatorEmulador].udid);
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Envio();
        }


        #endregion

        private void btnTeste_Click(object sender, EventArgs e)
        {
           
        }
    }
}
