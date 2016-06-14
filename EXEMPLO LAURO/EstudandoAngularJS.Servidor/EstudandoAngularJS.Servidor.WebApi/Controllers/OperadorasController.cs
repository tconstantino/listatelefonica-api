using EstudandoAngularJS.Servidor.WebApi.Data.Repositorio;
using System.Web.Http;
using System.Linq;
using System;
using System.Web.Http.Cors;

namespace EstudandoAngularJS.Servidor.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OperadorasController : ApiController
    {
        private readonly OperadoraRepositorio _operadoraRepositorio;
        public OperadorasController()
        {
            _operadoraRepositorio = new OperadoraRepositorio();
        }
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_operadoraRepositorio.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
