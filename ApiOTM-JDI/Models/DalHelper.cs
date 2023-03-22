using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using LibraryEntityData;



namespace ApiOTM.Models
{
    public class DalHelper
    {

        //int filiais = 200;

        protected static string getStringConexao()
        {
            //return ConfigurationManager.ConnectionStrings["conexaoProducao"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["NoteDell"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            return ConfigurationManager.ConnectionStrings["MeuContext"].ConnectionString;

        }

        #region "GET"


        #region "INTEGRACAO LOGS"

        public static List<TopRouteIntegracaoLogs> getIntegracaoLogs(string Cod_Roteirizacao)
        {

            List<TopRouteIntegracaoLogs> _logs = new List<TopRouteIntegracaoLogs>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand("exec SP_INTEGRACAO_ROUTEASY_LOGS " + Cod_Roteirizacao, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var log = new TopRouteIntegracaoLogs
                                {

                                    COD_ROTEIRIZACAO = Convert.ToString(dr["COD_ROTEIRIZACAO"]),
                                    COD_ROTEIRIZACAO_ROTA = Convert.ToString(dr["COD_ROTEIRIZACAO_ROTA"]),
                                    DT_INCLUSAO = Convert.ToString(dr["DT_INCLUSAO"]),
                                    tipo = Convert.ToString(dr["tipo"]),
                                    ERROR_NUMBER = Convert.ToString(dr["ERROR_NUMBER"]),
                                    ERROR_LINE = Convert.ToString(dr["ERROR_LINE"]),
                                    ERROR_MESSAGE = Convert.ToString(dr["ERROR_MESSAGE"])

                                };


                                _logs.Add(log);
                            }
                        }
                        return _logs;
                    }
                }

            }
        }

        #endregion


        #region "VEICULO ITENS"

        public static List<TopRouteDetalheItensVeiculo> getRoteirizacaoItensVeiculo(int codRote, int codVeiculo)
        {


            List<TopRouteDetalheItensVeiculo> _detalhesItensVeiculo = new List<TopRouteDetalheItensVeiculo>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec sp_TopRouteDetalheItensVeiculo " + codRote + "," + codVeiculo, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {
                                var docs = new TopRouteDetalheItensVeiculo();

                                docs.COD_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                docs.IDENT_VEICULOS = Convert.ToString(dr["IDENT_VEICULOS"]);
                                //docs.COD_VEICULOS = Convert.ToInt32.Parse(dr["COD_VEICULOS"]);

                                if (!dr.IsDBNull(46))
                                    docs.COD_VEICULOS = Convert.ToInt32(dr["COD_VEICULOS"]);


                                docs.DOCUMENTO = Convert.ToInt32(dr["COD_DOCUMENTO"]);
                                docs.IDENT_TIPO_DOCUMENTOS = Convert.ToString(dr["IDENT_TIPO_DOCUMENTOS"]);
                                docs.DESTINATARIO = Convert.ToString(dr["DESTINATARIO"]);
                                docs.ROTA = Convert.ToString(dr["ROTA"]) == "" ? -1 : Convert.ToInt32(dr["ROTA"]);
                                docs.CEP = Convert.ToString(dr["CEP"]) == "" ? -1 : Convert.ToInt32(dr["CEP"]);
                                docs.ENDERECO = Convert.ToString(dr["ENDERECO"]);
                                docs.BAIRRO = Convert.ToString(dr["BAIRRO"]);
                                docs.CIDADE = Convert.ToString(dr["CIDADE"]);
                                docs.QT_VOLUME = Convert.ToString(dr["QT_VOLUME"]) == "" ? 0 : Convert.ToInt32(dr["QT_VOLUME"]);
                                docs.PESO = Convert.ToString(dr["PESO"]) == "" ? 0 : Convert.ToInt32(dr["PESO"]);
                                docs.PESO_REAL = Convert.ToString(dr["PESO_REAL"]) == "" ? 0 : Convert.ToInt32(dr["PESO_REAL"]);
                                docs.VALOR = Convert.ToString(dr["VALOR"]) == "" ? 0 : Convert.ToDecimal(dr["VALOR"]);
                                docs.FRETE = Convert.ToString(dr["FRETE"]) == "" ? 0 : Convert.ToDecimal(dr["FRETE"]);
                                docs.MENSAGEM = Convert.ToString(dr["MENSAGEM"]);
                                docs.ORDEM_ENTREGA = Convert.ToString(dr["ORDEM_ENTREGA"]) == "" ? 0 : Convert.ToInt32(dr["ORDEM_ENTREGA"]);
                                docs.lat = Convert.ToString(dr["LATITUDE"]) == "" ? "" : Convert.ToString(dr["LATITUDE"]);
                                docs.lng = Convert.ToString(dr["LONGITUDE"]) == "" ? "" : Convert.ToString(dr["LONGITUDE"]);




                                _detalhesItensVeiculo.Add(docs);
                            }
                        }
                        return _detalhesItensVeiculo;
                    }
                }

            }
        }



        #endregion

        #region"VEICULOS"

        public static List<TopRouteVeiculo> get_TopRouteVeiculos(int id)
        {

            List<TopRouteVeiculo> _veiculos = new List<TopRouteVeiculo>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos " + id, con))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var veic = new TopRouteVeiculo();

                                veic.COD_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                veic.COD_VEICULOS = Convert.ToInt32(dr["COD_VEICULOS"]);
                                veic.DS_VEICULOS = dr["DS_VEICULOS"].ToString();
                                veic.IDENT_VEICULOS = dr["IDENT_VEICULOS"].ToString();
                                veic.QTD_CTRC = Convert.ToInt32(dr["QTD_CTRC"]);
                                veic.ROTA = dr["ROTA"].ToString();
                                veic.MODELO = dr["MODELO"].ToString();
                                veic.CAPACIDADE = Convert.ToInt32(dr["CAPACIDADE"]);
                                veic.NR_PLACA = dr["NR_PLACA"].ToString();
                                veic.SEQ_VIAGEM = Convert.ToInt32(dr["SEQ_VIAGEM"]);

                                if (!dr.IsDBNull(10))
                                    veic.KM_TOTAL_DISTANCE = Convert.ToInt32(dr["KM_TOTAL_DISTANCE"]);


                                if (!dr.IsDBNull(13))
                                    veic.PESOTOTAL = Convert.ToInt32(dr["PESOTOTAL"]);


                                if (!dr.IsDBNull(14))
                                    veic.OCUPACAO = Convert.ToInt32(dr["OCUPACAO"]);

                              

                                _veiculos.Add(veic);
                            }
                        }
                        return _veiculos;
                    }
                }

            }

        }

        public static TopRouteVeiculo get_TopRouteVeiculo(int id, int veiculo)
        {

            TopRouteVeiculo vei = new TopRouteVeiculo();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos " + id + "," + veiculo, con))

                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                vei.COD_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                vei.COD_VEICULOS = Convert.ToInt32(dr["COD_VEICULOS"]);
                                vei.DS_VEICULOS = dr["DS_VEICULOS"].ToString();
                                vei.IDENT_VEICULOS = dr["IDENT_VEICULOS"].ToString();
                                vei.QTD_CTRC = Convert.ToInt32(dr["QTD_CTRC"]);
                                vei.ROTA = dr["ROTA"].ToString();
                                vei.MODELO = dr["MODELO"].ToString();
                                vei.CAPACIDADE = Convert.ToInt32(dr["CAPACIDADE"]);
                                vei.NR_PLACA = dr["NR_PLACA"].ToString();
                                vei.SEQ_VIAGEM = Convert.ToInt32(dr["SEQ_VIAGEM"]);
                                vei.KM_TOTAL_DISTANCE = Convert.ToInt32(dr["KM_TOTAL_DISTANCE"]);

                            }
                        }
                        return vei;
                    }
                }

            }
        }





        #endregion

        #region "OTM"


        /// <summary>
        /// Funcao para buscar a cada 5 segundos na tela a roteirizacao com Dt_retorno Is null
        /// </summary>
        /// <param name="roteirizacao"></param>
        /// <returns></returns>
        public static TopRoute getroteirizacaoRetornoNUll(TopRoute roteirizacao)
        {



            List<TopRouteRotasDistribuicao> _rotas = new List<TopRouteRotasDistribuicao>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("select distinct COD_ROTAS_DISTRIBUICAO, DS_ROTAS_DISTRIBUICAO , KM_ROTAS_DISTRIBUICAO, IDENT_ROTAS_DISTRIBUICAO from tb_ROTAS_DISTRIBUICAO	 where COD_FILIAIS   in(2,200) and FL_ATIVA =  1", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var rota = new TopRouteRotasDistribuicao();


                                rota.COD_ROTAS_DISTRIBUICAO = Convert.ToInt32(dr["COD_ROTAS_DISTRIBUICAO"]);
                                rota.DS_ROTAS_DISTRIBUICAO = Convert.ToString(dr["DS_ROTAS_DISTRIBUICAO"]).ToString();
                                rota.KM_ROTAS_DISTRIBUICAO = Convert.ToInt32(dr["KM_ROTAS_DISTRIBUICAO"]);
                                rota.IDENT_ROTAS_DISTRIBUICAO = Convert.ToString(dr["IDENT_ROTAS_DISTRIBUICAO"]).ToString();


                                _rotas.Add(rota);
                            }
                        }
                        return roteirizacao;
                    }
                }

            }


        }




        public static List<TopRouteVeiculo> getTopRouteVeiculos(string veiculo)
        {

            List<TopRouteVeiculo> _veiculos = new List<TopRouteVeiculo>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_VEICULOS_SELECIONAR " + veiculo, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var vei = new TopRouteVeiculo();

                                vei.COD_VEICULOS    = Convert.ToInt32(dr["COD_VEICULOS"]);
                                vei.IDENT_VEICULOS  = Convert.ToString(dr["IDENT_VEICULOS"]);
                                vei.NR_PLACA        = Convert.ToString(dr["NR_PLACA"]);
                                vei.CAPACIDADE      = Convert.ToInt32(dr["CAPACIDADE"]);
                                vei.SIGLA_FILIAIS   = Convert.ToString(dr["SIGLA_FILIAIS"]);
                                vei.CLASSE_VEICULOS = Convert.ToString(dr["CLASSE_VEICULOS"]);
                                vei.DS_VEICULOS     = Convert.ToString(dr["DS_VEICULOS"]);



                                _veiculos.Add(vei);
                            }
                        }
                        return _veiculos;
                    }
                }

            }


        }





        public static List<TopRouteDocumentosRoteirizados> get_DocumentoRoteirizados(string dt_inicio , string dt_final)
        {

            List<TopRouteDocumentosRoteirizados> _docsRouter = new List<TopRouteDocumentosRoteirizados>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_DOCUMENTOS_ROTEIRIZACAOS " + dt_inicio +"," + dt_final , con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var doc = new TopRouteDocumentosRoteirizados();
                                doc.ID                          = Convert.ToInt32(dr["ID"]);
                                doc.COD_FILIAIS                 = Convert.ToInt32(dr["COD_FILIAIS"]);
                                doc.COD_ROTEIRIZACAO            = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                doc.COD_DOCUMENTOS              = Convert.ToInt32(dr["COD_DOCUMENTOS"]);
                                doc.PRIORIDADE                  = Convert.ToInt32(dr["PRIORIDADE"]);
                                doc.COD_VEICULOS                = Convert.ToInt32(dr["COD_VEICULOS"]);
                                doc.ID_DOCUMENTOS               = Convert.ToInt32(dr["ID_DOCUMENTOS"]);

                                if (!dr.IsDBNull(7))
                                {
                                    doc.COD_VIAGENS_ROTEIRIZACAO = Convert.ToInt32(dr["COD_VIAGENS_ROTEIRIZACAO"]);
                                }

                                //doc.COD_VIAGENS_ROTEIRIZACAO    = Convert.ToInt32(dr["COD_VIAGENS_ROTEIRIZACAO"]);
                                doc.ORDEM_ENTREGA               = Convert.ToInt32(dr["ORDEM_ENTREGA"]);
                                doc.TIPO_ROUTER                 = Convert.ToString(dr["TIPO_ROUTER"]);
                                doc.BAIXA                       = Convert.ToString(dr["BAIXA"]);
                                doc.TIPO_DOCUMENTOS             = Convert.ToString(dr["TIPO_DOCUMENTOS"]);

                                _docsRouter.Add(doc);
                            }
                        }
                        return _docsRouter;
                    }
                }

            }


        }



        public static List<TopRouteFiliaisUsuario> get_FiliaisUsuario(int codUsuario)
        {

            List<TopRouteFiliaisUsuario> _FiliaisUsuario = new List<TopRouteFiliaisUsuario>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_FILIAIS_USUARIO "  + codUsuario, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var filialUsuario = new TopRouteFiliaisUsuario();


                                // rot.ID = Convert.ToInt32(dr["ID"]);
                                filialUsuario.JSON_FILIAIS_USUARIO = Convert.ToString(dr["jSON_RETORNO"]);
                                

                                _FiliaisUsuario.Add(filialUsuario);
                            }
                        }
                        return _FiliaisUsuario;
                    }
                }

            }


        }




        public static TopRouteLogin get_UsuariosLogin(string login, string password)
        {

            TopRouteLogin _login = new TopRouteLogin();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                //using (SqlCommand cmd = new SqlCommand("SELECT [COD_ROTEIRIZACAO]				=	COD_ROTEIRIZACAO,[COD_FILIAIS]					=	COD_FILIAIS,[DT_EMISSAO_MANIFESTOS]		=	isnull(DT_EMISSAO_MANIFESTOS,'19000101'),[DT_INCLUSAO_ROTEIRIZACAO]		=	isnull(DT_INCLUSAO_ROTEIRIZACAO,'19000101'),[COD_INCLUSAO_USUARIOS]		=	COD_INCLUSAO_USUARIOS,[DT_SAIDA_PREVISTA_MANIFESTOS]	=	isnull(DT_SAIDA_PREVISTA_MANIFESTOS,'19000101'),[DT_LIBERACAO_USO]				=	isnull(DT_LIBERACAO_USO,'19000101')FROM TB_ROTEIRIZACAO ORDER BY COD_ROTEIRIZACAO asc", con))
                using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_ACESSO_USUARIO " + login + ","  + password, con))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                _login.JSON_LOGIN = Convert.ToString(dr["JSON_RETORNO"]);
                             

                            }
                        }
                        return _login;
                    }
                }

            }


        }



        /// <summary>
        /// Funcao para buscar a cada 5 segundos na tela a roteirizacao com Dt_retorno Is null
        /// </summary>
        /// <param name="roteirizacao"></param>
        /// <returns></returns>
        public static List<TopRouteUtil> getrotasEnviadas(int codRote, string data)
        {

            List<TopRouteUtil> _envios = new List<TopRouteUtil>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("EXEC SP_TOPROUTE_GET_ROTA_ENVIADAS_ROUTEASY " + Convert.ToString(codRote) + "," + Convert.ToString(data), con))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var routeSend = new TopRouteUtil();

                                routeSend.ID                        = Convert.ToInt32(dr["ID"]);
                                routeSend.DT_INTEGRACAO             = Convert.ToString(dr["dt_integracao"]);
                                routeSend.DATA_ENVIO                = Convert.ToString(dr["DATA_ENVIO"]);
                                routeSend.HORA_ENVIO                = Convert.ToString(dr["HORA_ENVIO"]);
                                routeSend.CODIGO_ROTEIRIZACAO       = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                routeSend.CODIGO_ROTEIRIZACAO_ROTA  = Convert.ToString(dr["COD_ROTEIRIZACAO_COD_ROTA"]);
                                routeSend.COD_ROTA                  = Convert.ToInt32(dr["COD_ROTA"]);
                                routeSend.QTD_SERVICOS_ENVIO        = Convert.ToInt32(dr["QTD_SERVICOS_ENVIO"]);

                                _envios.Add(routeSend);
                            }

                        }

                    }
                }
            }

            return _envios;

        }



        public static TopRouteDashboard getRoteirizacaoDashboard(int id)
        {

            TopRouteDashboard Dashboard = new TopRouteDashboard();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                //using (SqlCommand cmd = new SqlCommand("SELECT [COD_ROTEIRIZACAO]				=	COD_ROTEIRIZACAO,[COD_FILIAIS]					=	COD_FILIAIS,[DT_EMISSAO_MANIFESTOS]		=	isnull(DT_EMISSAO_MANIFESTOS,'19000101'),[DT_INCLUSAO_ROTEIRIZACAO]		=	isnull(DT_INCLUSAO_ROTEIRIZACAO,'19000101'),[COD_INCLUSAO_USUARIOS]		=	COD_INCLUSAO_USUARIOS,[DT_SAIDA_PREVISTA_MANIFESTOS]	=	isnull(DT_SAIDA_PREVISTA_MANIFESTOS,'19000101'),[DT_LIBERACAO_USO]				=	isnull(DT_LIBERACAO_USO,'19000101')FROM TB_ROTEIRIZACAO ORDER BY COD_ROTEIRIZACAO asc", con))
                using (SqlCommand cmd = new SqlCommand("exec sp_roterizacao " + id + ", 200" , con))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                Dashboard.ID = Convert.ToInt32(dr["ID"]);
                                Dashboard.CODIGO_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                Dashboard.CODIGO_FILIAIS = Convert.ToInt32(dr["COD_FILIAIS"]);
                                Dashboard.ENVIO_NS = dr["DT_ENVIO_NS"].ToString();
                                Dashboard.RETORNO_OTM = dr["DT_RETORNO_OTM"].ToString();

                                Dashboard.QTD_ROTAS = dr["QTD_ROTAS"].ToString();
                                Dashboard.QTD_VEICULOS = dr["QTD_VEIULOS"].ToString();
                                Dashboard.QTD_COLETAS = dr["QTD_COLETAS"].ToString();
                                Dashboard.QTD_ENTREGAS = dr["QTD_ENTREGAS"].ToString();
                                Dashboard.QTD_VIAGENS = dr["QTD_VIAGENS"].ToString();

                            }
                        }
                        return Dashboard;
                    }
                }

            }


        }



        public static List<TopRouteDashboard_Manager> dashboard_manager_agroup(string dt_ini, string dt_fim )
        {

            List<TopRouteDashboard_Manager> _Dashs = new List<TopRouteDashboard_Manager>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                //using (SqlCommand cmd = new SqlCommand("SELECT [COD_  ROTEIRIZACAO]				=	COD_ROTEIRIZACAO,[COD_FILIAIS]					=	COD_FILIAIS,[DT_EMISSAO_MANIFESTOS]		=	isnull(DT_EMISSAO_MANIFESTOS,'19000101'),[DT_INCLUSAO_ROTEIRIZACAO]		=	isnull(DT_INCLUSAO_ROTEIRIZACAO,'19000101'),[COD_INCLUSAO_USUARIOS]		=	COD_INCLUSAO_USUARIOS,[DT_SAIDA_PREVISTA_MANIFESTOS]	=	isnull(DT_SAIDA_PREVISTA_MANIFESTOS,'19000101'),[DT_LIBERACAO_USO]				=	isnull(DT_LIBERACAO_USO,'19000101')FROM TB_ROTEIRIZACAO ORDER BY COD_ROTEIRIZACAO asc", con))
                using (SqlCommand cmd = new SqlCommand("EXEC SP_TOPROUTE_DASHBORAR_MANAGER_AGROUP  " + dt_ini + "," + dt_fim , con))
                {


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var dash = new TopRouteDashboard_Manager();

                                dash.COD_FILIAIS                    = Convert.ToInt32(dr["COD_FILIAIS"]);
                                dash.NM_FILIAIS                     = dr["NM_FILIAIS"].ToString();
                                dash.COD_ROTEIRIZACAO               = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                dash.QTD_ROTEIRIZACAO               = Convert.ToInt32(dr["QTD_ROTEIRIZACAO"]);
                                dash.DATA_INICIO                    = dr["DATA_INICIO"].ToString();
                                dash.DATA_FINAL                     = dr["DATA_FINAL"].ToString();
                                dash.DATA_INCLUSAO_ROTEIRIZACAO     = dr["DATA_INCLUSAO_ROTEIRIZACAO"].ToString();
                                dash.HORA_INCLUSAO_ROTEIRIZACAO     = dr["HORA_INCLUSAO_ROTEIRIZACAO"].ToString();
                                dash.KM_TOTAL                       = Convert.ToInt32(dr["KM_TOTAL"]);
                                dash.TIPO_ROUTER                    = dr["TIPO_ROUTER"].ToString();
                                dash.QTD_MANUAL                     = Convert.ToInt32(dr["QTD_MANUAL"]);
                                dash.QTD_OPERADOR                   = Convert.ToInt32(dr["QTD_OPERADOR"]);
                                dash.QTD_ROUTEASY                   = Convert.ToInt32(dr["QTD_ROUTEASY"]);
                                dash.TOTAL_DOCUMENTOS_ROTEIRIZADOS  = Convert.ToInt32(dr["TOTAL_DOCUMENTOS_ROTEIRIZADOS"]);

                                _Dashs.Add(dash);
                            }
                        }
                        return _Dashs;
                    }
                }

            }
        }



        public static List<TopRouteDashboard_Manager> dashboard_manager_ungroup(string dt_ini, string dt_fim, int cod_filial , int principal)
        {

            List<TopRouteDashboard_Manager> _Dashs = new List<TopRouteDashboard_Manager>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("EXEC SP_TOPROUTE_DASHBORAR_MANAGER_UNGROUP  " + dt_ini + "," + dt_fim + "," + cod_filial +"," + principal , con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    { 
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var dash = new TopRouteDashboard_Manager();

                                dash.COD_FILIAIS                    = Convert.ToInt32(dr["COD_FILIAIS"]);
                                dash.NM_FILIAIS                     = dr["NM_FILIAIS"].ToString();
                                dash.COD_ROTEIRIZACAO               = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                dash.QTD_ROTEIRIZACAO               = Convert.ToInt32(dr["QTD_ROTEIRIZACAO"]);
                                dash.DATA_INICIO                    = dr["DATA_INICIO"].ToString();
                                dash.DATA_FINAL                     = dr["DATA_FINAL"].ToString();
                                dash.DATA_INCLUSAO_ROTEIRIZACAO     = dr["DATA_INCLUSAO_ROTEIRIZACAO"].ToString();
                                dash.HORA_INCLUSAO_ROTEIRIZACAO     = dr["HORA_INCLUSAO_ROTEIRIZACAO"].ToString();
                                dash.KM_TOTAL                       = Convert.ToInt32(dr["KM_TOTAL"]);
                                dash.TIPO_ROUTER                    = dr["TIPO_ROUTE"].ToString();
                                dash.QTD_MANUAL                     = Convert.ToInt32(dr["QTD_MANUAL"]);
                                dash.QTD_OPERADOR                   = Convert.ToInt32(dr["QTD_OPERADOR"]);
                                dash.QTD_ROUTEASY                   = Convert.ToInt32(dr["QTD_ROUTEASY"]);
                                dash.TOTAL_DOCUMENTOS_ROTEIRIZADOS  = Convert.ToInt32(dr["TOTAL_DOCUMENTOS_ROTEIRIZADOS"]);
                                dash.TOTAL_DOCUMENTOS_BASE          = Convert.ToInt32(dr["TOTAL_DOCUMENTOS_BASE"]);

                                _Dashs.Add(dash);
                            }
                        }
                        return _Dashs;
                    }
                }

            }
        }



        public static List<TopRoute> TodasRoteirizacoes_Filial(int cod_filiais)
        {

            List<TopRoute> _roteirizacao = new List<TopRoute>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {   

                con.Open();
                //using (SqlCommand cmd = new SqlCommand("SELECT [COD_  ROTEIRIZACAO]				=	COD_ROTEIRIZACAO,[COD_FILIAIS]					=	COD_FILIAIS,[DT_EMISSAO_MANIFESTOS]		=	isnull(DT_EMISSAO_MANIFESTOS,'19000101'),[DT_INCLUSAO_ROTEIRIZACAO]		=	isnull(DT_INCLUSAO_ROTEIRIZACAO,'19000101'),[COD_INCLUSAO_USUARIOS]		=	COD_INCLUSAO_USUARIOS,[DT_SAIDA_PREVISTA_MANIFESTOS]	=	isnull(DT_SAIDA_PREVISTA_MANIFESTOS,'19000101'),[DT_LIBERACAO_USO]				=	isnull(DT_LIBERACAO_USO,'19000101')FROM TB_ROTEIRIZACAO ORDER BY COD_ROTEIRIZACAO asc", con))
                using (SqlCommand cmd = new SqlCommand("exec sp_roterizacao 0," + cod_filiais, con))
                {


                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var rot = new TopRoute();

                                if (!dr.IsDBNull(1))
                                {
                                    rot.ID = Convert.ToInt32(dr["ID"]);

                                }

                                // rot.ID = Convert.ToInt32(dr["ID"]);
                                rot.CODIGO_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                rot.CODIGO_FILIAIS = Convert.ToInt32(dr["COD_FILIAIS"]);
                                rot.ENVIO_NS = dr["DT_ENVIO_NS"].ToString();
                                rot.RETORNO_OTM = dr["DT_RETORNO_OTM"].ToString();

                                rot.QTD_ROTAS = Convert.ToInt32(dr["QTD_ROTAS"]);
                                rot.QTD_VEICULOS = Convert.ToInt32(dr["QTD_VEIULOS"]);
                                rot.QTD_COLETAS = Convert.ToInt32(dr["QTD_COLETAS"]);
                                rot.QTD_ENTREGAS = Convert.ToInt32(dr["QTD_ENTREGAS"]);
                                rot.QTD_VIAGENS = Convert.ToInt32(dr["QTD_VIAGENS"]);
                                rot.KM_TOTAL = Convert.ToInt32(dr["KM_TOTAL"]);
                                rot.QTD_COLETAS_ENVIO = Convert.ToInt32(dr["QTD_COLETAS_ENVIO"]);
                                rot.QTD_ENTREGAS_ENVIO = Convert.ToInt32(dr["QTD_ENTREGAS_ENVIO"]);
                                rot.QTD_VEICULOS_ENVIO = Convert.ToInt32(dr["QTD_VEICULOS_ENVIO"]);


                                rot.DISTANCIA_VEICULOS_PROPRIOS = Convert.ToInt32(dr["DISTANCIA_VEICULOS_PROPRIOS"]);
                                rot.DISTANCIA_VEICULOS_AGREGRADOS = Convert.ToInt32(dr["DISTANCIA_VEICULOS_AGREGRADOS"]);
                                rot.PESO_VEICULOS_PROPRIOS = Convert.ToInt32(dr["PESO_VEICULOS_PROPRIOS"]);
                                rot.PESO_VEICULOS_AGREGRADOS = Convert.ToInt32(dr["PESO_VEICULOS_AGREGRADOS"]);
                                rot.OCUPACAO_VEICULOS_MEDIA_PROPRIOS = Convert.ToInt32(dr["OCUPACAO_VEICULOS_MEDIA_PROPRIOS"]);
                                rot.OCUPACAO_VEICULOS_MEDIA_AGREGRADOS = Convert.ToInt32(dr["OCUPACAO_VEICULOS_MEDIA_AGREGRADOS"]);
                                rot.QTD_VEICULOS_PROPRIOS = Convert.ToInt32(dr["QTD_VEICULOS_PROPRIOS"]);
                                rot.QTD_VEICULOS_AGREGADOS = Convert.ToInt32(dr["QTD_VEICULOS_AGREGADOS"]);
                                rot.DT_ROTEIRIZACAO = Convert.ToString(dr["DT_ROTEIRIZACAO"]);
                                rot.QTD_SERVICOS = Convert.ToInt32(dr["QTD_SERVICOS"]);

                                rot.QTD_SERVICOS_PROPRIOS = Convert.ToInt32(dr["QTD_SERVICOS_PROPRIOS"]);
                                rot.QTD_SERVICOS_AGREGADOS = Convert.ToInt32(dr["QTD_SERVICOS_AGREGADOS"]);
                                rot.PERCENT_SERVICOS_PROPRIOS = Convert.ToInt32(dr["PERCENT_SERVICOS_PROPRIOS"]);
                                rot.PERCENT_SERVICOS_AGREGADOS = Convert.ToInt32(dr["PERCENT_SERVICOS_AGREGADOS"]);
                                rot.PERCENT_SERVICOS_AGREGADOS = Convert.ToInt32(dr["PERCENT_SERVICOS_AGREGADOS"]);

                                rot.QTD_SERVICOS_MANUAL     = Convert.ToInt32(dr["QTD_SERVICOS_MANUAL"]);
                                rot.QTD_SERVICOS_TOPROUTE   = Convert.ToInt32(dr["QTD_SERVICOS_TOPROUTE"]);
                                rot.QTD_SERVICOS_ROUTEASY   = Convert.ToInt32(dr["QTD_SERVICOS_ROUTEASY"]);

                                rot.QTD_SERVICOS_ALL = Convert.ToInt32(dr["QTD_SERVICOS_ALL"]);

                                _roteirizacao.Add(rot);
                            }
                        }
                        return _roteirizacao;
                    }
                }

            }
        }


        public static List<TopRoute> TodasRoteirizacoes()
        {

            List<TopRoute> _roteirizacao = new List<TopRoute>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                try
                {
                    con.Open();
    
                }
                catch (Exception e)
                {

                    TopRoute topRoute = new TopRoute();  
                    Console.WriteLine(e);

                    string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                    //
                    string path2 = path.Remove(path.LastIndexOf("\\"));
                    path = path2.Remove(path2.LastIndexOf("\\") + 1);
                    path += "log";

                    System.IO.Directory.CreateDirectory(path);


                    topRoute.messageError = e.Message;
                    _roteirizacao.Add(topRoute);
                    
                    return _roteirizacao;
                } 
                
                //using (SqlCommand cmd = new SqlCommand("SELECT [COD_  ROTEIRIZACAO]				=	COD_ROTEIRIZACAO,[COD_FILIAIS]					=	COD_FILIAIS,[DT_EMISSAO_MANIFESTOS]		=	isnull(DT_EMISSAO_MANIFESTOS,'19000101'),[DT_INCLUSAO_ROTEIRIZACAO]		=	isnull(DT_INCLUSAO_ROTEIRIZACAO,'19000101'),[COD_INCLUSAO_USUARIOS]		=	COD_INCLUSAO_USUARIOS,[DT_SAIDA_PREVISTA_MANIFESTOS]	=	isnull(DT_SAIDA_PREVISTA_MANIFESTOS,'19000101'),[DT_LIBERACAO_USO]				=	isnull(DT_LIBERACAO_USO,'19000101')FROM TB_ROTEIRIZACAO ORDER BY COD_ROTEIRIZACAO asc", con))
                using (SqlCommand cmd = new SqlCommand("exec sp_roterizacao 0,200", con))
                {


                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var rot = new TopRoute();

                                if (!dr.IsDBNull(1))
                                {
                                    rot.ID = Convert.ToInt32(dr["ID"]);

                                }

                                // rot.ID = Convert.ToInt32(dr["ID"]);
                                rot.CODIGO_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                rot.CODIGO_FILIAIS = Convert.ToInt32(dr["COD_FILIAIS"]);
                                rot.ENVIO_NS = dr["DT_ENVIO_NS"].ToString();
                                rot.RETORNO_OTM = dr["DT_RETORNO_OTM"].ToString();

                                rot.QTD_ROTAS = Convert.ToInt32(dr["QTD_ROTAS"]);
                                rot.QTD_VEICULOS = Convert.ToInt32(dr["QTD_VEIULOS"]);
                                rot.QTD_COLETAS = Convert.ToInt32(dr["QTD_COLETAS"]);
                                rot.QTD_ENTREGAS = Convert.ToInt32(dr["QTD_ENTREGAS"]);
                                rot.QTD_VIAGENS = Convert.ToInt32(dr["QTD_VIAGENS"]);
                                rot.KM_TOTAL = Convert.ToInt32(dr["KM_TOTAL"]);
                                rot.QTD_COLETAS_ENVIO = Convert.ToInt32(dr["QTD_COLETAS_ENVIO"]);
                                rot.QTD_ENTREGAS_ENVIO = Convert.ToInt32(dr["QTD_ENTREGAS_ENVIO"]);
                                rot.QTD_VEICULOS_ENVIO = Convert.ToInt32(dr["QTD_VEICULOS_ENVIO"]);


                                rot.DISTANCIA_VEICULOS_PROPRIOS         = Convert.ToInt32(dr["DISTANCIA_VEICULOS_PROPRIOS"]);
                                rot.DISTANCIA_VEICULOS_AGREGRADOS       = Convert.ToInt32(dr["DISTANCIA_VEICULOS_AGREGRADOS"]);
                                rot.PESO_VEICULOS_PROPRIOS              = Convert.ToInt32(dr["PESO_VEICULOS_PROPRIOS"]);
                                rot.PESO_VEICULOS_AGREGRADOS            = Convert.ToInt32(dr["PESO_VEICULOS_AGREGRADOS"]);
                                rot.OCUPACAO_VEICULOS_MEDIA_PROPRIOS    = Convert.ToInt32(dr["OCUPACAO_VEICULOS_MEDIA_PROPRIOS"]);
                                rot.OCUPACAO_VEICULOS_MEDIA_AGREGRADOS  = Convert.ToInt32(dr["OCUPACAO_VEICULOS_MEDIA_AGREGRADOS"]);
                                rot.QTD_VEICULOS_PROPRIOS               = Convert.ToInt32(dr["QTD_VEICULOS_PROPRIOS"]);
                                rot.QTD_VEICULOS_AGREGADOS              = Convert.ToInt32(dr["QTD_VEICULOS_AGREGADOS"]);
                                rot.DT_ROTEIRIZACAO                     = Convert.ToString(dr["DT_ROTEIRIZACAO"]);
                                rot.QTD_SERVICOS                        = Convert.ToInt32(dr["QTD_SERVICOS"]);

                                rot.QTD_SERVICOS_PROPRIOS               = Convert.ToInt32(dr["QTD_SERVICOS_PROPRIOS"]);
                                rot.QTD_SERVICOS_AGREGADOS              = Convert.ToInt32(dr["QTD_SERVICOS_AGREGADOS"]);
                                rot.PERCENT_SERVICOS_PROPRIOS           = Convert.ToInt32(dr["PERCENT_SERVICOS_PROPRIOS"]);
                                rot.PERCENT_SERVICOS_AGREGADOS          = Convert.ToInt32(dr["PERCENT_SERVICOS_AGREGADOS"]);

                                rot.QTD_SERVICOS_ALL = Convert.ToInt32(dr["QTD_SERVICOS_ALL"]);

                                _roteirizacao.Add(rot);
                            }
                        }
                        return _roteirizacao;
                    }
                }

            }


        }




        public static TopRoute Roteirizacao(int id)
        {
            TopRoute rot = new TopRoute();
            
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();


                try{
                    using (SqlCommand cmd = new SqlCommand("exec sp_roterizacao " + id, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {

                                while (dr.Read())
                                {


                                    if (!dr.IsDBNull(1))
                                    {
                                        rot.ID = Convert.ToInt32(dr["ID"]);

                                    }

                                    // rot.ID = Convert.ToInt32(dr["ID"]);
                                    rot.CODIGO_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                    rot.CODIGO_FILIAIS = Convert.ToInt32(dr["COD_FILIAIS"]);
                                    rot.ENVIO_NS = dr["DT_ENVIO_NS"].ToString();
                                    rot.RETORNO_OTM = dr["DT_RETORNO_OTM"].ToString();

                                    rot.QTD_ROTAS = Convert.ToInt32(dr["QTD_ROTAS"]);
                                    rot.QTD_VEICULOS = Convert.ToInt32(dr["QTD_VEIULOS"]);
                                    rot.QTD_COLETAS = Convert.ToInt32(dr["QTD_COLETAS"]);
                                    rot.QTD_ENTREGAS = Convert.ToInt32(dr["QTD_ENTREGAS"]);
                                    rot.QTD_VIAGENS = Convert.ToInt32(dr["QTD_VIAGENS"]);
                                    rot.KM_TOTAL = Convert.ToInt32(dr["KM_TOTAL"]);
                                    rot.QTD_COLETAS_ENVIO = Convert.ToInt32(dr["QTD_COLETAS_ENVIO"]);
                                    rot.QTD_ENTREGAS_ENVIO = Convert.ToInt32(dr["QTD_ENTREGAS_ENVIO"]);
                                    rot.QTD_VEICULOS_ENVIO = Convert.ToInt32(dr["QTD_VEICULOS_ENVIO"]);



                                    //rot.CODIGO_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                    //rot.CODIGO_FILIAIS = Convert.ToInt32(dr["COD_FILIAIS"]);
                                    //roteirizacao.DATA_EMISSAO_MANIFESTOS = dr["DT_EMISSAO_MANIFESTOS"] != null ? DateTime.MinValue : Convert.ToDateTime(dr["DT_EMISSAO_MANIFESTOS"]);
                                    //roteirizacao.DATA_INCLUSAO_ROTEIRIZACAO = Convert.ToDateTime(dr["DT_INCLUSAO_ROTEIRIZACAO"]);
                                    //roteirizacao.CODIGO_INCLUSAO_USUARIOS = Convert.ToInt32(dr["COD_INCLUSAO_USUARIOS"]);
                                    //roteirizacao.DATA_SAIDA_PREVISTA_MANIFESTOS = Convert.ToDateTime(dr["DT_SAIDA_PREVISTA_MANIFESTOS"]);
                                    //roteirizacao.DATA_LIBERACAO_USO = Convert.ToDateTime(dr["DT_LIBERACAO_USO"]);
                                    //roteirizacao.DATA_SAIDA_PREVISTA_MANIFESTOS = Convert.ToDateTime(dr["DT_SAIDA_PREVISTA_MANIFESTOS"]);

                                }
                            }
                            return rot;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
                finally
                {
                    con.Close();
                }

            }

        }


        public static TopRoutePickingList Roteirizacao1(int id, string veiculo)
        {
            TopRoute rot = new TopRoute();

            TopRoutePickingList rot1 = new TopRoutePickingList();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                //buscar veiculo  (detalhes do veiculo)
                using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PICKING_LIST1 " + Convert.ToInt32(id) +"," + Convert.ToString(veiculo) +",V", con))
                {

                        
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {

                        //}
                        //if (dr != null)
                        //{

                            rot1.veiculo = new veiculo()
                            {
                                COD_ROTEIRIZACAO            = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]),
                                FILIAL                      = Convert.ToString(dr["FILIAL"]),
                                DT_EMISSAO_MANIFESTOS       = dr["DT_EMISSAO_MANIFESTOS"] != null ? DateTime.MinValue: Convert.ToDateTime(dr["DT_EMISSAO_MANIFESTOS"]),
                                DT_INCLUSAO_ROTEIRIZACAO    = dr["DT_INCLUSAO_ROTEIRIZACAO"] != null ?  Convert.ToDateTime(dr["DT_INCLUSAO_ROTEIRIZACAO"]) : DateTime.MinValue,
                                COD_VEICULOS                = Convert.ToInt32(dr["COD_VEICULOS"]),
                                IDENT_VEICULOS              = Convert.ToString(dr["IDENT_VEICULOS"]),
                                CAPACIDADE                  = Convert.ToInt32(dr["CAPACIDADE"]),

                                COD_VIAGENS_ROTEIRIZACAO = dr["COD_VIAGENS_ROTEIRIZACAO"] != null ? Convert.ToInt32(dr["COD_VIAGENS_ROTEIRIZACAO"]) : Int32.MinValue,
                                SEQ_VIAGENS_ROTEIRIZACAO = dr["SEQ_VIAGENS_ROTEIRIZACAO"] != null ? Convert.ToInt32(dr["SEQ_VIAGENS_ROTEIRIZACAO"]) : Int32.MinValue,

                                //COD_VIAGENS_ROTEIRIZACAO    = Convert.ToInt32(dr["COD_VIAGENS_ROTEIRIZACAO"]),
                                //SEQ_VIAGENS_ROTEIRIZACAO    = Convert.ToInt32(dr["SEQ_VIAGENS_ROTEIRIZACAO"])

                            };

                            dr.Close();
                            //buscar intens dentros do veiculo encontrado acima (serviços dentro do veiculo)
                            using (SqlCommand cmddoc = new SqlCommand("exec SP_TOPROUTE_PICKING_LIST1 " + id + "," + veiculo + ",D", con))
                            {

                                using (SqlDataReader drdoc = cmddoc.ExecuteReader())
                                {
                                    if (drdoc != null)
                                    {
                                        rot1.veiculo.DOCUMENTOS = new List<SERVICOS>();

                                        
                                        while (drdoc.Read())
                                        {
                                            SERVICOS doc = new SERVICOS();

                                            doc.COD_ROTEIRIZACAO    = Convert.ToInt32(drdoc["COD_ROTEIRIZACAO"]);
                                            doc.COD_VEICULOS        = Convert.ToInt32(drdoc["COD_VEICULOS"]);
                                            doc.TIPO_SERVICO        = Convert.ToString(drdoc["TIPO_SERVICO"]);
                                            doc.ORDEM               = Convert.ToInt32(drdoc["ORDEM"]);
                                            doc.COD_DOCUMENTO       = Convert.ToInt32(drdoc["COD_DOCUMENTO"]);
                                            doc.DOCUMENTO           = Convert.ToString(drdoc["DOCUMENTO"]);

                                            doc.DT_EMISSAO          = Convert.ToDateTime(drdoc["DT_EMISSAO"]);
                                            doc.COD_REMETENTE       = Convert.ToInt32(drdoc["COD_REMETENTE"]);
                                            doc.REMETENTE           = Convert.ToString(drdoc["REMETENTE"]);
                                            doc.COD_DESTINATARIO    = Convert.ToInt32(drdoc["COD_DESTINATARIO"]);
                                            doc.DESTINATARIO        = Convert.ToString(drdoc["DESTINATARIO"]);
                                            doc.ENDERECO            = Convert.ToString(drdoc["ENDERECO"]);

                                            doc.NUMERO              = Convert.ToInt32(drdoc["NUMERO"]);
                                            doc.CEP                 = Convert.ToString(drdoc["CEP"]);
                                            doc.BAIRRO              = Convert.ToString(drdoc["BAIRRO"]);
                                            doc.CIDADE              = Convert.ToString(drdoc["CIDADE"]);
                                            doc.UF                  = Convert.ToString(drdoc["UF"]);
                                            doc.COMPLEMENTO         = Convert.ToString(drdoc["COMPLEMENTO"]);


                                            doc.COD_ROTA            = Convert.ToInt32(drdoc["COD_ROTA"]);
                                            doc.QT_VOLUMES          = Convert.ToInt32(drdoc["QT_VOLUMES"]);
                                            doc.PESO_NOTA           = Convert.ToInt32(drdoc["PESO_NOTA"]);
                                            doc.PESO_CALCULO        = Convert.ToInt32(drdoc["PESO_CALCULO"]);
                                            doc.QT_RETORNOS         = Convert.ToInt32(drdoc["QT_RETORNOS"]);

                                            doc.COD_PRIORIDADE              = Convert.ToInt32(drdoc["COD_PRIORIDADE"]);
                                            doc.COD_FILIAIS = 0; //Convert.ToInt32(drdoc["COD_FILIAIS"]);
                                            doc.NOTAS                       = Convert.ToString(drdoc["NOTAS"]);
                                            doc.ID_VOLUMES                  = Convert.ToString(drdoc["ID_VOLUMES"]);
                                            doc.COD_VIAGENS_ROTEIRIZACAO    = Convert.ToInt32(drdoc["COD_VIAGENS_ROTEIRIZACAO"]);



                                            doc.SEQ_VIAGENS_ROTEIRIZACAO    = Convert.ToInt32(drdoc["SEQ_VIAGENS_ROTEIRIZACAO"]);
                                            doc.COD_UU                      = Convert.ToInt32(drdoc["COD_UU"]);
                                            doc.COD_UU_ENDERECO             = Convert.ToInt32(drdoc["COD_UU_ENDERECO"]);
                                            doc.END_ARM                     = Convert.ToString(drdoc["END_ARM"]);

                                            //1   De...Até
                                            //2   A partir de
                                            //3   Até
                                            //4   Na hora
                                            //doc.COD_AGENDAMENTOS_PERIODO    = drdoc["COD_AGENDAMENTOS_PERIODO"] != null ? null : Convert.ToInt32(drdoc["COD_AGENDAMENTOS_PERIODO"])

                                            if (!drdoc.IsDBNull(39))
                                            {
                                                doc.COD_AGENDAMENTOS_PERIODO = Convert.ToInt32(drdoc["COD_AGENDAMENTOS_PERIODO"]);

                                            }
                                            if (!drdoc.IsDBNull(33))
                                            {
                                                doc.DT_AGENDAMENTO = Convert.ToString(drdoc["DT_AGENDAMENTO"]);

                                            }
                                            if (!drdoc.IsDBNull(34))
                                            {
                                                doc.HR_AGENDAMENTO_INICIO = Convert.ToString(drdoc["HR_AGENDAMENTO_INICIO"]);

                                            }
                                            if (!drdoc.IsDBNull(35))
                                            {
                                                doc.HR_AGENDAMENTO_FIM = Convert.ToString(drdoc["HR_AGENDAMENTO_FIM"]);

                                            }
                                            if (!drdoc.IsDBNull(36))
                                            {
                                                doc.OBS_AGENDAMENTO = Convert.ToString(drdoc["OBS_AGENDAMENTO"]);

                                            }
                                            if (!drdoc.IsDBNull(37))
                                            {
                                                doc.DS_AGENDAMENTOS_PERIODO = Convert.ToString(drdoc["DS_AGENDAMENTOS_PERIODO"]);

                                            }
                                            if (!drdoc.IsDBNull(38))
                                            {
                                                doc.DS_AGENDAMENTOS_TIPO = Convert.ToString(drdoc["DS_AGENDAMENTOS_TIPO"]);

                                            }

                                            //doc.COD_AGENDAMENTOS_PERIODO    = drdoc["COD_AGENDAMENTOS_PERIODO"];    //40
                                            //doc.DT_AGENDAMENTO              = Convert.ToString(drdoc["DT_AGENDAMENTO"]);         //33
                                            //doc.HR_AGENDAMENTO_INICIO       = Convert.ToString(drdoc["HR_AGENDAMENTO_INICIO"]);    //34
                                            //doc.HR_AGENDAMENTO_FIM          = Convert.ToString(drdoc["HR_AGENDAMENTO_FIM"]);           //35
                                            //doc.OBS_AGENDAMENTO             = Convert.ToString(drdoc["OBS_AGENDAMENTO"]);              //36
                                            //doc.DS_AGENDAMENTOS_PERIODO     = Convert.ToString(drdoc["DS_AGENDAMENTOS_PERIODO"]);          //37
                                            //doc.DS_AGENDAMENTOS_TIPO        = Convert.ToString(drdoc["DS_AGENDAMENTOS_TIPO"]);            //38
                                            
                                            //doc.DT_AGENDAMENTO              = drdoc["DT_AGENDAMENTO"] != null ?  DateTime.MinValue: Convert.ToDateTime(drdoc["DT_AGENDAMENTO"])
                                            //doc.HR_AGENDAMENTO_INICIO   = drdoc["HR_AGENDAMENTO_INICIO"] != null ?  DateTime.MinValue: Convert.ToDateTime(drdoc["HR_AGENDAMENTO_INICIO"]);
                                            //doc.HR_AGENDAMENTO_FIM      = drdoc["HR_AGENDAMENTO_FIM"] != null ?  DateTime.MinValue: Convert.ToDateTime(drdoc["HR_AGENDAMENTO_FIM"]);

                                            //doc.OBS_AGENDAMENTO         = drdoc["OBS_AGENDAMENTO"] != null ?  "": Convert.ToString(drdoc["OBS_AGENDAMENTO"]);
                                            //doc.DS_AGENDAMENTOS_PERIODO = drdoc["DS_AGENDAMENTOS_PERIODO"] != null ? "": Convert.ToString(drdoc["DS_AGENDAMENTOS_PERIODO"]);
                                            //doc.DS_AGENDAMENTOS_TIPO = drdoc["DS_AGENDAMENTOS_TIPO"] != null ?  "": Convert.ToString(drdoc["DS_AGENDAMENTOS_TIPO"]);

                                            doc.VL_MERCADORIA           = Convert.ToDecimal(drdoc["VL_MERCADORIA"]);
                                            doc.UNITIZADORES            = Convert.ToString(drdoc["UNITIZADORES"]);
                                            doc.GAIOLAS                 = Convert.ToString(drdoc["GAIOLAS"]);
                                                

                                            rot1.veiculo.DOCUMENTOS.Add(doc);

                                        }
                                    }

                                    drdoc.Close();
                                }

                            }



                        }
                        return rot1;
                    }
                }

            }
        }


        public static TopRoutePickingList get_pickingList(int cod_roteirizacao, int cod_filais, string veiculo)
        {
            //TopRoutePickingList _pickingList = new TopRoutePickingList();

            object _veiculo = (veiculo == "" ? Convert.DBNull : veiculo);

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                var _pickingList = new TopRoutePickingList();
                con.Open();

                using (SqlCommand cmd = new SqlCommand("EXEC SP_TOPROUTE_PICKING_LIST " + cod_filais + "," + cod_roteirizacao + "," + _veiculo + "," + "V", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            //Console.WriteLine(Convert.ToInt32(dr["COD_ROTEIRIZACAO"]));


                            _pickingList.veiculo = new veiculo()
                            {
                                COD_ROTEIRIZACAO = dr.GetInt32(0)
                                //,
                                //FILIAL                     = Convert.ToString(dr["FILIAL"])
                                //,DT_EMISSAO_MANIFESTOS      = Convert.ToDateTime(dr["DT_EMISSAO_MANIFESTOS"])
                                //,DT_INCLUSAO_ROTEIRIZACAO   = Convert.ToDateTime(dr["DT_INCLUSAO_ROTEIRIZACAO"])
                                //,COD_VEICULOS               = Convert.ToInt32(dr["COD_VEICULOS"])
                                //,INDENT_VEICULOS            = Convert.ToString(dr["INDENT_VEICULOS"])
                                //,CAPAPCIDADE                = Convert.ToInt32(dr["CAPAPCIDADE"])
                                //,COD_VIAGENS_ROTEIRIZACAO   = Convert.ToInt32(dr["COD_VIAGENS_ROTEIRIZACAO"])
                                //,SEQ_VIAGENS_ROTEIRIZACAO   = Convert.ToInt32(dr["SEQ_VIAGENS_ROTEIRIZACAO"])
                            };


                            using (SqlCommand cmdDoc = new SqlCommand("SP_TOPROUTE_PICKING_LIST " + cod_filais + "," + cod_roteirizacao + "," + _veiculo + "." + 'd', con))
                            //using (SqlCommand cmdDoc = new SqlCommand("exec PR_REL_ROTEIRIZACAO_PICKING_LIST", con))
                            {
                                int contador = 1;
                                using (SqlDataReader dr_DOC = cmdDoc.ExecuteReader())
                                {
                                    while (dr_DOC.Read())
                                    {
                                        var doc = new SERVICOS
                                        {
                                            REMETENTE = "Paulo",
                                            DESTINATARIO = "Thalita",
                                            //NUMERO_DOCUMENTO = "12345",
                                            ORDEM = contador++

                                        };

                                        _pickingList.veiculo.DOCUMENTOS.Add(doc);
                                    }
                                }
                            }
                        }
                        return _pickingList;
                    }
                }

            }
        }

        /// <summary>
        /// PARAMETRO SERA A FILIAS
        /// </summary>
        /// <returns></returns>
        public static List<TopRouteRotasDistribuicao> get_RotasDistibuicao(int cod_filiais)
        {
            string commandSQL = "";
            List<TopRouteRotasDistribuicao> _rotas = new List<TopRouteRotasDistribuicao>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                commandSQL = "select COD_ROTAS_DISTRIBUICAO, DS_ROTAS_DISTRIBUICAO , KM_ROTAS_DISTRIBUICAO, IDENT_ROTAS_DISTRIBUICAO " +
                                " from tb_ROTAS_DISTRIBUICAO	(nolock) " +
                                " where COD_FILIAIS     =" + cod_filiais +
                                " and FL_TOPROUTE       =  1 "  + 
                                " and FL_ATIVA =  1 order by  COD_ROTAS_DISTRIBUICAO asc";


                //if (cod_filiais == 200)
                //{
                //    commandSQL = "select COD_ROTAS_DISTRIBUICAO, DS_ROTAS_DISTRIBUICAO , KM_ROTAS_DISTRIBUICAO, IDENT_ROTAS_DISTRIBUICAO from tb_ROTAS_DISTRIBUICAO	(nolock) where COD_FILIAIS   in(200) and COD_ROTAS_DISTRIBUICAO not in (4,5,6,7)  and FL_ATIVA =  1 order by  COD_ROTAS_DISTRIBUICAO asc";

                //}
                //else
                //{
                //    commandSQL = "select COD_ROTAS_DISTRIBUICAO, DS_ROTAS_DISTRIBUICAO , KM_ROTAS_DISTRIBUICAO, IDENT_ROTAS_DISTRIBUICAO " +
                //                " from tb_ROTAS_DISTRIBUICAO	(nolock) " +
                //                " where COD_FILIAIS   ="+ cod_filiais +
                //                " and FL_ATIVA =  1 order by  COD_ROTAS_DISTRIBUICAO asc";
                //}


                con.Open();
                //using (SqlCommand cmd = new SqlCommand("select COD_ROTAS_DISTRIBUICAO, DS_ROTAS_DISTRIBUICAO , KM_ROTAS_DISTRIBUICAO, IDENT_ROTAS_DISTRIBUICAO from tb_ROTAS_DISTRIBUICAO	(nolock) where COD_FILIAIS   in(200) and COD_ROTAS_DISTRIBUICAO not in (4,5,6,7)  and FL_ATIVA =  1 order by  COD_ROTAS_DISTRIBUICAO asc", con))
                using (SqlCommand cmd = new SqlCommand(commandSQL, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                var rota = new TopRouteRotasDistribuicao();


                                rota.COD_ROTAS_DISTRIBUICAO = Convert.ToInt32(dr["COD_ROTAS_DISTRIBUICAO"]);
                                rota.DS_ROTAS_DISTRIBUICAO = Convert.ToString(dr["DS_ROTAS_DISTRIBUICAO"]).ToString();
                                rota.KM_ROTAS_DISTRIBUICAO = Convert.ToInt32(dr["KM_ROTAS_DISTRIBUICAO"]);
                                rota.IDENT_ROTAS_DISTRIBUICAO = Convert.ToString(dr["IDENT_ROTAS_DISTRIBUICAO"]).ToString();


                                _rotas.Add(rota);
                            }
                        }
                        return _rotas;
                    }
                }

            }
        }



        //public static TopRouteJobs    getJobManifestosDocumentos(int codRoute, int codFilial)
        //{

        //    TopRouteJobs _job = new TopRouteJobs();

        //    using (SqlConnection con = new SqlConnection(getStringConexao()))
        //    {

        //        con.Open();
        //        //using (SqlCommand cmd = new SqlCommand("SELECT [COD_ROTEIRIZACAO]				=	COD_ROTEIRIZACAO,[COD_FILIAIS]					=	COD_FILIAIS,[DT_EMISSAO_MANIFESTOS]		=	isnull(DT_EMISSAO_MANIFESTOS,'19000101'),[DT_INCLUSAO_ROTEIRIZACAO]		=	isnull(DT_INCLUSAO_ROTEIRIZACAO,'19000101'),[COD_INCLUSAO_USUARIOS]		=	COD_INCLUSAO_USUARIOS,[DT_SAIDA_PREVISTA_MANIFESTOS]	=	isnull(DT_SAIDA_PREVISTA_MANIFESTOS,'19000101'),[DT_LIBERACAO_USO]				=	isnull(DT_LIBERACAO_USO,'19000101')FROM TB_ROTEIRIZACAO ORDER BY COD_ROTEIRIZACAO asc", con))
        //        using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_JOB_DOCUMENTOS_MANIFESTATOS " + codRoute + "," + codFilial, con))
        //        {

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr != null)
        //                {

        //                    while (dr.Read())
        //                    {

        //                        _job.JSON_JOB = Convert.ToString(dr["JSON_JOB"]);


        //                    }
        //                }
        //                return _job;
        //            }
        //        }

        //    }


        //}


        #endregion


        #region "OTM Documentos"

        public static List<TopRouteItens> getRoteirizacaoItens(int Cod_Roteirizacao)
        {

            List<TopRouteItens> _DocumentosRote = new List<TopRouteItens>();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec spGetRoteirizacaoDocumentos " + Cod_Roteirizacao, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {
                                var docs = new TopRouteItens();

                                docs.COD_ROTEIRIZACAO = Convert.ToInt32(dr["COD_ROTEIRIZACAO"]);
                                docs.IDENT_VEICULOS = Convert.ToString(dr["IDENT_VEICULOS"]);

                                if (!dr.IsDBNull(18))
                                    docs.COD_VEICULOS = Convert.ToInt32(dr["COD_VEICULOS"]);


                                docs.COD_DOCUMENTO = Convert.ToInt32(dr["COD_DOCUMENTO"]);
                                docs.IDENT_TIPO_DOCUMENTOS = Convert.ToString(dr["IDENT_TIPO_DOCUMENTOS"]);

                                docs.REMETENTE = Convert.ToString(dr["REMETENTE"]);
                                docs.DESTINATARIO = Convert.ToString(dr["DESTINATARIO"]);

                                //PFANTIN
                                if (!dr.IsDBNull(30))
                                    docs.CNPJ_ENTREGA = Convert.ToString(dr["CNPJ_ENTREGA"]);

                                //PFANTIN
                                if (!dr.IsDBNull(31))
                                    docs.COD_CLIENTES = Convert.ToInt32(dr["COD_CLIENTES"]);


                                

                                if (Convert.ToString(dr["ROTA"]) == "")
                                {
                                    docs.ROTA = null;
                                }
                                else
                                {
                                    docs.ROTA = Convert.ToInt32(dr["ROTA"]);
                                }

                                docs.ENDERECO = Convert.ToString(dr["ENDERECO"]);
                                docs.BAIRRO = Convert.ToString(dr["BAIRRO"]);
                                docs.CIDADE = Convert.ToString(dr["CIDADE"]);
                                docs.NR_ENDERECO = Convert.ToString(dr["NR_ENDERECO"]);
                                docs.DT_EMISSAO = Convert.ToString(dr["DT_EMISSAO"]);

                                docs.DT_MAXIMA = Convert.ToString(dr["DT_MAXIMA"]);
                                docs.DT_MAXIMA_EXTENSO = Convert.ToString(dr["DT_MAXIMA_EXTENSO"]);
                                docs.DT_MAXIMA_AVISO = Convert.ToString(dr["DT_MAXIMA_AVISO"]);

                                docs.NR_DOCUMENTO = Convert.ToString(dr["NR_DOCUMENTO"]);
                                docs.NR_DOCUMENTO_FORMATADO = Convert.ToString(dr["NR_DOCUMENTO_FORMATADO"]);

                                if (Convert.ToString(dr["QT_VOLUME"]) == "")
                                {
                                    docs.QT_VOLUME = null;
                                }
                                else
                                {
                                    docs.QT_VOLUME = Convert.ToInt32(dr["QT_VOLUME"]);
                                }

                                if (Convert.ToString(dr["PESO"]) == "")
                                {
                                    docs.PESO = null;
                                }
                                else
                                {
                                    docs.PESO = Convert.ToInt32(dr["PESO"]);
                                }

                                if (Convert.ToString(dr["PESO_REAL"]) == "")
                                {
                                    docs.PESO_REAL = null;
                                }
                                else
                                {
                                    docs.PESO_REAL = Convert.ToInt32(dr["PESO_REAL"]);
                                }

                                if (Convert.ToString(dr["PESO_REAL"]) == "")
                                {
                                    docs.VALOR = null;
                                }
                                else
                                {
                                    docs.VALOR = Convert.ToDecimal(dr["VALOR"]);
                                }



                                if (Convert.ToString(dr["ORDEM_ENTREGA"]) == "")
                                {
                                    docs.ORDEM_ENTREGA = null;
                                }
                                else
                                {
                                    docs.ORDEM_ENTREGA = Convert.ToInt32(dr["ORDEM_ENTREGA"]);
                                }


                                docs.COD_BARRAS = Convert.ToString(dr["COD_BARRAS"]);

                                if (Convert.ToString(dr["TEMPO_ENTREGA"]) == "")
                                {
                                    docs.TEMPO_ENTREGA = null;
                                }
                                else
                                {
                                    docs.TEMPO_ENTREGA = Convert.ToInt32(dr["TEMPO_ENTREGA"]);
                                }

                                docs.END_ARM = Convert.ToString(dr["END_ARM"]);
                                docs.NR_COLETA = Convert.ToString(dr["NR_COLETA"]);
                                docs.DT_SAIDA_PREV = Convert.ToString(dr["DT_SAIDA_PREV"]);

                                if (Convert.ToBoolean(dr["FL_ROTEIRIZAR"]) == false)
                                {
                                    docs.FL_ROTEIRIZAR = false;
                                }
                                else
                                {
                                    docs.FL_ROTEIRIZAR = Convert.ToBoolean(dr["FL_ROTEIRIZAR"]);
                                }

                                if (Convert.ToString(dr["FL_DOC_REMOV_VEICULO"]) == "")
                                {
                                    docs.FL_DOC_REMOV_VEICULO = false;
                                }
                                else
                                {
                                    docs.FL_DOC_REMOV_VEICULO = Convert.ToBoolean(dr["FL_DOC_REMOV_VEICULO"]);
                                }



                                if (Convert.ToString(dr["LATITUDE"]) == "")
                                {
                                    docs.lat = null;
                                }
                                else
                                {
                                    docs.lat = Convert.ToString(dr["LATITUDE"]);
                                }


                                if (Convert.ToString(dr["LONGITUDE"]) == "")
                                {
                                    docs.lat = null;
                                }
                                else
                                {
                                    docs.lng = Convert.ToString(dr["LONGITUDE"]);
                                }

                                /// Data alteracao : 12/08/2018
                                /// Autor: Paulo fantin
                                /// Descrição: Alterado a table procedures spGetRoteirizacaoDocumentos  
                                /// para os novos campos de retonor retornar na api e inclusao do campo FL_DOC_FISICO_REAL 
                                /// na tabela tb_docuemntos_roteirizacao
                                /// Observacao: ALTERACAO FEITA PARA ATENDER NOVO FORMATO DO TOP ROUTE  COMO COMBINADO COM O KLEBER"
                                #region "ALTERACAO GREENTOP"

                                docs.NR_MAC_FORMATADO   = Convert.ToString(dr["NR_MAC_FORMATADO"]);
                                docs.NR_MAC             = Convert.ToInt32(dr["NR_MAC"]);


                                if (Convert.ToString(dr["CEP"]) == "")
                                {
                                    docs.CEP = null;
                                }
                                else
                                {
                                    docs.CEP = Convert.ToString(dr["CEP"]);
                                }

                                if (Convert.ToString(dr["FAIXA_CEP"]) == "")
                                {
                                    docs.FAIXA_CEP = null;
                                }
                                else
                                {
                                    docs.FAIXA_CEP = Convert.ToString(dr["FAIXA_CEP"]);
                                }

                                if (!dr.IsDBNull(35))
                                    docs.ROTA_DOC_REAL = Convert.ToInt32(dr["ROTA_DOC_REAL"]);

                                if (!dr.IsDBNull(36))
                                    docs.FL_CONFERIDO = Convert.ToBoolean(dr["FL_CONFERIDO"]);

                                if (!dr.IsDBNull(37))
                                    docs.QTD_RETORNO = Convert.ToInt32(dr["QTD_RETORNO"]);


                                #endregion

                                if (Convert.ToString(dr["TIPO_ROUTER"]) == "")
                                {
                                    docs.TIPO_ROUTER = null;
                                }
                                else
                                {
                                    docs.TIPO_ROUTER = Convert.ToString(dr["TIPO_ROUTER"]);
                                }


                                //if (!dr.IsDBNull(16))
                                //    docs.PESO = Convert.ToInt32(dr["PESO"]);
                                //if (!dr.IsDBNull(17))
                                //    docs.PESO_REAL= Convert.ToInt32(dr["PESO_REAL"]);

                                if (!dr.IsDBNull(43))
                                    docs.MANIFESTO_SEQ_ENTREGA  							= 	Convert.ToInt32(dr["MANIFESTO_SEQ_ENTREGA"]);
                                if (!dr.IsDBNull(44))
                                    docs.MANIFESTO_COD_CONHECIMENTOS  						=  	Convert.ToInt32(dr["MANIFESTO_COD_CONHECIMENTOS"]);
                                if (!dr.IsDBNull(45))
                                    docs.MANIFESTO_COD_MANIFESTOS  							=  	Convert.ToInt32(dr["MANIFESTO_COD_MANIFESTOS"]);
                                if (!dr.IsDBNull(46))
                                    docs.MANIFESTO_COD_OCORRENCIAS_TIPO 					=  	Convert.ToInt32(dr["MANIFESTO_COD_OCORRENCIAS_TIPO"]);
                                if (!dr.IsDBNull(47))
                                    docs.MANIFESTO_DS_OCORRENCIAS_TIPO 						=  	Convert.ToString(dr["MANIFESTO_DS_OCORRENCIAS_TIPO"]);
                                if (!dr.IsDBNull(48))
                                    docs.MANIFESTO_DT_INCLUSAO_MANIFESTOS_CONHECIMENTOS 	=  	Convert.ToDateTime(dr["MANIFESTO_DT_INCLUSAO_MANIFESTOS_CONHECIMENTOS"]);
                                if (!dr.IsDBNull(49))
                                    docs.MANIFESTO_ID_VIAGENS 								=  	Convert.ToInt32(dr["MANIFESTO_ID_VIAGENS"]);
                                if (!dr.IsDBNull(50))
                                    docs.MANIFESTO_COD_VIAGENS 								=  	Convert.ToInt32(dr["MANIFESTO_COD_VIAGENS"]);
                                if (!dr.IsDBNull(51))
                                    docs.MANIFESTO_NR_MANIFESTOS 							=  	Convert.ToString(dr["MANIFESTO_NR_MANIFESTOS"]);
                                if (!dr.IsDBNull(52))
                                    docs.MANIFESTO_DT_EMISSAO_MANIFESTOS 					=  	Convert.ToDateTime(dr["MANIFESTO_DT_EMISSAO_MANIFESTOS"]);
                                if (!dr.IsDBNull(53))
                                    docs.MANIFESTO_COD_TIPO_OPERACAO 						=  	Convert.ToInt32(dr["MANIFESTO_COD_TIPO_OPERACAO"]);
                                if (!dr.IsDBNull(54))
                                    docs.MANIFESTO_DS_TIPO_OPERACAO 						=  	Convert.ToString(dr["MANIFESTO_DS_TIPO_OPERACAO"]);
                                if (!dr.IsDBNull(55))
                                    docs.MANIFESTO_SIGLA_TIPO_OPERACAO 						=  	Convert.ToString(dr["MANIFESTO_SIGLA_TIPO_OPERACAO"]);
                                if (!dr.IsDBNull(56))
                                    docs.MANIFESTO_DT_BAIXA_MANIFESTOS 						=  	Convert.ToDateTime(dr["MANIFESTO_DT_BAIXA_MANIFESTOS"]);
                                if (!dr.IsDBNull(57))
                                    docs.MANIFESTO_DT_IMPRESSAO 							=  	Convert.ToDateTime(dr["MANIFESTO_DT_IMPRESSAO"]);
                                if (!dr.IsDBNull(58))
                                    docs.VIAGENS_COD_VEICULOS_TRACAO 						=  	Convert.ToInt32(dr["VIAGENS_COD_VEICULOS_TRACAO"]);
                                if (!dr.IsDBNull(59))
                                    docs.VIAGENS_NR_PLACA_VEICULOS 							=  	Convert.ToString(dr["VIAGENS_NR_PLACA_VEICULOS"]);
                                if (!dr.IsDBNull(60))
                                    docs.VIAGENS_IDENT_VEICULOS 							=  	Convert.ToString(dr["VIAGENS_IDENT_VEICULOS"]);
                                if (!dr.IsDBNull(61))
                                    docs.VIAGENS_COD_MOTORISTAS 							=  	Convert.ToInt32(dr["VIAGENS_COD_MOTORISTAS"]);
                                if (!dr.IsDBNull(62))
                                    docs.VIAGENS_NM_MOTORISTAS 								=  	Convert.ToString(dr["VIAGENS_NM_MOTORISTAS"]);
                                if (!dr.IsDBNull(63))
                                    docs.VIAGENS_TEL_MOTORISTAS 							=  	Convert.ToString(dr["VIAGENS_TEL_MOTORISTAS"]);
                                if (!dr.IsDBNull(64))
                                    docs.VIAGENS_COD_SITUACAO_VIAGENS 						=  	Convert.ToInt32(dr["VIAGENS_COD_SITUACAO_VIAGENS"]);
                                if (!dr.IsDBNull(65))
                                    docs.VIAGENS_DS_SITUACAO_VIAGENS 						=  	Convert.ToString(dr["VIAGENS_DS_SITUACAO_VIAGENS"]);

                                docs.FRETE = Convert.ToString(dr["FRETE"]) == "" ? 0 : Convert.ToDecimal(dr["FRETE"]);


                                if (!dr.IsDBNull(67))
                                    docs.DT_AGENDAMENTO = Convert.ToDateTime(dr["DT_AGENDAMENTO"]);

                                if (!dr.IsDBNull(68))
                                    docs.HR_AGENDAMENTO_INICIO = Convert.ToDateTime(dr["HR_AGENDAMENTO_INICIO"]);

                                if (!dr.IsDBNull(69))
                                    docs.HR_AGENDAMENTO_FIM = Convert.ToDateTime(dr["HR_AGENDAMENTO_FIM"]);

                                if (!dr.IsDBNull(70))
                                    docs.DS_AGENDAMENTOS_STATUS = Convert.ToString(dr["DS_AGENDAMENTOS_STATUS"]);

                                if (!dr.IsDBNull(71))
                                    docs.SIGLA_AGENDAMENTOS_STATUS = Convert.ToString(dr["SIGLA_AGENDAMENTOS_STATUS"]);

                                if (!dr.IsDBNull(72))
                                    docs.DS_AGENDAMENTOS_TIPO = Convert.ToString(dr["DS_AGENDAMENTOS_TIPO"]);


                                //FL_DOC_FISICO_REAL
                                //    NR_MAC


                                _DocumentosRote.Add(docs);
                            }
                        }
                        return _DocumentosRote;
                    }
                }

            }
        }
        #endregion

        #region "USUARIOS"

        public static TopRouteUsuario getUsuarioAutenticado(string login)
        {

            TopRouteUsuario _usuariosAutenticado = new TopRouteUsuario();

            using (SqlConnection con = new SqlConnection(getStringConexao()))
            {

                con.Open();

                using (SqlCommand cmd = new SqlCommand("exec sp_TopRouteUsuarioAutenticado " + login, con))
                {

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {

                            while (dr.Read())
                            {

                                _usuariosAutenticado.COD_USUARIOS = Convert.ToInt32(dr["COD_USUARIOS"]);
                                _usuariosAutenticado.COD_FUNCIONARIOS = Convert.ToInt32(dr["COD_FUNCIONARIOS"]);
                                _usuariosAutenticado.LOGIN = dr["LOGIN_USUARIOS"].ToString();
                                _usuariosAutenticado.NOME = dr["NM_FUNCIONARIOS"].ToString();
                                _usuariosAutenticado.CARGO = dr["NM_CARGO_FUNCIONARIOS"].ToString();
                                _usuariosAutenticado.COD_FILIAIS = Convert.ToInt32(dr["COD_FILIAIS"]);
                                _usuariosAutenticado.FL_ATIVO = Convert.ToBoolean(dr["fl_ativo_usuarios"]);
                                _usuariosAutenticado.FL_BLOQUEADO = Convert.ToBoolean(dr["fl_bloqueado_usuarios"]);
                                _usuariosAutenticado.EMAIL = dr["email_usuarios"].ToString();
                                _usuariosAutenticado.MGS = dr["MSG"].ToString();

                            }
                        }
                        return _usuariosAutenticado;
                    }
                }

            }

        }

        #endregion


        #endregion

        #region "PUT"


        public static bool put_Conferencia(int cod_roteirizacao, int cod_rota, int cod_documento, string acao, string tiporouter)
        {
            try
            {
                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();

                    bool resultado = false;

                        using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PUT_CONFERENCIA ", con))
                    {

                        cmd.CommandText = "Exec SP_TOPROUTE_PUT_CONFERENCIA @COD_ROTEIRIZACAO, @COD_ROTA,@COD_DOCUMENTOS,@ACAO,@TIPO_ROUTER ";

                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", cod_roteirizacao);
                        cmd.Parameters.AddWithValue("COD_ROTA", cod_rota);
                        cmd.Parameters.AddWithValue("COD_DOCUMENTOS", cod_documento);
                        cmd.Parameters.AddWithValue("ACAO", acao);
                        cmd.Parameters.AddWithValue("TIPO_ROUTER", tiporouter);

                        int i = cmd.ExecuteNonQuery();

                        resultado = i > 0;
                    }

                }

                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;

                return false;

            }




        }


        public static bool put_Documento_Fisico_Real(List<TopRouteItens> itens)
        {
            try
            {
                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();

                    bool resultado = false;

                    foreach (var item in itens)
                    {
                        //using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos  @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA", con))
                        using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PUT_ROTA_DOC_REAL ", con))
                        {

                            cmd.CommandText = "Exec SP_TOPROUTE_PUT_ROTA_DOC_REAL @COD_DOCUMENTOS, @COD_ROTEIRIZACAO, @ROTA_DOC_REAL ,  @TIPO_ROUTER ";

                            cmd.Parameters.AddWithValue("COD_DOCUMENTOS"    , item.COD_DOCUMENTO);
                            cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO"  , item.COD_ROTEIRIZACAO);
                            cmd.Parameters.AddWithValue("ROTA_DOC_REAL"     , item.ROTA_DOC_REAL);
                            cmd.Parameters.AddWithValue("TIPO_ROUTER", item.TIPO_ROUTER);

                            int i = cmd.ExecuteNonQuery();

                            resultado = i > 0;
                        }
                    }
                }

                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;

                return false;

            }




        }


        public static bool AdicionarVeiculos(TopRouteVeiculo veiculos)
        {

            try
            {

                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();
                    bool resultado = false;

                    using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_VEICULOS_ADICIONAR", con))
                    {

                        cmd.CommandText = "Exec SP_TOPROUTE_VEICULOS_ADICIONAR @COD_VEICULOS,@COD_ROTEIRIZACAO";
                        cmd.Parameters.AddWithValue("COD_VEICULOS", veiculos.IDENT_VEICULOS);
                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", veiculos.COD_ROTEIRIZACAO);

                        int i = cmd.ExecuteNonQuery();

                        resultado = i > 0;

                    }

                }

                return retorno;

            }
            catch (Exception e)
            {

                throw new System.ArgumentException(e.Message, "original");

                //return false;

            }



        }



        public static bool post_EnviarRouteasy(TopRouteIndividual roteirizacao)
        {

            try
            {

                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();
                    bool resultado = false;

                    using (SqlCommand cmd = new SqlCommand("exec SP_ENVIA_JSON_ROTEIRIZACAO_ROUTEASY  ", con))
                    {

                        //cmd.CommandText = "Exec PR_ENVIA_ROTEIRIZACAO_OTM @COD_ROTEIRIZACAO";
                        //cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", roteirizacao.CODIGO_ROTEIRIZACAO);

                        cmd.CommandText = "Exec SP_ENVIA_JSON_ROTEIRIZACAO_ROUTEASY @COD_ROTEIRIZACAO, @COD_FILIAIS,@COD_ROTA_INDIVIDUAL, @SISTEMA_ENVIO";
                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO"      , roteirizacao.CODIGO_ROTEIRIZACAO);
                        cmd.Parameters.AddWithValue("COD_FILIAIS"           , roteirizacao.CODIGO_FILIAIS);
                        cmd.Parameters.AddWithValue("COD_ROTA_INDIVIDUAL"   , roteirizacao.COD_ROTA_INDIVIDUAL);
                        cmd.Parameters.AddWithValue("SISTEMA_ENVIO"         , roteirizacao.SISTEMA_ENVIO);

                        int i = cmd.ExecuteNonQuery();

                        resultado = i > 0;


                    }

                }

                return retorno;

            }
            catch (Exception e)
            {

                throw new System.ArgumentException(e.Message, "original");

                //return false;

            }



        }



        public static bool put_EnviarOTM(TopRoute roteirizacao)
        {
            //instrucao = "exec PR_ENVIA_ROTEIRIZACAO_OTM " & codRoteirizacao

            try
            {

                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();
                    bool resultado = false;

                    using (SqlCommand cmd = new SqlCommand("exec SP_ENVIA_JSON_ROTEIRIZACAO_ROUTEASY  ", con))
                    {

                        //cmd.CommandText = "Exec PR_ENVIA_ROTEIRIZACAO_OTM @COD_ROTEIRIZACAO";
                        //cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", roteirizacao.CODIGO_ROTEIRIZACAO);

                        cmd.CommandText = "Exec SP_ENVIA_JSON_ROTEIRIZACAO_ROUTEASY @COD_ROTEIRIZACAO, @COD_FILIAIS";
                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", roteirizacao.CODIGO_ROTEIRIZACAO);
                        cmd.Parameters.AddWithValue("COD_FILIAIS", roteirizacao.CODIGO_FILIAIS);


                        int i = cmd.ExecuteNonQuery();

                        resultado = i > 0;


                    }

                }

                return retorno;

            }
            catch (Exception e)
            {

                throw new System.ArgumentException(e.Message, "original");

                //return false;

            }



        }

        
        public static bool PUT_ROTA_DOC_REAL(TopRouteItens servicos)
        {

            try
            {

                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();

                    bool resultado = false;


                    //using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos  @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA", con))
                    using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PUT_ROTA_DOC_REAL ", con))
                    {

                        cmd.CommandText = "Exec SP_TOPROUTE_PUT_ROTA_DOC_REAL @COD_DOCUMENTOS, @COD_ROTEIRIZACAO, @ROTA_DOC_REAL  ";

                        cmd.Parameters.AddWithValue("COD_DOCUMENTOS"    , servicos.COD_DOCUMENTO);
                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO"  , servicos.COD_ROTEIRIZACAO);
                        cmd.Parameters.AddWithValue("ROTA_DOC_REAL"     , servicos.ROTA_DOC_REAL );
                        //cmd.Parameters.AddWithValue("TIPO_ROUTER"       , servicos.TIPO_ROUTER);

                        int i = cmd.ExecuteNonQuery();

                        resultado = i > 0;
                    }


                    //using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PUT_ROTA_DOC_REAL ", con))
                    //{

                    //    cmd.CommandText = " UPDATE TB_DOCUMENTOS_ROTEIRIZACAO  SET ROTA_DOC_REAL  = null , TIPO_ROUTER = @TIPO FROM  TB_DOCUMENTOS_ROTEIRIZACAO  WHERE COD_ROTEIRIZACAO  = @COD_ROTEIRIZACAO  and  COD_DOCUMENTOS  = @COD_DOCUMENTOS   ";

                    //    cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO"  , servicos.COD_ROTEIRIZACAO);
                    //    cmd.Parameters.AddWithValue("COD_DOCUMENTOS"    , servicos.COD_DOCUMENTO);
                    //    cmd.Parameters.AddWithValue("TIPO"              , servicos.TIPO_ROUTER);

                    //    int i = cmd.ExecuteNonQuery();

                    //    resultado = i > 0;

                    //}

                }

                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;
                return false;

            }




        }



        /// <summary>
        /// Atualizar os serviços de coleta e entrega para o veiculo relacionado a seleção da tela client-side
        /// </summary>
        /// <param name="roteirizacaoItensVeiculos"></param>
        public static bool put_TopRouteItensVeiculos(TopRouteItens servicos)
        {



            try
            {


                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();

                    bool resultado = false;

                    //using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos  @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA", con))
                    using (SqlCommand cmd = new SqlCommand("exec spTopRoute_PutRoteirizacaoItens ", con))
                    {


                        //if (servicos.COD_VEICULOS > 0)
                        //{
                        //    cmd.CommandText = "Exec SPTopRoute_PUTRoteirizacaoItens @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA , @COD_ROTEIRIZACAO ";
                        //}
                        //else
                        //{
                        //    cmd.CommandText = "Exec SPTopRoute_PUTRoteirizacaoItens @COD_DOCUMENTOS, @COD_VEICULOS= null, @ORDEM_ENTREGA  = null, @COD_ROTEIRIZACAO ";
                        //}

                        cmd.CommandText = "Exec SPTopRoute_PUTRoteirizacaoItens @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA , @COD_ROTEIRIZACAO ,@TIPO_ROUTE";


                        cmd.Parameters.AddWithValue("COD_DOCUMENTOS", servicos.COD_DOCUMENTO);
                        cmd.Parameters.AddWithValue("COD_VEICULOS", servicos.COD_VEICULOS);
                        cmd.Parameters.AddWithValue("ORDEM_ENTREGA", servicos.ORDEM_ENTREGA);
                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", servicos.COD_ROTEIRIZACAO);
                        cmd.Parameters.AddWithValue("TIPO_ROUTE"    , servicos.TIPO_ROUTER);

                        //if (servicos.COD_VEICULOS > 0)
                        //{
                        //cmd.Parameters.AddWithValue("COD_VEICULOS", servicos.COD_VEICULOS);
                        //cmd.Parameters.AddWithValue("ORDEM_ENTREGA", servicos.ORDEM_ENTREGA);
                        //}


                        int i = cmd.ExecuteNonQuery();

                        resultado = i > 0;


                    }

                }

                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;
                return false;

            }




        }


        public static bool naoRoteizarServicos(TopRouteItens item)
        {
            var resultado = false;
            using (SqlConnection connection = new SqlConnection(getStringConexao()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    int i = 0;
                    //CLIENTE REDESPACHO
                    command.CommandText = " UPDATE TB_DOCUMENTOS_ROTEIRIZACAO  SET FL_ROTEIRIZAR  = @FL_ROTEIRIZAR WHERE COD_ROTEIRIZACAO  = @COD_ROTEIRIZACAO  and  COD_DOCUMENTOS  = @COD_DOCUMENTOS   ";

                    command.Parameters.AddWithValue("COD_ROTEIRIZACAO", item.COD_ROTEIRIZACAO);
                    command.Parameters.AddWithValue("COD_DOCUMENTOS", item.COD_DOCUMENTO);
                    command.Parameters.AddWithValue("FL_ROTEIRIZAR", item.FL_ROTEIRIZAR);
                    i = command.ExecuteNonQuery();


                    resultado = i > 0;
                }
                connection.Close();
                return resultado;
            }
        }



        public static bool put_TopRouteSequencia(TopRouteItens servico)
        {


            try
            {

                var resultado = false;
                using (SqlConnection connection = new SqlConnection(getStringConexao()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {

                        command.Connection = connection;

                        int i = 0;
                        //CLIENTE REDESPACHO
                        command.CommandText = " UPDATE TB_DOCUMENTOS_ROTEIRIZACAO SET   " +
                                                "   ORDEM_ENTREGA =   @ORDEM_ENTREGA , " +
                                                "   TIPO_ROUTER =   @TIPO_ROUTER" +
                                                " WHERE COD_DOCUMENTOS    = @COD_DOCUMENTO   " +
                                                " AND COD_ROTEIRIZACAO    = @COD_ROTEIRIZACAO   ";

                        command.Parameters.AddWithValue("COD_DOCUMENTO"     , servico.COD_DOCUMENTO);
                        command.Parameters.AddWithValue("COD_ROTEIRIZACAO"  , servico.COD_ROTEIRIZACAO);
                        command.Parameters.AddWithValue("ORDEM_ENTREGA"     , servico.ORDEM_ENTREGA);
                        command.Parameters.AddWithValue("TIPO_ROUTER"       , servico.TIPO_ROUTER);

                        i = command.ExecuteNonQuery();

                    }
                    connection.Close();
                    return resultado;

                }

            }
            catch (Exception e)
            {
                object teste = e.Message;
                return false;
            }


        }
        
            public static bool documento_baixa_routeasy(List<TopRouteDocumentosRoteirizados> documentos)
        {

            try
            {
                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();

                    bool resultado = false;

                    foreach (var item in documentos)
                    {
                        //using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos  @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA", con))
                        using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PUT_DOCUMENTOS_BAIXA ", con))
                        {

                            cmd.CommandText = "Exec SP_TOPROUTE_PUT_DOCUMENTOS_BAIXA @COD_ROTEIRIZACAO, @COD_DOCUMENTOS, @BAIXA ";

                            cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", item.COD_ROTEIRIZACAO);
                            cmd.Parameters.AddWithValue("COD_DOCUMENTOS", item.COD_DOCUMENTOS);
                            cmd.Parameters.AddWithValue("BAIXA", item.BAIXA);

                            int i = cmd.ExecuteNonQuery();

                            resultado = i > 0;
                        }
                    }
                }


                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;

                return false;

            }



        }




        //public static bool put_TopRouteItensRota(TopRouteItens PutRota)
        public static bool put_TopRouteItensRota(List<TopRouteItens> PutRota)
        {

            try
            {
                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();
                    
                    bool resultado = false;

                    foreach (var item in PutRota)
                    {
                        //using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos  @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA", con))
                        using (SqlCommand cmd = new SqlCommand("exec SP_TOPROUTE_PUT_ROTA ", con))
                        {
                      
                            cmd.CommandText = "Exec SP_TOPROUTE_PUT_ROTA @COD_ROTA, @COD_ROTEIRIZACAO, @COD_CLIENTE,@CNPJ_ENTREGA,@COD_DOCUMENTO,@ROTA_DOC_REAL, @ORDEM_ENTREGA  ";


                            cmd.Parameters.AddWithValue("COD_ROTA", item.ROTA != null ? item.ROTA : -1);
                            cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", item.COD_ROTEIRIZACAO);
                            cmd.Parameters.AddWithValue("COD_CLIENTE", item.COD_CLIENTES);
                            cmd.Parameters.AddWithValue("CNPJ_ENTREGA", item.CNPJ_ENTREGA != null ? item.CNPJ_ENTREGA: "");
                            cmd.Parameters.AddWithValue("COD_DOCUMENTO", item.COD_DOCUMENTO);
                            cmd.Parameters.AddWithValue("ROTA_DOC_REAL", item.ROTA_DOC_REAL);
                            cmd.Parameters.AddWithValue("ORDEM_ENTREGA", item.ORDEM_ENTREGA!= null? item.ORDEM_ENTREGA: 0);
                            int i = cmd.ExecuteNonQuery();

                            resultado = i > 0;
                        }
                    }
                }

                
                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;

                return false;

            }

            #region comantado antigo
            //var resultado = false;
            //using (SqlConnection connection = new SqlConnection(getStringConexao()))
            //{
            //    connection.Open();

            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        command.Connection = connection;

            //        int i = 0;
            //        //CLIENTE REDESPACHO
            //        command.CommandText = " update TB_CONHECIMENTOS SET                             " +
            //                            "       COD_ROTAS_DISTRIBUICAO          =  @CodRoute        " +
            //                            "       ,DT_ATUALIZACAO_CONHECIMENTOS   =  getdate()        " +
            //                            "       ,COD_ATUALIZACAO_USUARIOS       =  @CodUser         " +
            //                            "   FROM    TB_CONHECIMENTOS C                              " +
            //                            "   INNER JOIN TB_DOCUMENTOS_ROTEIRIZACAO DR(NOLOCK)        " +
            //                            "       ON DR.COD_DOCUMENTOS = C.COD_CONHECIMENTOS AND      " +
            //                            "            DR.COD_TIPO_DOCUMENTOS = 1                     " +
            //                            "   WHERE DR.COD_ROTEIRIZACAO = @codRoteirizacao            " +
            //                            "   and C.COD_REDESPACHO_CLIENTES   =   @codCliente         ";

            //        command.Parameters.AddWithValue("codRoteirizacao", PutRota.COD_ROTEIRIZACAO);
            //        command.Parameters.AddWithValue("CNPJ_entrega", PutRota.CNPJ_ENTREGA);
            //        command.Parameters.AddWithValue("codCliente", PutRota.COD_CLIENTES);
            //        command.Parameters.AddWithValue("CodRoute", PutRota.ROTA);
            //        command.Parameters.AddWithValue("CodUser", 9999);
            //        command.Parameters.AddWithValue("codDocumento", PutRota.COD_DOCUMENTO);

            //        i = command.ExecuteNonQuery();

            //        //CLIENTE CONSIGNATARIO
            //        command.CommandText = " update TB_CONHECIMENTOS SET                             " +
            //                                "       COD_ROTAS_DISTRIBUICAO          =  @CodRoute      " +
            //                                "       ,DT_ATUALIZACAO_CONHECIMENTOS   =  getdate()      " +
            //                                "       ,COD_ATUALIZACAO_USUARIOS       =  @CodUser       " +
            //                                "   FROM    TB_CONHECIMENTOS C                            " +
            //                                "   INNER JOIN TB_DOCUMENTOS_ROTEIRIZACAO DR(NOLOCK)      " +
            //                                "       ON DR.COD_DOCUMENTOS = C.COD_CONHECIMENTOS AND    " +
            //                                "            DR.COD_TIPO_DOCUMENTOS = 1                   " +
            //                                "   WHERE DR.COD_ROTEIRIZACAO = @codRoteirizacao          " +
            //                                "   and  C.COD_REDESPACHO_CLIENTES  =   @codCliente       ";


            //        i = command.ExecuteNonQuery();


            //        //CLIENTE DESTINATARIO
            //        command.CommandText = " UPDATE  TB_CONHECIMENTOS                              " +
            //                                " SET     COD_ROTAS_DISTRIBUICAO = @CodRoute,           " +
            //                                "         DT_ATUALIZACAO_CONHECIMENTOS = GETDATE(),     " +
            //                                "         COD_ATUALIZACAO_USUARIOS = @CodUser           " +
            //                                " FROM    TB_CONHECIMENTOS C                            " +
            //                                " INNER   JOIN TB_DOCUMENTOS_ROTEIRIZACAO DR (NOLOCK)   " +
            //                                " ON      DR.COD_DOCUMENTOS = C.COD_CONHECIMENTOS AND   " +
            //                                "         DR.COD_TIPO_DOCUMENTOS = 1                    " +
            //                                "  WHERE   C.COD_REDESPACHO_CLIENTES IS NULL AND        " +
            //                                "          COD_CONSIGNATARIO_CLIENTES IS NULL AND       " +
            //                                "          DR.COD_ROTEIRIZACAO = @codRoteirizacao       " +
            //                                " and      C.COD_DESTINATARIO_CLIENTES  =   @codCliente ";


            //        i = command.ExecuteNonQuery();


            //        command.CommandText = "   UPDATE TB_COLETAS                                           " +
            //                                "   SET COD_ROTAS_DISTRIBUICAO = @CodRoute,                    " +
            //                                "           DT_ATUALIZACAO_COLETAS = GETDATE(),                 " +
            //                                "           COD_ATUALIZACAO_USUARIOS = @CodUser                 " +
            //                                "   FROM TB_COLETAS C                                           " +
            //                                "   INNER   JOIN TB_DOCUMENTOS_ROTEIRIZACAO DR(NOLOCK)          " +
            //                                "   ON DR.COD_DOCUMENTOS = C.COD_COLETAS AND                    " +
            //                                "           DR.COD_TIPO_DOCUMENTOS = 3                          " +
            //                                "   WHERE DR.COD_ROTEIRIZACAO = @codRoteirizacao                " +
            //                                "   AND C.COD_SOLICITANTE_CLIENTES  =   @codCliente             ";

            //        i = command.ExecuteNonQuery();

            //        command.CommandText = "   UPDATE TB_CLIENTES                      " +
            //                                "   SET COD_ROTAS_DISTRIBUICAO = @CodRoute  " +
            //                                "   FROM TB_CLIENTES CLI                    " +
            //                                "   WHERE   CNPJ_CLIENTES = @CNPJ_entrega     ";

            //        i = command.ExecuteNonQuery();


            //        command.CommandText = "   UPDATE TB_DOCUMENTOS_ROTEIRIZACAO " +
            //                            "   SET ROTA_DOC_REAL = @CodRoute  " +
            //                            "   FROM TB_DOCUMENTOS_ROTEIRIZACAO doc     " +
            //                            "   WHERE   COD_DOCUMENTOS = @codDocumento     " +
            //                            "   AND   COD_ROTEIRIZACAO = @codRoteirizacao     ";

            //        i = command.ExecuteNonQuery();



            //        resultado = i > 0;
            //    }
            //    connection.Close();




            //    return resultado;
            //}
            #endregion

        }





        /// <summary>
        /// Função para atualizar relaciondo a roteirizacao passado no parametro para limpar os servicos dos veiculos
        /// </summary>
        /// <param Cod_Roteirizacao="classe TopRouteVeiculo para pegar "></param>
        /// <returns>true/false</returns>
        public static bool put_TopRouteLimparServicosVeiculo(TopRouteVeiculo veiculo)
        {
            var resultado = false;
            using (SqlConnection connection = new SqlConnection(getStringConexao()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;

                    int i = 0;
                    //CLIENTE REDESPACHO
                    command.CommandText = " UPDATE TB_DOCUMENTOS_ROTEIRIZACAO SET               " +
                                            "   ORDEM_ENTREGA =  NULL                           " +
                                            "   ,COD_VEICULOS =   NULL                           " +
                                            " WHERE COD_ROTEIRIZACAO    = @COD_ROTEIRIZACAO     ";


                    command.Parameters.AddWithValue("COD_ROTEIRIZACAO", veiculo.COD_ROTEIRIZACAO);


                    i = command.ExecuteNonQuery();

                }
                connection.Close();
                return resultado;

            }
        }

        #endregion

        #region "DELETE"

        /// <summary>
        /// desvincular o servico Coleta/Entrega de um veículo
        /// </summary>
        /// <param name="del_TopRouteItensVeiculos"></param>
        public static bool del_TopRouteItensVeiculos(TopRouteItens servico)
        {


            try
            {

                bool retorno = false;
                using (SqlConnection con = new SqlConnection(getStringConexao()))
                {

                    con.Open();

                    bool resultado = false;

                    //using (SqlCommand cmd = new SqlCommand("exec sp_TopRoute_Veiculos  @COD_DOCUMENTOS, @COD_VEICULOS, @ORDEM_ENTREGA", con))
                    using (SqlCommand cmd = new SqlCommand("exec spTopRoute_Del_RoteirizacaoItens ", con))
                    {

                        cmd.CommandText = "Exec spTopRoute_Del_RoteirizacaoItens @COD_DOCUMENTOS, @COD_ROTEIRIZACAO ";
                        cmd.Parameters.AddWithValue("COD_DOCUMENTOS", servico.COD_DOCUMENTO);
                        cmd.Parameters.AddWithValue("COD_ROTEIRIZACAO", servico.COD_ROTEIRIZACAO);
                        int i = cmd.ExecuteNonQuery();
                        resultado = i > 0;
                    }

                }

                return retorno;

            }
            catch (Exception e)
            {
                object teste = e.Message;

                return false;

            }




        }



        #endregion

        //public static bool atualizarCliente(cliente cliente)
        //{
        //    var resultado = false;
        //    using (SqlConnection connection = new SqlConnection(getStringConexao()))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = " update clientes set  nome = @nome,  email = @email where id = @id";

        //            command.Parameters.AddWithValue("nome", cliente.Nome);
        //            command.Parameters.AddWithValue("email", cliente.Email);
        //            command.Parameters.AddWithValue("id", cliente.Id);

        //            int i = command.ExecuteNonQuery();
        //            resultado = i > 0;
        //        }

        //        connection.Close();

        //        return resultado;
        //    }
        //}




        //public static bool salvateste([FromBody]object json)
        //{
        //    var resultado = false;
        //    using (SqlConnection connection = new SqlConnection(getStringConexao()))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "insert into tb_cliente(nome,  email) values(@nome, @email)";

        //            //command.Parameters.AddWithValue("nome", cliente.Nome);
        //            //command.Parameters.AddWithValue("email", cliente.Email);


        //            int i = command.ExecuteNonQuery();
        //            resultado = i > 0;

        //            resultado = i > 0;
        //        }

        //        connection.Close();

        //        return resultado;
        //    }
        //}


        //public static bool salvarCliente(cliente cliente)
        //{
        //    var resultado = false;
        //    using (SqlConnection connection = new SqlConnection(getStringConexao()))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "insert into tb_cliente(nome,  email) values(@nome, @email)";

        //            command.Parameters.AddWithValue("nome", cliente.Nome);
        //            command.Parameters.AddWithValue("email", cliente.Email);


        //            int i = command.ExecuteNonQuery();
        //            resultado = i > 0;

        //            resultado = i > 0;
        //        }

        //        connection.Close();

        //        return resultado;
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonRetorno"></param>
        /// <returns></returns>
        //public static bool salvarClienteJson(Person person)
        //{
        //    var resultado = false;
        //    using (SqlConnection connection = new SqlConnection(getStringConexao()))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "insert into clientes(nome,  email) values(@nome, @email)";

        //            command.Parameters.AddWithValue("nome", person.LastName);
        //            command.Parameters.AddWithValue("email", person.Address);

        //            int i = command.ExecuteNonQuery();
        //            resultado = i > 0;
        //        }

        //        connection.Close();

        //        return resultado;
        //    }
        //}



        //public static bool postRetornoRouteasy(routeasyRetorno jsonRetorno)
        //{
        //    var resultado = false;
        //    using (SqlConnection connection = new SqlConnection(getStringConexao()))
        //    {
        //        connection.Open();

        //        //salvar retorno nosso banco

        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "insert into tb_cliente (nome,  email) values(@nome, @email)";

        //            //command.Parameters.AddWithValue("nome", cliente.Nome);
        //            //command.Parameters.AddWithValue("email", cliente.Email);

        //            int i = command.ExecuteNonQuery();
        //            resultado = i > 0;
        //        }

        //        connection.Close();

        //        return resultado;
        //    }
        //}
    }
};


