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
  public class ViagemController : Controller
  {
    private readonly IViagemAppService _ViagemApp;
    
    public ViagemController(IViagemAppService viagemApp)
    {
      _ViagemApp = viagemApp;
    }
    // GET: Histórico de todas as viagens avaliadas
    public ActionResult Index()
    {
      var viagemViewModel = Mapper.Map<IEnumerable<Viagem>, IEnumerable<ViagemViewModel>>(_ViagemApp.ObterViagensAvaliadas(_ViagemApp.GetAll().OrderBy(v => v.Avaliacao), null));
      return View(viagemViewModel);
    }

    // POST: Clientes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public ActionResult Edit(ViagemViewModel viagem)
    {
      if (ModelState.IsValid)
      {
        var viagemDomain = Mapper.Map<ViagemViewModel, Viagem>(viagem);
        _ViagemApp.Update(viagemDomain);
        return RedirectToAction("Index");
      }
      return View(viagem);

    }
    [Authorize]
    public ActionResult Edit(int id)
    {
      var viagem = _ViagemApp.GetById(id);
      var viagemViewModel = Mapper.Map<Viagem, ViagemViewModel>(viagem);
      return View(viagemViewModel);
    }
    // GET: Histórico de todas as viagens do cliente
    [Authorize]
    public ActionResult HistoricoTodasViagens()
    {
      string[] keyUser = System.Web.HttpContext.Current.User.Identity.Name.Split('-');
      int clienteId = Convert.ToInt32(keyUser[0]);
      var viagemViewModel = Mapper.Map<IEnumerable<Viagem>, IEnumerable<ViagemViewModel>>(_ViagemApp.ObterViagensAvaliadas(_ViagemApp.GetAll(), clienteId));
      return View(viagemViewModel);
    }
    //GET: Viagem avaliação pendente por cliente
    [Authorize]
    public ActionResult ListarPendentes()
    {
      string[] keyUser = System.Web.HttpContext.Current.User.Identity.Name.Split('-');

      int clienteId = Convert.ToInt32(keyUser[0]);
      var viagemViewModel = Mapper.Map<IEnumerable<Viagem>, IEnumerable<ViagemViewModel>>(_ViagemApp.ObterViagensPendentesAvaliacao(_ViagemApp.GetAll(), 1));
      return View(viagemViewModel);
    }
  }
}