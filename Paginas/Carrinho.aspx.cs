using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Carrinho : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Carrinho();
        }
    }

    double subtotal = 0.0;
    static double total = 0.0;
    public void Carrinho()
    {

        HttpCookie cookie = Request.Cookies["produtos"];
        if (cookie != null)
        {
            if (!String.IsNullOrEmpty(cookie.Value))
            {
                string ck = "";
                ck = cookie.Value;

                string codProdutos = ck.Replace("%3B", ";");
                string[] prod = codProdutos.Split(';');
                string prods = "";

                if (codProdutos.Contains(";"))
                {
                    foreach (string p in prod)
                    {
                        if (p != "")
                            prods += p + ",";
                    }
                    prods = prods.Substring(0, prods.Length - 1);
                }
                else
                {
                    if (codProdutos != "")
                        prods = codProdutos;
                }
                DataSet ds = ProdutoDB.SelectAllAcesso(prods);
                total = 0.0;
                ltlCarrinho.Text = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    subtotal += (double)dr["pro_preco"];
                    ltlCarrinho.Text += @"<div class='product'>
                                            <div class='product-id' style='display:none;'>
                                                " + dr["pro_codigo"] + @"
                                            </div>   
                                            <div class='cpf-vendedor' style='display:none;'>
                                                " + dr["usu_cpf_cnpj"] + @"
                                            </div>   
                                            <div class='product-image'>
                                                <img src='" + dr["foto"] + @"'/>
                                            </div>
                                            <div class='product-details'>
                                                <div class='product-title'>" + dr["pro_nome"] + @"</div>
                                                <p class='product-description'>" + dr["pro_descricao"] + @"</p>
                                            </div>
                                            <div class='product-price'>" + dr["pro_preco"] + @"</div>
                                            <div class='product-quantity'>
                                                <input class='varrerQnt' type='number' rel='q" + dr["pro_codigo"] + @"' value='1' max='" + dr["pro_quantidade"] + @"' min='1'/>
                                            </div>
                                            <div class='product-removal'>
                                                <a href='#' class='remove-product' rel='" + dr["pro_codigo"] + @"'>
                                                    Remover
                                                </a>
                                            </div>
                                            <div class='product-line-price'>" + dr["pro_preco"] + @"</div>
                                        </div>";
                }

                double taxa = (subtotal * 0.05);

                total += subtotal + taxa + 15;
                ltlTotal.Text = "";
                ltlTotal.Text = @"<div class='totals'>
                                    <div class='totals-item'>
                                        <label>Subtotal</label>
                                        <div class='totals-value' id='cart-subtotal'>" + String.Format("{0:0.00}", subtotal) + @"</div>
                                    </div>
                                    <div class='totals-item'>
                                        <label>Taxa (5%)</label>
                                        <div class='totals-value' id='cart-tax'>" + String.Format("{0:0.00}", taxa) + @"</div>
                                    </div>
                                    <div class='totals-item'>
                                        <label>Frete</label>
                                        <div class='totals-value' id='cart-shipping'>15,00</div>
                                    </div>
                                    <div class='totals-item totals-item-total'>
                                        <label> Total</label>
                                    <div class='totals-value' id='cart-total'>" + String.Format("{0:0.00}", total) + @"</div>
                                    </div>
                                </div>";
            }
        }
    }

    //[WebMethod]
    //public static string Finalizar(string [] cod, string [] qtde)
    //{        

    //    return "s";
    //}
    protected void btnCalcularFrete_Click(object sender, EventArgs e)
    {

    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["produtos"];
        if (cookie != null)
        {
            string ck = cookie.Value;
            string codProdutos = ck.Replace("%3B", ";");
            Session["carrinho"] = codProdutos;
            Session["total"] = Convert.ToString(total);
            Response.Redirect("/Paginas/Pedidos/GeracaoPedido.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Carrinho vazio','info')", true);
        }
    }
}