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
    public class daoPedidoVendaPagamento
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int _idPedido { get; set; }
        public int _idTipo { get; set; }
        public double _vlPagamento { get; set; }
        public DateTime _dataVenc { get; set; }
        public int _pcParcela { get; set; }
        public string _dsTitular { get; set; }
        public string _nrAgencia { get; set; }
        public string _nrConta { get; set; }
        public string _dsDoc { get; set; }
        public string _nr_cheque { get; set; }
        public string _nrAutorizacao { get; set; }
        public string _nrBanco { get; set; }
        public string _ccm { get; set; }
        public int pro_setPedidoVendaPagamento()
        {
            int nr_pedidoItens = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompraPagamento]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido",_idPedido);
                        cmd.Parameters.AddWithValue("@tp_forma",_idTipo);
                        cmd.Parameters.AddWithValue("@vl_pagamento",_vlPagamento);
                        cmd.Parameters.AddWithValue("@dt_vencimento",_dataVenc);
                        cmd.Parameters.AddWithValue("@pc_pagamento",_pcParcela);
                        cmd.Parameters.AddWithValue("@ds_titular",_dsTitular);
                        cmd.Parameters.AddWithValue("@nragencia",10);
                        cmd.Parameters.AddWithValue("@nr_conta",_nrConta);
                        cmd.Parameters.AddWithValue("@nr_documento",_dsDoc);
                        cmd.Parameters.AddWithValue("@nr_autorizacao",_nrAutorizacao);
                        cmd.Parameters.AddWithValue("@nr_banco",_nrBanco);
                        cmd.Parameters.AddWithValue("@nr_ccm7",_ccm);
                        nr_pedidoItens = cmd.ExecuteNonQuery();
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