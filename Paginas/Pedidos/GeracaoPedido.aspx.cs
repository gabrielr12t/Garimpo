using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Pedidos_GeracaoPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpCookie cookie = null;
        if (Request.Cookies["produtos"] != null)
        {
            cookie = Request.Cookies["produtos"];
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CarrinhoVazio();", true);
        }
        if (Session["cpf"] == null)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "NaoLogado();", true);
        }
        else
        {
            if (!Page.IsPostBack)
            {
                CarregaFormaEnvio();
                CarregaCliente();
                CarregaFormaPagamento();
            }
        }
    }
    public void CarregaFormaEnvio()
    {
        //Carregar um DropdownList com o banco de dados
        DataSet ds = FormasEnvioDB.SelectAll();
        ddlFormaEnvio.DataSource = ds;
        //nome da coluna do banco de dados;
        ddlFormaEnvio.DataTextField = "env_nome";
        //ID da coluna do Banco
        ddlFormaEnvio.DataValueField = "env_codigo";
        ddlFormaEnvio.DataBind();
        ddlFormaEnvio.Items.Insert(0, "Selecione");
    }
    public void CarregaFormaPagamento()
    {
        //Carregar um DropdownList com o banco de dados
        DataSet ds = FormaPagamentoDB.SelectAll();
        ddlFormaPagamento.DataSource = ds;
        //nome da coluna do banco de dados;
        ddlFormaPagamento.DataTextField = "for_pagamento";
        //ID da coluna do Banco
        ddlFormaPagamento.DataValueField = "for_codigo";
        ddlFormaPagamento.DataBind();
        ddlFormaPagamento.Items.Insert(0, "Selecione");
    }
    public void CarregaCliente()
    {
        DataSet ds = UsuarioDB.SelectUsuarioComEndereco(Session["cpf"].ToString());
        int qtd = ds.Tables[0].Rows.Count;
        ltlCliente.Text = "";
        if (qtd > 0)
        {
            ltlCliente.Text = @"<div class=col-lg-11>
                                <strong>Nome: </strong> " + ds.Tables[0].Rows[0]["usu_nome"] + @"
                                <br />
                                <strong>E-mail:</strong>  " + ds.Tables[0].Rows[0]["usu_email"] + @"
                                <br />
                                <strong>Telefone: </strong>" + ds.Tables[0].Rows[0]["usu_telefone"] + @"
                                <br />
                                <br />
                            </div>";
            rbtEnd.Items.Clear();
            rbtEnd.DataSource = ds.Tables[0].DefaultView;
            rbtEnd.DataTextField = "endereco";
            //rbtEnd.DataTextFormatString =texto;
            rbtEnd.DataValueField = "end_codigo";
            rbtEnd.DataBind();

        }
        else
        {
            //semEndereco
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "cadastroImcompleto();", true);
        }


    }
    public bool IsCheck(string id)
    {
        bool retorno = false;
        if (id != string.Empty)
        {
            retorno = true;
        }
        return retorno;
    }
    public bool IsValidEnvio(string id)
    {
        bool retorno = false;
        if (id != "Selecione")
        {
            retorno = true;
        }
        return retorno;
    }
    public bool IsValidPagamento(string id)
    {
        bool retorno = false;
        if (id != "Selecione")
        {
            retorno = true;
        }
        return retorno;
    }




    static string[] cpfVendedor;
    static string[] id;
    static string[] qtd;
    static string t = "";
    static bool quantidade = true;



    [WebMethod]
    public static string Finalizar(string[] cod, string[] qtde, string[] cpf, string total)
    {
        id = new string[cod.Length];
        qtd = new string[cod.Length];
        cpfVendedor = new string[cod.Length];
        t = total;
        DataSet ds;
        for (int i = 0; i < cod.Length; i++)
        {
            ds = ProdutoDB.SelectQuantidade(Convert.ToInt32(cod[i]));
            int quantidadeBanco = Convert.ToInt32(ds.Tables[0].Rows[0]["pro_quantidade"]);

            id[i] = cod[i];
            qtd[i] = qtde[i];
            cpfVendedor[i] = cpf[i];
            if (Convert.ToInt32(qtd[i]) < 0)
            {
                quantidade = false;
            }
            if (Convert.ToInt32(qtd[i]) > quantidadeBanco)
            {
                quantidade = false;
            }
        }
        return "s";
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {

        if (rbtEnd.SelectedValue != "")
        {
            if (ddlFormaEnvio.SelectedValue != "Selecione")
            {
                if (ddlFormaPagamento.SelectedValue != "Selecione")
                {
                    if (ckbAceitar.Checked)
                    {

                        if (quantidade)
                        {
                            DateTime hoje = DateTime.Now;
                            Compra c = new Compra();
                            c.Com_data = hoje;
                            c.Com_valor_total = Convert.ToDouble(t);
                            c.Usuario = new Usuario();
                            c.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
                            c.Endereco = new Endereco();
                            c.Endereco.End_codigo = Convert.ToInt32(rbtEnd.SelectedValue);
                            c.Envio = new Env_forma_envio();
                            c.Envio.Env_codigo = Convert.ToInt32(ddlFormaEnvio.SelectedValue);
                            c.Forma_pagamento = new Forma_pagamento();
                            c.Forma_pagamento.For_codigo = Convert.ToInt32(ddlFormaPagamento.SelectedValue);
                            if (CompraDB.Insert(c) == 0)
                            {
                                UsuarioDB dbu = new UsuarioDB();
                                Usuario u = dbu.Select(Session["cpf"].ToString());
                                Email.EnviarEmail(u.Usu_email, "Compra efetuada no Garimpo", "Olá senhor " + u.Usu_nome + @" sua compra no Garimpo foi efetuata com sucesso tendo um prazo de 12 dias para entrega, Valor total de R$" + t + @".");
                                CompraDB db = new CompraDB();
                                Compra compra = db.SelectCompra(Convert.ToString(Session["cpf"]));
                                int idCompra = compra.Com_codigo;
                                ProdutoDB pDb = new ProdutoDB();

                                //atualizar compra usuario
                                Usuario usu = new Usuario();
                                usu.Usu_cpf_cnpj = Session["cpf"].ToString();
                                usu.Usu_qtdd_compras = u.Usu_qtdd_compras + id.Length;
                                UsuarioDB.UpdateCompras(usu);

                                for (int j = 0; j < qtd.Length; j++)
                                {
                                    Produto p = pDb.SelectIDQuantidade(Convert.ToInt32(id[j]));
                                    Item it = new Item();
                                    it.Compra = new Compra();
                                    it.Compra.Com_codigo = idCompra;
                                    it.Ite_quantidade = Convert.ToInt32(qtd[j]);
                                    it.Ite_avaliacao = false;
                                    it.Ite_status = 0;
                                    it.Produto = new Produto();
                                    it.Produto.Pro_codigo = Convert.ToInt32(id[j]);
                                    ItemDB.Insert(it);
                                    p.Pro_codigo = Convert.ToInt32(id[j]);
                                    p.Pro_quantidade = p.Pro_quantidade;
                                    ProdutoDB.UpdateQuantidade(p, Convert.ToInt32(qtd[j]));
                                }
                                Mensagem m = new Mensagem();
                                m.Men_conteudo = "Olá senhor " + Session["nome"] + @", sua compra no garimpo foi efetuada com sucesso podendo ser acompanha em seu perfil na aba suas compras, num total de R$" + t + @"";
                                m.Men_data = DateTime.Now;
                                m.Men_lida = false;
                                m.Men_visivel = true;
                                m.Tipo = new Tme_tipo_mensagem();
                                m.Tipo.Tme_codigo = 1;
                                m.Usuario = new Usuario();
                                m.Usuario.Usu_cpf_cnpj = Session["cpf"].ToString();
                                MensagemDB.InsertCompraProduto(m);

                                DataSet ds = ProdutoDB.SelectAllDS();
                                int cont = 0;
                                int aux = ds.Tables[0].Rows.Count;
                                List<string> pro = new List<string>();
                                List<string> vend = new List<string>();
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    if (id[cont].Equals(dr["pro_codigo"].ToString()))
                                    {
                                        pro.Add(dr["pro_nome"].ToString());
                                        vend.Add(dr["usu_nome"].ToString());
                                        if (cont + 1 < id.Length)
                                        {
                                            cont++;
                                        }
                                    }
                                }
                                for (int i = 0; i < pro.Count; i++)
                                {
                                    Mensagem mV = new Mensagem();
                                    mV.Men_conteudo = "Olá senhor(a) " + vend[i] + @", seu produto " + pro[i] + @" acabou de ser vendido com " + qtd[cont] + @" unidade(s). Confira na aba Histórico de vendas em seu perfil.";
                                    mV.Men_data = DateTime.Now;
                                    mV.Men_lida = false;
                                    mV.Men_visivel = true;
                                    mV.Tipo = new Tme_tipo_mensagem();
                                    mV.Tipo.Tme_codigo = 1;
                                    mV.Usuario = new Usuario();
                                    mV.Usuario.Usu_cpf_cnpj = cpfVendedor[i];
                                    MensagemDB.InsertCompraProduto(mV);
                                }
                                HttpCookie myCookie = new HttpCookie("produtos");
                                myCookie.Expires = DateTime.Now.AddDays(-1d);
                                Response.Cookies.Add(myCookie);
                                Response.Redirect("/Paginas/Pedidos/PedidoConfirmado.aspx");
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Quantidade maior do que a disponível no produto, tente novamente','error')", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Termos!!','Aceite os termos para continuar','error')", true);
                        lblAceitar.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Selecione uma forma de pagamento','error')", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Selecione uma forma de envio','error')", true);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", "swal('Erro!!','Selecione um endereço','error')", true);
        }
    }
}