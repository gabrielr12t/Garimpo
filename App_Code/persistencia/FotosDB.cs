using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Descrição resumida de FotosDB
/// </summary>
public class FotosDB
{
    

    public static int Insert(Foto foto)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO fot_fotos (fot_url, pro_codigo) VALUES (?fot_url, ?pro_codigo)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?fot_url", foto.Fot_url));                      
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", foto.Produto.Pro_codigo));                                      
            objCommand.ExecuteNonQuery();   // utilizado quando cdigo não tem retorno, como seria o caso do SELECT
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

    // //SELECT ID
    //select que devolve tudo em 1 obj
    public Foto SelectFotoProduto(int codigo)
    {
        Foto foto = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM fot_fotos WHERE pro_codigo = ?codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objDataReader = objCommand.ExecuteReader();
        
        while (objDataReader.Read())
        {
            foto = new Foto();
            foto.Fot_url = Convert.ToString(objDataReader["fot_url"]);                     
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();        
        objConexao.Dispose();
        objDataReader.Dispose();
        return foto;
    }

    public static DataSet SelectByProduto(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from fot_fotos where pro_codigo = ?id;";
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?id", id));
        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }//---------------------------------
    public static int Delete(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "delete from fot_fotos where fot_codigo = ?fot_codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?fot_codigo", codigo));// PK
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