namespace ApiRouteasy.Models
{
    public class DalHelperRouteasy
    {

        protected static string getStringConexao()
        {
            //return ConfigurationManager.ConnectionStrings["conexaoProducao"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["NoteDell"].ConnectionString;
            //return ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
            return ConfigurationManager.ConnectionStrings["MeuContext"].ConnectionString;

        }

        public static bool salvarRetornoRouteasy([FromBody]object json)
        {

            var resultado = false;
            using (SqlConnection connection = new SqlConnection(getStringConexao()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.commandTex = "SP_RETORNO_JSON_ROTEIRIZACAO_ROUTEASY @JSON_RETORNO";
                    //command.Parameters.AddWithValue("JSON_RETORNO", json.ToString());
                    command.CommandText = "insert into tb_integracao_routeasy_tmp(json_retorno) values(@json_retorno)";
                    command.Parameters.AddWithValue("json_retorno", json.ToString());

                    int i = command.ExecuteNonQuery();
                    resultado = i > 0;
                }

                connection.Close();

                return resultado;
            }
        }




        public static bool RetornoRouteasyProcess([FromBody]object json)
        {
            var resultado = false;
            using (SqlConnection connection = new SqlConnection(getStringConexao()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    int i = 0;
                    //CLIENTE REDESPACHO
                    command.CommandText = "exec SP_RETORNO_JSON_ROTEIRIZACAO_ROUTEASY @JSON_RETORNO";
                    command.Parameters.AddWithValue("JSON_RETORNO", json.ToString());
                    i = command.ExecuteNonQuery();


                    resultado = i > 0;
                }
                connection.Close();
                return resultado;
            }
        }

    }

}