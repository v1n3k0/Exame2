using System.Collections.Generic;

namespace Exame.Web.Models
{
    public class CosifView
    {
        public int Codigo { get; set; }
        public int CodigoProduto { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }
        public List<MovimentoView> Movimentos { get; set; }
    }
}