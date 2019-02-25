<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="ConcluirCadastro.aspx.cs" Inherits="Paginas_Cadastro_ConcluirCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../themes/js/jquery-1.7.2.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.js"></script>


    <script src="../../themes/js/jquery.mask.min.js"></script>


    <script>
        $(document).ready(function () {
            $('.telefone').mask('(99) 9999-9999');
            $('.data').mask('99/99/9999');
            $('.cep').mask('99999-999');
        });
    </script>
    <%--DADOS--%>
    <asp:Panel ID="pnlDados" runat="server">
        <section class="main-content">
            <div class="row">
                <div class="span5">
                    <h4 class="title"><span class="text"><strong>Dados Pessoais</strong></span></h4>
                    <div class="control-group ">
                        <div class="controls">
                            CPF:
                           <strong>
                               <asp:Label ID="lblCpf" runat="server"></asp:Label></strong>
                        </div>
                    </div>
                    <div class="control-group ">
                        <div class="controls">
                            Nome:
                           <strong>
                               <asp:Label ID="lblNome" runat="server"></asp:Label></strong>
                        </div>
                    </div>
                    <div class="control-group ">
                        <div class="controls">
                            E-mail:
                           <strong>
                               <asp:Label ID="lblEmail" runat="server"></asp:Label></strong>
                        </div>
                    </div>
                    <div class="control-group radio">
                        <div class="controls">
                            Sexo: <a class="obrigatorio">*</a><br />
                            <asp:RadioButtonList ID="rblSexo" runat="server" ValidationGroup="concluir" RepeatDirection="Vertical" CssClass="radio inline">
                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="concluir" ErrorMessage="Selecione um sexo" ControlToValidate="rblSexo" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="span7">
                    <h4 class="title"><span class="text"><strong></strong></span></h4>
                    Telefone: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-book "></i></span>
                            <asp:TextBox ID="txtTelefone" runat="server" ValidationGroup="concluir" CssClass="input-xlarge telefone"></asp:TextBox>
                        </div>

                        <br />
                        <asp:RequiredFieldValidator ID="telefone" ValidationGroup="concluir" ErrorMessage="Insira um telefone" ControlToValidate="txtTelefone" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="regular" ValidationGroup="concluir" ControlToValidate="txtTelefone" ErrorMessage="telefone inválido" Display="Dynamic" ForeColor="Red" ValidationExpression="(^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$)"></asp:RegularExpressionValidator>
                    </div>
                    Data de Nascimento: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-calendar "></i></span>
                            <asp:TextBox ID="txtDataNascimento" runat="server" ValidationGroup="concluir" CssClass="input-xlarge data"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="concluir" ErrorMessage="Insira sua data de nascimento" ControlToValidate="txtDataNascimento" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ValidationGroup="concluir" ControlToValidate="txtDataNascimento" ErrorMessage="Data inválida" Display="Dynamic" ForeColor="Red" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2)\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator>
                    </div>
                     <div class="controls">
                        <div class="input-prepend">
                            <asp:Button ID="btnDados" OnClick="btnDados_Click" Text="Finalizar" Visible="false"  CssClass="i2Style i2Style:active" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>


    <%--ENDEREÇO--%>

    <section class="main-content">
        <asp:Panel runat="server" ID="pnlEndereco">
            <div class="row">
                <div class="span11">
                    <h4 class="title"><span class="text"><strong>Endereço</strong></span></h4>
                </div>

                <div class="span5">
                    CEP: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-search "></i></span>
                            <asp:TextBox ID="txtCep" runat="server" CssClass="input-xlarge cep" ValidationGroup="concluir" placeholder="Digite seu CEP"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="concluir" ErrorMessage="Insira seu CEP" ControlToValidate="txtCep" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Estado: <a class="obrigatorio">*</a>
                    <div class="controls ">
                        <div class="input-prepend">
                            <span class="add-on"><i class="fa fa-map" style="color: black"></i></span>
                            <asp:TextBox ID="txtEstado" runat="server" ValidationGroup="concluir" CssClass="input-xlarge uf"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="concluir" ErrorMessage="Insira seu estado" ControlToValidate="txtEstado" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Cidade:  <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-home "></i></span>
                            <asp:TextBox ID="txtCidade" runat="server" ValidationGroup="concluir" CssClass="input-xlarge cidade"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="concluir" ErrorMessage="Insira sua cidade" ControlToValidate="txtCidade" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Bairro:
               <div class="controls">
                   <div class="input-prepend">
                       <span class="add-on"><i class="fa fa-home" style="color: black"></i></span>
                       <asp:TextBox ID="txtBairro" runat="server" ValidationGroup="concluir" CssClass="input-xlarge bairro"></asp:TextBox>
                   </div>
                   <br />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="concluir" ErrorMessage="Insira seu bairro" ControlToValidate="txtBairro" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
               </div>
                    Número:<a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="fa fa-unlock " style="color: black"></i></span>
                            <asp:TextBox ID="txtNumero" CssClass="input-xlarge" ValidationGroup="concluir" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="concluir" ErrorMessage="Insira o número de sua residência" ControlToValidate="txtNumero" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="span7">
                    Endereço: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-map-marker "></i></span>
                            <asp:TextBox ID="txtEndereco" runat="server" ValidationGroup="concluir" CssClass="input-xlarge rua"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="concluir" ErrorMessage="Insira seu endereço" ControlToValidate="txtEndereco" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Referência:             
               <div class="controls">
                   <div class="input-prepend">
                       <span class="add-on"><i class="icon-list "></i></span>
                       <asp:TextBox ID="txtReferencia" runat="server" ValidationGroup="concluir" CssClass="input-xlarge"></asp:TextBox>
                   </div>
               </div>
                    Insira uma foto para seu perfil:     
                    <div class="controls">
                        <div class="input-prepend">
                            <asp:Label ID="lblFoto" runat="server"><img src="../../themes/images/FOTOPERFIL/jovem-nerd-doidão.jpg" class="img-circle" style="width: 50px; height: 50px" /></asp:Label>
                            <asp:FileUpload ID="flpArquivo" AllowMultiple="true" runat="server" /><br />
                            <asp:Label ID="lblRetornoFoto" runat="server"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="controls">
                        <div class="input-prepend">
                            <asp:Button ID="btnFinalizar" ValidationGroup="concluir" CssClass="i2Style i2Style:active" runat="server" OnClick="btnFinalizar_Click" Text="Finalizar" />
                            <asp:Button ID="btnConcluir" ValidationGroup="concluir" CssClass="i2Style i2Style:active" Visible="false" runat="server" OnClick="btnConcluir_Click" Text="Finalizar" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

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


            //------------------------ BUSCA CEP ----------------------------
            $(document).ready(function () {

                $('.cep').mask('99999-999');
            });
            $(document).ready(function () {
                function limpa_formulário_cep() {
                    // Limpa valores do formulário de cep.
                    $('.rua').val("");
                    $('.bairro').val("");
                    $('.cidade').val("");
                    $('.uf').val("");
                }
                //Quando o campo cep perde o foco.
                $('.cep').blur(function () {
                    //Nova variável "cep" somente com dígitos.
                    var cep = $(this).val().replace(/\D/g, '');
                    //Verifica se campo cep possui valor informado.
                    if (cep != "") {
                        //Expressão regular para validar o CEP.
                        var validacep = /^[0-9]{8}$/;
                        //Valida o formato do CEP.
                        if (validacep.test(cep)) {
                            //Preenche os campos com "..." enquanto consulta webservice.
                            $('.rua').val("...");
                            $('.bairro').val("...");
                            $('.cidade').val("...");
                            $('.uf').val("...");
                            //Consulta o webservice viacep.com.br/
                            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                                if (!("erro" in dados)) {
                                    //Atualiza os campos com os valores da consulta.
                                    $('.rua').val(dados.logradouro);
                                    $('.bairro').val(dados.bairro);
                                    $('.cidade').val(dados.localidade);
                                    $('.uf').val(dados.uf);

                                } //end if.
                                else {
                                    //CEP pesquisado não foi encontrado.
                                    limpa_formulário_cep();
                                    swal('Opss', 'CEP não encontrado!!', 'error');
                                }
                            });
                        } //end if.
                        else {
                            //cep é inválido.
                            limpa_formulário_cep();
                            swal('Errado', 'Formato inválido!!', 'warning');
                        }
                    } //end if.
                    else {
                        //cep sem valor, limpa formulário.
                        limpa_formulário_cep();
                    }
                });
            });
            function finalizado() {
                swal("Cadastro completo finalizado!!", {
                    button: false,
                });
                setTimeout(function () {
                    window.location.href = '/Paginas/Index.aspx';
                }, 2000);
            }
        </script>
    </section>
    <%---------------------%>
</asp:Content>

