using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

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

        public static int ExecuteNonQuery(string queryString, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            int resultadoNonQuery = 0;

            try
            {
                connection.Open();
                resultadoNonQuery = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Concat("ERROR: ", ex.Message));
            }

            return resultadoNonQuery;
        }

        public static SqlDataReader ExecuteReader(string queryString, SqlConnection connection)
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
                Debug.WriteLine(string.Concat("ERROR: ", ex.Message));
            }

            return reader;
        }

        public static object ExecuteScalar(string queryString, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            object scalar = null;

            try
            {
                connection.Open();
                scalar = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Concat("ERROR: ", ex.Message));
            }

            return scalar;
        }
    }
}
