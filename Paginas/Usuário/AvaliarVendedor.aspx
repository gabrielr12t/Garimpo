<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="AvaliarVendedor.aspx.cs" Inherits="Paginas_Usuário_AvaliarVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .margem {
            margin-left: 5%;
        }
    </style>
    <br />
    <asp:Literal ID="ltlMensagem" runat="server"></asp:Literal>
    <div class="span11 center">
        <p class="lead">Avalie sua experiência com o vendedor</p>
    </div>
    <br />

    <asp:Panel ID="pnlInicial" runat="server">
        <div class="span11 center" style="border: 0.1px solid; border-color: #d4d4d4">
        <br />
        <asp:Button ID="btnRecebi" runat="server" CssClass="i2Style i2Style:active btn-success" OnClick="btnRecebi_Click" Text="Recebi o produto" />
        <asp:Button ID="btnNaoRecebi" runat="server" CssClass="i2Style i2Style:active btn-danger" OnClick="btnNaoRecebi_Click" Text="Não recebi o produto" />
    </div>
    </asp:Panel>

    <asp:Panel ID="pnlRecebeu" runat="server" Visible="false">
        <div class="span11  " style="border: 0.1px solid; border-color: #d4d4d4">
            <br />
            <%--   <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Caso recebo o produto  </span></span></span>
            </h4>--%>
            <blockquote>
                <p>° O vendedor respondeu suas mensagens?</p>
                <asp:RadioButtonList ID="rbtMensagens" runat="server" RepeatDirection="vertical" CssClass="radio inline">
                    <asp:ListItem Value="100"><p class="help-inline">Sim todas</p> </asp:ListItem>
                    <asp:ListItem Value="50"><p class="help-inline"> Algumas</p></asp:ListItem>
                    <asp:ListItem Value="0"><p class="help-inline"> Nenhuma </p></asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
                <p>° O vendedor enviou no prazo?</p>
                <asp:RadioButtonList ID="rbtPrazo" runat="server" RepeatDirection="vertical" CssClass="radio inline">
                    <asp:ListItem Value="100"><p class="help-inline">No prazo </p> </asp:ListItem>
                    <asp:ListItem Value="50"><p class="help-inline "> Pouco atraso </p></asp:ListItem>
                    <asp:ListItem Value="0"><p class="help-inline"> Muito atraso </p></asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
                <p>° O produto confere com a descrição?</p>
                <asp:RadioButtonList ID="rbtConfere" runat="server" RepeatDirection="Vertical" CssClass="radio inline">
                    <asp:ListItem Value="100"><p class="help-inline">Sim </p> </asp:ListItem>
                    <asp:ListItem Value="0"><p class="help-inline "> Não </p></asp:ListItem>
                </asp:RadioButtonList>
            </blockquote>
           
            <div class="span4">
                <asp:Button ID="btnRecebeu" CssClass="i2Style i2Style:active" runat="server" Text="Enviar avaliação" OnClick="btnRecebeu_Click" />
            </div>  
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlNRecebeu" Visible="false" runat="server">
        <div class="span11" style="border: 0.1px solid; border-color: #d4d4d4">
            <br />
            <%-- <h4 class="title">
                <span class="text-center"><span class="text"><span class="line">Caso não receba o produto </span></span></span>
            </h4>--%>
            <blockquote>

                <asp:RadioButtonList ID="rbtNrecebeu" runat="server" RepeatDirection="vertical" CssClass="radio inline ">
                    <asp:ListItem Value="-25"><p class="help-inline">O vededor não enviou</p> </asp:ListItem>
                    <asp:ListItem Value="100"><p class="help-inline"> Tive problemas com os correios</p></asp:ListItem>
                    <asp:ListItem Value="-25"><p class="help-inline"> O vendedor não compareceu ao local combinado </p></asp:ListItem>
                    <asp:ListItem Value="100"><p class="help-inline"> Cancelei a compra </p></asp:ListItem>
                </asp:RadioButtonList>
            </blockquote>
             <div class="span4">
                <asp:Button ID="btnNRecebeu" CssClass="i2Style i2Style:active" runat="server" Text="Enviar avaliação" OnClick="btnNRecebeu_Click" />
            </div>      
        </div>
        
             
    </asp:Panel>

    <script>
  function feedback() {
                swal("Obrigado pelo seu seu feedback!!", {
                    button: false,
                });
                setTimeout(function () {
                    window.location.href = '/Paginas/Index.aspx';
                }, 2000);
            }
    </script>
</asp:Content>

