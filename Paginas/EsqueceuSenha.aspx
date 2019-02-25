<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="EsqueceuSenha.aspx.cs" Inherits="Paginas_EsqueceuSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid">
        <div class="span8 pull-right">
            <h4 class="title"><span class="text"><strong>Recuperação de senha</strong></span></h4>
            <asp:Panel ID="pnpBotao" DefaultButton="btnEnviar" runat="server">
                Email: <a class="obrigatorio">*</a>
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-user"></i></span>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input-xlarge" placeholder="Digite seu e-mail" type="text"></asp:TextBox>
                    </div>
                    <br />
                    <asp:RequiredFieldValidator ID="cvNome" ValidationGroup="EsqueceuSenha" ErrorMessage="Insira o email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
                </div>
                <div class="controls">
                    <asp:Button ID="btnEnviar" ValidationGroup="EsqueceuSenha" class="botao" runat="server" type="submit" Text="Enviar" OnClick="btnEnviar_Click" />
                </div>
            </asp:Panel>
            <div class="controls">
                <asp:Label runat="server" ID="lblRetorno"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

