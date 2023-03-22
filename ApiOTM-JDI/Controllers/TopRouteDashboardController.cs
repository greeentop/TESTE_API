using ApiOTM.Models;
using LibraryEntityData;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiOTM.Controllers
{
    [RoutePrefix("api")]
    public class TopRouteDashboardController : ApiController
    {


        private readonly IRoteirizacaoRepositorio _troteirizacaoRepositorio;

        public TopRouteDashboardController()
        {
            _troteirizacaoRepositorio = new RoteirizacaoRepositorio();
        }

        

        [HttpGet]
        [Route("detalhes/dashboard/{id}")]
        public TopRouteDashboard GetRoteirizacaoDashboard(int id)
        {
            var dashboard = _troteirizacaoRepositorio.getRoteirizacaoDashboard(id);

            if (dashboard  == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return dashboard;
        }

    }
}
