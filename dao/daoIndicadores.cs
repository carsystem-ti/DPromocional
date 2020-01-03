using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DPromocional.dao
{
    public class daoIndicadores : Dados
    {
        public daoIndicadores()
        {
        }

        public DataTable getIndicadores(string codigo)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@TP", "5"),
                                                    new SqlParameter("@GR", codigo)
                                            };
                return getDataTableProc("cnxDpromocional", "DinheiroP.pro_GetRegistros", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getIndicacao(string codigo, string codIndicador)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@TP", "6"),
                                                    new SqlParameter("@GR", codigo),
                                                    new SqlParameter("@ID", codIndicador)
                                            };
                return getDataTableProc("cnxDpromocional", "DinheiroP.pro_GetRegistros", parametros);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getAgenda(string codigo)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@TP", "7"),
                                                    new SqlParameter("@GR", codigo)
                                            };
                return getDataTableProc("cnxDpromocional", "DinheiroP.pro_GetRegistros", parametros);
            }
            catch
            {
                throw;
            }
        }

        public void setEnviaCRM(string codIndicador)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@cd_CT", "1"),
                                                    new SqlParameter("@id_indicacao", codIndicador)
                                            };
                ExecNonQuery("cnxDpromocional", "Principal..Proc_REP_CT_Grava_Leads_DP", parametros);
            }
            catch
            {
                throw;
            }
        }

        public void setCancelaCRM(string codIndicador)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@TP", "1"),                                                    
                                                    new SqlParameter("@NrInd", codIndicador),
                                                    new SqlParameter("@CdSta","3")
                                            };
                ExecNonQuery("cnxDpromocional", "DinheiroP.pro_AtualizaIndicacao", parametros);
            }
            catch
            {
                throw;
            }
        }

        public void setGravaAgenda(string codIndicador, DateTime data)
        {
            try
            {
                SqlParameter[] parametros = { 
                                                    new SqlParameter("@id_ind", Convert.ToInt32(codIndicador)),                                                    
                                                    new SqlParameter("@dt_Age", data)
                                            };
                ExecNonQuery("cnxDpromocional", "DinheiroP.pro_GravaAgenda", parametros);
            }
            catch
            {
                throw;
            }
        }
    }

}