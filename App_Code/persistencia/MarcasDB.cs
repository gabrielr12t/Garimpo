using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MarcasDB
/// </summary>
public class MarcasDB
{
    //SELECT
    public static DataSet SelectAll()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM mar_marcas ORDER BY mar_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    //---------------------------
    public static Marca Select(int codigo)
    {
        Marca mar = null;
        IDataReader objreader;
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from mar_marcas where mar_codigo = ?codigo;";
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objreader = objCommand.ExecuteReader();       
        while (objreader.Read())
        {
            mar = new Marca();
            mar.Mar_codigo = Convert.ToInt32(objreader["mar_codigo"]);
            mar.Mar_nome = Convert.ToString(objreader["mar_nome"]);
           
        }
        objreader.Dispose();
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return mar;
    }
    //INSERT    
    public static int Insert(Marca marca)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO mar_marcas (mar_nome, usu_cpf_cnpj) VALUES (?mar_nome, ?usu_cpf_cnpj)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?mar_nome", marca.Mar_nome));
            //Chave estrangeira
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", marca.Usuario.Usu_cpf_cnpj));
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