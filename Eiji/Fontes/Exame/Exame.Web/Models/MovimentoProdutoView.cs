using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Exame.Web.Models
{
    [DataContract]
    public class MovimentoProdutoView
    {
        [DataMember]
        [Display(Name = "Mês")]
        public int Mes { get; set; }

        [DataMember]
        [Display(Name = "Ano")]
        public int Ano { get; set; }

        [DataMember]
        [Display(Name = "Produto")]
        public int CodigoProduto { get; set; }

        [DataMember]
        [Display(Name = "Descrição do Produto")]
        public string DescricaoProduto { get; set; }

        [DataMember]
        [Display(Name = "Número de Lançamento")]
        public int NumeroLancamento { get; set; }

        [DataMember]
        [Display(Name = "Descrição do Movimento")]
        public string DescricaoMovimento { get; set; }

        [DataMember]
        [Display(Name = "Valor")]
        public int Valor { get; set; }
    }
}