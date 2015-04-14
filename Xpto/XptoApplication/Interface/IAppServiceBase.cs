using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Application.Interface
{
  /// <summary>
  /// Interface de serviços do app
  /// </summary>
  public interface IAppServiceBase<TEntity> where TEntity : class
  {
    /// <summary>
    /// Adicionar
    /// </summary>
    /// <param name="obj"></param>
    void Add(TEntity obj);
    /// <summary>
    /// Recupera o objeto pelo identificador
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity GetById(int id);
    /// <summary>
    /// Retorna todos os itens
    /// </summary>
    /// <returns></returns>
    IEnumerable<TEntity> GetAll();
    /// <summary>
    /// Atualiza os dados do objeto
    /// </summary>
    /// <param name="obj"></param>
    void Update(TEntity obj);
    /// <summary>
    /// Remove o objeto
    /// </summary>
    /// <param name="obj"></param>
    void Remove(TEntity obj);
    /// <summary>
    /// Descarte do objeto
    /// </summary>
    void Dispose();
  }
}
