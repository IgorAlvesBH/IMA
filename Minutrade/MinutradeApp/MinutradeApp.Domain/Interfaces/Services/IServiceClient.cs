using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Domain.Interfaces.Services
{
  /// <summary>
  /// Serviços
  /// </summary>
  public interface IServiceClient : IServiceBase<Client>
  {
    /// <summary>
    /// Valida se o CPF é válido
    /// </summary>
    /// <param name="cpf">Cpf a ser validado</param>
    bool IsCpfValid(string cpf);
    /// <summary>
    /// Salva um novo cliente e retorna se foi gravado com sucesso.
    /// </summary>
    int PostClient(Client client);
    /// <summary>
    /// Valida se o objeto é válido
    /// </summary>
    /// <param name="client">objeto a ser validado</param>
    bool IsClientValid(Client client);
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
    /// <summary>
    /// Valida se todos os campos do endereço estão preenchidos
    /// </summary>
    /// <param name="adress">objeto a ser validado</param>
    /// <returns>Retorna verdadeiro se todos os campos estiverem preenchidos</returns>
    bool IsAdressValid(Adress adress);
  }
}
