using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using DPromocional.dao;

namespace VendasIndicador
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Browser.Equals("IE") && Request.Browser.MajorVersion < 8)
            {
                pnLogar.Visible = false;
                pnIE7.Visible = true;
            }
            Session.Clear();
            txtLogin.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim().Length == 0 || txtSenha.Text.Trim().Length == 0)
                lbMensErro.Text = "Digite suas credenciais !";
            else
            {
                try
                {
                    AcessoLogin acessoLogin = new AcessoLogin(txtLogin.Text, txtSenha.Text);                    
                    Session["acessoLogin"] = acessoLogin;                    
                    //Response.Redirect("Home.aspx");
                    Response.Redirect("Relatorio.aspx");
                }
                catch (SqlException ex)
                {
                    lbMensErro.Text = "Erro na base: " + ex.Message;
                }
                catch (Exception ex)
                {
                    lbMensErro.Text = ex.Message;
                }
            }
        }        
    }
}