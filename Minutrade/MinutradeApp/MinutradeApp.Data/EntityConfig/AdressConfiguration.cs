using MinutradeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Data.EntityConfig
{
  /// <summary>
  /// Definição das colunas da entidade Adress
  /// </summary>
  public class AdressConfiguration : EntityTypeConfiguration<Adress>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public AdressConfiguration()
    {
      HasKey(a => new { a.Id });
    }
  }
}
