<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="distribuicao.ascx.cs" Inherits="DPromocional.distribuicao" %>

<%@ Register TagPrefix="My" TagName="Carregando" Src="~/dpAscx/Carregando.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link href="css/distribuicao.css" rel="stylesheet" />
<link rel="Stylesheet" type="text/css" href="css/distribuicao.css" />
<link rel="Stylesheet" type="text/css" href="css/comum.css" />

<script src="scripts/MaskedEditFix.js"></script>

<My:Carregando ID="carregando" runat="server"></My:Carregando>
<div id="principal">
    <div>
        <asp:Label ID="lbSucesso" ClientIDMode="Static" runat="server" Text="Selecione Filtro" CssClass="SubTitulos"
            Width="145px"></asp:Label>
    </div>
    <div class="menu">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="dropEscolhe" runat="server" Height="26px" Width="113px" AutoPostBack="True" OnSelectedIndexChanged="dropEscolhe_SelectedIndexChanged">
                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                    <asp:ListItem Value="1">Contrato</asp:ListItem>
                    <asp:ListItem Value="2">Cnpj</asp:ListItem>
                    <asp:ListItem Value="3">CPF</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtContrato" runat="server" Width="95px" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TxtCnpj" runat="server" Width="152px" Visible="False"></asp:TextBox>
                <asp:MaskedEditExtender ID="TxtCnpj_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99,999,999/9999-99" MaskType="Number" TargetControlID="TxtCnpj">
                </asp:MaskedEditExtender>
                <asp:TextBox ID="TxtCpf" runat="server" Width="95px" Visible="False"></asp:TextBox>

                <asp:MaskedEditExtender ID="TxtCpf_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="999,999,999-99" MaskType="Number" TargetControlID="TxtCpf">
                </asp:MaskedEditExtender>

                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" Width="117px" Visible="False" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <br />
    <div style="float: right">
        <fieldset>
            <legend>Retirar da carteira </legend>
    <asp:Label ID="lbSucesso0" ClientIDMode="Static" runat="server" Text="Código Indicador" CssClass="SubTitulos"
            Width="98px" Height="16px"></asp:Label>
        <asp:TextBox ID="txtCodigoGR" runat="server" ClientIDMode="Static" Height="16px" MaxLength="6" Width="68px"></asp:TextBox>
        <asp:Button ID="btnLimparCodigo" runat="server" Text="Retirar Gr" Height="31px" OnClick="btnLimparCodigo_Click" Width="106px" />
               
        </fieldset>
    </div>
    <div>

        <asp:Label ID="lblmensagem" CssClass="" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>

    </div>
    <br />
    <div class="Dlabel">
        <asp:Label ID="lbtotal" ClientIDMode="Static" runat="server" Text="Total"
            CssClass="SubTitulos" Width="165px" Height="17px"></asp:Label>
        <asp:Label ID="Label15" runat="server" Text="Consultores" Width="98px"></asp:Label>
    </div>
    <div class="selecao">
        <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
        <asp:DropDownList ID="dropConsultores" runat="server" Height="25px" Width="270px" DataTextField="GR" DataValueField="GR">
        </asp:DropDownList>
        <asp:Button ID="btnDistribuir" runat="server" Text="Distribuir" OnClick="btnDistribuir_Click" Width="105px" />
    </div>
    <div class="gridCentral">
        <asp:UpdatePanel ID="upGrv" runat="server">
            <ContentTemplate>
                <div style="float: left;">
                    <asp:Button ID="btnDisponibilizar" runat="server" Font-Size="Small" ForeColor="Red" Height="30px" OnClick="btnDisponibilizar_Click" Text="Clientes disponíveis" Width="176px" />
                </div>
                <br />
                <asp:GridView ID="GrvDistribuicao" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GrvDistribuicao_PageIndexChanging" Width="603px" PageSize="12" OnLoad="GrvDistribuicao_Load" CellSpacing="-1">
                    <Columns>
                        <asp:BoundField DataField="Cod" HeaderText="Código" />
                        <asp:BoundField DataField="Doc" HeaderText="Cpf/Cnpj" />
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                        <asp:TemplateField HeaderText="Marcar">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkmarcarTodos" runat="server" AutoPostBack="True" OnCheckedChanged="chkmarcarTodos_CheckedChanged" ClientIDMode="Static" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkselecionar" runat="server" AutoPostBack="True" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <%-- 
                <asp:AsyncPostBackTrigger ControlID="chkmarcarTodos" EventName="CheckedChanged" />
                --%>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="QuantitivoGrs">
        <asp:UpdatePanel ID="updGrid" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gridConsultores" runat="server" AutoGenerateColumns="False" Width="274px" OnLoad="gridConsultores_Load" CellSpacing="-1">
                    <Columns>
                        <asp:BoundField DataField="GerenteRelacionamento" HeaderText="Consultor" />
                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>

</div>
