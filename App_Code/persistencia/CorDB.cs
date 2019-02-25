using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CorDB
/// </summary>
public class CorDB
{
    //SELECT
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cor_cores ORDER BY cor_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    //select que devolve tudo em 1 obj
    public Cor SelectObj()
    {
        Cor cor = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cor_cores ORDER BY cor_nome", objConexao);        
        objDataReader = objCommand.ExecuteReader();       
        while (objDataReader.Read())
        {
            cor = new Cor();
            cor.Cor_nome = Convert.ToString(objDataReader["cor_nome"]);
            cor.Cor_imagem= Convert.ToString(objDataReader["cor_imagem"]);                            
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();       
        objConexao.Dispose();
        objDataReader.Dispose();
        return cor;
    }
  

    //------ Tabela N:N Cor produto REVISAR  
    public bool VincularCor(int codCor, int codProduto)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "INSERT INTO cop_cores_produtos (cor_cod, pro_codigo) VALUES (?cor_cod, ?pro_codigo)";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cor_cod", codCor));
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", codProduto));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }

    public static DataSet SelectCoresProdutos(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cop_cores_produtos as cp where cp.pro_codigo = ?id", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?id", id));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
}