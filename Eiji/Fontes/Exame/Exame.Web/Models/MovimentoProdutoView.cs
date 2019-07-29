using Exame.VO.Entidade.Procedure;
using System.ComponentModel.DataAnnotations;

namespace Exame.Web.Models
{
    public class MovimentoProdutoView
    {
        [Display(Name = "Mês")]
        public int Mes { get; set; }

        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [Display(Name = "Produto")]
        public int CodigoProduto { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string DescricaoProduto { get; set; }

        [Display(Name = "Número de Lançamento")]
        public int NumeroLancamento { get; set; }

        [Display(Name = "Descrição do Movimento")]
        public string DescricaoMovimento { get; set; }

        [Display(Name = "Valor")]
        public int Valor { get; set; }
    }
}