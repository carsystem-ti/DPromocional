<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="DPromocional.principal1" %>

<%@ Register TagPrefix="My" TagName="ind" Src="~/dpAscx/IndicadoresCS.ascx" %>
<%@ Register TagPrefix="My" TagName="dist" Src="~/dpAscx/distribuicao.ascx" %>
<%@ Register TagPrefix="My" TagName="PagLib" Src="~/dpAscx/PagamentoLiberacao.ascx" %>
<%@ Register TagPrefix="My" TagName="Indicacoes" Src="~/dpAscx/Indicacoes.ascx" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%">
            <asp:TabPanel  runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Distribuição              
                </HeaderTemplate>
                <ContentTemplate>
                    <My:dist ID="distribuicao" runat="server"></My:dist>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Carteira              
                </HeaderTemplate>
                <ContentTemplate>
                    <My:ind ID="ind" runat="server"></My:ind>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                <HeaderTemplate>
                    Indicação              
                </HeaderTemplate>
                <ContentTemplate>
                    <My:Indicacoes ID="Indicacoes" runat="server"></My:Indicacoes>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Pagamentos/Liberações">
                <HeaderTemplate>
                    Pagamento/Liberações
                </HeaderTemplate>
                <ContentTemplate>
                    <My:PagLib ID="PagLib" runat="server"></My:PagLib>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </div>
</asp:Content>
