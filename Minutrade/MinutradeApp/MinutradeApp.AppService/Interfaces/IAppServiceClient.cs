using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.AppService.Interfaces
{
  /// <summary>
  /// Serviços de cliente
  /// </summary>
  public interface IAppServiceClient : IAppServiceBase<Client>
  {
    /// <summary>
    /// Salva um novo cliente
    /// </summary>
    /// <param name="client">Objeto a ser gravado</param>
    int PostClient(Client client);
    /// <summary>
    /// Atualiza os dados do cliente
    /// </summary>
    /// <param name="client">item a ser atualizado</param>
    int PutClient(Client client);
    /// <summary>
    /// Remove o cliente de acordo com o CPF
    /// </summary>
    /// <param name="cpf"></param>
    int DeleteClient(string cpf);
  }
}
