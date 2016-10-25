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
  }
}
