using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Produtos_CadastroProdutoNovo : System.Web.UI.Page
{
    int codigoEstilo;
    int codigoCategoria;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] != null)
        {
            Usuario u = UsuarioDB.SelectUsuario(Session["cpf"].ToString());
            DataSet ds = EnderecoDB.SelectAll(Session["cpf"].ToString());
            int qtd = ds.Tables[0].Rows.Count;

            if (u.Usu_cadastroCompleto == 2 && qtd > 0)
            {
                if (!Page.IsPostBack)
                {
                    CarregarCBLEnvio();
                    CarregarDDLEstilo();
                    CarregarDDLMarca();
                    CarregarCBLCor();
                    //CarregaGrid();
                }
                if (ddlEstilo.SelectedItem.Text != "Selecione")
                {
                    codigoEstilo = Convert.ToInt32(ddlEstilo.SelectedItem.Value);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "concluir();", true);
            }
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
    }
    protected void ddlEstilo_TextChanged(object sender, EventArgs e)
    {
        CarregarDDLCategoria();
    }

    protected void ddlCategoria_TextChanged(object sender, EventArgs e)
    {
        codigoCategoria = Convert.ToInt32(ddlCategoria.SelectedItem.Value);
        CarregarDDLSubcategoria();
    }

    protected void rbtOpcoes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtOpcoes.SelectedValue == "Roupas")
        {
            pnlGeral.Visible = false;
            pnl2.Visible = true;
            if (rbtRoupas.SelectedValue == "Calcas")
            {
                pnlGeral.Visible = true;
                pnlCalcas.Visible = true;
                pnlCamisa.Visible = false;
                pnlCalcado.Visible = false;
            }
            else if (rbtRoupas.SelectedValue == "Camisas")
            {
                pnlGeral.Visible = true;
                pnlCamisa.Visible = true;
                pnlCalcas.Visible = false;
                pnlCalcado.Visible = false;

            }
            else
            {
                pnlCalcas.Visible = false;
                pnlCamisa.Visible = false;

            }
        }
        else if (rbtOpcoes.SelectedValue == "Calcados")
        {
            pnlCalcado.Visible = true;
            pnlCalcas.Visible = false;
            pnlCamisa.Visible = false;
            pnl2.Visible = false;
            pnlGeral.Visible = true;

        }
        else
        {
            pnlGeral.Visible = true;
            pnl2.Visible = false;
            pnlCalcado.Visible = false;
            pnlCalcas.Visible = false;
            pnlCamisa.Visible = false;
        }
    }
    protected void rbtRoupas_TextChanged(object sender, EventArgs e)
    {
        pnlGeral.Visible = true;
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
    public void CarregarDDLCategoria()
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
    public void CarregarDDLSubcategoria()
    {
        //Dropdown Subcategoria
        DataSet ds3 = SubcategoriaDB.SelectID(codigoCategoria);
        ddlSubcategoria.DataSource = ds3;
        ddlSubcategoria.DataTextField = "sub_nome";
        ddlSubcategoria.DataValueField = "sub_codigo";
        ddlSubcategoria.DataBind();
        ddlSubcategoria.Items.Insert(0, "Selecione");
    }
    public void CarregarDDLMarca()
    {
        //carregar DDLMarcas
        //Carregar um DropdownList com o banco de dados
        DataSet ds4 = MarcasDB.SelectAll();
        ddlMarca.DataSource = ds4;
        //nome da coluna do banco de dados;
        ddlMarca.DataTextField = "mar_nome";
        //ID da coluna do Banco
        ddlMarca.DataValueField = "mar_codigo";
        ddlMarca.DataBind();
        //ddlMarca.Items.Insert(0, "Selecione");
    }
    public void CarregarCBLCor()
    {
        //carregar Cor       
        DataSet ds2 = CorDB.SelectAll();
        cblCor.DataSource = ds2;
        //nome da coluna do banco de dados;
        cblCor.DataTextField = "cor_nome";
        //ID da coluna do Banco
        cblCor.DataValueField = "cor_codigo";
        cblCor.DataBind();
    }

    //public void CarregaGrid()
    //{
    //    DataSet ds = CorDB.SelectAll();
    //    gridCor.DataSource = ds.Tables[0].DefaultView;
    //    gridCor.DataBind();
    //}

    public void CarregarCBLEnvio()
    {
        //carregar Cor       
        DataSet ds2 = FormasEnvioDB.SelectAll();
        cblEnvios.DataSource = ds2;
        //nome da coluna do banco de dados;
        cblEnvios.DataTextField = "env_nome";
        //ID da coluna do Banco
        cblEnvios.DataValueField = "env_codigo";
        cblEnvios.DataBind();
    }

    private bool IsPreenchido(string str)
    {
        bool retorno = false;
        if (str != string.Empty)
        {
            retorno = true;
        }
        return retorno;
    }


    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        if (!IsPreenchido(txtNome.Text))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            txtNome.Focus();
            txtNome.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            txtNome.Style.Remove("border-color");
        }

        if (!IsPreenchido(txtDescricao.Text))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            txtDescricao.Focus();
            txtDescricao.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            txtDescricao.Style.Remove("border-color");
        }

        if (!IsPreenchido(txtPreco.Text))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            txtPreco.Focus();
            txtPreco.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            txtPreco.Style.Remove("border-color");
        }

        if (!IsPreenchido(ddlMarca.SelectedValue))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            ddlMarca.Focus();
            ddlMarca.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            ddlMarca.Style.Remove("border-color");
        }

        if (!IsPreenchido(ddlEstilo.SelectedValue))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            ddlEstilo.Focus();
            ddlEstilo.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            ddlEstilo.Style.Remove("border-color");
        }

        if (!IsPreenchido(ddlCategoria.SelectedValue))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            ddlCategoria.Focus();
            ddlCategoria.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            ddlCategoria.Style.Remove("border-color");
        }

        if (!IsPreenchido(ddlSubcategoria.SelectedValue))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            ddlSubcategoria.Focus();
            ddlSubcategoria.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            ddlSubcategoria.Style.Remove("border-color");
        }


        if (!IsPreenchido(ddlQuantidade.SelectedValue))
        {
            lblRetorno.Text = "<p style='color:red'>Campo obrigatório</p>";
            ddlQuantidade.Focus();
            ddlQuantidade.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            ddlQuantidade.Style.Remove("border-color");
        }

        if (!IsPreenchido(cblCor.SelectedValue))
        {
            lblCor.Text = "<p style='color:red'>Cores: *</p>";
            lblRetorno.Text = "<p style='color:red'>Selecione pelo menos uma cor</p>";
            cblCor.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblCor.Style.Remove("border-color");
            lblRetorno.Text = "";
            cblCor.Style.Remove("border-color");
        }

        if (!IsPreenchido(cblEnvios.SelectedValue))
        {
            lblEnvio.Text = "<p style='color:red'>Forma de envio: *</p>";
            lblRetorno.Text = "<p style='color:red'>Selecione pelo menos uma forma de envio</p>";
            cblEnvios.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblEnvio.Style.Remove("border-color");
            lblRetorno.Text = "";
            cblEnvios.Style.Remove("border-color");
        }


        if (!IsPreenchido(Convert.ToString(img1.HasFiles)))
        {
            lblRetorno.Text = "<p style='color:red'>Adicione uma imagem</p>";
            img1.Style.Add("border-color", "red");
            return;
        }
        else
        {
            lblRetorno.Text = "";
            img1.Style.Remove("border-color");
        }
        //-------------------------------------------------------

      
        string caminhoFoto = "";
        int inseriu = 0;
        string dir = Request.PhysicalApplicationPath + "\\Fotos\\Produtos\\";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        List<string> imgs = new List<string>();

        if (img1.HasFiles)
        {
            foreach (HttpPostedFile item in img1.PostedFiles)
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
                        inseriu = 1;
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
       

        // se a foto foi inserida insere o produto

        if (inseriu == 1)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Confirma();", true);

            Produto produto = new Produto();
            produto.Pro_nome = txtNome.Text;
            produto.Pro_descricao = txtDescricao.Text;
            produto.Pro_preco = Convert.ToDouble(txtPreco.Text);
            produto.Pro_condicao = Convert.ToString(ddlCondicao.SelectedValue);
            produto.Pro_quantidade = Convert.ToInt32(ddlQuantidade.SelectedValue);

            //fazer as condiçoes
            if (rbtOpcoes.SelectedValue == "Roupas" && rbtRoupas.SelectedValue == "Camisas")
            {
                produto.Pro_medida = Convert.ToString(ddlTamanhoCamisas.SelectedValue);
            }
            else if (rbtOpcoes.SelectedValue == "Roupas" && rbtOpcoes.SelectedValue == "Calcas")
            {
                produto.Pro_medida = Convert.ToString(ddlTamanhoCalcas.SelectedValue);
            }
            else if (rbtOpcoes.SelectedValue == "Calcados")
            {
                produto.Pro_medida = Convert.ToString(ddlTamanhoCalcado.SelectedValue);
            }
            else
            {
                produto.Pro_medida = "";
            }

            produto.Pro_status = true;
            produto.Pro_moderacao_status = 0;// 0 = em andamento / 1=aceito / 2=não aceito
                                             //tamanho na pagina seria medida no banco?
                                             //precisamos especificar melhor o tamanho/medida                                   
            produto.Subcategoria = new Subcategoria();
            produto.Subcategoria.Sub_codigo = Convert.ToInt32(ddlSubcategoria.SelectedValue);

            produto.Marca = new Marca();
            produto.Marca.Mar_codigo = Convert.ToInt32(ddlMarca.SelectedValue);
            produto.Pro_preco_antigo = 0.0;
            produto.Usuario = new Usuario();
            produto.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
            produto.Pro_acesso = 0;
            ProdutoDB.Insert(produto);
            ProdutoDB db = new ProdutoDB();
            Produto p = db.SelectNew(Convert.ToString(Session["cpf"]));

            int cod_produto = p.Pro_codigo;

            CorDB cordb = new CorDB();
            for (int i = 0; i < cblCor.Items.Count; i++)
            {
                if (cblCor.Items[i].Selected)
                {
                    int cor = Convert.ToInt32(cblCor.Items[i].Value);
                    cordb.VincularCor(cor, cod_produto);
                }
            }

            FormasEnvioDB formaenviodb = new FormasEnvioDB();
            for (int i = 0; i < cblEnvios.Items.Count; i++)
            {
                if (cblEnvios.Items[i].Selected)
                {
                    int env = Convert.ToInt32(cblEnvios.Items[i].Value);
                    formaenviodb.FormasDeEnvio(env, cod_produto);
                }
            }

            foreach (string item in imgs)
            {
                Foto foto = new Foto();
                foto.Fot_url = item;
                foto.Produto = new Produto();
                foto.Produto.Pro_codigo = cod_produto;
                FotosDB.Insert(foto);
            }

            Mensagem mensagem = new Mensagem();
            mensagem.Men_conteudo = "Olá sr(a) " + Session["nome"] + " você efetuou o cadastro do seu produto " + produto.Pro_nome + "," +
                        " agora é só aguardar os administradores aceitarem para que seu produto fique ativo. seu produto cadastrado " +
                        "foi um(a) " + produto.Pro_nome + "com" + produto.Pro_quantidade + " unidade(s)";
            mensagem.Usuario = new Usuario();
            //mensagem.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
            mensagem.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
            mensagem.Produto = new Produto();
            mensagem.Tipo = new Tme_tipo_mensagem();
            mensagem.Tipo.Tme_codigo = 1;
            mensagem.Men_lida = false;
            mensagem.Men_data = Convert.ToDateTime(DateTime.Now);
            mensagem.Produto.Pro_codigo = cod_produto;
            MensagemDB.CadastroProduto(mensagem);

            ////mensagem para adms          
            DataSet data = UsuarioDB.SelectAll();                     
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                if (dr["tip_codigo"].ToString().Equals("Administrador"))
                {
                    Mensagem madm = new Mensagem();
                    madm.Men_conteudo = "Olá sr(a) "+dr["usu_nome"]+@", o usuário " +Session["nome"]+ " inseriu um novo produto no sistema," +
                                  " irá aparecer na página Moderar Produtos, Atenciosamente Garimpo.";
                    madm.Usuario = new Usuario();
                    madm.Usuario.Usu_cpf_cnpj = dr["usu_cpf_cnpj"].ToString();
                    madm.Tipo = new Tme_tipo_mensagem();
                    madm.Tipo.Tme_codigo = 1;
                    madm.Produto = new Produto();
                    madm.Produto.Pro_codigo = cod_produto;
                    madm.Men_lida = false;
                    madm.Men_data = Convert.ToDateTime(DateTime.Now);
                    MensagemDB.MensagemADM(madm);
                }
            }                                                                       
            //---------------
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Ocorreu um erro, tente novamente','error')", true);
        }
    }
    public bool erro()
    {
        return false;
    }
    protected void btnMarca_Click(object sender, EventArgs e)
    {
        if (!(txtMarca.Text == ""))
        {
            Marca marca = new Marca();
            marca.Mar_nome = txtMarca.Text;
            marca.Usuario = new Usuario();
            marca.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
            MarcasDB.Insert(marca);
            CarregarDDLMarca();
            txtMarca.Style.Remove("border-color");
            txtMarca.Text = "";
        }
        else
        {
            txtMarca.Style.Add("border-color", "red");
            lblMarca.Text = "<p style='color:red'>Insira um nome para a marca</p>";
        }
    }
}
