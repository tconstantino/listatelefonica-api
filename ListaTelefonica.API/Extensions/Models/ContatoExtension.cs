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
            if (model == null) return null;

            return new Contato()
            {
                Identificador = model.Identificador,
                Nome = model.Nome,
                Telefone = model.Telefone.ToDomain(),
                Cor = model.Cor,
                DataInclusao = DateTime.Now,
                Serial = model.Serial,
                DataNascimento = model.DataNascimento,
                CPF = model.CPF,
                CNPJ = model.CNPJ,
                CEP = model.CEP
            };
        }

        public static ContatoModel ToModel(this Contato domain)
        {
            if (domain == null) return null;

            return new ContatoModel()
            {
                Identificador = domain.Identificador,
                Nome = domain.Nome,
                Telefone = domain.Telefone.ToModel(),
                Cor = domain.Cor,
                DataInclusao = domain.DataInclusao,
                Serial = domain.Serial,
                DataNascimento = domain.DataNascimento,
                CPF = domain.CPF,
                CNPJ = domain.CNPJ,
                CEP = domain.CEP
            };
        }

        public static IList<Contato> ToDomain(this IList<ContatoModel> model)
        {
            if (model == null) return null;

            return model.Select(m => m.ToDomain()).ToList();
        }

        public static IList<ContatoModel> ToModel(this IList<Contato> domain)
        {
            if (domain == null) return null;

            return domain.Select(d => d.ToModel()).ToList();
        }
    }
}