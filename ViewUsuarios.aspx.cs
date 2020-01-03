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
    public partial class ViewUsuarios : System.Web.UI.Page
    {
        daosetLogin bdl = new daosetLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaConsultores();
            }
        }
        private void Mensagem(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void CarregaConsultores()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            DataTable dt = new DataTable();
            int franquia =acessoLogin.idFranquia;
            dt = bdl.pro_getUsuarios(franquia);
            if (dt.Rows.Count > 0)
            {
                GridVendedores.DataSource = dt;
                GridVendedores.DataBind();
            }
        }
        private void CadastrarUsuario()
        {
            int retorno = 0;
            int existe = 0;
            if (txtUsuario.Text != "")
            {
                foreach (GridViewRow rw in GridVendedores.Rows)
                {
                    if (rw.Cells[1].Text == txtUsuario.Text.ToUpper())
                    {
                        existe = 1;
                    }
                }
                if (existe == 0)
                {
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string usuario = txtUsuario.Text;
                    int franquia = acessoLogin.idFranquia;
                    retorno = bdl.pro_setGravaUsuario(franquia, usuario);
                    if (retorno > 0)
                    {
                        Mensagem("Usúario " + usuario + " criado com sucesso...");
                        CarregaConsultores();
                    }
                    else
                    {
                        Mensagem("Não foi possível criar esse usúario,favor verificar as informações..");
                    }
                }
                else
                {
                    Mensagem("Usúario existente");
                }
            }
            else
            {
                Mensagem("Favor preencher todos os dados..");
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarUsuario();
        }

        protected void GridVendedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GridVendedores, "Select$" + e.Row.RowIndex);
            }
            alteracoes.Visible = false;
            if (GridVendedores.Rows.Count > 0)
            {
                foreach (GridViewRow drw in GridVendedores.Rows)
                {
                    string status = drw.Cells[2].Text;
                    switch (status)
                    {
                        case "N":
                            drw.Cells[2].Text = "INATIVO";
                            break;
                        case "S":
                            drw.Cells[2].Text = "ATIVO";
                            break;
                    }
                }
            }
        }
        protected void GridVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUsuarioExistente.Text = GridVendedores.SelectedRow.Cells[1].Text;
            alteracoes.Visible = true;
        }

        protected void GridVendedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridVendedores.PageIndex = e.NewPageIndex;
            CarregaConsultores();
        }
        private void AtivaUsuario()
        {
            if (GridVendedores.SelectedRow.Cells[0].Text != "")
            {
                if (GridVendedores.SelectedRow.Cells[2].Text == "INATIVO")
                {
                    int retorno = 0;
                    int vendedor = Convert.ToInt32(GridVendedores.SelectedRow.Cells[0].Text);
                    retorno = bdl.pro_ativaUsuario(vendedor);
                    if (retorno > 0)
                    {
                        Mensagem("Usúario ativado com sucesso...");
                        CarregaConsultores();
                    }
                    else
                    {
                        Mensagem("Não foi possível alterar dados..");
                    }
                }
                else
                {
                    Mensagem("Usuário já esta Ativo");
                }
            }
            else
            {
                Mensagem("Favor selecione um consultor");
            }
        }
        private void InativaUsuario()
        {
            if (GridVendedores.SelectedRow.Cells[0].Text != "")
            {
                if (GridVendedores.SelectedRow.Cells[2].Text == "ATIVO")
                {
                    int retorno = 0;
                    int vendedor = Convert.ToInt32(GridVendedores.SelectedRow.Cells[0].Text);
                    retorno = bdl.pro_InativaUsuario(vendedor);
                    if (retorno > 0)
                    {
                        Mensagem("Usúario Inativado com sucesso...");
                        CarregaConsultores();
                    }
                    else
                    {
                        Mensagem("Não foi possível alterar dados..");
                    }
                }
                else
                {
                    Mensagem("Usuário ja esta Inativo");
                }
            }
            else
            {
                Mensagem("Favor selecione um consultor");
            }
        }
        protected void imgAtivar_Click(object sender, ImageClickEventArgs e)
        {
            AtivaUsuario();
        }

        protected void imgDesativar_Click(object sender, ImageClickEventArgs e)
        {
            InativaUsuario();
        }
    }
}