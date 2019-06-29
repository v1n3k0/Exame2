using Exame.DAO.Repositorio;
using Exame.VO;
using System;
using System.Collections.Generic;

namespace Exame.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorioProduto = new ProdutoRepositorio();

            IEnumerable<Produto> produtos = repositorioProduto.ListarPorStatus("A");

            Console.WriteLine("Codigo\tDescricao\tStatus");

            foreach (var produto in produtos)
            {
                Console.WriteLine("{0}\t{1}\t{2}",produto.Codigo, produto.Descricao, produto.Status);
            }

            Console.WriteLine("\n");

            var repositorioCosif = new CosifRepositorio();

            IEnumerable<Cosif> cosifs = repositorioCosif.ListarPorStatusPorProduto("A", 1);

            Console.WriteLine("Codigo\tCodProd\tClass\tStatus");

            foreach (var cosif in cosifs)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", cosif.Codigo, cosif.CodigoProduto, cosif.Classificacao, cosif.Status);
            }

            Console.ReadLine();
        }
    }
}
