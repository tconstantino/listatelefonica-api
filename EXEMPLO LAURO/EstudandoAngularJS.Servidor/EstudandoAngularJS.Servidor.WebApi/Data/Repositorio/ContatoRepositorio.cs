using EstudandoAngularJS.Servidor.WebApi.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace EstudandoAngularJS.Servidor.WebApi.Data.Repositorio
{
    public class ContatoRepositorio : BaseRepositorio<Contato>
    {
        public override IEnumerable<Contato> GetAll()
        {
            return _contexto.Contato
                .Include(c => c.Operadora)
                .Include(c => c.Fundo);                
        }
    }
}