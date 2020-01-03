<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndicadoresCS.ascx.cs" Inherits="DPromocional.dpAscx.IndicadoresCS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="My" TagName="carregando" Src="~/dpAscx/Carregando.ascx" %>
<link href="css/PagamentoLiberacao.css" rel="stylesheet" />
<link href="css/comum.css" rel="stylesheet" />
<link href="css/indicadores.css" rel="stylesheet" />
<script src="scripts/jquery.js"></script>
<script src="scripts/PagamentoLiberacao.js"></script>
<script src="scripts/MaskedEditFix.js"></script>
<script src="scripts/Indicadores.js"></script>
<div id="divPrincipal" style="height: 554px">
            <My:carregando ID="carregando" runat="server"></My:carregando>
            <div class="infCliente">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <fieldset class="fildsetDadosBasicos">
                            <legend>Dados Básicos</legend>
                            <div style="width: 467px">
                                <asp:Label ID="Label4" ClientIDMode="Static" runat="server" Text="Cod" CssClass="SubTitulos"
                                    Width="102px" Height="16px"></asp:Label>
                                <asp:Label ID="Label5" ClientIDMode="Static" runat="server" Text="Cliente" CssClass="SubTitulos"
                                    Width="208px" Height="16px"></asp:Label>
                                <asp:Label ID="Label21" runat="server" Text="Cpf_Cnpj"></asp:Label>
                            </div>
                            <div class="TextDadosBasicos">
                                <asp:TextBox ID="TxtCod" runat="server" Width="95px" ClientIDMode="Static"
                                    Height="16px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="TxtCliente" runat="server" Width="199px" Height="16px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="TxtCpf_Cnpf" runat="server" Width="150px" Height="16px" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="Label1" ClientIDMode="Static" runat="server" Text="Contato" CssClass="SubTitulos"
                                    Width="102px" Height="16px"></asp:Label>
                                <asp:Label ID="Label2" ClientIDMode="Static" runat="server" Text="Celular" CssClass="SubTitulos"
                                    Width="208px" Height="16px"></asp:Label>
                                <asp:Label ID="Label3" ClientIDMode="Static" runat="server" Text="Email" CssClass="SubTitulos"
                                    Width="74px" Height="16px"></asp:Label>
                            </div>
                            <div class="divTextDadosBasicos">
                                <asp:TextBox ID="txtContato" runat="server" Width="95px" ClientIDMode="Static"
                                    Height="16px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtCelular" runat="server" Width="199px" Height="16px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtEmail" runat="server" Width="150px" Height="16px" ReadOnly="True"></asp:TextBox>
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="divDadosBancarios">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <fieldset class="fildDadosBancarios">
                            <legend>Dados Banco</legend>
                            <div style="width: 363px">
                                <asp:Label ID="Label7" ClientIDMode="Static" runat="server" Text="Banco" CssClass="SubTitulos"
                                    Width="127px" Height="16px"></asp:Label>
                                <asp:Label ID="Label8" ClientIDMode="Static" runat="server" Text="Agencia" CssClass="SubTitulos"
                                    Width="65px" Height="16px"></asp:Label>
                                <asp:Label ID="Label9" ClientIDMode="Static" runat="server" Text="Dig" CssClass="SubTitulos"
                                    Width="23px" Height="16px"></asp:Label>
                                <asp:Label ID="Label10" ClientIDMode="Static" runat="server" Text="Conta" CssClass="SubTitulos"
                                    Width="62px" Height="16px"></asp:Label>
                                <asp:Label ID="Label11" ClientIDMode="Static" runat="server" Text="Dig" CssClass="SubTitulos"
                                    Width="23px" Height="16px"></asp:Label>
                                <asp:Label ID="Label14" ClientIDMode="Static" runat="server" Text="Oper." CssClass="SubTitulos"
                                    Width="28px" Height="16px"></asp:Label>
                                <div class="divTextDadosBancarios">
                                    <asp:DropDownList ID="dropBancos" runat="server" Height="21px" Width="141px" ClientIDMode="Static" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtAgencia" runat="server" Width="49px" Height="16px" MaxLength="10"></asp:TextBox>
                                    <asp:TextBox ID="txtDigAgencia" runat="server" Width="16px" Height="16px" MaxLength="2"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="txtDigAgencia_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="9" TargetControlID="txtDigAgencia">
                                    </asp:MaskedEditExtender>
                                    <asp:TextBox ID="txtConta" runat="server" Width="62px" Height="16px" ClientIDMode="Static" MaxLength="20"></asp:TextBox>
                                    <asp:TextBox ID="txtdigConta" runat="server" Width="16px" Height="16px" MaxLength="2"></asp:TextBox>
                                    <asp:TextBox ID="txtOperador" runat="server" Width="16px" Height="16px" MaxLength="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="btnAtualizarBancos">
                                <br />
                                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar Banco" Font-Names="Vrinda" Font-Size="Small" ClientIDMode="Static" OnClick="btnAtualizar_Click" Width="141px" Height="27px" />
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="divAgenda">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <fieldset class="fildsetAgenda">
                            <legend>Agendar</legend>
                            <div class="divInternaDadosAgenda">
                                <asp:Label ID="Label20" ClientIDMode="Static" runat="server" Text="Data Agenda" CssClass="SubTitulos"
                                    Width="88px" Height="16px"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtDataAgenda" runat="server" Width="103px" Height="16px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtDataAgenda_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDataAgenda">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtDataAgenda_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDataAgenda" DaysModeTitleFormat="dd/MM/yyyy" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:Button ID="btnAgendamento" runat="server" Text="Agendar"
                                    Width="96px" Height="29px" OnClick="btnAgendamento_Click" ClientIDMode="Static" />
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:Label ID="lblmensagem" CssClass="" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                    </div>
                    <br />
                    <div class="atualiza">
                        <asp:Button ID="btnAtualiza" runat="server" Font-Size="Small" Height="30px" OnClick="btnAtualiza_Click" Text="Atualizar" ClientIDMode="Static" />
                        <asp:Button ID="btnCancelarIndicacao" runat="server" Font-Size="Small" ForeColor="Red" Height="30px" OnClick="btnCancelarIndicacao_Click" Text="Não quer Indicar" Width="142px" ClientIDMode="Static" />
                    </div>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
 <div class="GeralGrid">
                <table class="divCabecGrid" style="width: 662px">
                            <thead>
                                <tr>
                                    <th class="cod">Cod</th>
                                    <th class="doc">Documento</th>
                                    <th class="nome">Nome</th>
                                    <th class="telefone">Telefone</th>
                                    <th class="celular">Celular</th>
                                    <th class="colVlStatus">E-mail</th>
                                </tr>
                            </thead>
                        </table>
                  <div id="painel" class="divInternoGrid">
                         <asp:UpdatePanel ID="updGridIndicadores" runat="server">
                    <ContentTemplate>
                        <p>
                            <asp:GridView ID="gridIndicadores" runat="server" CellSpacing="-1"
                                ClientIDMode="Static" AutoGenerateColumns="False" ShowHeader="false"
                                Width="100%" EmptyDataText="&nbsp;" Font-Size="X-Small" OnRowDataBound="gridIndicadores_RowDataBound" OnSelectedIndexChanging="gridIndicadores_SelectedIndexChanging" Height="178px" Font-Names="Vrinda" OnLoad="gridIndicadores_Load" BorderWidth="2px" OnPreRender="gridIndicadores_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="cod" HeaderText="Código" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right" />
                                    <asp:BoundField DataField="doc" HeaderText="Documento" ItemStyle-CssClass="colDocumento" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cliente" HeaderText="Nome" ItemStyle-CssClass="colNome" />
                                    <asp:BoundField DataField="fone" HeaderText="Telefone" ItemStyle-CssClass="colContrato" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cel" HeaderText="Celular" ItemStyle-CssClass="colCodGr" />
                                    <asp:BoundField DataField="ds_email" HeaderText="E-mail" ItemStyle-CssClass="colCodGr" />
                                    <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect" />
                                </Columns>
                                <SelectedRowStyle CssClass="selectRowTD" />
                            </asp:GridView>
                                </p>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gridIndicadores" EventName="SelectedIndexChanging" />
                        <asp:AsyncPostBackTrigger ControlID="gridIndicadores" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="gridIndicadores" EventName="RowUpdating" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="divgravaIndicacao">
                <asp:UpdatePanel ID="updGravaIndi" runat="server">
                    <ContentTemplate>
                        <fieldset class="fildsetGravarIndicacao">
                            <legend>Gravar Indicação</legend>
                            <asp:Label ID="Label12" ClientIDMode="Static" runat="server" Text="Nome" CssClass="SubTitulos"
                                Width="48px" Height="23px"></asp:Label>
                            <asp:TextBox ID="txtNovoContato" runat="server" Width="232px" Height="16px"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label16" runat="server" ClientIDMode="Static"
                                CssClass="SubTitulos" Height="22px" Text="Email" Width="48px"></asp:Label>
                            <asp:TextBox ID="txtNovoEmail" runat="server" Width="147px" Height="16px" ClientIDMode="Static"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label13" ClientIDMode="Static" runat="server" Text="Fixo" CssClass="SubTitulos"
                                Width="48px" Height="22px"></asp:Label>
                            <asp:TextBox ID="txtNovoFixo" runat="server" Width="100px" Height="16px" ClientIDMode="Static" MaxLength="13"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtNovoFixo_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtNovoFixo" ClearMaskOnLostFocus="False" ClientIDMode="Static">
                            </asp:MaskedEditExtender>
                            <br />
                            <asp:Label ID="Label17" runat="server" ClientIDMode="Static" CssClass="SubTitulos" Height="23px" Text="Celular" Width="48px"></asp:Label>
                            <asp:TextBox ID="txtNovoCelular" runat="server" Width="100px" Height="16px" ClientIDMode="Static" MaxLength="14"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtNovoCelular_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtNovoCelular" ClearMaskOnLostFocus="False">
                            </asp:MaskedEditExtender>
                            <asp:Button ID="btnCadastrarInd" runat="server" CssClass="btnCadastrarInd"
                                Text="Gravar " Width="110px" Height="27px" OnClick="btnCadastrarInd_Click" ClientIDMode="Static" />
                            <br />
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>