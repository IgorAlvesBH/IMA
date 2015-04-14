using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Domain.Entities
{
  /// <summary>
  /// Destino
  /// </summary>
  public class Destino
  {
    /// <summary>
    /// Id
    /// </summary>
    public int IdDestino { get; set; }
    /// <summary>
    /// Nome do local
    /// </summary>
    public string Nome { get; set; }
    /// <summary>
    /// Descrição do local
    /// </summary>
    public string Descricao { get; set; }
  }
}
