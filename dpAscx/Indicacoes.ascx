<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Indicacoes.ascx.cs" Inherits="DPromocional.dpAscx.Indicacoes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="My" TagName="Carregando" Src="~/dpAscx/Carregando.ascx" %>

<link href="css/comum.css" rel="stylesheet" />
<link href="css/Indicacoes.css" rel="stylesheet" />

<script type="text/javascript" src="scripts/MaskedEditFix.js"></script>

<div id="divPrincipal">
    <My:Carregando ID="Carregando" runat="server"></My:Carregando>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbMensError" Font-Bold="True" ForeColor="Red" runat="server" Text="Erro" Visible="false"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gridIndicadores" EventName="RowUpdating" />
            <asp:AsyncPostBackTrigger ControlID="btGrava" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="divEsquerda">
        <h5>Indicadores</h5>
        <div class="divWidth100">
            <table class="divCabecGrid">
                <thead>
                    <tr>
                        <th class="colIndicadoresCod">Cód</th>
                        <th class="colIndicadoresInd">Indicador</th>
                        <th class="colIndicadoresDoc">Doc</th>
                    </tr>
                </thead>
            </table>
        </div>
        <div id="divGridIndicadores">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gridIndicadores" runat="server" CellSpacing="-1" AutoGenerateColumns="false" ShowHeader="false" Width="100%" EmptyDataText="&nbsp;" OnRowDataBound="gridIndicadores_RowDataBound" OnSelectedIndexChanging="gridIndicadores_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Cod" ItemStyle-CssClass="colIndicadoresCod" ItemStyle-HorizontalAlign="right" />
                            <asp:BoundField DataField="Indicador" ItemStyle-CssClass="colIndicadoresInd" />
                            <asp:BoundField DataField="Doc" ItemStyle-CssClass="colIndicadoresDoc" ItemStyle-HorizontalAlign="Center" />
                            <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect" />
                        </Columns>
                        <SelectedRowStyle CssClass="selectRowTD" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="divDireita">
        <div class="divMetadeSuperior">
            <h5>Indicação</h5>
            <div class="divWidth100">
                <table class="divCabecGrid">
                    <thead>
                        <tr>
                            <th class="colIndicacaoCod">Cód</th>
                            <th class="colIndicacaoIndicado">Indicado</th>
                            <th class="colIndicacaoTelefone">Tel.</th>
                            <th class="colIndicacaoCelular">Cel.</th>
                            <th class="colIndicacaoEMail">e-Mail</th>
                            <th class="colIndicacaoStatus">Status</th>
                            <th class="colIndicacaoCT">CT</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div id="divGridIndicacao">
                <asp:UpdatePanel ID="upPanelIndicacao" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gridIndicacao" runat="server" CellSpacing="-1" AutoGenerateColumns="false" ShowHeader="false" Width="100%" EmptyDataText="&nbsp;" ClientIDMode="Static" OnRowCreated="gridIndicacao_RowCreated" OnRowCommand="gridIndicacao_RowCommand" OnRowDataBound="gridIndicadores_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Cod" ItemStyle-CssClass="colIndicacaoCod" ItemStyle-HorizontalAlign="right" />
                                <asp:BoundField DataField="Indicado" ItemStyle-CssClass="colIndicacaoIndicado" />
                                <asp:BoundField DataField="Telefone" ItemStyle-CssClass="colIndicacaoTelefone" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Celular" ItemStyle-CssClass="colIndicacaoCelular" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="E-Mail" ItemStyle-CssClass="colIndicacaoEMail" />
                                <asp:BoundField DataField="Status" ItemStyle-CssClass="colIndicacaoStatus" />
                                <asp:BoundField DataField="CT" ItemStyle-CssClass="colIndicacaoCT" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="divOpcoesGrid">
                                            <asp:LinkButton ID="lkbEnviaCrm" runat="server" CommandName="EnviaCRM" CommandArgument='<%# Eval("Cod") %>'>Enviar CRM</asp:LinkButton>
                                            <br />
                                            <asp:LinkButton ID="lkbCancela" runat="server" CommandName="CancelarCRM" CommandArgument='<%# Eval("Cod") %>'>Cancelar</asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect" />
                            </Columns>
                            <SelectedRowStyle CssClass="selectRowTD" />
                        </asp:GridView>
                    </ContentTemplate>
                    
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btGrava" EventName="Click" />                        
                        <asp:AsyncPostBackTrigger ControlID="gridIndicadores" EventName="RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="gridIndicacao" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="gridIndicacao" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="gridIndicacao" EventName="RowCreated" />
                    </Triggers>
                        
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="divMetadeSuperior">
            <h5>Agenda</h5>
            <asp:Label ID="Label1" runat="server" Text="Agendar para"></asp:Label>
            <asp:TextBox ID="txtData" runat="server" Width="100px"></asp:TextBox>
            <asp:MaskedEditExtender runat="server"
                ID="MaskDatatxtData"
                TargetControlID="txtData"
                Mask="99/99/9999"
                MaskType="Date"
                MessageValidatorTip="true" />
            <asp:CalendarExtender
                runat="server"
                ID="CalendartxtData"
                TargetControlID="txtData"
                ClientIDMode="Static"
                CssClass="calendario" />

            <asp:Label ID="Label2" runat="server" Text="as"></asp:Label>
            <asp:TextBox ID="txtHora" runat="server" Width="80px"></asp:TextBox>
            <asp:MaskedEditExtender runat="server"
                ID="MaskDatatxtHora"
                TargetControlID="txtHora"
                Mask="99:99"
                MaskType="Time"
                MessageValidatorTip="true" />
            <asp:Button ID="btGrava" runat="server" Width="110px" Text="Gravar" OnClick="Button1_Click" />
            <div class="divWidth100">
                <table class="divCabecGrid">
                    <thead>
                        <tr>
                            <th class="colAgendaCod">Cód</th>
                            <th class="colAgendaInd">Ind</th>
                            <th class="colAgendaNome">Nome</th>
                            <th class="colAgendaData">Data</th>
                            <th class="colAgendaTel">Tel</th>
                            <th class="colAgendaCel">Cel</th>
                            <th class="colAgendaEMail">e-Mail</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div id="divGridAgenda">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gridAgenda" runat="server" CellSpacing="-1" AutoGenerateColumns="false" ShowHeader="false" Width="100%" EmptyDataText="&nbsp;" ClientIDMode="Static">
                            <Columns>
                                <asp:BoundField DataField="Cod" ItemStyle-CssClass="colAgendaCod" ItemStyle-HorizontalAlign="right" />
                                <asp:BoundField DataField="Ind" ItemStyle-CssClass="colAgendaInd" ItemStyle-HorizontalAlign="right" />
                                <asp:BoundField DataField="Nome" ItemStyle-CssClass="colAgendaNome" />
                                <asp:BoundField DataField="Data" ItemStyle-CssClass="colAgendaData" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Telefone" ItemStyle-CssClass="colAgendaTel" />
                                <asp:BoundField DataField="Celular" ItemStyle-CssClass="colAgendaCel" />
                                <asp:BoundField DataField="E-Mail" ItemStyle-CssClass="colAgendaEMail" />
                                <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect" />
                            </Columns>
                            <SelectedRowStyle CssClass="selectRowTD" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <%-- <asp:AsyncPostBackTrigger ControlID="gridIndicadores" EventName="RowUpdating" /> --%>
                        <asp:AsyncPostBackTrigger ControlID="btGrava" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
</div>

