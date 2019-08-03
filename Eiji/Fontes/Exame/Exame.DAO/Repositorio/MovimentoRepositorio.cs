using Exame.VO;
using Exame.VO.Entidade.Procedure;
using Exame.VO.Interface.Banco;
using Exame.VO.Interface.Repositorio;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class MovimentoRepositorio : IMovimentoRepositorio
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

        private readonly IConexao _conexao = new Conexao();
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public bool Adicionar(Movimento movimento)
        {
            _logger.Info("Adicionar [INICIO]");

            var resultado = false;
            string queryString = $"INSERT INTO {TABELA} ({MES},{ANO},{NUMEROLANCAMENTO},{CODIGOPRODUTO},{CODIGOCOSIF},{VALOR},{DESCRICAO},{DATAMOVIMENTO},{CODIGOUSUARIO}) VALUES (@mes, @ano, @numeroLancamento, @codigoProduto, @codigoCosif, @valor, @descricao, @dataMovimento, @codigoUsuario)";

            SqlParameter[] parameters =
            {
                new SqlParameter{ParameterName = "@mes", Value = movimento.Mes},
                new SqlParameter{ParameterName = "@ano", Value = movimento.Ano},
                new SqlParameter{ParameterName = "@numeroLancamento", Value = movimento.NumeroLancamento},
                new SqlParameter{ParameterName = "@codigoProduto", Value = movimento.CodigoProduto},
                new SqlParameter{ParameterName = "@codigoCosif", Value = movimento.CodigoCosif},
                new SqlParameter{ParameterName = "@valor", Value = movimento.Valor},
                new SqlParameter{ParameterName = "@descricao", Value = movimento.Descricao},
                new SqlParameter{ParameterName = "@dataMovimento", Value = movimento.DataMovimento},
                new SqlParameter{ParameterName = "@codigoUsuario", Value = movimento.CodigoUsuario},
            };

            using (SqlConnection connection = _conexao.SqlConnection())
            {
                int resultadoNonQuery = _conexao.ExecuteNonQuery(queryString, parameters, connection);

                resultado = resultadoNonQuery > 0;
            }

            _logger.Info($"Adicionar [FIM]| resultado: {resultado}");
            return resultado;
        }

        public IEnumerable<MovimentoProduto> ListarMovimentoProduto()
        {
            _logger.Info("ListarMovimentoProduto [INICIO]");
            string queryString = "ListarMovimentoProduto";

            using (SqlConnection connection = _conexao.SqlConnection())
            using (IDataReader reader = _conexao.ExecuteReader(queryString, connection))
            {
                while (reader.Read())
                {
                    yield return
                        new MovimentoProduto(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetString(5),
                            reader.GetInt32(6)
                        );
                }

            }

            _logger.Info("ListarMovimentoProduto [FIM]");
        }

        public int MaximoNumeroLancamento(int mes, int ano)
        {
            _logger.Info($"MaximoNumeroLancamento [INICIO] | mes: {mes}, ano {ano}");

            var numeroLancamento = 1;
            string queryString = $"SELECT ISNULL(MAX(NUM_LANCAMENTO), 0) FROM MOVIMENTO_MANUAL WHERE DAT_MES = @mes AND DAT_ANO = @ano";

            SqlParameter[] parameters =
            {
                new SqlParameter{ ParameterName = "@mes", Value = mes},
                new SqlParameter{ ParameterName = "@ano", Value = ano}
            };

            using (SqlConnection connection = _conexao.SqlConnection())
            {
                object scalar = _conexao.ExecuteScalar(queryString, parameters, connection);

                numeroLancamento = (int)scalar;
            }

            _logger.Info($"MaximoNumeroLancamento [FIM]| numeroLancamento: {numeroLancamento}");
            return numeroLancamento;
        }
    }
}
