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
    public class daoPedidoVendaItens
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int _idPedido { get; set; }
        public string _idproduto { get; set; }
        public double _valorProduto { get; set; }
        public int _qtQuantidade { get; set; }
        public double _vlDesconto { get; set; }
        public int pro_setPedidoVendaItens()
        {
            int nr_pedidoItens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompraItens]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido", _idPedido);
                        cmd.Parameters.AddWithValue("@id_produto", _idproduto);
                        cmd.Parameters.AddWithValue("@vlProduto",_valorProduto);
                        //cmd.Parameters.AddWithValue("@qt_item",_qtQuantidade);
                        cmd.Parameters.AddWithValue("@vl_desconto",_vlDesconto);
                        nr_pedidoItens = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedidoItens;
        }
    }
}