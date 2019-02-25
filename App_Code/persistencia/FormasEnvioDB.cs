using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de FormasEnvioDB
/// </summary>
public class FormasEnvioDB
{
    public static DataSet SelectAll()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM env_formas_envios ORDER BY env_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }

    public static DataSet SelectID(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select * from enp_envio_produtos where pro_codigo = ?pro_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public bool FormasDeEnvio(int envCodigo, int codProduto)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "INSERT INTO enp_envio_produtos (pro_codigo, env_codigo) VALUES (?pro_codigo, ?env_codigo)";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao); 
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", codProduto));
        objCommand.Parameters.Add(Mapped.Parameter("?env_codigo", envCodigo));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }
}