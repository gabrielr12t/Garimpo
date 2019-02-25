using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_ProdutosVenda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null)
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
        CarregarLabel();
    }
    private void CarregarLabel()
    {
        DataSet ds = ProdutoDB.SelectAllCPFProdutosAtivo(Session["cpf"].ToString());

        FotosDB db = new FotosDB();
        lblTable.Text = "";
        int aux = 1;
        bool flag = true;
        int cont = 1;
        bool stop = true;
        //verificando quantidade de paginas
        int totalPaginas = 0;
        int totalProdutos = ds.Tables[0].Rows.Count;


        if (totalProdutos % 4 != 0)
        {
            totalPaginas = (totalProdutos / 4) + 1;
        }
        else
        {
            totalPaginas = totalProdutos / 4;
        }//----------

        //imprimindo os numeros das paginas

        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            if (aux <= totalPaginas)
            {    
                ltlPagination.Text += @" <li><a href='/Paginas/Usuário/ProdutosVenda.aspx?npg="+aux+@"'>" + aux + @"</a></li>";
                aux++;
            }

           
            if (Request.QueryString["npg"] != null)
            {
                if ((Convert.ToInt32(Request.QueryString["npg"]) != 1))
                {
                    if (cont / (Convert.ToInt32(Request.QueryString["npg"]) - 1) == 4)
                    {
                       
                        lblTable.Text = "";
                        cont++;

                    }
                }
                
                if (cont > (Convert.ToInt32(Request.QueryString["npg"]) * 4))
                {
                    flag = false;
                }
            }
            else
            {
                if (cont % 5 == 0 && cont < totalProdutos)
                {
                    flag = false;
                    cont++;
                }
            }
           
            if (flag)
            {
                Foto foto = db.SelectFotoProduto(Convert.ToInt32(dr["pro_codigo"]));
                lblTable.Text += @"<tr>
                                    <td class='span2'>
                                        <a href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&cpf=" + Criptrografia.Criptografar(dr["usu_cpf_cnpj"].ToString()) + @"&sub=" + dr["sub_codigo"] + @"'><img src='" + foto.Fot_url + @"' style='width: 130px!important; height: 130px!important' /></a>
                                    </td>
                                    <td class='span7'>
                                        <strong>" + dr["pro_nome"] + @"</strong><br/>
                                        <strong>Quantidade:</strong> " + dr["pro_quantidade"] + @"<br/>
                                        <strong>Descrição:</strong>" + dr["pro_descricao"] + @"<br/>
                                        <strong>Valor do produto:</strong>R$" + dr["pro_preco"] + @"<br/>
                                        <strong>Status:</strong><a style='color:green!important'>" + dr["pro_status"] + @"</a><br>
                                        <strong>Situação de aprovação:</strong><a style = 'color:green!important' >" + dr["pro_moderacao_status"] + @"</a><br/>
                                    </td> 
                                    <td>
                                        <a class='validarProdutoVenda' href='#' rel='" + dr["pro_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='Desativar este produto'>
                                            <i class='icon-remove'></i>
                                        </a>
                                    </td>
                               </tr> ";
            }
            cont++;
        }
    }
    [System.Web.Services.WebMethod]
    public static string ValidaProdutos(string codigo)
    {
        if (ProdutoDB.Desativar(Convert.ToInt32(codigo)) == 0)
        {
            return "s";
        }
        else
            return "n";
    }
}