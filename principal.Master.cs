using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional
{
    public partial class principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acessoLogin"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                lbFranquia.Text = "Franquia: " + acessoLogin.Franquia;
                lbNome.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nome: " + acessoLogin.Nome;
                if (ContentPlaceHolder1.FindControl("linkDP") != null)
                    lkbtVoltar.Visible = false;
                else
                    lkbtVoltar.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void lkbtVoltar_Click(object sender, EventArgs e)
        {
            if (ContentPlaceHolder1.FindControl("pnSintetico") != null)
            {
                Control pnSintetico = ContentPlaceHolder1.FindControl("pnSintetico");
                if (pnSintetico.Visible)
                    Response.Redirect("home.aspx");
                else
                {
                    pnSintetico.Visible = true;
                    Control pnAnalitico = ContentPlaceHolder1.FindControl("pnAnalitico");
                    pnAnalitico.Visible = false;
                    Control pnAnaliticoAjusteCredito = ContentPlaceHolder1.FindControl("pnAnaliticoAjusteCredito");
                    pnAnaliticoAjusteCredito.Visible = false;
                }
            }
            else
                Response.Redirect("Home.aspx");
        }
    }
}