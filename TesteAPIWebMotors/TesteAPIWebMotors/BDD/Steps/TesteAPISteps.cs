using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using StackExchange.Redis;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TesteAPIWebMotors.Page;

namespace TesteAPIWebMotors.BDD.Steps
{
    [Binding]
    public class TesteAPISteps : APIPage
    {
        string content;
        int ID;
        string Name;
        string Version;
        string Make;
        string Model;

        [When(@"faco a requisicao usando o (.*) para buscar a marca")]
        public void QuandoFacoARequisicaoUsandoOParaBuscarAMarca(int id)
        {           
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make?ID={id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            content = (string)response.Content;            
            var result = JsonConvert.DeserializeObject<List<APIPage.WebMotors>>(content);            
            var api_1 = result[id];            
            Name = api_1.Name;
        }
        
        [Then(@"valido o (.*) de busca na API")]
        public void EntaoValidoODeBuscaNaAPI(string resultado)
        {
            Assert.AreEqual(Name, resultado);
        }

        [When(@"faco a requisicao usando o (.*) para buscar o modelo pelo (.*)")]
        public void QuandoFacoARequisicaoUsandoOParaBuscarOModeloPelo(int makeId, int parametro)
        {
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID={makeId}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);            
            content = (string)response.Content;
            var result = JsonConvert.DeserializeObject<List<APIPage.WebMotors>>(content);
            var api_2 = result[parametro];
            ID = api_2.ID;
            Name = api_2.Name;
        }

        [Then(@"valido o (.*) e o (.*) do carro")]
        public void EntaoValidoOEODoCarro(string modelo, int id)
        {
            Assert.AreEqual(modelo, Name);
            Assert.AreEqual(ID, id);
        }

        [When(@"faco a requisicao usando o (.*) para buscar a versao pelo (.*)")]
        public void QuandoFacoARequisicaoUsandoOParaBuscarAVersaoPelo(int modelID, int parametro)
        {
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID={modelID}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            content = (string)response.Content;
            var result = JsonConvert.DeserializeObject<List<APIPage.WebMotors>>(content);
            var api_3 = result[parametro];
            ID = api_3.ID;
            Name = api_3.Name;
        }

        [When(@"faco a requisicao usando o (.*) para buscar a nova versao pelo (.*)")]
        public void QuandoFacoARequisicaoUsandoOParaBuscarANovaVersaoPelo(int id, int parametro)
        {
            var client = new RestClient($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Vehicles?Page={id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            content = (string)response.Content;
            var result = JsonConvert.DeserializeObject<List<APIPage.WebMotors>>(content);
            var api_4 = result[parametro];
            ID = api_4.ID;
            Name = api_4.Name;
            Make = api_4.Make;
            Model = api_4.Model;
            Version = api_4.Version;
        }

        [Then(@"valido o (.*),(.*),(.*) e o (.*)")]
        public void EntaoValidoOEO(string versao, string marca, string modelo, int id)
        {
            Assert.AreEqual(id, ID);
            Assert.AreEqual(Make,marca);
            Assert.AreEqual(Version, versao);
            Assert.AreEqual(Model, modelo);
        }
    }
}
