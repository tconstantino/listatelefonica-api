using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Infrastructure.Context;
using ListaTelefonica.Infrastructure.Repository;
using Microsoft.Practices.Unity;

namespace ListaTelefonica.CrossCuting.DependencyInjection
{
    public class ContainerDI
    {
        private static IUnityContainer Container;
        private static IUnityContainer ContainerSingleton { get { return Container ?? (Container = new UnityContainer()); } }
        
        public static void RegisterElements()
        {
            ContainerSingleton.RegisterType<IContextoDB, ContextoDB>();

            ContainerSingleton.RegisterType<ICategoriaRepository, CategoriaRepository>(new InjectionConstructor(typeof(IContextoDB)));
            ContainerSingleton.RegisterType<IContatoRepository, ContatoRepository>(new InjectionConstructor(typeof(IContextoDB)));
            ContainerSingleton.RegisterType<IOperadoraRepository, OperadoraRepository>(new InjectionConstructor(typeof(IContextoDB)));
            ContainerSingleton.RegisterType<ITelefoneRepository, TelefoneRepository>(new InjectionConstructor(typeof(IContextoDB)));
        }

        public static T Resolve<T>(params ResolverOverride[] parametros)
        {
            return ContainerSingleton.Resolve<T>(parametros);
        }
    }
}
