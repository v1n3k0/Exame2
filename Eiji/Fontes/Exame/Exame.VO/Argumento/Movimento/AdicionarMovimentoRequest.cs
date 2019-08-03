namespace Exame.VO.Argumento.Movimento
{
    public class AdicionarMovimentoRequest
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int CodigoProduto { get; set; }
        public int CodigoCosif { get; set; }
        public int Valor { get; set; }
        public string Descricao { get; set; }
    }
}
