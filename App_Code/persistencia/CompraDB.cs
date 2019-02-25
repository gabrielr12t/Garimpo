using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de CompraDB
/// </summary>
public class CompraDB
{
    public static int Insert(Compra compra)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando

            string sql = "INSERT INTO com_compras (com_data, com_valor_total, usu_cpf_cnpj, end_codigo, env_codigo, for_codigo) VALUES ( ?com_data, ?com_valor_total, ?usu_cpf_cnpj, ?end_codigo, ?env_codigo, ?for_codigo)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?com_data", compra.Com_data));
            objCommand.Parameters.Add(Mapped.Parameter("?com_valor_total", compra.Com_valor_total));

            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", compra.Usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", compra.Endereco.End_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?env_codigo", compra.Envio.Env_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?for_codigo", compra.Forma_pagamento.For_codigo));
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

    public Compra SelectCompra(string cpf)
    {
        Compra compra = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM com_compras WHERE usu_cpf_cnpj = ?cpf", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataReader = objCommand.ExecuteReader();
        string cpf_cnpj = "";
        while (objDataReader.Read())
        {
            compra = new Compra();
            compra.Com_codigo = Convert.ToInt32(objDataReader["com_codigo"]);
            compra.Com_data = Convert.ToDateTime(objDataReader["com_data"]);
            compra.Com_valor_total = Convert.ToDouble(objDataReader["com_valor_total"]);
            //compra.Com_status = Convert.ToInt32(objDataReader["com_status"]);
            cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (cpf_cnpj != "")
        {
            UsuarioDB db = new UsuarioDB();
            db.Select(cpf_cnpj);
            compra.Usuario = db.Select(cpf_cnpj);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return compra;
    }

    public static DataSet SelectMinhasCompras(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();       
        objCommand = Mapped.Command("select *,p.usu_cpf_cnpj cpf_vend ,(select f.fot_url from fot_fotos as f where f.pro_codigo = i.pro_codigo limit 1) as foto from com_compras as c inner JOIN ite_itens as i on i.com_codigo = c.com_codigo inner join pro_produtos as p on i.pro_codigo=p.pro_codigo inner join end_enderecos as e on e.end_codigo = c.end_codigo where c.usu_cpf_cnpj = ?usu_cpf_cnpj order by c.com_data desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    
    //select * from com_compras as c inner JOIN ite_itens as i on i.com_codigo = c.com_codigo where c.usu_cpf_cnpj = "155.477.841-11" order by c.com_data asc
}