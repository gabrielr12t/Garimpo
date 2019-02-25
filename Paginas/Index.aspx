<%@ Page Title="" Language="C#" MasterPageFile="../Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Paginas_Produtos_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%------ Java Script Carousel --------%>
    <style>
       
    </style>

    <asp:HiddenField ID="cpfUsuario" runat="server" />
    <asp:HiddenField ID="idProduto" runat="server" />
    <%------ BANNER COM IMAGENS SLIDE---------%>
    <section class="homepage-slider" id="home-slider">
        <div class="flexslider">
            <ul class="slides">
                <li>
                    <a href="#">
                        <img src="../themes/images/carousel/carousel-normal/garimpo-moda-2.jpg" alt="" /></a>
                    <div class="intro">
                        <h1>Garimpo moda retro</h1>
                        <p><span>fazemos seu estilo</span></p>

                    </div>
                </li>
                <li>
                    <a href="#">
                        <img src="../themes/images/carousel/carousel-normal/garimpo-moda.jpg" alt="" /></a>
                    <div class="intro">
                        <h1>Não usa mais sua roupa?</h1>
                        <p><span>venda no Garimpo</span></p>
                    </div>
                </li>

            </ul>
        </div>
    </section>

    <%------ FORMAS DE PAGAMENTO --------%>
    <section class="span8 center">
        <br />
        Pague no boleto, débito ou no cartão:   		
            <span class="glyphicon glyphicon-random">
                <a href="#"><i class="fa fa-cc-visa iconemenu cartao"></i></a>
                <a href="#"><i class="fa fa-cc-mastercard iconemenu cartao"></i></a>
                <a href="#"><i class="fa fa-cc-visa iconemenu cartao"></i></a>
            </span>
    </section>


    <section class="main-content">
        <div class="row">
            <div class="span12">
                <div class="row">
                    <div class="span12">
                        <h4 class="title">
                            <span class="pull-left"><span class="text"><span class="line">Produtos mais <strong><a href="/Paginas/Produtos/GradeProdutos.aspx"><u>Pesquisados</u></a></strong></span></span></span>
                            <span class="pull-right">
                                <a class="left button" href="#myCarousel" data-slide="prev"></a><a class="right button" href="#myCarousel" data-slide="next"></a>
                            </span>
                        </h4>
                        <%---------  Mais pesquisados  ---------%>
                        <div id="myCarousel" class="myCarousel carousel slide">
                            <div class="carousel-inner">
                                <asp:Literal ID="ltlMaisPesquisados" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <br />


                <div class="row">
                    <div class="span12">
                        <h4 class="title">
                            <span class="pull-left"><span class="text"><span class="line"><a href="/Paginas/Produtos/GradeProdutos.aspx"><u><strong>Promoções</strong></u></a></span></span></span>
                            <span class="pull-right">
                                <a class="left button" href="#myCarousel-2" data-slide="prev"></a>
                                <a class="right button" href="#myCarousel-2" data-slide="next"></a>
                            </span>
                        </h4>
                        <%--------- a fazer ---------%>
                        <div id="myCarousel-2" class="myCarousel carousel slide">
                            <div class="carousel-inner">
                                <asp:Literal ID="ltlPromocao" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="span12">
                        <h4 class="title">
                            <%--<span class="pull-left"><span class="text"><span class="line">Pode ser do seu <strong><u>interesse</u></strong></span></span></span>--%>
                            <asp:Label ID="lblFrase" runat="server"></asp:Label>
                            <span class="pull-right">
                                <a class="left button" href="#myCarousel-3" data-slide="prev"></a>
                                <a class="right button" href="#myCarousel-3" data-slide="next"></a>
                            </span>
                        </h4>
                        <div id="myCarousel-3" class="myCarousel carousel slide">
                            <div class="carousel-inner">
                               <asp:Literal ID="ltlSeuInteresse" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="favoritar.js"></script>

    <script>
        if ("Notification" in window) {
            let ask = Notification.requestPermission();
            ask.then(permission => {
                if (permission === "granted") {
                    setTimeout(function () {
                        let msg = new Notification("Garimpo", {
                            body: "Bem vindo ao Garimpo",
                            icon: "/themes/images/atendente.png"
                        });
                        msg.addEventListener
                    }, 10000);
                }
            });
        }
        

        function NaoLogado() {
            swal("É necessário estar logado para favoritar um produto", {
                button: false,
            });
        }
    </script>
     <script type="text/javascript">            
            $(document).ready(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        </script>

</asp:Content>

