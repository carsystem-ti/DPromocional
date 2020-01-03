<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VendasIndicador.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dinheiro Promocional</title>    
    <link rel="Stylesheet" type="text/css" href="css/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="principal">
        <div class="imgTop">
            <asp:Image ID="imageCab" ImageUrl="~/img/cabLogin.jpg" runat="server" />
        </div>
        <div class="separadorBranco">
        </div>
        <!-- Div com os dados -->
        <div class="divDados">
            <div class="divLogImg">                
                <img src="img/dinheiro-blog.jpg" />

            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" CssClass="divLoginSenha" Visible="true" ID="pnLogar">
                        <div class="divMensErro">
                            <asp:Label ID="lbMensErro" runat="server" Text="" CssClass="mensErro"></asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mensErro"
                                Text="Digite o usuário !" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>                            
                            <br />
                            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" CssClass="mensErro" Text="Digite a senha !"
                                ControlToValidate="txtSenha"></asp:RequiredFieldValidator>
                        </div>
                        <div class="divLogin">
                            <div class="divEsquerda">
                                <asp:Label ID="Label1" Text="&nbsp;Login:" runat="server" CssClass="rotulo"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox ID="txtLogin" CssClass="confTextCinza" runat="server" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="divSenha">
                            <div class="divEsquerda">
                                <asp:Label ID="lbSenha" Text="Senha:" runat="server" CssClass="rotulo"></asp:Label>
                            </div>
                            <div class="divEsquerda">
                                <asp:TextBox ID="txtSenha" runat="server" MaxLength="20" CssClass="confTextCinza"
                                    TextMode="Password"></asp:TextBox>
                            </div>
                            <div>
                                &nbsp;
                                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="Button1_Click" />
                            </div>
                        </div>
                        <br />                        
                    </asp:Panel>
                    
                    <asp:Panel ID="pnIE7" runat="server" Visible="false">
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lbMensBrowser" runat="server" CssClass="mensErro"  Text="Seu Internet Explorer está desatualizado !"></asp:Label>  
                        <br />  
                        <asp:Label ID="lbMensBrowser2" runat="server" CssClass="mensErro" Text="Para continuar utilizando este site atualize seu Internet Explorer ou use outro navegador. "></asp:Label>    
                    </asp:Panel>                    
                    
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnEntrar" EventName="Click" />                    
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="separadorBranco">
        </div>
        <div class="separadorLaranja">
        </div>
        <div class="separadorBranco">
        </div>
        <div class="separadorCinza">
        </div>
    </div>
    </form>
</body>
</html>
