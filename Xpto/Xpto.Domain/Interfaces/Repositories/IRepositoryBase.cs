using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Domain.Interfaces.Repositories
{
  /// <summary>
  /// Interface para CRUD
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public interface IRepositoryBase<TEntity> where TEntity : class
  {
    /// <summary>
    /// Incluir
    /// </summary>
    /// <param name="obj"></param>
    void Add(TEntity obj);
    /// <summary>
    /// Busca o registro filtrando pelo Id
    /// </summary>
    /// <param name="id">Identificador do registro</param>
    /// <returns></returns>
    TEntity GetById(int id);
    /// <summary>
    /// Retorna todos os registros
    /// </summary>
    /// <returns></returns>
    IEnumerable<TEntity> GetAll();
    /// <summary>
    /// Atualiza o objeto
    /// </summary>
    /// <param name="obj"></param>
    void Update(TEntity obj);
    /// <summary>
    /// Remover o item
    /// </summary>
    /// <param name="obj"></param>
    void Remove(TEntity obj);
    /// <summary>
    /// Descarte de objeto
    /// </summary>
    void Dispose();
  }
}
