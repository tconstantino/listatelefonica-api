using System;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Domain.Repository
{
    public interface IOperadoraRepository : IRepository<Operadora>
    {
        Boolean OperadoraPossuiTelefones(Int64 idOperadora);
    }
}
