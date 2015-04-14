
using System;
using System.Collections.Generic;
namespace Xpto.Domain.Entities
{
  /// <summary>
  /// Cliente
  /// </summary>
  public class Cliente
  {
    /// <summary>
    /// ID do cliente
    /// </summary>
    public int ClienteId { get; set; }
    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string Nome { get; set; }
    /// <summary>
    /// Email do cliente
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// CPF
    /// </summary>
    public string Cpf { get; set; }
    /// <summary>
    /// Coleção de viagens
    /// </summary>
    IEnumerable<Viagem> ViagemList{ get; set; }

  }
}
