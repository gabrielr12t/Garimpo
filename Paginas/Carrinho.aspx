<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="Carrinho.aspx.cs" Inherits="Paginas_Carrinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css" />
    <link href="CarrinhoJS/estiloCarrinho.css" rel="stylesheet" />


    <section class="header_text sub">
        <h4><span>Carrinho de compras</span></h4>
    </section>
    <section class="main-content">

        <div class="shopping-cart">

            <div class="column-labels">
                <label class="product-image">Image</label>
                <label class="product-details">Produto</label>
                <label class="product-price">Preço</label>
                <label class="product-quantity">Quantidade</label>
                <label class="product-removal">Remover</label>
                <label class="product-line-price">Total</label>
            </div>

            <asp:Literal ID="ltlCarrinho" runat="server"></asp:Literal>


            <asp:Literal ID="ltlTotal" runat="server"></asp:Literal>

            <%-- <button class="checkout">Checkout</button>--%>

            <asp:Button ID="Button1" runat="server" Text="Continuar comprando" CssClass="i2Style i2Style:active pull-left" PostBackUrl="~/Paginas/Index.aspx" />
            <asp:Button ID="btnFinalizar2" Visible="false" runat="server" Text="Finalizar" CssClass="i2Style i2Style:active pull-right" OnClick="btnFinalizar_Click" />
            <div class="span3 offset8">
                <br /><a href="Pedidos/GeracaoPedido.aspx" id="btnFinalizar" class="botaoPadrao ">Finalizar</a>
            </div>
        </div>


        <script src="../themes/js/jquery-1.7.2.min.js"></script>
        <script src="CarrinhoJS/jquery.cookie.js"></script>
        <script src="CarrinhoJS/carrinho.js"></script>

    </section>
    <script src="themes/js/common.js"></script>
    <script>
        $(document).ready(function () {
            $('#checkout').click(function (e) {
                document.location.href = "checkout.html";
            })
        });
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>

</asp:Content>

