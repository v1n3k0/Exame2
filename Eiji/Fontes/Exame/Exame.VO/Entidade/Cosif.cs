namespace Exame.VO
{
    public class Cosif
    {
        public int Codigo { get; private set; }
        public int CodigoProduto { get; private set; }
        public string Classificacao { get; private set; }
        public string Status { get; private set; }

        public Cosif(int codigo, int codigoProduto, string classificacao, string status)
        {
            Codigo = codigo;
            CodigoProduto = codigoProduto;
            Classificacao = classificacao;
            Status = status;
        }

        public Cosif(int codigo, int codigoProduto, string status)
        {
            Codigo = codigo;
            CodigoProduto = codigoProduto;
            Status = status;
        }
    }
}
