using System.Collections.Generic;

namespace Exame.Web.Models
{
    public class ProdutoView
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public List<CosifView> Cosifs { get; set; }
    }
}