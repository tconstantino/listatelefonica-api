using System.Collections.Generic;
using System.Web.Http;
using ListaTelefonica.API.Extensions.Models;
using ListaTelefonica.API.Models;
using ListaTelefonica.Application;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Controllers
{
    public class CategoriaController : ApiController
    {
        public CategoriaController()
        {
            CategoriaApp = new CategoriaApp();
        }

        private CategoriaApp CategoriaApp { get; set; }

        // GET: api/Categoria
        public IEnumerable<CategoriaModel> Get()
        {
            IList<Telefone> categorias = CategoriaApp.ObterTodas();

            return categorias.ToModel();
        }

        // GET: api/Categoria/5
        public CategoriaModel Get(int id)
        {
            Telefone categoria = CategoriaApp.ObterPeloId(id);

            return categoria.ToModel();
        }

        // POST: api/Categoria
        public void Post(CategoriaModel categoria)
        {
            CategoriaApp.Inserir(categoria.ToDomain());
        }

        // PUT: api/Categoria/5
        public void Put(CategoriaModel categoria)
        {
            CategoriaApp.Atualizar(categoria.ToDomain());
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
            CategoriaApp.Excluir(id);
        }
    }
}
