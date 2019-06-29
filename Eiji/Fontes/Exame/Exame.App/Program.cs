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

            IEnumerable<Produto> produtos = repositorioProduto.listar();

            Console.WriteLine("\tCodigo\tDescricao\tStatus");

            foreach (var produto in produtos)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}",produto.codigo, produto.descricao, produto.status);
            }

            Console.ReadLine();
        }
    }
}
