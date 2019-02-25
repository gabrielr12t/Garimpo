using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_ProdutosPendentes : System.Web.UI.Page
{
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
        DataSet ds = ProdutoDB.ProdutosNaoModerados(Session["cpf"].ToString());
        lblTable.Text = "";

        FotosDB db = new FotosDB();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            Foto foto = db.SelectFotoProduto(Convert.ToInt32(dr["pro_codigo"]));
            lblTable.Text += "<tr><td class='span2'><img src='" + foto.Fot_url + "' style='width: 130px!important; height: 130px!important' /></td><td class='span7'><strong>" + dr["pro_nome"] + "</strong><br/><strong>Quantidade:</strong> " + dr["pro_quantidade"] +
                "<br/><strong>Descrição:</strong>" + dr["pro_descricao"] + "<br/><strong>Valor do produto:</strong>R$" + dr["pro_preco"] + "<br/><strong>Status:</strong> " + dr["pro_status"] +
                "<br><strong>Situação de aprovação:</strong><a style='color:red'> " + dr["pro_moderacao_status"] + "</a><br/>" +
                "</td><td></tr> ";
        }

    }
}