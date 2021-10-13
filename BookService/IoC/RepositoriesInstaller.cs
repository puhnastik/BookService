using BookService.Models;
using BookService.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookService.IoC
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<BookServiceContext>().LifestylePerWebRequest());
            container.Register(Component.For<IBookRepository>().ImplementedBy<BookRepository>().LifestylePerWebRequest());
        }
    }
}