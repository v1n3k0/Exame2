using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Exame.VO.Interface.Banco;

namespace Exame.DAO
{
    public class Conexao: IConexao
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Configurar conexão
        /// </summary>
        /// <returns></returns>
        public SqlConnection SqlConnection()
        {
            _logger.Info("SqlConnection [INICIO]");

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString);

            _logger.Info("SqlConnection [FIM]");
            return connection;
        }

        /// <summary>
        /// Executar instrução SQL que não retornam dados
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string queryString, SqlConnection connection)
        {
            return ExecuteNonQuery(queryString, null, connection);
        }

        /// <summary>
        /// Executar instrução SQL que não retornam dados
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="parameters">Parametros da instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string queryString, SqlParameter[] parameters, SqlConnection connection)
        {
            _logger.Info($"ExecuteNonQuery [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            if(parameters != null) command.Parameters.AddRange(parameters);
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

        /// <summary>
        /// Instrução SQL que retorna um IDataReader
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string queryString, SqlConnection connection)
        {
            return ExecuteReader(queryString, null, connection);
        }

        /// <summary>
        /// Instrução SQL que retorna um IDataReader
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="parameters">Parametros da instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string queryString, SqlParameter[] parameters, SqlConnection connection)
        {
            _logger.Info($"ExecuteReader [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            if(parameters != null) command.Parameters.AddRange(parameters);
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

        /// <summary>
        /// Executar instrução SQL utilizando funções agregadas
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns></returns>
        public object ExecuteScalar(string queryString, SqlConnection connection)
        {
            return ExecuteScalar(queryString, null, connection);
        }

        /// <summary>
        /// Executar instrução SQL utilizando funções agregadas
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="parameters">Parametros da instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns></returns>
        public object ExecuteScalar(string queryString, SqlParameter[] parameters, SqlConnection connection)
        {
            _logger.Info($"ExecuteScalar [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, connection);
            if(parameters != null) command.Parameters.AddRange(parameters);
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
