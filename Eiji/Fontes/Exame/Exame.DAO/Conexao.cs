using System.Configuration;
using System.Data.SqlClient;

namespace Exame.DAO
{
    public static class Conexao
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;

        public static SqlConnection SqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            return connection;
        }
    }
}
