using System;
using System.Collections.Generic;

namespace MinutradeApp.Domain.Entities
{
  /// <summary>
  /// Objeto cliente
  /// </summary>
  public class Client : EntityBase
  {    
    /// <summary>
    /// Nome
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// CPF
    /// </summary>
    public string Cpf { get; set; }
    /// <summary>
    /// E-mail
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Estado civil
    /// </summary>
    public string MaritalStatus { get; set; }
    /// <summary>
    /// Telefone fixo
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Telefone celular
    /// </summary>
    public string CellPhone { get; set; }
    /// <summary>
    /// Id do endereço referenciado
    /// </summary>
    public Guid AdressId { get; set; }
    /// <summary>
    /// Endereço
    /// </summary>
    public virtual Adress Adress { get; set; }
  }
}
