using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio.Base;
using Exame.VO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class ProdutoRepositorio : ListaRepositorio<Produto>, IProdutoRepositorio
    {
        private const string TABELA = "PRODUTO";
        private const string CODIGO = "COD_PRODUTO";
        private const string DESCRICAO = "DES_PRODUTO";
        private const string STATUS = "STA_STATUS";
        
        /// <summary>
        /// Recuperar Produto por status
        /// </summary>
        /// <param name="status">Status do Produto</param>
        /// <returns>Lista de Produto</returns>
        public ICollection<Produto> ListarPorStatus(string status)
        {
            _logger.Info($"ListarPorStatus [INICIO] | status: {status}");

            string queryString = $"SELECT {CODIGO},{DESCRICAO},{STATUS} from {TABELA} WHERE  {STATUS} like @status";

            ICollection<Produto> lista = ListarPor(queryString, 
                new SqlParameter { ParameterName = "@status", Value = status }
                );

            _logger.Info("ListarPorStatus [FIM]");
            return lista;
        }

        /// <summary>
        /// Criar uma lista de Produto
        /// </summary>
        /// <param name="reader">SqlDataReader</param>
        /// <returns>Lista de Produto</returns>
        protected override ICollection<Produto> PreencherLista(SqlDataReader reader)
        {
            _logger.Info("PreencherLista [INICIO]");

            ICollection<Produto> lista = new Collection<Produto>();

            while (reader.Read())
            {
                lista.Add(new Produto()
                {
                    Codigo = reader.GetInt32(reader.GetOrdinal(CODIGO)),
                    Descricao = reader.GetString(reader.GetOrdinal(DESCRICAO)),
                    Status = reader.GetString(reader.GetOrdinal(STATUS))
                });
            }

            _logger.Info("PreencherLista [FIM]");
            return lista;
        }
    }
}
