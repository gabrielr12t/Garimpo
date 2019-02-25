using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Produtos_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ProdutosMaisPesquisados();
            ProdutosDeSeuInteresse();
            CarregaPromocao();
        }
    }

    public void ProdutosMaisPesquisados()
    {
        DataSet ds = ProdutoDB.SelectAllAcesso();

        DataSet f = new DataSet();
        if (Session["cpf"] != null)
        {
            f = FavoritarDB.SelectCoracao(Session["cpf"].ToString());
        }
        string cpf = "", id = "", favCPF = "", favID = "";
        bool favoritou;

        int qnt = ds.Tables[0].Rows.Count;
        if (qnt > 0)
        {
            int cont = 0;
            bool flag = false;
            string div = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (cont % 4 == 0)
                {
                    if (flag == false)
                    {
                        div += @"<div class='item active'><ul class='thumbnails'> ";
                        flag = true;
                    }
                    else
                    {
                        div += @"</ul></div><div class='item'><ul class='thumbnails'> ";
                    }
                }
                div += @"<li class='span3'>
                                            <div class='product-box' >                                                
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"].ToString() + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                                    <img style='height:300px!important' src='" + dr["foto"] + @"' />
                                                </a>
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                                    <h4>" + dr["pro_nome"] + @"</h4>
                                                </a>
                                                <h6>Tamanho: " + dr["pro_medida"] + @"</h6>
                                                <div class='span2 center'>
                                                    <p class='price'>R$" + String.Format("{0:0.00}", dr["pro_preco"])  + @"</p>
                                                </div>";
                //buscar favorito se usuario estiver logado
                if (Session["cpf"] != null)
                {
                    cpf = ""; id = ""; favCPF = ""; favID = "";
                    cpf = Session["cpf"].ToString();
                    id = dr["pro_codigo"].ToString();
                    favoritou = false;

                    foreach (DataRow d in f.Tables[0].Rows)
                    {
                        favCPF = d["usu_cpf"].ToString();
                        favID = d["pro_codigo"].ToString();
                        if (cpf.Equals(favCPF) && id.Equals(favID))
                        {
                            favoritou = true;
                        }
                    }
                    if (favoritou)
                    {
                        div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaocheio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                    }
                    else
                    {
                        div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                    }
                }
                else
                {
                    div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                }
                cont++;
            }
            div += "</ul></div>";
            ltlMaisPesquisados.Text = div;
        }
    }

    public void CarregaPromocao()
    {
        DataSet f = new DataSet();
        if (Session["cpf"] != null)
        {
            f = FavoritarDB.SelectCoracao(Session["cpf"].ToString());
        }
        string cpf = "", id = "", favCPF = "", favID = "";
        bool favoritou;
        DataSet ds = ProdutoDB.SelectAllAcesso();

        int qnt = ds.Tables[0].Rows.Count;
        if (qnt > 0)
        {
            double p = 0, pa = 0, des = 0;
            int cont = 0;
            bool flag = false;
            string div = "";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                p = Convert.ToDouble(dr["pro_preco"]);
                pa = Convert.ToDouble(dr["pro_preco_antigo"]);
                des = Math.Round((100 - (p / pa) * 100), 2);
                if (p < pa)
                {
                    if (cont % 4 == 0)
                    {
                        if (flag == false)
                        {
                            div += @"<div class='item active'><ul class='thumbnails'> ";
                            flag = true;
                        }
                        else
                        {
                            div += @"</ul></div><div class='item'><ul class='thumbnails'> ";
                        }
                    }
                }
                if (p < pa)
                {
                    div += @"<li class='span3'>
                                            <div class='product-box' >
                                                <div class='ribbon'><span>-" + des + @"%</span></div>
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                                    <img style='height:300px!important' src='" + dr["foto"] + @"' />
                                                </a>
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"&sub=" + dr["sub_codigo"] + @"'>
                                                    <h4>" + dr["pro_nome"] + @"</h4>
                                                </a>
                                                <h6>Tamanho: " + dr["pro_medida"] + @"</h6>
                                                <div class='span2 center'>
                                                    <p class='price'>R$" + String.Format("{0:0.00}", dr["pro_preco"]) + @"</p>
                                                </div>";
                    //buscar favorito se usuario estiver logado
                    if (Session["cpf"] != null)
                    {
                        cpf = ""; id = ""; favCPF = ""; favID = "";
                        cpf = Session["cpf"].ToString();
                        id = dr["pro_codigo"].ToString();
                        favoritou = false;

                        foreach (DataRow d in f.Tables[0].Rows)
                        {
                            favCPF = d["usu_cpf"].ToString();
                            favID = d["pro_codigo"].ToString();
                            if (cpf.Equals(favCPF) && id.Equals(favID))
                            {
                                favoritou = true;
                            }
                        }
                        if (favoritou)
                        {
                            div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaocheio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                        }
                        else
                        {
                            div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                        }
                    }
                    else
                    {
                        div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                    }
                    cont++;
                }
            }
            div += "</ul></div>";
            ltlPromocao.Text = div;
        }
    }
    public void ProdutosDeSeuInteresse()
    {
        DataSet ds = new DataSet();

        DataSet f = new DataSet();
        string cpf = "", id = "", favCPF = "", favID = "";
        bool favoritou;
        int qnt = 0;
        if (Session["cpf"] != null)
        {
            f = FavoritarDB.SelectCoracao(Session["cpf"].ToString());
            lblFrase.Text = "<span class='pull-left'><span class='text'><span class='line'>Pode ser do seu <strong><u>interesse</u></strong></span></span></span>";
            UsuarioDB db = new UsuarioDB();
            Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));
            if (usuario.Subcategoria.Sub_codigo != 0)
            {
                ds = ProdutoDB.selectProdutosInteressados(Convert.ToInt32(usuario.Subcategoria.Sub_codigo));
                qnt = ds.Tables[0].Rows.Count;
            }
        }
        else
        {
            Random rdn = new Random();
            int numeroAleatorio = rdn.Next(18, 73);
            ds = ProdutoDB.SelectAleatorioSubcategoria(numeroAleatorio);
            qnt = ds.Tables[0].Rows.Count;
            lblFrase.Text = "<span class='pull-left'><span class='text'><span class='line'>Outros <strong><u>Produtos</u></strong></span></span></span>";

        }
        if (qnt > 0)
        {
            string fav = "";
            int cont = 0;
            bool flag = false;
            string div = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (cont % 4 == 0)
                {
                    if (flag == false)
                    {
                        div += @"<div class='item active'><ul class='thumbnails'> ";
                        flag = true;
                    }
                    else
                    {
                        div += @"</ul></div><div class='item'><ul class='thumbnails'> ";

                    }
                }
                div += @"<li class='span3' >
                                            <div class='product-box'>
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                                     <img style='height:300px!important' src='" + dr["foto"] + @"' />
                                                </a>
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                                    <h4>" + dr["pro_nome"] + @"</h4>
                                                </a>
                                                <h6>Tamanho: " + dr["pro_medida"] + @"</h6>
                                                <div class='span2 center'>
                                                    <p class='price'>R$" + String.Format("{0:0.00}", dr["pro_preco"]) + @"</p>
                                                </div>";
                if (Session["cpf"] != null)
                {
                    cpf = ""; id = ""; favCPF = ""; favID = "";
                    cpf = Session["cpf"].ToString();
                    id = dr["pro_codigo"].ToString();
                    favoritou = false;

                    foreach (DataRow d in f.Tables[0].Rows)
                    {
                        favCPF = d["usu_cpf"].ToString();
                        favID = d["pro_codigo"].ToString();
                        if (cpf.Equals(favCPF) && id.Equals(favID))
                        {
                            favoritou = true;
                        }
                    }
                    if (favoritou)
                    {
                        div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaocheio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                    }
                    else
                    {
                        div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                    }
                }
                else
                {
                    div += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                }
                cont++;
            }
            div += "</ul></div>";
            ltlSeuInteresse.Text = div;
        }
    }

    [WebMethod]
    public static void Favoritou(string logado, string codProduto)
    {
        Favorito f = new Favorito();
        f.Usuario = new Usuario();
        f.Usuario.Usu_cpf_cnpj = logado;
        f.Produto = new Produto();
        f.Produto.Pro_codigo = Convert.ToInt32(codProduto);
        FavoritarDB.Insert(f);
    }

    [WebMethod]
    public static void NaoFavoritou(string logado, string codProduto)
    {
        Favorito f = new Favorito();
        f.Usuario = new Usuario();
        f.Usuario.Usu_cpf_cnpj = logado;
        f.Produto = new Produto();
        f.Produto.Pro_codigo = Convert.ToInt32(codProduto);
        FavoritarDB.Delete(f);
    }
}