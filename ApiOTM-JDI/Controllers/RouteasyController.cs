using Routeasy.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routeasy.Controllers
{

    [RoutePrefix("Routeasy")]
    public class RouteasyController : ApiController
    {


        private readonly IRoteirizacaoRepositorio_Routeasy _troteirizacaoRepositorioRouteasy;

        public RouteasyController()
        {
            _troteirizacaoRepositorioRouteasy = new RoteirizacaoRepositorio();
        }


        //tb_integracao_routeasy_tmp
        [HttpPost]
        [Route("deliveries")] 

        // Caution: Will not work!    okdsjghwAH ÇOIRHLKJFDXDZV JÇL43   UVÇLJ421 HYFXZJBV7YV]\S7BU98Eoiwqjnhiu toitherq87 
        //public HttpResponseMessage Post([FromBody] int id, [FromBody] string name) { ... }
        //public HttpResponseMessage deliveriesReturn( [FromBody] mainRetorno jsonRetorno  )
        public HttpResponseMessage deliveriesReturn([FromBody]object jsonRetorno)
        {
            bool resultado = false;
            //var docs ;    
            try
            {

                //JsonConversao jsonconv = new JsonConversao();
                //object json = jsonconv.ConverteObjectParaJSon(jsonRetorno).Replace("\"", "");

                var docs = _troteirizacaoRepositorioRouteasy.deliveriesReturn(jsonRetorno);
                resultado = docs;

                clsRet ret = new clsRet();


                if (resultado == true)
                {
                    ret.retorno = HttpStatusCode.OK.ToString();
                }
                
                

                return Request.CreateResponse(HttpStatusCode.OK, ret);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //SP_RETORNO_JSON_ROTEIRIZACAO_ROUTEASY
        [HttpPost]
        [Route("deliveries/process")] 

        // Caution: Will not work!    okdsjghwAH ÇOIRHLKJFDXDZV JÇL43   UVÇLJ421 HYFXZJBV7YV]\S7BU98Eoiwqjnhiu toitherq87 
        //public HttpResponseMessage Post([FromBody] int id, [FromBody] string name) { ... }
        //public HttpResponseMessage deliveriesReturn( [FromBody] mainRetorno jsonRetorno  )
        public HttpResponseMessage deliveriesReturnProcess([FromBody]object jsonRetorno)
        {
            bool resultado = false;
            //var docs ;    
            try
            {

                //JsonConversao jsonconv = new JsonConversao();
                //object json = jsonconv.ConverteObjectParaJSon(jsonRetorno).Replace("\"", "");

                var docs = _troteirizacaoRepositorioRouteasy.deliveriesReturnProcess(jsonRetorno);
                resultado = docs;

                clsRet ret = new clsRet();


                if (resultado == true)
                {
                    ret.retorno = HttpStatusCode.OK.ToString();
                }



                return Request.CreateResponse(HttpStatusCode.OK, ret);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        public class clsRet
        {
            public string retorno { get; set; }

        }

    }
}
