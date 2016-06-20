using System;
using System.Collections.Generic;
using System.Linq;
using ListaTelefonica.API.Models;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Extensions.Models
{
    public static class ContatoExtension
    {
        public static Contato ToDomain(this ContatoModel model)
        {
            return new Contato()
            {
                Identificador = model.Identificador,
                Nome = model.Nome,
                Telefone = model.Telefone.ToDomain(),
                Cor = model.Cor,
                DataInclusao = DateTime.Now
            };
        }

        public static ContatoModel ToModel(this Contato domain)
        {
            return new ContatoModel()
            {
                Identificador = domain.Identificador,
                Nome = domain.Nome,
                Telefone = domain.Telefone.ToModel(),
                Cor = domain.Cor,
                DataInclusao = domain.DataInclusao
            };
        }

        public static IList<Contato> ToDomain(this IList<ContatoModel> model)
        {
            return model.Select(m => m.ToDomain()).ToList();
        }

        public static IList<ContatoModel> ToModel(this IList<Contato> domain)
        {
            return domain.Select(d => d.ToModel()).ToList();
        }
    }
}