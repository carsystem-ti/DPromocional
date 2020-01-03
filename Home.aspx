<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DPromocional.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbMensError" runat="server" Text="Erro" ForeColor="Red" Visible="false"></asp:Label>
    <br />
    <br />
    <br />
    <div class="divPrincipal">
        <div class="divEsquerda">
            <div class="divTextoCentro">
                <asp:LinkButton ID="linkDP" runat="server" CssClass="mensMenu" OnClick="linkDP_Click">Dinheiro Promocional</asp:LinkButton>
            </div>
            <asp:ImageButton ID="imgbtnDP" ImageUrl="~/img/financeiro.jpg" runat="server" OnClick="imgbtnDP_Click" />
        </div>

        <div class="divCentral">
            <div class="divTextoCentroDivCentro">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="mensMenu" OnClick="LinkButton1_Click" >Simulador</asp:LinkButton>
            </div>
            <asp:ImageButton ID="ImageButton1" ImageUrl="~/img/Simulador.jpg" runat="server" style="margin-left: 170px" OnClick="ImageButton1_Click"/>
        </div>

        <div class="divDireita">
            <div class="divTextoCentroDivDireita">
                <asp:LinkButton ID="linkRelatorio" runat="server" CssClass="mensMenu" OnClick="linkRelatorio_Click">Relatórios</asp:LinkButton>
            </div>
            <asp:ImageButton ID="imgbtnRelatorio" ImageUrl="~/img/Relatorio.jpg" runat="server" OnClick="imgbtnRelatorio_Click" />
        </div>
    </div>
</asp:Content>
