using ApiOTM.Models;
using LibraryEntityData;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiOTM.Controllers
{

    [RoutePrefix("api")]
    public class TopRouteController : ApiController
    {
        private readonly IRoteirizacaoRepositorio _troteirizacaoRepositorio;

        public TopRouteController()
        {
            _troteirizacaoRepositorio = new RoteirizacaoRepositorio();
        }

        [HttpGet]
        [Route("listar/dashboard-manager-ungroup/{dt_ini}/{dt_fim}/{cod_filial}/{principal}")]
        public List<TopRouteDashboard_Manager> dashboard_manager_ungroup(string dt_ini, string dt_fim, int cod_filial, int principal=0)
        {
            var dash = _troteirizacaoRepositorio.dashboard_manager_ungroup(dt_ini, dt_fim, cod_filial , principal);

            if (dash == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return dash;
        }

        [HttpGet]
        [Route("listar/dashboard-manager-agroup/{dt_ini}/{dt_fim}")]
        public List<TopRouteDashboard_Manager> dashboard_manager_agroup(string dt_ini, string dt_fim)
        {
            var dash = _troteirizacaoRepositorio.dashboard_manager_agroup(dt_ini, dt_fim);

            if (dash == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return dash;
        }



        [HttpGet]
        [Route("listar/roteirizacao/{cod_filiais}")]
        public List<TopRoute> list_Roteirizacao_Filiais(int cod_filiais)
        {
            var Rot = _troteirizacaoRepositorio.All_Roteirizacao_Filial(cod_filiais);

            if (Rot == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return Rot;
        }




        // GET: api/Produtos
        [HttpGet]
        [Route("listar/roteirizacao")]
        public IEnumerable<TopRoute> List()
        {
            return _troteirizacaoRepositorio.All;
        }

        
        [HttpGet]
        [Route("detalhes/roteirizacao/{id}")]
        public TopRoute GetRoteirizacao(int id)
        {
            var Rot = _troteirizacaoRepositorio.Find(id);

            if (Rot == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return Rot;
        }


        [HttpGet]
        [Route("detalhes/roteirizacao1/{id}/{id1}")]
        public TopRoutePickingList GetRoteirizacao1(int id,  string id1)
        {
            var Rot = _troteirizacaoRepositorio.Find1(id, id1);

            if (Rot == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return Rot;
        }





        #region"listar IntegracaoLogs"

        [HttpGet]
        [Route("listar/integracaoLogs/{id}")]
        public List<TopRouteIntegracaoLogs> getIntegracaoLogs(string id)
        {
            var docs = _troteirizacaoRepositorio.getIntegracaoLogs(id);

            if (docs == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return docs;
        }

        #endregion


    }
}