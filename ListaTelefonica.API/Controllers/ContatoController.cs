using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ListaTelefonica.API.Extensions.Models;
using ListaTelefonica.API.Models;
using ListaTelefonica.Application;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ContatoController : ApiController
    {        
        public ContatoController()
        {
            ContatoApp = new ContatoApp();
        }

        private ContatoApp ContatoApp { get; set; }

        // GET: api/Contato
        public IList<ContatoModel> Get()
        {
            IList<Contato> contatos = ContatoApp.ObterTodos();

            return contatos.ToModel();
        }

        // GET: api/Contato/5
        public ContatoModel Get(long id)
        {
            Contato contato = ContatoApp.ObterPeloId(id);

            return contato.ToModel();
        }

        // POST: api/Contato
        public void Post(ContatoModel contato)
        {
            ContatoApp.Inserir(contato.ToDomain());
        }

        // PUT: api/Contato/5
        public void Put(ContatoModel contato)
        {
            ContatoApp.Atualizar(contato.ToDomain());
        }

        // DELETE: api/Contato/5
        public void Delete(int id, [FromBody]ContatoModel contato)
        {
            ContatoApp.Excluir(id);
        }
    }
}
