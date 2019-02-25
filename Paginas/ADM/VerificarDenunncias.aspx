<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterADM.master" AutoEventWireup="true" CodeFile="VerificarDenunncias.aspx.cs" Inherits="Paginas_ADM_VerificarDenunncias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row center span8">
        <table class="table table-striped">
            <thead>
            </thead>
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Verificar <strong>denúncias:</strong></span></span></span>
            </h4>
            Sobre publicação:<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Foto irregular</asp:ListItem>
                <asp:ListItem>Descrição irregular</asp:ListItem>
                <asp:ListItem>produto em categoria errada</asp:ListItem>
            </asp:DropDownList>
            sobre comentáriio:<asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Compartilhamento conta</asp:ListItem>
                <asp:ListItem Value="Compartilhamento dados"></asp:ListItem>
                <asp:ListItem>Ofensa a usuário</asp:ListItem>
            </asp:DropDownList>
            <tbody>
                <asp:Literal ID="ltlDenuncia" runat="server"></asp:Literal>
                <%-- <tr>
                    <td>
                        <p>
                            <asp:CheckBox ID="CheckBox2" runat="server" />                            
                        </p>
                    </td>
                    <td><a href="#">
                        <p>#cod-produto</p>
                        <p><strong>Produto categoria errada</strong></p>
                    </a></td>
                    <td><strong>Nome do Produto</strong><br />
                        <a href="#">
                            <asp:Label ID="Label3" runat="server" Text="Categoria/subcategoria"></asp:Label></a>
                    </td>
                    <td>
                        <a href="#" data-toggle="tooltip" data-placement="bottom" title="Desativar produto"><i class="icon-remove"></i></a>
                    </td>
                </tr>--%>
            </tbody>
        </table>
        <hr />


        <div class="pagination pagination-centered">
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

    <script src="../../themes/js/jsDenuncias.js"></script>

    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });

    </script>
</asp:Content>

