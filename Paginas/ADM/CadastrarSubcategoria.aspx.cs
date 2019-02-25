using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_CadastrarSubcategoria : System.Web.UI.Page
{
    int codigo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null)
        {
            Response.Redirect("/Paginas/Login.aspx");
        }

        if (!IsPostBack)
        {
            CarregarDDL();            
        }
        if (ddlEstilo.SelectedItem.Text != "Selecione")
        {
            codigo = Convert.ToInt32(ddlEstilo.SelectedValue);            
        }
    }
    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregaGrid(Convert.ToInt32(ddlCategoria.SelectedValue));
    }
    //---------
    private void CarregaGrid(int categoria)
    {
        SubcategoriaDB bd = new SubcategoriaDB();
        DataSet ds = bd.SelectBuscaSubcategoriaID(categoria);
        gridSubcategoria.DataSource = ds.Tables[0].DefaultView;
        gridSubcategoria.DataBind();
        int registros = ds.Tables[0].Rows.Count;
        if (registros == 0)
            lblQuantidade.Text = "Nenhuma Categoria nesse estilo";
        else
            lblQuantidade.Text = "Categorias cadastrada nesse estilo";
    }
    //-----------
    protected void ddlEstilo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregarCategorias();
    }
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
    public void CarregarCategorias() { 
        // DropDown Categorias
        DataSet ds1 = CategoriaDB.SelectAId(codigo);
        ddlCategoria.DataSource = ds1;
        //nome da coluna do banco de dados;
        ddlCategoria.DataTextField = "cat_nome";
        //ID da coluna do Banco
        ddlCategoria.DataValueField = "cat_codigo";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, "Selecione");

    }    
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {

        if (ddlCategoria.SelectedIndex != 0)
        {
            Subcategoria sub = new Subcategoria();
            if (txtSubcategoria.Text != "")
                sub.Sub_nome = txtSubcategoria.Text;

            Categoria cat = new Categoria();
            cat.Cat_codigo = Convert.ToInt32(ddlCategoria.SelectedValue);
            sub.Categoria = cat;

            switch (SubcategoriaDB.Insert(sub))
            {
                case 0:
                    lblMensagem.Text = "<br/> <div class='span5 alert alert-success'><button type=button class='close' data-dismiss='alert'>&times;</button><h4>Tudo certo!</h4>Cadastro com sucesso</div>";
                    txtSubcategoria.Text = "";
                    txtSubcategoria.Focus();
                                     
                    //ddlCategoria.SelectedIndex = 0;
                    //ddlEstilo.SelectedIndex = 0;
                    break;
                case -2:
                    lblMensagem.Text = "<br/><div class='alert alert-danger span5'>Não cadastrado</div>";
                    txtSubcategoria.Text = "";
                    ddlCategoria.SelectedIndex = 0;
                    break;
            }
        }
        else
        {
            lblMensagem.Text = "<br/> <div class='span5 alert alert-error'><button type=button class='close' data-dismiss='alert'>&times;</button><h4>Erro!</h4>Selecione uma categoria</div>";
        }
    }

   



}