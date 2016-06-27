using ListaTelefonica.CrossCuting.DependencyInjection;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Infrastructure.Context;

namespace ListaTelefonica.CrossCuting.Factory
{
    public class ContextFactory
    {
        public static T Create<T>()
        {
            return ContainerDI.Resolve<T>();
        }
    }
}
