using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutradeApp.AppService.Interfaces;
using MinutradeApp.AppService.Concrete;
using MinutradeApp.Domain.Concrete;
using MinutradeApp.Tests;
using System.Collections.Generic;
using MinutradeApp.Domain.Entities;
using MinutradeApp.Controllers;
using MinutradeApp.ViewModel;
using System.Web.Http.Results;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net;
using MinutradeApp.Domain.Interfaces.Services;

namespace MinutradeApp.Tests
{
  [TestClass]
  public class TestClientController
  {

    /// <summary>
    /// Service
    /// </summary>
    private IAppServiceClient AppServiceClient
    {
      get
      {
        if (_AppServiceClient == null)
        {
          _AppServiceClient = new AppServiceClient(ServiceClient);
        }
        return _AppServiceClient;
      }
    }private IAppServiceClient _AppServiceClient;

    private IServiceClient ServiceClient
    {
      get
      {
        if (_ServiceClient == null)
        {
          _ServiceClient = new ServiceClient((new RepositoryClientTest(DbContext)));
        }
        return _ServiceClient;
      }
    }private IServiceClient _ServiceClient;

    /// <summary>
    /// Simula o banco de dados
    /// </summary>
    private Dictionary<string, Client> DbContext { get; set; }
    /// <summary>
    /// Controller a ser testado
    /// </summary>
    private ClientController Controller { get; set; }

    [TestInitialize]
    public void Setup()
    {      
      DbContext = new Dictionary<string, Client>();
      Controller = new ClientController(AppServiceClient);
      Controller.Request = new HttpRequestMessage
      {
        RequestUri = new Uri(@"http://localhost/api/Client")
      };
      Controller.Configuration = new HttpConfiguration();
      Controller.Configuration.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional });

