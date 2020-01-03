using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DPromocional.dao
{
    public class daoPagamentosLiberacoes : Dados
    {
        private void verificaCampos(DataTable dtAux)
        {
            if (dtAux.Columns.Contains("nr_cpf_cnpj"))
                dtAux.Columns["nr_cpf_cnpj"].ColumnName = "Documento";

            if (!dtAux.Columns.Contains("CodGR"))
                dtAux.Columns.Add("CodGR");
        }

        public DataTable getContrato(string contrato)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@contratoCliente", contrato),
                                                    new SqlParameter("@documento", DBNull.Value),
                                                    new SqlParameter("@placaVeiculo", DBNull.Value),
                                                    new SqlParameter("@nomeIndicador", DBNull.Value)
                                            };
                DataTable dtAux = getDataTableProc("cnxDpromocional", "DinheiroP.pro_getIndicador", parametros);

                verificaCampos(dtAux);

                return dtAux;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getPlaca(string placa)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@contratoCliente", DBNull.Value),
                                                    new SqlParameter("@documento", DBNull.Value),
                                                    new SqlParameter("@placaVeiculo", placa),
                                                    new SqlParameter("@nomeIndicador", DBNull.Value)
                                            };
                DataTable dtAux = getDataTableProc("cnxDpromocional", "DinheiroP.pro_getIndicador", parametros);

                verificaCampos(dtAux);

                return dtAux;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getCPFCNPJ(string CPFCNPJ)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                new SqlParameter("@documento", CPFCNPJ),    
                                                new SqlParameter("@contratoCliente", DBNull.Value),                                                    
                                                new SqlParameter("@placaVeiculo", DBNull.Value),
                                                new SqlParameter("@nomeIndicador", DBNull.Value)
                                            };
                DataTable dtAux = getDataTableProc("cnxDpromocional", "DinheiroP.pro_getIndicador", parametros);

                verificaCampos(dtAux);

                return dtAux;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getIndicador(string indicador)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@contratoCliente", DBNull.Value),
                                                    new SqlParameter("@documento", DBNull.Value),
                                                    new SqlParameter("@placaVeiculo", DBNull.Value),
                                                    new SqlParameter("@nomeIndicador", indicador)
                                            };
                DataTable dtAux = getDataTableProc("cnxDpromocional", "DinheiroP.pro_getIndicador", parametros);

                verificaCampos(dtAux);

                return dtAux;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getCarteira(string codigo)
        {
            try
            {
                SqlParameter[] parametros = {                                                     
                                                    new SqlParameter("@gerenteRelac", codigo)
                                            };
                DataTable dtResult = getDataTableProc("cnxDpromocional", "DinheiroP.pro_getPorCarteira", parametros);
                dtResult.Columns["Codigo"].ColumnName = "Código";
                dtResult.Columns["Indicador"].ColumnName = "Nome";
                dtResult.Columns["ds_indicacao"].ColumnName = "CodGr";               

                return dtResult;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getProximosDias()
        {
            try
            {
                DataTable dtResult = getDataTableProc("cnxDpromocional", "DinheiroP.pro_getProximosDias", null);
                dtResult.Columns[0].ColumnName = "Código";
                dtResult.Columns[1].ColumnName = "Nome";
                dtResult.Columns.Add("Contrato");
                dtResult.Columns.Add("CodGr");
                return dtResult;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getValoresIndicacoes(int codigo)
        {
            try
            {
                SqlParameter[] parametros = {                                                     
                                                    new SqlParameter("@codigoIndicador", codigo)
                                            };
                return getDataTableProc("cnxDpromocional", "DinheiroP.pro_getIndicados", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getDebitos(int codigo)
        {
            try
            {
                SqlParameter[] parametros = {                                                     
                                                    new SqlParameter("@codigoIndicador", codigo)
                                            };
                return getDataTableProc("cnxDpromocional", "DinheiroP.pro_getDebitosIndicador", parametros);
            }
            catch
            {
                throw;
            }
        }

        public void setAtualizaContratoConfirmado(string contrato)
        {
            SqlParameter[] parametros = {                                                     
                                             new SqlParameter("@numeroContrato", contrato)
                                        };
            try
            {
                ExecNonQuery("cnxDpromocional", "DinheiroP.pro_AtualizaContratoConfirmado", parametros);
            }
            catch
            {
                throw;
            }
        }
    }
}