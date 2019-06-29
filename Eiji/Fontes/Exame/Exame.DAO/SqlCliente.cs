using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exame.DAO
{
    public class SqlCliente
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;

        public SqlDataReader executarReader(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    
                }

                return reader;
            }
        }

        public SqlDataReader executarNonQuery(SqlCommand comando)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    comando.ExecuteNonQuery();;
                }
                catch (Exception ex)
                {

                }

                return reader;
            }
        }
    }       
}
