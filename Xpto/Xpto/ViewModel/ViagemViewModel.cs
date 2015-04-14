using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xpto.Domain.Entities;

namespace Xpto.ViewModel
{
  public class ViagemViewModel
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int IdViagem { get; set; }
    /// <summary>
    /// Destino da viagem
    /// </summary>
    public virtual DestinoViewModel Destino { get; set; }
    /// <summary>
    /// Cliente
    /// </summary>
    public virtual ClienteViewModel Cliente { get; set; }
    /// <summary>
    /// Avaliação do destino na viagem
    /// </summary>
    public AvaliacaoViagemEnum Avaliacao { get; set; }
    /// <summary>
    /// Data de início da viagem
    /// </summary>
    [Required(ErrorMessage = "Data início é obrigatória!")]
    public DateTime DataInicio { get; set; }
    /// <summary>
    /// Data fim da viagem
    /// </summary>
    [Required(ErrorMessage = "Data fim é obrigatório")]
    public DateTime DataFim { get; set; }
    /// <summary>
    /// Id do cliente
    /// </summary>
    public int IdCliente { get; set; }
    /// <summary>
    /// Id do destino
    /// </summary>
    public int IdDestino { get; set; }
  }
}