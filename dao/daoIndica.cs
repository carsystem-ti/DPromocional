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
    public class daoIndica
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxDpromocional"] as ConnectionStringSettings;
        public DataTable pro_getIndicadores(string user)
        {
            DataTable dt_Indicadores = new DataTable();
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
                        cmd.Parameters.AddWithValue("@TP", 4);
                        cmd.Parameters.AddWithValue("@GR",user);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_Indicadores.Clear();
                        da.Fill(dt_Indicadores);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_Indicadores;
        }
        public bool GravarIndicados(int indicador,string ds_Contato,string nr_fixo,string nr_celular,string ds_email,string ds_usuarioCadastro,bool retorno)
        {
           
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GravaIndicacao]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_indicador", indicador);
                        cmd.Parameters.AddWithValue("@ds_nome", ds_Contato);
                        cmd.Parameters.AddWithValue("@nr_telefone", nr_fixo);
                        cmd.Parameters.AddWithValue("@nr_celular", nr_celular);
                        cmd.Parameters.AddWithValue("@ds_email", ds_email);
                        cmd.Parameters.AddWithValue("@ds_usu_cadastro", ds_usuarioCadastro);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        retorno=true;
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    retorno=false;
                }
            }
           return  retorno ;
        }
        public bool GravaAgendaIndicadores(int indicador,DateTime dt_agendamento)
        {
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GravaAgendaInd]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Tp", 1);
                        cmd.Parameters.AddWithValue("@NrInd", indicador);
                        cmd.Parameters.AddWithValue("@dt_Age", dt_agendamento);
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
        public DataSet pro_getBancos()
        {
            DataSet ds_Banco= new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GetBancos]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        ds_Banco.Clear();
                        da.Fill(ds_Banco);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return ds_Banco;
        }
        public DataSet pro_RetornaDadosBancarios(int indicador)
        {
            DataSet dsDados = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_GetDados]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tp",3);
                        cmd.Parameters.AddWithValue("@doc", indicador);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsDados.Clear();
                        da.Fill(dsDados);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dsDados;
        }
        public bool AtualizaBancos(int _indicador,string _cd_banco,string _nrAgencia,string _digAgencia,string _dsConta,string _digConta,string _operadora)
        {
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_AtualizaIndicador]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Tp", 2);
                        cmd.Parameters.AddWithValue("@NrInd",_indicador);
                        cmd.Parameters.AddWithValue("@cd_banco",_cd_banco);
                        cmd.Parameters.AddWithValue("@nr_agencia", _nrAgencia);
                        cmd.Parameters.AddWithValue("@nr_agencia_dig", _digAgencia);
                        cmd.Parameters.AddWithValue("@nr_conta", _dsConta);
                        cmd.Parameters.AddWithValue("@nr_conta_dig", _digConta);
                        cmd.Parameters.AddWithValue("@nr_oper", _operadora);
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
        public bool RetiraIndicados(int indicador)
        {
            bool retorno = false;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[DinheiroP].[pro_AtualizaIndicador]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TP", 1);
                        cmd.Parameters.AddWithValue("@NrInd", indicador);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        retorno = true;
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    retorno = false;
                }
            }
            return retorno;
        }
    }
}