using System.Data;
using System.Data.SqlClient;

namespace Exame.DAO.Interface
{
    interface IConexao
    {
        SqlConnection SqlConnection();

        int ExecuteNonQuery(string queryString, SqlParameter[] parameters, SqlConnection connection);

        IDataReader ExecuteReader(string queryString, SqlConnection connection);

        IDataReader ExecuteReader(string queryString, SqlParameter[] parameters, SqlConnection connection);

        object ExecuteScalar(string queryString, SqlParameter[] parameters, SqlConnection connection);
    }
}
