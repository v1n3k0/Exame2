﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Exame.DAO
{
    public static class Conexao
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["ExameConnetionString"].ConnectionString;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static SqlConnection SqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            return connection;
        }

        public static int ExecuteNonQuery(string queryString, SqlConnection connection)
        {
            Logger.Info($"ExecuteNonQuery: {queryString}");
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
                Logger.Error(ex, "ExecuteNonQuery: ");
            }

            Logger.Info($"ExecuteNonQuery: {resultadoNonQuery}");
            return resultadoNonQuery;
        }

        public static SqlDataReader ExecuteReader(string queryString, SqlConnection connection)
        {
            Logger.Info($"ExecuteReader: {queryString}");
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
                Logger.Error(ex, "ExecuteReader: ");
            }

            Logger.Info($"ExecuteReader: {reader}");
            return reader;
        }

        public static object ExecuteScalar(string queryString, SqlConnection connection)
        {
            Logger.Info($"ExecuteScalar: {queryString}");
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
                Logger.Error(ex, "ExecuteScalar: ");
            }

            Logger.Info($"ExecuteScalar: {scalar}");
            return scalar;
        }
    }
}
