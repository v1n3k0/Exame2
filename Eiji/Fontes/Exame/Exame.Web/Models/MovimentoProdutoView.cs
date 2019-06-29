using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exame.VO.Entidade.Procedure;

namespace Exame.Web.Models
{
    public class MovimentoProdutoView
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int NumeroLancamento { get; set; }
        public string DescricaoMovimento { get; set; }
        public int Valor { get; set; }

        public static explicit operator MovimentoProdutoView(MovimentoProduto v)
        {
            return new MovimentoProdutoView()
            {
                Mes = v.Mes,
                Ano = v.Ano,
                CodigoProduto = v.CodigoProduto,
                DescricaoMovimento = v.DescricaoMovimento,
                NumeroLancamento = v.NumeroLancamento,
                DescricaoProduto = v.DescricaoProduto,
                Valor = v.Valor
            };
        }
    }
}