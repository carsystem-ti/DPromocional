<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="ViewUsuarios.aspx.cs" Inherits="DPromocional.ViewUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="css/comum.css" rel="stylesheet" />
    <link href="css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/MaskedEditFix.js"></script>
    
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="lblmensagem" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    </div>
    <div style="float: left; width: 1212px;">
        <fieldset style="width: 427px">
            <legend>Consultores vinculado a Revenda</legend>
            <asp:GridView ID="GridVendedores" runat="server" CellSpacing="-1"
                ClientIDMode="Static" AutoGenerateColumns="False"
                Width="98%" EmptyDataText="&nbsp;" Font-Size="Small" OnRowDataBound="GridVendedores_RowDataBound" Height="16px" BorderColor="DarkCyan" Font-Names="Vrinda" DataKeyNames="id_vendedor" OnSelectedIndexChanged="GridVendedores_SelectedIndexChanged" OnPageIndexChanging="GridVendedores_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="id_vendedor" HeaderText="Código" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                        <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ds_vendedor" HeaderText="vendedor" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                        <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fl_ativo" HeaderText="Status" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                        <ItemStyle CssClass="colCodGr" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                        <ItemStyle CssClass="divSomeSelect" />
                    </asp:CommandField>
                </Columns>
                <SelectedRowStyle CssClass="selectRowTD" />
            </asp:GridView>

        </fieldset>
    </div>

    <div id="alteracoes" runat="server" visible="false" style="float: right; margin-top: -22%; margin-right: 30%;">
        <fieldset>
            <legend>Opções para (Ativar e Desativar) usúarios</legend>
            <asp:Label ID="Label2" runat="server" Text="Usúario"></asp:Label><asp:TextBox ID="txtUsuarioExistente" runat="server"></asp:TextBox><asp:ImageButton ID="imgAtivar" runat="server" Height="27px" ImageUrl="~/img/ativar.png" OnClick="imgAtivar_Click" /><asp:ImageButton ID="imgDesativar" runat="server" ImageUrl="~/img/excluir.png" OnClick="imgDesativar_Click" />
        </fieldset>
    </div>
    <div style="float: left; margin-top: -14%; margin-left: 40%; width: 498px;">
        <fieldset>
            <legend>Cadastro de vendedores</legend>
            <div>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/usuarios.png" Height="125px" Width="147px" />
            </div>
            <div style="float: left; margin-left: 36%; margin-top: -20%">
                <asp:Label ID="Label1" runat="server" Text="Usúario"></asp:Label><asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>
        </fieldset>
    </div>

</asp:Content>
