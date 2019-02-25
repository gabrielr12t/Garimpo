using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_Favoritos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null)
        {
            Response.Redirect("/Paginas/login.aspx");
        }
        if (!Page.IsPostBack)
        {
            carregarProduto();
        }
    }

    public void carregarProduto()
    {
        if (Session["cpf"] != null)
        {
            DataSet ds1 = FavoritarDB.SelectFavoritos(Session["cpf"].ToString());
        }
        DataSet ds = FavoritarDB.SelectFavoritos(Session["cpf"].ToString());
        ltlProdutos.Text = "";
        int cont = 0;
        int pg = 0;
        ltlPag.Text = "";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (cont == 0)
            {
                ltlPag.Text += @"<li><a href='#'>Ant</a></li><li>";
            }
            if (cont % 5 == 0)
            {
                ltlPag.Text += @"<!--<li class='active'><a href='#'>" + pg + @"</a></li>-->
                                 <li><a href='#'>" + pg + @"</a></li>";
                pg++;
            }
            ltlProdutos.Text += @"<tr>
                    <td>
                        <p>
                            <input type='checkbox' name='vehicle' value='Bike'>
						</p>
                    </td>
                    <td class='span3'><a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" +Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                         <img alt='' src='" + dr["foto"] + @"' class='img-carrinho' /></a></td>
                    <td>
					     <strong>" + dr["pro_nome"] + @"</strong><br />
				         <strong>" + dr["pro_descricao"] + @"</strong><br/>
						 <strong>" + dr["pro_condicao"] + @"</strong><br/>
                         <strong>R$:" + dr["pro_preco"] + @"</strong>					     
                    </td>
                    <td>
                         <a href='#' class='naofavoritar' id='" + dr["pro_codigo"] + @"' cpf='" + Session["cpf"].ToString() + @"'  data-toggle='tooltip' data-placement='bottom' title='Remover do favoritos'><i class='icon-remove'></i></a>
                    </td>
                </tr>";
            cont++;
        }
        ltlPag.Text += @"<li><a href='#'>Próx</a></li>";
    }

    [WebMethod]
    public static string ExcluirFavorito(string cpf, string codigo)
    {
        Favorito f = new Favorito();
        f.Usuario = new Usuario();
        f.Usuario.Usu_cpf_cnpj = cpf;
        f.Produto = new Produto();
        f.Produto.Pro_codigo = Convert.ToInt32(codigo);
        if (FavoritarDB.Delete(f) == 0)
        {
            return "s";
        }
        else
        {
            return "n";
        }

    }
}