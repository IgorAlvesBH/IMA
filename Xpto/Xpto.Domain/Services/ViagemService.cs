using Xpto.Domain.Entities;
using Xpto.Domain.Interfaces.Repositories;
using Xpto.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Domain.Services
{
  /// <summary>
  /// ViagemService
  /// </summary>
  public class ViagemService : ServiceBase<Viagem>, IViagemService
  {
    private readonly IViagemRepository _ViagemRepository;
    public ViagemService(IViagemRepository viagemRepository)
      :base(viagemRepository)
    {
      _ViagemRepository = viagemRepository;
    }
    /// <summary>
    /// Valida se a viagem está ou não pendente de atualização
    /// </summary>
    /// <param name="viagem">Viagem a ser analisada</param>
    /// <param name="clienteId">Cliente que precisa responder avaliação</param>
    /// <returns>Retorna verdadeiro se a avaliação está pendente de atualização</returns>
    public IEnumerable<Viagem> ObterViagensPendentesAvaliacao(IEnumerable<Viagem> viagemList, int? clienteId)
    {
      return viagemList.Where(v => v.ViagemPendenteAvaliacao(v, clienteId));
    }
    /// <summary>
    /// Busca as viagens que já foram avaliadas
    /// </summary>
    /// <param name="viagemList">Viagens a serem analisadas</param>
    /// <param name="clienteId">Cliente</param>
    /// <returns></returns>
    public IEnumerable<Viagem> ObterViagensAvaliadas(IEnumerable<Viagem> viagemList, int? clienteId)
    {
      return viagemList.Where(v => v.ViagemAvaliacaoRealizada(v, clienteId));
    }
  }
}
