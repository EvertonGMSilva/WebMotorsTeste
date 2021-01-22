using Automation.Base;
using TechTalk.SpecFlow;
using TesteWebMotors.Pages;

namespace TesteWebMotors.BDD.Steps
{
    class WebMotorsSteps : Driver
    {
        WebMotorsPage webMotorsPage = new WebMotorsPage();

        [Given(@"que estou na home da WebMotors")]
        public void DadoQueEstouNaHomeDaWebMotors()
        {
            ElementeExiste(WebMotorsPage.boxInformacao);
        }

        [When(@"faço a busca de uma (.*) de carro")]
        [Given(@"faço a busca de uma (.*) de carro")]
        public void DadoFacoABuscaDeUmaDeCarro(string marca)
        {
            webMotorsPage.Pesquisar(marca).CliquePesquisa(marca);

        }

        [Given(@"valido o filtro da marca")]
        public void DadoValidoOFiltroDaMarca()
        {
            webMotorsPage.ObtenhoMarcaFiltro().ValidaFiltroMarca();
        }

        [When(@"filtro o (.*) do carro")]
        public void QuandoFiltroODoCarro(string modelo)
        {
            webMotorsPage.CliqueTodosModelos()
                            .CliqueModeloCarro(modelo)
                            .CliqueVersaoCarro();
        }

        [When(@"valido o filtro do modelo")]
        public void QuandoValidoOFiltroDoModelo()
        {
            webMotorsPage.ValidaVesaoCarro();
        }

        [Then(@"valido que a busca foi feita com sucesso")]
        public void EntaoValidoQueABuscaFoiFeitaComSucesso()
        {
            webMotorsPage.ListResultados();
        }

        [When(@"faço a busca ""(.*)""")]
        public void QuandoFacoABusca(string name)
        {
            webMotorsPage.Pesquisar(name);
            SetImplicityWait(290);
        }

        [Then(@"valido a (.*) de erro")]
        public void EntaoValidoADeErro(string msg)
        {           
            webMotorsPage.ValidaMsgErroPesquisa(msg);
        }

    }
}