      Controller.RequestContext.RouteData = new HttpRouteData(
          route: new HttpRoute(),
          values: new HttpRouteValueDictionary { { "controller", "client" } });
    }
    #region Testes de integração garantindo o statusCode esperado    
    /// <summary>
    /// Cria o contexto de teste para o post
    /// </summary>
    /// <param name="clientView"></param>
    public void CreateTestPost(out ClientViewModel clientView)
    {
      clientView = new ClientViewModel();
      clientView.Cpf = "33090079879";
      clientView.Name = "Test";
      clientView.CellPhone = "3112345620";
      clientView.Phone = "31988888888";
      clientView.MaritalStatus = "Solteiro(a)";
      clientView.Email = "teste@teste.com";
      clientView.City = "Belo Horizonte";
      clientView.State = "MG";
      clientView.Street = "Rua 1";
      clientView.Number = 100;
      clientView.ZipCode = "12255200";
      clientView.Complement = "Apto";
      clientView.Country = "Brasil";
      clientView.District = "Teste";      
    }    

    /// <summary>
    /// Teste dos casos em que o CPF já existe na base, deve ser retornado 409 - Conflict
    /// </summary>
    [TestMethod]
    public void TestClientControllerPost()
    {
      ClientViewModel model = null;
      CreateTestPost(out model);
      var result = Controller.Post(model);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.Created);
      //Não permite CPF duplicado
      result = Controller.Post(model);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.InternalServerError);
      //Não permite com CPF inválido.
      model.Cpf = string.Empty;
      result = Controller.Post(model);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.Conflict);
    }

    /// <summary>
    /// Cria o contexto de teste para Put
    /// </summary>
    /// <param name="clientView"></param>
    public void CreateTestPut(out ClientViewModel clientView)
    {
      clientView = new ClientViewModel();
      clientView.Cpf = "33090079879";
      clientView.Name = "Test";
      clientView.CellPhone = "3112345620";
      clientView.Phone = "31988888888";
      clientView.MaritalStatus = "Solteiro(a)";
      clientView.Email = "teste@teste.com";
      clientView.City = "Belo Horizonte";
      clientView.State = "MG";
      clientView.Street = "Rua 1";
      clientView.Number = 100;
      clientView.ZipCode = "12255200";
      clientView.Complement = "Apto";
      clientView.Country = "Brasil";
      clientView.District = "Teste";
      Controller.Post(clientView);
    }

    [TestMethod]
    public void TestClienControllerPut()
    {
      ClientViewModel model = null;
      CreateTestPut(out model);
      var result = Controller.Put(model);
      //Atualizado com sucesso
      Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
      //Todos os campos precisam estar preenchidos.
      model.Email = null;
      result = Controller.Put(model);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.Conflict);
      //Não encontra o CPF, retorna notFound
      model.Cpf = "123456";
      result = Controller.Put(model);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
    }
    /// <summary>
    /// Contexto do teste de exclusão
    /// </summary>
    /// <param name="clientView"></param>
    public void CreateTestDelete(out ClientViewModel clientView)
    {
      clientView = new ClientViewModel();
      clientView.Cpf = "33090079879";
      clientView.Name = "Test";
      clientView.CellPhone = "3112345620";
      clientView.Phone = "31988888888";
      clientView.MaritalStatus = "Solteiro(a)";
      clientView.Email = "teste@teste.com";
      clientView.City = "Belo Horizonte";
      clientView.State = "MG";
      clientView.Street = "Rua 1";
      clientView.Number = 100;
      clientView.ZipCode = "12255200";
      clientView.Complement = "Apto";
      clientView.Country = "Brasil";
      clientView.District = "Teste";
      Controller.Post(clientView);
    }

    [TestMethod]
    public void TestClienControllerDelete()
    {
      ClientViewModel model = null;
      CreateTestDelete(out model);
      var result = Controller.Delete(model.Cpf);
      //Atualizado com sucesso
      Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
      //Não encontrado pois o item já foi removido.
      result = Controller.Delete(model.Cpf);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
    }

    public void CreateTestGet(out ClientViewModel clientView)
    {
      clientView = new ClientViewModel();
      clientView.Cpf = "33090079879";
      clientView.Name = "Test";
      clientView.CellPhone = "3112345620";
      clientView.Phone = "31988888888";
      clientView.MaritalStatus = "Solteiro(a)";
      clientView.Email = "teste@teste.com";
      clientView.City = "Belo Horizonte";
      clientView.State = "MG";
      clientView.Street = "Rua 1";
      clientView.Number = 100;
      clientView.ZipCode = "12255200";
      clientView.Complement = "Apto";
      clientView.Country = "Brasil";
      clientView.District = "Teste";
      Controller.Post(clientView);
    }
    [TestMethod]
    public void TestClientControllerGet()
    {
      ClientViewModel model = null;      
      var result = Controller.Get();
      //Não possui registros
      Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);

      CreateTestGet(out model);
      result = Controller.Get();
      Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
    }

    [TestMethod]
    public void TestClientControllerGetWithParam()
    {
      ClientViewModel model = null;
      var result = Controller.Get("33090079879");
      //Não possui registros
      Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);

      CreateTestGet(out model);
      result = Controller.Get(model.Cpf);
      Assert.IsTrue(result.StatusCode == HttpStatusCode.OK);
    }
    #endregion

    #region Testes de unidade garantindo o funcionamento da regra conforme o esperado.
    /// <summary>
    /// Garante que o validor de CPF está correto.
    /// </summary>
    [TestMethod]
    public void TestCpfValidation()
    {
      bool result = ServiceClient.IsCpfValid("49965342229");
      Assert.IsTrue(result);

      result = ServiceClient.IsCpfValid("111111");
      Assert.IsFalse(result);

      result = ServiceClient.IsCpfValid("930.762.350-36");

      Assert.IsTrue(result);
    }

    public Client CreateTestClientValidation()
    {
      Client client = new Client();
      client.Adress = new Adress();
      client.Adress.Id = Guid.NewGuid();
      client.Adress.City = "Cidade";
      client.Adress.Complement = "Apto 999";
      client.Adress.Country = "Brasil";
      client.Adress.District = "Bairro";
      client.Adress.Number = 1000;
      client.Adress.State = "Estado";
      client.Adress.Street = "Rua/Av";
      client.Adress.ZipCode = "25555000";
      client.Id = Guid.NewGuid();
      client.AdressId = client.Adress.Id;
      client.CellPhone = "31111111111";
      client.Phone = "31111111111";
      client.Cpf = "49965342229";
      client.Name = "Nome";
      client.MaritalStatus = "Solteiro(a)";
      client.Email = "email@email.com";
      return client;
    }
    /// <summary>
    /// Testa se o objeto é válido, a regra preconiza que todos os campos precisam estar preenchidos.
    /// </summary>
    [TestMethod]
    public void TestClientValidation()
    {
      Client client = CreateTestClientValidation();
      bool result = ServiceClient.IsClientValid(client);
      Assert.IsTrue(result);
      //Testando propriedades de endereço.
      client.Adress.City = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);
      
      client = CreateTestClientValidation();
      client.Adress.Complement = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Adress.Country = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Adress.District = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Adress.State = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Adress.Street = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Adress.ZipCode = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      //Testando propriedades de cliente
      client = CreateTestClientValidation();
      client.Cpf = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.CellPhone = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Phone = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Email = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.MaritalStatus = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);

      client = CreateTestClientValidation();
      client.Name = null;
      result = ServiceClient.IsClientValid(client);
      Assert.IsFalse(result);
    }
    #endregion
  }
}
