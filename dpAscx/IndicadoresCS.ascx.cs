using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using DPromocional.dao;
namespace DPromocional.dpAscx
{
    public partial class IndicadoresCS : System.Web.UI.UserControl
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            //if (!ClientScript.IsStartupScriptRegistered(GetType(), "MaskedEditFix"))
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "MaskedEditFix", String.Format("<script type='text/javascript' src='{0}'></script>", Page.ResolveUrl("MaskedEditFix.js")));
            //}
        }
        daoIndica bdi = new daoIndica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscaIndicadores();
                BuscaBancos();
            }
        }
        private void BuscaBancos()
        {
            DataSet dsBancos = new DataSet();
            dsBancos = bdi.pro_getBancos();
            dropBancos.DataSource = dsBancos;
            dropBancos.DataValueField = "cd_banco";
            dropBancos.DataTextField = "ds_banco";
            dropBancos.DataBind();
            dropBancos.Items.Insert(0, "Selecione um Banco");
        }
        private void getDadosBancarios()
        {
            if (TxtCod.Text != "")
            {
                DataSet dsRetorno = new DataSet();
                int id_indicador = Convert.ToInt32(TxtCod.Text);
                dsRetorno = bdi.pro_RetornaDadosBancarios(id_indicador);
                if (dsRetorno.Tables[0].Rows.Count > 0)
                {
                    dropBancos.SelectedValue = dsRetorno.Tables[0].Rows[0]["cd_banco"].ToString();
                    txtAgencia.Text = dsRetorno.Tables[0].Rows[0]["nr_agencia"].ToString();
                    txtDigAgencia.Text = dsRetorno.Tables[0].Rows[0]["nr_agencia_dig"].ToString();
                    txtConta.Text = dsRetorno.Tables[0].Rows[0]["nr_conta"].ToString();
                    txtdigConta.Text = dsRetorno.Tables[0].Rows[0]["nr_conta_dig"].ToString();
                    txtOperador.Text = dsRetorno.Tables[0].Rows[0]["nr_operacao"].ToString();
                }
                else
                {
                    BuscaBancos();
                    txtAgencia.Text = "";
                    txtDigAgencia.Text = "";
                    txtConta.Text = "";
                    txtdigConta.Text = "";
                    txtOperador.Text = "";
                }
            }
        }
        private void BuscaIndicadores()
        {
            AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
            string usuario = acessoLogin.Codigo;
            DataTable dti = new DataTable();
            dti = bdi.pro_getIndicadores(usuario.Substring(0, 6));
            if (dti.Rows.Count > 0)
            {
                gridIndicadores.DataSource = dti;
                gridIndicadores.DataBind();

            }
        }
        protected void gridIndicadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gridIndicadores, "Select$" + e.Row.RowIndex);
                }
            
        }
        protected void gridIndicadores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            TxtCod.Text = gridIndicadores.Rows[e.NewSelectedIndex].Cells[0].Text;
            TxtCpf_Cnpf.Text = gridIndicadores.Rows[e.NewSelectedIndex].Cells[1].Text;
            TxtCliente.Text = Server.HtmlDecode(gridIndicadores.Rows[e.NewSelectedIndex].Cells[2].Text);
            txtContato.Text = gridIndicadores.Rows[e.NewSelectedIndex].Cells[3].Text;
            txtCelular.Text = gridIndicadores.Rows[e.NewSelectedIndex].Cells[4].Text;
            txtEmail.Text = Server.HtmlDecode(gridIndicadores.Rows[e.NewSelectedIndex].Cells[5].Text);
            getDadosBancarios();
        }
        private void GravaIndicador()
        {

            if (TxtCod.Text != "" && txtNovoCelular.Text != "" && txtNovoContato.Text != "" && txtNovoEmail.Text != "" && txtNovoFixo.Text != "")
            {
                try
                {
                    AcessoLogin acessoLogin = (AcessoLogin)Session["acessoLogin"];
                    string usuario = acessoLogin.Nome;
                    int nr_indicador = Convert.ToInt32(TxtCod.Text);
                    string ds_novoContato = txtNovoContato.Text;
                    string ds_novoEmail = txtNovoEmail.Text;
                    string ds_novoFixo = txtNovoFixo.Text;
                    string ds_novoCel = txtNovoCelular.Text;
                    bool retorno = bdi.GravarIndicados(nr_indicador, ds_novoContato, ds_novoFixo, ds_novoCel, ds_novoEmail, usuario, false);
                    if (retorno == true)
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Indicado vinculado com sucesso..";
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Não foi possível inserir as informações,verifique os dados.";
                    }
                }
                catch (Exception ex)
                {
                    lblmensagem.Text = ex.ToString();
                    lblmensagem.Visible = true;
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Favor preencher todos os dados..";
            }
        }
        protected void btnCadastrarInd_Click(object sender, EventArgs e)
        {
            GravaIndicador();
        }
        private void GravaAgendamento()
        {
            if (TxtCod.Text != "" && TxtCliente.Text != "" && txtDataAgenda.Text != "" && txtDataAgenda.Text != "__/__/____")
            {

                int id_indicador = Convert.ToInt32(TxtCod.Text);
                DateTime dt_agenda = Convert.ToDateTime(txtDataAgenda.Text);
                if (dt_agenda > DateTime.Now)
                {
                    bool gravou = bdi.GravaAgendaIndicadores(id_indicador, dt_agenda);
                    if (gravou == true)
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Agendamento efetuado com sucesso..";
                        BuscaIndicadores();
                    }
                    else
                    {
                        lblmensagem.Visible = true;
                        lblmensagem.Text = "Erro";
                    }
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Data do agendamento é menor que data de hoje,favor verificar";
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Favor preencher todos os dados.";
            }
        }
        protected void btnAgendamento_Click(object sender, EventArgs e)
        {
            GravaAgendamento();
        }
        private void AtualizaDadosBancarios()
        {
            if (TxtCod.Text != "" && txtAgencia.Text != "" && txtDigAgencia.Text != "" && txtConta.Text != "" && txtdigConta.Text != "" && dropBancos.SelectedValue != "0" && dropBancos.SelectedItem.Text != "Selecione um Banco" && txtOperador.Text != "")
            {
                int id_indicador = Convert.ToInt32(TxtCod.Text);
                string cd_banco = dropBancos.SelectedValue;
                string nr_agencia = txtAgencia.Text;
                string digAgencia = txtDigAgencia.Text;
                string nr_Conta = txtConta.Text;
                string digConta = txtdigConta.Text;
                string operadora = txtOperador.Text;
                bool retorno = bdi.AtualizaBancos(id_indicador, cd_banco, nr_agencia, digAgencia, nr_Conta, digConta, operadora);
                if (retorno == true)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Atualizações efetuadas com sucesso..";
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Erro";
                }
            }
        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizaDadosBancarios();
        }

        protected void gridIndicadores_Load(object sender, EventArgs e)
        {
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = "gridIndicadores";
            trigger.EventName = "SelectedIndexChanging";
            updGridIndicadores.Triggers.Add(trigger);
            AsyncPostBackTrigger triggerRow = new AsyncPostBackTrigger();
            triggerRow.ControlID = "gridIndicadores";
            triggerRow.EventName = "RowDataBound";
            updGridIndicadores.Triggers.Add(trigger);
            AsyncPostBackTrigger triggerUpdati = new AsyncPostBackTrigger();
            triggerUpdati.ControlID = "gridIndicadores";
            triggerUpdati.EventName = "RowUpdating";
            updGridIndicadores.Triggers.Add(trigger);
        }
        protected void btnAtualiza_Click(object sender, EventArgs e)
        {
            BuscaIndicadores();
        }

        protected void btnCancelarIndicacao_Click(object sender, EventArgs e)
        {
            if (TxtCod.Text != "")
            {
                int cd_indicador = Convert.ToInt32(TxtCod.Text);
                bool Transacao = bdi.RetiraIndicados(cd_indicador);
                if (Transacao == true)
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Cliente retirada da carteira";
                    BuscaIndicadores();
                }
                else
                {
                    lblmensagem.Visible = true;
                    lblmensagem.Text = "Não foi possível retirar indicador";
                }
            }
            else
            {
                lblmensagem.Visible = true;
                lblmensagem.Text = "Favor preencher todos os dados.";
            }
        }

        protected void gridIndicadores_PreRender(object sender, EventArgs e)
        {
            if (gridIndicadores.Rows.Count > 0)
            {
                gridIndicadores.UseAccessibleHeader = true;
                gridIndicadores.HeaderRow.TableSection = TableRowSection.TableHeader;
 
            }
        }
    }
}