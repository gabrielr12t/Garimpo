using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Produtos_Produto : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Criptrografia.Descriptografar(Request.QueryString["cpf"]);

        string cpf = Criptrografia.Descriptografar(Request.QueryString["cpf"]);
        string id = Request.QueryString["id"];
        string sub = Request.QueryString["sub"];

        if (id == null)
        {
            Response.Redirect("/Paginas/Erros/Erro404.aspx");
        }

        ProdutoDB.ProdutosMaisAcessados(Convert.ToInt32(id));
        //Produto prod = ProdutoDB.Select(Convert.ToInt32(id));

        if (Session["cpf"] != null)
        {
            //inserir subcategoria para o usuario logado            
            Usuario u = new Usuario();
            u.Usu_cpf_cnpj = Session["cpf"].ToString();
            u.Subcategoria = new Subcategoria();
            u.Subcategoria.Sub_codigo = Convert.ToInt32(sub);
            UsuarioDB.updateSubCatAcessada(u);
            //-------------------------------------
            if (cpf.Equals(Session["cpf"].ToString()))
            {
                txtMensagem.Enabled = false;
                btnPergunta.Visible = false;
                txtMensagem.Text = "Você não pode perguntar no seu produto.".ToUpper();
            }
        }
        if (!IsPostBack)
        {
            carregarInformacao();
            Produtos();
            CarregaMensagem();
            ProdutosSimilares();
        }
    }

    public void carregarInformacao()
    {
        DataSet f = new DataSet();
        if (Session["cpf"] != null)
        {
            f = FavoritarDB.SelectCoracao(Session["cpf"].ToString());
        }
        string cpf = "", id = "", favCPF = "", favID = "";
        bool favoritou;


        string idProd = Request.QueryString["id"];
        Produto prod = ProdutoDB.SelectID(Convert.ToInt32(idProd));
        double p, pa, des;
        p = prod.Pro_preco;
        pa = prod.Pro_preco_antigo;
        des = Math.Round((100 - (p / pa) * 100), 2);
        if (id != " ")
        {
            string msg = "Sem reputação";
            bool flag = true;
            int rep = 0;
            int reps = 0;
            //calculo rep
            if (prod.Usuario.Usu_reputacao != 0)
            {
                //DataSet dsR = ItemDB.SelectQuantidadeAvaliacoes(prod.Usuario.Usu_cpf_cnpj);
                 //reps = dsR.Tables[0].Rows.Count;
                if (prod.Usuario.Usu_reputacao >0 )
                {
                    rep = Convert.ToInt32(prod.Usuario.Usu_reputacao / prod.Usuario.Usu_qtdd_vendas);
                }
                else
                {
                    rep = 1;
                }
                
            }
            else
            {
                flag = false;
            }
            lblCategorias.Text = @"<div class='span3 container-fluid'>
            <span>" + prod.Subcategoria.Categoria.Estilo.Est_nome + @"/</span>
            <span>" + prod.Subcategoria.Categoria.Cat_nome + @"/</span>
            <span>" + prod.Subcategoria.Sub_nome + @"</span>
            </div>";

            lblvendedor.Text = @" <div class='row-fluid' id='secao'>
            <div class='span3' id='first'>                
                <a href='/Paginas/Usuário/PáginaVendedor.aspx?cpf=" + Criptrografia.Criptografar(prod.Usuario.Usu_cpf_cnpj) + @"' class='fotoPerfilGrande' data-toggle='tooltip' data-placement='bottom' title='Clique na foto para acessar o perfil do vendedor'>
                    <img class='fotoPerfilGrande' src='" + prod.Usuario.Usu_foto_perfil + @"' /></a>
            </div>
            <div class='span4' id='second'>
                <div class='fonte-estilo'>
                    Brechó do <strong class='roxo'>" + prod.Usuario.Usu_nome + @"</strong><br />
                    " + prod.Usuario.CidadeEstado + @"
                </div>
            </div>
            <div class='span2' id='third'>";
            if (flag)
            {
                lblvendedor.Text += @"<span Class='rep-ven'>Reputação</span> <br/><div class='progress progress-striped active'>";
                if (rep >= 65)
                {
                    lblvendedor.Text += @"<div class='bar bar-success' style='width: " + rep + @"%; color:#11F075!important;'></div>";
                }
                if (rep >= 35 && rep < 65)
                {
                    lblvendedor.Text += @"<div class='bar bar-warning' style='width: " + rep + @"%;color:#'></div>";
                }
                if (rep > 0 && rep < 35)
                {
                    lblvendedor.Text += @"<div class='bar bar-danger' style='width: " + rep + @"%;color:#'></div>";
                }

                lblvendedor.Text += @"</div>";
                //lblvendedor.Text += @"<span Class='rep-ven'>Reputação: " + rep + @" </span>";
            }
            else
            {
                lblvendedor.Text += @"<span Class='rep-ven'>Reputação: " + msg + @" </span>";
            }
            lblvendedor.Text += @"</div>
            <div class='span3' id='fourth'>
                <span Class='rep-ven'>Total de Vendas: " + reps + @"
            </div>
            <div class='span11'>
                <hr />
            </div>
        </div>";

            lblInformacoes.Text = @"<div class='row'>
                <div class='span11'>
                    <div class='row'>
                        <div class='span4'>";
            DataSet ds = FotosDB.SelectByProduto(prod.Pro_codigo);
            int cont = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (cont == 0)
                {
                    lblInformacoes.Text += @"<a href='" + dr["fot_url"] + @"' class='thumbnail' data-fancybox-group='group1' title='Foto " + (cont + 1) + @"'>
                                <img alt='' src='" + dr["fot_url"] + @"' /></a>
                            <ul class='thumbnails small'>";
                }
                else
                {
                    lblInformacoes.Text += @"<li class='span1'>
                                    <a href='" + dr["fot_url"] + @"' class='thumbnail' data-fancybox-group='group1' title='Foto " + (cont + 1) + @"'>
                                        <img src='" + dr["fot_url"] + @"' alt='' /></a>
                                    </li>";
                }
                cont++;
            }
            lblInformacoes.Text += @" </ul></div>
                        <div class='span7'>
                            <address>
                                <span class='roxo'>" + prod.Pro_nome + @"</span><br />
                                <span class='marg'>Tamanho: " + prod.Pro_medida + @"</span>
                                <span class='marg'>Marca: " + prod.Marca.Mar_nome + @"</span>
                                <span class='marg'>Condição: " + prod.Pro_condicao + @"</span>
                                <span>Disponível: " + prod.Pro_quantidade + @"</span>";
            //
            if (Session["cpf"] != null)
            {
                cpf = ""; id = ""; favCPF = ""; favID = "";
                cpf = Session["cpf"].ToString();
                id = Convert.ToString(prod.Pro_codigo);
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
                    lblInformacoes.Text += @"<span><a href='#' onclick='return false;'>
                                        <i class='btnHeart coracaocheio fa fa-heart fa-2x pull-right' cpf='" + Session["cpf"] + @"' cod='" + prod.Pro_codigo + @"' rel='vazio'></i>
                                      </a>
                                    </span>";
                }
                else
                {
                    lblInformacoes.Text += @"<span><a href='#' onclick='return false;'>
                                        <i class='btnHeart coracaovazio fa fa-heart fa-2x pull-right' cpf='" + Session["cpf"] + @"' cod='" + prod.Pro_codigo + @"' rel='vazio'></i>
                                      </a>
                                    </span>";
                }
            }
            else
            {
                lblInformacoes.Text += @"<span><a href='#' onclick='return false;'>
                                        <i class='btnHeart coracaovazio fa fa-heart fa-2x pull-right' cpf='" + Session["cpf"] + @"' cod='" + prod.Pro_codigo + @"' rel='vazio'></i>
                                      </a>
                                    </span>";
            }
            //

            lblInformacoes.Text += @" <br />
                                <hr /> 
                                <div class='span7'>
                                    <p class='descricao'>
                                        " + prod.Pro_descricao + @"                                        
                                    </p>
                                    <hr />
                                </div>
                               
                               <br/>
                                <div class='span3'>                                    
                                    <!--<a href='#'><i class='fa fa-shopping-cart iconemenu marg'></i></a>-->";
            if (p < pa)
            {
                lblInformacoes.Text += @"<span class='preço' style='opacity:0.7;'><strike> R$" + String.Format("{0:0.00}", prod.Pro_preco_antigo) + @"</strike></span> (" + des + @"% de desconto)<br/><span class='preço'>R$ " + String.Format("{0:0.00}", prod.Pro_preco) + @"</span>                        
                                </div>";
            }
            else
            {
                lblInformacoes.Text += @"<span class='preço'>R$ " + String.Format("{0:0.00}", prod.Pro_preco) + @"</span><br>                   
                                </div>";
            }
            lblInformacoes.Text += @"<a href='/Paginas/Carrinho.aspx' class='add-to-cart comprar' rel='" + prod.Pro_codigo + @"'>Comprar</a>
                                <!--<input Type='button' Value='Comprar' class='i2Style i2Style:active botao-publicar comprar' Onclick='window.location.href='/Paginas/Carrinho.aspx?id=" + prod.Pro_codigo + @"''>-->
                                <!--<input type='button' name='btnComprar' onclick='Redirecionar()' rel='" + prod.Pro_codigo + @"' class='redirecionar i2Style i2Style:active botao-publicar comprar' value='COMPRAR'>-->
								<br/><br/>
                               <div class='span5'>
                                <a href='#' class='frete'><u>Calcular Frete</u></a>
                                </div>                                                                                                  
                            </address>
                        </div>
                    </div>
                </div>
            </div>";
        }
        else
        {
            Response.Redirect("/Paginas/Index.aspx");
        }
        lblDenunciar.Text = "";
        lblDenunciar.Text = @"<a href='/Paginas/Usuário/Denuncia.aspx?id=" + prod.Pro_codigo + @"'><u>Denunciar</u></a>";
    }
    //favoritar
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
    //--------

    //carregar perguntas
    public void CarregaMensagem()
    {
        string id = Request.QueryString["id"];
        DataSet ds = MensagemDB.SelectMensagemProduto(Convert.ToInt32(id));

        int qtd = ds.Tables[0].Rows.Count;
        lblMensagem.Text = "";
        lblMinhaPergunta.Text = "";
        string perguntaCodigo = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            perguntaCodigo = "";
            if (qtd > 0)
            {
                if (dr["men_cpf_pergunta"].ToString() != "")
                {
                    if (Session["cpf"] != null)
                    {
                        if (Session["cpf"].ToString().Equals(dr["men_cpf_pergunta"].ToString()))
                        {
                            lblSuaPergunta.Text = @"<h4>Sua pergunta</h4>";
                            perguntaCodigo = dr["men_pergunta_codigo"].ToString();
                            lblMinhaPergunta.Text += @"<div class='containerNOVO'>
														<img src='" + dr["fotoComprador"] + @"' alt='Avatar' style='width: 100%;height:60px!important;' />
														<p> " + dr["men_conteudo"] + @"</p>
														<span class='time-right'>" + dr["men_data"] + @"</span>
												</div>";

                            foreach (DataRow dr1 in ds.Tables[0].Rows)
                            {
                                if ((dr1["men_pergunta_codigo"].ToString() == perguntaCodigo) && (dr1["men_cpf_pergunta"].ToString() == ""))
                                {
                                    perguntaCodigo = dr["men_pergunta_codigo"].ToString();
                                    lblMinhaPergunta.Text += @"<div class='containerNOVO darker'>
														<img src='" + dr["fotoVendedor"] + @"' class='right' alt='Avatar' style='width: 100%;height:60px!important;' />
														<p class='testecor'>" + dr1["men_conteudo"] + @"</p>
														<span class='time-left'>" + dr1["men_data"] + @"</span>
												</div><hr/>";
                                }
                            }
                        }
                        else
                        {
                            if (Session["cpf"].ToString().Equals(dr["usu_cpf_cnpj"]) && (dr["men_respondida"].ToString() == ""))
                            {
                                perguntaCodigo = dr["men_pergunta_codigo"].ToString();
                                lblMensagem.Text += @"<div class='containerNOVO'>
														<img src='" + dr["fotoComprador"] + @"' alt='Avatar' style='width: 100%;height:60px!important;' />
														</strong><p>" + dr["men_conteudo"] + @"<a href='#'  onclick='return false;' class='RespostaVendedor pull-right' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + dr["usu_cpf_cnpj"] + "|" + dr["men_cpf_pergunta"] + "|" + dr["men_pergunta_codigo"] + "|" + dr["pro_codigo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Responder Pergunta' ><i class='fa fa-pencil'></i></a></p>
														<span class='time-right'>" + dr["men_data"] + @"</span>
													</div>";
                            }
                            else
                            {
                                perguntaCodigo = dr["men_pergunta_codigo"].ToString();
                                lblMensagem.Text += @"<div class='containerNOVO'>
														<img src='" + dr["fotoComprador"] + @"' alt='Avatar' style='width: 100%;height:60px!important;' />
														<p> " + dr["men_conteudo"] + @"</p>
														<span class='time-right'>" + dr["men_data"] + @"</span>
												</div>";
                            }
                        }
                    }
                    else
                    {
                        perguntaCodigo = dr["men_pergunta_codigo"].ToString();
                        lblMensagem.Text += @"<div class='containerNOVO'>
													<img src='" + dr["fotoComprador"] + @"'	 alt='Avatar' style='width: 100%;height:60px!important;' />
													<p> " + dr["men_conteudo"] + @"</p>
													<span class='time-right'>" + dr["men_data"] + @"</span>
											</div>";
                    }
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        if ((dr1["men_pergunta_codigo"].ToString() == perguntaCodigo) && (dr1["men_cpf_pergunta"].ToString() == ""))
                        {
                            if (Session["cpf"] == null)
                            {
                                lblMensagem.Text += @"<div class='containerNOVO darker'>
														<img src='" + dr["fotoVendedor"] + @"' class='right' alt='Avatar' style='width: 100%;height:60px!important;' />
														<p class='testecor'>" + dr1["men_conteudo"] + @"</p>
														<span class='time-left'>" + dr1["men_data"] + @"</span>
												</div><hr/>";
                            }
                            else
                            {
                                if (Session["cpf"].ToString() != (dr["men_cpf_pergunta"].ToString()))
                                {
                                    lblMensagem.Text += @"<div class='containerNOVO darker'>
														<img src='" + dr["fotoVendedor"] + @"' class='right' alt='Avatar' style='width: 100%;height:60px!important;' />
														<p class='testecor'>" + dr1["men_conteudo"] + @"</p>
														<span class='time-left'>" + dr1["men_data"] + @"</span>
												</div><hr/>";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void ProdutosSimilares()
    {
        string sub = Request.QueryString["sub"];
        DataSet ds = ProdutoDB.selectProdutosInteressados(Convert.ToInt32(sub));

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
            ltlProdutosSimilares.Text = div;
        }
    }
    //carregar produtos do vendedor
    public void Produtos()
    {
        string cpfP = Criptrografia.Descriptografar(Request.QueryString["cpf"]);
        DataSet ds = ProdutoDB.SelectProdutoVendedor(cpfP);

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
            ltlProdutosVendedor.Text = div;
        }
    }

    protected void Publicar()
    {
        if (Session["cpf"] != null)
        {
            Response.Redirect("/Paginas/Pedidos/GeracaoPedido.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "NaoLogado();", true);
        }
    }

    protected void btnPergunta_Click(object sender, EventArgs e)
    {
        if (Session["cpf"] != null)
        {
            string id = Request.QueryString["id"];
            Produto prod = ProdutoDB.SelectID(Convert.ToInt32(id));
            string nome = prod.Usuario.Usu_cpf_cnpj;
            Mensagem m = new Mensagem();
            m.Men_conteudo = txtMensagem.Text;
            m.Men_data = DateTime.Now;
            m.Men_lida = false;
            m.Usuario = new Usuario();
            m.Usuario.Usu_cpf_cnpj = prod.Usuario.Usu_cpf_cnpj;
            m.Produto = new Produto();
            m.Produto.Pro_codigo = Convert.ToInt32(id);
            m.Tipo = new Tme_tipo_mensagem();
            m.Tipo.Tme_codigo = 2;
            m.Men_pergunta_codigo = DateTime.Now.ToString("ddMMyyyymmssfff");
            m.Men_cpf_pergunta = Session["cpf"].ToString();
            if (MensagemDB.InsertMensagemParaVendedor(m) == 0)
            {
                txtMensagem.Text = "";
                CarregaMensagem();
            }
        }
        else
        {
            txtMensagem.Text = "";
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "NaoLogado();", true);
        }
    }
    protected void btnResposta_Click(object sender, EventArgs e)
    {
        Mensagem m = new Mensagem();
        m.Men_conteudo = txtResposta.Text;
        m.Men_data = DateTime.Now;
        m.Men_lida = false;
        m.Usuario = new Usuario();
        m.Usuario.Usu_cpf_cnpj = txtCpfPergunta.Value;
        m.Produto = new Produto();
        m.Produto.Pro_codigo = Convert.ToInt32(txtCodigoProduto.Value);
        m.Tipo = new Tme_tipo_mensagem();
        m.Tipo.Tme_codigo = 3;
        m.Men_pergunta_codigo = txtPerguntaCodigo.Value;

        if (MensagemDB.InsertMensagemParaComprador(m) == 0)
        {
            txtResposta.Text = "";
            Mensagem m1 = new Mensagem();
            m1.Men_codigo = Convert.ToInt32(txtCodigo.Value);
            m1.Men_respondida = true;
            MensagemDB.MensagemRespondida(m1);
            CarregaMensagem();
        }
    }
}