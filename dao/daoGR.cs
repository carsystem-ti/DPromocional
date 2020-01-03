using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
namespace DPromocional.dao
{
    public class daoGR
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxDpromocional"] as ConnectionStringSettings;
        public DataTable pro_getQuantitativoCarteira(string _user)
        {
            DataTable dt_Consultores = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GetRegistros]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TP", 11);
                        cmd.Parameters.AddWithValue("@GR", _user);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_Consultores.Clear();
                        da.Fill(dt_Consultores);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_Consultores;
        }
        public DataTable pro_getConsultores(string user)
        {
            DataTable dt_Consultores = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GetRegistros]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TP",2);
                        cmd.Parameters.AddWithValue("@GR",user);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_Consultores.Clear();
                        da.Fill(dt_Consultores);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_Consultores;
        }
        public bool GravaIndicador(int indicador, string atendente)
        {
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[pro_DIP_GravaGR]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NrInd", indicador);
                        cmd.Parameters.AddWithValue("@cdGr", atendente);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return true;
        }
    }
}