<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="CadastroRapidoo.aspx.cs" Inherits="Paginas_Cadastro_CadastroRapidoo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script src="../../themes/js/jquery.mask.min.js"></script>


    <style>
        .swal-overlay {
            background-color: rgba(75, 62, 110,0.45);
        }
    </style>
    <section class="main-content">
        <br />
        <div id="collapseOne" class="accordion-body in collapse">
            <div class="accordion-inner">
                <fieldset>
                    <asp:Panel ID="pnlDados" DefaultButton="btnCadastrar" runat="server">
                        <div class="row-fluid">
                            <div class="span8 pull-right">
                                <div class="controls span7">
                                    <asp:Label ID="lblConfirmaSenha" runat="server"></asp:Label>
                                </div>
                                <h4 class="title"><span class="text"><strong>Cadastro Rápido</strong></span></h4>
                                Nome <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-user"></i></span>
                                        <asp:TextBox ID="txtNome" ValidationGroup="cadastroRapido" runat="server" CssClass="input-xlarge" Style="text-transform: capitalize" placeholder="Digite seu nome completo" type="text"></asp:TextBox>
                                    </div>
                                    <br />

                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtNome" ErrorMessage="Digite seu nome completo" Display="Dynamic" ForeColor="Red" ValidationExpression="([A-Za-z].* [A-Za-z].*)"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="cvNome" ValidationGroup="cadastroRapido" ErrorMessage="Insira seu nome" ControlToValidate="txtNome" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                                </div>
                                E-mail <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-envelope "></i></span>
                                        <asp:TextBox ID="txtEmail" ValidationGroup="cadastroRapido" runat="server" CssClass="input-xlarge" placeholder="Digite seu e-mail" TextMode="email"></asp:TextBox>
                                    </div>
                                    <br />
                                    <asp:RequiredFieldValidator ID="cvEmail" ValidationGroup="cadastroRapido" ErrorMessage="Insira seu e-mail" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                                </div>
                                Senha <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-lock"></i></span>
                                        <asp:Label ID="senha" runat="server">
                                            <asp:TextBox ID="txtSenha" runat="server" ValidationGroup="cadastroRapido" CssClass="input-xlarge" placeholder="Digite sua senha" type="password" MaxLength="18"></asp:TextBox></asp:Label>
                                        <span class="help-inline">mínimo 8 caracteres</span>
                                    </div>
                                    <a data-toggle="tooltip" data-placement="bottom" title="A senha precisa conter 8 caracteres com 1 Letra maiúscula e um número!">mínimo 8 caracteres</a>
                                    <br />
                                    <asp:RegularExpressionValidator ValidationGroup="cadastroRapido" runat="server" Display="dynamic"
                                        ControlToValidate="txtSenha"
                                        ForeColor="Red"
                                        ErrorMessage="A senha deve conter um caracter especial."
                                        ValidationExpression="^.*(?=.*[@#$%^&+=._!]).*$" />
                                    <asp:RegularExpressionValidator ValidationGroup="cadastroRapido" runat="server" Display="dynamic"
                                        ControlToValidate="txtSenha"
                                        ForeColor="Red"
                                        ErrorMessage="A senha deve conter uma letra maiúscula."
                                        ValidationExpression="^.*(?=.*[A-Z]).*$" />
                                    <asp:RegularExpressionValidator ValidationGroup="cadastroRapido" runat="server" Display="dynamic"
                                        ControlToValidate="txtSenha"
                                        ForeColor="Red"
                                        ErrorMessage="A senha deve conter uma letra minúscula."
                                        ValidationExpression="^.*(?=.*[a-z]).*$" />
                                    <asp:RegularExpressionValidator ValidationGroup="cadastroRapido" runat="server" Display="dynamic"
                                        ForeColor="Red"
                                        ControlToValidate="txtSenha"
                                        ErrorMessage="A senha precisa ter de 8 a 18 caracteres"
                                        ValidationExpression="[^\s]{8,18}" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="cadastroRapido" ErrorMessage="Insira a senha" ControlToValidate="txtSenha" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>

                                </div>
                                Digite a Senha novamente <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-lock"></i></span>
                                        <asp:TextBox ID="txtConfirmaSenha" runat="server" ValidationGroup="cadastroRapido" CssClass="input-xlarge" placeholder="Digite sua senha" type="password" MaxLength="18"></asp:TextBox>
                                    </div>
                                    <a data-toggle="tooltip" data-placement="bottom" title="A senha precisa conter 8 caracteres com 1 Letra maiúscula e um número!">mínimo 8 caracteres</a>
                                    <br />
                                    <asp:CompareValidator ID="cvConfirmaSenha" Type="String" ValidationGroup="cadastroRapido" ErrorMessage="Senhas Diferentes" ControlToValidate="txtConfirmaSenha" ControlToCompare="txtSenha" Display="Dynamic" ForeColor="red" runat="server"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="cadastroRapido" ErrorMessage="Repita a senha" ControlToValidate="txtConfirmaSenha" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>

                                </div>
                                CPF/CNPJ <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <div class="input-prepend">
                                        <span class="add-on"><i class="icon-check "></i></span>
                                        <asp:TextBox ID="txtCpf" runat="server" ValidationGroup="cadastroRapido" CssClass="input-xlarge cpf" placeholder="Digite seu CPF"></asp:TextBox>
                                    </div>
                                    <br />
                                    <asp:RequiredFieldValidator ID="cvCpf" ErrorMessage="Insira seu CPF" ValidationGroup="cadastroRapido" ControlToValidate="txtCpf" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ValidationGroup="cadastroRapido" ID="regular" ControlToValidate="txtCpf" ErrorMessage="CPF inválido" Display="Dynamic" ForeColor="Red" ValidationExpression="([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})"></asp:RegularExpressionValidator>
                                </div>
                                <label class="control-label"></label>
                                <div class="controls">
                                    <asp:Label ID="lblAceitar" runat="server">
                                        <asp:CheckBox ID="ckbAceitar" runat="server" ValidationGroup="cadastroRapido" /><asp:Label ID="lblTermos" runat="server"> Concordo com os <a href="#" style="text-decoration:underline">termos de uso gerais</a> </asp:Label><br />
                                    </asp:Label>
                                    <br />
                                    <asp:Button ID="btnCadastrar" ValidationGroup="cadastroRapido" class="botao" runat="server" type="submit" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                                </div>
                                <asp:Label ID="lblRetorno" runat="server"></asp:Label>
                                <asp:Label ID="lblSenha" runat="server"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                </fieldset>
            </div>
        </div>


        <script type="text/javascript">            
            $(document).ready(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        </script>


        <script>
            $(document).ready(function () {
                $('.cpf').mask('999.999.999-99');
            });
        </script>

        <script type="text/javascript">
            function erro() {
                swal({
                    title: "xiii algo deu errado!",
                    text: "Este usuário já está cadastrado!",
                    icon: "error",
                });
            }
        </script>
        <script type="text/javascript">
            function cadastro() {
                swal("Cadastro rápido feito!!", {
                    icon: "success",
                    buttons: {
                        // cancel: "Run away!",
                        catch: {
                            text: "voltar",
                            value: "depois"
                        },
                        voltar: {
                            text: "Continuar cadastro",
                            value: "agora",

                        }
                    },
                })
                    .then((value) => {
                        switch (value) {
                            case "agora":
                                swal("Vamos finalizar o cadastro!!", {
                                    button: false,
                                });
                                setTimeout(function () {
                                    window.location.href = '/Paginas/Cadastro/ConcluirCadastro.aspx';
                                }, 2300);
                                break;
                            case "depois":
                                swal("Sem problema outra hora você finaliza o cadastro", {
                                    button: false,
                                });
                                setTimeout(function () {
                                    window.location.href = '/Paginas/Index.aspx';
                                }, 2300);
                                break;
                            default:
                                //swal("Você receberá uma mensagem quando seu produto for aprovado!", {
                                //    button: false,
                                //});
                                //setTimeout(function () {
                                window.location.href = '/Paginas/Index.aspx';
                            //}, 2300);
                        }
                    });
            }
        </script>
        <%-- <script src="../../themes/js/common.js"></script>
        <script src="../../themes/js/jquery.flexslider-min.js"></script>--%>
    </section>
</asp:Content>

