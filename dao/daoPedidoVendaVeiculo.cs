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
    public class daoPedidoVendaVeiculo
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        #region Atributos Veiculos
        public int _idPedido { get; set; }
        public int _idItem { get; set; }
        public int _idmodelo { get; set; }
        public string _dsplaca { get; set; }
        public string _dsCor { get; set; }
        public string _dsCombustivel { get; set; }
        public string _dsAno { get; set; }
        public string _dsRenavan { get; set; }
        public string _dsChassi { get; set; }
        public string _anoVeiculo { get; set; }
        public int _tipoveiculo { get; set; }
        #endregion

        public int pro_setPedidoVendaVeiculo()
        {
            int nr_pedidoVeiculo = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompraVeiculo]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido", _idPedido);
                        cmd.Parameters.AddWithValue("@id_item", _idItem);
                        cmd.Parameters.AddWithValue("@id_modelo", _idmodelo);
                        cmd.Parameters.AddWithValue("@ds_placa", _dsplaca);
                        cmd.Parameters.AddWithValue("@ds_cor", _dsCor);
                        cmd.Parameters.AddWithValue("@ds_combustivel", _dsCombustivel);
                        cmd.Parameters.AddWithValue("@ds_ano", _dsAno);
                        cmd.Parameters.AddWithValue("@ds_Renavan", _dsRenavan);
                        cmd.Parameters.AddWithValue("@ds_Chassi", _dsChassi);
                        nr_pedidoVeiculo = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedidoVeiculo;
        }
    }
}