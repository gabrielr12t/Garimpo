using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Paginas_Usuário_ProdutosDesativados : System.Web.UI.Page
{
    string r;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] != null)
        {
            CarregarLabel();
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
    }
    private void CarregarLabel()
    {
        DataSet ds = ProdutoDB.SelectAllCPFProdutosInativos(Session["cpf"].ToString());
        FotosDB db = new FotosDB();
        lblTable.Text = "";

        var url = "";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            //url = HttpUtility.UrlEncode(dr["pro_codigo"].ToString());

            Foto foto = db.SelectFotoProduto(Convert.ToInt32(dr["pro_codigo"]));
            lblTable.Text += @"<tr>
                                    <td class='span2'>
                                        <img src='" + foto.Fot_url + @"' style='width: 130px!important; height: 130px!important' />
                                    </td>
                                    <td class='span7'>
                                        <strong>" + dr["pro_nome"] + @"</strong><br/><strong>Quantidade:</strong> " + dr["pro_quantidade"] + @"<br/>
                                        <strong>Descrição:</strong>" + dr["pro_descricao"] + @"<br/>
                                        <strong>Valor do produto:</strong>R$" + dr["pro_preco"] + @"<br/>
                                        <strong>Status:</strong><a style='color:red!important'> " + dr["pro_status"] + @"</a><br>
                                        ";
            if (Convert.ToString(dr["pro_moderacao_status"]) == "Aprovado")
            {
                lblTable.Text += @"<strong>Situação de aprovação:</strong><a style='color:green!important'> " + dr["pro_moderacao_status"] + @"</a><br/>
                                    </td>
                                    <td>
                                        <a class='validarProdutoVenda' href='#' rel='" + dr["pro_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='Ativar este produto'><i class='icon-plus'></i></a>
                                    <td/>";
            }
            else
            {
                lblTable.Text += @"<strong>Situação de aprovação:</strong><a style='color:red!important'> " + dr["pro_moderacao_status"] + @"</a><br/>
                                    </td>
                                    <td>
                                        <a href='/Paginas/alterar/AlteracaoProduto.aspx?id=" + dr["pro_codigo"] + @"' rel='" + dr["pro_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='Editar este produto'><i class='icon-edit'></i></a></tr>
                                    </td>";
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static string Valida(string codigo)
    {
        if (ProdutoDB.Ativar(Convert.ToInt32(codigo)) == 0)
        {
            return "s";
        }
        else
            return "n";
    }
}