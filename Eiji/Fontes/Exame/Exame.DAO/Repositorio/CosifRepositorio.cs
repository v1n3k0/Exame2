using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio.Base;
using Exame.VO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class CosifRepositorio : ListaRepositorio<Cosif>, ICosifRepositorio
    {
        private const string TABELA = "PRODUTO_COSIF";
        private const string CODIGO = "COD_COSIF";
        private const string CODIGOPRODUTO = "COD_PRODUTO";
        private const string CLASSIFICACAO = "COD_CLASSIFICACAO";
        private const string STATUS = "STA_STATUS";

        /// <summary>
        /// Recuperar Cosif por status e produto
        /// </summary>
        /// <param name="status">Status do Cosif</param>
        /// <param name="codigoProduto">Codigo do Produto</param>
        /// <returns>Lista de Cosif</returns>
        public ICollection<Cosif> ListarPorStatusPorProduto(string status, int codigoProduto)
        {
            _logger.Info($"ListarPorStatusPorProduto [INICIO] | status:{status}, codigoProduto: {codigoProduto}");

            string queryString = $"SELECT {CODIGO},{CODIGOPRODUTO},{CLASSIFICACAO},{STATUS} from {TABELA} WHERE {STATUS} like @status AND {CODIGOPRODUTO} = @codigoProduto";

            ICollection<Cosif> lista = ListarPor(queryString,
                new SqlParameter { ParameterName = "@status", Value = status },
                new SqlParameter { ParameterName = "@codigoProduto", Value = codigoProduto }
                );

            _logger.Info("ListarPorStatusPorProduto [FIM]");
            return lista;
        }

        /// <summary>
        /// Criar uma lista de Cosif
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Lista de Cosif</returns>
        protected override ICollection<Cosif> PreencherLista(SqlDataReader reader)
        {
            _logger.Info("PreencherLista [INICIO]");

            ICollection<Cosif> lista = new Collection<Cosif>();

            while (reader.Read())
            {
                lista.Add(new Cosif()
                {
                    Codigo = reader.GetInt32(reader.GetOrdinal(CODIGO)),
                    CodigoProduto = reader.GetInt32(reader.GetOrdinal(CODIGOPRODUTO)),
                    Classificacao = reader.GetString(reader.GetOrdinal(CLASSIFICACAO)),
                    Status = reader.GetString(reader.GetOrdinal(STATUS))
                });
            }

            _logger.Info("PreencherLista [FIM]");
            return lista;
        }
    }
}
