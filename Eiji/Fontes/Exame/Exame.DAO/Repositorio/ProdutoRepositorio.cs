using Exame.DAO.Interface.Repositorio;
using Exame.VO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private const string TABELA = "PRODUTO";
        private const string CODIGO = "COD_PRODUTO";
        private const string DESCRICAO = "DES_PRODUTO";
        private const string STATUS = "STA_STATUS";

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public IEnumerable<Produto> ListarPorStatus(string status)
        {
            _logger.Info($"ListarPorStatus [INICIO] | status: {status}");

            string queryString = $"SELECT {CODIGO},{DESCRICAO},{STATUS} from {TABELA} WHERE  {STATUS} like '{status}'";

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                using (SqlDataReader reader = Conexao.ExecuteReader(queryString, connection))
                {
                    while (reader.Read())
                    {
                        yield return new Produto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    }
                }
            }

            _logger.Info("ListarPorStatus [FIM]");
        }
    }
}
