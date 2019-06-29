using Exame.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Exame.DAO.Repositorio
{
    public class CosifRepositorio
    {
        private const string TABELA = "PRODUTO_COSIF";
        private const string CODIGO = "COD_COSIF";
        private const string CODIGOPRODUTO = "COD_PRODUTO";
        private const string CLASSIFICACAO = "COD_CLASSIFICACAO";
        private const string STATUS = "STA_STATUS";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;

        public IEnumerable<Cosif> ListarPorProduto(int codigoProduto)
        {
            string queryString = $"SELECT {CODIGO},{CODIGOPRODUTO},{CLASSIFICACAO},{STATUS} " +
                $"from {TABELA} " +
                $"WHERE {CODIGOPRODUTO} = @codigoProduto";

            var cosifs = new List<Cosif>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@codigoProduto", codigoProduto);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cosifs.Add(
                            new Cosif()
                            {
                                Codigo = reader.GetInt32(0),
                                CodigoProduto = reader.GetInt32(1),
                                Classificacao = reader.GetString(2),
                                Status = reader.GetString(3)
                            });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Concat("ERROR: ",ex.Message));
                }
            }

            return cosifs;
        }
    }
}
