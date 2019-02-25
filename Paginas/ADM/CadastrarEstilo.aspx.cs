using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_CadastrarCategoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null)
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
        if (!IsPostBack)
        {
            CarregarGrid();
        }
    }

    private void CarregarGrid()
    {
        DataSet ds = EstiloDB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            gridEstilo.DataSource = ds.Tables[0].DefaultView;
            gridEstilo.DataBind();
            gridEstilo.Visible = true;
            lblQuantidade.Text = "O site possui " + qtd + " estilos cadastrados";
        }
        else
        {
            gridEstilo.Visible = false;
            lblQuantidade.Text = "Nenhum estilo cadastrado";
        }
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        if (txtEstilo.Text != "")
        {            
            Estilo est = new Estilo();
            est.Est_nome = txtEstilo.Text;
          
            est.Usuario = new Usuario();
            est.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();

            switch (EstiloDB.Insert(est))
            {
                case 0:
                    CarregarGrid();
                    lblMensagem.Text = " </br></br>  <div class='alert alert-success span4'>Cadastrado</div>";
                    txtEstilo.Text = "";
                    txtEstilo.Focus();

                    break;
                case -2:
                    lblMensagem.Text = "</br></br>  <div class='alert alert-danger span4'>Não Cadastrado</div>";
                    txtEstilo.Text = "";
                    break;
            }
        }
        else
        {
            //lblMensagem.Text = "</br></br>  <div class='alert alert-warning span4'>Preencha o campo</div>";
            lblMensagem.Text = "<br /><br /><div class='span5 alert alert-error'><button type=button class='close' data-dismiss='alert'>&times;</button><h4>Erro!</h4>Preencha o campo para cadastrar</div>";
        }
    }
}