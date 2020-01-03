using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkDP_Click(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.UsaDP)
            {
                Response.Redirect("principal.aspx");
                Master.FindControl("lkbtVoltar").Visible = true;
            }
            else
                ShowMens("Você não tem acesso a este módulo !");

        }

        protected void imgbtnDP_Click(object sender, ImageClickEventArgs e)
        {
            linkDP_Click(null, null);
        }

        protected void linkRelatorio_Click(object sender, EventArgs e)
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            if (acessoLogin.idFranquia > 0 || acessoLogin.idFranquia == -1)
            {
                Response.Redirect("Relatorio.aspx");                
                Master.FindControl("lkbtVoltar").Visible = true;
            }
            else
                ShowMens("Você não tem acesso a este módulo !");
        }

        protected void imgbtnRelatorio_Click(object sender, ImageClickEventArgs e)
        {
            linkRelatorio_Click(null, null);
        }

        private void ShowMens(string mens)
        {
            lbMensError.Text = mens;
            lbMensError.Visible = true;

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Simulador.aspx");
            Master.FindControl("lkbtVoltar").Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            LinkButton1_Click(null, null);
        }
    }
}