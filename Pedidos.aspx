<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="DPromocional.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/comum.css" rel="stylesheet" />
    <link href="css/mensagem.css" rel="stylesheet" />
    <script src="scripts/jquery.min.js" type="text/javascript"></script>
    <script src="scripts/jquery-ui.js" type="text/javascript"></script>
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


        $("#divLoading").ajaxStart(function () {
            $(this).show();
        });

        $("#divLoading").ajaxStop(function () {
            $(this).hide();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divLoading" align="center" style="display: none">
    </div>
    <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="lblmensagem" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    </div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div id="divLoad">
                <asp:Image ID="imgLoad" runat="server" ImageUrl="~/img/carregando.gif" ImageAlign="Middle" ClientIDMode="Static" />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" ForeColor="OrangeRed">Carregando ...</asp:Label>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rdbFiltro" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GridPedidosAbertos" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="GridPedidosAbertos" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="GridPedidosAbertos" EventName="RowUpdating" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="updGrid" runat="server">
        <ContentTemplate>
            <div id="grid" runat="server" visible="false" style="float: left;">
                <asp:GridView ID="GridPedidosAbertos" runat="server" CellSpacing="-1"
                    ClientIDMode="Static" AutoGenerateColumns="False"
                    Width="179%" EmptyDataText="&nbsp;" Font-Size="Small" OnRowDataBound="GridPedidosAbertos_RowDataBound" Height="16px" BorderColor="DarkCyan" Font-Names="Vrinda" DataKeyNames="id_pedido" AllowPaging="True" OnSelectedIndexChanged="GridPedidosAbertos_SelectedIndexChanged" OnPreRender="GridPedidosAbertos_PreRender">
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dt_pedido" HeaderText="Data" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="produto" HeaderText="Produto" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qt_compra" HeaderText="QtCompra" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_status" HeaderText="Status Pedido" />
                        <asp:BoundField DataField="ds_usuarioPedido" HeaderText="Usúario" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                            <ItemStyle CssClass="divSomeSelect" />
                        </asp:CommandField>
                    </Columns>
                    <SelectedRowStyle CssClass="selectRowTD" />
                </asp:GridView>
                <div id="divItem" style="float: left; margin-left: 80%; width: 356px;" runat="server" visible="false">
                    <asp:GridView ID="GridItem" runat="server" CellSpacing="-1"
                        ClientIDMode="Static" AutoGenerateColumns="False"
                        Width="98%" EmptyDataText="&nbsp;" Font-Size="Small" Height="16px" BorderColor="DarkCyan" Font-Names="Vrinda" DataKeyNames="id_Sbc" AllowPaging="True" OnRowDataBound="GridItem_RowDataBound" OnSelectedIndexChanged="GridItem_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                                <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" Font-Size="Small" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id_Sbc" HeaderText="Peça" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                                <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" Font-Size="Small" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Aceite">
                                <ItemTemplate>
                                    <div class="divGridIndicacao">
                                        <asp:LinkButton ID="lnkAceite" runat="server" CommandName="Aceite" CommandArgument="1">Aceite</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                                <ItemStyle CssClass="divSomeSelect" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle Font-Size="Small" />
                        <HeaderStyle Font-Size="Small" />
                        <PagerStyle Font-Size="Small" />
                        <RowStyle Font-Size="Small" />
                        <SelectedRowStyle CssClass="selectRowTD" Font-Size="Small" />
                    </asp:GridView>
                </div>
                <br />
                <br />
                <div id="cancelarPedido" runat="server" visible="false" style="float: left;">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Pedido" OnClick="btnCancelar_Click" />
                </div>
                <div id="enviarCadastro" runat="server" visible="false">
                    <asp:Button ID="btnEnviarCadastro" runat="server" Text="Enviar cadastro" Width="156px" OnClick="btnEnviarCadastro_Click" />
                </div>
                <div id="cancela" runat="server" visible="false">
                    <asp:Button ID="btncancelarPedido" runat="server" Text="Cancelar Pedido" Width="156px" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridPedidosAbertos" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="GridPedidosAbertos" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="GridPedidosAbertos" EventName="RowUpdating" />
            <asp:AsyncPostBackTrigger ControlID="rdbFiltro" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
