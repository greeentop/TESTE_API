using LibraryEntityData;
using System.Collections.Generic;
using System;
using System.Web.Http;
using ApiRouteasy.Models;

namespace ApiOTM.Models
{

    public class RoteirizacaoRepositorio : IRoteirizacaoRepositorio
    {
        #region"DECLARCOES PRIVADA"

        private TopRouteDashboard _RoteirizacaoDdashboard;
        //private TopRoute _roteirizacao;
        private TopRouteVeiculo _Veiculo;
        private TopRouteUsuario _usuarioAutenticado;



        private List<TopRoute> _roteirizacoes_Filiais;

        private List<TopRoute> _roteirizacoes;
        private List<TopRouteItens> _Itens;
        private List<TopRouteDashboard_Manager> _dashboard_manager_ungroup;
        private List<TopRouteDashboard_Manager> _dashboard_manager_agroup;

        private List<TopRouteUtil> _rotasEnviadas;

        private TopRouteLogin _login;
        private List<TopRouteFiliaisUsuario> _FiliaisUsuario;
        private List<TopRouteDocumentosRoteirizados> _docsRouters;
        private List<TopRouteVeiculo> _veiculo;

        private List<TopRouteIntegracaoLogs> _integracaoLogs;

        private List<TopRouteVeiculo> _Veiculos;
        private List<TopRouteDetalheItensVeiculo> _ItensVeiculo;
        private List<TopRouteRotasDistribuicao> _rotas;
        //private TopRouteJobs _jobs;


        private TopRoutePickingList _picking;

        



        #endregion


        public RoteirizacaoRepositorio()
        {
            IncializaDados();
        }

        private void IncializaDados(int cod_filiais = 0)
        {

            //_roteirizacoes = DalHelper.TodasRoteirizacoes();         
        }




        #region "integracao"
        /// <summary>
        /// integracao Logs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TopRouteIntegracaoLogs> getIntegracaoLogs(string id)
        {
            _integracaoLogs = DalHelper.getIntegracaoLogs(id);
            return _integracaoLogs;
        }

        #endregion



        #region "METODOS DE ACESSO COM O BANCO DE DADOS"



        public IEnumerable<TopRoute> All
        {
            get
            {
                return _roteirizacoes;
            }
        }

        public TopRoute Find(int id)
        {
            return DalHelper.Roteirizacao(id);
        }


        public TopRoutePickingList Find1(int id, string veiculo)
        {
            return DalHelper.Roteirizacao1(id,veiculo);
        }



        public List<TopRouteItens> getRoteirizacaoItens(int id)
        {
            _Itens = DalHelper.getRoteirizacaoItens(id);
            return _Itens;
        }

        public List<TopRoute> All_Roteirizacao_Filial(int cod_filiais)
        {
            _roteirizacoes_Filiais = DalHelper.TodasRoteirizacoes_Filial(cod_filiais);
            return _roteirizacoes_Filiais;
        }

        public List<TopRouteUtil> getrotasEnviadas(int codRote, string data)
        {
            _rotasEnviadas = DalHelper.getrotasEnviadas(codRote , data);
            return _rotasEnviadas;
        }
        public List<TopRouteDashboard_Manager> dashboard_manager_ungroup(string dt_ini, string dt_fim , int cod_filial , int principal)
        {
            _dashboard_manager_ungroup = DalHelper.dashboard_manager_ungroup(dt_ini, dt_fim, cod_filial, principal);
            return _dashboard_manager_ungroup;
        }

        public List<TopRouteDashboard_Manager> dashboard_manager_agroup(string dt_ini, string dt_fim)
        {
            _dashboard_manager_agroup = DalHelper.dashboard_manager_agroup(dt_ini, dt_fim);
            return _dashboard_manager_agroup;
        }

        public TopRouteLogin get_UsuariosLogin(string login, string password)
        {
            _login = DalHelper.get_UsuariosLogin(login, password);
            return _login;
        }

        public List<TopRouteFiliaisUsuario>  get_FiliaisUsuario(int codUsuario)
        {
            _FiliaisUsuario = DalHelper.get_FiliaisUsuario(codUsuario);
            return _FiliaisUsuario;
        }


