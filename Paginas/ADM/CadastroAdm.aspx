<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterADM.master" AutoEventWireup="true" CodeFile="CadastroAdm.aspx.cs" Inherits="Paginas_ADM_CadastroAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="main-content">

        <br />
        <div id="collapseOne" class="accordion-body in collapse">
            <div class="accordion-inner">
                <div class="row-fluid">
                    <div class="span11 center">
                        <div class="controls span7">
                            <asp:Label ID="lblConfirmaSenha" runat="server"></asp:Label>
                        </div>
                        <h4 class="title"><span class="text"><strong>Cadastro Rápido</strong></span></h4>
                        <label class="control-label" for="inputIcon">Nome</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-user"></i></span>
                                <asp:TextBox ID="txtNome" runat="server" CssClass="input-xlarge" placeholder="Digite seu nome completo" type="text"></asp:TextBox>
                            </div>
                        </div>
                        <label class="control-label" for="inputIcon">E-mail</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-envelope "></i></span>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="input-xlarge" placeholder="Digite seu e-mail" type="email"></asp:TextBox>
                            </div>
                        </div>

                        <label class="control-label">Senha</label>

                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-lock"></i></span>
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="input-xlarge" placeholder="Digite sua senha" type="password"></asp:TextBox>
                                <%--<span class="help-inline">mínimo 8 caracteres</span> --%>
                            </div>
                            <%--<a data-toggle="tooltip" data-placement="bottom" title="A senha precisa conter 8 caracteres com 1 Letra maiúscula e um número!">mínimo 8 caracteres</a>--%>
                        </div>
                        <label class="control-label">Digite a Senha novamente</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-lock"></i></span>
                                <asp:TextBox ID="txtConfirmaSenha" runat="server" CssClass="input-xlarge" placeholder="Digite sua senha" type="password"></asp:TextBox>
                            </div>
                           <%-- <a data-toggle="tooltip" data-placement="bottom" title="A senha precisa conter 8 caracteres com 1 Letra maiúscula e um número!">mínimo 8 caracteres</a>--%>
                        </div>
                        <label class="control-label" for="inputIcon">CPF/CNPJ</label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-check "></i></span>
                                <asp:TextBox ID="txtCpf" runat="server" CssClass="input-xlarge" placeholder="Digite seu CPF" type="number"></asp:TextBox>
                            </div>
                        </div>
                        <label class="control-label"></label>
                        <div class="controls">
                            <asp:CheckBox ID="ckbAceitar" runat="server" /><asp:Label ID="Label1" runat="server" Text=""> Concordo com os <a href="#" style="text-decoration:underline">termos de uso gerais</a> </asp:Label><br />
                            <br />
                            <asp:Button ID="btnCadastrar" class="botao" type="submit" runat="server" Text="Cadastrar" />
                        </div>
                        <asp:Label ID="lblRetorno" runat="server"></asp:Label>
                        <asp:Label ID="lblSenha" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <script src="../../themes/js/common.js"></script>
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
            $(document).ready(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        </script>
    </section>
</asp:Content>

