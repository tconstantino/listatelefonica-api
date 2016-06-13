using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public class OperadoraRepository : BaseRepository<Operadora>, IOperadoraRepository
    {
        public OperadoraRepository(IContextoDB contextoDB) : base(contextoDB) { }
    }
}
