using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Domain.Interfaces.Services;
using Xpto.Domain.Interfaces.Repositories;

namespace Xpto.Domain.Services
{
  public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
  {
    private readonly IRepositoryBase<TEntity> _Repository;
    /// <summary>
    /// Injeção de dependência, onde no constructor é passado o tipo do objeto desejado
    /// </summary>
    /// <param name="repository"></param>
    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
      _Repository = repository;
    }
    public void Add(TEntity obj)
    {
      _Repository.Add(obj);
    }

    public TEntity GetById(int id)
    {
      return _Repository.GetById(id);
    }

    public IEnumerable<TEntity> GetAll()
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
  }
}
