<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Vinculacao.aspx.cs" Inherits="DPromocional.Vinculacao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/comum.css" rel="stylesheet" />
    <link href="css/mensagem.css" rel="stylesheet" />
    <link href="css/Vinculacao.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/funcoes.js"></script>
    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup(message) {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="dialog" style="display: none">
        <asp:Label ID="Label2" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="Dlabel">
        <asp:RadioButtonList ID="rdbFiltro" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbFiltro_SelectedIndexChanged" Font-Names="Vrinda" Font-Size="Small" ClientIDMode="Static">
            <asp:ListItem Value="1">PEDIDOS ABERTOS</asp:ListItem>
            <asp:ListItem Value="2">ENVIADO CADASTRO</asp:ListItem>
            <asp:ListItem Value="3">APROVADO CADASTRO</asp:ListItem>
            <asp:ListItem Value="4">RECUSADO CADASTRO</asp:ListItem>
            <asp:ListItem Value="5">EXPEDIÇÃO</asp:ListItem>
            <asp:ListItem Value="6">EM ENTREGA</asp:ListItem>
            <asp:ListItem Value="7">CONFIRMADO</asp:ListItem>
            <asp:ListItem Value="8">CANCELADO</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div id="filtro" runat="server" visible="false" class="Dlabel">
        <asp:Label ID="lblcep" runat="server" Height="16px" Text="Data Inicial" Width="90px"></asp:Label>
        <asp:Label ID="lblEndereco" runat="server" Height="17px" Text="Data Final" Width="98px"></asp:Label>
        <asp:Label ID="lblnumero" runat="server" Height="16px" Text="Franquias" Width="66px"></asp:Label>
    </div>
    <div id="selecao" runat="server" visible="false" class="selecao">
        <asp:TextBox ID="txtDataInicial" runat="server" Height="16px" Width="84px"></asp:TextBox>
        <asp:CalendarExtender ID="txtDataInicial_CalendarExtender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDataInicial">
        </asp:CalendarExtender>
        <asp:TextBox ID="txtDataFinal" runat="server" Height="16px" Width="91px"></asp:TextBox>
        <asp:CalendarExtender ID="txtDataFinal_CalendarExtender" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDataFinal">
        </asp:CalendarExtender>
        <asp:DropDownList ID="dropFranquias" runat="server" Height="26px" Width="242px" DataTextField="ds_franquia" DataValueField="id_franquia">
        </asp:DropDownList>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ClientIDMode="Static" TabIndex="78" OnLoad="btnBuscar_Load" />
    </div>
    <div>
        <asp:Label ID="lblmensagem" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
    <fieldset>
        <div id="divGrid" runat="server" style="width: 521px">
            <p style="width: 564px">
                <asp:GridView ID="GridPedidosAbertos" runat="server" CellSpacing="-1"
                    ClientIDMode="Static" AutoGenerateColumns="False"
                    Width="136%" EmptyDataText="&nbsp;" Font-Size="X-Small" OnRowDataBound="GridPedidosAbertos_RowDataBound" Height="125px" Font-Names="Vrinda" BorderWidth="2px" OnSelectedIndexChanged="GridPedidosAbertos_SelectedIndexChanged" OnPreRender="GridPedidosAbertos_PreRender" AllowPaging="True" PageSize="8">
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigo" HeaderText="Codigo" ItemStyle-CssClass="colDocumento" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="colDocumento" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_produto" HeaderText="Produto" ItemStyle-CssClass="colNome">
                            <ItemStyle CssClass="colNome" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qt_compra" HeaderText="Qtde." ItemStyle-CssClass="colContrato" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="colContrato" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dt_pedido" HeaderText="Data" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_usuarioPedido" HeaderText="Usúario" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                            <ItemStyle CssClass="divSomeSelect" />
                        </asp:CommandField>
                    </Columns>
                    <SelectedRowStyle CssClass="selectRowTD" />
                </asp:GridView>
            </p>
        </div>
        </div>
    </fieldset>
    <div id="vincular" runat="server" visible="false" style="float: right; margin-top: -110px; margin-right: 4%; width: 459px;">
        <fieldset style="width: 446px">
            <div style="float: left;">
                <asp:Label ID="Label5" runat="server" Height="16px" Text="Pedido" Width="90px"></asp:Label>
                <asp:Label ID="Label1" runat="server" Height="16px" Text="Item Pedido" Width="90px"></asp:Label>
                <asp:Label ID="Label3" runat="server" Height="16px" Text="Quantidade" Width="98px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Height="18px" Text="ID/RAST" Width="91px"></asp:Label>
            </div>
            <br />
            <div style="float: left; width: 438px;">
                <asp:TextBox ID="txtPedidoCompra" runat="server" Height="16px" Width="84px" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="txtPedido" runat="server" Height="16px" Width="84px" ReadOnly="True"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDataInicial">
                </asp:CalendarExtender>
                <asp:TextBox ID="txtQuantidade" runat="server" Height="16px" Width="45px" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="TxtPeca" runat="server" Height="16px" Width="81px" OnLoad="TxtPeca_Load" MaxLength="6"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" DaysModeTitleFormat="dd/MM/yyyy" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDataFinal">
                </asp:CalendarExtender>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" OnClick="btnIncluir_Click" Height="36px" ClientIDMode="Static" OnLoad="btnIncluir_Load" />
            </div>
        </fieldset>
    </div>
    <div style="float: left; margin-top: 4px; margin-left: 29%">
        <div id="pedidos" runat="server" visible="false">
            <asp:GridView ID="GridPedidos" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="White" BorderStyle="Solid" Font-Names="Franklin Gothic Book"
                Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" PageSize="8" Width="511px"
                Height="16px" ShowFooter="True" OnDataBound="GridPedidos_DataBound" OnRowDeleting="GridPedidos_RowDeleting" CellSpacing="-1">
                <AlternatingRowStyle BorderColor="DarkCyan" />
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="codigo">
                        <FooterStyle Font-Names="Franklin Gothic Book" Font-Size="Small" />
                        <HeaderStyle Font-Names="Franklin Gothic Book" Font-Size="Small" Font-Strikeout="False"
                            HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Item Pedido" DataField="pedido">
                        <FooterStyle Font-Names="Franklin Gothic Book" Font-Size="Small" />
                        <HeaderStyle Font-Names="Franklin Gothic Book" Font-Size="Small" Font-Strikeout="False"
                            HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ID/LOC" DataField="peca">
                        <FooterStyle Font-Names="Franklin Gothic Book" Font-Size="Small" HorizontalAlign="Left" />
                        <HeaderStyle Font-Names="Franklin Gothic Book" Font-Size="Small" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:CommandField HeaderText="Excluir" ShowDeleteButton="True" ButtonType="Image"
                        DeleteImageUrl="~/img/excluir.png" />
                </Columns>
                <EditRowStyle BorderColor="#B34A06" />
                <EmptyDataRowStyle BorderColor="#628AA2" />
                <FooterStyle BackColor="#CCCCCC" BorderColor="#B34A06" />
                <HeaderStyle BackColor="DarkCyan" BorderColor="#360486" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="DarkCyan" BorderColor="#360486" Font-Names="Franklin Gothic Book"
                    ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BorderColor="#B34A06" />
                <SelectedRowStyle BackColor="DarkCyan" BorderColor="DarkCyan" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" BorderColor="DarkCyan" />
                <SortedAscendingHeaderStyle BackColor="Gray" BorderColor="#B34A06" />
                <SortedDescendingCellStyle BackColor="DarkCyan" />
                <SortedDescendingHeaderStyle BackColor="DarkCyan" />
            </asp:GridView>
        </div>
    </div>
    <div id="finalizar" runat="server" visible="false" style="float: right; margin-top: 5px; margin-right: 45%">
        <asp:Button ID="btnFinaliza" runat="server" Text="Finalizar Distribuição" OnClick="btnFinaliza_Click" Width="219px" />

    </div>
    <div id="DivAprovacaoPedido" runat="server" visible="false" style="float: left; margin-top: 5px; margin-right: 45%; width: 348px;">
        <asp:Button ID="btnAprovarPedido" runat="server" Text="Aprovar Pedido" Width="170px" OnClick="btnAprovarPedido_Click" />
        <asp:Button ID="btnReprovarPedido" runat="server" OnClick="btnReprovarPedido_Click" Text="Reprovar Pedido" Width="157px" />
    </div>
    <div id="DivNumeroNota" runat="server" visible="false" style="float: left; margin-top: 5px; width: 455px;">
        <asp:Label ID="Label6" runat="server" Text="Número da Nota"></asp:Label><asp:TextBox ID="txtNrNota" runat="server"></asp:TextBox>
        <asp:Button ID="btnVincularNota" runat="server" OnClick="btnVincularNota_Click" Text="Vincular" Width="107px" Height="29px" />
    </div>
</asp:Content>
