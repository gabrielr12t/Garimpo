<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPerfil.master" AutoEventWireup="true" CodeFile="HistoricoVenda.aspx.cs" Inherits="Paginas_Usuário_HistoricoVenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script> 
        $(document).ready(function () {
            $("#flip").click(function () {
                $("#panel").slideToggle("slow");
            });
        });
    </script>

    <style>
        #panel, #flip {
            padding: 5px;
            /*text-align: center;*/
            background-color: transparent;
            border: solid 1px #c3c3c3;
        }

        #panel {
            padding: 50px;
            display: none;
        }
    </style>
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
                <span class="text-center"><span class="text"><span class="line">Minhas <strong>Vendas:</strong></span></span></span>
            </h4>
            <tbody>
                <asp:Literal ID="ltlVendas" runat="server"></asp:Literal>
               
               <%-- <tr>
                    <td>
                        <a href="#"><div id="flip"><strong>nome produto</strong>, quantidade vendida, data <i class="fa fa-arrow-circle-o-down pull-right"></i></div></a>
                        <div id="panel">
                            <div class="row">
                                <div class="span3">
                                    foto
                                </div>
                                <div class="span3">
                                    Endereço de entrega<br />Rua:sadas<br />estado:as<br />

                                </div>
                                <div class="span3 ">
                                    Forma de pagamento
                                </div>
                                <div class="span3 ">
                                    Status da venda
                                </div>
                            </div>

                        </div>
                    </td>
                </tr>--%>
            </tbody>
        </table>
        <hr />
       <%-- <div class="pagination pagination-centered">
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

    <script src="../../themes/js/jsStatusVenda.js"></script>

     <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>

