using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_EsqueceuSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        DataSet ds = UsuarioDB.SelectEmail(txtEmail.Text);
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd > 0)
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
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(senha);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            //----------------------------------------

            string corpo = "Olá senhor(a) " + nome + "  esta é sua nova senha para acesso ao Garimpo</br><strong style='font-size:25px'>" + senha + "</strong>";
            Email.EnviarEmail(txtEmail.Text, "Recuperação de senha", corpo);

            Usuario usuario = new Usuario();
            usuario.Usu_email = txtEmail.Text.ToLower();
            usuario.Usu_senha = strHex;

            Mensagem mensagem = new Mensagem();
            mensagem.Men_conteudo = "Olá Sr(a) " + nome + " notamos que você precisou recuperar a senha, recomendamos que mude a senha a seu gosto";
            mensagem.Men_data = DateTime.Now;
            mensagem.Men_lida = false;
            mensagem.Usuario = new Usuario();
            mensagem.Usuario.Usu_cpf_cnpj = cpf;
            MensagemDB.MensagemCadastro(mensagem);

            UsuarioDB.UpdateSenha(usuario);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Pronto!!','Foi enviada uma senha para seu email','success')", true);
            txtEmail.Text = "";
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','E-mail não cadastrado','error')", true);
        }
    }
}