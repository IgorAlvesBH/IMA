using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Application.Interface;
using Xpto.Domain.Entities;

namespace XptoApplication.Interface
{
  public interface IViagemAppService : IAppServiceBase<Viagem>
  {
    /// <summary>
    /// Valida se a viagem está ou não pendente de atualização
    /// </summary>
    /// <param name="viagem">Viagem a ser analisada</param>
    /// <param name="idCliente">Cliente que precisa responder avaliação</param>
    /// <returns>Retorna verdadeiro se a avaliação está pendente de atualização</returns>
    IEnumerable<Viagem> ObterViagensPendentesAvaliacao(IEnumerable<Viagem> viagemList, int? idCliente);
    /// <summary>
    /// Busca as viagens que já foram avaliadas
    /// </summary>
    /// <param name="viagemList">Viagens a serem analisadas</param>
    /// <param name="idCliente">Cliente</param>
    /// <returns></returns>
    IEnumerable<Viagem> ObterViagensAvaliadas(IEnumerable<Viagem> viagemList, int? idCliente);
  }
}
