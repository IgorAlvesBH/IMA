using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpto.Domain.Entities;
using Xpto.ViewModel;
using XptoApplication.Interface;

namespace Xpto.Controllers
{
  public class ClienteController : Controller
  {
    private readonly IClienteAppService _clienteApp;
    
    public ClienteController(IClienteAppService clienteApp)
    {
      _clienteApp = clienteApp;
    }
    // GET: Cliente
    public ActionResult Index()
    {
      var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
      return View(clienteViewModel);
    }    
  }
}
