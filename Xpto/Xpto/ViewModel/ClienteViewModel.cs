using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xpto.ViewModel
{
  /// <summary>
  /// ViewModel de cliente (Não apresenta comportamento)
  /// </summary>
  public class ClienteViewModel
  {
    /// <summary>
    /// ID do cliente
    /// </summary>
    [Key]
    public int ClienteId { get; set; }
    /// <summary>
    /// Nome do cliente
    /// </summary>
    [Required(ErrorMessage = "Preencha o campo Nome")]
    [MaxLength(100, ErrorMessage = "Valor máximo são 100 caracteres")]
    [MinLength(2, ErrorMessage = "Valor mínimo 2 caracteres")]
    public string Nome { get; set; }
    /// <summary>
    /// Email do cliente
    /// </summary>
    [Required(ErrorMessage = "Preencha o campo E-mail")]
    [MaxLength(100, ErrorMessage = "Valor máximo são 100 caracteres")]
    [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
    [DisplayName("E-mail")]
    public string Email { get; set; }
    /// <summary>
    /// Cpf do cliente
    /// </summary>
    [Required(ErrorMessage = "Preencha o campo E-mail")]
    [MaxLength(14, ErrorMessage = "Valor máximo são 14 caracteres")]    
    [DisplayName("CPF")]
    public string Cpf { get; set; }
  }
}