using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_VisualizarProduto : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Convert.ToInt32(Session["tipo"]) == 1)
        {
            int  id = Convert.ToInt32(Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                buscaProduto();
            }            
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
    }

    public void buscaProduto()
    {        
        int id = Convert.ToInt32(Request.QueryString["id"]);
        DataSet ds = ProdutoDB.SelectVisualizarProduto(id);
        txtNome.Text = ds.Tables[0].Rows[0]["pro_nome"].ToString();
        txtDescricao.Text = ds.Tables[0].Rows[0]["pro_descricao"].ToString();
        txtPreco.Text = ds.Tables[0].Rows[0]["pro_preco"].ToString();
        txtMarca.Text = ds.Tables[0].Rows[0]["mar_nome"].ToString();
        txtEstilo.Text = ds.Tables[0].Rows[0]["est_nome"].ToString();
        txtSubcategoria.Text = ds.Tables[0].Rows[0]["sub_nome"].ToString();
        txtCategoria.Text = ds.Tables[0].Rows[0]["cat_nome"].ToString();       
        txtCondicao.Text = ds.Tables[0].Rows[0]["pro_condicao"].ToString();
        txtQuantidade.Text = ds.Tables[0].Rows[0]["pro_quantidade"].ToString();
        

      
        lblImagens.Text = "";
        //lblEnvio.Text = "";
        string foto = "", cor = "", corAux = "", envio = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (foto != dr["fot_url"].ToString())
            {
                lblImagens.Text += @"<img src='" + dr["fot_url"] + @"' style='width: 80px; height: 80px;' />";
                foto = dr["fot_url"].ToString();
            }
           
            if (envio != dr["env_nome"].ToString())
            {
                lblEnvio.Text = @""+dr["env_nome"]+@"";
                envio = dr["env_nome"].ToString();
            }
        }       
    }
}