        public List<TopRouteDocumentosRoteirizados> get_DocumentoRoteirizados(string dt_inicio, string dt_final)
        {
            _docsRouters = DalHelper.get_DocumentoRoteirizados(dt_inicio, dt_final);
            return _docsRouters;
        }

        public List<TopRouteVeiculo> getTopRouteVeiculos(string veiculo)
        {
            _veiculo = DalHelper.getTopRouteVeiculos(veiculo);
            return _veiculo;
        }




        public TopRoutePickingList GetPickingList(int cod_roteirizacao, int cod__filais, string veiculo)
        {
            _picking = DalHelper.get_pickingList(cod_roteirizacao, cod__filais, veiculo);
            return _picking;
        }



        public List<TopRouteRotasDistribuicao> get_RotasDistibuicao( int cod_filiais)
        {
            _rotas = DalHelper.get_RotasDistibuicao(cod_filiais);
            return _rotas;
        }

        //public TopRouteJobs getJobManifestosDocumentos(int codRoute, int codFilial)
        //{
        //    _jobs = DalHelper.getJobManifestosDocumentos(codRoute, codFilial);
        //    return _jobs;
        //}


        public TopRouteDashboard getRoteirizacaoDashboard(int id)
        {
            _RoteirizacaoDdashboard = DalHelper.getRoteirizacaoDashboard(id);
            return _RoteirizacaoDdashboard;
        }


        public TopRouteUsuario getTopRouteUsuarioAutenticado(string login)
        {
            _usuarioAutenticado = DalHelper.getUsuarioAutenticado(login);
            return _usuarioAutenticado;
        }

        #endregion

        #region "veiculos"


        public TopRouteVeiculo get_TopRouteVeiculo (int id, int veiculo)
        {
            _Veiculo = DalHelper.get_TopRouteVeiculo(id, veiculo);
            return _Veiculo;
        }


        public List<TopRouteDetalheItensVeiculo> getTopRoute_DetalheItensVeiculo(int cod_roteirizacao , int cod_veiculo)
        {
            _ItensVeiculo = DalHelper.getRoteirizacaoItensVeiculo( cod_roteirizacao,  cod_veiculo);
            return _ItensVeiculo;
            
        }

        public List<TopRouteVeiculo> get_TopRouteVeiculos(int id)
        {
            _Veiculos = DalHelper.get_TopRouteVeiculos(id);
            return _Veiculos;
        }


