using ListaTelefonica.CrossCuting.DependencyInjection;
using ListaTelefonica.Domain.Repository;
using Microsoft.Practices.Unity;

namespace ListaTelefonica.CrossCuting.Factory
{
    public class RepositoryFactory
    {
        public static T Create<T> (IContextoDB contextoDB)
        {
            return ContainerDI.Resolve<T>(new ParameterOverride("contextoDB", contextoDB));
        }
    }
}
