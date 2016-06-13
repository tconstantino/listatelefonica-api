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
            using (var con = new ContextoDB())
            {


                var a = con.Set<Operadora>();

                var operadoras = con.Operadora.ToList();

                var b = operadoras;
            }
        }
    }
}
