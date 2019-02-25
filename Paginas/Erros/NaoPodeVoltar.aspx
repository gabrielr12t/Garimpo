<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NaoPodeVoltar.aspx.cs" Inherits="Paginas_Erros_NaoPodeVoltar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="../../themes/css/bootstrappage.css" rel="stylesheet" />
    <link href="../../bootstrap/css/meusEstilos.css" rel="stylesheet" />
    <link href="../../bootstrap/css/EstiloProduto.css" rel="stylesheet" />
    <link href="../../bootstrap/css/EstiloCadastroProduto.css" rel="stylesheet" />

    <!-- Styles globals -->
    <link href="../../themes/css/flexslider.css" rel="stylesheet" />
    <link href="../../themes/css/main.css" rel="stylesheet" />

    <!-- scripts -->
    <script src="../../themes/js/jquery-1.7.2.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <script src="../../themes/js/superfish.js"></script>
    <script src="../../themes/js/jquery.scrolltotop.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <h3 style="color: black">Você já passou por aqui</h3>
            <div class="alert alert-danger">
                <strong>
                    <h3>Clique<a href="/Paginas/Index.aspx"> aqui </a>para voltar à pagina inicial</h3>
                    <h3>Clique<a href="/Paginas/Cadastro/ConcluirCadastro.aspx"> aqui</a> para continuar seu cadastro</h3>
                </strong>
            </div>
        </div>
    </form>
</body>
</html>

