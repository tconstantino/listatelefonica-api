using ListaTelefonica.CrossCuting.DependencyInjection;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Infrastructure.Context;

namespace ListaTelefonica.CrossCuting.Factory
{
    public class ContextFactory
    {
        private static ContextoDB ContextoDB { get; set; }
        public static IContextoDB DefaultContext { get { return new ContextoDB() /*ContainerDI.Resolve<IContextoDB>())*/; } }

        public static T Create<T>()
        {
            if (typeof(IContextoDB) == typeof(T)) return (T)DefaultContext;

            return ContainerDI.Resolve<T>();
        }
    }
}
