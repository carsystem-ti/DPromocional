using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace DPromocional.dao
{
    public class daoCompraIds
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxFranquia"] as ConnectionStringSettings;
        public int pro_setVinculaPeca(int _Item, string _Peca, string UserEnvio, int pedido)
        {
            int nr_item = 0;
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Franquia].[pro_setDistribuicaoPecas]", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPedido", pedido);
                        cmd.Parameters.AddWithValue("@idItensPedido", _Item);
                        cmd.Parameters.AddWithValue("@idPeca", _Peca);
                        cmd.Parameters.AddWithValue("@usuarioAnalista", UserEnvio);
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
        public DataSet pro_getValidaPeca(string _nrPeca)
        {
            DataSet dsPeca = new DataSet();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Franquia.pro_getValidaPeca", conn);
                        cmd.CommandTimeout = 160;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nr_peca", _nrPeca);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dsPeca.Clear();
                        da.Fill(dsPeca);

                    }
                }
                catch (SqlException ex)
                {
                    ex.Message.ToString();
                }
            }
            return dsPeca;
        }
    }
}