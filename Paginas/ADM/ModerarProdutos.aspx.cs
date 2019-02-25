using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_ModerarProdutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarLabel();
    }

    private void CarregarLabel()
    {
        System.Data.DataSet ds = ProdutoDB.SelectProdutosModerar();
        //FotosDB db = new FotosDB();
        lblDinamica.Text = "";
        string msg = "Sem reputação";
        bool flag = true;
        int rep = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            //calculo rep
            if (dr["usu_reputacao"].ToString() != "0")
            {
                DataSet dsR = ItemDB.SelectQuantidadeAvaliacoes(dr["usu_cpf_cnpj"].ToString());
                int reps = dsR.Tables[0].Rows.Count;
                if (Convert.ToDouble(dr["usu_reputacao"]) > 0)
                {
                    rep = Convert.ToInt32(Convert.ToDouble(dr["usu_reputacao"]) / reps);
                }
                else
                {
                    rep = 1;
                }

            }
            else
            {
                flag = false;
            }
            lblDinamica.Text += @"<table class='table table-striped table-hover' style='background-color:blue!important'>
									<tbody>                                      
										<tr>       
											<td class='span2'>
												<img src='" + dr["foto"] + @"' style='width: 130px!important; height: 130px!important' />
											</td>
											<td class='span4'>
                                                <a href='VisualizarProduto.aspx?id=" + dr["pro_codigo"] + @"'  >
												    <strong>Informações do Produto </strong><br/>
												    <strong>Nome:</strong> " + dr["pro_nome"] + @" <br/>
												    <strong>Descrição:</strong>" + dr["descricao"] + @"...<br/>
												    <strong>Quantidade:</strong> " + dr["pro_quantidade"] + @"<br/>
												    <strong>Preço:</strong> " + dr["pro_preco"] + @"
                                                </a>
											</td>
											<td class='span4'>
                                                 <a href='VisualizarProduto.aspx?id=" + dr["pro_codigo"] + @"'  >
												    <strong>Usuário: </strong>" + dr["usu_nome"] + @"<br/>";

            
            if (flag)
            {
                lblDinamica.Text += @"<strong>Reputação:</strong> <br/><div class='progress progress-striped active'>";
                if (rep >= 65)
                {
                    lblDinamica.Text += @"<div class='bar bar-success' style='width: " + rep + @"%; color:#11F075!important;'></div>";
                }
                if (rep >= 35 && rep < 65)
                {
                    lblDinamica.Text += @"<div class='bar bar-warning' style='width: " + rep + @"%;color:#'></div>";
                }
                if (rep > 0 && rep < 35)
                {
                    lblDinamica.Text += @"<div class='bar bar-danger' style='width: " + rep + @"%;color:#'></div>";
                }

                lblDinamica.Text += @"</div>";
                //lblvendedor.Text += @"<span Class='rep-ven'>Reputação: " + rep + @" </span>";
            }
            else
            {
                lblDinamica.Text += @"<strong>Reputação:</strong> " + msg + @" ";
            }

            lblDinamica.Text += @" <strong>Marca:</strong>" + dr["marca"] + @"
                                                </a>
											</td>
											<td>
                                                <a class='validarProdutoVenda' href='#' nome='" + dr["usu_nome"] + @"' rel='" + dr["pro_codigo"] + @"' id='" + dr["usu_cpf_cnpj"] + @"' data-toggle='tooltip' style='color:green' data-placement='bottom' title='Aprovar'><i class='icon-ok' style='color:green' ></i></a>
											</td>
											<td>
												<a class='NaoAceito' href='#' nome='" + dr["usu_nome"] + @"' rel='" + dr["pro_codigo"] + "' id='" + dr["usu_cpf_cnpj"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Reprovar'><i class='icon-remove'></i></a>
											</td>
										</tr>                                      
									</tbody>
								</table>";
        }
    }
    [WebMethod]
    public static string Modera(string codigo, string cpf, string nome)
    {
        if (ProdutoDB.AceitarModeracao(Convert.ToInt32(codigo)) == 0)
        {
            Mensagem m = new Mensagem();
            m.Men_conteudo = "Sr(a) " + nome + ", seu produto foi aprovado no sistema.";
            m.Men_data = DateTime.Now;
            m.Men_lida = false;
            m.Usuario = new Usuario();
            m.Usuario.Usu_cpf_cnpj = cpf;
            m.Tipo = new Tme_tipo_mensagem();
            m.Tipo.Tme_codigo = 5;
            m.Produto = new Produto();
            m.Produto.Pro_codigo = Convert.ToInt32(codigo);
            MensagemDB.CadastroProduto(m);
            return "s";
        }
        else
        {
            return "n";
        }
    }

    [WebMethod]
    public static string Recusado(string codigo, string cpf, string nome)
    {
        if (ProdutoDB.ProdutoNaoAceito(Convert.ToInt32(codigo)) == 0)
        {
            Mensagem m = new Mensagem();
            m.Men_conteudo = "Sr(a) " + nome + ", seu produto não foi aprovado no sistema, modifique-o para uma nova moderação";
            m.Men_data = DateTime.Now;
            m.Men_lida = false;
            m.Usuario = new Usuario();
            m.Usuario.Usu_cpf_cnpj = cpf;
            m.Tipo = new Tme_tipo_mensagem();
            m.Tipo.Tme_codigo = 6;
            m.Produto = new Produto();
            m.Produto.Pro_codigo = Convert.ToInt32(codigo);
            MensagemDB.CadastroProduto(m);
            return "s";
        }
        else
        {
            return "n";
        }
    }

   

}
