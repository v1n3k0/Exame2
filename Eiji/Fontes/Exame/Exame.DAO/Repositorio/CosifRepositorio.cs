using Exame.VO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class CosifRepositorio
    {
        private const string TABELA = "PRODUTO_COSIF";
        private const string CODIGO = "COD_COSIF";
        private const string CODIGOPRODUTO = "COD_PRODUTO";
        private const string CLASSIFICACAO = "COD_CLASSIFICACAO";
        private const string STATUS = "STA_STATUS";

        public IEnumerable<Cosif> ListarPorStatusPorProduto(string status, int codigoProduto)
        {
            string queryString = $"SELECT {CODIGO},{CODIGOPRODUTO},{CLASSIFICACAO},{STATUS} " +
                $"from {TABELA} WHERE {STATUS} like '{status}' AND {CODIGOPRODUTO} = {codigoProduto}";

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                using (SqlDataReader reader = Conexao.ExecuteReader(queryString, connection))
                {
                    while (reader.Read())
                    {
                        yield return new Cosif()
                        {
                            Codigo = reader.GetInt32(0),
                            CodigoProduto = reader.GetInt32(1),
                            Classificacao = reader.GetString(2),
                            Status = reader.GetString(3)
                        };
                    }
                }
            }
        }
    }
}
