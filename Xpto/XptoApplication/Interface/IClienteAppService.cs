using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Application.Interface;
using Xpto.Domain.Entities;

namespace XptoApplication.Interface
{
  public interface IClienteAppService : IAppServiceBase<Cliente>
  {
    /// <summary>
    /// Busca os dados do cliente por CPF
    /// </summary>
    /// <param name="Cpf">CPF do cliente</param>
    /// <returns>Retorna o objeto cliente</returns>
    Cliente ObterClientePorCpf(string Cpf);
  }
}
