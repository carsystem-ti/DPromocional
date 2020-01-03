using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional
{
    public partial class Vinculacao : System.Web.UI.Page
    {
        private DataTable dtb = null;
        daoPedido bdp = new daoPedido();
        daoFranquia bdf = new daoFranquia();
        daoCompraIds bdi = new daoCompraIds();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFraquias();
                TxtPeca.Focus();
                rdbFiltro.SelectedValue = "1";
                getPedidosAbertos();
            }
        }
        private void MontaDataTable()
        {
            dtb = new DataTable();
            dtb = CriarDataTable();
            Session["pedidos"] = dtb;
            this.GridPedidos.DataSource = ((DataTable)Session["pedidos"]).DefaultView;
        }
        private void GeradorMensagem(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + message + "');", true);
        }
        private void getFraquias()
        {
            DataTable dtFranq = new DataTable();
            dtFranq = bdf.pro_getFranquias();
            if (dtFranq.Rows.Count > 0)
            {
                dropFranquias.DataSource = dtFranq;
                dropFranquias.DataBind();
                dropFranquias.Items.Insert(0, "SELECIONE UMA FRANQUIA");
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

            mDataColumn.ColumnName = "Pedido";

            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "Produto";



            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();

            mDataColumn.DataType = Type.GetType("System.String");

            mDataColumn.ColumnName = "peca";

            mDataTable.Columns.Add(mDataColumn);
            return mDataTable;

        }
        private void Acessos()
        {
            int selecao = Convert.ToInt32(rdbFiltro.SelectedValue);
            switch (selecao)
            {
                case 1:
                    TxtPeca.Focus();
                    // vincular.Visible = true;
                    finalizar.Visible = false;
                    //aceite.Visible = false;
                    break;
                case 2:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    // aceite.Visible = true;
                    break;

                default:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    // aceite.Visible = false;
                    break;
            }
        }
        private void getPedidosAbertos()
        {
            if (rdbFiltro.SelectedValue != "")
            {
                int status = Convert.ToInt32(rdbFiltro.SelectedValue);
                DataTable dt_Pedidos = new DataTable();
                dt_Pedidos = bdp.pro_getPedidos(status);
                if (dt_Pedidos.Rows.Count > 0)
                {
                    lblmensagem.Text = "Total de Processos: " + dt_Pedidos.Rows.Count;
                    GridPedidosAbertos.DataSource = dt_Pedidos;
                    GridPedidosAbertos.DataBind();
                    TxtPeca.Focus();
                    divGrid.Visible = true;
                    Acessos();
                    DivAprovacaoPedido.Visible = false;
                    DivNumeroNota.Visible = false;
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Não existe dados para essa fonte de busca";
                    GeradorMensagem("Não existe dados para essa fonte de busca");
                    GridPedidos.DataBind();
                    vincular.Visible = false;
                    GridPedidosAbertos.DataBind();
                    divGrid.Visible = false;
                    // aceite.Visible = false;
                    DivAprovacaoPedido.Visible = false;
                    DivNumeroNota.Visible = false;
                }

            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Favor preencher todos os dados";
                GridPedidos.DataBind();
                vincular.Visible = false;
                GridPedidosAbertos.DataBind();
                divGrid.Visible = false;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // getPedidosAbertos();
        }

        private void incluirNoDataTable(string incremento, string pedido, string peca, DataTable mTable)
        {
            DataRow linha;
            linha = mTable.NewRow();

            linha["Codigo"] = incremento;
            linha["Pedido"] = pedido;
            linha["peca"] = peca;
            mTable.Rows.Add(linha);
        }
        private void InseriPedido()
        {
            string aleatorio = Guid.NewGuid().ToString().Substring(0, 3);
            if (TxtPeca.Text != "")
            {
                incluirNoDataTable(aleatorio, txtPedido.Text, TxtPeca.Text, (DataTable)Session["pedidos"]);
                this.GridPedidos.DataSource = ((DataTable)Session["pedidos"]).DefaultView;
                this.GridPedidos.DataBind();
                TxtPeca.Text = "";
                TxtPeca.Focus();
            }
        }
        private void ValidaDados()
        {
            if (txtQuantidade.Text != "" && TxtPeca.Text != "")
            {
                if (GridPedidos.Rows.Count > 0)
                {
                    int contador = 0;
                    foreach (GridViewRow row in GridPedidos.Rows)
                    {
                        string peca = row.Cells[2].Text;
                        string PecaInserida = TxtPeca.Text;
                        string pedido = row.Cells[1].Text;
                        if (peca == PecaInserida && pedido == txtPedido.Text)
                        {
                            contador = contador + 1;
                        }
                    }
                    if (contador == 0)
                    {
                        InseriPedido();
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Peça já inserida";
                    }
                }
                else
                {
                    InseriPedido();
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Selecione todas as informações";
            }
        }
        protected void GridPedidos_DataBound(object sender, EventArgs e)
        {
            if (GridPedidos.Rows.Count > 0)
            {
                pedidos.Visible = true;
                int quantidade = Convert.ToInt32(txtQuantidade.Text);
                int quantInserido = Convert.ToInt32(GridPedidos.Rows.Count);
                if (GridPedidos.Rows.Count == quantidade)
                {
                    btnIncluir.Enabled = false;
                    TxtPeca.Enabled = false;
                    finalizar.Visible = true;

                }
                else
                {
                    btnIncluir.Enabled = true;
                    TxtPeca.Enabled = true;
                    finalizar.Visible = false;
                    btnIncluir.Enabled = true;

                }
            }
            else
            {
                pedidos.Visible = false;
                TxtPeca.Enabled = true;
                TxtPeca.Focus();
                btnIncluir.Enabled = true;
                finalizar.Visible = false;
                btnIncluir.Enabled = true;
                //  vincularPecas.Visible = false;
                ////concluir.Visible = false;
            }
            TxtPeca.Focus();
        }
        private void ExcluirLinha(string id)
        {
            for (int i = 1; i <= 1; i++)
            {
                foreach (DataRow linha in ((DataTable)Session["pedidos"]).Rows)
                {
                    if (linha[0].ToString() == id)
                    {
                        linha.Delete();
                        this.GridPedidos.DataSource = ((DataTable)Session["pedidos"]).DefaultView;
                        this.GridPedidos.DataBind();
                        return;
                    }
                }
            }
        }
        protected void GridPedidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridPedidos.Rows[e.RowIndex].Cells[0].Text;
            ExcluirLinha(id);
            TxtPeca.Focus();
        }
        protected void GridPedidosAbertos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GridPedidosAbertos, "Select$" + e.Row.RowIndex);
            }
            TxtPeca.Focus();
        }
        protected void TxtPeca_Load(object sender, EventArgs e)
        {
            //ValidaDados();
            Verificapecas();
        }
        private void Verificapecas()
        {
            if (TxtPeca.Text != "")
            {
                try
                {
                    DataSet ds = new DataSet();
                    string nr_peca = TxtPeca.Text;
                    ds = bdi.pro_getValidaPeca(nr_peca);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string valida = ds.Tables[0].Rows[0]["valida"].ToString();
                        if (valida == "0")
                        {
                            ValidaDados();
                        }
                        else
                        {

                            lblmensagem.Visible = true;
                            lblmensagem.Text = "Peça não pode ser utilizada";
                            GeradorMensagem("Peça não pode ser utilizada");
                        }

                    }
                }
                catch (Exception ex)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = ex.Message.ToString();
                }
            }
        }
        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            //ValidaDados();
            Verificapecas();
            // GeradorMensagem("tetse");
        }
        protected void GridPedidosAbertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selecao = Convert.ToInt32(rdbFiltro.SelectedValue);
            switch (selecao)
            {
                case 1:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    MontaDataTable();
                    GridPedidos.DataBind();
                    break;
                case 2:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    DivAprovacaoPedido.Visible = true;
                    GridPedidos.DataBind();
                    break;
                case 3:
                    txtPedidoCompra.Text = GridPedidosAbertos.SelectedRow.Cells[0].Text;
                    txtPedido.Text = GridPedidosAbertos.SelectedRow.Cells[1].Text;
                    txtQuantidade.Text = GridPedidosAbertos.SelectedRow.Cells[4].Text;
                    GridPedidosAbertos.SelectedRowStyle.BackColor = Color.Green;
                    TxtPeca.Focus();
                    vincular.Visible = true;
                    finalizar.Visible = false;
                    MontaDataTable();
                    GridPedidos.DataBind();
                    DivAprovacaoPedido.Visible = false;

                    GridPedidos.DataBind();
                    break;
                case 5:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    MontaDataTable();
                    GridPedidos.DataBind();
                    DivAprovacaoPedido.Visible = false;
                    DivNumeroNota.Visible = true;

                    break;
                case 7:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    DivNumeroNota.Visible = false;
                    DivAprovacaoPedido.Visible = false;
                    break;

                default:
                    vincular.Visible = false;
                    finalizar.Visible = false;
                    DivNumeroNota.Visible = false;
                    DivAprovacaoPedido.Visible = false;
                    break;
            }

        }
        public class GridDecorator
        {
            public static void MergeRows(GridView gridView)
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];
                    int i = 0;

                    if (row.Cells[i].Text.TrimEnd().TrimStart() == previousRow.Cells[i].Text.TrimEnd().TrimStart())
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                    else
                    {
                        i = 1;
                    }

                }
            }

        }
        protected void btnFinaliza_Click(object sender, EventArgs e)
        {
            if (GridPedidos.Rows.Count > 0)
            {
                foreach (GridViewRow grw in GridPedidos.Rows)
                {
                    if (txtPedido.Text != "" && txtPedidoCompra.Text != "")
                    {
                        try
                        {
                            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                            int itemPedido = Convert.ToInt32(grw.Cells[1].Text);
                            string nr_peca = grw.Cells[2].Text;
                            string usrAnalista = acessoLogin.Nome;
                            int pedido = Convert.ToInt32(txtPedidoCompra.Text);
                            int retorno = bdi.pro_setVinculaPeca(itemPedido, nr_peca, usrAnalista, pedido);
                            if (retorno > 0)
                            {
                                GeradorMensagem("Distribuicao efetuada com sucesso..");
                                GridPedidos.DataBind();
                                vincular.Visible = false;
                                getPedidosAbertos();
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    }
                }
                getPedidosAbertos();
            }
        }

        protected void btnIncluir_Load(object sender, EventArgs e)
        {
            //AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            //trigger.ControlID = "GridPedidosAbertos";
            //trigger.EventName = "SelectedIndexChanging";
            //updFiltro.Triggers.Add(trigger);
            //AsyncPostBackTrigger triggerRow = new AsyncPostBackTrigger();
            //triggerRow.ControlID = "GridPedidosAbertos";
            //triggerRow.EventName = "RowDataBound";
            //updFiltro.Triggers.Add(triggerRow);
            //AsyncPostBackTrigger triggerUpdati = new AsyncPostBackTrigger();
            //triggerUpdati.ControlID = "GridPedidosAbertos";
            //triggerUpdati.EventName = "RowUpdating";
            //updFiltro.Triggers.Add(triggerUpdati);

            //AsyncPostBackTrigger triggerButton = new AsyncPostBackTrigger();
            //triggerButton.ControlID = "btnBuscar";
            //triggerButton.EventName = "Click";
            //updFiltro.Triggers.Add(triggerButton);
        }

        protected void btnBuscar_Load(object sender, EventArgs e)
        {
            //AsyncPostBackTrigger triggerButton = new AsyncPostBackTrigger();
            //triggerButton.ControlID = "btnIncluir";
            //triggerButton.EventName = "Click";
            //updFiltro.Triggers.Add(triggerButton);
        }

        protected void GridPedidosAbertos_PreRender(object sender, EventArgs e)
        {
            GridDecorator.MergeRows(GridPedidosAbertos);

        }

        protected void rdbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPedidosAbertos();
        }
        private void AtualizaStatus(int status)
        {
            try
            {
                int pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
                int retorno = bdp.pro_setAlteraStatus(pedido, status);
                if (retorno > 0)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Pedido alterado para aceita.";
                    getPedidosAbertos();
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Não foi possível altera";
                }
            }
            catch (Exception ex)
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = ex.Message.ToString();
            }
        }
        protected void btnAprovarPedido_Click(object sender, EventArgs e)
        {
            AtualizaStatus(3);
        }

        protected void btnReprovarPedido_Click(object sender, EventArgs e)
        {
            AtualizaStatus(4);
        }
        private void VinculaNota()
        {
            if (txtNrNota.Text != "")
            {
                int retorno = 0;
                int nr_nota = Convert.ToInt32(txtNrNota.Text);
                int pedido = Convert.ToInt32(GridPedidosAbertos.SelectedRow.Cells[0].Text);
                retorno = bdp.pro_setVinculaNota(pedido, nr_nota);
                if (retorno > 0)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Nota vinculada com sucesso";
                    DivNumeroNota.Visible = true;
                    getPedidosAbertos();
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Não foi possível executar essa tarefa.";
                    DivNumeroNota.Visible = true;

                }
            }
        }
        protected void btnVincularNota_Click(object sender, EventArgs e)
        {
            VinculaNota();
        }
    }
}