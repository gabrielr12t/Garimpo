using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_CaixaMensagem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cpf"] != null)
        {
            UsuarioDB db = new UsuarioDB();
            Usuario usuario = db.Select(Convert.ToString(Session["cpf"]));
            CarregarLabel();
            MesagemLida();
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
    }

    private void CarregarLabel()
    {
        DataSet ds = MensagemDB.Select(Session["cpf"].ToString());
        int qnt = ds.Tables[0].Rows.Count;
        lblDinamica.Text = "";
        ltlThMensagem.Text = "";
        //style='background-color:#eeeeee' 
        if (qnt > 0)
        {
            ltlThMensagem.Text = @"<th></th>
                <th>Tipo da Mensagem</th>
                <th>Conteúdo</th>
                <th>data</th>
                <th>Remover</th>";
        }
        else
        {
            ltlThMensagem.Text = "";
        }
        if (qnt > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["men_visivel"].ToString() != "0")
                {
                    if (Convert.ToBoolean(dr["men_lida"]) == false)
                    {

                        lblDinamica.Text += @"<tr class='block' style='background-color:#f3f1fa'>
                                                    <td class='linha-vertical'>
                                                       <input type = 'checkbox'>
                                                    </td>
                                                    <td class='span3 linha-vertical'>
                                                        <strong>" + dr["tme_codigo"] + @"</strong>
                                                    </td>
                                                    <td class='span8 linha-vertical'>";
                        if (dr["tme_codigo"].ToString().Equals("Equipe Garimpo"))
                        {
                            lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Visualizar mensagem' onclick='return false;' class='visualizar' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Visualizar' data-toggle='modal'>" + dr["men_conteudo"] + @"</a>
                                                            <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"' data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'></a>
                                                     </td>
                                                     <td class='span2 linha-vertical'>
                                                     " + dr["men_data"] + @"                    
                                                    </td>" +
                                                              "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                                          "</tr>";
                        }
                        else
                        {
                            if (dr["men_cpf_pergunta"].ToString() != "" && dr["men_respondida"].ToString() == "")
                            {
                                lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Responder Pergunta' onclick='return false;' class='responder' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + dr["usu_cpf_cnpj"] + "|" + dr["men_cpf_pergunta"] + "|" + dr["men_pergunta_codigo"] + "|" + dr["pro_codigo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Responder Pergunta'> " + dr["men_conteudo"] + "" +
                                                                 " <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"' data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'><i class='fa fa-question fa-1x'></i></a>
                                                     </td>
                                                     <td class='span2 linha-vertical'>
                                                      " + dr["men_data"] + @"
                                                    </td>
                                                 <td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>
                                             </tr>";
                            }
                            else
                            {
                                if (dr["men_respondida"].ToString() != "")
                                {
                                    lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Visualizar mensagem' onclick='return false;' class='visualizar' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Visualizar' data-toggle='modal'>" + dr["men_conteudo"] + @"</a>
                                                            <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"'  data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'><i class='fa fa-check fa-1x'></i></a>
                                                     </td>
                                                     <td class='span2 linha-vertical'>
                                                     " + dr["men_data"] + @"                    
                                                    </td>" +
                                                             "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                                         "</tr>";
                                }
                                else
                                {
                                    lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Visualizar mensagem' onclick='return false;' class='visualizar' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Visualizar' data-toggle='modal'>" + dr["men_conteudo"] + @"</a>
                        			                                <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"'  data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'><i class='fa fa-check fa-1x'></i></a>
                                                                 </td>
                                                                 <td class='span2 linha-vertical'>
                                                                 " + dr["men_data"] + @"                    
                                                                </td>" +
                                                             "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                                         "</tr>";
                                }
                            }
                        }
                    }
                    else
                    {
                        lblDinamica.Text += @"<tr class='block'>
                                                    <td class='linha-vertical'>
                                                       <input type = 'checkbox'>
                                                    </td>
                                                    <td class='span3 linha-vertical'>
                                                        <strong>" + dr["tme_codigo"] + @"</strong>
                                                    </td>
                                                    <td class='span8 linha-vertical'>";
                        if (dr["tme_codigo"].ToString().Equals("Equipe Garimpo") || dr["tme_codigo"].ToString().Equals("Produto atualizado"))
                        {
                            lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Visualizar mensagem' onclick='return false;' class='visualizar' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Visualizar' data-toggle='modal'>" + dr["men_conteudo"] + @"</a>
                                                            <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"'  data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'></a>
                                                     </td>
                                                     <td class='span2 linha-vertical'>
                                                     " + dr["men_data"] + @"                    
                                                    </td>" +
                                                             "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                                         "</tr>";
                        }
                        else
                        {
                            if (dr["men_cpf_pergunta"].ToString() != "" && dr["men_respondida"].ToString() == "")
                            {
                                lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Responder Pergunta' onclick='return false;' class='responder' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + dr["usu_cpf_cnpj"] + "|" + dr["men_cpf_pergunta"] + "|" + dr["men_pergunta_codigo"] + "|" + dr["pro_codigo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Responder Pergunta'> " + dr["men_conteudo"] + "" +
                                                             " <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"' data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'><i class='fa fa-question'></a>" +
                                                          "</td>" +

                                                          "<td class='span2 linha-vertical'>" +
                                                          " " + dr["men_data"] + @"                    
                                                </td>" +
                                                          "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                                      "</tr>";
                            }
                            else
                            {
                                if (dr["men_respondida"].ToString() != "")
                                {
                                    lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Visualizar mensagem' onclick='return false;' class='visualizar' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Visualizar' data-toggle='modal'>" + dr["men_conteudo"] + @"</a>
            		          <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"'  data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'><i class='fa fa-check fa-1x'></i></a>" +
                                            "</td>" +
                                            "<td class='span2 linha-vertical'>" +
                                            " " + dr["men_data"] + @"                    
                                     </td>" +
                                            "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                        "</tr>";
                                }
                                else
                                {
                                    lblDinamica.Text += @"<a href='#' data-toogle='tooltip' data-placement='bottom' title='Visualizar mensagem' onclick='return false;' class='visualizar' rel ='" + dr["men_codigo"] + "|" + dr["men_conteudo"] + "|" + @" data-toogle='tooltip' data-placement='bottom' title='Visualizar' data-toggle='modal'>" + dr["men_conteudo"] + @"</a>
        		                                    <a class='pull-right' style='text-decoration:underline' href='/Paginas/Produtos/Produto.aspx?id=" + dr["pro_codigo"] + @"&sub=" + dr["sub_codigo"] + @"&cpf=" + dr["usu_cpf_cnpj"] + @"'  data-toogle='tooltip' data-placement='bottom' title='Visualizar produto'><i class='fa fa-check fa-1x'></i></a>
                                                 </td>
                                                 <td class='span2 linha-vertical'>" +
                                                              " " + dr["men_data"] + @"                    
                                                 </td>" +
                                                              "<td class='center'><a href='#' class='excluirMensagem' id='" + dr["men_codigo"] + @"' data-toggle='tooltip' data-placement='bottom' title='excluir mensagem'><i class='fa fa-trash fa-1x'></i></a></td>" +
                                                          "</tr>";
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            lblDinamica.Text += @"<div class='alert'>
                                      <button type='button' class='close' data-dismiss='alert'>&times;</button>
                                      <strong>Warning!</strong> Sem Mensagens.
                                    </div>";
        }
    }


    //excluir mensagem
    [WebMethod]
    public static string Exclui(string cod)
    {
        int id = Convert.ToInt32(cod);
        Mensagem m = new Mensagem();
        m.Men_codigo = id;
        if (MensagemDB.UpdateMensagemVisivel(m) == true)
        {
            return "s";
        }
        else
        {
            return "n";
        }
    }

    public void MesagemLida()
    {
        Mensagem mensagem = new Mensagem();
        mensagem.Usuario = new Usuario();
        mensagem.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
        mensagem.Men_lida = true;
        MensagemDB.UpdateMensagemLida(mensagem);
    }


    protected void btnEnv_Click(object sender, EventArgs e)
    {
        Mensagem m = new Mensagem();
        m.Men_conteudo = txtResposta.Text;
        m.Men_data = DateTime.Now;
        m.Men_lida = false;
        m.Usuario = new Usuario();
        m.Usuario.Usu_cpf_cnpj = txtCpfPergunta.Value;
        m.Produto = new Produto();
        m.Produto.Pro_codigo = Convert.ToInt32(txtCodigoProduto.Value);
        m.Tipo = new Tme_tipo_mensagem();
        m.Tipo.Tme_codigo = 3;
        m.Men_pergunta_codigo = txtPerguntaCodigo.Value;

        if (MensagemDB.InsertMensagemParaComprador(m) == 0)
        {
            Mensagem m1 = new Mensagem();
            m1.Men_codigo = Convert.ToInt32(txtCodigo.Value);
            m1.Men_respondida = true;
            MensagemDB.MensagemRespondida(m1);
            CarregarLabel();
        }

    }
}

