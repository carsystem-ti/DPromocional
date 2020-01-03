<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagamentoLiberacao.ascx.cs" Inherits="DPromocional.dpAscx.PagamentoLiberacao" %>

<%@ Register TagPrefix="My" TagName="Carregando" Src="~/dpAscx/Carregando.ascx" %>

<link href="css/comum.css" rel="stylesheet" />
<link href="css/PagamentoLiberacao.css" rel="stylesheet" />

<script src="scripts/jquery.js"></script>
<script src="scripts/PagamentoLiberacao.js"></script>


<div>
    <My:Carregando ID="Carregando" runat="server"></My:Carregando>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbMensError" runat="server" Text="Erro !" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gridBusca" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="BTBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="divLimpaEsquerda">
        <h5>Busca</h5>
        <div class="divLeft">
            <div class="divLeft">
                <asp:Label ID="Label1" runat="server" Text="">Opções de Busca</asp:Label>
                <br />
                <asp:DropDownList ID="ddlOpcoesBusca" runat="server" Width="150px" ClientIDMode="Static">
                    <asp:ListItem Selected="True" Value="Contrato">Número de Contrato</asp:ListItem>
                    <asp:ListItem Value="Placa">Placa do Veículo</asp:ListItem>
                    <asp:ListItem Value="CPF">CPF/CNPJ</asp:ListItem>
                    <asp:ListItem Value="Indicador">Indicador</asp:ListItem>
                    <asp:ListItem Value="Carteira">Minha Carteira</asp:ListItem>
                    <asp:ListItem Value="Dias">Próximos 10 dias</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lbValor" runat="server" Text="" ClientIDMode="Static">Digite o valor</asp:Label>
                <br />
                <asp:TextBox ID="txtValor" runat="server" Width="145px" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div id="divBtnBuscar">
                <asp:Button ID="BTBuscar" runat="server" Text="Buscar" OnClick="BTBuscar_Click" Width="100px" />
            </div>
        </div>
        <div id="divResultadoBusca">
            <table class="divCabecGrid">
                <thead>
                    <tr>
                        <th id="colBuscaCodigo" runat="server" class="colCodigo">Código</th>
                        <th id="colBuscaNome" runat="server" class="colNome">Nome</th>
                        <th class="colDocumento">Documento</th>
                        <th id="colBuscaContrato" runat="server" class="colContrato">Contrato</th>
                        <th id="colBuscaCodGr" runat="server" class="colCodGr">CodGr</th>
                    </tr>
                </thead>
            </table>
            <div id="divGridResultadoBusca">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gridBusca" runat="server" CellSpacing="-1" ClientIDMode="Static" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="gridBusca_RowDataBound" OnSelectedIndexChanging="gridBusca_SelectedIndexChanging" Width="100%" EmptyDataText="&nbsp;">
                            <Columns>
                                <asp:BoundField DataField="Código" HeaderText="Código" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome" ItemStyle-CssClass="colNome" />
                                <asp:BoundField DataField="Documento" HeaderText="Documento" ItemStyle-CssClass="colDocumento" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Contrato" HeaderText="Contrato" ItemStyle-CssClass="colContrato" ItemStyle-HorizontalAlign="right" />
                                <asp:BoundField DataField="CodGr" HeaderText="CodGr" ItemStyle-CssClass="colCodGr" />
                                <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect" />
                            </Columns>
                            <SelectedRowStyle CssClass="selectRowTD" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTBuscar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div id="divGridValoresIndicacoes">
        <h5>Valores Indicações</h5>
        <table class="divCabecGrid">
            <thead>
                <tr>
                    <th class="colVlIndicacao">Indicação</th>
                    <th class="colVlNome">Nome</th>
                    <th class="colVlDataLiberacao">Data da Liberação</th>
                    <th class="colVlDataPagamento">Data de Pagamento</th>
                    <th class="colVlStatus">Status</th>
                    <th class="colVlDataCadastro">Data do Cadastro</th>
                </tr>
            </thead>
        </table>
        <div id="divGridValoresIndicacoes2">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gridValoresIndicacoes" runat="server" CellSpacing="-1" ClientIDMode="Static" AutoGenerateColumns="false" ShowHeader="false" Width="100%" EmptyDataText="&nbsp;">
                        <Columns>
                            <asp:BoundField DataField="Indicacao" ItemStyle-CssClass="colVlIndicacao" ItemStyle-HorizontalAlign="right" />
                            <asp:BoundField DataField="Nome" ItemStyle-CssClass="colVlNome" />
                            <asp:BoundField DataField="DataLiberacao" ItemStyle-CssClass="colVlDataLiberacao" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DataPagamento" ItemStyle-CssClass="colVlDataPagamento" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Status" ItemStyle-CssClass="colVlStatus" ItemStyle-HorizontalAlign="left" />
                            <asp:BoundField DataField="DataCadastro" ItemStyle-CssClass="colVlDataCadastro" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gridBusca" EventName="SelectedIndexChanging" />
                    <asp:AsyncPostBackTrigger ControlID="BTBuscar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </div>
    <div id="divGridDebitos">
        <h5>Débitos</h5>
        <table class="divCabecGrid">
            <thead>
                <tr>
                    <th class="colCodigoDebito">Código do Débito</th>
                    <th class="colDataVencimento">Data de Vencimento</th>
                    <th class="colValorDebito">Valor do Débito</th>
                    <th class="colSituacao">Situação</th>
                </tr>
            </thead>
        </table>
        <div id="divGridDebitos2">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gridDebitos" runat="server" CellSpacing="-1" ClientIDMode="Static" AutoGenerateColumns="false" ShowHeader="false" Width="100%" EmptyDataText="&nbsp;">
                        <Columns>
                            <asp:BoundField DataField="Codigo do debito" ItemStyle-CssClass="colCodigoDebito" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Dvenc" ItemStyle-CssClass="colDataVencimento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Dvalor do debito" ItemStyle-CssClass="colValorDebito" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Situacao" ItemStyle-CssClass="colSituacao" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gridBusca" EventName="SelectedIndexChanging" />
                    <asp:AsyncPostBackTrigger ControlID="BTBuscar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

</div>
