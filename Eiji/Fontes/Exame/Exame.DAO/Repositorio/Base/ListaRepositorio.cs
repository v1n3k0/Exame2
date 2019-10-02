using Exame.DAO.Interface.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio.Base
{
    public abstract class ListaRepositorio<T> : BaseRepositorio, IListaRepositorio<T> where T : class
    {
        protected SqlDataReader reader;

        /// <summary>
        /// Recuperar uma lista de objetos 
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <returns>Lista de objetos do tipo T</returns>
        protected ICollection<T> Listar(string queryString)
        {
            return ListarPor(queryString, null);
        }

        /// <summary>
        /// Recuperar uma lista de objetos 
        /// </summary>
        /// <param name="queryString">Instrução</param>
        /// <param name="parameters">Parametros da instrução</param>
        /// <returns>Lista de objetos do tipo T</returns>
        protected ICollection<T> ListarPor(string queryString, params SqlParameter[] parameters)
        {
            _logger.Info($"ExecuteReader [INICIO]|queryString: {queryString}");

            var command = new SqlCommand(queryString, _connection);
            if (parameters != null) command.Parameters.AddRange(parameters);
            ICollection<T> lista = null;

            try
            {
                _connection.Open();
                reader = command.ExecuteReader();
                lista = PreencherLista(reader);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ExecuteReader: ");
            }
            finally
            {
                Close();
            }

            _logger.Info("ExecuteReader [FIM]");
            return lista;
        }

        /// <summary>
        /// Preencher uma lista
        /// </summary>
        /// <param name="reader">SqlDataReader</param>
        /// <returns>Criar lista</returns>
        protected abstract ICollection<T> PreencherLista(SqlDataReader reader);

        /// <summary>
        /// Fecha SqlDataReader e o SqlConnection
        /// </summary>
        protected override void Close()
        {
            if (reader != null && !reader.IsClosed) reader.Close();
            base.Close();
        }
    }
}
