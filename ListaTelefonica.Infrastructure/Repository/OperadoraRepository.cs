﻿using System;
using System.Collections.Generic;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Domain.Repository;

namespace ListaTelefonica.Infrastructure.Repository
{
    public class OperadoraRepository : IOperadoraRepository
    {
        public void Editar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public Operadora ObterPeloID()
        {
            return new Operadora();
        }

        public IList<Operadora> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
