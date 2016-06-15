using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Domain.Entity;
using ListaTelefonica.Infrastructure.Repository;

namespace ListaTelefonica.Infrastructure
{
    public class Class1
    {
        public void TESTE()
        {
            using (ContextoDB contexto = new ContextoDB())
            {
                var operadoras = contexto.Set<Operadora>();
                var operadoras2 = contexto.operadoras;
                var categoria = operadoras.First().Categoria;
                var nomeDaCategoria = categoria.Nome;
            }
        }
    }
}
		
