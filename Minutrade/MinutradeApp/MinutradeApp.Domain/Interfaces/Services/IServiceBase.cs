using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Domain.Interfaces.Services
{
  /// <summary>
  /// Service base
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public interface IServiceBase<TEntity> where TEntity : EntityBase
  {
    /// <summary>
    /// Adicionar item
    /// </summary>
    /// <param name="obj"></param>
    void Add(TEntity obj);
    /// <summary>
    /// Busca todos os registros
    /// </summary>
    /// <returns>Retorna todos os registros</returns>
    List<TEntity> GetAll();    
    /// <summary>
    /// Atualiza o objeto de acordo com o item
    /// </summary>
    /// <param name="obj"></param>
    void Update(TEntity obj);
    /// <summary>
    /// Remove o item
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
