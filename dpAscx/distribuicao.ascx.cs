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
    public partial class distribuicao : System.Web.UI.UserControl
    {
        daoCarteira bdc = new daoCarteira();
        int alterado = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                int func = Convert.ToInt32(acessoLogin.Funcao);
                if (func == 1)
                {
                    BuscaDados();
                    BuscaGr();
                    QuantitativoIndicacoes();
                }
            }
        }
        private void BuscaDados()
        {
            DataTable dtCar = new DataTable();
            dtCar = bdc.pro_getCarteira();
            if (dtCar.Rows.Count > 0)
            {
                txtTotal.Text = dtCar.Rows.Count.ToString();
                GrvDistribuicao.DataSource = dtCar;
                GrvDistribuicao.DataBind();
            }
        }
        private void BuscaGr()
        {

            DataTable dtGrs = new DataTable();
            daoGR bdg = new daoGR();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            string usuario = acessoLogin.Codigo.Substring(0, 6);
            dtGrs = bdg.pro_getConsultores(usuario);
            if (dtGrs.Rows.Count > 0)
            {
                dropConsultores.DataSource = dtGrs;
                dropConsultores.DataBind();
                dropConsultores.Items.Insert(0, "Selecione");
            }
        }
        private void QuantitativoIndicacoes()
        {
            DataTable dtGrs = new DataTable();
            daoGR bdg = new daoGR();
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            string usuario = acessoLogin.Codigo;
            dtGrs = bdg.pro_getQuantitativoCarteira(usuario.Substring(0, 6));
            if (dtGrs.Rows.Count > 0)
            {
                gridConsultores.DataSource = dtGrs;
                gridConsultores.DataBind();
            }
        }
        protected void GrvDistribuicao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvDistribuicao.PageIndex = e.NewPageIndex;
            BuscaDados();
        }

        protected void txtContrato_TextChanged(object sender, EventArgs e)
        {
            txtContrato.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string itemselecionado;

            int selecao = Convert.ToInt32(dropEscolhe.SelectedValue);
            switch (selecao)
            {
                case 1:
                    itemselecionado = txtContrato.Text;
                    DataTable dtItem = bdc.pro_getContrato(itemselecionado);
                    if (dtItem.Rows.Count > 0)
                    {
                        txtTotal.Text = dtItem.Rows.Count.ToString();
                        GrvDistribuicao.DataSource = dtItem;
                        GrvDistribuicao.DataBind();
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Não existe dados para essa fonte de pesquisa";
                        GrvDistribuicao.DataBind();
                        txtTotal.Text = "0";
                    }
                    break;
                case 2:
                    itemselecionado = TxtCnpj.Text;
                    DataTable dtCpf_Cnpj = bdc.pro_getCpf_Cnpj(itemselecionado);
                    if (dtCpf_Cnpj.Rows.Count > 0)
                    {
                        txtTotal.Text = dtCpf_Cnpj.Rows.Count.ToString();
                        GrvDistribuicao.DataSource = dtCpf_Cnpj;
                        GrvDistribuicao.DataBind();
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Não existe dados para essa fonte de pesquisa";
                        GrvDistribuicao.DataBind();
                        txtTotal.Text = "0";
                    }
                    break;
                case 3:
                    itemselecionado = TxtCpf.Text;
                    DataTable Cnpj = bdc.pro_getCpf_Cnpj(itemselecionado);
                    if (Cnpj.Rows.Count > 0)
                    {
                        txtTotal.Text = Cnpj.Rows.Count.ToString();
                        GrvDistribuicao.DataSource = Cnpj;
                        GrvDistribuicao.DataBind();
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Não existe dados para essa fonte de pesquisa";
                        GrvDistribuicao.DataBind();
                        txtTotal.Text = "0";
                    }
                    break;
                default:
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Selecione uma opção válida";
                    break;
            }
        }

        protected void chkmarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GrvDistribuicao.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkselecionar");
                if (ch != null)
                {
                    ch.Checked = (sender as CheckBox).Checked;
                }
            }
        }
        private void DistribuiCarteira()
        {
            foreach (GridViewRow row in GrvDistribuicao.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("chkselecionar");

                if (ch != null && ch.Checked == true)
                {
                    if (dropConsultores.SelectedValue != "Selecione")
                    {
                        string drop = dropConsultores.SelectedValue.ToString().Substring(0, 6);
                        int Cod = Convert.ToInt32(row.Cells[0].Text);
                        bdc.pro_setVinculaIndicador(Cod, drop);
                        alterado = alterado + 1;
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Selecione um consultor";
                    }
                }
            }
            if (alterado > 0)
            {
                BuscaDados();
                QuantitativoIndicacoes();
                lblmensagem.Visible = true;
                lblmensagem.Text = "Indicador vinculado com sucesso.";
            }
        }
        protected void dropEscolhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selecao = Convert.ToInt32(dropEscolhe.SelectedValue);
            switch (selecao)
            {
                case 0:
                    btnBuscar.Visible = false;
                    txtContrato.Visible = true;
                    TxtCnpj.Visible = false;
                    txtContrato.Visible = false;
                    TxtCpf.Visible = false;
                    break;
                case 1:
                    btnBuscar.Visible = true;
                    txtContrato.Visible = true;
                    TxtCnpj.Visible = false;
                    TxtCpf.Visible = false;
                    txtContrato.Text = "";
                    break;
                case 2:
                    btnBuscar.Visible = true;
                    TxtCnpj.Visible = true;
                    txtContrato.Visible = false;
                    TxtCpf.Visible = false;
                    TxtCnpj.Text = "";
                    break;
                case 3:
                    btnBuscar.Visible = true;
                    TxtCpf.Visible = true;
                    TxtCnpj.Visible = false;
                    txtContrato.Visible = false;
                    TxtCpf.Text = "";
                    break;
            }
        }
        protected void btnDistribuir_Click(object sender, EventArgs e)
        {
            DistribuiCarteira();
        }

        protected void GrvDistribuicao_Load(object sender, EventArgs e)
        {
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = "chkmarcarTodos";
            trigger.EventName = "CheckedChanged";
            upGrv.Triggers.Add(trigger);
        }

        protected void gridConsultores_Load(object sender, EventArgs e)
        {
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = "btnDistribuir";
            trigger.EventName = "OnClick";
            updGrid.Triggers.Add(trigger);
        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            BuscaDados();
        }

        protected void btnDisponibilizar_Click(object sender, EventArgs e)
        {
            BuscaDados();
        }

        protected void btnLimparCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodigoGR.Text != "")
            {
                string codigo = txtCodigoGR.Text;
                bool exito=bdc.pro_setRetiraIndicadorGR(codigo);
                if (exito == true)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Processo concluido com sucesso..";
                    BuscaDados();
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Erro ao processar,verifique os dados..";
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Favor preencher todos os dados..";
            }
           
        }
    }
}