﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="HistoricoCompra.aspx.cs" Inherits="Paginas_Usuário_HistoricoCompra" %>

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
        <table class="table table-striped">
            <thead>
            </thead>
            <h4 class="title">
                    <span class="text-center"><span class="text"><span class="line">Histórico <strong>Compras:</strong></span></span></span>
                </h4>
                
            <tbody>
                <asp:Literal ID="ltlCompras" runat="server" ></asp:Literal>
                  <%--<tr>
                    <td>
                        <p>
                            <asp:Label ID="Label2" runat="server" Text="#001"></asp:Label>
                        </p>
                    </td>
                    <td><a href="#">
                        <img alt="" src="../../themes/images/ladies/9.jpg" class="img-carrinho" /></a></td>
                    <td><strong>Nome do Produto</strong><br />
                        Data Compra:
                        <asp:Label ID="Label1" runat="server" Text="00/00/0000"></asp:Label>
                        <br />
                        Valor da compra:
                        <asp:Label ID="lblValor" runat="server" Text="R$00,00"></asp:Label>
                    </td>
                </tr>       --%>        
              
            </tbody>
        </table>
        <hr />
       
     <%--   <div class="pagination pagination-centered">
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
     
     <script type="text/javascript">            
        $(document).ready(function () {
            $('[data-toogle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>


