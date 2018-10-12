using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace EstudoSelenium
{
    
    public class TesteSelenium : IDisposable
    {
        private IWebDriver driver;
        private string url;

        public TesteSelenium()
        {
            url = "http://www.google.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        [Fact]
        public void GoogleSearchTest()
        {
            driver.Navigate().GoToUrl(url + "/");
            driver.FindElement(By.ClassName("gsfi")).SendKeys("VSTS");
            driver.FindElement(By.Name("btnK")).Submit();
            driver.FindElement(By.ClassName("r")).Click();
            var titulo = driver.Title.Contains("Visual Studio Team Services");
            Assert.True(titulo);
        }

        [Fact]
        public void PoliedroGoogleSearchTest()
        {
            driver.Navigate().GoToUrl(url + "/");
            driver.FindElement(By.ClassName("gsfi")).SendKeys("Poliedro Educação");
            driver.FindElement(By.Name("btnK")).Submit();
            driver.FindElement(By.ClassName("r")).FindElement(By.TagName("a")).Click();
            var titulo = driver.Title.Contains("Poliedro");
            Assert.True(titulo);
        }

        [Fact]
        public void TestaFormulario()
        {
            driver.Navigate().GoToUrl("http://concursodebolsa.sistemapoliedro.com.br/DadosCadastro.aspx");
            driver.FindElement(By.Id("txt_Nome")).SendKeys("Nome aluno teste");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_Email")).SendKeys("aluno@teste.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_ConfirmacaoEmail")).SendKeys("aluno@teste.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_Cpf")).SendKeys("69946980096");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_RG")).SendKeys("372809327");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_Telefone")).SendKeys("86260949626");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_DtNascimento")).SendKeys("27061996");
            Thread.Sleep(1000);
            var listaEstado = driver.FindElement(By.Id("cbo_estado"));
            var estadoSP = new SelectElement(listaEstado);
            estadoSP.SelectByText("SP");
            Thread.Sleep(1000);
            var listaCidade = driver.FindElement(By.Id("cbo_Cidade"));
            var cidadeSJC = new SelectElement(listaCidade);
            cidadeSJC.SelectByText("SAO JOSE DOS CAMPOS");
        }

        [Fact]
        public void TesteFormularioComplexo()
        {
            driver.Navigate().GoToUrl("https://getbootstrap.com/docs/4.0/components/forms/");

            //INPUT TEXT BÁSICO
            driver.FindElement(By.Id("exampleFormControlInput1")).SendKeys("Texto teste formulário");

            //DROP DOWN
            var lista = driver.FindElement(By.Id("exampleFormControlSelect1"));
            var itemLista = new SelectElement(lista);
            itemLista.SelectByText("2");

            //MULTI SELECT DROP DOWN
            var listaMulti = driver.FindElement(By.Id("exampleFormControlSelect2"));
            var itens = new SelectElement(listaMulti);
            itens.SelectByIndex(0);
            itens.SelectByIndex(2);

            //INPUT TEXT AREA BÁSICO
            driver.FindElement(By.Id("exampleFormControlTextarea1")).SendKeys("ABCDEF GHIJKLMN 123456");

            //CHECKBOX
            var select = new SelectElement(driver.FindElement(By.Id("defaultCheck1")));
            select.SelectByText("Default checkbox");

            //INPUT TEXT AREA BÁSICO
            //driver.FindElement(By.Id("defaultCheck1")).Clear();


            Thread.Sleep(50000);
        }

    }
}
