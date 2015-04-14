[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Xpto.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Xpto.App_Start.NinjectWebCommon), "Stop")]

namespace Xpto.App_Start
{
  using System;
  using System.Web;

  using Microsoft.Web.Infrastructure.DynamicModuleHelper;

  using Ninject;
  using Ninject.Web.Common;
  using Xpto.Application.Interface;
  using Xpto.Application;
  using XptoApplication.Interface;
  using XptoApplication;
  using Xpto.Domain.Interfaces.Services;
  using Xpto.Domain.Services;
  using Xpto.Domain.Interfaces.Repositories;
  using Xpto.Infra.Data.Repositories;

  public static class NinjectWebCommon
  {
    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

    /// <summary>
    /// Starts the application
    /// </summary>
    public static void Start()
    {
      DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
      DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
      bootstrapper.Initialize(CreateKernel);
    }

    /// <summary>
    /// Stops the application.
    /// </summary>
    public static void Stop()
    {
      bootstrapper.ShutDown();
    }

    /// <summary>
    /// Creates the kernel that will manage your application.
    /// </summary>
    /// <returns>The created kernel.</returns>
    private static IKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      try
      {
        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

        RegisterServices(kernel);
        return kernel;
      }
      catch
      {
        kernel.Dispose();
        throw;
      }
    }

    /// <summary>
    /// Load your modules or register your services here!
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    private static void RegisterServices(IKernel kernel)
    {
      //Efetuando a ligação dos objetos para que o controller consiga saber a origem do tipo de injeção dos objetos nos seus construtores com parâmetros
      kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
      kernel.Bind<IClienteAppService>().To<AppClienteService>();
      kernel.Bind<IDestinoAppService>().To<AppDestinoService>();
      kernel.Bind<IViagemAppService>().To<AppViagemService>();

      kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
      kernel.Bind<IClienteService>().To<ClienteService>();
      kernel.Bind<IDestinoService>().To<DestinoService>();
      kernel.Bind<IViagemService>().To<ViagemService>();
      // Não é recomendado a camada MVC conhecer diretamente a camada de acesso a base, o ideal é ser criado um módulo de acesso;
      kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
      kernel.Bind<IClienteRepository>().To<ClienteRepository>();
      kernel.Bind<IDestinoRepository>().To<DestinoRepository>();
      kernel.Bind<IViagemRepository>().To<ViagemRepository>();
    }
  }
}
