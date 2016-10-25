using MinutradeApp.Domain.Entities;
using MinutradeApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinutradeApp.Data.Context;

namespace MinutradeApp.Data.Repositories
{
  /// <summary>
  /// Repositório das entidades
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public class SqlRepository<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : EntityBase
  {
    /// <summary>
    /// Acesso aos dados
    /// </summary>
    public SqlDbContext Db
    {
      get
      {
        if (_Db == null)
        {
          _Db = new SqlDbContext();
        }
        return _Db;
      }
    }
    private SqlDbContext _Db = null;
    /// <summary>
    /// Adiciona item
    /// </summary>
    /// <param name="obj"></param>
    public int Add(TEntity obj)
    {
      obj.Id = Guid.NewGuid();
      Db.Entry(obj).State = System.Data.Entity.EntityState.Added;
      return Db.SaveChanges();
    }
    /// <summary>
    /// Busca todos os registros
    /// </summary>
    /// <returns>Retorna os registros de acordo com o objeto</returns>
    public List<TEntity> GetAll()
    {
      return Db.Set<TEntity>().ToList();
    }
    /// <summary>
    /// Busca a entidade baseada em seu ID
    /// </summary>
    /// <param name="id">Identificador da entidade</param>
    /// <returns>Retorna o objeto de acordo com o campo chave</returns>
    public TEntity GetById(int id)
    {
      return Db.Set<TEntity>().Find(id);
    }
    /// <summary>
    /// Deleta o item
    /// </summary>
    /// <param name="obj">Item a ser removido</param>
    public int Remove(TEntity obj)
    {
      Db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
      return Db.SaveChanges();
    }
    /// <summary>
    /// Busca os registros de acordo com o filtro
    /// </summary>
    /// <param name="predicate">Filtro das informações</param>
    /// <returns>Retorna as informações de acordo com o filtro criado</returns>
    public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
    {
      return GetAll().Where(predicate.Compile()).ToList();
    }
    /// <summary>
    /// Atualiza o valor da entidade
    /// </summary>
    /// <param name="obj">Item a ser atualizado</param>
    public int Update(TEntity obj)
    {
      Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
      return Db.SaveChanges();
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
      if (_Db != null)
      {
        _Db.Dispose();
      }
    }
  }
}
