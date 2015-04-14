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
  public class ClienteService : ServiceBase<Cliente>, IClienteService
  {
    private readonly IClienteRepository _ClienteRepository;
    
    public ClienteService(IClienteRepository clienteRepository)
      : base(clienteRepository)
    {
      _ClienteRepository = clienteRepository;
    }
    /// <summary>
    /// Busca os dados do cliente por CPF
    /// </summary>
    /// <param name="Cpf">CPF do cliente</param>
    /// <returns>Retorna o objeto cliente</returns>
    public Cliente ObterClientePorCpf(string Cpf)
    {
      return _ClienteRepository.ObterClientePorCpf(Cpf);
    }
  }
}
