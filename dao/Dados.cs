using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DPromocional.dao
{
    public class Dados
    {
        private enum TipoRetorno { Scalar, DataTable, SQLReader, NonQuery }

        private Object ExecSQL(string strConexao, string proc_SQL, SqlParameter[] parametros, CommandType tipoComando, TipoRetorno retorno)
        {
            using (SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings[strConexao].ConnectionString))
            using (SqlCommand command = new SqlCommand(proc_SQL, conexao))
            {
                try
                {
                    command.CommandType = tipoComando;
                    if (parametros != null)
                        command.Parameters.AddRange(parametros);
                    conexao.Open();

                    switch (retorno)
                    {
                        case TipoRetorno.Scalar:
                            return command.ExecuteScalar();

                        case TipoRetorno.DataTable:
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable ds = new DataTable();
                                adapter.Fill(ds);                                
                                return ds;
                            }

                        case TipoRetorno.SQLReader:
                            leReader(command.ExecuteReader());
                            return null;

                        case TipoRetorno.NonQuery:
                            command.ExecuteNonQuery();
                            return null;

                        default:
                            return null;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (conexao.State == ConnectionState.Open)
                        conexao.Close();
                }
            }
        }

        protected virtual void leReader(SqlDataReader dataReader)
        {
            return;
        }

        protected string getValorSQL(string strConexao, string sql, SqlParameter[] parametros)
        {
            try
            {
                return ExecSQL(strConexao, sql, parametros, CommandType.Text, TipoRetorno.Scalar).ToString();
            }
            catch
            {
                throw;
            }
        }
                
        protected string getValorProc(string strConexao, string proc, SqlParameter[] parametros)
        {
            try
            {
                return ExecSQL(strConexao, proc, parametros, CommandType.StoredProcedure, TipoRetorno.Scalar).ToString();
            }
            catch
            {
                throw;
            }
        }

        protected DataTable getDataTableSQL(string strConexao, string SQL)
        {
            try
            {
                return (DataTable)ExecSQL(strConexao, SQL, null, CommandType.Text, TipoRetorno.DataTable);
            }
            catch
            {
                throw;
            }
        }

        protected DataTable getDataTableProc(string strConexao, string proc, SqlParameter[] parametros)
        {
            try
            {
                return (DataTable)ExecSQL(strConexao, proc, parametros, CommandType.StoredProcedure, TipoRetorno.DataTable);
            }
            catch
            {
                throw;
            }
        }

        protected void getDataReaderProc(string strConexao, string proc, SqlParameter[] parametros)
        {
            try
            {
                ExecSQL(strConexao, proc, parametros, CommandType.StoredProcedure, TipoRetorno.SQLReader);
            }
            catch
            {
                throw;
            }
        }

        protected void ExecNonQuery(string strConexao, string proc, SqlParameter[] parametros)
        {
            try
            {
                ExecSQL(strConexao, proc, parametros, CommandType.StoredProcedure, TipoRetorno.NonQuery);
            }
            catch
            {
                throw;
            }
        }
    }
}