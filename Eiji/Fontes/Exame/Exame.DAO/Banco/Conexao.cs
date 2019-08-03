using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Exame.VO.Interface.Banco;

namespace Exame.DAO
{
    public class Conexao: IConexao
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public SqlConnection SqlConnection()
        {
            _logger.Info("SqlConnection [INICIO]");

            SqlConnection connection = new SqlConnection(_connectionString);

            _logger.Info("SqlConnection [FIM]");
            return connection;
        }

        public int ExecuteNonQuery(string queryString, SqlParameter[] parameters, SqlConnection connection)
        {
            _logger.Info($"ExecuteNonQuery [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddRange(parameters);
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

        public IDataReader ExecuteReader(string queryString, SqlConnection connection)
        {
            _logger.Info($"ExecuteReader [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            IDataReader reader = null;

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

        public IDataReader ExecuteReader(string queryString, SqlParameter[] parameters, SqlConnection connection)
        {
            _logger.Info($"ExecuteReader [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddRange(parameters);
            IDataReader reader = null;

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

        public object ExecuteScalar(string queryString, SqlParameter[] parameters, SqlConnection connection)
        {
            _logger.Info($"ExecuteScalar [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddRange(parameters);
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
