using System.Linq;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public class OperadoraRepository : BaseRepository<Operadora>, IOperadoraRepository
    {
        public OperadoraRepository(IContextoDB contextoDB) : base(contextoDB) { }

        public bool OperadoraPossuiTelefones(long idOperadora)
        {
            return GenericQuery<Telefone>().Where(t => t.Operadora.Identificador == idOperadora).Count() > 0;
        }
    }
}
