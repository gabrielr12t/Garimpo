using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Alterar_AlteracaoProduto : System.Web.UI.Page
{
    int codigoEstilo;
    int codigoCategoria;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] == null || Request.QueryString["id"] == null)
        {
            Response.Redirect("/Paginas/Erros/Erro404.aspx");
        }
        else
        {

            if (!Page.IsPostBack)
            {
                CarregaDadosProduto();
                carregaFotos();
                CarregarDDLEstilo();
            }
            if (ddlEstilo.SelectedItem.Text != "Selecione")
            {
                codigoEstilo = Convert.ToInt32(ddlEstilo.SelectedItem.Value);
            }
        }
    }
    public void CarregaDadosProduto()
    {
        string id = Request.QueryString["id"];
       

        DataSet db = ProdutoDB.SelectAlterarProduto(Convert.ToInt32(id));
        txtNome.Text = db.Tables[0].Rows[0]["pro_nome"].ToString();
        txtDescricao.Text = db.Tables[0].Rows[0]["pro_descricao"].ToString();
        txtPreco.Text = db.Tables[0].Rows[0]["pro_preco"].ToString();
        ddlCondicao.SelectedItem.Text = db.Tables[0].Rows[0]["pro_condicao"].ToString();
        ddlQuantidade.SelectedItem.Text = db.Tables[0].Rows[0]["pro_quantidade"].ToString();
    }
    public void CarregarDDLEstilo()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        DataSet db = ProdutoDB.SelectAlterarProduto(Convert.ToInt32(id));
        DataSet ds = EstiloDB.SelectAll();
        ddlEstilo.DataSource = ds;
        ddlEstilo.SelectedValue = (db.Tables[0].Rows[0]["est_codigo"].ToString());
        ddlEstilo.DataTextField = "est_nome";
        ddlEstilo.DataValueField = "est_codigo";
        ddlEstilo.DataBind();

        //Dropdown Categoria     
        ds = CategoriaDB.SelectAId(Convert.ToInt32(db.Tables[0].Rows[0]["est_codigo"].ToString()));
        ddlCategoria.SelectedValue = (db.Tables[0].Rows[0]["cat_codigo"].ToString());
        ddlCategoria.DataSource = ds;
        ddlCategoria.DataTextField = "cat_nome";
        ddlCategoria.DataValueField = "cat_codigo";
        ddlCategoria.DataBind();

        //Dropdown Subcategoria
        ds = SubcategoriaDB.SelectID(Convert.ToInt32(db.Tables[0].Rows[0]["cat_codigo"].ToString()));
        ddlSubcategoria.DataSource = ds;
        ddlSubcategoria.SelectedValue = ddlCategoria.SelectedValue = (db.Tables[0].Rows[0]["sub_codigo"].ToString());
        ddlSubcategoria.DataTextField = "sub_nome";
        ddlSubcategoria.DataValueField = "sub_codigo";
        ddlSubcategoria.DataBind();


        //carregar DDLMarcas        
        ds = MarcasDB.SelectAll();
        ddlMarca.DataSource = ds;
        ddlMarca.DataTextField = "mar_nome";
        ddlMarca.DataValueField = "mar_codigo";
        ddlMarca.DataBind();
    }

    //----------------------------------------------------------------

    protected void ddlEstilo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregarDDLCategoriaN();
    }

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        codigoCategoria = Convert.ToInt32(ddlCategoria.SelectedItem.Value);
        CarregarDDLSubcategoriaN();
    }
    public void CarregarDDLEstiloN()
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
    public void CarregarDDLCategoriaN()
    {
        //Dropdown Categoria     
        //DataSet ds1 = CategoriaDB.SelectAId(codigo);
        DataSet ds1 = CategoriaDB.SelectAId(codigoEstilo);
        ddlCategoria.DataSource = ds1;
        ddlCategoria.DataTextField = "cat_nome";
        ddlCategoria.DataValueField = "cat_codigo";
        ddlCategoria.DataBind();
        ddlCategoria.Items.Insert(0, "Selecione");
    }
    public void CarregarDDLSubcategoriaN()
    {
        //Dropdown Subcategoria
        DataSet ds3 = SubcategoriaDB.SelectID(codigoCategoria);
        ddlSubcategoria.DataSource = ds3;
        ddlSubcategoria.DataTextField = "sub_nome";
        ddlSubcategoria.DataValueField = "sub_codigo";
        ddlSubcategoria.DataBind();
        ddlSubcategoria.Items.Insert(0, "Selecione");
    }

    public void carregaFotos()
    {
        string id = Request.QueryString["id"];
        ltlFotos.Text = "";
        DataSet ds = FotosDB.SelectByProduto(Convert.ToInt32(id));
        int qtn = ds.Tables[0].Rows.Count;
        int cont = 0;
        if (qtn > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (cont == 0)
                {
                    ltlFotos.Text += @"<table class='table table-striped table-hover' style='background-color: blue!important'>
                                    <tbody>
                                        <tr>";
                }
                if (cont < 3)
                {
                    ltlFotos.Text += @"<td class='span3'>
                                                <img src='" + dr["fot_url"] + @"' style='width: 130px!important; height: 130px!important'/><a class='excluir'  rel='" + dr["fot_codigo"] + @"' id='" + dr["pro_codigo"] + @"' href='#' ></br><i class='fa fa-trash fa-2x'></i></a>
                                           </td>";
                    cont++;
                }
                if (cont == 3)
                {
                    ltlFotos.Text += @"</tr>
                                    </tbody>
                                </table>";
                    cont = 0;
                }
            }
            ltlFotos.Text += @"</tr>
                                    </tbody>
                                </table>";
        }
    }

    [WebMethod]
    public static string ExcluiFoto(string codigo, string id)
    {
        DataSet ds = FotosDB.SelectByProduto(Convert.ToInt32(id));
        int qtn = ds.Tables[0].Rows.Count;
        if (qtn > 1)
        {
            FotosDB.Delete(Convert.ToInt32(codigo));
            return "s";
        }
        else
        {
            return "n";
        }
    }
    static List<string> imgs;
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool f = false;
        string caminhoFoto = "";
        string dir = Request.PhysicalApplicationPath + "\\Fotos\\Produtos\\";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (uplImagem.HasFiles)
        {
            foreach (HttpPostedFile item in uplImagem.PostedFiles)
            {
                string ext = Path.GetExtension(item.FileName).ToLower();
                if (ext == ".jpg" || ext == ".png" || ext == ".jfif")
                {
                    double tamanho = item.ContentLength / 1024;
                    if (tamanho <= 4000)
                    {
                        string nomeArquivo = DateTime.Now.ToString("ddMMyyyymmssfff") + ext;
                        item.SaveAs(dir + nomeArquivo);
                        caminhoFoto = "\\Fotos\\Produtos\\" + nomeArquivo;
                        if (!f)
                        {
                            imgs = new List<string>();
                            f = true;
                        }
                       
                        imgs.Add(caminhoFoto);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Tamanho máximo de foto excedido','error')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Extensão inválida','error')", true);
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Selecione um arquivo','error')", true);
        }

        ltlFotosNovas.Text = "";
        int cont = 0;
        bool flag = true;

        foreach (string fot in imgs)
        {
            if (flag)
            {
                ltlFotosNovas.Text += "Fotos adicionadas <br />";
                flag = false;
            }
            if (cont == 0)
            {
                ltlFotosNovas.Text += @"<table class='table table-striped table-hover' style='background-color: blue!important'>
                                    <tbody>
                                        <tr>";
            }
            if (cont < 3)
            {
                ltlFotosNovas.Text += @"<td class='span3'>
                                                <img src='" + fot + @"' style='width: 130px!important; height: 130px!important'/>
                                           </td>";
                cont++;
            }
            if (cont == 3)
            {
                ltlFotosNovas.Text += @"</tr>
                                    </tbody>
                                </table>";
                cont = 0;
            }
        }
        ltlFotosNovas.Text += @"</tr>
                                    </tbody>
                                </table>";
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];

        DataSet db = ProdutoDB.SelectAlterarProduto(Convert.ToInt32(id));

        Produto p = new Produto();
        p.Subcategoria = new Subcategoria();
        p.Subcategoria.Sub_codigo = Convert.ToInt32(ddlSubcategoria.SelectedValue);
        p.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
        p.Pro_nome = txtNome.Text;
        p.Pro_descricao = txtDescricao.Text;
        p.Pro_preco_antigo = Convert.ToInt32(db.Tables[0].Rows[0]["pro_preco"].ToString());
        p.Pro_preco = Convert.ToDouble(txtPreco.Text);
        p.Pro_condicao = ddlCondicao.SelectedValue;
        p.Pro_quantidade = Convert.ToInt32(ddlQuantidade.SelectedValue);
        p.Marca = new Marca();
        p.Marca.Mar_codigo = Convert.ToInt32(ddlMarca.SelectedValue);
        if (ProdutoDB.Update(p) == 0)
        {
            foreach (string item in imgs)
            {
                Foto foto = new Foto();
                foto.Fot_url = item;
                foto.Produto = new Produto();
                foto.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
                FotosDB.Insert(foto);
            }
            DataSet data = UsuarioDB.SelectAll();
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                if (dr["tip_codigo"].ToString().Equals("Administrador"))
                {
                    Mensagem madm = new Mensagem();
                    madm.Men_conteudo = "Olá sr(a) " + dr["usu_nome"] + @", o usuário " + Session["nome"] + " alterou um produto no sistema," +
                                  " irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.";
                    madm.Usuario = new Usuario();
                    madm.Usuario.Usu_cpf_cnpj = dr["usu_cpf_cnpj"].ToString();
                    madm.Tipo = new Tme_tipo_mensagem();
                    madm.Tipo.Tme_codigo = 7;
                    madm.Produto = new Produto();
                    madm.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
                    madm.Men_lida = false;
                    madm.Men_data = Convert.ToDateTime(DateTime.Now);
                    MensagemDB.MensagemADM(madm);
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Confirma();", true);
        }
    }

}