using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Domain.Entities;

namespace Xpto.Tests.Controllers
{
  [TestClass]
  public class ViagemTest
  {
    [TestMethod]
    public void ValidarViagensPendentesAvaliacao()
    {
      Viagem viagemPendente = new Viagem();      
      viagemPendente.Avaliacao = AvaliacaoViagemEnum.Pendente;
      viagemPendente.IdCliente = 1;
      viagemPendente.DataInicio = DateTime.Now.AddDays(-30).Date;
      viagemPendente.DataFim = DateTime.Now.Date;

      Viagem viagemAvaliada = new Viagem();
      viagemAvaliada.Avaliacao = AvaliacaoViagemEnum.Muitobom;
      viagemAvaliada.IdCliente = 1;
      viagemAvaliada.DataInicio = DateTime.Now.AddDays(-30).Date;
      viagemAvaliada.DataFim = DateTime.Now.Date;

      bool result = viagemPendente.ViagemPendenteAvaliacao(viagemPendente, 1);
      Assert.IsTrue(result == true);

      result = viagemAvaliada.ViagemPendenteAvaliacao(viagemAvaliada, 2);
      Assert.IsTrue(result == false);

      result = viagemAvaliada.ViagemPendenteAvaliacao(viagemAvaliada, 1);
      Assert.IsTrue(result == false);
    }
    [TestMethod]
    public void ValidarViagensAvaliadas()
    {
      Viagem viagemPendente = new Viagem();
      viagemPendente.Avaliacao = AvaliacaoViagemEnum.Muitobom;
      viagemPendente.IdCliente = 1;
      viagemPendente.DataInicio = DateTime.Now.AddDays(-30).Date;
      viagemPendente.DataFim = DateTime.Now.Date;

      Viagem viagemAvaliada = new Viagem();
      viagemAvaliada.Avaliacao = AvaliacaoViagemEnum.Muitobom;
      viagemAvaliada.IdCliente = 1;
      viagemAvaliada.DataInicio = DateTime.Now.AddDays(-30).Date;
      viagemAvaliada.DataFim = DateTime.Now.Date;      

      bool result = viagemPendente.ViagemAvaliacaoRealizada(viagemPendente, 2);
      Assert.IsTrue(result == false);

      result = viagemAvaliada.ViagemAvaliacaoRealizada(viagemAvaliada, 2);
      Assert.IsTrue(result == false);

      result = viagemAvaliada.ViagemAvaliacaoRealizada(viagemAvaliada, 1);
      Assert.IsTrue(result == true);
    }
  }
}
