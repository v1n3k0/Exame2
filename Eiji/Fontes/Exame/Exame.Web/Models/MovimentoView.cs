using System;

namespace Exame.Web.Models
{
    public class MovimentoView
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public int CodigoProduto { get; set; }
        public int CodigoCosif { get; set; }
        public int Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string CodigoUsuario { get; set; }
    }
}