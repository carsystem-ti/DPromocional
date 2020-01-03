using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional
{
    public partial class Produtos : System.Web.UI.Page
    {
        private DataTable dtb = null;
        daoProdutos bdp = new daoProdutos();
        daoFranquia bdf = new daoFranquia();
        daoPedido bdpi = new daoPedido();
        daoPedidoItens bditens = new daoPedidoItens();
        int processo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtb = new DataTable();
                dtb = CriarDataTable();
                Session["produtos"] = dtb;
                this.GridProdutos.DataSource = ((DataTable)Session["produtos"]).DefaultView;
                getProdutos();

            }
            if (!ClientScript.IsStartupScriptRegistered(GetType(), "MaskedEditFix"))
            {
                ClientScript.RegisterStartupScript(GetType(), "MaskedEditFix", String.Format("<script type='text/javascript' src='{0}'></script>", Page.ResolveUrl("MaskedEditFix.js")));
            }
        }
        private void BuscaMensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void getProdutos()
        {
            DataSet dsProdutos = new DataSet();
            dsProdutos = bdp.pro_getProdutos();
            if (dsProdutos.Tables.Count > 0)
            {
                dropProduto.DataSource = dsProdutos;
                dropProduto.DataBind();
                dropProduto.Items.Insert(0, "Selecione o produto");
            }

        }
        public DataTable CriarDataTable()
        {
            DataTable mDataTable = new DataTable();

            DataColumn mDataColumn;



            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "Codigo";

            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "Produto";



            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "Qtde";

            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "VL.Unitário";

            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "VL.Total";

            mDataTable.Columns.Add(mDataColumn);

            return mDataTable;

        }
        private void incluirNoDataTable(string incremento, string produto, string quantidade, string vlUnitario, string vlTotal, DataTable mTable)
        {
            DataRow linha;
            linha = mTable.NewRow();

            linha["Codigo"] = incremento;
            linha["produto"] = produto;
            linha["Qtde"] = quantidade;
            linha["VL.Unitário"] = vlUnitario;
            linha["VL.Total"] = vlTotal;

            mTable.Rows.Add(linha);
        }
        private void InseriProdutos()
        {
            incluirNoDataTable(dropProduto.SelectedValue, dropProduto.SelectedItem.Text, dropQuantidade.SelectedValue, TxtvlUnitario.Text, txtTotal.Text.Replace(".", ""), (DataTable)Session["produtos"]);
            this.GridProdutos.DataSource = ((DataTable)Session["produtos"]).DefaultView;
            this.GridProdutos.DataBind();
            lblmensagem.Visible = true;
            lblmensagem.Text = "Produto:" + dropProduto.SelectedItem.Text + " adicionado com sucesso";
        }
        private void CadastrarProdutos()
        {
            if (dropProduto.SelectedValue != "" && txtTotal.Text != "" && TxtvlUnitario.Text != "" && txtTotal.Text != "0,00")
            {
                if (GridProdutos.Rows.Count > 0)
                {
                    int contador = 0;
                    foreach (GridViewRow rows in GridProdutos.Rows)
                    {
                        string cd_Produto = rows.Cells[0].Text;
                        if (cd_Produto == dropProduto.SelectedValue)
                        {
                            contador = contador + 1;
                        }

                    }
                    if (contador == 0)
                    {
                        InseriProdutos();
                    }
                    else
                    {
                        // lblmensagem.Visible = true;
                        Mensagem("Produto já esta adicionado na compra");
                    }
                }
                else
                {
                    InseriProdutos();
                }

            }
            else
            {
                //lblmensagem.Visible = true;
                Mensagem("Favor selecionar todas as informações...");
            }
        }
        private void ExcluirLinha(string id)
        {
            for (int i = 1; i <= 1; i++)
            {
                foreach (DataRow linha in ((DataTable)Session["produtos"]).Rows)
                {
                    if (linha[0].ToString() == id)
                    {
                        linha.Delete();
                        this.GridProdutos.DataSource = ((DataTable)Session["produtos"]).DefaultView;
                        this.GridProdutos.DataBind();
                        return;
                    }
                }
            }
        }
        private void BuscaEndereco()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            DataSet dsEntrega = new DataSet();
            string id_franquia = acessoLogin.Nome.Substring(0, 6);
            dsEntrega = bdf.pro_getEnderecoFranquia(id_franquia);
            if (dsEntrega.Tables[0].Rows.Count > 0)
            {
                txtCep.Text = dsEntrega.Tables[0].Rows[0]["nr_cep"].ToString();
                TxtEndereco.Text = dsEntrega.Tables[0].Rows[0]["ds_endereco"].ToString();
                txtNumero.Text = dsEntrega.Tables[0].Rows[0]["nr_entrega"].ToString();
                txtBairro.Text = dsEntrega.Tables[0].Rows[0]["ds_bairro"].ToString();
                txtCidade.Text = dsEntrega.Tables[0].Rows[0]["ds_cidade"].ToString();
                txtUf.Text = dsEntrega.Tables[0].Rows[0]["ds_uf"].ToString();
                txtComplemento.Text = dsEntrega.Tables[0].Rows[0]["ds_complemento"].ToString();

            }

        }
        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            CadastrarProdutos();
        }
        protected void GridProdutos_DataBound(object sender, EventArgs e)
        {
            if (GridProdutos.Rows.Count > 0)
            {
                produtos.Visible = true;
                BuscaEndereco();
                endereco.Visible = true;
            }
            else
            {
                produtos.Visible = false;
                endereco.Visible = false;
            }
        }
        protected void GridProdutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridProdutos.Rows[e.RowIndex].Cells[0].Text;
            ExcluirLinha(id);
        }
        protected void dropProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tpProduto = dropProduto.SelectedValue;
            switch (tpProduto)
            {
                case "Selecione o produto":
                    //  lblmensagem.Visible = true;
                    Mensagem("DIGITE UM PRODUTO");
                    btnIncluir.Visible = false;
                    break;

                default:
                    DataSet ds_valor = new DataSet();
                    ds_valor = bdp.pro_getvlProduto(dropProduto.SelectedValue);
                    if (ds_valor.Tables.Count > 0)
                    {
                        double valor = Convert.ToDouble(ds_valor.Tables[0].Rows[0]["vl_compraFranquia"].ToString());
                        TxtvlUnitario.Text = valor.ToString("N2");
                        btnIncluir.Visible = true;
                        CalculaValores();
                    }
                    break;
            }
        }
        private void CalculaValores()
        {
            if (dropProduto.SelectedValue != "Selecione o produto")
            {
                int quantidade = Convert.ToInt32(dropQuantidade.SelectedValue);
                double vl_valor = Convert.ToDouble(TxtvlUnitario.Text);
                double total = quantidade * vl_valor;
                txtTotal.Text = total.ToString("N2");
                btnIncluir.Visible = true;
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Selecione um produto";
                btnIncluir.Visible = false;
                txtTotal.Text = "";
            }
        }
        protected void dropQuantidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropQuantidade.SelectedValue != "0")
            {
                CalculaValores();
            }
            else
            {
                txtTotal.Text = "";
                btnIncluir.Visible = false;
            }
        }
        protected void GridProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridProdutos.Rows.Count > 0)
            {
                double SomaUnitario = 0;
                double SomaGeral = 0;
                int total = 0;
                foreach (GridViewRow row in GridProdutos.Rows)
                {
                    if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                    {
                        int quant = Convert.ToInt32(row.Cells[2].Text);
                        double valorrecebido = Convert.ToDouble(row.Cells[3].Text);
                        double valorgeral = Convert.ToDouble(row.Cells[4].Text);

                        if (row.Cells[3].Text != "")
                        {
                            SomaUnitario += valorrecebido;
                            SomaGeral += valorgeral;
                            total += quant;
                            if (e.Row.RowType == DataControlRowType.Footer)
                            {
                                e.Row.Cells[1].Text = "Total";
                                e.Row.Cells[2].Text = total.ToString();
                                e.Row.Cells[3].Text = SomaUnitario.ToString("N2").Replace(".", "");
                                e.Row.Cells[4].Text = SomaGeral.ToString("N2").Replace(".", "");

                            }
                        }
                    }
                }

            }
            
        }
        private void GravaPedido()
        {
            if (txtCep.Text != "" && TxtEndereco.Text != "" && txtComplemento.Text != "" && txtBairro.Text != "" && txtNumero.Text != "" && txtCidade.Text != "" && txtCidade.Text != "")
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                int id_franquia = acessoLogin.idFranquia;
                string usuario = acessoLogin.Nome;
                string cep = txtCep.Text;
                string ds_endereco = TxtEndereco.Text;
                string ds_complemento = txtComplemento.Text;
                string ds_bairro = txtBairro.Text;
                string nr_endereco = txtNumero.Text;
                string ds_cidade = txtCidade.Text;
                string ds_uf = txtUf.Text;
                int tpEntrega = Convert.ToInt32("1");
                string ds_Obs = txtobs.Text;

                processo = bdpi.pro_setPedido(id_franquia, usuario, cep, nr_endereco, ds_endereco, ds_complemento, ds_bairro, ds_cidade, tpEntrega, ds_Obs, ds_uf, ds_Obs);
                if (processo > 0)
                {
                    GravaItens(processo);
                }
                else
                {
                    // lblmensagem.Visible = true;
                    Mensagem("Não foi possível gravar dados,verifique as informações digitadas");
                }
            }
            else
            {
                // lblmensagem.Visible = true;
                Mensagem("Favor preencher todos os dados..");
            }
        }
        private void GravaItens(int Pedido)
        {
            if (GridProdutos.Rows.Count > 0)
            {
                foreach (GridViewRow row in GridProdutos.Rows)
                {
                    try
                    {
                        string produto = row.Cells[0].Text;
                        double vl_unitario = Convert.ToDouble(row.Cells[3].Text);
                        int quantidade = Convert.ToInt32(row.Cells[2].Text);
                        int ret = bditens.pro_setPedido(Pedido, produto, vl_unitario, quantidade);
                        if (ret > 0)
                        {
                            //lblmensagem.Visible = true;
                            //lblmensagem.Text = "Compra finalizada com sucesso";
                            BuscaMensagem("PEDIDO GERADO COM SUCESSO N:" + processo);
                        }
                        else
                        {
                            lblmensagem.Visible = true;
                            lblmensagem.Text = "Erro Tente novamente.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = ex.Message.ToString();
                    }
                }
            }
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            GravaPedido();
        }
        private void BuscaCep()
        {
            if (txtCep.Text != "")
            {
                DataSet ds_cep = new DataSet();
                string nr_cep = txtCep.Text;
                ds_cep = bdp.pro_getCep(nr_cep);
                if (ds_cep.Tables[0].Rows.Count > 0)
                {
                    TxtEndereco.Text = ds_cep.Tables[0].Rows[0]["Rua"].ToString();
                    txtBairro.Text = ds_cep.Tables[0].Rows[0]["Bairro"].ToString();
                    txtCidade.Text = ds_cep.Tables[0].Rows[0]["Cidade"].ToString();
                    txtUf.Text = ds_cep.Tables[0].Rows[0]["Estado"].ToString();
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                }
                else
                {
                    BuscaMensagem("CEP NÃO ENCONTRADO");
                    TxtEndereco.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtUf.Text = "";
                    txtNumero.Text = "";
                }
            }
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            BuscaCep();
        }

    }
}