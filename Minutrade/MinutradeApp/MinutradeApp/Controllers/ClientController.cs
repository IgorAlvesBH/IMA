using MinutradeApp.AppService.Concrete;
using MinutradeApp.AppService.Interfaces;
using MinutradeApp.Data.Repositories;
using MinutradeApp.Domain.Concrete;
using MinutradeApp.Domain.Entities;
using MinutradeApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MinutradeApp.Controllers
{
  public class ClientController : ApiController
  {

    #region Serviços
    private IAppServiceClient _AppServiceClient;
    #endregion

    public ClientController(IAppServiceClient serviceClient)
    {
      _AppServiceClient = serviceClient;
    }
    // GET: api/Client
    /// <summary>
    /// Obtém todos os registros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public HttpResponseMessage Get()
    {

      try
      {
        List<Client> clientList = _AppServiceClient.GetAll();
        List<ClientViewModel> resultList = new List<ClientViewModel>();
        foreach (Client client in clientList)
        {
          resultList.Add(new ClientViewModel(client));
        }
        var response = Request.CreateResponse(HttpStatusCode.NotFound, resultList);
        string uri = Url.Link("DefaultApi", "");
        response.Headers.Location = new Uri(uri);
        if (resultList.Count == 0)
        {
          return response;
        }
        response = Request.CreateResponse(HttpStatusCode.OK, resultList);
        response.Content = new StringContent(JsonConvert.SerializeObject(resultList));
        return response;
      }
      catch 
      {
        var response = Request.CreateResponse(HttpStatusCode.InternalServerError, "");
        string uri = Url.Link("DefaultApi", "");
        response.Headers.Location = new Uri(uri);
        return response;
      }
      finally
      {
        _AppServiceClient.Dispose();
      }
    }
    [HttpGet]
    // GET: api/Client/5
    public HttpResponseMessage Get(string id)
    {
      try
      {
        Client item = _AppServiceClient.SearchFor(cli => cli.Cpf == id).FirstOrDefault();
        var response = Request.CreateResponse(HttpStatusCode.NotFound, id);
        string uri = Url.Link("DefaultApi", "");
        response.Headers.Location = new Uri(uri);
        if (item == null)
        {
          return response;
        }
        ClientViewModel result = new ClientViewModel(item);
        response = Request.CreateResponse(HttpStatusCode.OK, result);
        response.Content = new StringContent(JsonConvert.SerializeObject(result));
        return response;
      }
      catch
      {
        var response = Request.CreateResponse(HttpStatusCode.InternalServerError, "");
        string uri = Url.Link("DefaultApi", "");
        response.Headers.Location = new Uri(uri);
        return response;
      }
      finally
      {
        _AppServiceClient.Dispose();
      }
    }
    [HttpPost]
    // POST: api/Client
    public HttpResponseMessage Post(ClientViewModel client)
    {
      try
      {
        Client clientNew = new Client();
        clientNew.Adress = new Adress();
        clientNew.Adress.Id = Guid.NewGuid();
        clientNew.Adress.City = client.City;
        clientNew.Adress.Complement = client.Complement;
        clientNew.Adress.Country = client.Country;
        clientNew.Adress.District = client.District;
        clientNew.Adress.Number = client.Number;
        clientNew.Adress.State = client.State;
        clientNew.Adress.Street = client.Street;
        clientNew.Adress.ZipCode = client.ZipCode;
        clientNew.AdressId = clientNew.Adress.Id;
        clientNew.CellPhone = client.CellPhone;
        clientNew.Phone = client.Phone;
        clientNew.Name = client.Name;
        clientNew.MaritalStatus = client.MaritalStatus;
        clientNew.Email = client.Email;
        clientNew.Cpf = client.Cpf;
        int rowsAffected = _AppServiceClient.PostClient(clientNew);

        var response = Request.CreateResponse(HttpStatusCode.Created, client);
        string uri = Url.Link("DefaultApi", new { id = client.Cpf });
        response.Headers.Location = new Uri(uri);
        if (rowsAffected > 0)
        {
          return response;
        }
        response = Request.CreateResponse(HttpStatusCode.Conflict, client);
        return response;
      }
      catch
      {
        var response = Request.CreateResponse(HttpStatusCode.InternalServerError, client);
        string uri = Url.Link("DefaultApi", new { id = client.Cpf });
        response.Headers.Location = new Uri(uri);
        return response;
      }
      finally
      {
        _AppServiceClient.Dispose();
      }
    }
    [HttpPut]
    // PUT: api/Client/5    
    public HttpResponseMessage Put(ClientViewModel obj)
    {
      try
      {
        Client clientUpdate = _AppServiceClient.SearchFor(cli => cli.Cpf == obj.Cpf).FirstOrDefault();
        var response = Request.CreateResponse(HttpStatusCode.NotFound, obj);
        string uri = Url.Link("DefaultApi", new { id = obj.Cpf });
        response.Headers.Location = new Uri(uri);
        if (clientUpdate == null)
        {
          return response;
        }
        clientUpdate.CellPhone = obj.CellPhone.Trim();
        clientUpdate.Cpf = obj.Cpf;
        clientUpdate.Email = obj.Email;
        clientUpdate.MaritalStatus = obj.MaritalStatus;
        clientUpdate.Name = obj.Name;
        clientUpdate.Phone = obj.Phone;
        clientUpdate.Adress.City = obj.City;
        clientUpdate.Adress.Complement = obj.Complement;
        clientUpdate.Adress.Country = obj.Country;
        clientUpdate.Adress.District = obj.District;
        clientUpdate.Adress.Number = obj.Number;
        clientUpdate.Adress.State = obj.State;
        clientUpdate.Adress.Street = obj.Street;
        clientUpdate.Adress.ZipCode = obj.ZipCode;
        int rowsAffected = _AppServiceClient.PutClient(clientUpdate);
        if (rowsAffected > 0)
        {
          response = Request.CreateResponse(HttpStatusCode.OK, obj);
          return response;
        }
        response = Request.CreateResponse(HttpStatusCode.Conflict, obj);
        return response;
      }
      catch
      {
        var response = Request.CreateResponse(HttpStatusCode.InternalServerError, obj);
        string uri = Url.Link("DefaultApi", new { id = obj.Cpf });
        response.Headers.Location = new Uri(uri);
        return response;
      }
      finally
      {
        _AppServiceClient.Dispose();
      }
    }
    [HttpDelete]
    // DELETE: api/Client/5
    public HttpResponseMessage Delete(string id)
    {
      try
      {
        var response = Request.CreateResponse(HttpStatusCode.NotFound, id);
        string uri = Url.Link("DefaultApi", new { id = id });
        response.Headers.Location = new Uri(uri);
        int rowsAffected = _AppServiceClient.DeleteClient(id);
        if (rowsAffected > 0)
        {
          response = Request.CreateResponse(HttpStatusCode.OK, id);
          return response;
        }
        return response;
      }
      catch 
      {
        var response = Request.CreateResponse(HttpStatusCode.InternalServerError, id);
        string uri = Url.Link("DefaultApi", new { id = id });
        response.Headers.Location = new Uri(uri);
        return response;
      }
      finally
      {
        _AppServiceClient.Dispose();
      }
    }
  }
}
