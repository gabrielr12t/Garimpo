using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Produtos_GradeProdutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["est"] == null && (Request.QueryString["sub"] == null) && (Request.QueryString["cat"] == null))
        {
            Response.Redirect("/Paginas/Erros/Erro404.aspx");
        }
        if (!IsPostBack)
        {
            CarregarDDLMarca();
            CarregaProduto();
        }
    }
    public void CarregarDDLMarca()
    {
        //carregar DDLMarcas
        //Carregar um DropdownList com o banco de dados
        DataSet ds4 = MarcasDB.SelectAll();
        ddlMarca.DataSource = ds4;
        //nome da coluna do banco de dados;
        ddlMarca.DataTextField = "mar_nome";
        //ID da coluna do Banco
        ddlMarca.DataValueField = "mar_codigo";
        ddlMarca.DataBind();
        //ddlMarca.Items.Insert(0, "Selecione");
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
    public void CarregaProduto()
    {

        ltlRoupas.Text = "";
        ltlRoupas.Text += @"";

        DataSet ds = new DataSet();
        if (Request.QueryString["est"] != null)
        {
            ds = ProdutoDB.SelectProdutosByEstilos(Convert.ToInt32(Request.QueryString["est"].ToString()));
        }
        if (Request.QueryString["cat"] != null)
        {
            ds = ProdutoDB.SelectPrudutoByCategoria(Convert.ToInt32(Request.QueryString["cat"].ToString()));
        }
        if (Request.QueryString["sub"] != null)
        {
            ds = ProdutoDB.SelectPrudutoBySubcategoria(Convert.ToInt32(Request.QueryString["sub"].ToString()));
        }
        DataSet f = new DataSet();
        if (Session["cpf"] != null)
        {
            f = FavoritarDB.SelectCoracao(Session["cpf"].ToString());
        }
        string cpf = "", id = "", favCPF = "", favID = "";
        bool favoritou;

        //Preço
        if (Request.QueryString["pMin"] != null || Request.QueryString["pMax"] != null)
        {

            double min = Convert.ToDouble(Request.QueryString["pMin"]);
            double max = Convert.ToDouble(Request.QueryString["pMax"]);

            int pMin = (int)min;
            int pMax = (int)max;
            ds = ProdutoDB.SelectFiltroPreco((pMin), (pMax));
        }
        if (Request.QueryString["marca"] != null)
        {
            int cod = Convert.ToInt32(Request.QueryString["marca"]);
            ds = ProdutoDB.SelectFiltroMarca(cod);
        }
            foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ltlRoupas.Text += @"<li class='span3'>
                                            <div class='product-box'>
                                                <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                                    <img style='height:300px!important' src='" + dr["foto"] + @"' />
                                                </a>
                                                <a href='/Paginas/Produtos/Produto.aspx'>
                                                    <h4>" + dr["pro_nome"] + @"</h4>
                                                </a>
                                                <h6>Tamanho: " + dr["pro_medida"] + @"</h6>
                                                <div class='span2 center'>
                                                    <p class='price'>R$" + dr["pro_preco"] + @"</p>
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
                    ltlRoupas.Text += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaocheio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                }
                else
                {
                    ltlRoupas.Text += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
                }
            }
            else
            {
                ltlRoupas.Text += @"<a href='#' onclick='return false;'>
                                                <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                            </a>
                                        </div>
                                    </li>";
            }
        }

        //Padrão
        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
        //    ltlRoupas.Text += @"<li class='span3'>
        //                                    <div class='product-box'>
        //                                        <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
        //                                            <img style='height:300px!important' src='" + dr["foto"] + @"' />
        //                                        </a>
        //                                        <a href='/Paginas/Produtos/Produto.aspx'>
        //                                            <h4>" + dr["pro_nome"] + @"</h4>
        //                                        </a>
        //                                        <h6>Tamanho: " + dr["pro_medida"] + @"</h6>
        //                                        <div class='span2 center'>
        //                                            <p class='price'>R$" + dr["pro_preco"] + @"</p>
        //                                        </div>";
        //    //buscar favorito se usuario estiver logado

        //    if (Session["cpf"] != null)
        //    {
        //        cpf = ""; id = ""; favCPF = ""; favID = "";
        //        cpf = Session["cpf"].ToString();
        //        id = dr["pro_codigo"].ToString();
        //        favoritou = false;

        //        foreach (DataRow d in f.Tables[0].Rows)
        //        {
        //            favCPF = d["usu_cpf"].ToString();
        //            favID = d["pro_codigo"].ToString();
        //            if (cpf.Equals(favCPF) && id.Equals(favID))
        //            {
        //                favoritou = true;
        //            }
        //        }
        //        if (favoritou)
        //        {
        //            ltlRoupas.Text += @"<a href='#' onclick='return false;'>
        //                                        <i class='btnHeart coracaocheio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
        //                                    </a>
        //                                </div>
        //                            </li>";
        //        }
        //        else
        //        {
        //            ltlRoupas.Text += @"<a href='#' onclick='return false;'>
        //                                        <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
        //                                    </a>
        //                                </div>
        //                            </li>";
        //        }
        //    }
        //    else
        //    {
        //        ltlRoupas.Text += @"<a href='#' onclick='return false;'>
        //                                        <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
        //                                    </a>
        //                                </div>
        //                            </li>";
        //    }

        //}
    }

    protected void btnFiltar_Click(object sender, EventArgs e)
    {
        string url = Request.Url.ToString();
        string nova = "";
        bool flag = true;
        for (int i = 0; i < url.Length; i++)
        {
            if (url.Contains("pMax"))
            {
                flag = false;
                nova = url.Replace("&pMax", "&");                
            }
            if (url.Contains("pMin"))
            {
                flag = false;                
                nova = url.Replace("&pMin", "&");
            }
            if (url.Contains("marca"))
            {
                flag = false;
                nova = url.Replace("&marca", "&");
            }
        }
        if (flag)
        {
            Response.Redirect(url + "&pMin=" +  (txtPrecoInicial.Text) + "&pMax=" + (txtPrecoFinal.Text) + "");
        }
        else
        {
            Response.Redirect(nova + "&pMin=" + txtPrecoInicial.Text + "&pMax=" + txtPrecoFinal.Text + "");
        }
    }

    protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
    {
        string url = Request.Url.ToString();
        string nova = "";
        bool flag = true;
        for (int i = 0; i < url.Length; i++)
        {
            if (url.Contains("marca"))
            {
                flag = false;
                nova = url.Replace("&marca", "&");
               
            }
        }
        if (flag)
        {
            Response.Redirect(url + "&marca=" +ddlMarca.SelectedItem.Value);
        }
        else
        {
            Response.Redirect(nova + "&marca=" + ddlMarca.SelectedItem.Value);
        }
    }
}
