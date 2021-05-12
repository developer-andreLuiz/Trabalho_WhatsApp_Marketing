using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp_Marketing.Service
{
    class CriarImagemService
    {
        public static Bitmap CriarImagemBitMap(string textoImagem, string fonte, int tamanho)
        {
            try
            {
                Bitmap objBmpImage = new Bitmap(1, 1);
                int intWidth = 0;
                int intHeight = 0;
                // Cria o objeto Font para desenha o texto da imagem
                Font objFont = new Font(fonte, tamanho, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                // Cria o objeto grafico para medir a largura e altura do texto
                Graphics objGraphics = Graphics.FromImage(objBmpImage);
                // aqui determinamos o tamanho do bitmap 
                intWidth = (int)objGraphics.MeasureString(textoImagem, objFont).Width;
                intHeight = (int)objGraphics.MeasureString(textoImagem, objFont).Height;
                // Cria o bmpImage novamente com o tamanho correto para o texto e fonte
                objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));
                // Adiciona cores ao novo bitmap.
                objGraphics = Graphics.FromImage(objBmpImage);
                // Define a cor de fundo
                objGraphics.Clear(Color.White);
                objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                objGraphics.DrawString(textoImagem, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
                objGraphics.Flush();
                return (objBmpImage);
            }
            catch
            {
                throw;
            }
        }
        public static Bitmap Converte_Texto_Para_Imagem(string txt, string fontname, int fontsize)
        {
            try
            {
                //cria a imagem bitmap
                Bitmap bmp = new Bitmap(1, 1);
                //O método FromImage cria um novo Graphics a partir da imagem definida
                Graphics graphics = Graphics.FromImage(bmp);
                // Cria um objeto Font para desenhar o texto da imagem
                Font font = new Font(fontname, fontsize);
                // Instancia o objeto Bitmap imagem novamente com o tamanho correto para o texto e fonte
                SizeF stringSize = graphics.MeasureString(txt, font);
                bmp = new Bitmap(bmp, (int)stringSize.Width, (int)stringSize.Height);
                graphics = Graphics.FromImage(bmp);
                // Aqui temos uma outra possibilidade
                // bmp = new Bitmap(bmp, new Size((int)graphics.MeasureString(txt, font).Width, (int)graphics.MeasureString(txt, font).Height));
                //Desenha o texto com o formato definido
                graphics.DrawString(txt, font, Brushes.Blue, 0, 0);
                font.Dispose();
                graphics.Flush();
                graphics.Dispose();
                return bmp;
            }
            catch
            {
                throw;
            }
        }
        public static Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
        {
            try
            {
                //cria o bitmap
                Bitmap bmp = new Bitmap(width, Height);
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    //define a fonte e escreve o texto
                    Font font = new Font(fontname, fontsize);
                    graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
                    graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
                    graphics.Flush();
                    font.Dispose();
                    graphics.Dispose();
                }
                return bmp;
            }
            catch
            {
                throw;
            }
        }
    }
}
