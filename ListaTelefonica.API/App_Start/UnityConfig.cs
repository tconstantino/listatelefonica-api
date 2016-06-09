using System.Web.Mvc;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Infrastructure.Repository;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace ListaTelefonica.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
                        
            container.RegisterType<IContatoRepository, ContatoRepository>();
            container.RegisterType<IOperadoraRepository, OperadoraRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}