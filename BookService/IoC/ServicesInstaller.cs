using BookService.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookService.IoC
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBookService>().ImplementedBy<Services.BookService>().LifestyleTransient());
            container.Register(Component.For<IMappingService>().ImplementedBy<MappingService>().LifestyleTransient());
        }
    }
}