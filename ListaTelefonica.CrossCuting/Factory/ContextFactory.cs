using ListaTelefonica.CrossCuting.DependencyInjection;

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
