using Automation.Base;
using OpenQA.Selenium;
using System;

namespace TesteWebMotors.Pages
{
    public class WebMotorsPage : Driver
    {
        public readonly By campoPesquisa = By.Id("searchBar");
        public static readonly By boxInformacao = By.Id("WhiteBox");
        public readonly By btnTodosModelos = By.XPath("//div[contains(text(), 'Todos os modelos')]");
        public readonly By btnTodasVersoes = By.XPath("//div[contains(text(), 'Todas as versões')]");
        public readonly By lblFiltroMarca = By.XPath("//ul[@id='FilterResultContainer']//following::a[contains(text(), 'HONDA')]");
        public readonly By btnFiltroModelo = By.XPath("//div[contains(text(), 'Todos os Modelos')]//following::a[contains(text(), 'CITY')]");
        public readonly By btnVersaoCarro = By.XPath("//a[contains(text(), '1.5 DX 16V FLEX 4P AUTOMÁTICO')]");
        public readonly By lblFiltroVersao = By.XPath("//div[@data-test-id='found-ads']//preceding::span[contains(text(), '1.5')]");
        public readonly By lblAnuncios = By.XPath("//h3[contains(text(), '1.5 DX 16V FLEX 4P AUTOMÁTICO')]");
        public readonly By lblResultados = By.XPath("//div[@data-test-id='found-ads']//child::strong");
        public readonly By txtMsgErroFiltro = By.XPath("//input[@id='searchBar']//following::div[contains(text(), 'Não encontramos')]");

        public string marcaCarro;
        public string filtroMarca;
        public string nomeCarro;
        public string versaoCarro;
        public string filtroVersao;
        public static int qtdAnuncios;

        public WebMotorsPage Pesquisar(string marca)
        {
            driver.FindElement(campoPesquisa).Click();
            SetImplicityWait(2000);
            driver.FindElement(campoPesquisa).SendKeys(marca);
            marcaCarro = marca.ToUpper();

            return this;
        }
        public WebMotorsPage CliquePesquisa(string marca)
        {
            SetImplicityWait(4000);
            var xpath = $"//div[contains(text(), 'Marcas')]//following::strong[contains(text(), '{marca}')][1]";
            driver.FindElement(By.XPath(xpath)).Click();

            return this;
        }
        public WebMotorsPage ObtenhoMarcaFiltro()
        {
            SetImplicityWait(4000);
            filtroMarca = GetElementText(lblFiltroMarca);

            return this;
        }
        public WebMotorsPage ValidaFiltroMarca()
        {
            ValidAssertAreEqual(marcaCarro, filtroMarca);           

            return this;
        }
        public WebMotorsPage CliqueTodosModelos()
        {
            Click(btnTodosModelos);

            return this;
        }
        public WebMotorsPage CliqueModeloCarro(string modelo)
        {
            nomeCarro = marcaCarro + " " + modelo;
            var xpath = $"//div[contains(text(), 'Todos os Modelos')]//following::a[contains(text(), '{modelo}')]";
            Click(By.XPath(xpath));
            return this;
        }
        public WebMotorsPage CliqueVersaoCarro()
        {
            SetImplicityWait(4000);
            Click(btnTodasVersoes);
            versaoCarro = GetElementText(btnVersaoCarro);
            Click(btnVersaoCarro);

            return this;
        }
        public WebMotorsPage ValidaVesaoCarro()
        {
            filtroVersao = GetElementText(lblFiltroVersao).ToUpper();
            ValidAssertAreEqual(versaoCarro, filtroVersao);

            return this;
        }
        public WebMotorsPage ListResultados()
        {
            int anuncios = GetWebElements(lblAnuncios);
            int qtdEncontrados = Convert.ToInt32(GetElementText(lblResultados));
            
            ValidAssertAreEqual(anuncios, qtdEncontrados);

            return this;
        }
        public WebMotorsPage ValidaMsgErroPesquisa(string msg)
        {
            SetImplicityWait(4000);
            var msgErro = GetElementText(txtMsgErroFiltro);

            ValidAssertAreEqual(msgErro, msg);

            return this;
        }
    }
}
