using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exame.DAO
{
    public static class Conexao
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static SqlConnection SqlConnection()
        {
            _logger.Info("SqlConnection [INICIO]");

            SqlConnection connection = new SqlConnection(_connectionString);

            _logger.Info("SqlConnection [FIM]");
            return connection;
        }

        public static int ExecuteNonQuery(string queryString, SqlConnection connection)
        {
            _logger.Info($"ExecuteNonQuery [INICIO]|queryString: {queryString}");

            SqlCommand command = new SqlCommand(queryString, connection);
            int resultadoNonQuery = 0;

            try
            {
                connection.Open();
                resultadoNonQuery = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ExecuteNonQuery: ");
            }

            _logger.Info("ExecuteNonQuery [FIM]");
            return resultadoNonQuery;
        }

        public static SqlDataReader ExecuteReader(string queryString, SqlConnection connection)
        {
            _logger.Info($"ExecuteReader [INICIO]|queryString: {queryString}");

            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ExecuteReader: ");
            }

            _logger.Info("ExecuteReader [FIM]");
            return reader;
        }

        public static object ExecuteScalar(string queryString, SqlConnection connection)
        {
            _logger.Info($"ExecuteScalar [INICIO]|queryString: {queryString}");

            SqlCommand command = new SqlCommand(queryString, connection);
            object scalar = null;

            try
            {
                connection.Open();
                scalar = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ExecuteScalar: ");
            }

            _logger.Info("ExecuteScalar [FIM]");
            return scalar;
        }
    }
}
