<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Erro404.aspx.cs" Inherits="Paginas_Erros_Erro404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- bootstrap -->
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="../../themes/css/bootstrappage.css" rel="stylesheet" />
    <link href="../../bootstrap/css/StyleMeuMenu.css" rel="stylesheet" />
    <link href="../../bootstrap/css/meusEstilos.css" rel="stylesheet" />

    <!-- Styles globals -->
    <link href="../../themes/css/flexslider.css" rel="stylesheet" />
    <link href="../../themes/css/main.css" rel="stylesheet" />

    <!-- scripts -->
    <script src="../../themes/js/jquery-1.7.2.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <script src="../../themes/js/superfish.js"></script>
    <script src="../../themes/js/jquery.scrolltotop.js"></script>
    <script src="../../themes/js/jquery.mask.min.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>



    <%--  [if lt IE 9]>			
			            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
			            <script src="js/respond.min.js"></script>
		            <![endif]--%>
    <%--########################################################################################--%>
    <%--SOCIAL--%>

    <link href="themes/css/fontawesome-4.5.0.min.css" rel="stylesheet" />
    <link href="themes/css/Icones.css" rel="stylesheet" />
    <link href="themes/css/fontawesome-4.7.0.min.css" rel="stylesheet" />

    <link href="../../themes/css/fontawesome-4.5.0.min.css" rel="stylesheet" />
    <link href="../../themes/css/Icones.css" rel="stylesheet" />
    <link href="../../themes/css/fontawesome-4.7.0.min.css" rel="stylesheet" />
    <%--########################################################################################--%>
</head>
<body>
    <form id="form1" runat="server">
        <div><br />
            <div class="container">
                <div class="row">
                    <div class="span12">
                        <div class="hero-unit center">
                            <h1>Página não encontrada <small><font face="Tahoma" color="red">Error 404</font></small></h1>
                            <br />
                            <p>Desculpe a página que você está procurando não pode ser encontrada</p>
                            <p><b>Clique no botão para voltar para a página inicial:</b></p>
                            <a href="/Paginas/Index.aspx" class="i2Style i2Style:active"><i class="icon-home icon-white"></i>Página inicial</a>
                        </div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
