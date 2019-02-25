<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="ProdutosDesativados.aspx.cs" Inherits="Paginas_Usuário_ProdutosDesativados" %>

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
        <h4 class="title">
            <span class="text-center"><span class="text"><span class="line">Produtos <strong>Desativados:</strong></span></span></span>
        </h4>
        <table class="table table-striped table-hover">
            <thead>
            </thead>

            <tbody>

                <asp:Label ID="lblTable" runat="server"></asp:Label>
                <%-- <tr>                   
                    <td>
                       Imagem
                    </td>
                    <td><strong>Nome do Produto</strong><br />
                       Status: 
                    </td>
                    <td>
                        <a href="#" data-toggle="tooltip" data-placement="bottom" title="Ativar este produto"><i class="icon-arrow-up"></i></a>
                    </td>
                </tr>--%>
            </tbody>
        </table>
        <hr />
         
    </div>   
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

    </script>
    <script src="../../themes/js/jsAtivarProdutos.js"></script>
</asp:Content>

