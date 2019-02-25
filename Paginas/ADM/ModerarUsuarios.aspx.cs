using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_ADM_ModerarUsuarios : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaUsers();
        }
        //if (!Page.IsPostBack)
        //{
        //    txtBuscar.Focus();
        //    CarregaGrid("");            
        //}        
    }
    public void CarregaUsers()
    {

        UsuarioDB bd = new UsuarioDB();
        DataSet ds = UsuarioDB.SelectAllg();
        ltlUsers.Text = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            ltlUsers.Text += @"<tr>
                                        <td class='span3'>
                                            <a href='/Paginas/Usuário/PáginaVendedor.aspx?cpf=" + dr["usu_cpf_cnpj"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Visualizar perfil do usuário' ><img alt='' src='" + dr["usu_foto_perfil"] + @"' class='fotoPerfilGrande' /></a>
                                        </td>
                                        <td class='span4'><strong> " + dr["usu_nome"] + @"</strong><br />
                                            " + dr["usu_cpf_cnpj"] + @"
                                            <br />
                                            " + dr["usu_email"] + @"
                                        </td>
                                        <td class='span3'>
                                            " + dr["tip_codigo"] + @"                                            
                                        </td>
                                       <!-- <td class='span3'>
                                            <strong>Status: </strong> " + dr["usu_status_cadastro"] + @"                                                
                                        </td> -->                                     
                                        <td class='span3'>";
            if (dr["usu_cpf_cnpj"].ToString() != "1")
            {


                if (dr["usu_status_cadastro"].ToString() == "Ativo")
                {
                    ltlUsers.Text += @"<label data-toggle='tooltip' data-placement='bottom' title ='Desativar usuário'  class='switch'>
                                      <input cpf='" + dr["usu_cpf_cnpj"] + @"' class='desativar' onclick='this.form.submit()' type='checkbox' checked>
                                      <span class='slider round'></span>
                                    </label>";
                }
                else
                {
                    ltlUsers.Text += @"<label data-toggle='tooltip' data-placement='bottom' title ='Ativar usuário'  class='switch'>
                                      <input cpf='" + dr["usu_cpf_cnpj"] + @"' class='ativar' onclick='this.form.submit()' type='checkbox'>
                                      <span class='slider round'></span>
                                    </label>";
                }
                ltlUsers.Text += @"</td>";
                if (!(dr["tip_codigo"].ToString().Equals("Administrador")))
                {
                    ltlUsers.Text += @"<td><a href='#' cpf='" + dr["usu_cpf_cnpj"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Tornar usuário Administrador' class='adicionar'><i class='fa fa-plus'/></a></td>";
                }
                else
                {
                    ltlUsers.Text += @"<td><a href='#' cpf='" + dr["usu_cpf_cnpj"] + @"' data-toggle='tooltip' data-placement='bottom' title ='Remover privilégio de Administrador' class='remover'><i class='fa fa-remove'/></a></td>";
                }
            }
            ltlUsers.Text += @"</tr>";



        }
    }

    [WebMethod]
    public static string Desativar(string cpf)
    {
        if (UsuarioDB.DesativarUser(cpf) == 0)
        {
            DataSet ds = ProdutoDB.SelectAllCPFProdutosAtivo(cpf);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ProdutoDB.Desativar(Convert.ToInt32(dr["pro_codigo"]));
            }
            return "s";
        }
        else
        {
            return "n";
        }
    }
    [WebMethod]
    public static string Ativar(string cpf)
    {
        if (UsuarioDB.AtivarUser(cpf) == 0)
        {
            return "s";
        }
        else
        {
            return "n";
        }
    }
    [WebMethod]
    public static string Adicionar(string cpf)
    {
        if (UsuarioDB.AdicionarAdministrador(cpf) == 0)
        {
            return "s";
        }
        else
        {
            return "n";
        }
    }
    [WebMethod]
    public static string Remover(string cpf)
    {
        if (UsuarioDB.RemoverAdministrador(cpf) == 0)
        {
            return "s";
        }
        else
        {
            return "n";
        }
    }  
    protected void btnNomes_Click(object sender, EventArgs e)
    {
        string termo = txtBuscar.Text.Trim();
        if (termo != string.Empty)
        {
            CarregaUsers();
        }
        else
        {
            CarregaUsers();
            txtBuscar.Focus();
        }
    }


    
}