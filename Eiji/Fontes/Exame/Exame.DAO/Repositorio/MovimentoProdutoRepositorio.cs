using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio.Base;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class MovimentoProdutoRepositorio : ListaRepositorio<MovimentoProduto>, IMovimentoProdutoRepositorio
    {
        private const string MES = "DAT_MES";
        private const string ANO = "DAT_ANO";
        private const string NUMEROLANCAMENTO = "NUM_LANCAMENTO";
        private const string CODIGOPRODUTO = "COD_PRODUTO";
        private const string VALOR = "VAL_VALOR";
        private const string DES_MOVIMENTO = "DES_DESCRICAO";
        private const string DES_PRODUTO = "DES_PRODUTO";

        /// <summary>
        /// Recuperar lista de todos os MovimentosProdutos
        /// </summary>
        /// <returns>Lista de MovimentoProdutos</returns>
        public ICollection<MovimentoProduto> ListarTodos()
        {
            _logger.Info("ListarMovimentoProduto [INICIO]");

            string queryString = "ListarMovimentoProduto";

            ICollection<MovimentoProduto> lista = Listar(queryString);

            _logger.Info("ListarMovimentoProduto [FIM]");
            return lista;
        }

        /// <summary>
        /// Criar uma lista de MovimentosProdutos
        /// </summary>
        /// <param name="reader">SqlDataReader</param>
        /// <returns>Lista de MovimentoProdutos</returns>
        protected override ICollection<MovimentoProduto> PreencherLista(SqlDataReader reader)
        {
            _logger.Info("PreencherLista [INICIO]");

            ICollection<MovimentoProduto> lista = new Collection<MovimentoProduto>();

            while (reader.Read())
            {
                lista.Add(new MovimentoProduto()
                {
                    Mes = reader.GetInt32(reader.GetOrdinal(MES)),
                    Ano = reader.GetInt32(reader.GetOrdinal(ANO)),
                    CodigoProduto = reader.GetInt32(reader.GetOrdinal(CODIGOPRODUTO)),
                    DescricaoProduto = reader.GetString(reader.GetOrdinal(DES_PRODUTO)),
                    NumeroLancamento = reader.GetInt32(reader.GetOrdinal(NUMEROLANCAMENTO)),
                    DescricaoMovimento = reader.GetString(reader.GetOrdinal(DES_MOVIMENTO)),
                    Valor = reader.GetInt32(reader.GetOrdinal(VALOR))
                });
            }

            _logger.Info("PreencherLista [FIM]");
            return lista;
        }
    }
}
