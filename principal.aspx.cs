using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPromocional.dao;

namespace DPromocional
{
    public partial class principal1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acessoLogin"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            ValidaAcesso();
        }
        private void ValidaAcesso()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            int func = Convert.ToInt32(acessoLogin.Funcao);
            if (func == 2)
            {
                this.TabPanel1.Visible = false;
            }
            else
            {
                this.TabPanel2.Visible = false;
                this.TabPanel3.Visible = false;
            }
        }
     }
}