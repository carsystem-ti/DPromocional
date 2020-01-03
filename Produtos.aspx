    <%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="DPromocional.Produtos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="css/comum.css" rel="stylesheet" />
    <link href="css/mensagem.css" rel="stylesheet" />
    <link href="css/produtos.css" rel="stylesheet" />
    <script type="text/javascript" src="scripts/jquery.js"></script>
    <script src="scripts/jquery.min.js" type="text/javascript"></script>
    <script  src="scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/MaskedEditFix.js"></script>
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
                            location.href = "http://localhost:52754/pedidos.aspx";
                        }
                    },
                    modal: true
                });
            });
        };
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <br />
    <fieldset style="width: 827px; height: 83px">
        <legend>Selecione os Produtos</legend>
        <div class="Dlabel">
            <asp:Label ID="Label15" runat="server" Height="19px" Text="Produtos" Width="269px"></asp:Label>
            <asp:Label ID="Label16" runat="server" Height="19px" Text="Quantidade" Width="96px"></asp:Label>
            <asp:Label ID="Label17" runat="server" Height="17px" Text="Valor Unitário" Width="148px"></asp:Label>
            <asp:Label ID="Label18" runat="server" Height="19px" Text="Valor Total" Width="98px"></asp:Label>
        </div>
        <div class="selecao">
            <asp:DropDownList ID="dropProduto" runat="server" Height="23px" Width="270px" AutoPostBack="True" OnSelectedIndexChanged="dropProduto_SelectedIndexChanged" DataTextField="dsProduto" DataValueField="cdproduto" ClientIDMode="Static">
            </asp:DropDownList>
            <asp:DropDownList ID="dropQuantidade" runat="server" Height="23px" Width="97px" AutoPostBack="True" OnSelectedIndexChanged="dropQuantidade_SelectedIndexChanged">
                <asp:ListItem Value="0">Selecione</asp:ListItem>
                <asp:ListItem Value="01">01</asp:ListItem>
                <asp:ListItem Value="02">02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
                <asp:ListItem>32</asp:ListItem>
                <asp:ListItem>33</asp:ListItem>
                <asp:ListItem>34</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>36</asp:ListItem>
                <asp:ListItem>37</asp:ListItem>
                <asp:ListItem>38</asp:ListItem>
                <asp:ListItem>39</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>41</asp:ListItem>
                <asp:ListItem>42</asp:ListItem>
                <asp:ListItem>43</asp:ListItem>
                <asp:ListItem>44</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>46</asp:ListItem>
                <asp:ListItem>47</asp:ListItem>
                <asp:ListItem>48</asp:ListItem>
                <asp:ListItem>49</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
                <asp:ListItem>32</asp:ListItem>
                <asp:ListItem>33</asp:ListItem>
                <asp:ListItem>34</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>36</asp:ListItem>
                <asp:ListItem>37</asp:ListItem>
                <asp:ListItem>38</asp:ListItem>
                <asp:ListItem>39</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>41</asp:ListItem>
                <asp:ListItem>42</asp:ListItem>
                <asp:ListItem>43</asp:ListItem>
                <asp:ListItem>44</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>46</asp:ListItem>
                <asp:ListItem>47</asp:ListItem>
                <asp:ListItem>48</asp:ListItem>
                <asp:ListItem>49</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>51</asp:ListItem>
                <asp:ListItem>52</asp:ListItem>
                <asp:ListItem>53</asp:ListItem>
                <asp:ListItem>54</asp:ListItem>
                <asp:ListItem>55</asp:ListItem>
                <asp:ListItem>56</asp:ListItem>
                <asp:ListItem>57</asp:ListItem>
                <asp:ListItem>58</asp:ListItem>
                <asp:ListItem>59</asp:ListItem>
                <asp:ListItem>60</asp:ListItem>
                <asp:ListItem>61</asp:ListItem>
                <asp:ListItem>62</asp:ListItem>
                <asp:ListItem>63</asp:ListItem>
                <asp:ListItem>64</asp:ListItem>
                <asp:ListItem>65</asp:ListItem>
                <asp:ListItem>66</asp:ListItem>
                <asp:ListItem>67</asp:ListItem>
                <asp:ListItem>68</asp:ListItem>
                <asp:ListItem>69</asp:ListItem>
                <asp:ListItem>70</asp:ListItem>
                <asp:ListItem>71</asp:ListItem>
                <asp:ListItem>72</asp:ListItem>
                <asp:ListItem>73</asp:ListItem>
                <asp:ListItem>74</asp:ListItem>
                <asp:ListItem>75</asp:ListItem>
                <asp:ListItem>76</asp:ListItem>
                <asp:ListItem>77</asp:ListItem>
                <asp:ListItem>78</asp:ListItem>
                <asp:ListItem>79</asp:ListItem>
                <asp:ListItem>80</asp:ListItem>
                <asp:ListItem>81</asp:ListItem>
                <asp:ListItem>82</asp:ListItem>
                <asp:ListItem>83</asp:ListItem>
                <asp:ListItem>84</asp:ListItem>
                <asp:ListItem>85</asp:ListItem>
                <asp:ListItem>86</asp:ListItem>
                <asp:ListItem>87</asp:ListItem>
                <asp:ListItem>88</asp:ListItem>
                <asp:ListItem>89</asp:ListItem>
                <asp:ListItem>90</asp:ListItem>
                <asp:ListItem>91</asp:ListItem>
                <asp:ListItem>92</asp:ListItem>
                <asp:ListItem>93</asp:ListItem>
                <asp:ListItem>94</asp:ListItem>
                <asp:ListItem>95</asp:ListItem>
                <asp:ListItem>96</asp:ListItem>
                <asp:ListItem>97</asp:ListItem>
                <asp:ListItem>98</asp:ListItem>
                <asp:ListItem>99</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TxtvlUnitario" runat="server" ReadOnly="True" Height="19px"></asp:TextBox>
            <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Height="19px"></asp:TextBox>
            <asp:Button ID="btnIncluir" runat="server" Font-Bold="True" Height="31px" OnClick="btnIncluir_Click" Text="Incluir" Width="95px" Visible="False" ClientIDMode="Static" />
        </div>
    </fieldset>
    <div style="float: left; width: 1197px;">
        <fieldset id="produtos" runat="server" visible="false">
            <legend style="color: #000000; height: 43px;">Produtos Selecionados</legend>
            <asp:GridView ID="GridProdutos" runat="server" AutoGenerateColumns="False" Font-Names="Franklin Gothic Book"
                Font-Size="Small" HorizontalAlign="Center" PageSize="8" CssClass="fundo"
                Width="454px" Height="16px" OnRowDeleting="GridProdutos_RowDeleting"
                OnDataBound="GridProdutos_DataBound" ShowFooter="True" CellSpacing="-1" OnRowDataBound="GridProdutos_RowDataBound">
                <AlternatingRowStyle BorderColor="DarkCyan" />
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo">
                        <FooterStyle Font-Names="Vrinda" Font-Size="Medium" />
                        <HeaderStyle Font-Names="Vrinda" Font-Size="Medium" Font-Strikeout="False" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Produto" DataField="produto">
                        <FooterStyle Font-Names="Vrinda" Font-Size="Medium" HorizontalAlign="Left" />
                        <HeaderStyle Font-Names="Vrinda" Font-Size="Medium" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Qtde." DataField="Qtde">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="VL.Unitário" DataField="VL.Unitário" />
                    <asp:BoundField HeaderText="VL.Total" DataField="VL.Total"></asp:BoundField>
                    <asp:CommandField ButtonType="Image" HeaderText="Excluir" DeleteImageUrl="~/img/excluir.png"
                        ShowDeleteButton="True" />
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
            <fieldset id="endereco" runat="server" style="width: 1178px; height: 143px">
                <legend>Dados Entrega</legend>
                <div class="Dlabel">
                    <asp:Label ID="lblcep" runat="server" Height="16px" Text="Cep" Width="202px"></asp:Label>
                    <asp:Label ID="lblEndereco" runat="server" Height="16px" Text="Endereço" Width="276px"></asp:Label>
                    <asp:Label ID="lblnumero" runat="server" Height="16px" Text="Número" Width="66px"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Height="16px" Text="Complemento" Width="159px"></asp:Label>
                    <asp:Label ID="lblBairro" runat="server" Height="16px" Text="Bairro" Width="159px"></asp:Label>
                    <asp:Label ID="lblCidade" runat="server" Height="16px" Text="Cidade" Width="99px"></asp:Label>
                    <asp:Label ID="lblUF" runat="server" Height="16px" Text="UF" Width="49px"></asp:Label>
                </div>
                <div class="selecao">
                    <asp:TextBox ID="txtCep" runat="server" Width="103px" Height="16px" ClientIDMode="Static"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtCep_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99999-999" MaskType="Number" TargetControlID="txtCep">
                    </asp:MaskedEditExtender>
                    <asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="~/img/buscar.png" Height="18px" Width="93px" OnClick="imgBuscar_Click" />
                    <asp:TextBox ID="TxtEndereco" runat="server" Height="16px" Width="274px" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtNumero" runat="server" Height="16px" Width="54px"></asp:TextBox>
                    <asp:TextBox ID="txtComplemento" runat="server" Height="16px" Width="155px"></asp:TextBox>
                    <asp:TextBox ID="txtBairro" runat="server" Height="16px" Width="159px" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtCidade" runat="server" Height="16px" Width="93px" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtUf" runat="server" Height="16px" Width="46px" Enabled="False"></asp:TextBox>
                </div>
                <br />
                <div style="float: left">
                    <asp:TextBox ID="txtobs" runat="server" Height="33px" Width="974px" TextMode="MultiLine">Observações do Pedido</asp:TextBox>
                </div>
            </fieldset>
            <br />
            <div style="float: left; margin-left: 73%; margin-top: -1px;">
                <asp:Button ID="btnConfirmar" runat="server" CssClass="ab-boton" Height="36px" Text="Confirmar Pedido" Width="178px" OnClick="btnConfirmar_Click" />
            </div>
        </fieldset>
    </div>

</asp:Content>
