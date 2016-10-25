using System;
using MinutradeApp.AppService.Interfaces;
using MinutradeApp.Domain.Entities;
using MinutradeApp.Domain.Interfaces.Services;

namespace MinutradeApp.AppService.Concrete
{
  /// <summary>
  /// Serviços de cliente
  /// </summary>
  public class AppServiceClient : AppServiceBase<Client>, IAppServiceClient
  {
    private readonly IServiceClient _ServiceClient;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="serviceClient">Serviço concreto de cliente</param>
    public AppServiceClient(IServiceClient serviceClient)
      : base(serviceClient)
    {
      _ServiceClient = serviceClient;
    }
    /// <summary>
    /// Remove o cliente
    /// </summary>
    /// <param name="cpf">CPF</param>
    public int DeleteClient(string cpf)
    {
      return _ServiceClient.DeleteClient(cpf);
    }

    /// <summary>
    /// Salva o registro de cliente
    /// </summary>
    /// <param name="client">Cliente</param>
    public int PostClient(Client client)
    {
      return _ServiceClient.PostClient(client);
    }
    /// <summary>
    /// Atualiza o registro
    /// </summary>
    /// <param name="client">Cliente</param>
    public int PutClient(Client client)
    {
      return _ServiceClient.PutClient(client);
    }
  }
}
