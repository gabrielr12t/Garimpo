<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Paginas_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
         function erro() {
            swal({
                title:"Ops!",
                text: "Usuário não encontrado ou campos inválidos",
                icon: "error"
            });
        }  
        function desativado() {
            swal({
                title: "Ops!",
                text: "Usuário desativado!!",
                icon: "warning"
            });
        }  

         function senhaIncorreta() {
            swal({
                title: "Ops!",
                text: "Senha incorreta, após 3 tentativas a senha será alterada e enviada uma nova senha ao e-mail!",
                icon: "warning"
            });
        }  
    </script>
    
    <section class="main-content">
        <div id="collapseOne" class="accordion-body in collapse">
            <div class="accordion-inner">
                <div class="row-fluid">
                    <asp:Panel ID="pnlLogin" DefaultButton="btnLogin" runat="server">
                        <div class="span8 pull-right">
                            <h4 class="title"><span class="text"><strong>Efetue o login para continuar</strong></span></h4>
                            E-mail:
                            <div class="controls">
                                <div class="input-prepend">
                                    <span class="add-on"><i class="icon-envelope "></i></span>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-xlarge" placeholder="Digite seu e-mail" type="email"></asp:TextBox>
                                </div><br />
                                <asp:RequiredFieldValidator ID="cvEmail" ValidationGroup="login" ErrorMessage="Campo obrigatório" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                            </div>
                            Senha:
                            <div class="controls">
                                <div class="input-prepend">
                                    <span class="add-on"><i class="icon-lock"></i></span>
                                    <asp:TextBox ID="txtSenha" runat="server" CssClass="input-xlarge" placeholder="Digite sua senha" type="password"></asp:TextBox>
                                    <span class="help-inline">mínimo 8 caracteres</span>
                                </div><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="login" ErrorMessage="Campo obrigatório" ControlToValidate="txtSenha" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                            </div>
                            <div class="control-group">
                                <label class="control-label"></label>
                            </div>
                            <div class="actions  col-sm-5  col-xs-6" style="margin-left: 0">
                                <asp:Button ID="btnLogin" CssClass="botao" ValidationGroup="login" runat="server" Text="Continuar" OnClick="btnLogin_Click" />
                                <a href="esqueceuSenha.aspx" class="pull-right" style="text-decoration: underline">Esqueci minha senha</a><br />
                                <a href="/Paginas/Cadastro/CadastroRapidoo.aspx" class="pull-right" style="text-decoration: underline">Cadastrar</a>
                            </div>
                            <asp:Label ID="lblRecebe" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>

                </div>
            </div>
        </div>

    <%--    <script src="../../themes/js/common.js"></script>
        <script src="../../themes/js/jquery.flexslider-min.js"></script>


        <script type="text/javascript">
            $(function () {
                $(document).ready(function () {
                    $('.flexslider').flexslider({
                        animation: "fade",
                        slideshowSpeed: 4000,
                        animationSpeed: 600,
                        controlNav: false,
                        directionNav: true,
                        controlsContainer: ".flex-container" // the container that holds the flexslider
                    });
                });
            });
        </script>--%>
    </section>
</asp:Content>

