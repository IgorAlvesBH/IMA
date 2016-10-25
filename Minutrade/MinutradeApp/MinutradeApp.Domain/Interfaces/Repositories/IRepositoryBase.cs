using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinutradeApp.Domain.Interfaces.Repositories
{
  public interface IRepositoryBase<TEntity> where TEntity : EntityBase
  {
    /// <summary>
    /// Incluir
    /// </summary>
    /// <param name="obj"></param>
    int Add(TEntity obj);
    /// <summary>
    /// Retorna todos os registros de forma.
    /// </summary>
    /// <returns></returns>
    List<TEntity> GetAll();
    /// <summary>
    /// Atualiza o objeto
    /// </summary>
    /// <param name="obj"></param>
    int Update(TEntity obj);
    /// <summary>
    /// Remover o item
    /// </summary>
    /// <param name="obj"></param>
    int Remove(TEntity obj);
    /// <summary>
    /// Descarte de objeto
    /// </summary>
    void Dispose();
    /// <summary>
    /// Pesquisa com filtro
    /// </summary>
    /// <param name="predicate">Expression</param>
    /// <returns>Retorna uma lista com os objetos filtrados</returns>
    IList<TEntity>SearchFor(Expression<Func<TEntity, bool>> predicate);
  }
}
