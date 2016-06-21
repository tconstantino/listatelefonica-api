using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.API.Models;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Extensions.Models
{
    public static class OperadoraExtension
    {
        public static Operadora ToDomain(this OperadoraModel model)
        {
            if (model == null) return null;

            return new Operadora()
            {
                Identificador = model.Identificador,
                Codigo = model.Codigo,
                Nome = model.Nome,
                Categoria = model.Categoria.ToDomain(),
                Preco = model.Preco                
            };
        }

        public static OperadoraModel ToModel(this Operadora domain)
        {
            if (domain == null) return null;

            return new OperadoraModel()
            {
                Identificador = domain.Identificador,
                Codigo = domain.Codigo,
                Nome = domain.Nome,
                Categoria = domain.Categoria.ToModel(),
                Preco = domain.Preco
            };
        }

        public static IList<Operadora> ToDomain(this IList<OperadoraModel> model)
        {
            if (model == null) return null;

            return model.Select(m => m.ToDomain()).ToList();
        }

        public static IList<OperadoraModel> ToModel(this IList<Operadora> domain)
        {
            if (domain == null) return null;

            return domain.Select(d => d.ToModel()).ToList();
        }
    }
}