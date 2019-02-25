<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="ProdutosVenda.aspx.cs" Inherits="Paginas_Usuário_ProdutosVenda" %>

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
        <table class="table table-striped  table-hover">
            
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Produtos à <strong>venda:</strong></span></span></span>
            </h4>
         <%--   <a href="#" class="pull-left">Desativar itens selecionados <i class="icon-minus pull-left"></i></a>--%>

            <!-- LISTA PRODUTOS A VENDA -->
            <tbody>

                <%------------------------------------%>

                <%-- <tr>
                    <td>
                        <p>
                           
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:Label ID="Label2" runat="server" Text="#001"></asp:Label>

                        </p>
                    </td>
                    <td><a href="#">
                     
                        <img alt="" src="../../themes/images/ladies/9.jpg" class="img-carrinho" /></a>
                    </td>
               
                    <td>
                        <strong>
                            <asp:Label ID="lblNomeProduto" runat="server" Text="Label"></asp:Label>
                        </strong>
                        <br />
                        <asp:Label ID="lblPrecoProduto" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                      
                        <asp:Button ID="btnEditarProduto" runat="server" Text="Editar" OnClick="btnEditarProduto_Click" />
                        <asp:Button ID="btnDesativarProduto" runat="server" Text="Desativar" OnClick="btnDesativarProduto_Click" />
                    </td>
                </tr>--%>
                <%------------------------------------%>
               
               <%-- <tr>
                    <td>
                        <p>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                            #001
                        </p>
                    </td>
                    <td>IMAGEM
                    </td>
                    <td><strong>Nome do Produto</strong><br />
                        Data Compra:00/00/0000                        
                        <br />
                        Valor da compra:R$00,00                                               
                    </td>
                </tr>--%>                

                <asp:Label ID="lblTable" runat="server"></asp:Label>

            </tbody>
        </table>
        <hr />
        <div class="pagination pagination-centered">
            <ul>
                <asp:Literal ID="ltlPagination" runat="server"></asp:Literal>
                <%--<li><a href="#">Ant</a></li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">Próx</a></li>--%>
            </ul>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

    </script>
    <script src="../../themes/js/jsDesativarProdutos.js"></script>
</asp:Content>

