using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Domain.Repository
{
    public interface IContatoRepository : IRepository<Contato>
    {
        void ExcluirComTelefoneDependente(Contato contato);
    }
}
