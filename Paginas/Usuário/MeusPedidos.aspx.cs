using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Pedidos_MeusPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MinhasCompras();
        }
   }
    public void MinhasCompras()
    {
        ltlCompras.Text = "";
        DataSet ds = new DataSet();

        if (Session["cpf"] != null)
        {
            ds = CompraDB.SelectMinhasCompras(Session["cpf"].ToString());
        }
        else
        {
            Response.Redirect("/Paginas/Index.aspx");
        }
        DateTime data = new DateTime();
        TimeSpan entrega = new TimeSpan();
        bool flag = true;
        string mensagem = "Prazo vencido";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            flag = true;
            if (dr["ite_status"].ToString() != "3" && dr["ite_status"].ToString() != "4")
            {
                entrega = Convert.ToDateTime(dr["com_data"]).AddDays(12) - DateTime.Now;
                if (entrega.Days < 0)
                {
                    flag = false;
                }

                data = Convert.ToDateTime(dr["com_data"]);
                ltlCompras.Text += @"<tr>                                    
                                    <td><a href='#'>
                                        <img alt='' src='" + dr["foto"] + @"' class='img-carrinho' /></a></td>
                                    <td><strong>" + dr["pro_nome"] + @"</strong><br />
                                        <strong>Quantidade: " + dr["ite_quantidade"] + @"</strong><br/>
                                       <strong>Status:</strong>";
                if (dr["ite_status"].ToString() == "0")
                {
                    ltlCompras.Text += @"<a style='color:blue'> Em andamento</a>";
                    ltlCompras.Text += @"<p class='price'>R$" + String.Format("{0:0.00}", dr["pro_preco"]) + @"</p>";
                }
                if (dr["ite_status"].ToString() == "1")
                {
                    ltlCompras.Text += @"<a style='color:green'> Pagamento aprovado</a>";
                    ltlCompras.Text += @"<p class='price'>R$" + String.Format("{0:0.00}", dr["pro_preco"]) + @"</p>";
                }
                if (dr["ite_status"].ToString() == "2")
                {
                    ltlCompras.Text += @"<a style='color:green'> Produto a caminho</a><br/>";                   
                    ltlCompras.Text += @"<p class='price'>R$" + String.Format("{0:0.00}", dr["pro_preco"]) + @"</p>";
                    ltlCompras.Text += @"<a href='#' class='recebi' cod='"+dr["pro_codigo"]+@"' compra='"+dr["com_codigo"]+@"' style='color:green' data-toggle='tooltip' data-placement='bottom' title ='Clique somente se você já recebeu o produto'>Recebi o produto<i class='fa fa-home fa-2x'></i></a></td>";
                }

                ltlCompras.Text += @"<td>
                                        <strong>Compra efetuada em:</strong> " + data.ToShortDateString() + @"</br> 
                                       <strong> Prazo de entrega:</strong> 12 dias<br/><strong>";

                if (dr["ite_status"].ToString() != "3")
                {
                    if (flag)
                    {
                        if (entrega.Days >= 7)
                        {
                            ltlCompras.Text += @"Restam:</strong><strong style='color:green'> " + entrega.Days + @" dias</strong></br>";

                        }
                        if (entrega.Days < 7 && entrega.Days >= 4)
                        {
                            ltlCompras.Text += @"Restam:</strong><strong style='color:orange'> " + entrega.Days + @" dias</strong></br>";
                        }
                        if (entrega.Days < 4)
                        {
                            ltlCompras.Text += @"Restam:</strong><strong style='color:red'> " + entrega.Days + @" dias</strong></br>";
                        }
                    }
                    else
                    {
                        ltlCompras.Text += @"Restam:</strong><a style='color:red'> " + mensagem + @" </a></br>";
                        if ((dr["ite_avaliacao"]).ToString() == "0")
                        {
                            ltlCompras.Text += @"<td class='pull-right'><a href='/Paginas/Usuário/AvaliarVendedor.aspx'>Avaliar vendedor<i></i></a></td>";
                        }                        
                        else
                        {
                            ltlCompras.Text += @"<td class='pull-right'><a href='#'>Vendedor já foi avaliado<i></i></a></td>";
                        }                        
                    }
                }
                else
                {
                    ltlCompras.Text += @"<td class='pull-right'><a href='/Paginas/Usuário/AvaliarVendedor.aspx'>Avaliar Vendedor<i></i></a></td>";
                }
                if (dr["ite_status"].ToString() == "0")
                {
                    ltlCompras.Text += @"<td><a href='#' class='cancelar' cod='" + dr["pro_codigo"] + @"' compra='" + dr["com_codigo"] + @"' style='color:black' data-toggle='tooltip' data-placement='bottom' title ='Clique aqui para cancelar a compra'><i class='fa fa-remove fa-2x'></i></a></td>";
                  
                }
                ltlCompras.Text += @"</td>
                                </tr>";
            }
        }
    }

    [WebMethod]
    public static string ProdutoRecebido(string cod, string compra)
    {
        Item i = new Item();
        i.Ite_status = 3;
        i.Produto = new Produto();
        i.Produto.Pro_codigo = Convert.ToInt32(cod);
        i.Compra = new Compra();
        i.Compra.Com_codigo = Convert.ToInt32(compra);
        if (ItemDB.UpdatePagamentoFeito(i) == 0)
        {
            return "s";
        }
        else
        {
            return "n";
        }
    }
    [WebMethod]
    public static string Cancelamento(string cod, string compra)
    {
        Item i = new Item();
        i.Ite_status = 4;
        i.Produto = new Produto();
        i.Produto.Pro_codigo = Convert.ToInt32(cod);
        i.Compra = new Compra();
        i.Compra.Com_codigo = Convert.ToInt32(compra);
        if (ItemDB.UpdatePagamentoFeito(i) == 0)
        {
            return "s";
        }
        else
        {
            return "n";
        }
    }
}