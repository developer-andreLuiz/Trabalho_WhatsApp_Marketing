using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_WhatsApp_Marketing.Service
{
    public class WhatsApp
    {
        private static AppiumDriver<AndroidElement> Driver;
        
        //Funções Base
        public static void OpenApp(string udid, int timeOutInSeconds = 600)
        {
            try
            {
                
                var appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("platformName", "android");
                appOptions.AddAdditionalCapability("noReset", "true");
                appOptions.AddAdditionalCapability("platformVersion", "7.1.2");
                appOptions.AddAdditionalCapability("appPackage", "com.whatsapp");
                appOptions.AddAdditionalCapability("appActivity", "com.whatsapp.HomeActivity");
                appOptions.AddAdditionalCapability("udid", udid);
                appOptions.AddAdditionalCapability("newCommandTimeout", 0);
                Driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appOptions, TimeSpan.FromSeconds(timeOutInSeconds));
            }
            catch
            {

            }
        }
        public static void OpenApp(int timeOutInSeconds = 600)
        {
            try
            {
                var appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("automationName", "UiAutomator2");
                appOptions.AddAdditionalCapability("platformName", "android");
                appOptions.AddAdditionalCapability("noReset", "true");
                appOptions.AddAdditionalCapability("platformVersion", "7.0");
                appOptions.AddAdditionalCapability("appPackage", "com.whatsapp");
                appOptions.AddAdditionalCapability("appActivity", "com.whatsapp.HomeActivity");
                //appOptions.AddAdditionalCapability("udid", udid);
                appOptions.AddAdditionalCapability("newCommandTimeout", 0);
                Driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appOptions, TimeSpan.FromSeconds(timeOutInSeconds));

            }
            catch
            {

            }
        }
        public static void OpenApp(int Teste, string versao, int timeOutInSeconds = 600)
        {
            try
            {
                var appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("automationName", "UiAutomator2");
                appOptions.AddAdditionalCapability("platformName", "android");
                appOptions.AddAdditionalCapability("noReset", "true");
                appOptions.AddAdditionalCapability("platformVersion", versao);
                appOptions.AddAdditionalCapability("appPackage", "com.whatsapp");
                appOptions.AddAdditionalCapability("appActivity", "com.whatsapp.HomeActivity");
                //appOptions.AddAdditionalCapability("udid", udid);
                appOptions.AddAdditionalCapability("newCommandTimeout", 0);
                Driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appOptions, TimeSpan.FromSeconds(timeOutInSeconds));

            }
            catch
            {

            }
        }
        public static void Close()
        {
            try
            {
                Driver.CloseApp();
            }
            catch { }
        }
        //Funções de Tela Conversa
        public static void EntraPrimeiraConversa()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Conversas = Driver.FindElementsByXPath("//*[@class='android.widget.RelativeLayout']");
                foreach (AndroidElement conversa in all_Conversas)
                {
                    conversa.Click();
                    break;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message + " EntraPrimeiraConversa");
            }

        }
        //Funções de Contatos
        public static void ClicarContatos()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.whatsapp:id/fab']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarContatos");
            }
        }
        public static void ClicarLupaProcurarContatos()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp:id/menuitem_search']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarLupaProcurarContatos");
            }
        }
        public static void DigitarBarraPesquisarContatos(string contato)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
              
                var barra = Driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.whatsapp:id/search_src_text']"));
                if (barra != null)
                {
                    Actions action = new Actions(Driver);
                    
                    char[] Numeros = contato.ToCharArray();
                    
                    foreach (char numero in Numeros)
                    {
                        action = new Actions(Driver);
                        action.SendKeys(numero.ToString()).Perform();
                        Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " DigitarBarraPesquisarContatos");
            }
        }
        public static bool ContatoEncontrado()
        {
            //nenhum resultado para o numero xxxxxx tem q melhorar 
            bool retorno = true;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.whatsapp:id/invite']"));
                if (btn != null)
                {
                    retorno = false;
                }
            }
            catch{}
            try
            {
                //Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var txt = Driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp:id/contactpicker_row_name']"));
                if (txt != null)
                {
                    if (txt.Text.Contains("Sem resultados para"))
                    {
                        retorno = false;
                    }
                   
                }
            }
            catch { }

            return retorno;
        }
        public static void LimparBarraPesquisarContatos()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc='Limpar consulta']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " LimparBarraPesquisarContatos");
            }
        }
        public static void ClicarEmContatoEncontrato()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp:id/contactpicker_row_name']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarEmContatoEncontrato");
            }
        }
        
        //Funções de Envio Dentro da Conversa
        public static void ClicarVoltar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageView[@resource-id='com.whatsapp:id/whatsapp_toolbar_home']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarVoltar");
            }
        }
        public static void ClicarInserir()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.whatsapp:id/input_attach_button']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarInserir");
            }
        }
        public static void ClicarGaleria()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.LinearLayout[@resource-id='com.whatsapp:id/pickfiletype_gallery_holder']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarGaleria");
            }
        }
        public static void ClicarPastaPictures()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@text='Pictures']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarPastaPictures");
            }
        }
        public static void SelecionarImagensPictures()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Photos = Driver.FindElementsByXPath("//*[@class='android.widget.ImageView']");
                TouchAction touch = new TouchAction(Driver);
                bool p = false;
                foreach (AndroidElement img in all_Photos)
                {
                    if (p == false)
                    {
                        touch.LongPress(img).Perform();
                        Thread.Sleep(TimeSpan.FromMilliseconds(500));
                        p = true;
                    }
                    else
                    {
                        img.Click();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " SelecionarImagensPictures");
            }

        }
        public static void ConfirmarSelecaoImagensPictures()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@text='OK']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ConfirmarSelecaoImagens");
            }
        }
        public static void ClicarEnviar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageButton[@resource-id='com.whatsapp:id/send']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarEnviar");
            }
        }
        public static void DigitarMensagem(string texto)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var txtEdit = Driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.whatsapp:id/entry']"));
                txtEdit.SendKeys(texto);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " DigitarMensagem");
            }
        }
        public static void ClicarOpcoes()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc='Mais opções']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarOpcoes");
            }
        }
        public static void ClicarMidia()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@text='Mídia, links e docs']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarMidia");
            }
        }
        public static void SelecionarConversaEnviada()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Conversas = Driver.FindElementsByXPath("//*[@class='android.view.ViewGroup']");//ele sempre retorna 2 a mais. a primeira mensagem comeca no count 2
                TouchAction touch = new TouchAction(Driver);
                bool p = false;
                int count = 0;
                foreach (AndroidElement conversa in all_Conversas)
                {
                    if (count>1)
                    {
                        if (p == false)
                        {
                            touch.LongPress(conversa).Perform();
                            Thread.Sleep(TimeSpan.FromMilliseconds(500));
                            p = true;
                        }
                        else
                        {
                            conversa.Click();
                        }
                    }
                    count++;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " SelecionarConversaEnviada");
            }
        }
        public static void ClicarCompartilhar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp:id/menuitem_forward']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarCompartilhar");
            }
        }
        public static void ClicarVoltarCompartilhar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageButton[@content-desc='Navegar para cima']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarVoltar");
            }
        }
        public static void EnvioDentroDaConversa()
        {
            try
            {
                ClicarInserir();
                ClicarGaleria();
                ClicarPastaPictures();
                SelecionarImagensPictures();
                ConfirmarSelecaoImagensPictures();
                ClicarEnviar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " EnvioDentroDaConversa");
            }

        }
        public static void CompartilharDentroDaConversa()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(20));
                ClicarOpcoes();
                ClicarMidia();
                SelecionarImagensPictures();
                ClicarCompartilhar();
                ClicarLupaProcurarContatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " CompartilharDentroDaConversa");
            }

        }
        public static void CompartilharDentroDaMidia()
        {
            try
            {
                SelecionarImagensPictures();
                ClicarCompartilhar();
                ClicarLupaProcurarContatos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " CompartilharDentroDaConversa");
            }

        }
        //Funções de Banckup -- Politica e Termos
        public static bool VerificarBackup()
        {
            bool retorno = false;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var text = Driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp:id/settings_gdrive_backup_now_category_title']"));
                if (text != null)
                {
                    retorno = true;
                }
            }
            catch { }

            return retorno;
        }
        public static void ClicarNuncaBackup()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.RadioButton[@text='Nunca']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarNuncaBackup");
            }
        }
        public static void ClicarOkBackup()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.whatsapp:id/gdrive_new_user_setup_btn']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarOkBackup");
            }
        }
        public static void ClicarFecharNotificacao()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageView[@resource-id='com.whatsapp:id/cancel']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + " ClicarFecharNotificacao");
            }
        }
        public static void ResolverBackupTermos()
        {
            try
            {
                if (VerificarBackup() == true)
                {
                    ClicarNuncaBackup();
                    ClicarOkBackup();
                }
            }
            catch { }

            try
            {
                ClicarFecharNotificacao();
            }
            catch { }
        }
        //Função de Deletar Conversa
        public static int SelecionarConversa1()
        {
            int r = 0;
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var all_Conversas = Driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id='com.whatsapp:id/contact_row_container']");
                TouchAction touch = new TouchAction(Driver);
                bool p = false;
                r = all_Conversas.Count;
                foreach (AndroidElement conversa in all_Conversas)
                {
                    if (p == false)
                    {
                        touch.LongPress(conversa).Perform();
                        Thread.Sleep(TimeSpan.FromMilliseconds(500));
                        p = true;
                        break;

                    }
                    else
                    {
                        conversa.Click();
                    }
                }

            }
            catch (Exception e)
            {

                //MessageBox.Show(e.Message + " SelecionarConversa1");
            }
            return r;
        }
        public static void ClicarMaisOpcoes()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.ImageView[@content-desc='Mais opções']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarMaisOpcoes");
            }
        }
        public static void ClicarSelecionarTodas()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@text='Selecionar todas']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarSelecionarTodas");
            }
        }
        public static void ClicarApagarConversas()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='com.whatsapp:id/menuitem_conversations_delete']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarApagarConversas");
            }
        }
        public static void ClicarApagar()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var btn = Driver.FindElement(By.XPath("//android.widget.Button[@resource-id='android:id/button1']"));
                if (btn != null)
                {
                    btn.Click();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " ClicarApagar");
            }
        }
        public static void ApagarConversas()
        {
            int conversas = SelecionarConversa1();
            if (conversas > 0)
            {
                if (conversas>1)
                {
                    ClicarMaisOpcoes();
                    ClicarSelecionarTodas();
                }
              
                ClicarApagarConversas();
                ClicarApagar();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
