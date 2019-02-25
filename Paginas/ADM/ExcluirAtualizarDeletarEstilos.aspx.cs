using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_AlterarEstilosCategorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarDDLEstilo();            
        }
    }
    public void CarregarDDLEstilo()
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        switch (EstiloDB.Delete(Convert.ToInt32(ddlEstilo.SelectedItem.Value)))
        {
            case 0:               
                lblRetorno.Text = " </br></br>  <div class='alert alert-success span4'>Deletado com sucesso</div>";
                break;
            case -2:                
                lblRetorno.Text = " </br></br>  <div class='alert alert-danger span4'>Não pôde ser deletado, pois há categorias neste estilo</div>";
                break;
        }
        CarregarDDLEstilo();     
    }
  
   
}