using Exame.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class ProdutoRepositorio
    {
        private const string PRODUTO = "PRODUTO";
        private const string CODIGO = "COD_PRODUTO";
        private const string DESCRICAO = "DES_PRODUTO";
        private const string STATUS = "STA_STATUS";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;

        public IEnumerable<Produto> listar()
        {
            string queryString = $"SELECT {CODIGO},{DESCRICAO},{STATUS} from {PRODUTO}";
            var produtos = new List<Produto>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        produtos.Add(
                            new Produto() {
                                codigo = reader.GetInt32(0),
                                descricao = reader.GetString(1),
                                status = reader.GetString(2)
                            });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
            }

            return produtos;
        }
    }
}
