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
  public class AppClienteService : AppServiceBase<Cliente>, IClienteAppService
  {
    private readonly IClienteService _clienteService;

    public AppClienteService(IClienteService clienteService)
      : base(clienteService)
    {
      _clienteService = clienteService;
    }
    /// <summary>
    /// Busca os dados do cliente por CPF
    /// </summary>
    /// <param name="Cpf">CPF do cliente</param>
    /// <returns>Retorna o objeto cliente</returns>
    public Cliente ObterClientePorCpf(string Cpf)
    {
      return _clienteService.ObterClientePorCpf(Cpf);
    }
  }
}
