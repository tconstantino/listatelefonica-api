using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.API.Models;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Extensions.Models
{
    public static class TelefoneExtension
    {
        public static Telefone ToDomain(this TelefoneModel model)
        {
            return new Telefone()
            {
                Identificador = model.Identificador,
                Numero = model.Numero,
                Operadora = model.Operadora.ToDomain()                
            };
        }

        public static TelefoneModel ToModel(this Telefone domain)
        {
            return new TelefoneModel()
            {
                Identificador = domain.Identificador,
                Numero = domain.Numero,
                Operadora = domain.Operadora.ToModel()
            };
        }

        public static IList<Telefone> ToDomain(this IList<TelefoneModel> model)
        {
            return model.Select(m => m.ToDomain()).ToList();
        }

        public static IList<TelefoneModel> ToModel(this IList<Telefone> domain)
        {
            return domain.Select(d => d.ToModel()).ToList();
        }
    }
}