using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using ListaTelefonica.API.Extensions.Models;
using ListaTelefonica.API.Models;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TelefoneController : ApiController
    {/*
        public TelefoneController()
        {
            TelefoneApp = new TelefoneApp();
        }

        private TelefoneApp TelefoneApp { get; set; }

        // GET: api/Telefone
        public IList<TelefoneModel> Get()
        {
            IList<Telefone> telefones = TelefoneApp.ObterTodos();
            return telefones.ToModel();
        }

        // GET: api/Telefone/5
        public TelefoneModel Get(Int64 id)
        {
            Telefone telefone = TelefoneApp.ObterPeloId(id);

            return telefone.ToModel();
        }

        // POST: api/Telefone
        public void Post(TelefoneModel telefone)
        {
        }

        // PUT: api/Telefone/5
        public void Put(TelefoneModel telefone)
        {
        }

        // DELETE: api/Telefone/5
        public void Delete(Int64 id)
        {
        }
        */
    }    
}
