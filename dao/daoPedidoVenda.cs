using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DPromocional.dao
{
    public class daoPedidoVenda
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        #region Atributos
        
        public int id_consulta { get; set; }
        public int _id_franquia { get; set; }
        public int _id_vendedor { get; set; }
        public string _ds_nome { get; set; }
        public string _tpCliente { get; set; }
        public string _nrCep { get; set; }
        public string _endereco { get; set; }
        public string _nrEndereco { get; set; }
        public string _dsComplemento { get; set; }
        public string _dsBairro { get; set; }
        public string _dsCidade { get; set; }
        public string _dsUf { get; set; }
        public string _dsDocumento { get; set; }
        public string _ddTel { get; set; }
        public string _nrTel { get; set; }
        public string _ddcel { get; set; }
        public string _nrCel { get; set; }
        public string _ddCom { get; set; }
        public string _nrCom { get; set; }
        #endregion 

        public int pro_setPedidoVenda()
        {
            int nr_pedido = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setPedidoCompra]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idFranquia", _id_franquia);
                        cmd.Parameters.AddWithValue("@id_vendedor",_id_vendedor);
                        cmd.Parameters.AddWithValue("@ds_nome",_ds_nome);
                        cmd.Parameters.AddWithValue("@tp_cliente",_tpCliente);
                        cmd.Parameters.AddWithValue("@nr_cep",_nrCep);
                        cmd.Parameters.AddWithValue("@ds_endereco",_endereco);
                        cmd.Parameters.AddWithValue("@nr_endereco",_nrEndereco);
                        cmd.Parameters.AddWithValue("@ds_complemento",_dsComplemento);
                        cmd.Parameters.AddWithValue("@ds_bairro",_dsBairro);
                        cmd.Parameters.AddWithValue("@ds_cidade",_dsCidade);
                        cmd.Parameters.AddWithValue("@ds_uf",_dsUf);
                        cmd.Parameters.AddWithValue("@ds_documento",_dsDocumento);
                        cmd.Parameters.AddWithValue("@ddTel",_ddTel);
                        cmd.Parameters.AddWithValue("@nr_Tel",_nrTel);
                        cmd.Parameters.AddWithValue("@dddCel",_ddcel);
                        cmd.Parameters.AddWithValue("@nr_Cel",_nrCel);
                        cmd.Parameters.AddWithValue("@dddComercial",_ddCom);
                        cmd.Parameters.AddWithValue("@nr_Comercial",_nrCom);
                        nr_pedido = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return nr_pedido;
        }
    }
}