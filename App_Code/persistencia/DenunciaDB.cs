using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DenunciaDB
/// </summary>
public class DenunciaDB
{
    public static int Insert(Denuncia denuncia)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO den_denuncias (den_opcao, den_tipo, usu_cpf_cnpj, pro_codigo) VALUES (?den_opcao, ?den_tipo, ?usu_cpf_cnpj, ?pro_codigo)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?den_opcao", denuncia.Den_opcao));
            objCommand.Parameters.Add(Mapped.Parameter("?den_tipo", denuncia.Den_tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", denuncia.Usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", denuncia.Produto.Pro_codigo));
        
            //objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", usuario.Subcategoria.Sub_codigo));
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

    public static DataSet SelectAllDenuncias()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select * from pro_produtos as p inner join den_denuncias as d on p.pro_codigo = d.pro_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //excluir denuncia
    public static int Delete(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "delete from den_denuncias where den_codigo = ?den_codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?den_codigo", codigo));// PK
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

}