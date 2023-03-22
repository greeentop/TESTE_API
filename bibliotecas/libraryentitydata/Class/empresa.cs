namespace LibraryEntityData.Class
{
    public class empresa
    {

        public int Id_Empresa { get; set; }
        public string nome_razao_Social { get; set; }
        public string nome_Fantasia { get; set; }
        public TipoEmpresa tipoEmporesa { get; set; }
        public string CNPJ_CPF { get; set; }

    }

    public enum TipoEmpresa
    {
        Juridica    = 0,
        fisica      = 1
    }
}
