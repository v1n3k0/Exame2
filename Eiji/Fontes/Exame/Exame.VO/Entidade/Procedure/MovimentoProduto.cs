namespace Exame.VO.Entidade.Procedure
{
    public class MovimentoProduto
    {
        public int Mes { get; private set; }
        public int Ano { get; private set; }
        public int CodigoProduto { get; private set; }
        public string DescricaoProduto { get; private set; }
        public int NumeroLancamento { get; private set; }
        public string DescricaoMovimento { get; private set; }
        public int Valor { get; private set; }

        public MovimentoProduto(int mes, int ano, int codigoProduto, string descricaoProduto, int numeroLancamento, string descricaoMovimento, int valor)
        {
            Mes = mes;
            Ano = ano;
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            NumeroLancamento = numeroLancamento;
            DescricaoMovimento = descricaoMovimento;
            Valor = valor;
        }
    }
}
