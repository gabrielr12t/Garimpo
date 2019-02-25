<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="GeracaoPedido.aspx.cs" Inherits="Paginas_Pedidos_GeracaoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .margem {
            margin-left: 5%;
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
    <br />
    <%--------------------------------------%>
    <%-- <div class="span11 espaco-span">       
        <div class="span10" style="border: 0.1px solid; border-color: #d4d4d4">
            <h4 class="title">
                <span class="text-center reveja-espacos"><span class="text"><span class="line">Revise os<strong> dados</strong></span></span></span>
            </h4>
            <div class="col-lg-11">
                <strong>Nome: </strong>
                <br />
                <strong>E-mail: </strong>
                <br />
                <strong>Telefone: </strong>
                <br />
                <br />
            </div>
        </div>    
        <div class="span10" style="border: 0.1px solid; border-color: #d4d4d4">
            <h4 class="title">
                <span class="text-center reveja-espacos"><span class="text"><span class="line">Escolha seu endereço<strong> de entrega</strong></span></span></span>
            </h4>
            <div class="col-lg-11 ">
                <strong>CEP:</strong>CEP                        
            </div>
            <div class="col-lg-4 ">
                <strong>Endereço: </strong>
                Endereço                        
            </div>
            <div class="col-lg-3 ">
                <strong>Número:</strong>Número                        
            </div>
            <div class="col-lg-3 ">
                <strong>Cidade: </strong>
                Cidade                        
            </div>
            <div class="col-lg-4 ">
                <strong>Bairro: </strong>
                Bairro                        
            </div>
            <div class="col-lg-3">
                <strong>Estado:</strong>Estado                        
            </div>
            <div class="col-lg-12 ">
                <strong>Referência: </strong>
                Referência <br />                                                                   
            </div>
            <div class="span8 offset3">
                <a href="#" style="text-decoration:underline">Alterar endereço de entrega</a>
                <br /><br />
            </div>            
            <br />
        </div>
    </div>--%>

    <div class="span11 espaco-span">
        <div class="span10" style="border: 0.1px solid; border-color: #d4d4d4">
            <h4 class="title">
                <span class="text-center reveja-espacos"><span class="text"><span class="line">Revise os<strong> dados</strong></span></span></span>
            </h4>
            <div class="col-lg-11">
                <asp:Literal ID="ltlCliente" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="span10" style="border: 0.1px solid; border-color: #d4d4d4;">
            <h4 class="title">
                <span class="text-center reveja-espacos"><span class="text"><span class="line">Escolha seu endereço<strong> de entrega</strong></span></span></span>
            </h4>
            <div class="row">
                <div class="span4">
                    <asp:RadioButtonList ID="rbtEnd" RepeatDirection="Horizontal" CssClass="margem" runat="server" />
                </div>
            </div>
            <br />
        </div>
    </div>
    <asp:Literal ID="ltlInformacoes" runat="server"></asp:Literal>
    <%--    <asp:Label ID="lblEnd" runat="server"></asp:Label>--%>


    <div class="span10 ">
        <!-- FORMA ENVIO-->
        <div class="span4 offset1 center">
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Escolha uma <strong>forma de envio</strong></span></span></span><br />
                <br />
                <asp:DropDownList ID="ddlFormaEnvio" value="0" runat="server" CssClass="input-medium"></asp:DropDownList>
            </h4>
        </div>

        <!-- FORMA PAGAMENTO-->
        <div class="span4  center">
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Escolha uma <strong>Forma de pagamento</strong></span></span></span><br />
                <br />
                <asp:DropDownList ID="ddlFormaPagamento" value="0" runat="server" CssClass="input-medium"></asp:DropDownList>
            </h4>
        </div>
    </div>
    <style>
      
    </style>
    <!-- CONCORDO TERMOS USO -->
    <div class="span9 offset1 center">
        <div class="controls">

            <asp:CheckBox ID="ckbAceitar" runat="server" /><asp:Label ID="lblAceitar" runat="server" Text=""> Concordo com os <a href="#" style="text-decoration:underline">termos de uso gerais</a> </asp:Label><br />
            <br />
            <!-- BOTÃO CONFIRMAR PEDIDO -->
            <asp:Button ID="btnConfirmar" class="i2Style i2Style:active center" type="submit" runat="server" Text="Confirmar pedido" OnClick="btnConfirmar_Click" />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </div>


    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

        function NaoLogado() {
            swal("É necessário estar logado para continuar", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Login.aspx';
            }, 2000);
        }

        function CarrinhoVazio() {
            swal("Seu carrinho está vazio!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Carrinho.aspx';
            }, 2000);
        }

        function concluir() {
            swal("Precisa terminar o cadastro para finalizar a compra!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Cadastro/ConcluirCadastro.aspx';
            }, 2000);
        }
        function semEndereco() {
            swal("Para comprar é obrigatório ter completado o dadastro e possuir um endereço!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Cadastro/ConcluirCadastro.aspx';
            }, 2000);
        }
        function cadastroImcompleto() {
            swal("Para comprar é seu cadastro precisa estar completo!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Cadastro/ConcluirCadastro.aspx';
            }, 2000);
        }

        cadastroImcompleto
    </script>

</asp:Content>

