using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntityData
{
    public class TopRouteVeiculo
    {



        public int    COD_ROTEIRIZACAO      { get; set; }
        public int    COD_VEICULOS          { get; set; }
        public string    DS_VEICULOS           { get; set; }
        public string IDENT_VEICULOS        { get; set; }

        public int QTD_CTRC { get; set; }
        public string    ROTA                  { get; set; }
        public string MODELO                { get; set; }
        public int    CAPACIDADE            { get; set; }
        public string NR_PLACA              { get; set; }
        public int?    SEQ_VIAGEM            { get; set; }
        public int   KM_TOTAL_DISTANCE        { get; set; }

        public decimal PESOTOTAL { get; set; }
        public int OCUPACAO { get; set; }

        public List<TopRouteUsuarioFilial> Filias { get; set; }
    }
}
