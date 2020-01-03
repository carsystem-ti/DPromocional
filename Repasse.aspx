<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Repasse.aspx.cs" Inherits="DPromocional.Repasse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/comum.css" rel="stylesheet" />
    <link href="css/mensagem.css" rel="stylesheet" />
    <link href="css/repasse.css" rel="stylesheet" />
    <script type="text/javascript" src="scripts/jquery.js"></script>
    <script src="scripts/jquery.min.js" type="text/javascript"></script>
    <script src="scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/MaskedEditFix.js"></script>
    <script type="text/javascript">
        function Mensagem(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensagem importante",
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
            });
        };
    </script>
    <style type="text/css">
        .TextDadosBasicos
        {
            width: 1163px;
            height: 22px;
            font-weight: 700;
            margin-left: 40px;
        }

        #dadosprodutos
        {
            height: 182px;
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <div id="dialog" style="display: none; height: 400px; width: 400px;">
        <asp:Label ID="Label24" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    </div>
    <div class="Dlabel">
        <asp:RadioButtonList ID="rdbTpPessoa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdbTpPessoa_SelectedIndexChanged" Font-Names="Vrinda" Font-Size="Small">
            <asp:ListItem Value="0">Pessoa Fisíca</asp:ListItem>
            <asp:ListItem Value="1">Pessoa Jurídica</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div id="ConsultaCpf" runat="server" visible="false" style="float: left; margin-left: 8%; margin-top: -57px; width: 380px;">
        <asp:Label ID="lbldocumento" runat="server" Height="25px" Text="CPF" Width="35px"></asp:Label><asp:TextBox ID="txtCpf" runat="server" Height="19px"></asp:TextBox>
        <asp:MaskedEditExtender ID="txtCpf_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="999,999,999-99" MaskType="Number" TargetControlID="txtCpf">
        </asp:MaskedEditExtender>
        <asp:Button ID="btnPesquisar" runat="server" Height="29px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
    </div>
    <div id="ConsultaCnpj" runat="server" visible="false" style="float: left; margin-left: 8%; margin-top: -30px; width: 382px;">
        <asp:Label ID="Label1" runat="server" Height="25px" Text="CNPJ" Width="35px"></asp:Label><asp:TextBox ID="txtCnpj" runat="server" Height="19px"></asp:TextBox>
        <asp:MaskedEditExtender ID="txtCnpj_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99.999.999/9999-99" MaskType="Number" TargetControlID="txtCnpj">
        </asp:MaskedEditExtender>
        <asp:Button ID="btnCnpj" runat="server" Height="29px" Text="Pesquisar" OnClick="btnCnpj_Click" />
    </div>
    <div id="filtroAprovacao" runat="server" visible="false" style="float: right; margin-right: 30px; margin-top: -45px; width: 627px; height: 53px;">
        <asp:RadioButton ID="rdbAprovado" CssClass="aprovado" runat="server" Text="APROVADO" Font-Size="Small" Visible="False" AutoPostBack="True" OnCheckedChanged="rdbAprovado_CheckedChanged" />
        <asp:RadioButton ID="rdbReprovado" CssClass="reprovado" runat="server" Text="REPROVADO" Visible="False" />
        <asp:RadioButton ID="rdbanalise" CssClass="analise" runat="server" Text="ANÁLISE MANUAL" Visible="False" />
    </div>
    <div id="dadoscliente" runat="server" visible="false">
        <div class="fita">
            <asp:Label ID="Label4" ClientIDMode="Static" runat="server" Text="Cod.Consulta" CssClass="SubTitulos"
                Width="100px" Height="16px"></asp:Label>
            <asp:Label ID="Label20" ClientIDMode="Static" runat="server" Text="Data.Consulta" CssClass="SubTitulos"
                Width="87px" Height="16px"></asp:Label>
            <asp:Label ID="Label22" ClientIDMode="Static" runat="server" Text="Resultado" CssClass="SubTitulos"
                Width="96px" Height="16px"></asp:Label>
            <asp:Label ID="Label3" ClientIDMode="Static" runat="server" Text="Cliente" CssClass="SubTitulos"
                Width="245px" Height="16px"></asp:Label>
            <asp:Label ID="Label2" ClientIDMode="Static" runat="server" Text="Residencial" CssClass="SubTitulos"
                Width="115px" Height="16px"></asp:Label>
            <asp:Label ID="Label6" ClientIDMode="Static" runat="server" Text="Celular" CssClass="SubTitulos"
                Width="103px" Height="16px"></asp:Label>
            <asp:Label ID="Label7" ClientIDMode="Static" runat="server" Text="Comercial" CssClass="SubTitulos"
                Width="103px" Height="16px"></asp:Label>
            <asp:Label ID="Label23" ClientIDMode="Static" runat="server" Text="E-mail" CssClass="SubTitulos"
                Width="36px" Height="16px"></asp:Label>
            <br />
        </div>
        <div>
            <asp:TextBox ID="txtCodigoConsulta" runat="server" Width="94px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtData" runat="server" Width="87px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtResultado" runat="server" Width="87px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtNome" runat="server" Width="231px" Height="16px"></asp:TextBox>
            <asp:TextBox ID="TxtResidencial" runat="server" Width="100px" Height="16px"></asp:TextBox>
            <asp:MaskedEditExtender ID="TxtResidencial_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="TxtResidencial">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtCelular" runat="server" Width="100px" Height="16px"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtCelular_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtCelular">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtComercial" runat="server" Width="100px" Height="16px"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtComercial_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtComercial">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtEmail" runat="server" Width="199px" Height="16px"></asp:TextBox>
            <asp:ImageButton ID="imgAvancarCliente" runat="server" Height="21px" ImageUrl="~/img/ativar.png" OnClick="imgAvancarCliente_Click" Width="47px" />
            <asp:ImageButton ID="imgEditCliente" runat="server" ImageUrl="~/img/b_edit.png" OnClick="imgEditCliente_Click" Visible="False" Height="21px" Width="61px" />
        </div>
    </div>
    <br />
    <div id="dadosresidencial" runat="server" visible="false">
        <div class="fita" style="width: 1207px">
            <asp:Label ID="Label5" ClientIDMode="Static" runat="server" Text="Cep Compra" CssClass="SubTitulos"
                Width="146px" Height="16px"></asp:Label>
            <asp:Label ID="Label8" ClientIDMode="Static" runat="server" Text="Endereço" CssClass="SubTitulos"
                Width="223px" Height="16px"></asp:Label>
            <asp:Label ID="Label9" ClientIDMode="Static" runat="server" Text="Nr." CssClass="SubTitulos"
                Width="52px" Height="16px"></asp:Label>
            <asp:Label ID="Label10" ClientIDMode="Static" runat="server" Text="Complemento" CssClass="SubTitulos"
                Width="220px" Height="16px"></asp:Label>
            <asp:Label ID="Label11" ClientIDMode="Static" runat="server" Text="Bairro" CssClass="SubTitulos"
                Width="157px" Height="16px"></asp:Label>
            <asp:Label ID="Label12" ClientIDMode="Static" runat="server" Text="Cidade" CssClass="SubTitulos"
                Width="162px" Height="16px"></asp:Label>
            <asp:Label ID="Label13" ClientIDMode="Static" runat="server" Text="UF" CssClass="SubTitulos"
                Width="85px" Height="16px"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCep" runat="server" Width="71px" Height="16px"></asp:TextBox><asp:ImageButton ID="imgCep" runat="server" Height="24px" ImageUrl="~/img/buscar.png" OnClick="imgCep_Click" />
            <asp:MaskedEditExtender ID="txtCep_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99999-999" TargetControlID="txtCep">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtEndereco" runat="server" Width="231px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtnr" runat="server" Width="42px" Height="16px"></asp:TextBox>
            <asp:TextBox ID="txtComplemento" runat="server" Width="210px" Height="16px"></asp:TextBox>
            <asp:TextBox ID="txtBairro" runat="server" Width="157px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtCidade" runat="server" Width="157px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtUf" runat="server" Width="96px" Height="16px" ReadOnly="True"></asp:TextBox>
            <asp:ImageButton ID="imgEndereco" runat="server" Height="18px" ImageUrl="~/img/ativar.png" OnClick="imgEndereco_Click" Width="47px" />
            <asp:ImageButton ID="imgEditEndereco" runat="server" ImageUrl="~/img/b_edit.png" OnClick="imgEditEndereco_Click" Visible="False" Height="20px" Width="61px" />
        </div>
    </div>
    <br />
    <div id="dadosVeiculo" runat="server" visible="false">
        <div class="fita" style="margin-bottom: 0px;">
            <asp:Label ID="Label14" ClientIDMode="Static" runat="server" Text="Placa" CssClass="SubTitulos"
                Width="68px" Height="16px"></asp:Label>
            <asp:Label ID="Label15" ClientIDMode="Static" runat="server" Text="Fabricante" CssClass="SubTitulos"
                Width="111px" Height="16px"></asp:Label>
            <asp:Label ID="Label16" ClientIDMode="Static" runat="server" Text="Modelo" CssClass="SubTitulos"
                Width="123px" Height="16px"></asp:Label>
            <asp:Label ID="Label17" ClientIDMode="Static" runat="server" Text="Cor" CssClass="SubTitulos"
                Width="99px" Height="16px"></asp:Label>
            <asp:Label ID="Label37" ClientIDMode="Static" runat="server" Text="Tipo" CssClass="SubTitulos"
                Width="101px" Height="16px"></asp:Label>
            <asp:Label ID="Label39" ClientIDMode="Static" runat="server" Text="Comb." CssClass="SubTitulos"
                Width="120px" Height="16px"></asp:Label>
            <asp:Label ID="Label38" ClientIDMode="Static" runat="server" Text="Ano" CssClass="SubTitulos"
                Width="62px" Height="16px"></asp:Label>
            <asp:Label ID="Label18" ClientIDMode="Static" runat="server" Text="Chassi" CssClass="SubTitulos"
                Width="89px" Height="18px"></asp:Label>
            <asp:Label ID="Label19" ClientIDMode="Static" runat="server" Text="Renavam" CssClass="SubTitulos"
                Width="109px" Height="16px"></asp:Label>
            <asp:Label ID="Label29" ClientIDMode="Static" runat="server" Text="Produtos" CssClass="SubTitulos"
                Width="138px" Height="16px"></asp:Label>
            <asp:Label ID="Label36" ClientIDMode="Static" runat="server" Text="Valor " CssClass="SubTitulos"
                Width="36px" Height="16px"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtPlaca" runat="server" Width="61px" Height="17px"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtPlaca_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="???-9999" TargetControlID="txtPlaca">
            </asp:MaskedEditExtender>
            <asp:DropDownList ID="dropFabricante" runat="server" Height="23px" Width="120px" AutoPostBack="True" DataTextField="ds_fabricante" DataValueField="id_fabricante" OnSelectedIndexChanged="dropFabricante_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="dropmodelo" runat="server" Height="23px" Width="124px" DataTextField="modelo" DataValueField="id_modelo" AutoPostBack="True" OnSelectedIndexChanged="dropmodelo_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txtCor" runat="server" Width="71px" Height="16px"></asp:TextBox>
            <asp:DropDownList ID="dropTipo" runat="server" Height="25px" Width="110px" DataTextField="ds_categoria" DataValueField="ds_categoria" Enabled="False"></asp:DropDownList>
            <asp:DropDownList ID="dropComb" runat="server" Height="25px" Width="110px" Font-Names="Vrinda">
                <asp:ListItem>GASOLINA</asp:ListItem>
                <asp:ListItem>ÁLCOOL</asp:ListItem>
                <asp:ListItem>DIESEL</asp:ListItem>
                <asp:ListItem>FLEX</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtAno" runat="server" Width="35px" Height="17px"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtAno_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtAno">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtChassi" runat="server" Width="95px" Height="17px"></asp:TextBox>
            <asp:TextBox ID="txtRenavam" runat="server" Width="99px" Height="16px"></asp:TextBox>
            <asp:DropDownList ID="dropProdutos" runat="server" Height="23px" Width="156px" DataTextField="dsProduto" DataValueField="cdproduto"></asp:DropDownList>
            <asp:TextBox ID="txtValorProduto" runat="server" Width="60px" Height="17px"></asp:TextBox>
            <asp:ImageButton ID="imgAddprodutos" runat="server" ImageUrl="~/img/add.png" Height="20px" OnClick="imgAddprodutos_Click" />
            <asp:ImageButton ID="imgVeiculo" runat="server" Height="22px" ImageUrl="~/img/ativar.png" OnClick="imgVeiculo_Click" Width="26px" Visible="False" />
            <asp:ImageButton ID="imgEditVeiculo" runat="server" ImageUrl="~/img/b_edit.png" OnClick="imgEditVeiculo_Click" Visible="False" Height="21px" Width="61px" />
        </div>
    </div>
    <br />
    <asp:CheckBox runat="server" AutoPostBack="True" Text="Usar Leitora " ForeColor="Red" ID="chkLeitora" Visible="False" OnCheckedChanged="chkLeitora_CheckedChanged"></asp:CheckBox>
    <asp:TabContainer ID="tabDadosComplementares" runat="server" Visible="false" ActiveTabIndex="1" Width="100%" Height="269px">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                Produtos
            </HeaderTemplate>
            <ContentTemplate>
                <div id="dadosprodutos" runat="server" visible="False">
                    <asp:GridView ID="GridProdutos" runat="server" AutoGenerateColumns="False" CellSpacing="-1" EmptyDataText="&nbsp;" Font-Size="X-Small" Height="16px" OnRowDataBound="GridProdutos_RowDataBound" OnRowDeleting="GridProdutos_RowDeleting" Width="99%" Font-Names="Vrinda">
                        <AlternatingRowStyle Font-Names="Vrinda" Font-Size="X-Small" />
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Código" />
                            <asp:BoundField DataField="placa" HeaderText="Placa" />
                            <asp:BoundField DataField="id_modelo" HeaderText="Id-Modelo" />
                            <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                            <asp:BoundField DataField="cor" HeaderText="Cor" />
                            <asp:BoundField DataField="chassi" HeaderText="Chassi" />
                            <asp:BoundField DataField="renavan" HeaderText="Renavan" />
                            <asp:BoundField DataField="Produto" HeaderText="Produto" />
                            <asp:BoundField DataField="Valor" HeaderText="Valor" />
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="ano" HeaderText="Ano" />
                             <asp:BoundField DataField="comb" HeaderText="Comb" />
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/excluir.png" HeaderText="Excluir" ShowDeleteButton="True" />
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle CssClass="divSomeSelect"></ItemStyle>
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle Font-Size="X-Small" Font-Names="Vrinda" />
                        <EmptyDataRowStyle Font-Size="X-Small" Font-Names="Vrinda" />
                        <FooterStyle Font-Size="X-Small" Font-Names="Vrinda" />
                        <HeaderStyle Font-Size="X-Small" Font-Names="Vrinda" />
                        <SelectedRowStyle CssClass="selectRowTD" />
                    </asp:GridView>
                    <br />
                    <table id="finalizar" runat="server" visible="False" class="direita">
                        <tr class="tr" runat="server">
                            <td class="tr" runat="server">
                                <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Pedido Venda" OnClick="btnFinalizar_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Pagamentos
            </HeaderTemplate>
            <ContentTemplate>
                <div id="divpagamento" runat="server" visible="False" style="float: left; height: 25px;">
                    <div style="width: 1202px; margin-bottom: 0px;">
                        <asp:Label ID="Label25" ClientIDMode="Static" runat="server" Text="Pagamentos" CssClass="SubTitulos"
                            Width="140px" Height="16px"></asp:Label>
                        <asp:Label ID="Label35" ClientIDMode="Static" runat="server" Text="Parcelas" CssClass="SubTitulos"
                            Width="60px" Height="16px" Enabled="False"></asp:Label>
                        <asp:Label ID="Label27" ClientIDMode="Static" runat="server" Text="Valor" CssClass="SubTitulos"
                            Width="73px" Height="16px" Enabled="False"></asp:Label>
                        <asp:Label ID="lblvencimento" ClientIDMode="Static" runat="server" Text="1-Vencimento" CssClass="SubTitulos"
                            Width="105px" Height="16px" Enabled="False" Visible="False"></asp:Label>
                        <asp:Label ID="lbltitular" ClientIDMode="Static" runat="server" Text="Titular" CssClass="SubTitulos"
                            Width="183px" Height="19px" Enabled="False" Visible="False"></asp:Label>
                        <asp:Label ID="lbldoc" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Enabled="False" Height="18px" Text="CNPJ/CPF" Visible="False" Width="123px"></asp:Label>
                        <asp:Label ID="lblLeitura" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Height="16px" Text="Leitura" Visible="False" Width="76px"></asp:Label>
                    </div>
                    <div>
                        <asp:DropDownList ID="dropForma" runat="server" AutoPostBack="True" DataTextField="ds_pagamento" DataValueField="id_forma" Height="23px" OnSelectedIndexChanged="dropForma_SelectedIndexChanged" Width="145px">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtQtdParcela" runat="server" Height="16px" Width="40px"></asp:TextBox>
                        <asp:TextBox ID="txtValor" runat="server" Width="72px" Height="18px"></asp:TextBox>
                        <asp:TextBox ID="txtvencimentoCheque" runat="server" Width="97px" Height="17px" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtTitular" runat="server" Height="18px" Visible="False" Width="179px"></asp:TextBox>
                        <asp:TextBox ID="txtDocumento" runat="server" Height="18px" Visible="False" Width="115px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtvencimentoCheque_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtvencimentoCheque" TodaysDateFormat="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="TxtResidencial" ClearMaskOnLostFocus="False">
                        </asp:MaskedEditExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtCelular" ClearMaskOnLostFocus="False">
                        </asp:MaskedEditExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtComercial" ClearMaskOnLostFocus="False">
                        </asp:MaskedEditExtender>
                        <asp:TextBox ID="txtLeitura" runat="server" AutoPostBack="True" Height="16px" OnTextChanged="txtLeitura_TextChanged" Visible="False" Width="280px"></asp:TextBox>
                        <asp:ImageButton ID="imgPagamento" runat="server" Height="20px" ImageUrl="~/img/add.png" OnClick="imgPagamento_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <br />
                    <div id="lblcheques" runat="server" visible="False" style="width: 1202px; margin-bottom: 0px;">
                        <asp:Label ID="lblAgencia" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Enabled="False" Height="18px" Text="Agencia" Visible="False" Width="65px"></asp:Label>
                        <asp:Label ID="lblconta" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Enabled="False" Height="16px" Text="Conta" Visible="False" Width="136px"></asp:Label>
                        <asp:Label ID="lblnrcheque" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Enabled="False" Height="16px" Text="Cheque" Visible="False" Width="100px"></asp:Label>
                        <asp:Label ID="lblbanco" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Enabled="False" Height="16px" Text="Banco" Visible="False" Width="91px"></asp:Label>
                    </div>
                    <div id="txtCheques" runat="server" visible="False">
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtvencimentoCheque" TodaysDateFormat="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="TxtResidencial" ClearMaskOnLostFocus="False">
                        </asp:MaskedEditExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtCelular" ClearMaskOnLostFocus="False">
                        </asp:MaskedEditExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtComercial" ClearMaskOnLostFocus="False">
                        </asp:MaskedEditExtender>
                        <asp:TextBox ID="txtAgencia" runat="server" Height="16px" Visible="False" Width="57px"></asp:TextBox>
                        <asp:TextBox ID="txtConta" runat="server" Height="16px" Visible="False" Width="127px"></asp:TextBox>
                        <asp:TextBox ID="txtNrCheque" runat="server" Height="16px" Visible="False" Width="92px"></asp:TextBox>
                        <asp:TextBox ID="txtBanco" runat="server" Height="16px" Visible="False" Width="75px"></asp:TextBox>
                    </div>
                    <br />
                    <div id="pagamento" runat="server" visible="False" style="height: 3px">
                        <asp:GridView ID="gridPagamento" runat="server" AutoGenerateColumns="False" CellSpacing="-1" EmptyDataText="&nbsp;" Font-Size="X-Small" Height="16px" OnRowDeleting="gridPagamento_RowDeleting" Width="91%" OnRowDataBound="gridPagamento_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                <asp:BoundField DataField="Pagamento" HeaderText="Pagamento" />
                                <asp:BoundField DataField="quantidade" HeaderText="Parcela" />
                                <asp:BoundField DataField="valor" HeaderText="Valor" />
                                <asp:BoundField DataField="data" HeaderText="Vencimento" />
                                <asp:BoundField DataField="titular" HeaderText="Titular" />
                                <asp:BoundField DataField="nr_agencia" HeaderText="Agencia" />
                                <asp:BoundField DataField="nr_conta" HeaderText="Conta" />
                                <asp:BoundField DataField="nr_documento" HeaderText="Documento" />
                                <asp:BoundField DataField="nr_cheque" HeaderText="Cheque" />
                                <asp:BoundField DataField="nr_Banco" HeaderText="Banco" />
                                <asp:BoundField DataField="ccm" HeaderText="ccm" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/excluir.png" HeaderText="Excluir" ShowDeleteButton="True" />
                                <asp:CommandField ShowSelectButton="True">
                                    <ItemStyle CssClass="divSomeSelect"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle Font-Size="X-Small" />
                            <EmptyDataRowStyle Font-Size="X-Small" />
                            <FooterStyle Font-Size="X-Small" />
                            <HeaderStyle Font-Size="X-Small" />
                            <SelectedRowStyle CssClass="selectRowTD" />
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
