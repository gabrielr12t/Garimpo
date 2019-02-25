<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecuperarSenha.aspx.cs" Inherits="Paginas_RecuperarSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>



    <link href="../Bootstrap4/css/bootstrap.min.css" rel="stylesheet" />

    <script src="../Bootstrap4/js/bootstrap.min.js"></script>


</head>
<body>
    <form id="form1" runat="server"><br />
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h3>Recuperação de senha</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    E-mail:
                    <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <asp:Button ID="btnEnviar" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                </div>
            </div>
            <asp:Label ID="lblSite" runat="server" ><a href="google.com"></a></asp:Label>
        </div>

    </form>
</body>
</html>
