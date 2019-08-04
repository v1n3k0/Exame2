using Exame.VO;
using Exame.VO.Interface.Banco;
using Exame.VO.Interface.Repositorio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class CosifRepositorio : ICosifRepositorio
    {
        private const string TABELA = "PRODUTO_COSIF";
        private const string CODIGO = "COD_COSIF";
        private const string CODIGOPRODUTO = "COD_PRODUTO";
        private const string CLASSIFICACAO = "COD_CLASSIFICACAO";
        private const string STATUS = "STA_STATUS";

        private readonly IConexao _conexao;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public CosifRepositorio(IConexao conexao) => _conexao = conexao;

        /// <summary>
        /// Recuperar Cosif por status e produto
        /// </summary>
        /// <param name="status">Status do Cosif</param>
        /// <param name="codigoProduto">Codigo do Produto</param>
        /// <returns></returns>
        public IEnumerable<Cosif> ListarPorStatusPorProduto(string status, int codigoProduto)
        {
            _logger.Info($"ListarPorStatusPorProduto [INICIO] | status:{status}, codigoProduto: {codigoProduto}");

            string queryString = $"SELECT {CODIGO},{CODIGOPRODUTO},{CLASSIFICACAO},{STATUS} from {TABELA} WHERE {STATUS} like @status AND {CODIGOPRODUTO} = @codigoProduto";

            SqlParameter[] parameters =
            {
                new SqlParameter{ ParameterName = "@status", Value = status},
                new SqlParameter{ ParameterName = "@codigoProduto", Value = codigoProduto}
            };

            using (SqlConnection connection = _conexao.SqlConnection())
            using (IDataReader reader = _conexao.ExecuteReader(queryString, parameters, connection))
            {
                while (reader.Read())
                {
                    yield return new Cosif(
                        reader.GetInt32(reader.GetOrdinal(CODIGO)), 
                        reader.GetInt32(reader.GetOrdinal(CODIGOPRODUTO)), 
                        reader.GetString(reader.GetOrdinal(CLASSIFICACAO)), 
                        reader.GetString(reader.GetOrdinal(STATUS))
                        );
                }
            }

            _logger.Info("ListarPorStatusPorProduto [FIM]");
        }
    }
}
