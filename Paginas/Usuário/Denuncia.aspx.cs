using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_Denuncia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] != null)
        {
            string id = Request.QueryString["id"];
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
    }
   
    protected void btnDenunciarProduto_Click(object sender, EventArgs e)
    {
        if (rbtProdutos.SelectedIndex != -1)
        {               
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Produto p = ProdutoDB.SelectID(id);

            Denuncia d = new Denuncia();
            d.Den_opcao = Convert.ToInt32(rbtProdutos.SelectedValue);
            d.Den_tipo = 1;
            d.Usuario = new Usuario();
            d.Produto = new Produto();
            d.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
            d.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);

            if (DenunciaDB.Insert(d) == 0)
            {
                if (Convert.ToInt32(rbtProdutos.SelectedValue) == 1)
                {
                    lblMensagem.Text = "";
                    lblMensagem.Text = @"Olá sr(a) " + p.Usuario.Usu_nome + @" seu produto recebeu uma denuncia alegando estar com foto irregular, 
                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica";
                }
                else if (Convert.ToInt32(rbtProdutos.SelectedValue) == 2)
                {
                    lblMensagem.Text = "";
                    lblMensagem.Text = @"Olá sr(a) " + p.Usuario.Usu_nome + @" seu produto recebeu uma denuncia alegando estar com descrição irregular, 
                            administradores estarão revisando a denúncia e verificando se a é verídica podendo desativar seu produto.";

                }
                else if (Convert.ToInt32(rbtProdutos.SelectedValue) == 3)
                {
                    lblMensagem.Text = "";
                    lblMensagem.Text = @"Olá sr(a) " + p.Usuario.Usu_nome + @" seu produto recebeu uma denuncia alegando estar com categoria errada, 
                            administradores estarão revisando a denúncia e verificando se a denúncia é verídica";
                }
                Mensagem mensagem = new Mensagem();
                mensagem.Men_conteudo = lblMensagem.Text;
                mensagem.Usuario = new Usuario();
                mensagem.Usuario.Usu_cpf_cnpj = p.Usuario.Usu_cpf_cnpj;
                mensagem.Produto = new Produto();
                mensagem.Tipo = new Tme_tipo_mensagem();
                mensagem.Tipo.Tme_codigo = 8;
                mensagem.Men_lida = false;
                mensagem.Men_data = Convert.ToDateTime(DateTime.Now);
                mensagem.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
                MensagemDB.CadastroProduto(mensagem);

                ////mensagem para adms          
                DataSet data = UsuarioDB.SelectAll();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    if (dr["tip_codigo"].ToString().Equals("Administrador"))
                    {
                        Mensagem madm = new Mensagem();
                        if (Convert.ToInt32(rbtProdutos.SelectedValue) == 1)
                        {
                            madm.Men_conteudo = "Olá sr(a) " + dr["usu_nome"] + @", este produto recebeu uma denúncia alegando estar com foto irregular ";
                        }
                        else if (Convert.ToInt32(rbtProdutos.SelectedValue) == 2)
                        {
                            madm.Men_conteudo = "Olá sr(a) " + dr["usu_nome"] + @", este produto recebeu uma denúncia alegando estar com descrição irregular ";
                        }
                        else if (Convert.ToInt32(rbtProdutos.SelectedValue) == 3)
                        {
                            madm.Men_conteudo = "Olá sr(a) " + dr["usu_nome"] + @", este produto recebeu uma denúncia alegando estar com categoria errada ";
                        }
                        madm.Usuario = new Usuario();
                        madm.Usuario.Usu_cpf_cnpj = dr["usu_cpf_cnpj"].ToString();
                        madm.Tipo = new Tme_tipo_mensagem();
                        madm.Tipo.Tme_codigo = 8;
                        madm.Produto = new Produto();
                        madm.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
                        madm.Men_lida = false;
                        madm.Men_data = Convert.ToDateTime(DateTime.Now);
                        MensagemDB.MensagemADM(madm);

                        //função javascript sweetAlert
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "enviado();", true);
                    }
                }
            }
        }
        else
        {
            string script = "alert('Selecione um ítem');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }
    }
}