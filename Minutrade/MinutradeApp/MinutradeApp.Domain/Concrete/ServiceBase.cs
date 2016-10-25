using MinutradeApp.Domain.Entities;
using MinutradeApp.Domain.Interfaces.Repositories;
using MinutradeApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Domain.Concrete
{
  public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : EntityBase
  {
    private readonly IRepositoryBase<TEntity> _Repository;
    /// <summary>
    /// Propriedade para escrever log do serviço
    /// </summary>
    public StringBuilder LogServer { get; set; }
    /// <summary>
    /// Injeção de dependência, onde no constructor é passado o tipo do objeto desejado
    /// </summary>
    /// <param name="repository"></param>
    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
      _Repository = repository;
      LogServer = new StringBuilder();
    }
    public void Add(TEntity obj)
    {
      _Repository.Add(obj);
    }

    public List<TEntity> GetAll()
    {
      return _Repository.GetAll();
    }

    public void Update(TEntity obj)
    {
      _Repository.Update(obj);
    }

    public void Remove(TEntity obj)
    {
      _Repository.Remove(obj);
    }

    public void Dispose()
    {
      _Repository.Dispose();
    }

    public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
    {
      return _Repository.GetAll().Where(predicate.Compile()).ToList();
    }
  }
}
