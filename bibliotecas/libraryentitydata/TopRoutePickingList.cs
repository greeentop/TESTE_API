using System;
using System.Collections.Generic;

namespace LibraryEntityData
{
    public class TopRoutePickingList
    {

        public veiculo veiculo;

    }

    public class SERVICOS
    {
        public int COD_ROTEIRIZACAO { get; set; }
        public int COD_VEICULOS { get; set; }
        public string TIPO_SERVICO { get; set; }
        public int ORDEM { get; set; }
        public int COD_DOCUMENTO { get; set; }
        public string DOCUMENTO { get; set; }
        public DateTime DT_EMISSAO { get; set; }
        public int COD_REMETENTE { get; set; }
        public string REMETENTE { get; set; }
        public int COD_DESTINATARIO { get; set; }
        public string DESTINATARIO { get; set; }
        public string ENDERECO { get; set; }
        public int NUMERO { get; set; }
        public string CEP { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string COMPLEMENTO { get; set; }
        public int COD_ROTA { get; set; }
        public int QT_VOLUMES { get; set; }
        public int PESO_NOTA { get; set; }
        public int PESO_CALCULO { get; set; }
        public int QT_RETORNOS { get; set; }
        public int? COD_PRIORIDADE { get; set; }
        public int COD_FILIAIS { get; set; }
        public string NOTAS { get; set; }
        public string ID_VOLUMES { get; set; }
        public int COD_VIAGENS_ROTEIRIZACAO { get; set; }
        public int SEQ_VIAGENS_ROTEIRIZACAO { get; set; }
        public int COD_UU { get; set; }
        public int COD_UU_ENDERECO { get; set; }
        public string END_ARM { get; set; }

        //agendamento
        public string DT_AGENDAMENTO { get; set; }
        public string HR_AGENDAMENTO_INICIO { get; set; }
        public string HR_AGENDAMENTO_FIM { get; set; }
        public string OBS_AGENDAMENTO { get; set; }
        public int? COD_AGENDAMENTOS_PERIODO { get; set; }
        public string DS_AGENDAMENTOS_PERIODO { get; set; }
        public string DS_AGENDAMENTOS_TIPO { get; set; }

        public decimal VL_MERCADORIA { get; set; }
        public string UNITIZADORES { get; set; }
        public string GAIOLAS { get; set; }






    }

    public class veiculo
    {
        public int COD_ROTEIRIZACAO { get; set; }

        public String FILIAL { get; set; }
        public DateTime DT_EMISSAO_MANIFESTOS { get; set; }
        public DateTime DT_INCLUSAO_ROTEIRIZACAO { get; set; }
        public int COD_VEICULOS { get; set; }
        public string IDENT_VEICULOS { get; set; }

        public long CAPACIDADE { get; set; }

        public int COD_VIAGENS_ROTEIRIZACAO { get; set; }
        public int SEQ_VIAGENS_ROTEIRIZACAO { get; set; }


        public List<SERVICOS> DOCUMENTOS;


    }
}
