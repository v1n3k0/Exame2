using System;
using System.ComponentModel.DataAnnotations;

namespace Exame.Web.Models
{
    public class MovimentoView
    {
        [Display(Name = "Mês")]
        [Required(ErrorMessage = "Mês é obrigatório")]
        [Range(1, 12, ErrorMessage ="Mês deve ter entre o valor 1 a 12")]
        public int Mes { get; set; }

        [Display(Name = "Ano")]
        [Required(ErrorMessage = "Ano é obrigatório")]
        [Range(1, 9999, ErrorMessage = "Ano deve ter entre o valor 1 a 9999")]
        public int Ano { get; set; }

        [Display(Name = "Número de Lançamento")]
        public int NumeroLancamento { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Produto é obrigatório")]
        public int CodigoProduto { get; set; }

        [Display(Name = "Cosif")]
        [Required(ErrorMessage = "Cosif é obrigatório")]
        public int CodigoCosif { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        public int Valor { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatório", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O Email deve ter no mínimo 1 e no máximo 50 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Movimento")]
        public DateTime DataMovimento { get; set; }

        [Display(Name = "Usuário")]
        public string CodigoUsuario { get; set; }
    }
}