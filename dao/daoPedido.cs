using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace DPromocional.dao
{
    public class daoPedido
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int pro_setPedido(int _franquia, string _dsusuario, string _nrcep, string _nrEndereco, string _dsEndereco, string _dsComplemento, string _dsBairro, string _dsCidade, int _tpEntrega, string _Observacao, string _dsUF, string _Obs)
        {
            int nr_retorno = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedido]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idFranquia", _franquia);
                        cmd.Parameters.AddWithValue("@usuarioPedido", _dsusuario);
                        cmd.Parameters.AddWithValue("@cep", _nrcep);
                        cmd.Parameters.AddWithValue("@ds_endereco", _dsEndereco);
                        cmd.Parameters.AddWithValue("@ds_complemento", _dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_Bairro", _dsBairro);
                        cmd.Parameters.AddWithValue("@nr_Endereco", _nrEndereco);
                        cmd.Parameters.AddWithValue("@ds_cidade", _dsCidade);
                        cmd.Parameters.AddWithValue("@ds_uf", _dsUF);
                        cmd.Parameters.AddWithValue("@tpEntrega", _tpEntrega);
                        cmd.Parameters.AddWithValue("@ds_Obs", _Obs);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_retorno;
        }
        public DataTable pro_getPedidos(int _status)
        {
            DataTable dt_data = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_getPedidosStatus]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", _status);
                        //cmd.Parameters.AddWithValue("@dataInicial", dt_inicial);
                        //cmd.Parameters.AddWithValue("@dataFinal", dt_final);
                        // cmd.Parameters.AddWithValue("@idfranquia", idFranquia);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_data.Clear();
                        da.Fill(dt_data);
                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_data;
        }
        public DataTable pro_getFiltroPedidos(int status, int idFranquia)
        {
            DataTable dt_data = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getFiltroPedidos", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idfranquia", idFranquia);
                        cmd.Parameters.AddWithValue("@status", status);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt_data.Clear();
                        da.Fill(dt_data);

                    }
                }
                catch (SqlException ex)
                {
                    throw new global::System.Data.StrongTypingException("'Procure o Administrador'", ex);
                }
            }
            return dt_data;
        }
        public int pro_setAlteraStatus(int _pedido, int _status)
        {
            int nr_altera = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setAlteraStatus]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", _pedido);
                        cmd.Parameters.AddWithValue("@status", _status);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_altera = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_altera;
        }
        public int pro_setVinculaNota(int _pedido, int _Nrnota)
        {
            int nr_altera = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setVinculaNota]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pedido", _pedido);
                        cmd.Parameters.AddWithValue("@nr_nota", _Nrnota);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        nr_altera = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_altera;
        }
    }
}