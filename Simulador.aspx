<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Simulador.aspx.cs" Inherits="DPromocional.Simulador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <link href="css/Simulador.css" rel="stylesheet" />
    <script type="text/javascript" src="scripts/jquery.js"></script>    
    <script type="text/javascript" src="scripts/jquery.numberformatter.js"></script>
    <script type="text/javascript" src="scripts/jquery.numeric.js"></script>
    <script type="text/javascript" src="scripts/Simulador.js"></script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <h5>Simulador de Vendas</h5>
    <br />
    <table style="width: 100%;" id="gridProduto">
        <tbody>
            <!-- Produtos -->
            <tr>
                <th style="width: 48%">Produto</th>
                <th style="width: 10%">Vl Produto</th>
                <th style="width: 10%">Mon</th>
                <th style="width: 10%">Qtde</th>
                <th style="width: 20%">Valor Total</th>
                <th style="width: 2%" class="btExcluirTh"></th>
            </tr>
            <tr>
                <td class="editavel">
                    <asp:DropDownList ID="ddlListaProduto" runat="server" Width="100%" ClientIDMode="Static" CssClass="classListaProduto"></asp:DropDownList>
                </td>
                <td align="right">&nbsp;</td>
                <td align="right">&nbsp;</td>
                <td class="editavel">
                    <input id="txtQuantidade" type="text" class="txtQuantidade" style="width: 97%; text-align: right" />
                </td>
                <td class="tdTotal" align="right">&nbsp;</td>
                <td class="btExcluir">
                    <img title="Excluir a linha" alt ="Excluir a linha" src="img/deletar.gif" class="botaoExcluir"/>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="linhaTotalizadora" align="right">
                    Sub Total Produtos
                </td>
                <td class="tdTotGeral linhaTotalizadora" align="right">
                    0,00
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>
            <tr>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
            </tr>
             
            <!-- Serviços -->
            <tr class="classHeaderServicos">
                <th colspan="2">Serviços</th>
                <th>Vl</th>                
                <th>Qtde</th>
                <th>Valor Total</th>
                <th class="btExcluirTh"></th>
            </tr>
            
            <tr class="classLinhaServico">
                <td class="editavel tdSubTituloBranco" colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" ClientIDMode="Static" CssClass="classListaServico">
                        <asp:ListItem Selected="True">--- Selecione o Serviço ---</asp:ListItem>
                        <asp:ListItem Value="60,00">TAXA SEDEX</asp:ListItem>
                        <asp:ListItem Value="1,00">KM</asp:ListItem>
                        <asp:ListItem Value="150,00 ">ASSISTÊNCIA 24Hs Carro e Moto</asp:ListItem>
                        <asp:ListItem Value="250,00 ">ASSISTÊNCIA 24Hs Utilitário</asp:ListItem>
                        <asp:ListItem Value="26,00">TX DE ENTREGA</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">&nbsp;</td>                
                <td class="editavel">
                    <input id="Text1" type="text" class="txtQuantidadeServico" style="width: 97%; text-align: right" />
                </td>
                <td class="tdTotalServico" align="right">&nbsp;</td>
                <td class="btExcluir">
                    <img title="Excluir a linha" alt ="Excluir a linha" src="img/deletar.gif" class="botaoExcluirServico"/>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="linhaTotalizadora" align="right">
                    Sub Total Serviços
                </td>
                <td class="tdTotGeralServicos linhaTotalizadora" align="right">
                    0,00
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>

            <!-- Subtotal geral -->
            <tr>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" class="linhaTotalizadora" align="right">
                    Sub Total Geral
                </td>
                <td class="tdSubTotGeral linhaTotalizadora" align="right">
                    
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>            
            <!-- Desconto e acréscimos -->
            <tr>
                <td colspan="3" class="linhaTotalizadora" align="right">
                    % de Desconto
                </td>
                <td class="editavel">
                    <input id="txtDesconto" type="text" style="width: 97%; text-align: right" />
                </td>
                <td class="tdPercDesc linhaTotalizadora" align="right">
                    
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>
            
            <tr>
                <td colspan="3" class="linhaTotalizadora" align="right">
                    % de Acréscimo
                </td>
                <td class="editavel">
                    <input id="txtAcrescimo" type="text" style="width: 97%; text-align: right" />
                </td>
                <td class="tdPercAcres linhaTotalizadora" align="right">
                    
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>            
            
            <!-- Total geral -->    
            <tr>
                <td colspan="4" class="linhaTotalizadora" align="right">
                    Total Geral
                </td>
                <td class="tdTotalGeral linhaTotalizadora" align="right">
                    
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>            

            <!-- Formas de pagamento -->
            <tr>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
                <td class="btExcluir">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" class="linhaTotalizadora" align="center">
                    Formas de Pagamentos
                </td>                
            </tr>
            <tr>
                <td colspan="1" class="btExcluir tdSubTitulo" align="center">
                    Dinheiro
                </td>
                <td class="btExcluir tdSubTitulo" align="right">Entrada</td>
                <td class="editavel">
                    <input id="entradaFormaPagamento" type="text" style="width: 97%; text-align: right" />
                </td>
                <td align="center" class="tdSubTitulo">
                    Pc
                </td>              
                <td align="center" class="tdSubTitulo">
                    Total
                </td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>            
            <tr>
                <td colspan="1" class="btExcluir tdSubTitulo" align="center">
                    Cartão
                </td>
                <td class="btExcluir"align="right">&nbsp;</td>                                
                <td class="editavel">
                    <asp:DropDownList ID="ddlParcCartao" runat="server" Width="100%" ClientIDMode="Static" ></asp:DropDownList>
                </td>
                <td align="right" class="tdValParcelaCartao">&nbsp;</td>              
                <td align="right" class="tdGeralCartao">&nbsp;</td>                  
                <td class="btExcluir">&nbsp;</td>                
            </tr>
            <tr>
                <td colspan="1" class="btExcluir tdSubTitulo" align="center">
                    Cheque
                </td>
                <td class="btExcluir"align="right">&nbsp;</td>                                
                <td class="editavel">                    
                    <asp:DropDownList ID="ddlParcCheques" runat="server" Width="100%" ClientIDMode="Static" ></asp:DropDownList>                   
                </td>
                <td align="right" class="tdValParcelaCheque">&nbsp;</td>              
                <td align="right" class="tdGeralCheque">&nbsp;</td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>
            <tr>
                <td colspan="3" class="linhaTotalizadora" align="center">
                    Entrada Boleto
                </td>                
                <td class="tdEntradaBoleto linhaTotalizadora" align="right">
                    0,00
                </td>                
                <td class="linhaTotalizadora" align="center">
                    &nbsp;
                </td>                
            </tr>
            <tr>
                <td colspan="1" class="btExcluir tdSubTitulo" align="center">
                    Boleto
                </td>
                <td class="btExcluir"align="right">&nbsp;</td>                                
                <td class="editavel">
                    <asp:DropDownList ID="ddlParcBoletos" runat="server" Width="100%" ClientIDMode="Static" ></asp:DropDownList>                   
                </td>
                <td align="right" class="tdValParcelaBoleto">&nbsp;</td>              
                <td align="right" class="tdGeralBoleto tdSubTitulo">&nbsp;</td>                
                <td class="btExcluir">&nbsp;</td>                
            </tr>
        </tbody>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
