<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="Denuncia.aspx.cs" Inherits="Paginas_Usuário_Denuncia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- regras publicação -->
    <br />
    <div class="span11 center">
        <h4 class="title">
            <span class="text-center">Conheça nossas <strong><a href="regras de publicação"><u>regras de publicação</u></a></strong> para saber se tem algo irregular</span>
        </h4>
    </div>

    <!-- condição denuncia publicação -->
    <div class="span6 left">
        <div class="span6 left" style="border: 0.1px solid; border-color: #d4d4d4">
            <!--------------------------------------------------------------------------------------------------------->
            <br />
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">denunciar publicação <strong>(condição)</strong></span></span></span>
            </h4>
            <blockquote>
                <!--------------------------------------------------------------------------------------------------------->
                <asp:RadioButtonList ValidationGroup="produto" ID="rbtProdutos" runat="server" RepeatDirection="vertical" CssClass="radio inline">
                    <asp:ListItem Value="1"><p>denunciar foto irregular</p></asp:ListItem>
                    <asp:ListItem Value="2"><p>denunciar descrição irregular</p></asp:ListItem>
                    <asp:ListItem Value="3"><p>denunciar produto em categoria errada</p></asp:ListItem>
                </asp:RadioButtonList>
                <!--------------------------------------------------------------------------------------------------------->
                <br />
                <!--------------------------------------------------------------------------------------------------------->
                <div class="span3 pull-right">
                    <asp:Button  ValidationGroup="produto" ID="btnDenunciarProduto" OnClick="btnDenunciarProduto_Click" runat="server" Text="denunciar" class="pull-center btn btn-danger" />
                </div>
            </blockquote>
            <!--------------------------------------------------------------------------------------------------------->
            <br />
            <br />
            <br />
        </div>
    </div>
    <asp:Label ID="lblMensagem" Visible="false" runat="server"></asp:Label>
    <!-- condição denunciar comentário -->
    <%-- <div class="span6 right">
       <div class="span6 left" style="border: 0.1px solid; border-color: #d4d4d4">
            <!--------------------------------------------------------------------------------------------------------->
            <br />
            <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">denunciar comentário <strong>(condição)</strong></span></span></span>
            </h4>
            <!--------------------------------------------------------------------------------------------------------->
            <blockquote>
                <asp:RadioButtonList ID="rbtOpcao" runat="server"  RepeatDirection="vertical" CssClass="radio inline">
                    <asp:ListItem Value="5"><p >usuário compartilha conta bancária</></asp:ListItem>
                    <asp:ListItem Value="5"><p>usuário compartilha dados de contato</p></asp:ListItem>
                    <asp:ListItem Value="5"><p>usuário ofende outro usuário</p></asp:ListItem>
                </asp:RadioButtonList>
                <!--------------------------------------------------------------------------------------------------------->
                <br />
                <!--------------------------------------------------------------------------------------------------------->
                <div class="span3 pull-right">
                    <asp:Button ID="btnDenunciarComentario" runat="server" Text="denunciar" class="pull-center btn btn-danger" />
                </div>
            </blockquote>
            <!--------------------------------------------------------------------------------------------------------->
            <br />
            <br />
            <br />
        </div>
    </div>--%>

    <script type="text/javascript">

        function enviado() {
            swal("Obrigado por nos ajudar!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Index.aspx';
            }, 3000);

        }
    </script>
</asp:Content>

