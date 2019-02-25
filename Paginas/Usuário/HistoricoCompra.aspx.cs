using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_HistoricoCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MinhasCompras();
        }
    }

    public void MinhasCompras()
    {
        ltlCompras.Text = "";
        DataSet ds = new DataSet();
        if (Session["cpf"] != null)
        {
            ds = CompraDB.SelectMinhasCompras(Session["cpf"].ToString());
        }
        else
        {
            Response.Redirect("/Paginas/Login.aspx");
        }
        DateTime data = new DateTime();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["ite_status"].ToString() == "3" || dr["ite_status"].ToString() == "4")
            {
                data = Convert.ToDateTime(dr["com_data"]);
                ltlCompras.Text += @"<tr>                                    
                                        <td class='span3'><a href='#'>
                                            <img alt='' src='" + dr["foto"] + @"' class='img-carrinho' /></a></td>
                                        <td><strong>" + dr["pro_nome"] + @"</strong>  <br />
                                            <strong>Quantidade:</strong> " + dr["ite_quantidade"] + @"<br />
                                            <strong>Data Compra:</strong>" + data.ToShortDateString() + @"<br />
                                            <strong>Valor da compra:</strong> " + String.Format("{0:0.00}", dr["pro_preco"]) + @"<br/>";
                
                if (dr["ite_status"].ToString() == "3")
                {
                    ltlCompras.Text += @"<strong>Situação:</strong> Produto entregue<br/>";
                }
                else
                {
                    ltlCompras.Text += @"<strong>Situação:</strong> Compra cancelada<br/>";
                }
                if (Convert.ToBoolean(dr["ite_avaliacao"]) == false)
                {
                    ltlCompras.Text += @"<br/><a class='botaoPadraoPERFIL' href='/Paginas/Usuário/AvaliarVendedor.aspx?id=" + dr["pro_codigo"] + @"&com_id=" + dr["com_codigo"] + @"&id_vendedor="+dr["cpf_vend"]+@"&it_status="+dr["ite_status"]+@"' data-toggle='tooltip' data-placement='bottom' title ='Avaliar vendedor'>Avaliar vendedor</a><br/>";
                }
                ltlCompras.Text += @"</td>
                                    <td>
                                        <strong> Endereço de entrega:</strong><br>
                                        <strong> Cep: </strong>" + dr["end_cep"] + @"<br/>                                        
                                        <strong> Rua: </strong> " + dr["end_endereco"]+ @"<br/>
                                        <strong> Estado: </strong>"+dr["end_estado"]+ @"<br/>
                                        <strong> Cidade: </strong>" + dr["end_cidade"] + @"<br/>
                                        <strong> Bairro: </strong>" + dr["end_bairro"] + @"<br/>
                                    </td>
                                    </tr>";
            }

        }
        //if (dr["com_status"].ToString() != "3" && dr["com_status"].ToString() != "4")
    }
}