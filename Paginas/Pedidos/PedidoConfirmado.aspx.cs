using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Pedidos_PedidoConfirmado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null)
        {
            Response.Redirect("/Paginas/Index.aspx");
        }
        else
        {
            UsuarioDB db = new UsuarioDB();
            Usuario u = db.Select(Session["cpf"].ToString());
            ltlEmail.Text = u.Usu_email;
        }
    }
}