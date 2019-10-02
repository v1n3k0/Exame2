using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Exame.Web.Models
{
    [DataContract]
    public class MovimentoView
    {
        [DataMember]
        [Display(Name = "Mês")]
        [Required(ErrorMessage = "Mês é obrigatório")]
        [Range(1, 12, ErrorMessage ="Mês deve ter entre o valor 1 a 12")]
        public int Mes { get; set; }

        [DataMember]
        [Display(Name = "Ano")]
        [Required(ErrorMessage = "Ano é obrigatório")]
        [Range(1, 9999, ErrorMessage = "Ano deve ter entre o valor 1 a 9999")]
        public int Ano { get; set; }
        
        [DataMember]
        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Produto é obrigatório")]
        public int CodigoProduto { get; set; }

        [DataMember]
        [Display(Name = "Cosif")]
        [Required(ErrorMessage = "Cosif é obrigatório")]
        public int CodigoCosif { get; set; }

        [DataMember]
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public int Valor { get; set; }

        [DataMember]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O Email deve ter no mínimo 1 e no máximo 50 caracteres.")]
        public string Descricao { get; set; }
    }
}