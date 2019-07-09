﻿using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

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
            string queryString = $"INSERT INTO {TABELA} " +
                $"({MES},{ANO},{NUMEROLANCAMENTO},{CODIGOPRODUTO},{CODIGOCOSIF},{VALOR},{DESCRICAO},{DATAMOVIMENTO},{CODIGOUSUARIO})" +
                "VALUES" +
                $"(@mes, @ano, @numeroLancamento, @codigoProduto, @codigoCosif, @valor, @descricao, @dataMovimento, @codigoUsuario)";

            var resultado = false;

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@mes", movimento.Mes);
                command.Parameters.AddWithValue("@ano", movimento.Ano);
                command.Parameters.AddWithValue("@numeroLancamento", movimento.NumeroLancamento);
                command.Parameters.AddWithValue("@codigoProduto", movimento.CodigoProduto);
                command.Parameters.AddWithValue("@codigoCosif", movimento.CodigoCosif);
                command.Parameters.AddWithValue("@valor", movimento.Valor);
                command.Parameters.AddWithValue("@descricao", movimento.Descricao);
                command.Parameters.AddWithValue("@dataMovimento", movimento.DataMovimento);
                command.Parameters.AddWithValue("@codigoUsuario", movimento.CodigoUsuario);

                try
                {
                    connection.Open();
                    int resultadoNonQuery = command.ExecuteNonQuery();

                    resultado = resultadoNonQuery > 0;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Concat("ERROR: ", ex.Message));
                }
            }

            return resultado;
        }

        public IEnumerable<MovimentoProduto> ListarMovimentoProduto()
        {
            string queryString = "exec ListarMovimentoProduto";

            var movimentosProduto = new List<MovimentoProduto>();

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
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
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Concat("ERROR: ", ex.Message));
                }
            }

            return movimentosProduto;
        }

        public int MaximoNumeroLancamento(int mes, int ano)
        {
            string queryString = "SELECT ISNULL(MAX(NUM_LANCAMENTO), 0) FROM MOVIMENTO_MANUAL WHERE DAT_MES = @mes AND DAT_ANO = @ano";

            var numeroLancamento = 1;

            using (SqlConnection connection = Conexao.SqlConnection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@mes", mes);
                command.Parameters.AddWithValue("@ano", ano);

                try
                {
                    connection.Open();
                    object scalar = command.ExecuteScalar();
                    numeroLancamento = (int)scalar;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Concat("ERROR: ", ex.Message));
                }
            }

            return numeroLancamento;
        }

    }
}
