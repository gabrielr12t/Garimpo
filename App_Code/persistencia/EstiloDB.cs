using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EstiloDB
/// </summary>
public class EstiloDB
{

    //INSERT    
    public static int Insert(Estilo estilo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO est_estilos (est_nome, usu_cpf_cnpj) VALUES (?est_nome, ?usu_cpf_cnpj)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?est_nome", estilo.Est_nome));
            //Chave estrangeira
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", estilo.Usuario.Usu_cpf_cnpj));
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
        //objCommand = Mapped.Command("SELECT * FROM est_estilos ORDER BY est_nome", objConnection);
        objCommand = Mapped.Command("SELECT * from est_estilos order by est_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    public static DataSet SelectEstiloCategoriaSub()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("SELECT * FROM est_estilos ORDER BY est_nome", objConnection);
        objCommand = Mapped.Command("SELECT e.est_codigo,e.est_nome,c.cat_codigo,c.cat_nome,c.est_codigo idEst,s.sub_codigo, s.sub_nome,s.cat_codigo idCat FROM est_estilos as e inner join cat_categorias as c on e.est_codigo = c.est_codigo inner join sub_subcategorias as s on s.cat_codigo=c.cat_codigo order by e.est_codigo, c.cat_codigo, s.sub_codigo;", objConnection);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    //


    //SELECT ID
    public static DataSet SelectAId(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from cat_categorias where est_codigo = ?codigo;";
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

    //select sub pelo estilo id
    public static DataSet SelectSubCategoriaByEstilo(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        //pega a subcategoria de acordo com o estiloID string sql = "SELECT DISTINCT * FROM est_estilos AS e INNER JOIN cat_categorias as c ON e.est_codigo = c.est_codigo inner join sub_subcategorias as s on c.cat_codigo =s.cat_codigo where e.est_codigo = ?id;";
        string sql = "SELECT DISTINCT *FROM est_estilos AS e INNER JOIN cat_categorias as c ON e.est_codigo = c.est_codigo where e.est_codigo = ?id";
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
    }

    //DELETE
    public static int Delete(int id)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "delete from est_estilos where est_codigo = ?est_codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?est_codigo", id));// PK
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
    public static Estilo Select(int codigo)
    {
        Estilo est = null;
        IDataReader objreader;
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from est_estilos where est_codigo = ?codigo;";
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objreader = objCommand.ExecuteReader();
        while (objreader.Read())
        {
            est = new Estilo();
            est.Est_codigo = Convert.ToInt32(objreader["est_codigo"]);
            est.Est_nome = Convert.ToString(objreader["est_nome"]);
        }

        objreader.Dispose();
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();

        return est;
    }

}