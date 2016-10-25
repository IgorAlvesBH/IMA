using MinutradeApp.Domain.Entities;
using MinutradeApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MinutradeApp.Tests
{
  public class RepositoryClientTest : IRepositoryClient
  {
    /// <summary>
    /// Fake do banco de dados tendo como chave o campo string(Tratado como CPF)
    /// </summary>
    private Dictionary<string, Client> _DbContentFake;
    public RepositoryClientTest(Dictionary<string, Client> dbContentFake)
    {
      _DbContentFake = dbContentFake;
    }
    public int Add(Client obj)
    {
      _DbContentFake.Add(obj.Cpf, obj);
      return 1;
    }

    public void Dispose()
    {

    }

    public List<Client> GetAll()
    {
      return _DbContentFake.Values.ToList();
    }

    public int Remove(Client obj)
    {
      _DbContentFake.Remove(obj.Cpf);
      return 1;
    }

    public IList<Client> SearchFor(Expression<Func<Client, bool>> predicate)
    {
      return _DbContentFake.Values.Where(predicate.Compile()).ToList();
    }

    public int Update(Client obj)
    {
      Client client = _DbContentFake.Values.Where(cli => cli.Cpf == obj.Cpf).FirstOrDefault();
      if (client == null)
      {
        return 0;
      }
      client = obj;
      return 1;
    }
  }
}
