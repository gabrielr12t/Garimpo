using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_CadastrarCategoriaSubcategoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CarregarDDL();
        
    }
    protected void ddlEstilo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregaGrid(Convert.ToInt32(ddlEstilo.SelectedItem.Value));
    }
    private void CarregaGrid(int categoria)
    {       
        CategoriaDB bd = new CategoriaDB();
        DataSet ds = bd.SelectBuscaSubcategoriaID(categoria);
        gridCategoria.DataSource = ds.Tables[0].DefaultView;
        gridCategoria.DataBind();
        int registros = ds.Tables[0].Rows.Count;
        if (registros == 0)
            lblQuantidade.Text = "Nenhuma Categoria nesse estilo";
        else
            lblQuantidade.Text = "Categorias cadastrada nesse estilo";
    }


    //carregar DDL
    public void CarregarDDL()
    {
        //Carregar um DropdownList com o banco de dados
        DataSet ds = EstiloDB.SelectAll();
        ddlEstilo.DataSource = ds;
        //nome da coluna do banco de dados;
        ddlEstilo.DataTextField = "est_nome";
        //ID da coluna do Banco
        ddlEstilo.DataValueField = "est_codigo";
        ddlEstilo.DataBind();
        ddlEstilo.Items.Insert(0, "Selecione");
       
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        if (ddlEstilo.SelectedIndex != 0)
        {
          
            Categoria cat = new Categoria();
            if (txtCategoria.Text != "")
                cat.Cat_nome = txtCategoria.Text;

            Estilo est = new Estilo();
            est.Est_codigo = Convert.ToInt32(ddlEstilo.SelectedValue);
            cat.Estilo = est;

            switch (CategoriaDB.Insert(cat))
            {
                case 0:
                    lblMensagem.Text = "<div class='alert alert-success span4'>Cadastrado</div>";
                    txtCategoria.Text = "";
                    txtCategoria.Focus();
                    break;
                case -2:
                    lblMensagem.Text = "<div class='alert alert-danger span5'>Não cadastrado</div>";
                    txtCategoria.Text = "";
                    break;
            }
        }
        else
        {
            lblMensagem.Text = "<div class='span5 alert alert-error'><button type=button class='close' data-dismiss='alert'>&times;</button><h4>Erro!</h4>Selecione um estilo</div>";
        }
    }

   
}