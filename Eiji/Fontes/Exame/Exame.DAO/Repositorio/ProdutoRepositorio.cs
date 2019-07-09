using Exame.VO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class ProdutoRepositorio
    {
        private const string TABELA = "PRODUTO";
        private const string CODIGO = "COD_PRODUTO";
        private const string DESCRICAO = "DES_PRODUTO";
        private const string STATUS = "STA_STATUS";

        public IEnumerable<Produto> ListarPorStatus(string status)
        {
            var produtos = new List<Produto>();
            string queryString = $"SELECT {CODIGO},{DESCRICAO},{STATUS} from {TABELA} WHERE  {STATUS} like '{status}'";

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                using (SqlDataReader reader = Conexao.ExecuteReader(queryString, connection))
                {
                    while (reader.Read())
                    {
                        produtos.Add(
                            new Produto()
                            {
                                Codigo = reader.GetInt32(0),
                                Descricao = reader.GetString(1),
                                Status = reader.GetString(2)
                            });
                    }
                }
            }

            return produtos;
        }
    }
}
