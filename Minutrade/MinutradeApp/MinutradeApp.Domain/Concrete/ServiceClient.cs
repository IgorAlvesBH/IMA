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
      :base(repositoryClient)
    {
      _RepositoryClient = repositoryClient;
    }

    public int PostClient(Client client)
    {
      int result = 0;
      //Retira a máscara antes de salvar... (Caso exista)
      string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
      string replacement = "";
      Regex rgx = new Regex(pattern);
      client.CellPhone = rgx.Replace(client.CellPhone, replacement);
      client.Phone = rgx.Replace(client.Phone, replacement);
      client.Cpf = rgx.Replace(client.Cpf, replacement);
      if (IsClientValid(client))
      {
        result = _RepositoryClient.Add(client);        
      }

      return result;
    }

    public bool IsClientValid(Client client)
    {
      //Valida se é um CPF válido
      if (IsCpfValid(client.Cpf))
      {
        if (client.Adress == null)
        {
          return false;
        }

        if (client.Adress.Street == null)
        {
          return false;
        }

        if (client.Adress.Complement == null)
        {
          return false;
        }

        if (client.Email == null)
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
      string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
      string replacement = "";
      Regex rgx = new Regex(pattern);
      client.CellPhone = rgx.Replace(client.CellPhone, replacement);
      client.Phone = rgx.Replace(client.Phone, replacement);
      client.Cpf = rgx.Replace(client.Cpf, replacement);
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
      string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
      string replacement = "";
      Regex rgx = new Regex(pattern);
      cpf = rgx.Replace(cpf, replacement);
      Client client = _RepositoryClient.SearchFor(cli => cli.Cpf == cpf).FirstOrDefault();
      int result = 0;
      if (client != null)
      {
        result = _RepositoryClient.Remove(client);
      }
      return result;
    }
  }
}
