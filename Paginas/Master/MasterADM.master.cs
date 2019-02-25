using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Master_MasterADM : System.Web.UI.MasterPage
{
    private bool IsAdministrador(int tipo)
    {
        bool retorno = false;
        if (tipo == 1)
        {
            retorno = true;
        }
        return retorno;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioDB db = new UsuarioDB();
        Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));

        

        if (Session["cpf"] != null && (IsAdministrador(usuario.Tipo.Tip_codigo)))
        {
            DataSet ds = MensagemDB.SelectMensagemLida(Session["cpf"].ToString());
            int qtd = ds.Tables[0].Rows.Count;
            if (qtd > 0)
            {
                lblMensagens.Text = "<li><a href = '/Paginas/Usuário/CaixaMensagem.aspx'>" +
                   "<i class='fa fa-inbox iconemenu'><asp:Label ID = 'lblContaMensagens' runat='server'>" +
                   "<span class='badge badge-important'>" + qtd + "</span></asp:Label></i></a></li>";
                //lblMensagens.Text+="<li><a href = '/Paginas/Usuário/CaixaMensagem.aspx'>" +
                //   "<i class='fa fa-inbox iconemenu'><asp:Label ID = 'lblContaMensagens' runat='server'>" +
                //   "<span class='badge badge-important'>"+qtd+"</span></asp:Label></i>";
            }
            else
            {
                lblMensagens.Text = "<li><a href = '/Paginas/Usuário/CaixaMensagem.aspx'>" +
                  "<i class='fa fa-inbox iconemenu'><asp:Label ID = 'lblContaMensagens' runat='server'>" +
                  "<span class='badge badge-important'></span></asp:Label></i></a></li>";
            }

            lblNomeAdm.Visible = true;
            lblNomeAdm.Text = usuario.Usu_nome;
            lblNome.Text = usuario.Usu_nome;
            string fotoCaminho;
            if (usuario.Usu_foto_perfil != "")
            {
                fotoCaminho = usuario.Usu_foto_perfil;
            }
            else
            {
                fotoCaminho = "../../themes/images/FOTOPERFIL/este.gif";
            }

            //img.ImageUrl = fotoCaminho;
            lblFoto.Text = "<img src='../../../" + fotoCaminho + @"'class='user meumenu' />";
            fotoPerfilGrande.ImageUrl = fotoCaminho;
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
    }
    protected void btnSair_Click2(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Session.Remove("cpf");
        Session.Remove("perfil");
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("/Paginas/Login.aspx");
    }
}
