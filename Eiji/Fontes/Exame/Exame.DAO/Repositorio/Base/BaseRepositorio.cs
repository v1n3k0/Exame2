using Exame.DAO.Interface.Repositorio.Base;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio.Base
{
    public class BaseRepositorio : IBaseRepositorio
    {
        protected readonly SqlConnection _connection;
        protected readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Configurar conexão
        /// </summary>
        protected BaseRepositorio()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString);
        }

        /// <summary>
        /// Executar instrução SQL que não retornam dados
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns>Número de linhas afetado</returns>
        protected int ExecuteNonQuery(string queryString)
        {
            return ExecuteNonQuery(queryString, null);
        }

        /// <summary>
        /// Executar instrução SQL que não retornam dados
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="parameters">Parametros da instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns>Número de linhas afetado</returns>
        protected int ExecuteNonQuery(string queryString, params SqlParameter[] parameters)
        {
            _logger.Info($"ExecuteNonQuery [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, _connection);
            if (parameters != null) command.Parameters.AddRange(parameters);
            int resultadoNonQuery = 0;

            try
            {
                _connection.Open();
                resultadoNonQuery = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ExecuteNonQuery: ");
            }
            finally
            {
                Close();
            }

            _logger.Info("ExecuteNonQuery [FIM]");
            return resultadoNonQuery;
        }

        /// <summary>
        /// Executar instrução SQL utilizando funções agregadas
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns>Valor primeira linha e coluna</returns>
        protected object ExecuteScalar(string queryString)
        {
            return ExecuteScalar(queryString, null);
        }

        /// <summary>
        /// Executar instrução SQL utilizando funções agregadas
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="parameters">Parametros da instrução</param>
        /// <param name="connection">Conexão do banco de dados</param>
        /// <returns>Valor primeira linha e coluna</returns>
        protected object ExecuteScalar(string queryString, params SqlParameter[] parameters)
        {
            _logger.Info($"ExecuteScalar [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, _connection);
            if (parameters != null) command.Parameters.AddRange(parameters);
            object scalar = null;

            try
            {
                _connection.Open();
                scalar = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ExecuteScalar: ");
            }
            finally
            {
                Close();
            }

            _logger.Info("ExecuteScalar [FIM]");
            return scalar;
        }

        /// <summary>
        /// Fecha SqlConnection
        /// </summary>
        protected virtual void Close()
        {
            _connection.Close();
        }
    }
}
