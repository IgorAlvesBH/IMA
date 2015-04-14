using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Domain.Entities
{
  /// <summary>
  /// Viagem
  /// </summary>
  public class Viagem
  {
    /// <summary>
    /// Id
    /// </summary>
    public int IdViagem { get; set; }
    /// <summary>
    /// Destino da viagem
    /// </summary>
    public virtual Destino Destino { get; set; }
    /// <summary>
    /// Cliente
    /// </summary>
    public virtual Cliente Cliente { get; set; }
    /// <summary>
    /// Avaliação do destino na viagem
    /// </summary>
    public AvaliacaoViagemEnum Avaliacao { get; set; }
    /// <summary>
    /// Data de início da viagem
    /// </summary>
    public DateTime DataInicio { get; set; }
    /// <summary>
    /// Data fim da viagem
    /// </summary>
    public DateTime DataFim { get; set; }
    /// <summary>
    /// Id do cliente
    /// </summary>
    public int IdCliente { get; set; }
    /// <summary>
    /// Id do destino
    /// </summary>
    public int IdDestino { get; set; }
    /// <summary>
    /// Valida se a viagem está ou não pendente de avaliação
    /// </summary>
    /// <param name="viagem">Viagem a ser analisada</param>
    /// <param name="idCliente">Cliente que precisa responder avaliação</param>
    /// <returns>Retorna verdadeiro se a avaliação está pendente de atualização</returns>
    public bool ViagemPendenteAvaliacao(Viagem viagem, int? idCliente)
    {
      if (idCliente == null)
      {
        return (viagem.Avaliacao == AvaliacaoViagemEnum.Pendente);
      }
      return (viagem.Avaliacao == AvaliacaoViagemEnum.Pendente && viagem.IdCliente == idCliente.Value);
    }
    /// <summary>
    /// Valida se a viagem já foi avaliada
    /// </summary>
    /// <param name="viagem">Viagem</param>
    /// <param name="idCliente">Cliente</param>
    /// <returns>Retorna verdadeiro ou falso se a viagem foi avaliada</returns>
    public bool ViagemAvaliacaoRealizada(Viagem viagem, int? idCliente)
    {
      if (idCliente == null)
      {
        return (viagem.Avaliacao != AvaliacaoViagemEnum.Pendente);
      }
      return (viagem.Avaliacao != AvaliacaoViagemEnum.Pendente && viagem.IdCliente == idCliente);
    }
  }
  /// <summary>
  /// Avaliação da viagem
  /// </summary>
  public enum AvaliacaoViagemEnum
  {
    MuitoRuim = 0,
    Ruim = 1,
    Regular = 2,
    Bom = 3,
    Muitobom = 4,
    Excelente = 5,
    Pendente = 6
  };
}
