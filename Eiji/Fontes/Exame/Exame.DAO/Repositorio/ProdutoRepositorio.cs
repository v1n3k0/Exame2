using Exame.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Exame.DAO.Repositorio
{
    public class ProdutoRepositorio
    {
        private const string TABELA = "PRODUTO";
        private const string CODIGO = "COD_PRODUTO";
        private const string DESCRICAO = "DES_PRODUTO";
        private const string STATUS = "STA_STATUS";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;

        public IEnumerable<Produto> ListarPorStatus(string status)
        {
            string queryString = $"SELECT {CODIGO},{DESCRICAO},{STATUS} " +
                $"from {TABELA} WHERE " +
                $"{STATUS} like @status";

            var produtos = new List<Produto>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@status", status);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        produtos.Add(
                            new Produto() {
                                Codigo = reader.GetInt32(0),
                                Descricao = reader.GetString(1),
                                Status = reader.GetString(2)
                            });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Concat("ERROR: ",ex.Message));
                }
            }

            return produtos;
        }
    }
}
