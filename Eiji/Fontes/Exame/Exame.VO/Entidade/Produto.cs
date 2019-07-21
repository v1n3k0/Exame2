namespace Exame.VO
{
    public class Produto
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Status { get; private set; }

        public Produto(int codigo, string descricao, string status)
        {
            Codigo = codigo;
            Descricao = descricao;
            Status = status;
        }

        public Produto(int codigo, string status)
        {
            Codigo = codigo;
            Status = status;
        }
    }
}