        public bool put_DocFisicoReal(List<TopRouteItens> itens)
        {
            bool resultado = false;
            try
            {

                
                DalHelper.put_Documento_Fisico_Real(itens);
                resultado = true;
                

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }


        public bool put_Conferencia(int cod_roteirizacao, int cod_rota, int cod_documento, string acao,string tiporouter)
        {
            bool resultado = false;
            try
            {


                DalHelper.put_Conferencia(cod_roteirizacao, cod_rota, cod_documento, acao, tiporouter);
                resultado = true;


                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }


        

        public bool PUT_ROTA_DOC_REAL(List<TopRouteItens> servicos)
        {
            bool resultado = false;
            try
            {

                foreach (TopRouteItens item in servicos)
                {
                    DalHelper.PUT_ROTA_DOC_REAL(item);
                    resultado = true;
                }

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }


        public bool put(List<TopRouteItens> servicos)
        {
            bool resultado = false;
            try
            {

                foreach (TopRouteItens item in servicos)
                {
                    DalHelper.put_TopRouteItensVeiculos(item);
                    resultado = true;
                }

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }
        
        public bool del(List<TopRouteItens> servico)
        {
            bool resultado = false;
            try
            {

                foreach (TopRouteItens item in servico)
                {
                    DalHelper.del_TopRouteItensVeiculos(item);
                    resultado = true;
                }

                return resultado;

            }
            catch (Exception e)
            {

                string teste = e.Message;
                return resultado;

            }


        }
        
        public bool putSequencia(List<TopRouteItens> servicos)
        {
            bool resultado = false;
            try
            {


                foreach (TopRouteItens item in servicos)
                {
                    DalHelper.put_TopRouteSequencia(item);
                    resultado = true;
                }

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }

        public bool putLimparVeiculo(TopRouteVeiculo vei)
        {
            bool resultado = false;
            try
            {
                    DalHelper.put_TopRouteLimparServicosVeiculo(vei);
                    resultado = true;
   

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }


        public bool documento_baixa_routeasy(List<TopRouteDocumentosRoteirizados> documentos)
        {
            bool resultado = false;
            try
            {


                resultado = DalHelper.documento_baixa_routeasy(documentos);
                //resultado = true;

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }


        public bool putRota(List<TopRouteItens> putrota)
        {
            bool resultado = false;
            try
            {


                resultado  = DalHelper.put_TopRouteItensRota(putrota);
                //resultado = true;
            
                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }

        public bool putNaoRoteirizar(TopRouteItens putNaoRoteirizar)
        {
            bool resultado = false;
            try
            {


                DalHelper.naoRoteizarServicos(putNaoRoteirizar);
                resultado = true;

                return resultado;

            }
            catch (Exception e)
            {
                string teste = e.Message;
                return resultado;

            }


        }
        
        public bool postEnviarRouteasy(TopRouteIndividual roteirizacao)
        {
            bool resultado = false;
            try
            {

                DalHelper.post_EnviarRouteasy(roteirizacao);
                resultado = true;

                return resultado;

            }
            catch
            {
                return resultado;

            }


        }



        public bool AdicionarVeiculos(List<TopRouteVeiculo> veiculos)
        {
            bool resultado = false;
            try
            {




                foreach (TopRouteVeiculo vei in veiculos)
                {
                    DalHelper.AdicionarVeiculos(vei);
                    resultado = true;
                }


                return resultado;

            }
            catch
            {
                return resultado;

            }


        }



        public bool putEnviarOTM(TopRoute roteirizacao)
        {
            bool resultado = false;
            try
            {

                DalHelper.put_EnviarOTM(roteirizacao);
                resultado = true;

                return resultado;

            }
            catch
            {
                return resultado;

            }


        }



        //public bool salvateste([FromBody]object json)
        //{
        //    bool resultado = false;
        //    try
        //    {


        //        DalHelper.salvateste(json);
        //        resultado = true;

        //        return resultado;

        //    }
        //    catch (Exception ex)
        //    {
        //        return resultado;

        //    }


        //}




        //public bool salvaCliente (cliente cliente)
        //{
        //    bool resultado = false;
        //    try
        //    {

                
        //        DalHelper.salvarCliente(cliente);
        //        resultado = true;

        //        return resultado;

        //    }
        //    catch (Exception ex)
        //    {
        //        return resultado;

        //    }


        //}
        //public bool atualizarCliente(cliente cliente)
        //{
        //    bool resultado = false;
        //    try
        //    {


        //        DalHelper.atualizarCliente(cliente);
        //        resultado = true;

        //        return resultado;

        //    }
        //    catch
        //    {
        //        return resultado;

        //    }


        //}

        #endregion



        //public bool postRoteasy(routeasyRetorno jsonRetorno)
        //{
        //    bool resultado = false;
        //    try
        //    {


        //        DalHelper.postRetornoRouteasy(jsonRetorno);
        //        resultado = true;

        //        return resultado;

        //    }
        //    catch (Exception e)
        //    {
        //        return resultado;

        //    }


        //}



    }
    
};



namespace Routeasy.Models
{

    public class RoteirizacaoRepositorio : IRoteirizacaoRepositorio_Routeasy
    {

        public bool deliveriesReturn([FromBody]object json)
        {
            bool resultado = false;
            try
            {
                DalHelperRouteasy.salvarRetornoRouteasy(json);
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                string teste = ex.Message;
                return resultado;
            }
        }

        public bool deliveriesReturnProcess([FromBody]object json)
        {
            bool resultado = false;
            try
            {
                DalHelperRouteasy.RetornoRouteasyProcess(json);
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {


                string teste = ex.Message;

                return resultado;
            }
        }


    }

}


//};
