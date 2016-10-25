using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MinutradeApp.Domain.Interfaces.Services;

namespace MinutradeApp.AppService.Concrete
{
  /// <summary>
  /// Services
  /// </summary>
  public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : EntityBase
  {
    /// <summary>
    /// Serviço
    /// </summary>
    private readonly IServiceBase<TEntity> _serviceBase;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="serviceBase">Serviço</param>
    public AppServiceBase(IServiceBase<TEntity> serviceBase)
    {
      _serviceBase = serviceBase;
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
      _serviceBase.Dispose();
    }
    /// <summary>
    /// Busca todos os registros
    /// </summary>
    /// <returns>Retorna todos os registros</returns>
    public List<TEntity> GetAll()
    {
      return _serviceBase.GetAll();
    }
    /// <summary>
    /// Remove o objeto
    /// </summary>
    /// <param name="obj">Objeto a ser removido</param>
    public void Remove(TEntity obj)
    {
      _serviceBase.Remove(obj);
    }
    /// <summary>
    /// Busca objetos de acordo com o filtro
    /// </summary>
    /// <param name="predicate">Filtro</param>
    /// <returns>Retorna os objetos que obedecem ao filtro</returns>
    public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
    {
      return _serviceBase.SearchFor(predicate);
    }
  }
}
