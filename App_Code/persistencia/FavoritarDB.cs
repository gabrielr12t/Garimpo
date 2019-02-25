using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de FavoritarDB
/// </summary>
public class FavoritarDB
{
    //------ Tabela N:N Cor produto REVISAR  
   
    public static int Insert(Favorito favorito)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO fav_favoritos (usu_cpf, pro_codigo) VALUES (?usu_cpf, ?pro_codigo)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf", favorito.Usuario.Usu_cpf_cnpj));           
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", favorito.Produto.Pro_codigo));
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

    //delete 
    public static int Delete(Favorito favorito)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "DELETE FROM fav_favoritos WHERE usu_cpf = ?usu_cpf AND pro_codigo = ?pro_codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf", favorito.Usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", favorito.Produto.Pro_codigo));
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


    public static DataSet SelectFavoritos(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select *, (SELECT f.fot_url from fot_fotos f where fav.pro_codigo = f.pro_codigo limit 1) as foto from fav_favoritos as fav inner JOIN pro_produtos as p on p.pro_codigo = fav.pro_codigo where fav.usu_cpf = ?usu_cpf;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectCoracao(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT f.usu_cpf,f.pro_codigo from fav_favoritos as f where f.usu_cpf = ?usu_cpf;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }


}