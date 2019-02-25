using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtEmail.Focus();

    }

    //verificar se campos estão preenchidos
    public Boolean preenchido()
    {
        if (txtEmail.Text != "" || txtSenha.Text != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //verifica se usuario foi encontrado
    private bool UsuarioEncontrado(Usuario usuario)
    {
        bool retorno = false;
        if (usuario != null)
        {
            retorno = true;
        }
        return retorno;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (preenchido())
        {
            //        Criptografia senha       //
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(txtSenha.Text);
            SHA512Managed SHhash = new SHA512Managed(); string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            //---------------------------

            UsuarioDB bd = new UsuarioDB();
            Usuario usuario = new Usuario();

            usuario = bd.Autentica(txtEmail.Text.ToLower(), strHex);
            if (UsuarioEncontrado(usuario))
            {
                if (usuario.Usu_status_cadastro)
                {
                    if (Convert.ToDateTime(usuario.usu_tempoSuspenso).Hour >= 0 || usuario.usu_tempoSuspenso == null)
                    {
                        Usuario u = new Usuario();
                        u.Usu_email = usuario.Usu_email;
                        u.usu_tentativas = 0;
                        UsuarioDB.UpdateTentativa(u);
                        Session["nome"] = usuario.Usu_nome;
                        Session["cpf"] = usuario.Usu_cpf_cnpj;
                        Session["tipo"] = usuario.Tipo.Tip_codigo;
                        Session["USUARIO"] = usuario;
                        switch (Convert.ToInt32(Session["tipo"]))
                        {
                            case 1:
                                Response.Redirect("/Paginas/ADM/ModerarProdutos.aspx");
                                break;
                            case 2:
                                Response.Redirect("/Paginas/Index.aspx");
                                break;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "desativado();", true);
                }
            }
            else
            {
                int cont = 0;
                DataSet ds = UsuarioDB.SelectEmail(txtEmail.Text);
                cont = ds.Tables[0].Rows.Count;
                if (cont > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["usu_tentativas"].ToString()) < 3)
                    {
                        int qtd = Convert.ToInt32(ds.Tables[0].Rows[0]["usu_tentativas"]);
                        Usuario u = new Usuario();
                        u.usu_tentativas = qtd+1;
                        u.Usu_email = txtEmail.Text;
                        UsuarioDB.UpdateTentativa(u);
                        txtSenha.Focus();
                        txtSenha.Text = "";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Ops!!','Senha incorreta, após mais "+ ( 3 - qtd) + " tentativas a senha será alterada e enviada uma nova senha ao e-mail!','warning')", true);
                    }
                    else
                    {                                               
                        Usuario u = new Usuario();
                        u.usu_tentativas = 0;
                        u.Usu_email = txtEmail.Text;
                        if (UsuarioDB.UpdateTentativa(u) == 0)
                        {
                            string nome = ds.Tables[0].Rows[0]["usu_nome"].ToString();
                            string cpf = ds.Tables[0].Rows[0]["usu_cpf_cnpj"].ToString();
                            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
                            char[] chars = new char[8];
                            Random rd = new Random();
                            for (int i = 0; i < chars.Length; i++)
                            {
                                chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
                            }
                            string senha = new string(chars);

                            //        Criptografia senha       //
                            UnicodeEncoding enc = new UnicodeEncoding();
                            byte[] hv, mb = enc.GetBytes(senha);
                            SHA512Managed shh = new SHA512Managed();
                            string shex = "";
                            hv = shh.ComputeHash(mb);
                            foreach (byte b in hv)
                            {
                                shex += String.Format("{0:x2}", b);
                            }
                           
                            Usuario user = new Usuario();
                            user.Usu_email = txtEmail.Text.ToLower();
                            user.Usu_senha = shex;
                            txtSenha.Text = "";
                            UsuarioDB.UpdateSenha(user);
                            string corpo = "Olá senhor(a) " + nome + "  Sua conta obteve muitas tentativas de acesso, estamos alterando sua senha para sua segurança.</br><strong style='font-size:25px'>" + senha + "</strong>";
                            Email.EnviarEmail(txtEmail.Text, "Alteração de senha", corpo);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Senha alterada!!','Foi enviada uma nova senha para seu email','warning')", true);
                            //----------------------------------------
                        }
                    }
                }
                else
                {
                    txtEmail.Text = "";
                    txtSenha.Text = "";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erro();", true);
                    txtEmail.Focus();
                }
            }
        }
        //----------------------------------------
        else
        {
            lblRecebe.Text = "<br/><br/><br/><br/> <div class='span6 alert alert-warning'><button type=button class='close' data-dismiss='alert'>&times;</button><h4>Ops!</h4>Os campos estão vazios!!</div>";
            if (txtEmail.Text == "")
            {
                txtEmail.Style.Add("Border-Color", "Red");
            }
            else
            {
                txtEmail.Style.Remove("Border-Color");
            }
            if (txtSenha.Text == "")
            {
                txtSenha.Style.Add("Border-Color", "Red");
            }
            else
            {
                txtSenha.Style.Remove("Border-Color");
            }
        }
    }
}