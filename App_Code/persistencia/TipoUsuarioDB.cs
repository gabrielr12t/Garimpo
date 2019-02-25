using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de TipoUsuarioDB
/// </summary>
public class TipoUsuarioDB
{
    public Tipo_usuario Select(int tip_codigo)
    {
        Tipo_usuario tipo = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM tip_tipo WHERE tip_codigo = ?tip_codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?tip_codigo", tip_codigo));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            tipo = new Tipo_usuario();
            tipo.Tip_codigo = Convert.ToInt32(objDataReader["tip_codigo"]);
            tipo.Tip_nome_tipo = Convert.ToString(objDataReader["tip_nome_tipo"]);           
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return tipo;
    }    //----------------------------
}