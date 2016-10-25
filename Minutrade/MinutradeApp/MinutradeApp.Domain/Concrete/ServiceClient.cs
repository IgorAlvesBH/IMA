using MinutradeApp.Domain.Entities;
using MinutradeApp.Domain.Interfaces.Repositories;
using MinutradeApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinutradeApp.Domain.Concrete
{
  public class ServiceClient : ServiceBase<Client>, IServiceClient
  {
    private readonly IRepositoryClient _RepositoryClient;
    public ServiceClient(IRepositoryClient repositoryClient)
      : base(repositoryClient)
    {
      _RepositoryClient = repositoryClient;
    }

    public int PostClient(Client client)
    {
      int result = 0;
      //Retira a máscara antes de salvar... (Caso exista)
      Regex.Replace(client.Cpf, "[^0-9]+", "");
      Regex.Replace(client.CellPhone, "[^0-9]+", "");
      Regex.Replace(client.Phone, "[^0-9]+", "");
      if (IsClientValid(client))
      {
        result = _RepositoryClient.Add(client);
      }

      return result;
    }
    /// <summary>
    /// É preciso que todos os itens estejam preenchidos para que seja válido.
    /// </summary>
    /// <param name="client">Objeto a ser validado</param>
    /// <returns>Retorna se é ou não válido</returns>
    public bool IsClientValid(Client client)
    {
      //Valida se é um CPF válido
      if (IsCpfValid(client.Cpf) && 
          IsAdressValid(client.Adress))
      {
        //Validando os dados do cliente
        if (client.Email == null ||
            client.Email == string.Empty ||
            !client.Email.Contains("@"))
        {
          return false;
        }

        if (client.Name == null ||
            client.Name == string.Empty)
        {
          return false;
        }

        if (client.MaritalStatus == null ||
            client.MaritalStatus == string.Empty)
        {
          return false;
        }

        if (client.Phone == null || client.CellPhone == null)
        {
          return false;
        }

        return true;
      }

      return false;
    }

    public bool IsCpfValid(string cpf)
    {
      if (cpf == null || cpf == string.Empty)
      {
        return false;
      }

      int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      string tempCpf;
      string digito;
      int soma;
      int resto;
      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;
      tempCpf = cpf.Substring(0, 9);
      soma = 0;

      for (int i = 0; i < 9; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = resto.ToString();
      tempCpf = tempCpf + digito;
      soma = 0;
      for (int i = 0; i < 10; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
      resto = soma % 11;
      if (resto < 2)
        resto = 0;
      else
        resto = 11 - resto;
      digito = digito + resto.ToString();
      return cpf.EndsWith(digito);
    }

    public int PutClient(Client client)
    {
      //Retira a máscara antes de salvar... (Caso exista)
      Regex.Replace(client.Cpf, "[^0-9]+", "");
      Regex.Replace(client.CellPhone, "[^0-9]+", "");
      Regex.Replace(client.Phone, "[^0-9]+", "");
      int result = 0;
      if (IsClientValid(client))
      {
        result = _RepositoryClient.Update(client);
      }
      return result;
    }

    public int DeleteClient(string cpf)
    {
      //Retira a máscara antes de salvar... (Caso exista)
      Regex.Replace(cpf, "[^0-9]+", "");
      Client client = _RepositoryClient.SearchFor(cli => cli.Cpf == cpf).FirstOrDefault();
      int result = 0;
      if (client != null)
      {
        result = _RepositoryClient.Remove(client);
      }
      return result;
    }

    public bool IsAdressValid(Adress adress)
    {
      if (adress == null)
      {
        return false;
      }
      //Validando propriedades de endereço        
      if (adress.Street == null ||
          adress.Street == string.Empty)
      {
        return false;
      }

      if (adress.Complement == null ||
          adress.Complement == string.Empty)
      {
        return false;
      }

      if (adress.City == null ||
          adress.City == string.Empty)
      {
        return false;
      }

      if (adress.Complement == null ||
          adress.Complement == string.Empty)
      {
        return false;
      }

      if (adress.District == null ||
          adress.District == string.Empty)
      {
        return false;
      }

      if (adress.State == null ||
          adress.State == string.Empty)
      {
        return false;
      }

      if (adress.Street == null ||
         adress.Street == string.Empty)
      {
        return false;
      }

      if (adress.Country == null ||
          adress.Country == string.Empty)
      {
        return false;
      }

      if (adress.ZipCode == null ||
          adress.ZipCode == string.Empty)
      {
        return false;
      }

      return true;
    }
  }
}
