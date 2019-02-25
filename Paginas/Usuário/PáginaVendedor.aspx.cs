using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_PáginaVendedor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            carregarUsuario();
            CarregaProdutos();
        }
    }

    public void carregarUsuario()
    {
        string id = Criptrografia.Descriptografar(Request.QueryString["cpf"]);
        Produto prod = ProdutoDB.Select(Convert.ToString(id));
        DataSet ds = ProdutoDB.SelectProdutoVendedor(id);
        int qtd = ds.Tables[0].Rows.Count;
        lblQuantidadeProdutosVenda.Text = Convert.ToString(qtd);
        Usuario user = UsuarioDB.SelectUsuario(Convert.ToString(id));
        if (qtd > 0)
        {
            string msg = "Sem reputação";
            bool flag = true;
            int rep = 0;
            int reps = 0;
            //calculo rep
            if (prod.Usuario.Usu_reputacao != 0)
            {
                DataSet dsR = ItemDB.SelectQuantidadeAvaliacoes(prod.Usuario.Usu_cpf_cnpj);
                 reps = dsR.Tables[0].Rows.Count;
                if (prod.Usuario.Usu_reputacao > 0)
                {
                    rep = Convert.ToInt32(prod.Usuario.Usu_reputacao / reps);
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

            lblVendedor.Text += @"<div class='row-fluid' id='secao'>
            <div class='span3' id='first'>                           
                <img class='fotoPerfilGrande' src='" + user.Usu_foto_perfil + @"' /></a>
            </div>
            <div class='span4' id='second'>
                <div class='fonte-estilo'>
                    Brechó do <strong class='roxo'>" + user.Usu_nome.ToUpper() + @"</strong><br />
                    " + user.CidadeEstado + @"
                </div>
            </div>
            <div class='span2' id='third'>";

            if (flag)
            {
                lblVendedor.Text += @"<span Class='rep-ven'>Reputação</span> <br/><div class='progress progress-striped active'>";
                if (rep >= 65)
                {
                    lblVendedor.Text += @"<div class='bar bar-success' style='width: " + rep + @"%; color:#11F075!important;'></div>";
                }
                if (rep >= 35 && rep < 65)
                {
                    lblVendedor.Text += @"<div class='bar bar-warning' style='width: " + rep + @"%;color:#'></div>";
                }
                if (rep > 0 && rep < 35)
                {
                    lblVendedor.Text += @"<div class='bar bar-danger' style='width: " + rep + @"%;color:#'></div>";
                }

                lblVendedor.Text += @"</div>";
                //lblvendedor.Text += @"<span Class='rep-ven'>Reputação: " + rep + @" </span>";
            }
            else
            {
                lblVendedor.Text += @"<span Class='rep-ven'>Reputação: " + msg + @" </span>";
            }

            lblVendedor.Text+=@"</div>
            <div class='span3' id='fourth'>
               <span class='rep-ven'>Total de Vendas: " + reps + @" </span>
            </div>
            <div class='span11'>
                <hr />
            </div>
        </div>";
        }
        else
        {
            lblVendedor.Text = "Não tem produto a venda";
        }
    }

    public void CarregaProdutos()
    {
        string cpf = Criptrografia.Descriptografar(Request.QueryString["cpf"]);
        DataSet ds = ProdutoDB.SelectProdutoVendedor(cpf);
        ltlProdutos.Text = "";


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ltlProdutos.Text += @"
                            <li class='span3'>
                                <div class='product-box'>
                                     <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                        <img style='height:300px!important' src='" + dr["foto"] + @"' />
                                    </a>
                                     <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'>
                                        <h4>" + dr["pro_nome"] + @"</h4>
                                    </a>
                                    <h6>Tamanho: " + dr["pro_medida"] + @"</h6>
                                    <div class='span2 center'>
                                        <p class='price'>R$" + dr["pro_preco"] + @"</p>
                                    </div>
                                    <a href='#' onclick='return false;'>
                                         <i class='btnHeart coracaovazio fa fa-heart fa-2x' cpf='" + Session["cpf"] + @"' cod='" + dr["pro_codigo"] + @"' rel='vazio'></i>
                                    </a>
                                </div>
                            </li>                       
                        ";
        }
    }
}