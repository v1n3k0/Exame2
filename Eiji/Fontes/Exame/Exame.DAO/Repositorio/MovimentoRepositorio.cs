using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio.Base;
using Exame.VO;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class MovimentoRepositorio : BaseRepositorio, IMovimentoRepositorio
    {
        private const string TABELA = "MOVIMENTO_MANUAL";
        private const string MES = "DAT_MES";
        private const string ANO = "DAT_ANO";
        private const string NUMEROLANCAMENTO = "NUM_LANCAMENTO";
        private const string CODIGOPRODUTO = "COD_PRODUTO";
        private const string CODIGOCOSIF = "COD_COSIF";
        private const string VALOR = "VAL_VALOR";
        private const string DESCRICAO = "DES_DESCRICAO";
        private const string DATAMOVIMENTO = "DAT_MOVIMENTO";
        private const string CODIGOUSUARIO = "COD_USUARIO";

        /// <summary>
        /// Inserir movimento
        /// </summary>
        /// <param name="movimento">Objeto a ser persistido</param>
        /// <returns>Resultado da execução</returns>
        public bool Adicionar(Movimento movimento)
        {
            _logger.Info("Adicionar [INICIO]");

            string queryString = $"INSERT INTO {TABELA} ({MES},{ANO},{NUMEROLANCAMENTO},{CODIGOPRODUTO},{CODIGOCOSIF},{VALOR},{DESCRICAO},{DATAMOVIMENTO},{CODIGOUSUARIO}) VALUES (@mes, @ano, @numeroLancamento, @codigoProduto, @codigoCosif, @valor, @descricao, @dataMovimento, @codigoUsuario)";

            int resultadoNonQuery = ExecuteNonQuery(queryString,
                new SqlParameter { ParameterName = "@mes", Value = movimento.Mes },
                new SqlParameter { ParameterName = "@ano", Value = movimento.Ano },
                new SqlParameter { ParameterName = "@numeroLancamento", Value = movimento.NumeroLancamento },
                new SqlParameter { ParameterName = "@codigoProduto", Value = movimento.CodigoProduto },
                new SqlParameter { ParameterName = "@codigoCosif", Value = movimento.CodigoCosif },
                new SqlParameter { ParameterName = "@valor", Value = movimento.Valor },
                new SqlParameter { ParameterName = "@descricao", Value = movimento.Descricao },
                new SqlParameter { ParameterName = "@dataMovimento", Value = movimento.DataMovimento },
                new SqlParameter { ParameterName = "@codigoUsuario", Value = movimento.CodigoUsuario }
                );

            bool resultado = resultadoNonQuery > 0;

            _logger.Info($"Adicionar [FIM]| resultado: {resultado}");
            return resultado;
        }

        /// <summary>
        /// Recuperar valor maximo do numero de lançamento
        /// </summary>
        /// <param name="mes">Mes do Movimento</param>
        /// <param name="ano">Ano do Movimento</param>
        /// <returns>Numero maximo do lançamento</returns>
        public int MaximoNumeroLancamento(int mes, int ano)
        {
            _logger.Info($"MaximoNumeroLancamento [INICIO] | mes: {mes}, ano {ano}");

            string queryString = $"SELECT ISNULL(MAX({NUMEROLANCAMENTO}), 0) FROM {TABELA} WHERE {MES} = @mes AND {ANO} = @ano";

            object scalar = ExecuteScalar(queryString,
                new SqlParameter { ParameterName = "@mes", Value = mes },
                new SqlParameter { ParameterName = "@ano", Value = ano }
                );

            var numeroLancamento = (int)scalar;

            _logger.Info($"MaximoNumeroLancamento [FIM]| numeroLancamento: {numeroLancamento}");
            return numeroLancamento;
        }
    }
}