using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional
{
    public partial class Relatorio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMes.SelectedIndex = DateTime.Now.Month - 1;
                txtAno.Text = DateTime.Now.Year.ToString();

                if (((AcessoLogin)Session["acessoLogin"]).idFranquia == -1)
                {
                    ddlFranquia.Visible = true;
                    daoRelatorio DaoRelatorio = new daoRelatorio();
                    ddlFranquia.DataSource = DaoRelatorio.getFranquias(16);
                    ddlFranquia.DataValueField = "id_franquia";
                    ddlFranquia.DataTextField = "ds_franquia";
                    ddlFranquia.DataBind();

                    lbFranquia.Visible = true;
                }
            }
            lbMensErro.Visible = false;
        }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            daoRelatorio DaoRelatorio = new daoRelatorio();
            try
            {
                AcessoLogin acessoLogin = ((AcessoLogin)Session["acessoLogin"]);

                if (acessoLogin.idFranquia == -1)
                    Session["FranquiaRel"] = ddlFranquia.SelectedValue;
                else
                    Session["FranquiaRel"] = acessoLogin.idFranquia;


                Object dAjusteCredito;
                Object dDescontosDiversos;
                Object dDebitosGerais;
                Object dCreditosGerais;

                gridSintetico.DataSource = DaoRelatorio.getSintetico(Convert.ToInt32(Session["FranquiaRel"]), ddlMes.SelectedIndex + 1, Convert.ToInt32(txtAno.Text), out dAjusteCredito, out dDescontosDiversos, out dDebitosGerais, out dCreditosGerais);
                gridSintetico.DataBind();

                gridSinteticoAjusteCre.DataSource = dAjusteCredito;
                gridSinteticoAjusteCre.DataBind();

                gridSinteticoAjusteDeb.DataSource = dDescontosDiversos;
                gridSinteticoAjusteDeb.DataBind();

                gridSinteticoDebitos.DataSource = dDebitosGerais;
                gridSinteticoDebitos.DataBind();

                gridSinteticoCreditos.DataSource = dCreditosGerais;
                gridSinteticoCreditos.DataBind();

                lbTotAjusteCredito.Text = DaoRelatorio.totAjusteCredito;
                lbTotAjusteDebito.Text = DaoRelatorio.totAjusteDebito;

                lbComissoes.Text = DaoRelatorio.totComissoes;
                lbCredito.Text = DaoRelatorio.totCredito;

                lbTitulo.Text = "RELATÓRIO DE COMISSÕES  -  Franquia  - " + DaoRelatorio.nomeFranquia;
                lbPeriodo.Text = "Período de apuração " + DaoRelatorio.periodo;                               

                lbSaldo.Text = DaoRelatorio.totGeral;                

                pnAnalitico.Visible = false;
                pnAnaliticoAjusteCredito.Visible = false;
                pnSintetico.Visible = true;
                pnTitulo.Visible = true;
            }
            catch (Exception ex)
            {
                ShowMensagem(ex.Message);
            }
        }

        protected void gridSintetico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "analitico")
            {
                try
                {
                    daoRelatorio DaoRelatorio = new daoRelatorio();
                    GridViewRow row = gridSintetico.Rows[Convert.ToInt32(e.CommandArgument)];
                    HiddenField idAgenda = (HiddenField)gridSintetico.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");
                    DataTable dtPoliticaVenda = DaoRelatorio.getAnaliticoPoliticaVenda(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                    gridVendaPolitica.DataSource = dtPoliticaVenda;
                    gridVendaPolitica.DataBind();

                    Session.Add("RelPedidos", dtPoliticaVenda);

                    decimal totVlUnitario = 0;
                    decimal totVlDesconto = 0;
                    decimal totVlBaseCom = 0;
                    decimal totVlComissao = 0;

                    calcSubTotal(gridVendaPolitica.FooterRow, dtPoliticaVenda, ref totVlUnitario, ref totVlDesconto, ref totVlBaseCom, ref totVlComissao);

                    lbTotValor.Text = totVlUnitario.ToString("###,###,##0.00");
                    lbTotDesconto.Text = totVlDesconto.ToString("###,###,##0.00");
                    lbTotPerDesc.Text = ((totVlDesconto * 100) / totVlUnitario).ToString("###,###,##0.00") + '%';
                    lbTotVlCobrado.Text = totVlBaseCom.ToString("###,###,##0.00");
                    lbTotComissao.Text = totVlComissao.ToString("###,###,##0.00");

                    pnAnalitico.Visible = true;
                    pnSintetico.Visible = false;
                    pnAnaliticoAjusteCredito.Visible = false;

                    //lbPeriodoVendaNaoPolitica.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower(); // + " - Vendas fora da Política de Vendas";
                    lbPeriodoVendaPolitica.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower(); // + " - Vendas de acordo com a Política de Vendas";                    
                }
                catch (Exception ex)
                {
                    ShowMensagem(ex.Message);
                }

            }
        }

        protected void gridVendaPolitica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 5;
                e.Row.Cells[0].Text = "SubTotal";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Font.Bold = true;

            }
            else
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToDouble(e.Row.Cells[5].Text) < 0)
                        e.Row.CssClass = "Negativo";
                }
        }

        private void calcSubTotal(GridViewRow linha, DataTable dt, ref decimal totVlUnitario, ref decimal totVlDesconto, ref decimal totVlBaseCom, ref decimal totVlComissao)
        {
            if (dt.Rows.Count > 0)
            {
                decimal auxCalc = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_unitario"));
                totVlUnitario += auxCalc;
                linha.Cells[5].Text = auxCalc.ToString("###,###,##0.00");
                linha.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                decimal totDesconto = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_desconto"));
                totVlDesconto += totDesconto;
                linha.Cells[6].Text = totDesconto.ToString("###,###,##0.00");
                linha.Cells[6].HorizontalAlign = HorizontalAlign.Right;

                linha.Cells[7].Text = ((totDesconto * 100) / auxCalc).ToString("###,###,##0.00") + '%';
                linha.Cells[7].HorizontalAlign = HorizontalAlign.Right;

                auxCalc = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_basecom"));
                totVlBaseCom += auxCalc;
                linha.Cells[8].Text = auxCalc.ToString("###,###,##0.00");
                linha.Cells[8].HorizontalAlign = HorizontalAlign.Right;

                auxCalc = dt.AsEnumerable().Sum(x => x.Field<decimal>("vl_comissao"));
                totVlComissao += auxCalc;
                linha.Cells[10].Text = auxCalc.ToString("###,###,##0.00");
                linha.Cells[10].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        private void ShowMensagem(string mens)
        {
            lbMensErro.Text = "Erro: " + mens;
            lbMensErro.Visible = true;
            pnSintetico.Visible = false;
            pnAnalitico.Visible = false;
        }

        protected void gridSinteticoAjusteCre_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "analitico")
            {
                try
                {
                    daoRelatorio DaoRelatorio = new daoRelatorio();
                    GridViewRow row;
                    HiddenField idAgenda;
                    if (e.CommandSource == gridSinteticoAjusteCre)
                    {
                        row = gridSinteticoAjusteCre.Rows[Convert.ToInt32(e.CommandArgument)];
                        idAgenda = (HiddenField)gridSinteticoAjusteCre.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");
                    }
                    else
                    {
                        row = gridSinteticoAjusteDeb.Rows[Convert.ToInt32(e.CommandArgument)];
                        idAgenda = (HiddenField)gridSinteticoAjusteDeb.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("idAgenda");
                    }
                    
                    DataTable dtAjusteCre = DaoRelatorio.getAnaliticoAjusteCredito(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                    gridAnaliticoAjusteCredito.DataSource = dtAjusteCre;
                    gridAnaliticoAjusteCredito.DataBind();

                    decimal auxCalc = dtAjusteCre.AsEnumerable().Sum(x => x.Field<decimal>("valor"));
                    gridAnaliticoAjusteCredito.FooterRow.Cells[0].Text = auxCalc.ToString("###,###,##0.00");
                    gridAnaliticoAjusteCredito.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;

                    pnAnalitico.Visible = false;
                    pnSintetico.Visible = false;
                    pnAnaliticoAjusteCredito.Visible = true;
                }
                catch (Exception ex)
                {
                    ShowMensagem(ex.Message);
                }

            }
        }

        protected void imgrelatorio_Click(object sender, ImageClickEventArgs e)
        {

            exportarExcelAnalitico();

            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=Relatorio.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/Relatorio.xls";

            //StringWriter stringWrite = new StringWriter();
            //HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            //gridVendaPolitica.RenderControl(htmlWrite);

            //Response.Write(stringWrite.ToString());
            //Response.End();

        }

        private void exportarExcelAnalitico()
        {

            DataTable dtrelexport = new DataTable();
            //BuscaDados();
            string nomeRelatorio = "Relatorio";
            dtrelexport.Columns.Add("dt_geracao", typeof(string));
            dtrelexport.Columns.Add("ds_vendedor", typeof(string));
            dtrelexport.Columns.Add("nr_contrato", typeof(string));
            dtrelexport.Columns.Add("id_pedido", typeof(string));
            dtrelexport.Columns.Add("ds_produto", typeof(string));
            dtrelexport.Columns.Add("vl_unitario", typeof(string));
            dtrelexport.Columns.Add("vl_desconto", typeof(string));
            dtrelexport.Columns.Add("pc_desconto", typeof(string));
            dtrelexport.Columns.Add("vl_basecom", typeof(string));
            dtrelexport.Columns.Add("tp_pagamento", typeof(string));
            dtrelexport.Columns.Add("vl_comissao", typeof(string));
            dtrelexport.Columns.Add("pc_com", typeof(string));
            dtrelexport.Columns.Add("tp_comissao", typeof(string));
            dtrelexport.Columns.Add("tp_lancamento", typeof(string));
            dtrelexport.Columns.Add("nr_diasCancelamento", typeof(string));
            dtrelexport.Columns.Add("nr_parcelas", typeof(string));
            dtrelexport.Columns.Add("parcela", typeof(string));


            DataTable dt = (Session["RelPedidos"] as DataTable);
            
            dt.Columns.Remove("id_agenda");
            dt.Columns.Remove("TpAgenda");

            dt.Columns["dt_geracao"].ColumnName = "Data";
            dt.Columns["ds_vendedor"].ColumnName = "Vendedor";
            dt.Columns["nr_contrato"].ColumnName = "Contrato";
            dt.Columns["id_pedido"].ColumnName = "CDV";
            dt.Columns["ds_produto"].ColumnName = "Produto";
            dt.Columns["vl_unitario"].ColumnName = "Valor";
            dt.Columns["vl_desconto"].ColumnName = "Desconto";
            dt.Columns["pc_desconto"].ColumnName = "% Desc";
            dt.Columns["vl_basecom"].ColumnName = "Vl cobrado";
            dt.Columns["tp_pagamento"].ColumnName = "Forma";
            dt.Columns["vl_comissao"].ColumnName = "Comissão";
            dt.Columns["pc_com"].ColumnName = "%";
            dt.Columns["tp_comissao"].ColumnName = "Tipo";
            dt.Columns["tp_lancamento"].ColumnName = "D/C";
            dt.Columns["nr_diasCancelamento"].ColumnName = "Nr Dias Canc";
            dt.Columns["nr_parcelas"].ColumnName = "Parcelas";
            dt.Columns["parcela"].ColumnName = "Nr parcelas";

            //Chamando método static, passando DataTable preenchido e nome do arquivo
            ExportarParaExcelAnalitico(dt, nomeRelatorio);
        }
        //Exportando dados da proc para o Ms Excel
        private void ExportarParaExcelAnalitico(DataTable dt_getLeadsAnaliticoPlanilha, string nome)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();

            foreach (DataColumn column in dt_getLeadsAnaliticoPlanilha.Columns)
            {
                context.Response.Write(column.ColumnName + "\t");
            }
            context.Response.Write(Environment.NewLine);

            foreach (DataRow row in dt_getLeadsAnaliticoPlanilha.Rows)
            {
                for (int i = 0; i < dt_getLeadsAnaliticoPlanilha.Columns.Count; i++)
                {
                    context.Response.Write(row[i].ToString().Replace(";", string.Empty) + "\t");
                }
                context.Response.Write(Environment.NewLine);
            }

            context.Response.ContentType = "application/ms-excel";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nome + ".xls");
            context.Response.End();
        }
    }
}