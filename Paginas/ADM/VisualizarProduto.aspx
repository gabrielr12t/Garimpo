<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="VisualizarProduto.aspx.cs" Inherits="Paginas_ADM_VisualizarProduto" %>

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

        .texto {
            font: bold 15px;
            color: black;
        }

        .borda {
            border: dashed 1px #f8f2f2;
        }
    </style>


    <br />



    <h4 class="title"><strong></strong></h4>
    <div class="row">


        <div class="container">
            <div class="col-md-4">
                <div class="control-group">
                    Nome: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtNome" ReadOnly="true" runat="server" MaxLength="26" CssClass="input-xlarge textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    Descriçao: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtDescricao" ReadOnly="true" MaxLength="200" CssClass="input-xlarge textbox" TextMode="MultiLine" runat="server" Rows="2"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    Preço: <a class="obrigatorio">*</a>
                    <div class="control">
                        <asp:TextBox ID="txtPreco" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                    </div>
                    <%--<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtPreco" ErrorMessage="Data inválida" Display="Dynamic" ForeColor="Red" ValidationExpression="^\d+?(.|,\d+)$"></asp:RegularExpressionValidator>--%>
                </div>
            </div>
            <div class="col-md-4">
                <div class="control-group">
                    Marca: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtMarca" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="control-group">
                    Condição: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtCondicao" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    Quantidade: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtQuantidade" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtEstilo" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        Categoria: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:TextBox ID="txtCategoria" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        SubCategoria: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:TextBox ID="txtSubcategoria" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <h4 class="title" style="margin-left: 15px"><strong></strong></h4>

        <div class="col-md-3">
          
            <div class="control-group">
                Fotos do seu produto<a class="obrigatorio">*</a>
                <div class="controls">
                    <%--<img src="../../themes/icones/Camera_Next_30014.png" style="width: 50px; height: 50px" />--%>
                    <asp:Label ID="lblImagens" CssClass="texto borda" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <asp:Panel ID="pnlCamisa" Visible="false" runat="server">
            <div class="col-md-3">
                <div class="control-group">
                    Tamanho: <a class="obrigatorio">*</a>
                    <div class="controls">
                        <asp:TextBox ID="txtTamanho" ReadOnly="true" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="col-md-3">
            <div class="control-group">
                Formas de envio:
                <asp:Label ID="lblEnvio" runat="server">Como você pode enviar?:<a class="obrigatorio">*</a></asp:Label>
                <div class="controls">
                    <asp:Label ID="lblFormasEnvio" CssClass="texto borda" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="control-group">
                <div class="controls">
                    <asp:Button ID="btnVoltar" Text="Voltar" PostBackUrl="~/Paginas/ADM/ModerarProdutos.aspx" CssClass="botaonovo" runat="server" />
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

    <script type="text/javascript">
        function Confirma() {
            swal("Produto Cadastrado!!", {
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
                            swal("Você receberá uma mensagem quando seu produto for aprovado!", {
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

