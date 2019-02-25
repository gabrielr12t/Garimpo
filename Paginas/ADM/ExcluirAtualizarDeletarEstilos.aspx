<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterADM.master" AutoEventWireup="true" CodeFile="ExcluirAtualizarDeletarEstilos.aspx.cs" Inherits="Paginas_ADM_AlterarEstilosCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <style>
        .margem {
            margin-left: 5%;
        }

        .quadradoTamanho {
            width: 30px;
            height: 20px;
            color: black;
            background-repeat: no-repeat;
            background-position: center center;
            background-size: cover;
            display: inline-block;
            border: groove 1px;
            text-align: center;
        }
    </style>


    <div class="span8" style="border: 0.1px solid; border-color: #d4d4d4">
        <h4 class="title">
            <span class="text-center"><span class="text"><span class="line">Categorias <strong>Alterações</strong></span></span></span>
        </h4>
        <div class="span12">



            <div class="margem">
                <div class="row">
                    <div class="span6 center">
                        <label>Selecione o estilo:</label>
                        <asp:DropDownList ID="ddlEstilo" runat="server"></asp:DropDownList>
                        <asp:Label ID="lblRetorno" runat="server" ></asp:Label>  
                    </div>
                                                                                               
                </div><br />
                <div class="span3 center"><asp:Button ID="btnDelete" runat="server" Text="Deletar" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>
                <div class="span2 center"><asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" CssClass="btn btn-warning" /></div>
                <div class="span2 center"><asp:Button ID="btnSalvar" Visible="false" runat="server" Text="Salvar" CssClass="btn btn-success" /></div>                
                <br /><br />
            </div>
            <%--<div class="margem">
                <strong>Nome: </strong>
                <asp:Label ID="lblNome" runat="server" Text="Nome Do Usuário Logado Aqui"></asp:Label>
                <div class="col-lg-5 pull-right">
                    <a href="#" data-toggle="tooltip" data-placement="bottom" title="Editar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                </div>
                <br />
                <strong>E-mail: </strong>
                <asp:Label ID="lblEmail" runat="server" Text="email@usuario.aqui"></asp:Label><div class="col-lg-5 pull-right">
                    <a href="#" data-toggle="tooltip" data-placement="bottom" title="Editar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                </div>
                <br />
                <strong>Sexo: </strong>
                <asp:Label ID="lblSexo" runat="server" Text="xxxxxxx"></asp:Label><div class="col-lg-5 pull-right">
                </div>
                <br />
                <strong>Data Nascimento: </strong>
                <asp:Label ID="lblDataNasc" runat="server" Text="xx/xx/xxxx"></asp:Label><div class="col-lg-5 pull-right">
                </div>
                <br />
                <strong>Telefone: </strong>
                <asp:Label ID="lblTelefone" runat="server" Text="(00) 0000-0000"></asp:Label><div class="col-lg-5 pull-right">
                    <a href="#" data-toggle="tooltip" data-placement="bottom" title="Editar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                </div>
                <br />
                <strong>CPF: </strong>
                <asp:Label ID="lblCpf" runat="server" Text="000.000.000.00"></asp:Label><div class="col-lg-5 pull-right">
                </div>
                <br />
                <br />
                 <asp:Button ID="btnEditarCad" CssClass="botao " runat="server" Text="Editar endereço" /><br /><br />
            </div>--%>
        </div>

    </div>
</asp:Content>

