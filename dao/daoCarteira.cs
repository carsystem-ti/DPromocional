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
    public class daoCarteira
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxDpromocional"] as ConnectionStringSettings;
        public DataTable pro_getCarteira()
        {
            DataTable dt_Franquias = new DataTable();
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
                        cmd.Parameters.AddWithValue("@TP", 1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_Franquias.Clear();
                        da.Fill(dt_Franquias);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_Franquias;
        }
        public DataTable pro_getContrato(string contrato)
        {
            DataTable dt_Franquias = new DataTable();
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
                        cmd.Parameters.AddWithValue("@TP", 18);
                        cmd.Parameters.AddWithValue("@contrato", contrato);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_Franquias.Clear();
                        da.Fill(dt_Franquias);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_Franquias;
        }
        public DataTable pro_getCpf_Cnpj(string item)
        {
            DataTable dt_Franquias = new DataTable();
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
                        cmd.Parameters.AddWithValue("@TP", 17);
                        cmd.Parameters.AddWithValue("@Cpf_Cnpj", item);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_Franquias.Clear();
                        da.Fill(dt_Franquias);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_Franquias;
        }
        public bool pro_setVinculaIndicador(int codigo,string gr)
        {
    
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GravaGR]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NrInd", codigo);
                        cmd.Parameters.AddWithValue("@cdGr", gr);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return true;
        }
        public bool pro_setRetiraIndicadorGR(string codigo)
        {
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_TrocaGR]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NrInd", Convert.ToInt32(codigo));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return true;
        }
    }
}