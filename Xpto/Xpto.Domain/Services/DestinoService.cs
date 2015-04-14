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
  public class DestinoService : ServiceBase<Destino>, IDestinoService
  {
    private readonly IDestinoRepository _DestinoRepository;

    public DestinoService(IDestinoRepository destinoRepository)
      :base(destinoRepository)
    {
      _DestinoRepository = destinoRepository;
    }
  }
}
