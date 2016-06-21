using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.API.Models;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Extensions.Models
{
    public static class CategoriaExtension
    {
        public static Telefone ToDomain(this CategoriaModel model)
        {
            if (model == null) return null;

            return new Telefone()
            {
                Identificador = model.Identificador,
                Nome = model.Nome
            };
        }

        public static CategoriaModel ToModel(this Telefone domain)
        {
            if (domain == null) return null;

            return new CategoriaModel()
            {
                Identificador = domain.Identificador,
                Nome = domain.Nome
            };
        }

        public static IList<Telefone> ToDomain(this IList<CategoriaModel> model)
        {
            if (model == null) return null;

            return model.Select(m => m.ToDomain()).ToList();
        }

        public static IList<CategoriaModel> ToModel(this IList<Telefone> domain)
        {
            if (domain == null) return null;

            return domain.Select(d => d.ToModel()).ToList();
        }
    }
}