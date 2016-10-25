using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Domain.Entities
{
  /// <summary>
  /// Log do server e status
  /// </summary>
  public class ServerLog
  {
    /// <summary>
    /// Mensagens de log
    /// </summary>
    public StringBuilder MessageLog { get; set; }
    /// <summary>
    /// Status do servidor
    /// </summary>
    public StatusServerEnum StatusServer { get; set; }
  }
  /// <summary>
  /// Status
  /// </summary>
  public enum StatusServerEnum
  {
    Success = 200,
    Error = 500
  }
}
