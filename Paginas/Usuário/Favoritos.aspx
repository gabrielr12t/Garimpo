<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="Favoritos.aspx.cs" Inherits="Paginas_Usuário_Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .img-carrinho {
            height: 150px;
            width: 150px;
        }

            .img-carrinho:hover {
                opacity: 0.8;
            }
    </style>
    <div class="row center span8">
        <table class="table table-striped">
            <thead>
            </thead>
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Favoritos <strong>:</strong></span></span></span>
            </h4>
            <tbody>
             <asp:Literal ID="ltlProdutos" runat="server"></asp:Literal>
               <%-- <tr>
                    <td>
                        <p>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </p>
                    </td>
                    <td><a href="/Paginas/Produtos/Produtos.aspx=?<%#Eval("pro_codigo") %>">
                        <img alt="" src="../../themes/images/ladies/9.jpg" class="img-carrinho" /></a></td>
                    <td><strong>Nome do Produto</strong><br />
                       <span>R$00,00"></span>
                    </td>
                    <td>
                        <a href="#" data-toggle="tooltip" data-placement="bottom" title="Remover do favoritos"><i class="icon-remove"></i></a>
                    </td>
                </tr>--%>
            </tbody>
        </table>
        <hr />
        <div class="pagination pagination pagination-centered">
            <ul>
                <asp:Literal ID="ltlPag" runat="server"></asp:Literal>
                <%--<li><a href="#">Ant</a></li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">Próx</a></li>--%>
            </ul>
        </div>
    </div>
    <script src="../../themes/js/jsExcluirFavorito.js"></script>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

    </script>
</asp:Content>


