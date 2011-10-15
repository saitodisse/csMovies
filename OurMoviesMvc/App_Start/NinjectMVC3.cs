using Dominio.Repositorio;
using Dominio.Servicos;
using InfraNhibernate.NHibernateHelpers;
using InfraNhibernate.Repositorios;

[assembly: WebActivator.PreApplicationStartMethod(typeof(OurMoviesMvc.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(OurMoviesMvc.App_Start.NinjectMVC3), "Stop")]

namespace OurMoviesMvc.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3  
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
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
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<SessionFactoryProvider>().ToSelf().InSingletonScope();
            kernel.Bind<SessionProvider>().ToSelf().InRequestScope();

            kernel.Bind<IBancoDadosCreator>().To<BancoDadosCreator>();

            //DAOs
            kernel.Bind<INotaDAO>().To<NotaDAO>();
            kernel.Bind<IReleaseDAO>().To<ReleaseDAO>();
            kernel.Bind<IUsuarioDAO>().To<UsuarioDAO>();
            kernel.Bind<IDownloadLinkDAO>().To<DownloadLinkDAO>();
            kernel.Bind<IFilmeDAO>().To<FilmeDAO>();
            kernel.Bind<IImdbInfoDAO>().To<ImdbInfoDAO>();
            kernel.Bind<ILegendaDAO>().To<LegendaDAO>();
            kernel.Bind<IArquivoDAO>().To<ArquivoDAO>();

            // servicos
            kernel.Bind<IFilmeServico>().To<FilmeServico>();
            kernel.Bind<IAdministradorServico>().To<AdministradorServico>();
        }        
    }
}
