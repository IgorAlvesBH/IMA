using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Domain.Entities
{
  /// <summary>
  /// Entidade comum a todas as outras
  /// </summary>
  public class EntityBase
  {
    /// <summary>
    /// Identificador
    /// </summary>
    public Guid Id { get; set; }
  }
}
