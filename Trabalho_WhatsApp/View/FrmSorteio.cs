using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp.Model;
using Trabalho_WhatsApp.Service;

namespace Trabalho_WhatsApp.View
{
    public partial class FrmSorteio : Form
    {
        List<Tb_sorteio_Model> ListaFinal = new List<Tb_sorteio_Model>();
       
        public FrmSorteio()
        {
            InitializeComponent();
        }

        private void btnBuscarInformacao_Click(object sender, EventArgs e)
        {
            var ListaSorteio = Banco.Tb_sorteio.RetornoCompleto();

            var ListaIndividual = new List<Tb_sorteio_Model>();

            ListaFinal = new List<Tb_sorteio_Model>();

            foreach (var item in ListaSorteio)
            {
                if (ListaIndividual.FindAll(x => x.telefone.Length > 0 && x.telefone.Equals(item.telefone)).Count == 0)
                {
                    ListaIndividual.Add(item);
                }
            }


            foreach (var item in ListaIndividual)
            {
                if (ListaSorteio.FindAll(x => x.telefone.Equals(item.telefone)).Count >= nUD.Value)
                {
                    ListaFinal.Add(item);
                }
            }



            lblQuantidadeTexto.Text = nUD.Value.ToString();
            lblVolumeCurti.Text = ListaFinal.Count.ToString();
            lblTotalNumeros.Text = ListaIndividual.Count.ToString();
            lblTotalCurti.Text = ListaSorteio.Count.ToString();
        }

       private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ListaFinal.Count > 0)
            {
              

                string[] textoParaImpressao = new string[ListaFinal.Count];
             
                int linha = 0;
                int coluna = 0;
                int pulalinha = 0;
                int cmdPg = 0;
                foreach (var item in ListaFinal)
                {
                    if (pulalinha == 0)
                    {
                        textoParaImpressao[linha] = "__________________________________________________________________________";
                        pulalinha++;
                        linha++;
                        if (cmdPg==33)
                        {
                            cmdPg = 0;
                          
                            textoParaImpressao[linha] = string.Empty;
                            linha++;
                            textoParaImpressao[linha] = "__________________________________________________________________________";
                            linha++;
                          
                        }
                    }
                    else
                    {
                        if (pulalinha == 4)
                        {
                            textoParaImpressao[linha] += $"|            {item.telefone}           |";
                            cmdPg++;
                            coluna++;
                            if (coluna == 3)
                            {
                                linha++;
                                coluna = 0;
                                pulalinha = 0;
                            }
                        }
                        else
                        {
                            textoParaImpressao[linha] = "|                                            |                                           |                                            |";
                            pulalinha++;
                            linha++;
                        }



                    }


                    
                        
                }

             
                
                
                PrintDocument doc = new ImprimirDocumento(textoParaImpressao);
                doc.PrintPage += this.Doc_PrintPage;
                PrintDialog dialogo = new PrintDialog();
                dialogo.Document = doc;



                //  Se o usuário clicar em OK , imprime o documento
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }




























            }
            else
            {
                MessageBox.Show("Sem números para Imprimir");
            }

        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Recupera o documento que enviou este evento.
            ImprimirDocumento doc = (ImprimirDocumento)sender;

            // Define a fonte e determina a altura da linha
            using (Font fonte = new Font("Verdana", 10))
            {
                float alturaLinha = fonte.GetHeight(e.Graphics);

                // Cria as variáveis para tratar a posição na página
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                // Incrementa o contador de página para refletir
                // a página que esta sendo impressa
                doc.NumeroPagina += 1;

                // Imprime toda a informação que cabe na página
                // O laço termina quando a próxima linha
                // iria passar a borda da margem ou quando não
                // houve mais linhas a imprimir
                while ((y + alturaLinha) < e.MarginBounds.Bottom &&
                  doc.Offset <= doc.Texto.GetUpperBound(0))
                {
                    e.Graphics.DrawString(doc.Texto[doc.Offset], fonte,
                      Brushes.Black, x, y);

                    // move para a proxima linha
                    doc.Offset += 1;

                    // Move uma linha para baixo (proxima linha)
                    y += alturaLinha;
                }

                if (doc.Offset < doc.Texto.GetUpperBound(0))
                {
                    // Havendo ainda pelo menos mais uma página.
                    // Sinaliza o evento para disparar novamente
                    e.HasMorePages = true;
                }
                else
                {
                    // A impressão terminou
                    doc.Offset = 0;
                }
            }
        }

    }
}
