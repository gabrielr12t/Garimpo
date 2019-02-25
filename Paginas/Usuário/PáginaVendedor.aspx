<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="PáginaVendedor.aspx.cs" Inherits="Paginas_Usuário_PáginaVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <style>
     
    </style>


    <section class="main-content">

        <style>
            .botao {
                color: #ffffff;
                background-color: #b04f91;
                font-size: 18px;
                border-radius: 1px;
                margin-top: -12px;
                margin-bottom: -12px;
            }
        </style>

        <br />
        <!-- VENDEDOR -->

        <asp:Literal ID="lblVendedor" runat="server"></asp:Literal>
        <%--<div class="row-fluid" id="secao">
            <div class="span3" id="first">
                <asp:Label runat="server" ID="lblUsuario"></asp:Label>
                <a href="/Paginas/Usuário/PáginaVendedor.aspx" class="fotoPerfilGrande" data-toggle="tooltip" data-placement="bottom" title="Clique na foto para acessar o perfil do vendedor">
                    <img class="fotoPerfilGrande" src="../../themes/images/FOTO PERFIL/jovem-nerd-doidão.jpg" /></a>
            </div>
            <div class="span3" id="second">
                <div class="fonte-estilo">
                    Brechó do <strong class="roxo">JOVEM NERD</strong><br />
                    Curitiba/Paraná
                </div>
            </div>
            <div class="span3" id="third">
                <span class="rep-ven">Reputação: Muito Boa</span>
            </div>
            <div class="span3" id="fourth">
               <span class="rep-ven">Total de Vendas: 230" </span>
            </div>
            <div class="span11">
                <hr />
            </div>
        </div>--%>
        <div class="row">
            <div class="span3 ">
                <div class="block">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">filtrar por categorias:</span></span></span>
                    </h4>
                    <asp:Button ID="Button1" CssClass="botao" runat="server" Text="nerd" />
                    <asp:Button ID="Button2" CssClass="botao" runat="server" Text="geek" />
                    <asp:Button ID="Button3" CssClass="botao" runat="server" Text="gamer" />
                    <asp:Button ID="Button4" CssClass="botao" runat="server" Text="rock" />
                    <asp:Button ID="Button5" CssClass="botao" runat="server" Text="camisas" />
                    <asp:Button ID="Button6" CssClass="botao" runat="server" Text="acessórios" />
                </div>
                <div class="block">
                    <h4 class="title">
                        <span class="text-center"><span class="text"><span class="line">filtrar por marcas:</span></span></span>
                    </h4>
                    <asp:Button ID="Button7" CssClass="botao" runat="server" Text="jovem nerd" />
                    <asp:Button ID="Button8" CssClass="botao" runat="server" Text="nerd universe" />
                    <asp:Button ID="Button9" CssClass="botao" runat="server" Text="mundo geek" />
                    <asp:Button ID="Button10" CssClass="botao" runat="server" Text="iRock" />
                </div>
                <div class="block">
                    <br />
                    <style>
                        .bbb {
                            width: 140px !important;
                        }
                    </style>
                    <asp:TextBox ID="txtBuscar" runat="server" class="form-control bbb" autocomplete="on" placeholder="Pesquisar"></asp:TextBox>
                </div>
            </div>

            <asp:Label ID="lblPagina" runat="server"></asp:Label>
            <div class="span9">
                <div class="control-group right">
                    <div class="controls">
                        <h4 class="title">
                            <span class="text-center">
                                <span class="text">
                                    <span class="line">Total produtos à venda:<asp:Label runat="server" ID="lblQuantidadeProdutosVenda"></asp:Label>
                                    </span>
                                </span>
                            </span>
                        </h4>
                    </div>
                </div>


                <ul class='thumbnails listing-products'>
                    <asp:Literal ID="ltlProdutos" runat="server"></asp:Literal>
                </ul>
              
                <hr />
               <%-- <div class="pagination   pagination-centered">
                    <ul>
                        <li><a href="#">Prev</a></li>
                        <li class="active"><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">Next</a></li>
                    </ul>
                </div>--%>
            </div>
        </div>
    </section>
</asp:Content>

