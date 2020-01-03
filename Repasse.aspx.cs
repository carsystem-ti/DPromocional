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
    public partial class Repasse : System.Web.UI.Page
    {
        daoProdutos bdp = new daoProdutos();
        daoVeiculo bdv = new daoVeiculo();
        daoRepasse bdr = new daoRepasse();
        daoPagamento bdpg = new daoPagamento();
        daoPedidoVendaPagamento bdvp = new daoPedidoVendaPagamento();
        private DataTable dtb = null;
        private DataTable dtp = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Produtos
                dtb = new DataTable();
                dtb = CriarDataTable();
                Session["vProdutos"] = dtb;
                this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;

                //Pagamentos
                dtp = new DataTable();
                dtp = CriarDataTablePagamento();
                Session["vPagamentos"] = dtp;
                this.GridProdutos.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;

                BuscaFabricante();
            }
        }
        public DataTable CriarDataTable()
        {
            DataTable mDataTable = new DataTable();
            DataColumn mDataColumn;

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "Codigo";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "Produto";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "placa";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "modelo";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "cor";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "chassi";
            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "renavan";
            mDataTable.Columns.Add(mDataColumn);


            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "valor";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "id_modelo";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "tipo";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "ano";
            mDataTable.Columns.Add(mDataColumn);

            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "comb";
            mDataTable.Columns.Add(mDataColumn);

            return mDataTable;

        }
        public DataTable CriarDataTablePagamento()
        {
            DataTable mDataTablePagamento = new DataTable();
            DataColumn mDataColumnPagamento;

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "Codigo";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "Pagamento";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.Int32");
            mDataColumnPagamento.ColumnName = "quantidade";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "valor";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "data";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "titular";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_agencia";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);


            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_conta";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_documento";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_cheque";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);


            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "nr_banco";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

            mDataColumnPagamento = new DataColumn();
            mDataColumnPagamento.DataType = Type.GetType("System.String");
            mDataColumnPagamento.ColumnName = "ccm";
            mDataTablePagamento.Columns.Add(mDataColumnPagamento);

         

            return mDataTablePagamento;

        }
        private void incluirNoDataTablePagamento(string incremento, string pagamento, string valor,
                                                string data,string quantidade,string titular, string nr_agencia, string nr_conta, string nr_documento, string nr_cheque, string nr_banco,string ccm, DataTable mDataTablePagamento)
        {
            try
            {
                DataRow linha;
                linha = mDataTablePagamento.NewRow();

                linha["Codigo"] = incremento;
                linha["Pagamento"] = pagamento;
                linha["quantidade"] = quantidade;
                linha["valor"] = valor;
                linha["data"] = data;
                linha["titular"] = titular;
                linha["nr_agencia"] = nr_agencia;
                linha["nr_conta"] = nr_conta;
                linha["nr_documento"] = nr_documento;
                linha["nr_cheque"] = nr_cheque;
                linha["nr_banco"] = nr_banco;
                linha["ccm"] = ccm;

                mDataTablePagamento.Rows.Add(linha);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }
        private void incluirNoDataTable(string incremento, string produto, string placa, string modelo, string cor, string chassi, string renavan, string valor, string id_modelo,string  tipo,string ano,string comb, DataTable mTable)
        {
            try
            {
                DataRow linha;
                linha = mTable.NewRow();

                linha["Codigo"] = incremento;
                linha["Produto"] = produto;
                linha["placa"] = placa;
                linha["modelo"] = modelo;
                linha["cor"] = cor;
                linha["chassi"] = chassi;
                linha["renavan"] = renavan;
                linha["valor"] = valor;
                linha["id_modelo"] = id_modelo;
                linha["tipo"] = tipo;
                linha["ano"] = ano;
                linha["comb"] = comb;
                mTable.Rows.Add(linha);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        private void InseriProdutos()
        {
            try
            {

                incluirNoDataTable(dropProdutos.SelectedValue, dropProdutos.SelectedItem.Text, txtPlaca.Text, dropmodelo.SelectedItem.Text, txtCor.Text, txtChassi.Text, txtRenavam.Text, txtValorProduto.Text, dropmodelo.SelectedValue, dropTipo.SelectedValue,txtAno.Text,dropComb.SelectedValue,(DataTable)Session["vProdutos"]);
                this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;
                this.GridProdutos.DataBind();
                //lblmensagem.Visible = true;
                InseriTaxaPlus();
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

        }
        private void InseriPagamentos()
        {
            try
            {
                int tipo = Convert.ToInt32(dropForma.SelectedValue);
                    switch(tipo)
                    {
                        case 1:
                                incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text,DateTime.Now.ToString(@"dd/MM/yyyy"),txtQtdParcela.Text, txtTitular.Text,"","", txtDocumento.Text, "", "","", (DataTable)Session["vPagamentos"]);
                                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                                this.gridPagamento.DataBind();
                            break;
                        case 2:
                                incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text,txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text,txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                                this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                                this.gridPagamento.DataBind();
                            break;
                        case 3:
                                int quantidade = Convert.ToInt32(txtQtdParcela.Text);
                                for (int i = 0; i < quantidade; i++)
                                {
                                    string Ban = txtLeitura.Text.Substring(1, 3);
                                    txtBanco.Text = Ban;

                                    string Age = txtLeitura.Text.Substring(4, 4);
                                    txtAgencia.Text = Age;

                                    string Com = txtLeitura.Text.Substring(10, 3);

                                    string Che = txtLeitura.Text.Substring(13, 6);
                                    txtNrCheque.Text = Che;

                                    string Con = txtLeitura.Text.Substring(23, 9);
                                    txtConta.Text = Con;
                                    incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text, txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                                    this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                                    this.gridPagamento.DataBind();
                                    txtLeitura.Text = "";
                                    txtLeitura.Focus();
                               }
                            break;

                        case 4:
                            incluirNoDataTablePagamento(dropForma.SelectedValue, dropForma.SelectedItem.Text, txtValor.Text, txtvencimentoCheque.Text, txtQtdParcela.Text, txtTitular.Text, txtAgencia.Text, txtConta.Text, txtDocumento.Text, txtNrCheque.Text, txtBanco.Text, txtLeitura.Text, (DataTable)Session["vPagamentos"]);
                            this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                            this.gridPagamento.DataBind();
                            break;
                        default:
                            Mensagem("Selecione uma Forma de Pagamento");
                            break;
                    }

        
                
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }
        private void Mensagem(string message)
        {
            //string message = "Número do Pedido gerador com sucesso";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Mensagem('" + message + "');", true);
        }
        private void BuscaModelo()
        {
            if (dropFabricante.SelectedValue != "Selecione")
            {
                int id_fabricante = Convert.ToInt32(dropFabricante.SelectedValue);
                DataTable modelo = bdv.BuscaModelo(id_fabricante);
                dropmodelo.DataSource = modelo;
                dropmodelo.DataBind();
                dropmodelo.Items.Insert(0, "Selecione");
            }
        }
        private void BuscaFabricante()
        {
            DataTable fabricante = new DataTable();
            fabricante = bdv.BuscaFabricante();
            dropFabricante.DataSource = fabricante;
            dropFabricante.DataBind();
            dropFabricante.Items.Insert(0, "Selecione");
        }
        private void Consulta(string nr_documento)
        {
            double valor = Convert.ToDouble("50.00");
            string retorno;
            CarSystem.Banco.BoaVista.BoaVista boa = new CarSystem.Banco.BoaVista.BoaVista("usr_web", "premium", "principal", CarSystem.Tipos.Servidores.Fury);

            boa.isProducao = false;

            CarSystem.Banco.BoaVista.BoaVista.Consulta iConsulta = boa.efetuaConsulta(nr_documento, valor);

            // lblmensagem.Text = (iConsulta.codigoConsulta.ToString());
            //lblmensagem.Text = (iConsulta.dataConsulta.ToString());

            if (nr_documento.Length == 14)
                retorno = (CarSystem.Utilidades.Formatar.formataCNPJ(iConsulta.documento.ToString()));
            else
                retorno = (CarSystem.Utilidades.Formatar.formataCPF(iConsulta.documento.ToString()));

            retorno = (iConsulta.statusConsulta.ToString());

            string resultado = iConsulta.statusConsulta.ToString();
            switch (resultado)
            {
                case "Aprovado":
                    filtroAprovacao.Visible = true;
                    rdbAprovado.Visible = true;
                    rdbReprovado.Visible = false;
                    rdbanalise.Visible = false;
                    txtData.Text = iConsulta.dataConsulta.ToString(@"dd/MM/yyyy");
                    txtCodigoConsulta.Text = iConsulta.codigoConsulta.ToString();
                    txtResultado.Text = iConsulta.statusConsulta.ToString();
                    break;
                case "Reprovado":
                    filtroAprovacao.Visible = true;
                    rdbReprovado.Visible = true;
                    rdbAprovado.Visible = false;
                    rdbanalise.Visible = false;
                    txtData.Text = iConsulta.dataConsulta.ToString(@"dd/MM/yyyy");
                    txtCodigoConsulta.Text = iConsulta.codigoConsulta.ToString();
                    txtResultado.Text = iConsulta.statusConsulta.ToString();
                    break;
                default:
                    filtroAprovacao.Visible = false;
                    break;
            }

        }
        protected void rdbTpPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
            switch (tipo)
            {
                case 0:
                    ConsultaCpf.Visible = true;
                    ConsultaCnpj.Visible = false;
                    txtCnpj.Text = "";
                    LimpaCampos();
                    break;
                case 1:
                    ConsultaCnpj.Visible = true;
                    ConsultaCpf.Visible = false;
                    txtCpf.Text = "";
                    LimpaCampos();
                    break;
            }
        }
        private void LimpaCampos()
        {
            txtResultado.Text = "";
            txtCodigoConsulta.Text = "";
            txtData.Text = "";
            filtroAprovacao.Visible = false;
            dadoscliente.Visible = false;
            dadosprodutos.Visible = false;
            dadosresidencial.Visible = false;
            dadosVeiculo.Visible = false;
            rdbAprovado.Checked = false;
            rdbReprovado.Checked = false;
            rdbanalise.Checked = false;
        }
        private void BloqueiaCampos()
        {
            rdbTpPessoa.Enabled = false;
            txtCnpj.Enabled = false;
            txtCpf.Enabled = false;

        }
        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            bool Valida = false;
            Valida = ValidaCpf(txtCpf.Text);
            switch (Valida)
            {
                case true:
                    Consulta(txtCpf.Text.Replace(".", "").Replace("-", "").ToString());
                    break;
                default:
                    Mensagem("CPF INVÁLIDO");
                    filtroAprovacao.Visible = false;
                    break;
            }
        }
        private void BuscaCep()
        {
            if (txtCep.Text != "")
            {
                DataSet ds_cep = new DataSet();
                string nr_cep = txtCep.Text;
                ds_cep = bdp.pro_getCep(nr_cep);
                if (ds_cep.Tables[0].Rows.Count > 0)
                {
                    txtEndereco.Text = ds_cep.Tables[0].Rows[0]["Rua"].ToString();
                    txtBairro.Text = ds_cep.Tables[0].Rows[0]["Bairro"].ToString();
                    txtCidade.Text = ds_cep.Tables[0].Rows[0]["Cidade"].ToString();
                    txtUf.Text = ds_cep.Tables[0].Rows[0]["Estado"].ToString();
                    txtnr.Text = "";
                    txtComplemento.Text = "";
                    imgEndereco.Visible = true;
                    DataSet dsCep = new DataSet();
                    ds_cep = bdr.ValidaTecnologia(nr_cep, "NS");
                    if (ds_cep.Tables[0].Rows.Count > 0)
                    {
                        string ds_tecnologia = ds_cep.Tables[0].Rows[0]["Tec"].ToString();
                        if (ds_tecnologia == "nOK")
                        {
                            imgEndereco.Visible = false;
                            Session["ns"] = "0";
                        }
                        else
                        {
                            imgEndereco.Visible = true;
                            Session["ns"] = "1";
                        }
                    }
                    ds_cep = bdr.ValidaTecnologia(nr_cep, "GSM");
                    {
                        string ds_tecnologia = ds_cep.Tables[0].Rows[0]["Tec"].ToString();
                        if (ds_tecnologia == "nOK")
                        {
                            imgEndereco.Visible = false;
                            Session["gsm"] = "0";
                        }
                        else
                        {
                            imgEndereco.Visible = true;
                            Session["gsm"] = "1";
                        }
                    }

                }
                else
                {
                    Mensagem("CEP NÃO ENCONTRADO");
                    txtEndereco.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtUf.Text = "";
                    txtnr.Text = "";
                    imgEndereco.Visible = false;
                }
            }
        }
        private void getProdutoVendas()
        {
            int tipo = 0;
            if (Session["ns"].ToString() == "1")
            {
                tipo = 1;
            }
            else if (Session["gsm"].ToString() == "1")
            {
                tipo = 2;
            }
            DataTable dtProdutos = new DataTable();
            dtProdutos = bdp.pro_getProdutosVendas(tipo);
            if (dtProdutos.Rows.Count > 0)
            {
                dropProdutos.DataSource = dtProdutos;
                dropProdutos.DataBind();
                dropProdutos.Items.Insert(0, "Selecione");
                dadosprodutos.Visible = true;
            }
            else
            {
                dadosprodutos.Visible = false;
            }
        }
        protected void imgCep_Click(object sender, ImageClickEventArgs e)
        {
            BuscaCep();
        }
        private void ValidaPlaca()
        {
            DataSet ds = new DataSet();

            if (txtCep.Text != "")
            {
                try
                {
                    string ds_placa = txtPlaca.Text.Replace("-", "").ToString();
                    ds = bdv.ValidaPlacaVeiculo(ds_placa.ToString());
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["ds_Placa"].ToString()) == 1)
                    {
                        Mensagem("Placa de veículo já consta em nossa base.");
                        return;
                    }
                    else
                    {
                       
                        InseriProdutos();
                    }
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }
        }
        private void pro_getPagamentos()
        {
            DataSet dt_pagamento = new DataSet();
            dt_pagamento = bdpg.getFormasPagamentos();
            if (dt_pagamento.Tables[0].Rows.Count > 0)
            {
                dropForma.DataSource = dt_pagamento;
                dropForma.DataBind();
                dropForma.Items.Insert(0, "Selecione");
            }

        }
        private void BloqueiaDadosVeiculo()
        {
            txtPlaca.Enabled = false;
            dropFabricante.Enabled = false;
            dropmodelo.Enabled = false;
            txtCor.Enabled = false;
            txtChassi.Enabled = false;
            txtRenavam.Enabled = false;
            imgVeiculo.Visible = false;
            imgEditVeiculo.Visible = true;
        }
        private void LiberaDadosVeiculo()
        {
            txtPlaca.Enabled = true;
            dropFabricante.Enabled = true;
            dropmodelo.Enabled = true;
            txtCor.Enabled = true;
            txtChassi.Enabled = true;
            txtRenavam.Enabled = true;
            imgVeiculo.Visible = true;
            imgEditEndereco.Visible = false;
        }
        private void BloqueiaDadosResidencias()
        {
            txtEndereco.Enabled = false;
            txtComplemento.Enabled = false;
            txtnr.Enabled = false;
            txtCep.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            imgEndereco.Visible = false;
            imgEditEndereco.Visible = true;
        }
        private void liberaDadosResidencias()
        {
            txtEndereco.Enabled = true;
            txtComplemento.Enabled = true;
            txtnr.Enabled = true;
            txtCep.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUf.Enabled = true;
            imgEndereco.Visible = true;
            imgEditEndereco.Visible = false;
        }
        private void BloqueiaDadosCliente()
        {
            txtNome.Enabled = false;
            TxtResidencial.Enabled = false;
            txtCelular.Enabled = false;
            txtComercial.Enabled = false;
            txtEmail.Enabled = false;
            imgAvancarCliente.Visible = false;
            imgEditCliente.Visible = true;
        }
        private void LiberaDadosCliente()
        {

            txtNome.Enabled = false;
            TxtResidencial.Enabled = false;
            txtCelular.Enabled = false;
            txtComercial.Enabled = false;
            txtEmail.Enabled = false;
            imgAvancarCliente.Visible = true;
            imgEditCliente.Visible = false;
        }
        private void ExcluirLinha(string id)
        {
            if (GridProdutos.Rows.Count > 0)
            {
                for (int i = 1; i <= 1; i++)
                {
                    foreach (DataRow linha in ((DataTable)Session["vProdutos"]).Rows)
                    {
                        if (linha[0].ToString() == id)
                        {
                            linha.Delete();
                            this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;
                            this.GridProdutos.DataBind();
                            return;
                        }
                    }
                }
            }
            else
            {
                dadosprodutos.Visible = false;
            }
        }
        private void ExcluirLinhaPagamento(string id)
        {
            if (gridPagamento.Rows.Count > 0)
            {
                for (int i = 1; i <= 1; i++)
                {
                    foreach (DataRow linha in ((DataTable)Session["vPagamentos"]).Rows)
                    {
                        if (linha[0].ToString() == id)
                        {
                            linha.Delete();
                            this.gridPagamento.DataSource = ((DataTable)Session["vPagamentos"]).DefaultView;
                            this.gridPagamento.DataBind();
                            return;
                        }
                    }
                }
            }
            else
            {
                dadosprodutos.Visible = false;
            }
        }
        private void InseriTaxaPlus()
        {
            if (dropProdutos.SelectedValue == "3" || dropProdutos.SelectedValue == "4" || dropProdutos.SelectedValue == "5" || dropProdutos.SelectedValue == "7" || dropProdutos.SelectedValue == "8" || dropProdutos.SelectedValue == "9" || dropProdutos.SelectedValue == "12" || dropProdutos.SelectedValue == "13" || dropProdutos.SelectedValue == "14" || dropProdutos.SelectedValue == "16" || dropProdutos.SelectedValue == "18")
            {
                incluirNoDataTable("25", "ADESÃO PLUS", txtPlaca.Text, dropmodelo.SelectedValue + '-' + dropmodelo.SelectedItem.Text, txtCor.Text, txtChassi.Text, txtRenavam.Text, txtValorProduto.Text, dropmodelo.SelectedValue,dropTipo.SelectedValue,txtAno.Text,dropComb.SelectedValue, (DataTable)Session["vProdutos"]);
                this.GridProdutos.DataSource = ((DataTable)Session["vProdutos"]).DefaultView;
                this.GridProdutos.DataBind();
            }
        }
        protected void dropFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaModelo();
        }
        public bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
        protected void btnCnpj_Click(object sender, EventArgs e)
        {
            bool Cnpj = false;
            Cnpj = ValidaCnpj(txtCnpj.Text.Replace(",", "."));
            switch (Cnpj)
            {
                case true:
                    Consulta(txtCnpj.Text.Replace(".", "").Replace("-", "").ToString().Replace("/", "").Replace(",", ""));
                    break;
                default:
                    Mensagem("CNPJ INVÁLIDO");
                    filtroAprovacao.Visible = false;
                    break;
            }

        }
        protected void rdbAprovado_CheckedChanged(object sender, EventArgs e)
        {
            dadoscliente.Visible = true;
            BloqueiaCampos();
        }
        protected void imgAvancarCliente_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCodigoConsulta.Text != "" && txtData.Text != "" && txtNome.Text != "" && TxtResidencial.Text != "" && txtCelular.Text != "" && txtEmail.Text != "")
            {
                dadosresidencial.Visible = true;
                BloqueiaDadosCliente();
            }
            else
            {
                Mensagem("FAVOR PREENCHER TODOS OS CAMPOS..");
            }
        }

        protected void imgEndereco_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCep.Text != "" && txtEndereco.Text != "" && txtnr.Text != "" && txtComplemento.Text != "" && txtBairro.Text != "" && txtCidade.Text != "" && txtUf.Text != "")
            {
                dadosVeiculo.Visible = true;
                BloqueiaDadosResidencias();
                dadosprodutos.Visible = true;
                getProdutoVendas();
                pro_getPagamentos();
                //   BloqueiaDadosVeiculo();
            }
            else
            {
                Mensagem("FAVOR PREENCHER TODOS OS DADOS..");
            }
        }
        private void FinalizaPedido()
        {
            if (gridPagamento.Rows.Count > 0 && GridProdutos.Rows.Count > 0)
            {
                finalizar.Visible = true;
                pagamento.Visible = true;
            }
            else
            {
                finalizar.Visible = false;
                    pagamento.Visible = false;;
            }
        }
        protected void imgVeiculo_Click(object sender, ImageClickEventArgs e)
        {
            BloqueiaDadosVeiculo();
        }

        protected void imgEditCliente_Click(object sender, ImageClickEventArgs e)
        {
            LiberaDadosCliente();
        }

        protected void imgEditEndereco_Click(object sender, ImageClickEventArgs e)
        {
            liberaDadosResidencias();
        }

        protected void imgEditVeiculo_Click(object sender, ImageClickEventArgs e)
        {
            LiberaDadosVeiculo();
        }

        protected void imgAddprodutos_Click(object sender, ImageClickEventArgs e)
        {
            ValidaPlaca();
        }

        protected void GridProdutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridProdutos.Rows[e.RowIndex].Cells[0].Text;
            ExcluirLinha(id);
        }

        protected void imgPagamento_Click(object sender, ImageClickEventArgs e)
        {
            InseriPagamentos();
        }

        protected void GridProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = e.Row.Attributes["onmouseover"] + "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = e.Row.Attributes["onmouseout"] + "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, "Select$" + e.Row.RowIndex);
            }
            if (GridProdutos.Rows.Count > 0)
            {
                divpagamento.Visible = true;
                imgVeiculo.Visible = true;
                dadosprodutos.Visible = true;
                tabDadosComplementares.Visible = true;
            }
            else
            {
                divpagamento.Visible = false;
                imgVeiculo.Visible = false;
                dadosprodutos.Visible = false;
                tabDadosComplementares.Visible = false;
            }
            FinalizaPedido();
        }
        private void BloqueiaFormaCheque()
        {
            lblbanco.Visible = false;
            txtBanco.Visible = false;
            txtBanco.Text = "";
            lblconta.Visible = false;
            txtConta.Visible = false;
            txtConta.Text = "";
            lbldocumento.Visible = false;
            txtDocumento.Visible = false;
            txtDocumento.Text = "";
            lbltitular.Visible = false;
            txtTitular.Visible = false;
            txtTitular.Text = "";
            lbldoc.Visible = false;
            lblnrcheque.Visible = false;
            txtNrCheque.Visible = false;
            txtNrCheque.Text = "";
            lblvencimento.Visible = false;
            txtvencimentoCheque.Visible = false;
            txtvencimentoCheque.Text = "";
            lblAgencia.Visible = false;
            txtAgencia.Visible = false;
            txtAgencia.Text = "";
            chkLeitora.Checked = false;
            chkLeitora.Visible = false;

            lblLeitura.Visible = false;
            txtLeitura.Visible = false;
        }
        private void LiberaFormaCheque()
        {
            lblbanco.Visible = true;
            txtBanco.Visible = true;
            lblconta.Visible = true;
            txtConta.Visible = true;
            lbldocumento.Visible = true;
            txtDocumento.Visible = true;
            lbltitular.Visible = true;
            txtTitular.Visible = true;
            lbldoc.Visible = true;
            lblnrcheque.Visible = true;
            txtNrCheque.Visible = true;
            lblvencimento.Visible = true;
            txtvencimentoCheque.Visible = true;
            lblAgencia.Visible = true;
            txtAgencia.Visible = true;
            chkLeitora.Visible = true;
            chkLeitora.Checked = false;
            lblLeitura.Visible = true;
            txtLeitura.Visible = true;
      }
        public void OnConfirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }

        private void RegrasPagamento()
        {
            if (dropForma.SelectedValue != "" && dropForma.SelectedValue != "Selecione")
            {
                int tpPagamento = Convert.ToInt32(dropForma.SelectedValue);
                switch (tpPagamento)
                {
                    case 1:
                        txtQtdParcela.Text = "1";
                        txtValor.Text = "";
                        txtQtdParcela.Enabled = false;
                        imgPagamento.Enabled = true;
                        txtvencimentoCheque.Visible = false;
                        lblvencimento.Visible = false;
                        BloqueiaFormaCheque();
                        break;

                    case 2:
                        txtQtdParcela.Enabled = true;
                        txtValor.Text = "";
                        txtvencimentoCheque.Visible = false;
                        lblvencimento.Visible = false;
                        imgPagamento.Enabled = true;
                        BloqueiaFormaCheque();
                        break;

                    case 3:
                        txtQtdParcela.Enabled = true;
                        txtvencimentoCheque.Text = DateTime.Now.AddMonths(1).ToString(@"dd/MM/yyyy");
                        txtTitular.Text = txtNome.Text;
                        int tipo = Convert.ToInt32(rdbTpPessoa.SelectedValue);
                        switch (tipo)
                        {
                            case 0:
                                txtDocumento.Text = txtCpf.Text;
                                break;

                            case 1:
                                txtDocumento.Text = txtCnpj.Text;
                                break;
                        }
                        
                        lblvencimento.Visible = false;
                        imgPagamento.Enabled = true;
                        LiberaFormaCheque();
                        break;

                    case 4:
                        txtQtdParcela.Enabled = true;
                        txtvencimentoCheque.Text = "";
                        txtvencimentoCheque.Visible = true;
                        lblvencimento.Visible = true;
                        imgPagamento.Enabled = true;
                        BloqueiaFormaCheque();
                        break;
                }
            }
            else
            {
                imgPagamento.Enabled = false;
                // txtValor.Text = "";
                // txtQtdParcela.Text = "";

            }

        }
        private void GravaPedido()
        {
            try
            {
                daoPedidoVenda bdpv = new daoPedidoVenda();
                int nr_Pedidovenda = 0;
                bdpv._id_franquia = 1;
                bdpv._id_vendedor = Convert.ToInt32("1");
                bdpv.id_consulta = Convert.ToInt32(txtCodigoConsulta.Text);
                bdpv._ds_nome = txtNome.Text;
                bdpv._nrCep = txtCep.Text;
                bdpv._endereco = txtEndereco.Text;
                bdpv._nrEndereco = txtnr.Text;
                bdpv._dsComplemento = txtComplemento.Text;
                bdpv._dsBairro = txtBairro.Text;
                bdpv._dsCidade = txtCidade.Text;
                bdpv._dsUf = txtUf.Text;
                if (rdbTpPessoa.SelectedValue == "0")
                {
                    bdpv._dsDocumento = txtCpf.Text;
                    bdpv._tpCliente = "F";
                }
                else
                {
                    bdpv._dsDocumento = txtCnpj.Text;
                    bdpv._tpCliente = "J";
                }
                bdpv._ddTel = TxtResidencial.Text.Substring(0, 2).ToString();
                bdpv._nrTel = TxtResidencial.Text.Substring(2, 8);
                bdpv._ddcel = txtCelular.Text.Substring(0, 2).ToString();
                bdpv._nrCel = txtCelular.Text.Substring(2, 9);
                bdpv._ddCom = txtComercial.Text.Substring(0, 2).ToString();
                bdpv._nrCom = txtComercial.Text.Substring(2, 8);
                nr_Pedidovenda = bdpv.pro_setPedidoVenda();
                if (nr_Pedidovenda > 0)
                {
                    GravaItens(nr_Pedidovenda);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void GravaItens(int nr_venda)
        {
            if (GridProdutos.Rows.Count > 0)
            {
                foreach (GridViewRow grw in GridProdutos.Rows)
                {
                    for (int i = 0; i < GridProdutos.Rows.Count; i++)
                    {
                        int nr_itens = 0;
                        int id_veiculo = 0;
                        daoPedidoVendaItens bdvi = new daoPedidoVendaItens();
                        daoPedidoVendaVeiculo bdvv = new daoPedidoVendaVeiculo();
                        daoPedidoVendaPagamento bdp = new daoPedidoVendaPagamento();
                        bdvi._idPedido = nr_venda;
                        bdvi._idproduto = grw.Cells[0].Text;
                        bdvi._valorProduto = Convert.ToDouble(grw.Cells[8].Text);
                        bdvi._vlDesconto = Convert.ToDouble(grw.Cells[8].Text);
                        nr_itens = bdvi.pro_setPedidoVendaItens();
                        bdvv._idItem = nr_itens;
                        bdvv._idmodelo = Convert.ToInt32(grw.Cells[2].Text);
                        bdvv._idPedido = nr_venda;
                        bdvv._dsplaca = grw.Cells[1].Text;
                        bdvv._dsCor = grw.Cells[4].Text;
                        bdvv._dsCombustivel = grw.Cells[11].Text;
                        bdvv._dsAno = grw.Cells[10].Text;
                        bdvv._dsRenavan = grw.Cells[5].Text;
                        bdvv._dsChassi = grw.Cells[4].Text;
                     
                       id_veiculo = bdvv.pro_setPedidoVendaVeiculo();
                    }
                   
                }
                GravaPagamento(nr_venda);
            }
        }
        private void GravaPagamento(int pedido)
        {
         
            foreach (GridViewRow grwp in gridPagamento.Rows)
            {
                int pagamento = Convert.ToInt32(dropForma.SelectedValue);
                int quantidade = Convert.ToInt32(txtQtdParcela.Text);
                if (rdbTpPessoa.SelectedValue == "0")
                    bdvp._dsDoc = txtCpf.Text;
                else
                    bdvp._dsDoc = txtCnpj.Text;
                double valorCalculado = Convert.ToDouble(txtValor.Text) / quantidade;
                switch (pagamento)
                {
                    case 1:
                        bdvp._idPedido = pedido;
                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
                        bdvp._vlPagamento = Convert.ToDouble(grwp.Cells[3].Text);
                        bdvp._dataVenc =DateTime.Now.Date;
                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
                        bdvp._dsDoc = txtCpf.Text;
                        bdvp._dsTitular = txtNome.Text;
                        bdvp.pro_setPedidoVendaPagamento();
                        break;
                    case 2:
                        bdvp._idPedido = pedido;
                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
                        bdvp._vlPagamento = Convert.ToDouble(grwp.Cells[3].Text);
                        bdvp._dataVenc = DateTime.Now.Date;
                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
                        if (grwp.Cells[5].Text != "&nbsp;" || grwp.Cells[5].Text != "")
                                bdvp._dsTitular = grwp.Cells[5].Text;
                        else
                            bdvp._dsTitular =txtNome.Text;
                        bdvp.pro_setPedidoVendaPagamento();
                        break;
                    case 3:
                        bdvp._idPedido = pedido;
                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
                        bdvp._vlPagamento = Convert.ToDouble(grwp.Cells[3].Text);
                        bdvp._dataVenc = Convert.ToDateTime(grwp.Cells[4].Text);
                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
                        bdvp._dsTitular = grwp.Cells[5].Text;
                        bdvp._nrAgencia = grwp.Cells[6].Text;
                        bdvp._nrConta = grwp.Cells[7].Text;
                        bdvp._ccm = Server.HtmlDecode(grwp.Cells[11].Text);
                        bdvp.pro_setPedidoVendaPagamento();
                        break;
                     case 4:
                        bdvp._idPedido = pedido;
                        bdvp._idTipo = Convert.ToInt32(grwp.Cells[0].Text);
                        bdvp._vlPagamento = Convert.ToDouble(grwp.Cells[3].Text);
                        bdvp._dataVenc = DateTime.Now.Date;
                        bdvp._pcParcela = Convert.ToInt32(grwp.Cells[2].Text);
                        bdvp._dsTitular = grwp.Cells[5].Text;
                        if (grwp.Cells[5].Text != "&nbsp;" || grwp.Cells[5].Text != "")
                                bdvp._dsTitular = grwp.Cells[5].Text;
                        else
                            bdvp._dsTitular =txtNome.Text;
                         bdvp.pro_setPedidoVendaPagamento();
                        break;
                    
                    default:
                        break;
                }
            }
        }
        protected void dropForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegrasPagamento();
        }

        protected void gridPagamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gridPagamento.Rows[e.RowIndex].Cells[0].Text;
            ExcluirLinhaPagamento(id);
        }

        protected void gridPagamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            FinalizaPedido();
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            GravaPedido();
        }

        protected void txtLeitura_TextChanged(object sender, EventArgs e)
        {
            if (txtLeitura.Text != "" && txtTitular.Text != "" && txtDocumento.Text != "" && txtQtdParcela.Text != "" && txtvencimentoCheque.Text != "")
            {
                string Ban = txtLeitura.Text.Substring(1,3);
                txtBanco.Text = Ban;

                string Age = txtLeitura.Text.Substring(4, 4);
                txtAgencia.Text = Age;

                string Com = txtLeitura.Text.Substring(10, 3);

                string Che = txtLeitura.Text.Substring(13, 6);
                txtNrCheque.Text = Che;

                string Con = txtLeitura.Text.Substring(23,9);
                txtConta.Text = Con;
                InseriPagamentos();
                txtLeitura.Text = "";
                txtLeitura.Focus();
            }
            else
            {
                Mensagem("FAVOR PREENCHER TODOS OS DADOS..");
            }

        }

        protected void chkLeitora_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeitora.Checked == true)
            {
                lblLeitura.Visible=true;
                txtLeitura.Visible=true;
                txtCheques.Visible = true;
                txtLeitura.Focus();
                txtLeitura.Text = "";
                lblcheques.Visible = true;
            }
            else
            {
                lblLeitura.Visible = false;
                txtLeitura.Visible = false;
                txtLeitura.Text = "";
                txtCheques.Visible = false;
                lblcheques.Visible = false;
            }
        }
        protected void dropmodelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropmodelo.SelectedValue != "Selecione")
            {
                DataTable dtCategoria = bdv.BuscaTipoVeiculo(Convert.ToInt32(dropmodelo.SelectedValue));
                dropTipo.DataSource = dtCategoria;
                dropTipo.DataBind();
            }
        }
    }
}