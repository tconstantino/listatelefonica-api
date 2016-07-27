using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(IContextoDB contextoDB) : base(contextoDB) { }
        
        public void ExcluirComTelefoneDependente(Contato contato)
        {
            this.ContextoDB.Excluir<Telefone>(contato.Telefone);
            this.Excluir(contato);
        }
    }
}
