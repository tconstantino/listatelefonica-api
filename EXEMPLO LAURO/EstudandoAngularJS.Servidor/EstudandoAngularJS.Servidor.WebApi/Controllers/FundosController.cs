using EstudandoAngularJS.Servidor.WebApi.Data.Repositorio;
using System;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;

namespace EstudandoAngularJS.Servidor.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FundosController : ApiController
    {
        private readonly FundoRepositorio _fundoRepositorio;
        public FundosController()
        {
            _fundoRepositorio = new FundoRepositorio();
        }
        public IHttpActionResult Get()
        {
            try
            {
                var fundos = _fundoRepositorio.GetAll().ToList();
                return Ok(fundos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
