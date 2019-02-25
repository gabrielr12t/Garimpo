using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Cadastro_CadastroRapidoo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioDB db = new UsuarioDB();
        Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));
        

        if (Session["cpf"] != null)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), key: "script", script: "<script>$('#myModal').modal('show');</script> ", addScriptTags: false);
            if (usuario.Usu_cadastroCompleto == 1)
            {
                Response.Redirect("/Paginas/Erros/NaoPodeVoltar.aspx");
            }
            //esconderCampos();
        }
        else
        {
            txtNome.Focus();
        }
    }
    //Trocar botões
    public void trocarBotao()
    {
        btnCadastrar.Visible = false;
    }

    //Verificar se os campos estão preenchidos

    //Limpar campos
    public void limparCampos()
    {
        txtCpf.Text = "";
        txtEmail.Text = "";
        txtNome.Text = "";
        txtSenha.Text = "";
        txtConfirmaSenha.Text = "";
    }//-------]


    // Verificar se concordou com os termos
    public Boolean concordou()
    {
        if (ckbAceitar.Checked)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //-----------------
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        lblRetorno.Text = "";
        if (concordou())
        {
            //        Criptografia senha       //
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(txtSenha.Text);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            //----------------------------------------
            Usuario usuario = new Usuario();
            usuario.Usu_cpf_cnpj = txtCpf.Text;
            usuario.Usu_nome = txtNome.Text;
            //adicionar Sobrenome
            usuario.Usu_sexo = "";
            //user.Usu_data_nasc = Convert.ToDateTime(0000-00-00);
            usuario.Usu_email = txtEmail.Text.ToLower();
            usuario.Usu_senha = strHex;

            DateTime hoje = DateTime.Now;
            hoje.ToString("dd/MM/YY");
            usuario.Usu_data_cadastro = hoje;
            usuario.Usu_status_cadastro = true;
            usuario.Usu_foto_perfil = "../../themes/images/FOTOPERFIL/este.gif";
            usuario.Usu_nome_loja = "Lojinha do(a)" + txtNome.Text;
            usuario.Usu_qtdd_vendas = 0;
            usuario.Usu_qtdd_vendas_canceladas = 0;
            usuario.Usu_qtdd_denuncia = 0;
            usuario.Usu_qtdd_compras = 0;
            usuario.Usu_qtdd_compras_canceladas = 0;
            usuario.Usu_medida_busto = "";
            usuario.Usu_medida_cintura = "";
            usuario.Usu_medida_calcado = "";
            usuario.Usu_reputacao = 0.0;
            usuario.Usu_cadastroCompleto = 1;
            usuario.Tipo = new Tipo_usuario();
            usuario.Tipo.Tip_codigo = 2;
            //usuario.Subcategoria = new Subcategoria();
            //usuario.Subcategoria.Sub_codigo = 25;
             switch (UsuarioDB.Insert(usuario))
            {
                case 0:
                    Session["nome"] = Convert.ToString(txtNome.Text);
                    Session["cpf"] = Convert.ToString(txtCpf.Text);
                    Mensagem mensagem = new Mensagem();
                    mensagem.Men_conteudo = "Seja muito bem-vindo Sr(a) " + txtNome.Text + " ao Garimpo, aqui você pode vender seus produtos e também comprar novos produtos";
                    mensagem.Men_data = DateTime.Now;
                    mensagem.Men_lida = false;
                    mensagem.Usuario = new Usuario();
                    mensagem.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
                    mensagem.Tipo = new Tme_tipo_mensagem();
                    mensagem.Tipo.Tme_codigo = 1;
                    MensagemDB.MensagemCadastro(mensagem);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "cadastro();", true);                                                  
                    break;
                case -2:
                    limparCampos();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erro();", true);
                    break;
            }
        }
        else
        {
            lblAceitar.Style.Add("color", "red");
            lblTermos.Style.Add("color", "red");
        }
    }

}


//AVISOS
//PRECISA IMPLEMENTAR O ATRIBUTO CADASTRO COMPLETO / 0=não fez cadastro , 1=fez cadastro rapido , 2=fez os dados no cadastro completo, 3=ja inseriu endereço