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
  public class AppDestinoService : AppServiceBase<Destino>, IDestinoAppService
  {
    private readonly IDestinoService _DestinoService;

    public AppDestinoService(IDestinoService destinoService)
      : base(destinoService)
    {
      _DestinoService = destinoService;
    }
  }
}
