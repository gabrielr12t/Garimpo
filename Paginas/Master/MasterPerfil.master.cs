using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Master_MasterPerfil : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int n = 0;
        HttpCookie cookie = Request.Cookies["produtos"];
        if (cookie != null)
        {
            string ck = cookie.Value;

            for (int i = 0; i < ck.Length; i++)
            {
                if (ck.ElementAt(i) == '%')
                {
                    n++;
                }
            }
        }
        if (n != 0)
        {
            ltlCarrinho.Text = @"<li><a href='/Paginas/Carrinho.aspx' class='cart iconemenu'><span class='counter'>" + n + @"</span></a></li>";
        }
        else
        {
            ltlCarrinho.Text = @"<li><a href='/Paginas/Carrinho.aspx' class='cart iconemenu'><span ></span></a></li>";
        }
        // $("a.cart > span.counter").text(count);
        if (!IsPostBack)
        {
            CarregarMenu();
        }

        if (Session["cpf"] != null)
        {
            UsuarioDB db = new UsuarioDB();
            Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));
            //img.Visible = true;

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

            string fotoCaminho;
            if (usuario.Usu_foto_perfil != "")
            {
                fotoCaminho = usuario.Usu_foto_perfil;
            }
            else
            {
                fotoCaminho = "../../themes/images/FOTOPERFIL/este.gif";
            }         
            lblFoto.Text += "<img src='../../../" + fotoCaminho + @"'class='user meumenu' />";

            //img.ImageUrl = fotoCaminho;
            imgGrande.ImageUrl = fotoCaminho;
            btnSair.Visible = true;
            foto.Visible = true;
            lblNome.Text = usuario.Usu_nome;           
            lblCCadastro.Text = Convert.ToString(usuario.Usu_data_cadastro.ToShortDateString());
            //lblCCadastro.Text = Session["data_cadastro"].ToString();
            btnSair.Visible = true;
            lblTotalCompras.Text = Convert.ToString(usuario.Usu_qtdd_compras);
            lblTotalVendas.Text = Convert.ToString(usuario.Usu_qtdd_vendas);
            

            //DataSet ds = UsuarioDB.SelectAll();
            //Usuario u = new Usuario();

            //u.Usu_nome = ds.Tables[0].Rows[0]["usu_nome"].ToString();
            //u.Usu_cpf_cnpj = ds.Tables[0].Rows[0]["usu_cpf_cnpj"].ToString();
        }
        else
        {
            Response.Redirect("/Paginas/Erros/ErroLogin.aspx");
        }
    }

    public void CarregarMenu()
    {
        DataSet ds = EstiloDB.SelectEstiloCategoriaSub();
        lblMenus.Text = "";
        int cont = 0;
        string estilo = "", categoria = "", subcategoria = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (categoria != dr["cat_nome"].ToString() && cont != 0)
                lblMenus.Text += "</ul></li>";

            if (estilo != dr["est_nome"].ToString() && cont != 0)
                lblMenus.Text += "</ul></li>";

            if (estilo != dr["est_nome"].ToString())
            {
                lblMenus.Text += @"<li><a href='/Paginas/Produtos/GradeProdutos.aspx?est=" + dr["est_codigo"] + @"'>" + dr["est_nome"] + @"</a><ul>";

            }
            if (categoria != dr["cat_nome"].ToString())
            {
                lblMenus.Text += @"<li><a href='/Paginas/Produtos/GradeProdutos.aspx?cat=" + dr["cat_codigo"] + @"'>" + dr["cat_nome"].ToString() + @"</a><ul style='margin-left:23%'>";
            }

            lblMenus.Text += @"<li><a href='/Paginas/Produtos/GradeProdutos.aspx?sub=" + dr["sub_codigo"] + @"'>" + dr["sub_nome"].ToString() + @"</a></li>";

            cont++;
            categoria = dr["cat_nome"].ToString();
            estilo = dr["est_nome"].ToString();
            subcategoria = dr["sub_nome"].ToString();
        }
        lblMenus.Text += @"</ul></li></ul></li>";
    }
    protected void btnSair_Click(object sender, EventArgs e)
    {
        btnSair.Visible = false;
        foto.Visible = false;
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Session.Remove("cpf");
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.Redirect("/Paginas/Login.aspx");        
    }
}