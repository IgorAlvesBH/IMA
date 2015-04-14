using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xpto.ViewModel
{
  /// <summary>
  /// ViewModel Destino
  /// </summary>
  public class DestinoViewModel
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int IdDestino { get; set; }
    /// <summary>
    /// Nome do local
    /// </summary>
    [Required(ErrorMessage = "Preencha o campo Nome")]
    [MaxLength(100, ErrorMessage = "Valor máximo são 100 caracteres")]
    [MinLength(2, ErrorMessage = "Valor mínimo 2 caracteres")]
    public string Nome { get; set; }
    /// <summary>
    /// Descrição do local
    /// </summary>
    [Required(ErrorMessage = "Preencha o campo descrição")]
    [MaxLength(100, ErrorMessage = "Valor máximo são 100 caracteres")]
    [MinLength(2, ErrorMessage = "Valor mínimo 2 caracteres")]
    public string Descricao { get; set; }
  }
}