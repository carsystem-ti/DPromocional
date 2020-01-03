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
    public partial class Simulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            daoSimulador DaoSimulador = new daoSimulador();
            ddlListaProduto.DataSource = DaoSimulador.getProdutos();
            ddlListaProduto.DataTextField = "dsProduto";
            ddlListaProduto.DataValueField = "ProdutoMonitoramento";
            ddlListaProduto.DataBind();
            ddlListaProduto.Items.Insert(0, new ListItem("--- Selecione um Produto ---",""));

            ddlParcBoletos.DataSource = DaoSimulador.getFormaBoleto();
            ddlParcBoletos.DataTextField = "nr_Parcelas";
            ddlParcBoletos.DataValueField = "nr_Coeficiente";
            ddlParcBoletos.DataBind();           

            ddlParcCheques.DataSource = DaoSimulador.getFormaCheque();
            ddlParcCheques.DataTextField = "nr_Parcelas";
            ddlParcCheques.DataValueField = "nr_Coeficiente";
            ddlParcCheques.DataBind();

            ddlParcCartao.DataSource = DaoSimulador.getFormaCartao();
            ddlParcCartao.DataTextField = "nr_Parcelas";
            ddlParcCartao.DataValueField = "nr_Coeficiente";
            ddlParcCartao.DataBind();            
        }
        
    }
}