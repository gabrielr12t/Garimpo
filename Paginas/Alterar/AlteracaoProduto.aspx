<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="AlteracaoProduto.aspx.cs" Inherits="Paginas_Alterar_AlteracaoProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">
        $(document).ready(function () {
            $('.telefone').mask('(99) 9999-9999');
            $('.data').mask('99/99/9999');
            $('.cep').mask('99999-999');
            $(".preco").maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
        });


        function concluir() {
            swal("Para vender é obrigatório ter completado o dadastro e possuir um endereço!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Cadastro/ConcluirCadastro.aspx';
            }, 2000);
        }
    </script>
    <style>
        .textbox {
            border-radius: 3px !important;
        }

        .botaonovo {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            color: #ffffff;
            padding: 10px 20px;
            background: -moz-linear-gradient( top, #bf20bf 0%, #bf20bf);
            background: -webkit-gradient( linear, left top, left bottom, from(#bf20bf), to(#bf20bf));
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 2px solid #d17dc4;
            -moz-box-shadow: 0px 1px 3px rgba(000,000,000,1), inset 0px 0px 3px rgba(219,40,219,0.2);
            -webkit-box-shadow: 0px 1px 3px rgba(000,000,000,1), inset 0px 0px 3px rgba(219,40,219,0.2);
            box-shadow: 0px 1px 3px rgba(000,000,000,1), inset 0px 0px 3px rgba(219,40,219,0.2);
            text-shadow: 0px -1px 0px rgba(209,157,209,0.2), 0px 1px 0px rgba(255,255,255,1);
        }

        .swal-overlay {
            background-color: rgba(75, 62, 110,0.45);
        }
    </style>

    <h4 class="title">Alteração <strong>Produto</strong></h4>
    <br />


    <h4 class="title"><strong></strong></h4>
    <div class="row">

        <div class="container">
            <div class="col-md-4">
                <div class="control-group">
                    Nome: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtNome" runat="server" MaxLength="26" CssClass="input-xlarge textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    Descriçao: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtDescricao" MaxLength="100" CssClass="input-xlarge textbox" TextMode="MultiLine" runat="server" Rows="2"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    Preço: <a class="obrigatorio">*</a>
                    <div class="control">
                        <asp:TextBox ID="txtPreco" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                    </div>
                    <%--<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtPreco" ErrorMessage="Data inválida" Display="Dynamic" ForeColor="Red" ValidationExpression="^\d+?(.|,\d+)$"></asp:RegularExpressionValidator>--%>
                </div>
            </div>
            <div class="col-md-4">
                <div class="control-group">
                    Fotos que seu produto possui
                        <div class="controls">
                            <asp:Literal ID="ltlFotos" runat="server"></asp:Literal><br />
                        </div>
                </div>
                <div class="control-group">
                    <div class="control-group">
                        Adicionar todas as Fotos de uma vez:
                    <div class="controls">
                        <asp:FileUpload ID="uplImagem" AllowMultiple="true" runat="server" />
                        <asp:Button ID="btnAdd" runat="server" CssClass="i2Style i2Style:active" OnClick="btnAdd_Click" Text="Adicionar fotos" />
                    </div>
                    </div>
                </div>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="updPanel" runat="server">
                <ContentTemplate>
                    <div class="col-md-3">
                        <div class="control-group">
                            Estilo: <a class="obrigatorio">*</a>
                            <div class="controls">
                                <asp:DropDownList ID="ddlEstilo" CssClass="dropdown textbox span2" OnSelectedIndexChanged="ddlEstilo_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            Categoria: <a class="obrigatorio">*</a>
                            <div class="controls">
                                <asp:DropDownList ID="ddlCategoria" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" CssClass="dropdown textbox span2" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            SubCategoria: <a class="obrigatorio">*</a>
                            <div class="controls">
                                <asp:DropDownList ID="ddlSubcategoria" CssClass="dropdown textbox span2" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <h4 class="title" style="margin-left: 15px"><strong></strong></h4>
            <div class="col-md-4">
                <div class="control-group">
                    Condição: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:DropDownList ID="ddlCondicao" CssClass="dropdown textbox span2" runat="server">
                            <asp:ListItem Value="novo">Novo</asp:ListItem>
                            <asp:ListItem Value="semi-novo">Semi-Novo</asp:ListItem>
                            <asp:ListItem Value="usado">Usado</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    Quantidade: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:DropDownList ID="ddlQuantidade" CssClass="dropdown textbox span2" runat="server">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%--onchange="this.form.submit()"--%> 
                 Marca: <a class="obrigatorio">*</a>
                <div class="controls">
                    <asp:DropDownList ID="ddlMarca" CssClass="dropdown textbox span2" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="col-md-3">
                <div class="control-group">
                    <div class="controls">
                        <asp:Literal ID="ltlFotosNovas" runat="server"></asp:Literal>
                    </div>
                </div>               
            </div>
            <div class="col-md-3">
                 <div class="control-group">
                    <div class="controls">
                        <asp:Button ID="btnFinalizar" Text="Concluir alteração" CssClass="i2Style i2Style:active pull-right" OnClick="btnFinalizar_Click" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <div class="controls">
                        <asp:Label ID="lblRetorno" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="../../themes/js/jsExcluirImagem.js"></script>

    <script type="text/javascript">
        function Confirma() {
            swal("Produto Alterado!!", {
                icon: "success",
                buttons: {
                    // cancel: "Run away!",
                    catch: {
                        text: "Ok",
                        value: "ok",
                    },
                },
            })
                .then((value) => {
                    switch (value) {
                        case "ok":
                            swal("Seu produto passará por uma nova moderação!", {
                                button: false,
                            });
                            setTimeout(function () {
                                window.location.href = '/Paginas/Index.aspx';
                            }, 2300);
                            break;
                        default:
                            //swal("Você receberá uma mensagem quando seu produto for aprovado!", {
                            //    button: false,
                            //});
                            //setTimeout(function () {
                            window.location.href = '/Paginas/Index.aspx';
                        //}, 2300);
                    }
                });
        }
    </script>
</asp:Content>

