<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="AlterarCadastro.aspx.cs" Inherits="Paginas_Alterar_AlterarCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script src="../../themes/js/jquery.mask.min.js"></script>


    <style>
        .swal-overlay {
            background-color: rgba(75, 62, 110,0.45);
        }

        .margem {
            margin-left: 1%;
        }

        .quadradoTamanho {
            width: 30px;
            height: 20px;
            color: black;
            background-repeat: no-repeat;
            background-position: center center;
            background-size: cover;
            display: inline-block;
            border: groove 1px;
            text-align: center;
        }
    </style>
    <%---------------- Dados do usuário ----------------------%>
    <asp:Panel ID="pnlDados" DefaultButton="btnSalvarDados" runat="server">
        <div class="span8" style="border: 0.1px solid; border-color: #d4d4d4">
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Dados <strong>Pessoais</strong></span></span></span>
            </h4>
            <div class="span12">

                <div class="row">
                    <div class="col-lg-4">
                        CPF/CNPJ:<br />
                        <asp:TextBox ID="txtCpf" ValidationGroup="dados" CssClass="input-xlarge cpf" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        Email:<br />
                        <asp:TextBox ID="txtEmail" ValidationGroup="dados" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        Nome:<br />
                        <asp:TextBox ID="txtNome" ValidationGroup="dados" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        Data de Nascimento:<br />
                        <asp:TextBox ID="txtDataNascimento" ValidationGroup="dados" CssClass="input-xlarge data" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ErrorMessage="Insira sua data de nascimento" ControlToValidate="txtDataNascimento" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtDataNascimento" ErrorMessage="Data inválida" Display="Dynamic" ForeColor="Red" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2)\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-lg-4">
                        Telefone:<br />
                        <asp:TextBox ID="txtTelefone" ValidationGroup="dados" CssClass="validate input-xlarge telefone" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="telefone" ErrorMessage="Insira um telefone" ControlToValidate="txtTelefone" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="regular" ControlToValidate="txtTelefone" ErrorMessage="telefone inválido" Display="Dynamic" ForeColor="Red" ValidationExpression="(^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$)"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-lg-4 margem">
                        Sexo:<br />
                        <asp:RadioButtonList ID="rbtSexo" ValidationGroup="dados" runat="server" CssClass="radio">
                            <asp:ListItem Selected="True" Value="F">Feminino</asp:ListItem>
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-lg-4">
                        <a href="#" data-toggle="modal" data-target="#ModalSenha">Alterar minha senha</a>
                    </div>
                    <br />
                </div>
                <br />
                <asp:Button ID="btnSalvarDados" runat="server" Text="Salvar" ValidationGroup="dados" CssClass="i2Style i2Style:active" OnClick="btnSalvarDados_Click1" /><br />
                <asp:Label ID="lblRetorno" runat="server"></asp:Label>
                <br />
            </div>

        </div>
    </asp:Panel>
    <%--------------------------------------------------%>

    <%---------------- Modal endereço ------------------------%>
    <div class="span8 " style="border: 0.1px solid; border-color: #d4d4d4">
        <h4 class="title center">
            <span class="text-center"><span class="text"><span class="line">Endereços<strong></strong></span></span></span>
        </h4>
        <div class="col-lg-11 center">
            <a href="#" style="font-size: 35px" data-toggle="modal" data-target="#ModalInserir">
                <p style="font-size: 20px">Adicionar endereço</p>
                <i class="fa fa-plus-circle"></i></a>
            <br />
        </div>
        <%--label dinamica--%>
        <style>
            .iconeGrande {
                font-size: 25px;
            }
        </style>
        <div class="row">
            <div class="span10">
                <div class="span6">
                    <asp:Repeater ID="rptImagens" runat="server" OnItemCommand="rptImagens_ItemCommand">
                        <ItemTemplate>
                            <p>
                                <hr />
                                <asp:LinkButton ID="btnExcluir" ValidationGroup="Endereco" CommandName="excluir" OnClientClick="return teste(this, event);" CommandArgument='<%#Eval("end_codigo") %>' CssClass="pull-right iconeGrande" runat="server"><i class="fa fa-trash"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnAlterar" ValidationGroup="Endereco" CommandName="alterar" CommandArgument='<%#Eval("end_codigo") %>' CssClass="pull-right iconeGrande" Width="30px" runat="server"><i class="fa fa-pencil"></i></asp:LinkButton>
                                <strong>CEP:</strong><%#Eval("end_cep") %>
                                <br />
                                <strong>Estado:</strong><%#Eval("end_estado")%>
                                <br />
                                <strong>Cidade:</strong><%#Eval("end_cidade")%>
                                <br />
                                <strong>Bairro:</strong><%#Eval("end_bairro")%>
                                <br />
                                <strong>Endereço:</strong><%#Eval("end_endereco")%>
                                <br />
                                <strong>Referência:</strong><%#Eval("end_referencia")%>
                                <br />
                                <strong>Número:</strong><%#Eval("end_numero")%>

                                <hr />
                            </p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <%--Panel endereço--%>
    </div>
    <%----------------------------------------------------------------%>

    <%------------------------------------------%>
    
    <br />

    <%--Inicio da modal editar endereço--%>
    <div class="modal hide fade" id="myModal">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3>Alteração de endereço</h3>
        </div>
        <div class="modal-body ">
            <asp:Panel ID="pnlEditar" DefaultButton="btnEditar" runat="server">
                <div class="span5 center">
                    CEP: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-search "></i></span>
                            <asp:TextBox ID="txtCepEditar" runat="server" CssClass="input-xlarge cep" ClientIDMode="Static" placeholder="Digite seu CEP"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="editar" ID="RequiredFieldValidator3" ErrorMessage="Insira seu CEP" ControlToValidate="txtCepEditar" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Estado: <a class="obrigatorio">*</a>
                    <div class="controls ">
                        <div class="input-prepend">
                            <span class="add-on"><i class="fa fa-map" style="color: black"></i></span>
                            <asp:TextBox ID="txtEstadoEditar" runat="server" ClientIDMode="Static" CssClass="input-xlarge uf"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="editar" ID="RequiredFieldValidator4" ErrorMessage="Insira seu estado" ControlToValidate="txtEstadoEditar" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Cidade:  <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-home "></i></span>
                            <asp:TextBox ID="txtCidadeEditar" runat="server" ClientIDMode="Static" CssClass="input-xlarge cidade"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="editar" ID="RequiredFieldValidator5" ErrorMessage="Insira sua cidade" ControlToValidate="txtCidadeEditar" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Bairro:
               <div class="controls">
                   <div class="input-prepend">
                       <span class="add-on"><i class="fa fa-home" style="color: black"></i></span>
                       <asp:TextBox ID="txtBairroEditar" runat="server" ClientIDMode="Static" CssClass="input-xlarge bairro"></asp:TextBox>
                   </div>
                   <br />
                   <asp:RequiredFieldValidator ValidationGroup="editar" ID="RequiredFieldValidator6" ErrorMessage="Insira seu bairro" ControlToValidate="txtBairroEditar" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
               </div>
                    Número:<a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="fa fa-unlock " style="color: black"></i></span>
                            <asp:TextBox ID="txtNumeroEditar" CssClass="input-xlarge" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="editar" ID="RequiredFieldValidator7" ErrorMessage="Insira o número de sua residência" ControlToValidate="txtNumeroEditar" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Endereço: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-map-marker "></i></span>
                            <asp:TextBox ID="txtEnderecoEditar" runat="server" ClientIDMode="Static" CssClass="input-xlarge rua"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="editar" ID="RequiredFieldValidator8" ErrorMessage="Insira seu endereço" ControlToValidate="txtEnderecoEditar" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Referência:             
               <div class="controls">
                   <div class="input-prepend">
                       <span class="add-on"><i class="icon-list "></i></span>
                       <asp:TextBox ID="txtReferenciaEditar" runat="server" ClientIDMode="Static" CssClass="input-xlarge"></asp:TextBox>
                   </div>
               </div>
                    <asp:HiddenField ID="txtCodigoEditar" ClientIDMode="Static" runat="server"></asp:HiddenField>
                    <br />
                    <asp:HiddenField ID="txtCPFEditar" ClientIDMode="Static" runat="server"></asp:HiddenField>
                    <br />
                    <div class="modal-footer center">
                        <div class="controls">
                            <div class="input-prepend">
                                <asp:Button ID="btnEditar" ValidationGroup="editar" Text="Editar" CssClass="i2Style i2Style:active" runat="server" OnClick="btnEditar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

    </div>
    <%-----------------------------------------------%>


    <%------ modal inserir endereço------%>

    <div class="modal hide fade" id="ModalInserir">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3>Adicionar novo endereço</h3>
        </div>
        <div class="modal-body ">
            <asp:Panel ID="pnlCadastrarEndereco" DefaultButton="btnCadastrar" runat="server">
                <div class="span5 center">
                    CEP: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-search "></i></span>
                            <asp:TextBox ID="txtCep" runat="server" CssClass="input-xlarge cep" placeholder="Digite seu CEP"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="cadastrarEndereco" ID="RequiredFieldValidator1" ErrorMessage="Insira seu CEP" ControlToValidate="txtCep" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Estado: <a class="obrigatorio">*</a>
                    <div class="controls ">
                        <div class="input-prepend">
                            <span class="add-on"><i class="fa fa-map" style="color: black"></i></span>
                            <asp:TextBox ID="txtEstado" runat="server" CssClass="input-xlarge uf"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="cadastrarEndereco" ID="RequiredFieldValidator2" ErrorMessage="Insira seu estado" ControlToValidate="txtEstado" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Cidade:  <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-home "></i></span>
                            <asp:TextBox ID="txtCidade" runat="server" CssClass="input-xlarge cidade"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="cadastrarEndereco" ID="RequiredFieldValidator9" ErrorMessage="Insira sua cidade" ControlToValidate="txtCidade" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Bairro:
               <div class="controls">
                   <div class="input-prepend">
                       <span class="add-on"><i class="fa fa-home" style="color: black"></i></span>
                       <asp:TextBox ID="txtBairro" runat="server" CssClass="input-xlarge bairro"></asp:TextBox>
                   </div>
                   <br />
                   <asp:RequiredFieldValidator ValidationGroup="cadastrarEndereco" ID="RequiredFieldValidator10" ErrorMessage="Insira seu bairro" ControlToValidate="txtBairro" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
               </div>
                    Número:<a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="fa fa-unlock " style="color: black"></i></span>
                            <asp:TextBox ID="txtNumero" CssClass="input-xlarge" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="cadastrarEndereco" ID="RequiredFieldValidator11" ErrorMessage="Insira o número de sua residência" ControlToValidate="txtNumero" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Endereço: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-map-marker "></i></span>
                            <asp:TextBox ID="txtEndereco" runat="server" CssClass="input-xlarge rua"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="cadastrarEndereco" ID="RequiredFieldValidator12" ErrorMessage="Insira seu endereço" ControlToValidate="txtEndereco" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>
                    Referência:             
               <div class="controls">
                   <div class="input-prepend">
                       <span class="add-on"><i class="icon-list "></i></span>
                       <asp:TextBox ID="txtReferencia" runat="server" CssClass="input-xlarge"></asp:TextBox>
                   </div>
               </div>
                    <div class="modal-footer center">
                        <div class="controls">
                            <div class="input-prepend">
                                <asp:Button ValidationGroup="cadastrarEndereco" ID="btnCadastrar" Text="Cadastrar" CssClass="i2Style i2Style:active" runat="server" OnClick="btnCadastrar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <%-----------------------------------------------%>

    <%------------ Modal Alterar Senha ---------------%>
    <div class="modal hide fade" id="ModalSenha">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3>Alteração de senha</h3>
        </div>
        <div class="modal-body ">
            <asp:Panel ID="pnpEsqueceuSenha" DefaultButton="btnAlterarSenha" runat="server">
                <div class="span5 center">
                    Digite sua senha atual <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-lock "></i></span>
                            <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password" CssClass="input-xlarge" placeholder="Senha atual"></asp:TextBox>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ValidationGroup="Senha" ID="RequiredFieldValidator15" ErrorMessage="Campo obrigatório" ControlToValidate="txtSenhaAtual" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>

                    Digite sua nova senha: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-lock "></i></span>
                            <asp:TextBox ID="txtNovaSenha" runat="server" TextMode="Password" CssClass="input-xlarge" placeholder="Nova senha"></asp:TextBox>
                        </div>
                        <br />

                        <asp:RegularExpressionValidator runat="server" Display="dynamic"
                            ControlToValidate="txtNovaSenha"
                            ForeColor="Red"
                            ErrorMessage="A senha deve conter um caracter especial."
                            ValidationExpression="^.*(?=.*[@#$%^&+=._!]).*$" />
                        <asp:RegularExpressionValidator runat="server" Display="dynamic"
                            ControlToValidate="txtNovaSenha"
                            ForeColor="Red"
                            ErrorMessage="A senha deve conter uma letra maiúscula."
                            ValidationExpression="^.*(?=.*[A-Z]).*$" />
                        <asp:RegularExpressionValidator runat="server" Display="dynamic"
                            ControlToValidate="txtNovaSenha"
                            ForeColor="Red"
                            ErrorMessage="A senha deve conter uma letra minúscula."
                            ValidationExpression="^.*(?=.*[a-z]).*$" />
                        <asp:RegularExpressionValidator runat="server" Display="dynamic"
                            ForeColor="Red"
                            ControlToValidate="txtNovaSenha"
                            ErrorMessage="A senha precisa ter de 8 a 18 caracteres"
                            ValidationExpression="[^\s]{8,18}" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="Senha" ErrorMessage="Insira a senha" ControlToValidate="txtNovaSenha" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>

                    Digite a Senha novamente <a class="obrigatorio">*</a>
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-lock"></i></span>
                            <asp:TextBox ID="txtConfirmaSenhanNova" runat="server" CssClass="input-xlarge" placeholder="Digite novamente" type="password" MaxLength="18"></asp:TextBox>
                        </div>

                        <br />
                        <asp:CompareValidator ID="cvConfirmaSenha" Type="String" ErrorMessage="Senhas Diferentes" ControlToValidate="txtConfirmaSenhanNova" ControlToCompare="txtNovaSenha" Display="Dynamic" ForeColor="red" runat="server"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="Senha" ErrorMessage="Repita a senha" ControlToValidate="txtConfirmaSenhanNova" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    </div>


                    <div class="modal-footer center">
                        <div class="controls">
                            <div class="input-prepend">
                                <asp:Button ValidationGroup="Senha" ID="btnAlterarSenha" Text="Alterar" CssClass="i2Style i2Style:active" OnClick="btnAlterarSenha_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <%---------------------------------------------------%>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    <%------------------------------------------%>

        //$(".editarCad").click(function () {
        //    $("#myModal").modal("show");
        //    var dados = $(this).attr("rel").split("|");
        //    $("#txtCodigoEditar").val(dados[0]);
        //    $("#txtCPFEditar").val(dados[1]);
        //    $("#txtEstadoEditar").val(dados[2]);
        //    $("#txtCidadeEditar").val(dados[3]);
        //    $("#txtBairroEditar").val(dados[4]);
        //    $("#txtEnderecoEditar").val(dados[5]);
        //    $("#txtReferenciaEditar").val(dados[6]);
        //    $("#txtNumeroEditar").val(dados[7]);
        //    $("#txtCepEditar").val(dados[8]);
        //});

    <%---------------------------------------------------------------%>

        function atualizado() {
            swal({
                title: "Uhuull!",
                text: "Seu cadastro foi atualizado!",
                icon: "success",
            });
        }
        function NaoPodeExcluir() {
            swal({
                title: "Opsss!",
                text: "Você possui produto a venda e não pode ficar sem endereço cadastrada. Cadatre outro para excluir este!",
                icon: "error",
            });
        }
        function existe() {
            swal({
                title: "Opa!",
                text: "Este telefone já está cadastrado!!",
                icon: "error",
            });
        }
        function erro() {
            swal({
                title: "Nããão!",
                text: "Tenho algo em branco?!",
                icon: "error"
            });
        }

        function erroSenha() {
            swal({
                title: "Nããão!",
                text: "Sua senha está incorreta",
                icon: "error"
            });
        }
        $(document).ready(function () {
            $('.data').mask('00/00/0000');
            $('.cep').mask('99999-999');
            $('.telefone').mask('(99) 9999-9999');
            $('.cpf').mask('999.999.999-99');
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

                            }//end if.
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

    </script>
    <script src="../../themes/js/jsExluirEndereco.js"></script>



    <script type="text/javascript">
        function sucesso() {
            swal("Endereço excluído!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Alterar/AlterarCadastro.aspx';
            }, 1500);

        }
        function AlterarSenha() {
            swal("Senha Alterada!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Alterar/AlterarCadastro.aspx';
            }, 1500);

        }
        function sucessoalteracao() {
            swal("Endereço alterado!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Alterar/AlterarCadastro.aspx';
            }, 1000);

        }

        function enderecoCadastrado() {
            swal("Endereço Cadastrado!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Alterar/AlterarCadastro.aspx';
            }, 1000);

        }
    </script>

    <script type="text/javascript">              
        //----------------
        function teste(ctl, event) {
            var defaultAction = $(ctl).prop("href");
            event.preventDefault();
            swal({
                title: "Excluir endereço!",
                text: "Você tem certeza que deseja excluir este endereço?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        window.location.href = defaultAction;
                        return true;
                    } else {
                        return false;
                    }
                });
        }
    </script>

</asp:Content>

