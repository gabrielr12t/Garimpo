using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Alterar_AlterarCadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["cpf"] != null)
            {
                //Usuario u = (Usuario)Session["USUARIO"];
                UsuarioDB db = new UsuarioDB();
                Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));
                CarregaGrid(usuario);
                //CarregarLiteral(usuario);
                txtCpf.Text = usuario.Usu_cpf_cnpj;
                txtNome.Text = usuario.Usu_nome;
                txtEmail.Text = usuario.Usu_email;
                txtTelefone.Text = usuario.Usu_telefone;
                rbtSexo.Text = usuario.Usu_sexo;
                if (usuario.Usu_data_cadastro == null)
                {
                    txtDataNascimento.Text = "";
                }
                else
                {
                    txtDataNascimento.Text = Convert.ToString(usuario.Usu_data_nasc);
                }
            }
            else
            {
                Response.Redirect("/Paginas/Login.aspx");
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "$('#myModal').modal('hide');", true);
        }
    }
    public void CarregaGrid(Usuario u)
    {
        DataSet ds = EnderecoDB.SelectAll(u.Usu_cpf_cnpj);
        rptImagens.DataSource = ds.Tables[0].DefaultView;
        rptImagens.DataBind();
    }

   // div endereço dinamica
    //private void CarregarLiteral(Usuario u)
    //{
    //    DataSet ds = EnderecoDB.SelectAll(u.Usu_cpf_cnpj);
    //    litEndereco.Text = "";
    //    foreach (DataRow dr in ds.Tables[0].Rows)
    //    {
    //        litEndereco.Text += @"<p class='descricao' style='border: 0.1px solid; border-color: #d4d4d4; padding: 10px 0px 10px 5px'><a href='#' onclick='return false;' class='editarCad' rel ='" + dr["end_codigo"] + "|" + u.Usu_cpf_cnpj +
    //            "|" + dr["end_estado"] + "|" + dr["end_cidade"] + "|" + dr["end_bairro"] + "|" + dr["end_endereco"] + "|" + dr["end_referencia"] + "|" + dr["end_numero"]
    //            + "|" + dr["end_cep"] + @"'><i class='fa fa-pencil pull-right' style='font-size:30px'></i></a><a href='#' class='excluir' rel='" + dr["end_codigo"] + "'><i class='fa fa-trash pull-right' style='font-size:30px'></i></a> Cep: " + dr["end_cep"] + @"<br/>Estado: " + dr["end_estado"]
    //            + "<br/>Cidade: " + dr["end_cidade"] + "<br/>Bairro: " + dr["end_bairro"] + @"<br/>Endereço: " + dr["end_endereco"]
    //            + @"<br/>Referência: " + dr["end_referencia"] + @"<br/>Número: " + dr["end_numero"]
    //            + @"<br/></p><br/> ";
    //    }
    //}

    //[WebMethod]
    //public static string ExcluiEndereco(string codigo)
    //{
    //    if (EnderecoDB.Delete(Convert.ToInt32(codigo)) == 0)
    //    {
    //        return "s";
    //    }
    //    else
    //        return "n";
    //}
    public Boolean camposPreenchidos()
    {
        if (txtNome.Text == "" || txtEmail.Text == "" || txtTelefone.Text == "" || txtDataNascimento.Text == "" || rbtSexo.SelectedValue != rbtSexo.SelectedValue)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void btnSalvarDados_Click1(object sender, EventArgs e)
    {
        //salvar dados pessoais.
        if (camposPreenchidos())
        {
            Usuario user = new Usuario();
            user.Usu_cpf_cnpj = Convert.ToString(Session["cpf"]);
            user.Usu_nome = txtNome.Text;
            user.Usu_email = txtEmail.Text;
            user.Usu_telefone = txtTelefone.Text;
            user.Usu_data_nasc = Convert.ToDateTime(txtDataNascimento.Text);
            user.Usu_sexo = Convert.ToString(rbtSexo.SelectedItem.Value);

            switch (UsuarioDB.Update(user))
            {
                case 0:
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "atualizado();", true);
                    break;
                case -2:
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "existe();", true);
                    txtTelefone.Text = user.Usu_telefone;
                    break;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erro();", true);
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {        
        Endereco endereco = new Endereco();
        endereco.End_cep = txtCep.Text;
        endereco.End_bairro = txtBairro.Text;
        endereco.End_cidade = txtCidade.Text;
        endereco.End_endereco = txtEndereco.Text;
        endereco.End_estado = txtEstado.Text;
        endereco.End_numero = Convert.ToInt32(txtNumero.Text);
        endereco.End_referencia = txtReferencia.Text;
        endereco.Usuario = new Usuario();
        endereco.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
        EnderecoDB.InsertEndereco(endereco);
        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "enderecoCadastrado();", true);
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        DataSet ds = EnderecoDB.SelectAll(Session["cpf"].ToString());
        Endereco end = new Endereco();
        end.End_bairro = txtBairroEditar.Text;
        end.End_cep = txtCepEditar.Text;
        end.End_cidade = txtCidadeEditar.Text;
        end.End_codigo = Convert.ToInt32(Session["codigoendereco"]);
        end.End_endereco = txtEnderecoEditar.Text;
        end.End_estado = txtEstadoEditar.Text;
        end.End_numero = Convert.ToInt32(txtNumeroEditar.Text);
        end.End_referencia = txtReferenciaEditar.Text;
        Usuario u = new Usuario();
        u.Usu_cpf_cnpj = txtCPFEditar.Value;
        end.Usuario = u;
        if (EnderecoDB.Update(end)==0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "sucessoalteracao();", true);
        }                
    }

    protected void rptImagens_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "excluir")
        {

            DataSet ds = EnderecoDB.SelectTemEndereco(Session["cpf"].ToString());
            DataSet end = EnderecoDB.SelectAll(Session["cpf"].ToString());
            int qtnEnd = end.Tables[0].Rows.Count;
            int qtn = ds.Tables[0].Rows.Count;
            if (qtn>1 && qtnEnd>1)
            {
                if (EnderecoDB.Delete(Convert.ToInt32(e.CommandArgument)) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "sucesso();", true);
                }
               
            }
            else
            {
                if (qtn == 0)
                {
                    if (EnderecoDB.Delete(Convert.ToInt32(e.CommandArgument)) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "sucesso();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "NaoPodeExcluir();", true);
                }
               
            }                                
        }
        if (e.CommandName == "alterar")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#myModal').modal('show');</script>", false);
            DataSet ds = EnderecoDB.SelectCodigo(Convert.ToInt32(e.CommandArgument));
            txtCepEditar.Text = ds.Tables[0].Rows[0]["end_cep"].ToString();
            txtEstadoEditar.Text = ds.Tables[0].Rows[0]["end_estado"].ToString();
            txtCidadeEditar.Text = ds.Tables[0].Rows[0]["end_cidade"].ToString();
            txtBairroEditar.Text = ds.Tables[0].Rows[0]["end_bairro"].ToString();
            txtNumeroEditar.Text = ds.Tables[0].Rows[0]["end_numero"].ToString();
            txtEnderecoEditar.Text = ds.Tables[0].Rows[0]["end_endereco"].ToString();
            txtReferenciaEditar.Text = ds.Tables[0].Rows[0]["end_referencia"].ToString();
            txtCodigoEditar.Value = ds.Tables[0].Rows[0]["end_codigo"].ToString();
            Session["codigoendereco"] = ds.Tables[0].Rows[0]["end_codigo"].ToString();
        }
    }

    //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Confirma();", true);
             
    protected void btnAlterarSenha_Click(object sender, EventArgs e)
    {
        UsuarioDB db = new UsuarioDB();
        Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));
     
        UnicodeEncoding eu = new UnicodeEncoding();
        byte[] Hash, bytes = eu.GetBytes(txtSenhaAtual.Text);
        SHA512Managed shas = new SHA512Managed(); string Hex = "";
        Hash = shas.ComputeHash(bytes);
        foreach (byte b in Hash)
        {
            Hex += String.Format("{0:x2}", b);
        }

        //---------------------------
        if (usuario.Usu_senha.Equals(Hex))
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(txtNovaSenha.Text);
            SHA512Managed SHhash = new SHA512Managed(); string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            usuario.Usu_cpf_cnpj = Convert.ToString(Session["cpf"]);
            usuario.Usu_senha = strHex;
            UsuarioDB.updateSenhaCpf(usuario);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "AlterarSenha();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroSenha();", true);
        }

    }
}