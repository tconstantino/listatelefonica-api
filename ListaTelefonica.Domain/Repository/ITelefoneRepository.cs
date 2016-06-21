using System;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Domain.Repository
{
    public interface ITelefoneRepository : IRepository<Telefone>
    {
        Boolean TelefonePossuiContato(Int64 idTelefone);
    }
}
