using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DPromocional.dao
{
    public class daoSimulador: Dados
    {
        public Object getProdutos()
        {
            try
            {
                DataTable aux = getDataTableProc("cnxDpromocional", "Principal.Franquia.pro_getProdutosSimulador", null);
                var retorno = from row in aux.AsEnumerable()
                          select new {
                              dsProduto = row.Field<String>("dsProduto"),
                              ProdutoMonitoramento = Convert.ToString(row.Field<Decimal?>("Vl_produto")) + ";" + Convert.ToString(row.Field<Decimal?>("Vl_Monitoramento"))
                          };
                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public DataTable getFormaBoleto()
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@ds_FormaPagamento", "Boleto 30 Dias")
                                            };                
                return getDataTableProc("cnxDpromocional", "Principal.Franquia.pro_getFormasDePagamento", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getFormaCheque()
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@ds_FormaPagamento", "Cheque 30/60 Dias")
                                            };
                return getDataTableProc("cnxDpromocional", "Principal.Franquia.pro_getFormasDePagamento", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getFormaCartao()
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@ds_FormaPagamento", "Cartão Crédito")
                                            };
                return getDataTableProc("cnxDpromocional", "Principal.Franquia.pro_getFormasDePagamento", parametros);
            }
            catch
            {
                throw;
            }
        }
        
    }
}