using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuário_AvaliarVendedor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("/Paginas/Erros/Erro404.aspx");
        }
        else
        {
            if (Request.QueryString["it_status"].ToString() == "3")
            {
                ltlMensagem.Text = @"<div class='span11 center'><p class='lead' style='color:green'>Percebemos que seu produto foi entregue</p></div>";
                pnlInicial.Visible = false;
                pnlNRecebeu.Visible = false;
                pnlRecebeu.Visible = true;
            }
        }
    }

    protected void btnRecebi_Click(object sender, EventArgs e)
    {
        pnlRecebeu.Visible = true;
        pnlNRecebeu.Visible = false;
    }

    protected void btnNaoRecebi_Click(object sender, EventArgs e)
    {
        pnlRecebeu.Visible = false;
        pnlNRecebeu.Visible = true;
    }
    protected void btnRecebeu_Click(object sender, EventArgs e)
    {
        if (rbtMensagens.SelectedIndex != -1 && rbtPrazo.SelectedIndex != -1 && rbtConfere.SelectedIndex != -1)
        {
            double soma = 0.00;
            soma += Convert.ToDouble(rbtMensagens.SelectedItem.Value) + Convert.ToDouble(rbtPrazo.SelectedItem.Value) + Convert.ToDouble(rbtConfere.SelectedItem.Value);
            double total = 0.00;
            total = Math.Round((soma / 3), 2);

            Item i = new Item();
            i.Ite_avaliacao = true;
            i.Produto = new Produto();
            i.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
            i.Compra = new Compra();
            i.Compra.Com_codigo = Convert.ToInt32(Request.QueryString["com_id"]);
            ItemDB.UpdateAvaliacao(i);

            UsuarioDB db = new UsuarioDB();
            Usuario usu = db.Select(Request.QueryString["id_vendedor"]);
       
            Usuario u = new Usuario();
            u.Usu_reputacao = usu.Usu_reputacao + total;
            u.Usu_qtdd_vendas = usu.Usu_qtdd_vendas + 1;
            u.Usu_cpf_cnpj = Request.QueryString["id_vendedor"];
            UsuarioDB.UpdateVendas(u);
            if (UsuarioDB.UpdateRep(u) == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "feedback();", true);

            }
        }
    }
    protected void btnNRecebeu_Click(object sender, EventArgs e)
    {
        if (rbtNrecebeu.SelectedIndex != -1)
        {
            int total = Convert.ToInt32(rbtNrecebeu.SelectedItem.Value);

            Item i = new Item();
            i.Ite_avaliacao = true;
            i.Produto = new Produto();
            i.Produto.Pro_codigo = Convert.ToInt32(Request.QueryString["id"]);
            i.Compra = new Compra();
            i.Compra.Com_codigo = Convert.ToInt32(Request.QueryString["com_id"]);
            ItemDB.UpdateAvaliacao(i);
            UsuarioDB db = new UsuarioDB();
            Usuario usu = db.Select(Request.QueryString["id_vendedor"]);
            Usuario usuario = db.Select(Session["cpf"].ToString());

            Usuario u = new Usuario();
            u.Usu_reputacao = usu.Usu_reputacao + total;
            u.Usu_qtdd_vendas = usuario.Usu_qtdd_vendas + 1;
            u.Usu_cpf_cnpj = Request.QueryString["id_vendedor"];
            UsuarioDB.UpdateVendas(u);

            if (UsuarioDB.UpdateRep(u) == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "feedback();", true);

            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Selecione uma das opções','error')", true);
        }

    }


}