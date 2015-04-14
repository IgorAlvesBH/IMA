using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Application;
using Xpto.Domain.Entities;
using Xpto.Domain.Interfaces.Services;
using XptoApplication.Interface;

namespace XptoApplication
{
  public class AppViagemService : AppServiceBase<Viagem>, IViagemAppService
  {
    private readonly IViagemService _ViagemService;

    public AppViagemService(IViagemService viagemService)
      : base(viagemService)
    {
      _ViagemService = viagemService;
    }
    /// <summary>
    /// Valida se a viagem está ou não pendente de atualização
    /// </summary>
    /// <param name="viagem">Viagem a ser analisada</param>
    /// <param name="idCliente">Cliente que precisa responder avaliação</param>
    /// <returns>Retorna verdadeiro se a avaliação está pendente de atualização</returns>
    public IEnumerable<Viagem> ObterViagensPendentesAvaliacao(IEnumerable<Viagem> viagemList, int? idCliente)
    {
      return _ViagemService.ObterViagensPendentesAvaliacao(viagemList, idCliente);
    }
    /// <summary>
    /// Busca as viagens que já foram avaliadas
    /// </summary>
    /// <param name="viagemList">Viagens a serem analisadas</param>
    /// <param name="idCliente">Cliente</param>
    /// <returns></returns>
    public IEnumerable<Viagem> ObterViagensAvaliadas(IEnumerable<Viagem> viagemList, int? idCliente)
    {
      return _ViagemService.ObterViagensAvaliadas(viagemList, idCliente);
    }
  }
}
