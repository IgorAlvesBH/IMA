using Xpto.Domain.Entities;
using Xpto.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpto.Infra.Data.Repositories
{
  public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
  {
    public Cliente ObterClientePorCpf(string Cpf)
    {
      return _Db.Clientes.Where(c => c.Cpf == Cpf).First();
    }
  }
}
