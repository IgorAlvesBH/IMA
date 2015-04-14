using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Domain.Interfaces.Services
{
  /// <summary>
  /// Service base
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public interface IServiceBase<TEntity> where TEntity : class
  {
    /// <summary>
    /// Adicionar item
    /// </summary>
    /// <param name="obj"></param>
    void Add(TEntity obj);
    /// <summary>
    /// Retorna o item baseado no Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity GetById(int id);
    /// <summary>
    /// Retorna todos os registros do tipo especificado
    /// </summary>
    /// <returns></returns>
    IEnumerable<TEntity> GetAll();
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
    /// Descarte do objeto
    /// </summary>
    void Dispose();
  }
}
