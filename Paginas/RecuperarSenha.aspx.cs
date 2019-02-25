using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_RecuperarSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Email.EnviarEmail(txtEmail.Text, "Recuperação de senha", "Clique no Link abaixo para recuperar sua senha<br/><a href='google.com'><a/>");
    }
}