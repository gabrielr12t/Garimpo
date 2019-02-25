using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ItemDB
/// </summary>
public class ItemDB
{
    public static int Insert(Item item)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando

            string sql = "INSERT INTO ite_itens (ite_quantidade,ite_avaliacao, ite_status, pro_codigo, com_codigo) VALUES (?ite_quantidade, ?ite_avaliacao, ?ite_status, ?pro_codigo, ?com_codigo)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?ite_quantidade", item.Ite_quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?ite_avaliacao", item.Ite_avaliacao));
            objCommand.Parameters.Add(Mapped.Parameter("?ite_status", item.Ite_status));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", item.Produto.Pro_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?com_codigo", item.Compra.Com_codigo));
            

            objCommand.ExecuteNonQuery();// utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception)
        {
            retorno = -2;
        }
        return retorno;
    }//----

    public static int UpdatePagamentoFeito(Item item)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE ite_itens SET ite_status = ?ite_status WHERE pro_codigo= ?pro_codigo and com_codigo = ?com_codigo; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?ite_status", item.Ite_status));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", item.Produto.Pro_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?com_codigo", item.Compra.Com_codigo));


            //objCommand.Parameters.Add(Mapped.Parameter("?pro_status", produto.Pro_status));
            //objCommand.Parameters.Add(Mapped.Parameter("?pro_moderacao_status", produto.Pro_moderacao_status));                                                
            objCommand.ExecuteNonQuery();   // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception e)
        {
            retorno = -2;
        }
        return retorno;
    }

    //

    public static int UpdateAvaliacao(Item item)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE ite_itens SET ite_avaliacao = ?ite_avaliacao WHERE pro_codigo= ?pro_codigo and com_codigo = ?com_codigo;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?ite_avaliacao", item.Ite_avaliacao));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", item.Produto.Pro_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?com_codigo", item.Compra.Com_codigo));


            //objCommand.Parameters.Add(Mapped.Parameter("?pro_status", produto.Pro_status));
            //objCommand.Parameters.Add(Mapped.Parameter("?pro_moderacao_status", produto.Pro_moderacao_status));                                                
            objCommand.ExecuteNonQuery();   // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception e)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static DataSet SelectQuantidadeAvaliacoes(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("select *,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p where p.sub_codigo = ?sub_codigo and p.pro_status = 1 and p.pro_moderacao_status = 1", objConnection);
        objCommand = Mapped.Command("select * from pro_produtos as p inner join ite_itens as i on i.pro_codigo = p.pro_codigo where p.usu_cpf_cnpj = ?usu_cpf_cnpj and i.ite_avaliacao", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static int UpdateCancelar( int com_id, int id)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "Update ite_itens set ite_status = 4 where com_codigo = "+com_id+" and pro_codigo = "+id+"";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);            
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception)
        {
            retorno = -2;
        }
        return retorno;
    }
    //
}