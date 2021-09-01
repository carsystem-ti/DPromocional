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
                    ddlFranquia.DataSource = DaoRelatorio.getFranquias();
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

                    decimal totVlUnitario = 0;
                    decimal totVlDesconto = 0;
                    decimal totVlBaseCom = 0;
                    decimal totVlComissao = 0;
                    calcSubTotal(gridVendaPolitica.FooterRow, dtPoliticaVenda, ref totVlUnitario, ref totVlDesconto, ref totVlBaseCom, ref totVlComissao);

                    dtPoliticaVenda = DaoRelatorio.getAnaliticoForaPoliticaVenda(Convert.ToInt32(Session["FranquiaRel"]), Convert.ToInt32(idAgenda.Value));
                    gridForaVendaPolitica.DataSource = dtPoliticaVenda;
                    gridForaVendaPolitica.DataBind();

                    calcSubTotal(gridForaVendaPolitica.FooterRow, dtPoliticaVenda, ref totVlUnitario, ref totVlDesconto, ref totVlBaseCom, ref totVlComissao);

                    lbTotValor.Text = totVlUnitario.ToString("###,###,##0.00");
                    lbTotDesconto.Text = totVlDesconto.ToString("###,###,##0.00");
                    lbTotPerDesc.Text = ((totVlDesconto * 100) / totVlUnitario).ToString("###,###,##0.00") + '%';
                    lbTotVlCobrado.Text = totVlBaseCom.ToString("###,###,##0.00");
                    lbTotComissao.Text = totVlComissao.ToString("###,###,##0.00");

                    pnAnalitico.Visible = true;
                    pnSintetico.Visible = false;
                    pnAnaliticoAjusteCredito.Visible = false;

                    lbPeriodoVendaNaoPolitica.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower() + " - Vendas fora da Política de Vendas";
                    lbPeriodoVendaPolitica.Text = "Período de apuração " + row.Cells[0].Text.ToString().Substring(57).ToLower() + " - Vendas de acordo com a Política de Vendas";                    
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

    }


}