using System;

namespace Exame.VO
{
    public class Movimento
    {
        public int Mes { get; private set; }
        public int Ano { get; private set; }
        public int NumeroLancamento { get; private set; }
        public int CodigoProduto { get; private set; }
        public int CodigoCosif { get; private set; }
        public int Valor { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataMovimento { get; private set; }
        public string CodigoUsuario { get; private set; }

        public Movimento(int mes, int ano, int numeroLancamento, int codigoProduto, int codigoCosif, int valor, 
            string descricao)
        {
            Mes = mes;
            Ano = ano;
            NumeroLancamento = numeroLancamento;
            CodigoProduto = codigoProduto;
            CodigoCosif = codigoCosif;
            Valor = valor;
            Descricao = descricao;
            DataMovimento = DateTime.Now;
            CodigoUsuario = "TESTE";
        }
    }
}
