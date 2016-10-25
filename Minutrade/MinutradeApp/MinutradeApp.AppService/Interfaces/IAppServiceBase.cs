using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinutradeApp.AppService
{
  /// <summary>
  /// Interface de serviços do app
  /// </summary>
  public interface IAppServiceBase<TEntity> where TEntity : EntityBase
  {
    /// <summary>
    /// Retorna todos os itens
    /// </summary>
    /// <returns></returns>
    List<TEntity> GetAll();
    /// <summary>
    /// Remove o objeto
    /// </summary>
    /// <param name="obj"></param>
    void Remove(TEntity obj);
    /// <summary>
    /// Pesquisa com filtro
    /// </summary>
    /// <param name="predicate">Expression</param>
    /// <returns></returns>
    IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
    /// <summary>
    /// Descarte do objeto
    /// </summary>
    void Dispose();
  }
}
