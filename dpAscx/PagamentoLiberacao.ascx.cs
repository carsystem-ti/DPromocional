using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional.dpAscx
{
    public partial class PagamentoLiberacao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            lbMensError.Visible = false;
            if (!IsPostBack)
            {                
                gridBusca.DataBind();
                gridValoresIndicacoes.DataBind();                
                gridDebitos.DataBind();
            }


        }

        protected void imgBTBuscar_Click(object sender, ImageClickEventArgs e)
        {   
            if (! (String.IsNullOrWhiteSpace(ddlOpcoesBusca.SelectedValue) && String.IsNullOrWhiteSpace(txtValor.Text)))
            {
                daoPagamentosLiberacoes DaoPagamentosLiberacoes = new daoPagamentosLiberacoes();
                colBuscaCodigo.InnerText = "Código";
                colBuscaNome.InnerText = "Nome";
                colBuscaCodGr.InnerText = "CodGr";

                colBuscaContrato.Visible = true;
                colBuscaCodGr.Visible = true;
                gridBusca.Columns[3].Visible = true;
                gridBusca.Columns[4].Visible = true;

                try
                {
                    switch (ddlOpcoesBusca.SelectedValue)
                    {
                        case "Contrato":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getContrato(txtValor.Text);
                            break;

                        case "Placa":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getPlaca(txtValor.Text);
                            break;

                        case "CPF":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getCPFCNPJ(txtValor.Text);
                            break;

                        case "Indicador":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getIndicador(txtValor.Text);
                            break;

                        case "Carteira":
                            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getCarteira(acessoLogin.Codigo);
                            colBuscaNome.InnerText = "Indicador";
                            colBuscaCodGr.InnerText = "Indicação";
                            break;

                        case "Dias":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getProximosDias();
                            colBuscaContrato.InnerText = "Indicador";
                            colBuscaNome.InnerText = "Indicador";
                            colBuscaContrato.Visible = false;
                            colBuscaCodGr.Visible = false;

                            gridBusca.Columns[3].Visible = false;
                            gridBusca.Columns[4].Visible = false;
                            break;
                    }
                    gridBusca.DataBind();
                    gridValoresIndicacoes.DataSource = null;
                    gridValoresIndicacoes.DataBind();
                    gridDebitos.DataSource = null;
                    gridDebitos.DataBind();
                    gridBusca.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    ShowErro("Erro ao pesquisar: " + ex.Message);
                }
            }
        }

        protected void gridBusca_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gridBusca, "Select$" + e.Row.RowIndex);
            }
        }
        
        protected void gridBusca_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            daoPagamentosLiberacoes DaoPagamentosLiberacoees = new daoPagamentosLiberacoes();

            try
            {
                gridValoresIndicacoes.DataSource = DaoPagamentosLiberacoees.getValoresIndicacoes(Convert.ToInt32(gridBusca.Rows[e.NewSelectedIndex].Cells[0].Text));
                gridValoresIndicacoes.DataBind();

                gridDebitos.DataSource = DaoPagamentosLiberacoees.getDebitos(Convert.ToInt32(gridBusca.Rows[e.NewSelectedIndex].Cells[0].Text));
                gridDebitos.DataBind();             
            }
            catch (Exception ex)
            {
                ShowErro("Erro ao preencher os grids: " + ex.Message);
            }
        }

        private void ShowErro(string mens)
        {
            lbMensError.Text = mens;
            lbMensError.Visible = true;
        }

        protected void BTBuscar_Click(object sender, EventArgs e)
        {
            if (! String.IsNullOrWhiteSpace(ddlOpcoesBusca.SelectedValue))
            {
                daoPagamentosLiberacoes DaoPagamentosLiberacoes = new daoPagamentosLiberacoes();
                colBuscaCodigo.InnerText = "Código";
                colBuscaNome.InnerText = "Nome";
                colBuscaCodGr.InnerText = "CodGr";

                colBuscaContrato.Visible = true;
                colBuscaCodGr.Visible = true;
                gridBusca.Columns[3].Visible = true;
                gridBusca.Columns[4].Visible = true;

                try
                {
                    switch (ddlOpcoesBusca.SelectedValue)
                    {
                        case "Contrato":
                            DaoPagamentosLiberacoes.setAtualizaContratoConfirmado(txtValor.Text);
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getContrato(txtValor.Text);                           
                            break;

                        case "Placa":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getPlaca(txtValor.Text);
                            break;

                        case "CPF":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getCPFCNPJ(txtValor.Text);
                            break;

                        case "Indicador":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getIndicador(txtValor.Text);
                            break;

                        case "Carteira":
                            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getCarteira(acessoLogin.Codigo);
                            colBuscaNome.InnerText = "Indicador";
                            colBuscaCodGr.InnerText = "Indicação";
                            break;

                        case "Dias":
                            gridBusca.DataSource = DaoPagamentosLiberacoes.getProximosDias();
                            colBuscaContrato.InnerText = "Indicador";
                            colBuscaNome.InnerText = "Indicador";
                            colBuscaContrato.Visible = false;
                            colBuscaCodGr.Visible = false;

                            gridBusca.Columns[3].Visible = false;
                            gridBusca.Columns[4].Visible = false;
                            break;
                    }
                    gridBusca.DataBind();
                    gridValoresIndicacoes.DataSource = null;
                    gridValoresIndicacoes.DataBind();
                    gridDebitos.DataSource = null;
                    gridDebitos.DataBind();
                    gridBusca.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    ShowErro("Erro ao pesquisar: " + ex.Message);
                }
            }            
                
        }

    }
}