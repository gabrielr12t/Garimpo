using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de VendasDB
/// </summary>
public class VendasDB
{
    public static int Insert(Vendas venda)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando

            string sql = "INSERT INTO ven_vendas (ven_data, ven_status, usu_cpf_cnpj, end_codigo, env_codigo, for_codigo) VALUES (?ven_data, ?ven_status, ?usu_cpf_cnpj, ?end_codigo, ?env_codigo, ?for_codigo)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?ven_data", venda.ven_data));
            objCommand.Parameters.Add(Mapped.Parameter("?ven_status", venda.ven_status));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", venda.usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", venda.endereco.End_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?env_codigo", venda.envio.Env_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?for_codigo", venda.forma.For_codigo));
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

    public Vendas SelectVenda(string cpf)
    {
        Vendas venda= null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM ven_vendas WHERE usu_cpf_cnpj = ?cpf", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataReader = objCommand.ExecuteReader();
        string cpf_cnpj = "";
        while (objDataReader.Read())
        {
            venda = new Vendas();
            venda.ven_codigo = Convert.ToInt32(objDataReader["ven_codigo"]);
            venda.ven_data = Convert.ToDateTime(objDataReader["ven_data"]);                        
            cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (cpf_cnpj != "")
        {
            UsuarioDB db = new UsuarioDB();
            db.Select(cpf_cnpj);
            venda.usuario = db.Select(cpf_cnpj);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return venda;
    }
}