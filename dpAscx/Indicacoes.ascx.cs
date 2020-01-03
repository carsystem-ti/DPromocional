using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using DPromocional.dao;

namespace DPromocional.dpAscx
{
    public partial class Indicacoes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                daoIndicadores DaoIndicadores = new daoIndicadores();
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                gridIndicadores.DataSource = DaoIndicadores.getIndicadores(acessoLogin.Codigo);
                gridIndicadores.DataBind();
                gridIndicacao.DataBind();                
                gridAgenda.DataSource = DaoIndicadores.getAgenda(acessoLogin.Codigo);
                gridAgenda.DataBind();
            }            
        }

        protected void gridIndicadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = e.Row.Attributes["onmouseover"] + "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = e.Row.Attributes["onmouseout"] + "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gridIndicadores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            daoIndicadores DaoIndicadores = new daoIndicadores();

            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            gridIndicacao.DataSource = DaoIndicadores.getIndicacao(acessoLogin.Codigo, gridIndicadores.Rows[e.NewSelectedIndex].Cells[0].Text);
            gridIndicacao.DataBind();
        }

        protected void gridIndicacao_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "$('.cssMenuContext" + e.Row.RowIndex.ToString() + "').hide();" +
                                                  "$('.cssMenuContextShow" + e.Row.RowIndex.ToString() + "').show();";

                e.Row.Attributes["onmouseout"] = "$('.cssMenuContext" + e.Row.RowIndex.ToString() + "').show();" +
                                                 "$('.cssMenuContextShow" + e.Row.RowIndex.ToString() + "').hide();";

                e.Row.Cells[6].CssClass = "cssMenuContext" + e.Row.RowIndex.ToString() + " colIndicacaoCT";

                e.Row.Cells[7].CssClass = "cssMenuContextShow" + e.Row.RowIndex.ToString() + " colIndicacaoCT";
                e.Row.Cells[7].Style.Add("display", "none");
            }
        }

        protected void gridIndicacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lbMensError.Visible = true;
            daoIndicadores DaoIndicadores = new daoIndicadores();
            try
            {
                if (e.CommandName == "EnviaCRM")
                {
                    DaoIndicadores.setEnviaCRM(e.CommandArgument.ToString());
                    lbMensError.Text = "Indicação enviada para o CRM !";
                }
                else
                    if (e.CommandName == "CancelarCRM")
                    {
                        DaoIndicadores.setCancelaCRM(e.CommandArgument.ToString());
                        lbMensError.Text = "Indicação cancelada !";
                    }
                    else
                        lbMensError.Visible = false;
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                gridIndicacao.DataSource = DaoIndicadores.getIndicacao(acessoLogin.Codigo, gridIndicadores.Rows[gridIndicadores.SelectedIndex].Cells[0].Text);
                gridIndicacao.DataBind();
            }
            catch (Exception ex)
            {
                lbMensError.Text = "Erro: " + ex.Message + " (" + e.CommandName + "-" + e.CommandArgument.ToString() + ")";
            }
        }        

        protected void Button1_Click(object sender, EventArgs e)
        {
            lbMensError.Visible = true;
            
            if ((!String.IsNullOrWhiteSpace(txtData.Text.ToString())) && (!String.IsNullOrWhiteSpace(txtHora.Text.ToString())) && (gridIndicacao.SelectedIndex > -1))
            {                
                try
                {
                    DateTime dtAux = Convert.ToDateTime(txtData.Text.ToString() + " " + txtHora.Text.ToString() + ":00");
                    daoIndicadores DaoIndicadores = new daoIndicadores();
                    DaoIndicadores.setGravaAgenda(gridIndicacao.Rows[gridIndicacao.SelectedIndex].Cells[0].Text, Convert.ToDateTime(txtData.Text.ToString() + " " + txtHora.Text.ToString() + ":00"));
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    gridIndicacao.DataSource = DaoIndicadores.getIndicacao(acessoLogin.Codigo, gridIndicadores.Rows[gridIndicadores.SelectedIndex].Cells[0].Text);
                    gridIndicacao.DataBind();
                    gridAgenda.DataSource = DaoIndicadores.getAgenda(acessoLogin.Codigo);
                    gridAgenda.DataBind();
                    lbMensError.Text = "Indicação agendada !";
                }
                catch (Exception ex)
                {
                    lbMensError.Text = "Erro ao gravar a agenda " + ex.Message;
                }
            }
            else
                lbMensError.Text = "Digite a data e a hora e selecione uma indicação";
        }

    }
}