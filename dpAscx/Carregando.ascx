<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carregando.ascx.cs" Inherits="DPromocional.dpAscx.Carregando" %>

<link href="css/comum.css" rel="stylesheet" />

<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <div id="divLoad">
            <asp:Image ID="imgLoad" runat="server" ImageUrl="~/img/carregando.gif" ImageAlign="Middle" ClientIDMode="Static" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large" ForeColor="OrangeRed">Carregando ...</asp:Label>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
