<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="ProdutosPendentes.aspx.cs" Inherits="Paginas_Usuário_ProdutosPendentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     
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
                <span class="text-center"><span class="text"><span class="line"> Produtos <strong>Pendentes:</strong></span></span></span>
            </h4>
       
        <table class="table table-striped table-hover">
            <thead>
            </thead>
         
            <tbody>
                
                <asp:Label ID="lblTable" runat="server"></asp:Label>
             

            </tbody>
        </table>
        <hr />
        <%--<div class="pagination pagination-small pagination-centered">
            <ul>
                <li><a href="#">Ant</a></li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">Próx</a></li>
            </ul>
        </div>--%>
    </div>
  
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

    </script>
   
</asp:Content>


