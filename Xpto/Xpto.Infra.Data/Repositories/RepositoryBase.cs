using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Domain.Interfaces.Repositories;
using Xpto.Infra.Data.Context;

namespace Xpto.Infra.Data.Repositories
{
  public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
  {
    protected XptoContext _Db = new XptoContext();

    public void Add(TEntity obj)
    {
      _Db.Set<TEntity>().Add(obj);
      _Db.SaveChanges();
    }

    public TEntity GetById(int id)
    {
      return _Db.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _Db.Set<TEntity>().ToList();
    }

    public void Update(TEntity obj)
    {
      _Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
      _Db.SaveChanges();
    }

    public void Remove(TEntity obj)
    {
      _Db.Set<TEntity>().Remove(obj);
      _Db.SaveChanges();
    }

    public void Dispose()
    {
      if (_Db != null)
      {
        _Db.Dispose();
      }
      _Db = null;      
    }
  }
}
