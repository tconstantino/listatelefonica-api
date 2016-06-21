using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ListaTelefonica.API.Controllers
{
    public class ContatoController : ApiController
    {
        // GET: api/Contato
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Contato/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contato
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contato/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contato/5
        public void Delete(int id)
        {
        }
    }
}
