using System.Linq;
using ListaTelefonica.CrossCuting.Factory;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;
using ListaTelefonica.Domain.Service;
using ListaTelefonica.Infrastructure.Repository;

namespace ListaTelefonica.Application
{
    public class OperadoraApp
    {
        public Operadora Buscar()
        {
            using (IContextoDB context = ContextFactory.Create<IContextoDB>())
            {
                var operadoraRepository = RepositoryFactory.Create<IOperadoraRepository>(context);


                TesteService service = new TesteService();
                return service.BuscarOperadoras(context, operadoraRepository).FirstOrDefault();
            }
        }
    }
}
