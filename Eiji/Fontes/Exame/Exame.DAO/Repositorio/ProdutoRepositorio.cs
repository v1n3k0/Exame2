using Exame.VO;
using Exame.VO.Interface.Banco;
using Exame.VO.Interface.Repositorio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private const string TABELA = "PRODUTO";
        private const string CODIGO = "COD_PRODUTO";
        private const string DESCRICAO = "DES_PRODUTO";
        private const string STATUS = "STA_STATUS";

        private readonly IConexao _conexao;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ProdutoRepositorio(IConexao conexao)
        {
            _conexao = conexao;
        }

        /// <summary>
        /// Recuperar Produto por status
        /// </summary>
        /// <param name="status">Status do Produto</param>
        /// <returns></returns>
        public IEnumerable<Produto> ListarPorStatus(string status)
        {
            _logger.Info($"ListarPorStatus [INICIO] | status: {status}");

            string queryString = $"SELECT {CODIGO},{DESCRICAO},{STATUS} from {TABELA} WHERE  {STATUS} like @status";

            SqlParameter[] parameters = 
            {
                new SqlParameter{ParameterName = "@status", Value = status}
            };

            using (SqlConnection connection = _conexao.SqlConnection())
            using (IDataReader reader = _conexao.ExecuteReader(queryString, parameters, connection))
            {
                while (reader.Read())
                {
                    yield return new Produto(
                        reader.GetInt32(reader.GetOrdinal(CODIGO)), 
                        reader.GetString(reader.GetOrdinal(DESCRICAO)), 
                        reader.GetString(reader.GetOrdinal(STATUS))
                        );
                }
            }

            _logger.Info("ListarPorStatus [FIM]");
        }
    }
}
