<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="GradeProdutos.aspx.cs" Inherits="Paginas_Produtos_GradeProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".preco").maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
        });
    </script>


    <section class="main-content">

        <style>
            .quadradoCores {
                margin-bottom: 15px !important;
                display: inline-block;
                width: 35px;
                height: 35px;
                border-radius: 50%;
                background-repeat: no-repeat;
                background-position: center center;
                background-size: cover;
                display: inline-block;
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

            .quadradoCores:hover {
                opacity: 0.8;
            }
        </style>

        <br />

        <div class="row">
            <div class="span3 ">
                <div class="block">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">Preço <strong>:</strong></span></span></span>
                    </h4>
                    De:
                    <asp:TextBox ID="txtPrecoInicial" ValidationGroup="Ppreco" runat="server" CssClass="input-medium preco" placeholder="R$"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="cvNome"  ControlToValidate="txtPrecoInicial" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    <br />
                    
                    Até:
                    <asp:TextBox ID="txtPrecoFinal" ValidationGroup="Ppreco" runat="server" CssClass="input-medium preco" placeholder="R$"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="txtPrecoFinal" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnFiltar" runat="server" Text="Filtrar" ValidationGroup="Ppreco" OnClick="btnFiltar_Click" CssClass="i2Style i2Style:active" />
                </div>
                <div class="block ">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">Tamanho <strong>:</strong></span></span></span>
                    </h4>
                    <a href="#" class="quadradoTamanho">35</a>
                    <a href="#" class="quadradoTamanho">36</a>
                    <a href="#" class="quadradoTamanho">37</a>
                    <a href="#" class="quadradoTamanho">38</a>
                    <a href="#" class="quadradoTamanho">39</a>
                    <a href="#" class="quadradoTamanho">40</a>
                    <a href="#" class="quadradoTamanho">41</a>
                    <%-- <asp:DropDownList ID="ddlTamanho" runat="server" CssClass="input-mini">
                        <asp:ListItem Selected="True">37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                    </asp:DropDownList>--%>
                </div>
                <div class="block">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">Marca <strong>:</strong></span></span></span>
                    </h4>
                  <asp:DropDownList ID="ddlMarca" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown textbox span2" runat="server"></asp:DropDownList>
                </div>
                <div class="block">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">Cor <strong>:</strong></span></span></span>
                    </h4>
                    <a href="#" class="quadradoCores" style="background-color: red"></a>
                    <a href="#" class="quadradoCores" style="background-color: #fee8e8"></a>
                    <a href="#" class="quadradoCores" style="background-color: #b3d831"></a>
                    <a href="#" class="quadradoCores" style="background-color: black"></a>
                    <a href="#" class="quadradoCores" style="background-color: #9b5bb1"></a>
                    <a href="#" class="quadradoCores" style="background-color: #4354b9"></a>
                    <a href="#" class="quadradoCores" style="background-color: #f7d636"></a>
                    <a href="#" class="quadradoCores" style="background-color: #c78b20"></a>
                    <a href="#" class="quadradoCores" style="background-color: #a33ba1"></a>
                    <a href="#" class="quadradoCores" style="background-color: pink"></a>
                    <a href="#" class="quadradoCores" style="background-color: #48b4cc"></a>
                    <a href="#" class="quadradoCores" style="background-color: #4fc71f"></a>
                </div>
                <div class="block">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">Frete <strong>:</strong></span></span></span>
                    </h4>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    Grátis<br />
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                    Por peso<br />
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                    Em mãos
                </div>

            </div>

            <div class="span9">
                <div class="control-group right">
                    <div class="controls">
                        Ordenar por:
                <asp:DropDownList ID="ddlOrdnarPor" runat="server" CssClass="input-medium">
                    <asp:ListItem>Menor Preço</asp:ListItem>
                    <asp:ListItem>Marcas</asp:ListItem>
                </asp:DropDownList>
                    </div>
                </div>
                <ul class="thumbnails listing-products">
                    <!-- camisa nerd -->

                    <asp:Literal ID="ltlRoupas" runat="server"></asp:Literal>
                    <%-- <li class="span3">
                        <div class="product-box">

                            <a href="/Paginas/Produtos/Produto.aspx">
                                <img src="../../themes/images/cloth grade/01.jpg" />
                            </a>

                            <a href="/Paginas/Produtos/Produto.aspx">
                                <h4>blusa inverno</h4>
                            </a>

                            <h6>tamanho pp</h6>

                            <div class="span1 center">
                                <p class="price">R$85.00</p>
                            </div>

                            <a href="/Paginas/Login.aspx">
                                <img class="favorito-icone" src="../../themes/icones/heart_23801.png" />
                            </a>

                        </div>
                    </li>                          --%>
                </ul>
                <hr />
                <div class="pagination pagination-medium pagination-centered">
                    <ul>
                        <li><a href="#">Ant</a></li>
                        <li class="active"><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">Próx</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <script src="../favoritarGrade.js"></script>
        <%--<script src="../../themes/js/common.js"></script>
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

