using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Cadastro_ConcluirCadastro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["cpf"] != null)
        {
            UsuarioDB db = new UsuarioDB();
            Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));

            DataSet ds = EnderecoDB.SelectAll(Session["cpf"].ToString());
            int qtd = ds.Tables[0].Rows.Count;

            string telefone = usuario.Usu_telefone;
            string dataNascimento = Convert.ToString(usuario.Usu_data_nasc);
            string sexo = usuario.Usu_sexo;

            if (telefone != "" && dataNascimento != "" && sexo != "")
            {
                pnlDados.Visible = false;
                btnFinalizar.Visible = false;
                btnConcluir.Visible = true;
            }

            lblNome.Text = usuario.Usu_nome;
            lblEmail.Text = usuario.Usu_email;
            lblCpf.Text = usuario.Usu_cpf_cnpj;           
            rblSexo.SelectedValue = usuario.Usu_sexo;  
            
            if (qtd>0)
            {
                pnlEndereco.Visible = false;
                btnDados.Visible = true;
            }
            else
            {
                pnlEndereco.Visible = true;
            }         
        }
        else
        {
            Response.Redirect("/Paginas/Erros/ErroLogin.aspx");
        }               
    }
    protected void btnConcluir_Click(object sender, EventArgs e)
    {
        Endereco end = new Endereco();       
        end.End_cep = txtCep.Text;
        end.End_estado = txtEstado.Text;
        end.End_cidade = txtCidade.Text;
        end.End_bairro = txtBairro.Text;
        end.End_numero = Convert.ToInt32(txtNumero.Text);
        end.End_endereco = txtEndereco.Text;
        if (txtReferencia.Text != "")
        {
            end.End_referencia = txtReferencia.Text;
        }
        else
        {
            end.End_referencia = "";
        }
        end.End_referencia = txtReferencia.Text;
        end.Usuario = new Usuario();
        end.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
        if (EnderecoDB.InsertEndereco(end) == 0)
        {
            //string script = "alert('Maravilha');";
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            Response.Redirect("/Paginas/Index.aspx");
        }
        else
        {
            string script = "alert('Deu ruim');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }
        
    }

    protected void btnDados_Click(object sender, EventArgs e)
    {
        Usuario u = new Usuario();
        u.Usu_nome = lblNome.Text;
        u.Usu_email = lblEmail.Text;
        u.Usu_cpf_cnpj = lblCpf.Text;
        u.Usu_sexo = rblSexo.SelectedValue;
        u.Usu_telefone = txtTelefone.Text;
        u.Usu_data_nasc = Convert.ToDateTime(txtDataNascimento.Text);

        if (UsuarioDB.Update(u) == 0)
        {
            string script = "alert('Maravilha');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }
        else
        {
            string script = "alert('ops');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        }

    }
    public void limparEnderelo()
    {
        txtCep.Text = "";
        txtEstado.Text = "";
        txtCidade.Text = "";
        txtBairro.Text = "";
        txtNumero.Text = "";
        txtEndereco.Text = "";
        txtReferencia.Text = "";
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
        //-------
        //Inserindo foto  
        string cpf = Session["cpf"].ToString();
        string caminhoFoto = "";
        string dir = Request.PhysicalApplicationPath + "\\FotosPerfis\\usuarios\\" + cpf + "\\";           
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (flpArquivo.HasFile)
        {
            string ext = Path.GetExtension(flpArquivo.FileName).ToLower();
            if (ext == ".jpg" || ext == ".png" || ext == ".jfif")
            {
                double tamanho = flpArquivo.PostedFile.ContentLength / 1024;
                if (tamanho <= 4000)
                {
                    string nomeArquivo = DateTime.Now.ToString("ddMMyyyymmssfff") + ext;
                    flpArquivo.SaveAs(dir + nomeArquivo);
                    caminhoFoto = "\\FotosPerfis\\usuarios\\" + cpf + "\\" + nomeArquivo;
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
        else
        {
            caminhoFoto = "../../themes/images/FOTOPERFIL/este.gif";
        }     
        
        Usuario usuario = new Usuario();
        usuario.Usu_sexo = rblSexo.SelectedValue;
        //verificando se já existe o telefone
        DataSet ds = UsuarioDB.SelectTelefone(txtTelefone.Text);
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "swal('Ops', 'Este telefone já está vinculado a uma conta', 'warning')", true);
            txtTelefone.Text = "";
            txtTelefone.Focus();
            pnlDados.Visible = true;
        }
        else
        {
            usuario.Usu_telefone = txtTelefone.Text;
            usuario.Usu_data_nasc = Convert.ToDateTime(txtDataNascimento.Text);
            usuario.Usu_foto_perfil = caminhoFoto;
            usuario.Usu_cadastroCompleto = 2;

            Endereco end = new Endereco();
            //Usuario usuario = new Usuario();
            usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
            end.End_cep = txtCep.Text;
            end.End_estado = txtEstado.Text;
            end.End_cidade = txtCidade.Text;
            end.End_bairro = txtBairro.Text;
            end.End_numero = Convert.ToInt32(txtNumero.Text);
            end.End_endereco = txtEndereco.Text;
            if (txtReferencia.Text != "")
            {
                end.End_referencia = txtReferencia.Text;
            }
            else
            {
                end.End_referencia = "";
            }
            end.End_referencia = txtReferencia.Text;
            end.Usuario = new Usuario();
            end.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();

            if (EnderecoDB.InsertEndereco(end) == 0)
            {
                Mensagem mensagem = new Mensagem();
                mensagem.Men_conteudo = "Você finalizou o cadastro Sr(a) " + usuario.Usu_nome + " no Garimpo, agora você pode comprar e vender";
                mensagem.Men_data = DateTime.Now;
                mensagem.Men_lida = false;
                mensagem.Usuario = new Usuario();
                mensagem.Usuario = new Usuario();
                mensagem.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
                mensagem.Tipo = new Tme_tipo_mensagem();
                mensagem.Tipo.Tme_codigo = 1;
                MensagemDB.MensagemCadastro(mensagem);
                UsuarioDB.UpdateUsuarioCompleto(usuario);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "finalizado();", true);
            }
        }       
    }   
}