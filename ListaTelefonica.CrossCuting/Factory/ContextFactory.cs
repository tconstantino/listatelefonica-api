using ListaTelefonica.CrossCuting.DependencyInjection;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.CrossCuting.Factory
{
    public class ContextFactory
    {
        private static IContextoDB ContextoDB { get; set; }
        public static IContextoDB DefaultContext { get { return ContextoDB ?? (ContextoDB = ContainerDI.Resolve<IContextoDB>()); } }

        public static T Create<T>()
        {
            if (typeof(IContextoDB) == typeof(T)) return (T)DefaultContext;

            return ContainerDI.Resolve<T>();
        }
    }
}
