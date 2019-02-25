using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubcategoriaDB
/// </summary>
public class SubcategoriaDB
{

    //INSERT
    public static int Insert(Subcategoria subcategoria)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO sub_subcategorias (sub_nome, cat_codigo) VALUES (?sub_nome, ?cat_codigo)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?sub_nome", subcategoria.Sub_nome));

            //chave estrangeira
            objCommand.Parameters.Add(Mapped.Parameter("?cat_codigo", subcategoria.Categoria.Cat_codigo));

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
        objCommand = Mapped.Command("SELECT * FROM sub_subcategorias ORDER BY sub_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }

    //SELECT ID USU
    public static DataSet SelectID(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from sub_subcategorias where cat_codigo = ?codigo;";
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
        objCommand = Mapped.Command("select * from sub_subcategorias where cat_codigo = ?id;", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?id", codigo));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public static Subcategoria Select(int codigo)
    {
        Subcategoria sub = null;
        IDataReader objreader;
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from sub_subcategorias where sub_codigo = ?codigo;";
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objreader = objCommand.ExecuteReader();
        int cat = 0;
        while (objreader.Read())
        {
            sub = new Subcategoria();
            sub.Sub_codigo = Convert.ToInt32(objreader["sub_codigo"]);
            sub.Sub_nome = Convert.ToString(objreader["sub_nome"]);
            cat = Convert.ToInt32(objreader["cat_codigo"]);
        }

        objreader.Dispose();
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        if (cat != 0)
        {            
            sub.Categoria = CategoriaDB.Select(cat);
        }
        return sub;
    }
    public Subcategoria SelectSubUsuario(int sub_codigo)
    {
        Subcategoria sub = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM sub_subcategorias WHERE sub_codigo = ?sub_codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", sub_codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            sub = new Subcategoria();
            sub.Sub_codigo = Convert.ToInt32(objDataReader["sub_codigo"]);
            sub.Sub_nome = Convert.ToString(objDataReader["sub_nome"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return sub;
    }


}