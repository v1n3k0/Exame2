using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Exame.DAO.Repositorio
{
    public class MovimentoRepositorio
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

        public bool Adicionar(Movimento movimento)
        {
            var resultado = false;
            string queryString = $"INSERT INTO {TABELA} " +
                $"({MES},{ANO},{NUMEROLANCAMENTO},{CODIGOPRODUTO},{CODIGOCOSIF},{VALOR},{DESCRICAO},{DATAMOVIMENTO},{CODIGOUSUARIO})" +
                $"VALUES ({movimento.Mes}, {movimento.Ano}, {movimento.NumeroLancamento}, {movimento.CodigoProduto}, {movimento.CodigoCosif}," +
                $"{movimento.Valor}, '{movimento.Descricao}', '{movimento.DataMovimento}', '{movimento.CodigoUsuario}')";

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                int resultadoNonQuery = Conexao.ExecuteNonQuery(queryString, connection);

                resultado = resultadoNonQuery > 0;
            }

            return resultado;
        }

        public List<MovimentoProduto> ListarMovimentoProduto()
        {
            var movimentosProduto = new List<MovimentoProduto>();
            string queryString = "exec ListarMovimentoProduto";

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                using (SqlDataReader reader = Conexao.ExecuteReader(queryString, connection))
                {
                    while (reader.Read())
                    {
                        movimentosProduto.Add(
                            new MovimentoProduto()
                            {
                                Mes = reader.GetInt32(0),
                                Ano = reader.GetInt32(1),
                                CodigoProduto = reader.GetInt32(2),
                                DescricaoProduto = reader.GetString(3),
                                NumeroLancamento = reader.GetInt32(4),
                                DescricaoMovimento = reader.GetString(5),
                                Valor = reader.GetInt32(6)
                            });
                    }
                }
            }

            return movimentosProduto;
        }

        public int MaximoNumeroLancamento(int mes, int ano)
        {
            var numeroLancamento = 1;
            string queryString = $"SELECT ISNULL(MAX(NUM_LANCAMENTO), 0) FROM MOVIMENTO_MANUAL WHERE DAT_MES = {mes} AND DAT_ANO = {ano}";

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                object scalar = Conexao.ExecuteScalar(queryString, connection);

                numeroLancamento = (int)scalar;
            }

            return numeroLancamento;
        }
    }
}
