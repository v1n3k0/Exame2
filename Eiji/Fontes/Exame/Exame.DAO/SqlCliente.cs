using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exame.DAO
{
    public class SqlCliente
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public SqlDataReader executar(SqlCommand comando)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    connection.Open();
                    reader = comando.ExecuteReader();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    
                }

                return reader;
            }
        }
    }       
}
