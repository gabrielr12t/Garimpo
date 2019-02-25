using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoriaDB
/// </summary>
public class CategoriaDB
{
    //INSERT
    public static int Insert(Categoria cat)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO cat_categorias (cat_nome, est_codigo) VALUES (?cat_nome, ?est_codigo)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cat_nome", cat.Cat_nome));

            //chave estrangeira
            objCommand.Parameters.Add(Mapped.Parameter("?est_codigo", cat.Estilo.Est_codigo));

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

    //SELECT
    public static DataSet SelectAll()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cat_categorias ORDER BY cat_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
       
    //SELECT ID
    public static DataSet SelectAId(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "SELECT * FROM cat_categorias WHERE est_codigo = ?codigo ORDER BY cat_nome";      
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
   
    public DataSet SelectBuscaSubcategoriaID(int codigo)
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("select * from cat_categorias where est_codigo = ?id;", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?id", codigo));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static DataSet SelectCategoiraID(int codigo)
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("select * from cat_categorias where cat_codigo = ?id;", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?id", codigo));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static Categoria Select(int codigo)
    {
        Categoria cat = null;
        IDataReader objreader;
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from cat_categorias where cat_codigo = ?codigo;";
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objreader = objCommand.ExecuteReader();
        int estilo=0;
        while (objreader.Read())
        {
            cat = new Categoria();
            cat.Cat_codigo = Convert.ToInt32(objreader["cat_codigo"]);
            cat.Cat_nome = Convert.ToString(objreader["cat_nome"]);
            estilo = Convert.ToInt32(objreader["est_codigo"]);
        }

        objreader.Dispose();
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        if (estilo != 0)
        {        
            cat.Estilo = EstiloDB.Select(estilo);
        }
        return cat;
    }

    public Categoria SelectID(int cat)
    {
        Categoria cate = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cat_categorias WHERE cat_codigo = ?cat", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cat", cat));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            cate = new Categoria();
            cate.Cat_codigo = Convert.ToInt32(objDataReader["cat_codigo"]);
            cate.Cat_nome = Convert.ToString(objDataReader["cat_nome"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return cate;
    }    //----------------------------

}