using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_VerificarDenunncias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaDenuncia();
        }
    }
    public void CarregaDenuncia()
    {
        ltlDenuncia.Text = "";
        DataSet ds = new DataSet();
        ds = DenunciaDB.SelectAllDenuncias();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            ltlDenuncia.Text += @" <tr>
                                    <td>
                                        <p>
                                            <input type='checkbox'>                           
                                        </p>
                                    </td>
                                    <td>           
                                        <p>#" + dr["pro_codigo"] + @"</p>";
            if (dr["den_opcao"].ToString() == "1")
            {
                ltlDenuncia.Text += @"<p><strong>Foto irregular</strong></p></td>";

            }
            else if (dr["den_opcao"].ToString() == "2")
            {
                ltlDenuncia.Text += @"<p><strong>Descrição irregular</strong></p></a></td>";
            }

            else if (dr["den_opcao"].ToString() == "3")
            {
                ltlDenuncia.Text += @"<p><strong>produto em categoria errada</strong></p></a></td>";
            }
            ltlDenuncia.Text += @" <td><strong>" + dr["pro_nome"] + @"</strong><br />
                                        <a href='#' style='text-decoration: underline'>
                                            <p><a style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"'>Verificar produto</p></a>
                                   </td>
                                   <td>
                                        <a href='#' id='" + dr["pro_codigo"] + @"' denuncia='" + dr["den_codigo"] + @"' cpf='" + dr["usu_cpf_cnpj"] + @"' class='desativar' data-toggle='tooltip' data-placement='bottom' title='Bloquear produto'><i class='icon-lock'></i></a>
                                   </td>
                                   <td>
                                        <a href='#' id='" + dr["pro_codigo"] + @"' denuncia='" + dr["den_codigo"] + @"' cpf='" + dr["usu_cpf_cnpj"] + @"' class='verifiquei' data-toggle='tooltip' data-placement='bottom' title='Produto verificado'><i class='icon-ok'></i></a>
                                   </td>";
        }
    }
    //Coninuar, produto bloqueado até que o dono altere


    [WebMethod]
    public static string Desativar(string id, string denuncia, string cpf)
    {
        if (ProdutoDB.BloquearProduto(Convert.ToInt32(id)) == 0)
        {
            UsuarioDB db = new UsuarioDB();
            Usuario usuario = db.Select(cpf);
            Mensagem mensagem = new Mensagem();
            mensagem.Men_conteudo = "Olá sr(a) " + usuario.Usu_nome + ",seu produto que havia sido denunciado constava erro, pois ele foi desativado, para que ele fique ativo novamente é necessário que arrume-o.";
            mensagem.Usuario = new Usuario();
            mensagem.Usuario.Usu_cpf_cnpj = cpf;
            mensagem.Produto = new Produto();
            mensagem.Tipo = new Tme_tipo_mensagem();
            mensagem.Tipo.Tme_codigo = 1;
            mensagem.Men_lida = false;
            mensagem.Men_data = Convert.ToDateTime(DateTime.Now);
            mensagem.Produto.Pro_codigo = Convert.ToInt32(id);
            MensagemDB.CadastroProduto(mensagem);
            DenunciaDB.Delete(Convert.ToInt32(denuncia));
            return "s";
        }
        else
        {
            return "n";
        }
    }

    [WebMethod]
    public static string Verificado(string id, string denuncia,string cpf)
    {
        if (DenunciaDB.Delete(Convert.ToInt32(denuncia)) == 0)
        {
            UsuarioDB db = new UsuarioDB();
            Usuario usuario = db.Select(cpf);
            Mensagem mensagem = new Mensagem();
            mensagem.Men_conteudo = "Olá sr(a) "+usuario.Usu_nome+",seu produto que havia sido denunciado foi verificado pelos administradores e não consta erro.";
            mensagem.Usuario = new Usuario();
            mensagem.Usuario.Usu_cpf_cnpj = cpf;
            mensagem.Produto = new Produto();
            mensagem.Tipo = new Tme_tipo_mensagem();
            mensagem.Tipo.Tme_codigo = 1;
            mensagem.Men_lida = false;
            mensagem.Men_data = Convert.ToDateTime(DateTime.Now);
            mensagem.Produto.Pro_codigo = Convert.ToInt32(id);
            MensagemDB.CadastroProduto(mensagem);
            return "s";
        }
        else
        {
            return "n";
        }
    }

}