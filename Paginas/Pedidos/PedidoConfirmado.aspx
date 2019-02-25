<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="PedidoConfirmado.aspx.cs" Inherits="Paginas_Pedidos_PedidoConfirmado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .margem {
            margin-left: 5%;
        }

        .centralizar {
            margin-left: 43%;
        }

        .centralizar-2 {
            margin-left: 20%;
        }

        .centralizar-3{
            margin-left: 20px;
        }

        .centralizar-4{
            margin-left: 9%;
        }

        .cor-texto{
            color: #b04f91;
        }

        .cor-texto2{
            color: #9159c0;
        }

        .botao-ajuste{
            margin-left: 550px;
            padding-top: 12px;
            padding-bottom: 12px;
            font-size: 18px;

        }

    </style>
    <br />

    <div class="span8">
        <h3 class="title centralizar">
            <span class="text-center cor-texto2"><strong><u>Pedido Confirmado no Sistema!</u></strong></span>
        </h3>
        <br />

    </div>

    <div class="centralizar-4"> 
        <div class="span9" style="border: 0.9px solid; border-color: #9da0d7">
            <br />
            <strong><h3 class="centralizar-3 cor-texto" >Etapa de segurança Garimpo:</h3></strong>
            <p>
                <h3 class="lead margem">
                    -O vendedor tem um prazo de 48Hrs para confirmar ter o produto!<br />
                    -Seu pagamento nunca será liberado antes do recebimento do produto!<br />
                    -Pedimos que aguarde, você será notificado pelo e-mail cadastrado!
                    <br />
                    <br />
               
                </h3>
            </p>
        </div>

        <div class="span9" style="border: 0.9px solid; border-color: #9da0d7">
            <br />
            <p class="lead margem centralizar-2">
            -Recomendamos que pague o boleto após confirmação do vendedor!<br />
            -Enviamos o boleto para o e-mail: <strong><asp:Literal ID="ltlEmail" runat="server"></asp:Literal></strong></p>
            <br />


            <!-- BOTÃO GERAR BOLETO-->
            <asp:Button ID="btnBoleto" runat="server" Text="Ver boleto" CssClass="i2Style i2Style:active botao-ajuste" PostBackUrl="/Paginas/Index.aspx" /><br />
            <br />
        </div>
    </div>

    



</asp:Content>

