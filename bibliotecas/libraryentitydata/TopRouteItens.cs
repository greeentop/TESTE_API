using System;

namespace LibraryEntityData
{
    public class TopRouteItens
    {

        public int COD_ROTEIRIZACAO { get; set; }
        public string IDENT_VEICULOS { get; set; }
        public int?  COD_VEICULOS { get; set; }
        public string NR_DOCUMENTO { get; set; }
        public string NR_DOCUMENTO_FORMATADO { get; set; }
        public string IDENT_TIPO_DOCUMENTOS { get; set; }
        public int? ORDEM_ENTREGA { get; set; }
        public string DESTINATARIO { get; set; }

        public int  COD_CLIENTE_DESTINATARIO { get; set; }

        public string REMETENTE { get; set; }

        public string CNPJ_DESTINATARIO { get; set; }
        public string CNPJ_ENTREGA { get; set; }
        public int? COD_CLIENTES { get; set; }
        public int COD_CLIENTE_REMETENTE { get; set; }

        public int? ROTA { get; set; }
        public string CIDADE { get; set; }
        public string ENDERECO { get; set; }
        public string NR_ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string DT_EMISSAO { get; set; }
        public string DT_MAXIMA { get; set; }
        public string DT_MAXIMA_EXTENSO { get; set; }
        public string DT_MAXIMA_AVISO { get; set; }

        public int? QT_VOLUME { get; set; }
        public int? PESO { get; set; }
        public int? PESO_REAL { get; set; }
        public decimal? VALOR { get; set; }

        public long? COD_DOCUMENTO { get; set; }
        public string TIPO_ROUTER { get; set; }
        public string COD_BARRAS { get; set; }
        public int? TEMPO_ENTREGA { get; set; }
        public string END_ARM { get; set; }
        public string NR_COLETA { get; set; }
        public string DT_SAIDA_PREV { get; set; }
        public Boolean FL_ROTEIRIZAR { get; set; }
        public Boolean FL_DOC_REMOV_VEICULO { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }

        public int? COD_VIAGENS_ROTEIRIZACAO { get; set; }

        public int MANIFESTO_SEQ_ENTREGA { get; set; }
        public int MANIFESTO_COD_CONHECIMENTOS { get; set; }
        public int MANIFESTO_COD_MANIFESTOS { get; set; }
        public int MANIFESTO_COD_OCORRENCIAS_TIPO { get; set; }
        public string MANIFESTO_DS_OCORRENCIAS_TIPO { get; set; }
        public DateTime MANIFESTO_DT_INCLUSAO_MANIFESTOS_CONHECIMENTOS { get; set; }
        public int MANIFESTO_ID_VIAGENS { get; set; }
        public int MANIFESTO_COD_VIAGENS { get; set; }
        public string MANIFESTO_NR_MANIFESTOS { get; set; }
        public DateTime MANIFESTO_DT_EMISSAO_MANIFESTOS { get; set; }
        public int MANIFESTO_COD_TIPO_OPERACAO { get; set; }
        public string MANIFESTO_DS_TIPO_OPERACAO { get; set; }
        public string MANIFESTO_SIGLA_TIPO_OPERACAO { get; set; }
        public DateTime MANIFESTO_DT_BAIXA_MANIFESTOS { get; set; }
        public DateTime MANIFESTO_DT_IMPRESSAO { get; set; }
        public int VIAGENS_COD_VEICULOS_TRACAO { get; set; }
        public string VIAGENS_NR_PLACA_VEICULOS { get; set; }
        public string VIAGENS_IDENT_VEICULOS { get; set; }
        public int VIAGENS_COD_MOTORISTAS { get; set; }
        public string VIAGENS_NM_MOTORISTAS { get; set; }
        public string VIAGENS_TEL_MOTORISTAS { get; set; }
        public int VIAGENS_COD_SITUACAO_VIAGENS { get; set; }
        public string VIAGENS_DS_SITUACAO_VIAGENS { get; set; }

        public decimal? FRETE { get; set; }


        public DateTime? DT_AGENDAMENTO { get; set; }
        public DateTime? HR_AGENDAMENTO_INICIO { get; set; }
        public DateTime? HR_AGENDAMENTO_FIM { get; set; }
        public string DS_AGENDAMENTOS_STATUS { get; set; }
        public string SIGLA_AGENDAMENTOS_STATUS { get; set; }
        public string DS_AGENDAMENTOS_TIPO { get; set; }


        #region "ALTERACAO GREENTOP PARA ATENDER NOVO MODELO TOP ROUTE"

        public int? NR_MAC { get; set; }
        public string NR_MAC_FORMATADO { get; set; }

        
        public string CEP { get; set; }
        public string FAIXA_CEP { get; set; }

        public long? ROTA_DOC_REAL { get; set; }
        public Boolean FL_CONFERIDO { get; set; }

        public int? QTD_RETORNO { get; set; }




        #endregion

        #region "COMENTADO"

        //public int? PRIORIDADE { get; set; }
        //public string DT_RETORNO_ROTEIRIZACAO { get; set; }
        //public string IDENT_FILIAIS { get; set; }
        //public string SIGLA_FILIAIS { get; set; }

        //public string IDENT_FILIAIS_ORIGEM_MAC { get; set; }
        //public string IDENT_FILIAIS_DESTINO_MAC { get; set; }
        //public int? CEP { get; set; }
        //public string FIL_DEST { get; set; }
        //public decimal? FRETE { get; set; }
        //public string MENSAGEM { get; set; }
        //public string NOTAS_FISCAIS { get; set; }

        //public string ID_VOLUME { get; set; }
        //public long? CNPJ_ENTREGA { get; set; }

        //public int? JANELA_ENTREGA { get; set; }

        //public Boolean FL_AGENDAMENTO { get; set; }
        //public Boolean FL_CARRO_DEDICADO { get; set; }
        //public string DS_RESTRICAO_VEICULO { get; set; }
        //public string OUTRAS_RESTRICOES { get; set; }
        //public string ZONA_RESTRICAO { get; set; }
        #endregion






    }
}

