using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_HistoricoVenda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null)
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            Vendas();
        }
    }

    public void Vendas()
    {
        ltlVendas.Text = "";
        DataSet ds = new DataSet();

        if (Session["cpf"] != null)
        {
            ds = ProdutoDB.SelectAll(Session["cpf"].ToString());
        }
        DateTime data = new DateTime();
        TimeSpan entrega = new TimeSpan();
        bool flag = true;
        string mensagem = "Prazo vencido";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            entrega = Convert.ToDateTime(dr["com_data"]).AddDays(12) - DateTime.Now;
            if (entrega.Days < 0)
            {
                flag = false;
            }
            ltlVendas.Text += @"<tr>
                                    <td class='span3'><a href='#'>
                                        <img alt='' src='" + dr["foto"] + @"' class='img-carrinho' /></a></td>
                                    <td><strong>" + dr["pro_nome"] + @"</strong><br />
                                        Data Venda: " + Convert.ToDateTime(dr["com_data"]).ToShortDateString() + @" <br />                                                            
                                        Valor da venda: R$" + String.Format("{0:0.00}", dr["pro_preco"]) + @"<br/>
                                        Quantidade vendida: " + dr["ite_quantidade"] + @"<br/>";
            if (dr["ite_status"].ToString() == "0")
            {
                if (entrega.Days > 0)
                {
                    if (entrega.Days >= 7)
                    {
                        ltlVendas.Text += @"Situação:<a style='color:blue'> Em andamento </a><br/><strong>Prazo para enviar: </strong><strong style='color:green'> " + entrega.Days + @" dias</strong> <td><a href='#' class='pagamentoRecebido'  cod='" + dr["pro_codigo"] + @"' compra='" + dr["com_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Pagamento recebido'><i class='fa fa-money fa-2x' style='color:green'></i><a/></td>";
                    }
                    if (entrega.Days < 7 && entrega.Days >= 4)
                    {
                        ltlVendas.Text += @"Situação:<a style='color:blue'> Em andamento </a><br/><strong>Prazo para enviar: </strong><strong style='color:orange'> " + entrega.Days + @" dias</strong> <td><a href='#' class='pagamentoRecebido'  cod='" + dr["pro_codigo"] + @"' compra='" + dr["com_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Pagamento recebido'><i class='fa fa-money fa-2x' style='color:green'></i><a/></td>";
                    }
                    if (entrega.Days < 4)
                    {
                        ltlVendas.Text += @"Situação:<a style='color:blue'> Em andamento </a><br/><strong>Prazo para enviar: </strong><strong style='color:red'> " + entrega.Days + @" dias</strong> <td><a href='#' class='pagamentoRecebido'  cod='" + dr["pro_codigo"] + @"' compra='" + dr["com_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Pagamento recebido'><i class='fa fa-money fa-2x' style='color:green'></i><a/></td>";
                    }
                }
                else
                {
                    ItemDB.UpdateCancelar(Convert.ToInt32(dr["com_codigo"]),Convert.ToInt32(dr["pro_codigo"]));
                    ltlVendas.Text += @"Situação:<a style='color:blue'> Em andamento </a><br/><strong style='color:red'>Prazo para enviar: Prazo vencido </strong><td><a href='#' class='pagamentoRecebido'  cod='" + dr["pro_codigo"] + @"' compra='" + dr["com_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Pagamento recebido'><i class='fa fa-money fa-2x' style='color:green'></i><a/></td>";
                }
            }
            if (dr["ite_status"].ToString() == "1")
            {
                ltlVendas.Text += @"Situação:<a style='color:green'> Pagamento Aprovado</a><td><a href='#' class='ProdutoEnviado'  cod='" + dr["pro_codigo"] + @"' compra='" + dr["com_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Enviei produto'><i class='fa fa-truck fa-2x' style='color:green'></i><a/></td>";
            }
            if (dr["ite_status"].ToString() == "2")
            {
                ltlVendas.Text += @"Situação:<a style='color:green'> Produto enviado</a><td><a href='#' data-toggle='tooltip' data-placement='bottom' title ='Você já enviou o produto, aguarde até a resposta do comprador'><i class='fa fa-spinner fa-2x' style='color:green'></i><a/></td>";
            }
            if (dr["ite_status"].ToString() == "3")
            {
                ltlVendas.Text += @"Situação:<a style='color:green'> Finalizada</a><td><a href='#' data-toggle='tooltip' data-placement='bottom' title ='Venda finalizada'><i class='fa fa-home fa-2x' style='color:green'></i><a/></td>";
            }
            if (dr["ite_status"].ToString() == "4")
            {
                ltlVendas.Text += @"Situação:<a style='color:red'> Cancelada</a><td><a href='#' data-toggle='tooltip' data-placement='bottom' title ='Venda cancelada'><i class='fa fa-remove fa-2x' style='color:green'></i><a/></td>";
            }
            ltlVendas.Text += @" </td><td>Entrega:<br/><strong>Cep: "+dr["end_cep"]+ @"</strong><br/><strong>Endereço: "+dr["end_endereco"]+@"</strong><br/><strong>Número: "+dr["end_numero"]+@"</strong></td>
                                </tr>";
        }
    }
    [WebMethod]
    public static string PagementoFeito(string cod, string compra)
    {
        Item i = new Item();
        i.Ite_status = 1;
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
    public static string ProdutoEnviadoJa(string cod, string compra)
    {
        Item i = new Item();
        i.Ite_status = 2;
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
    //ProdutoEnviadoJa
}