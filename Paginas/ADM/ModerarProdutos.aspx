<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterADM.master" AutoEventWireup="true" CodeFile="ModerarProdutos.aspx.cs" Inherits="Paginas_ADM_ModerarProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row center span8">
        <h4 class="title">
            <span class="text-center"><span class="text"><span class="line">Produtos <strong>à moderar:</strong></span></span></span>
        </h4>
        <asp:HiddenField ID="teste" runat="server"></asp:HiddenField>
        <asp:Label ID="lblDinamica" runat="server"></asp:Label>

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
   
    <%----------------------------------------------------------------%>
    <script src="../../themes/js/jsProdutosModerado.js"></script>
    <script src="../../themes/js/jsNaoAceito.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>

</asp:Content>
