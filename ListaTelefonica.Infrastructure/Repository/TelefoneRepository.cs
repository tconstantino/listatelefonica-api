using System.Linq;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(IContextoDB contextoDB) : base(contextoDB) { }

        public bool TelefonePossuiContato(long idTelefone)
        {
            return GenericQuery<Contato>().Where(c => c.Telefone.Identificador == idTelefone).Count() > 0;
        }
    }
}
