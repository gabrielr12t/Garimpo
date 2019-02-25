<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="Produto.aspx.cs" Inherits="Paginas_Produtos_Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   

    <%--<link href="../CarrinhoJS/estiloADDCarrinho.css" rel="stylesheet" />
    <script src="../CarrinhoJS/ADDCarrinho.js"></script>--%>
    <script>

        
    </script>
    <section class="container">
        <asp:Label runat="server" ID="lblvendedor"> </asp:Label>
        <!-- VENDEDOR -->
        <%-- <div class="row-fluid" id="secao">
            <div class="span3" id="first">
                <!-- foto do vendedor -->
                <a href="/Paginas/Usuário/PáginaVendedor.aspx" class="fotoPerfilGrande" data-toggle="tooltip" data-placement="bottom" title="Clique na foto para acessar o perfil do vendedor">
                    <img class="fotoPerfilGrande" src="../../themes/images/FOTO PERFIL/jovem-nerd-doidão.jpg" /></a>
            </div>
            <div class="span3" id="second">
                <div class="fonte-estilo">
                    Brechó do <strong></strong><br />
                    Curitiba/Paraná
                </div>

            </div>
            <div class="span3" id="third">
                <asp:Label ID="lblRecebeReputacao" runat="server" Text="Reputação: Muito Boa" CssClass="rep-ven"></asp:Label>
            </div>
            <div class="span3" id="fourth">
                <asp:Label ID="lblRecebeVenda" runat="server" Text="Total de Vendas: 230" CssClass="rep-ven"></asp:Label>
            </div>
            <div class="span11">
                <hr />
            </div>
        </div>--%>

        <!-- PRODUTO -->
        <!-- caminho do produto -->

        <asp:Label ID="lblCategorias" runat="server"></asp:Label>
        <%--<div class="span3 container-fluid">
            <span>NERD/</span>
            <span>ROUPAS/</span>
            <span>CAMISAS</span>
        </div>--%>
        <br />
        <br />
        <%------------------------------------------%>
        <section class="main-content">
            <%--label das informações do produto--%>
            <asp:Label runat="server" ID="lblInformacoes"></asp:Label>
            <%--<div class="row">
                <div class="span11">
                    <div class="row">
                        <div class="span4">
                            <a href="../../themes/images/cloth 4 nerd/nerd 5.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 1">
                                <img alt="" src="../../themes/images/cloth 4 nerd/nerd 5.jpg" /></a>
                            <ul class="thumbnails small">
                                <li class="span1">
                                    <a href="./../themes/images/cloth PRODUTO/angulo-02.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 2">
                                        <img src="../../themes/images/cloth PRODUTO/angulo-02.jpg" alt="" /></a>
                                </li>
                                <li class="span1">
                                    <a href="../../themes/images/cloth PRODUTO/angulo-03.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 3">
                                        <img src="../../themes/images/cloth PRODUTO/angulo-03.jpg" alt="" /></a>
                                </li>
                                <li class="span1">
                                    <a href="../../themes/images/cloth PRODUTO/angulo-04.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 4">
                                        <img src="../../themes/images/cloth PRODUTO/angulo-04.jpg" alt="" /></a>
                                </li>
                                <li class="span1">
                                    <a href="../../themes/images/ladies/5.jpg" class="thumbnail" data-fancybox-group="group1" title="Description 5">
                                        <img src="../../themes/images/ladies/5.jpg" alt="" /></a>
                                </li>
                            </ul>
                        </div>
                        <div class="span7">
                            <address>
                                <span class="roxo">Camisa Nerd Power</span><br />
                                <span class="marg">Tamanho: M</span>
                                <span>Marca: Jovem Nerd</span><br />
                                <hr />
                                <p class="descricao">
                                    Levante sua bandeira e vista sua camisa!
                                    <br />
                                    Mostre seu orgulho Nerd de ser!<br />
                                    Camiseta 100% algodão, fio 30 penteado.<br />
                                    Gola com costura reforçada.<br />
                                </p>

                                <hr />
                                <a href="#"><i class="fa fa-heart-o iconemenu marg"></i></a>
                                <a href="#"><i class="fa fa-shopping-cart iconemenu marg"></i></a>
                                <span class="preço">$ 25,00</span>
                                <asp:Button ID="Button2" class="i2Style i2Style:active botao-publicar comprar" type="submit" runat="server" Text="COMPRAR" OnClick="btnPublicar_Click" />
                                <br />
                                <a href="#" class="frete"><u>Calcular Frete</u></a>
                            </address>
                        </div>
                    </div>
                </div>
            </div>--%>
        </section>
        <%------------------------------------------%>

        <!-- CAIXA DE PERGUNTAS -->
        <div class="row-fluid">
            <div class="span12" id="divperg">
                <label id="perg"><strong>Tire Suas Dúvidas</strong> </label>
                <asp:TextBox ID="txtMensagem" runat="server" MaxLength="1000" Rows="20" Columns="40" Width="80%" Height="50px" TextMode="MultiLine" class="text"></asp:TextBox><br />
                <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" ID="s" Display="Dynamic" ForeColor="red" ControlToValidate="txtMensagem" ErrorMessage="Campo vazio" ValidationGroup="mensagem"></asp:RequiredFieldValidator>
                <asp:Button ID="btnPergunta" ValidationGroup="mensagem" OnClick="btnPergunta_Click" class="i2Style i2Style:active botao-publicar" type="submit" runat="server" Text="ENVIAR" /><br />
                <%--<asp:Label ID="lblRecebeDenuncia" runat="server" Text="Denúncia" class="marg"> <a href="/Paginas/Usuário/Denuncia.aspx"><u>Denunciar</u></a></asp:Label>--%>
                <asp:Label ID="lblDenunciar" runat="server"></asp:Label>
            </div>
        </div>
        <style>
            .testecor {
                color: #8f8d8d;
            }

            .divider {
                height: 1px;
                width: 100%;
                display: block; /* for use on default inline elements like span */
                margin: 9px 0;
                overflow: hidden;
                background-color: #e5e5e5;
            }
        </style>
        <%------- CHAT ----------%>




        <div class="row-fluid">
            <div class="span8 offset2">
                <asp:Label ID="lblSuaPergunta" runat="server"></asp:Label>
                <asp:Label ID="lblMinhaPergunta" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <hr class="divider" />
        <br />

        <div class="row-fluid">
            <div class="span8 offset2">
                <h3 class="text-center">Perguntas e Respostas</h3>
                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="span12">
                <h4 class="title">
                    <span class="pull-left"><span class="text"><span class="line">Produtos <strong><u>Similares</u></strong></span></span></span>
                    <span class="pull-right">
                        <a class="left button" href="#myCarousel-4" data-slide="prev"></a>
                        <a class="right button" href="#myCarousel-4" data-slide="next"></a>
                    </span>
                </h4>
                <div id="myCarousel-5" class="myCarousel carousel slide">
                    <div class="carousel-inner">                       
                        <asp:Literal ID="ltlProdutosSimilares" runat="server"></asp:Literal>                 
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="span12">
                <h4 class="title">
                    <span class="pull-left"><span class="text"><span class="line">Outros Produtos <strong><u><a href="../Usuário/PáginaVendedor.aspx">Do Vendedor</a></u></strong></span></span></span>
                    <span class="pull-right">
                        <a class="left button" href="#myCarousel-4" data-slide="prev"></a>
                        <a class="right button" href="#myCarousel-4" data-slide="next"></a>
                    </span>
                </h4>
                <div id="myCarousel-4" class="myCarousel carousel slide">
                    <div class="carousel-inner">                       
                        <asp:Literal ID="ltlProdutosVendedor" runat="server"></asp:Literal>                 
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Modal Responder-->
    <div id="ModalResposta" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">Modal header</h3>
        </div>
        <div class="modal-body center">
            <strong>Pergunta:</strong><br />
            <asp:TextBox BorderStyle="None" ReadOnly="true" ID="txtConteudo" CssClass="textbox input-xlarge" ClientIDMode="Static" runat="server"></asp:TextBox><br />
            <strong>Resposta:</strong><br />
            <asp:TextBox ID="txtResposta" runat="server" ClientIDMode="Static" CssClass="textbox input-xlarge"></asp:TextBox><br />
            <asp:Button Text="Enviar" runat="server" ID="btnResposta" OnClick="btnResposta_Click" CssClass="i2Style i2Style:active" />
            <%--<asp:LinkButton ID="btnResponder" runat="server" CssClass=""><i class="fa fa-send fa-1x"></i> Responder</asp:LinkButton>--%>
            <asp:HiddenField ID="txtCodigo" ClientIDMode="Static" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="txtUsuCpf" ClientIDMode="Static" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="txtCpfPergunta" ClientIDMode="Static" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="txtPerguntaCodigo" ClientIDMode="Static" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="txtCodigoProduto" ClientIDMode="Static" runat="server"></asp:HiddenField>
        </div>
        <div class="modal-footer">
            <button class="botao-cancelar" data-dismiss="modal" aria-hidden="true">cancelar</button>
        </div>
    </div>
      <script type="text/javascript">            
            $(document).ready(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        </script>
    <script type="text/javascript">
        $(".RespostaVendedor").click(function () {
            $("#ModalResposta").modal("show");
            var dados = $(this).attr("rel").split("|");
            $("#txtCodigo").val(dados[0]);
            $("#txtConteudo").val(dados[1]);
            $("#txtUsuCpf").val(dados[2]);
            $("#txtCpfPergunta").val(dados[3]);
            $("#txtPerguntaCodigo").val(dados[4]);
            $("#txtCodigoProduto").val(dados[5]);
        });
    </script>

    <script type="text/javascript">
        function NaoLogado() {
            swal("É necessário estar logado para continuar", {
                button: false,
            });
            //setTimeout(function () {
            //    window.location.href = '/Paginas/Login.aspx';
            //}, 2000);
        }
    </script>

    <%--  <script src="../../themes/js/common.js"></script>--%>
    <script>
        $(function () {
            $('#myTab a:first').tab('show');
            $('#myTab a').click(function (e) {
                e.preventDefault();
                $(this).tab('show');
            })
        })
        $(document).ready(function () {
            $('.thumbnail').fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('#myCarousel-2').carousel({
                interval: 2500
            });
        });
    </script>
   

    <script type="text/javascript">
        function Redirecionar() {
            //var codigo = parseInt.$(this).attr("rel");
            location.href = "/Paginas/Carrinho.aspx?id=" + codigo;
        }
    </script>

    <script src="favoritarProduto.js"></script>
    <%--<script src="../favoritarProduto.js"></script>--%>


</asp:Content>

