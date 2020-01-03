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
    public class daoPedidoItens
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int pro_setPedido(int _Pedido, string _Produto, double _vl_Unitario, int _qtQuantidade)
        {
            int nr_item = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoItens]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido", _Pedido);
                        cmd.Parameters.AddWithValue("@idProduto", _Produto);
                        cmd.Parameters.AddWithValue("@vl_Unitario", _vl_Unitario);
                        cmd.Parameters.AddWithValue("@qtProduto", _qtQuantidade);
                        nr_item = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_item;
        }
        public DataTable pro_getFiltroPedidosItens(int idItem)
        {
            DataTable dt_data = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getItensPedido", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@item", idItem);
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
        public int pro_setAceite(string _id_peca, string _Usuario, int _pedido)
        {
            int nr_item = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_setAceitePeca", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@peca", _id_peca);
                        cmd.Parameters.AddWithValue("@ds_usuario", _Usuario);
                        cmd.Parameters.AddWithValue("@pedido", _pedido);
                        nr_item = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_item;
        }
    }
}