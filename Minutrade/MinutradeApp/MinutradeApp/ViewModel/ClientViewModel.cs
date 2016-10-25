using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace MinutradeApp.ViewModel
{
  /// <summary>
  /// ViewModel com os dados de cliente
  /// </summary>  
  public class ClientViewModel
  {
    public ClientViewModel()
    {

    }
    /// <summary>
    /// Constructor - Já mapeia o objeto para a view Model
    /// </summary>
    /// <param name="obj"></param>
    public ClientViewModel(Client obj)
    {
      if (obj == null)
      {
        return;
      }
      ClientId = obj.Id.ToString();
      Name = obj.Name;
      Cpf = obj.Cpf;//obj.Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
      Email = obj.Email;
      MaritalStatus = obj.MaritalStatus;
      AdressId = obj.AdressId.ToString();
      Country = obj.Adress.Country;
      State = obj.Adress.State;
      City = obj.Adress.City;
      District = obj.Adress.District;
      Street = obj.Adress.Street;
      Number = obj.Adress.Number;
      Complement = obj.Adress.Complement;
      ZipCode = obj.Adress.ZipCode;
      Phone = obj.Phone;
      CellPhone = obj.CellPhone;  
    }
    /// <summary>
    /// Id do obj Cliente
    /// </summary>
    public string ClientId { get; set; }
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
    /// Id do obj endereço
    /// </summary>
    public string AdressId { get; set; }
    /// <summary>
    /// País
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Estado
    /// </summary>
    public string State { get; set; }
    /// <summary>
    /// Cidade
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Distrito/Bairro
    /// </summary>
    public string District { get; set; }
    /// <summary>
    /// Logradouro
    /// </summary>
    public string Street { get; set; }
    /// <summary>
    /// Número
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// Complemento
    /// </summary>
    public string Complement { get; set; }
    /// <summary>
    /// CEP
    /// </summary>
    public string ZipCode { get; set; }
    /// <summary>
    /// Telefone fixo
    /// </summary>
    public string Phone { get; set;}
    /// <summary>
    /// Telefone celular
    /// </summary>
    public string CellPhone { get; set; }
  }
}