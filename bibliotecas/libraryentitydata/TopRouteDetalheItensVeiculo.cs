namespace LibraryEntityData
{
    public class TopRouteDetalheItensVeiculo
    {
        
        public int COD_ROTEIRIZACAO { get; set; }

        public string IDENT_VEICULOS { get; set; }
        public int COD_VEICULOS { get; set; }
        public int COD_DOCUMENTOS { get; set; }

        public string DESTINATARIO { get; set; }

        public string IDENT_TIPO_DOCUMENTOS { get; set; }
        public int? ROTA { get; set; }
        public int? CEP { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }

        public int? QT_VOLUME { get; set; }
        public int? PESO { get; set; }
        public int? PESO_REAL { get; set; }
        public decimal? VALOR { get; set; }
        public decimal? FRETE { get; set; }
        public string MENSAGEM { get; set; }
        public int? ORDEM_ENTREGA { get; set; }
        public int DOCUMENTO { get; set; }

        public string lng { get; set; }
        public string lat { get; set; }


    }
}
