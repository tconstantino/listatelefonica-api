using System;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Domain.Repository
{
    public interface ICategoriaRepository : IRepository<Telefone>
    {
        Boolean CategoriaPossuiOperadoras(Int64 idCategoria);
    }
}
