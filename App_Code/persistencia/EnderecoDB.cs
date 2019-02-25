using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de EnderecoDB
/// </summary>
public class EnderecoDB
{
    //INSERT ENDEREÇO
    public static int InsertEndereco(Endereco endereco)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando

            string sql = "INSERT INTO end_enderecos (end_cep, end_estado, end_cidade, end_bairro, end_numero, end_endereco, end_referencia, usu_cpf_cnpj ) VALUES (?end_cep, ?end_estado, ?end_cidade, ?end_bairro, ?end_numero, ?end_endereco, ?end_referencia, ?usu_cpf_cnpj)";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?end_cep", endereco.End_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?end_estado", endereco.End_estado));
            objCommand.Parameters.Add(Mapped.Parameter("?end_cidade", endereco.End_cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?end_bairro", endereco.End_bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?end_numero", endereco.End_numero));
            objCommand.Parameters.Add(Mapped.Parameter("?end_endereco", endereco.End_endereco));
            objCommand.Parameters.Add(Mapped.Parameter("?end_referencia", endereco.End_referencia));
            //Chave estrangeira                             
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", endereco.Usuario.Usu_cpf_cnpj));
            objCommand.ExecuteNonQuery();// utilizado quando cdigo não tem retorno, como seria o caso do SELECT
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
        }
        catch (Exception)
        {
            retorno = -2;
        }
        return retorno;
    }//----

    public static int Update(Endereco end)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE end_enderecos SET end_cep = ?cep, end_estado = ?estado, end_cidade = ?cidade, end_bairro = ?bairro, end_endereco = ?endereco, end_referencia = ?referencia, end_numero = ?numero WHERE end_codigo= ?codigo; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cep", end.End_cep));
            objCommand.Parameters.Add(Mapped.Parameter("?estado", end.End_estado));
            objCommand.Parameters.Add(Mapped.Parameter("?cidade", end.End_cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?bairro", end.End_bairro));
            objCommand.Parameters.Add(Mapped.Parameter("?endereco", end.End_endereco));
            objCommand.Parameters.Add(Mapped.Parameter("?referencia", end.End_referencia));
            objCommand.Parameters.Add(Mapped.Parameter("?numero", end.End_numero));
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", end.End_codigo));

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

    //DELETE
    public static int Delete(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "delete from end_enderecos where end_codigo = ?end_codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", codigo));// PK
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
    public static DataSet SelectCodigo(int codigo)
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM end_enderecos where end_codigo = ?end_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?end_codigo", codigo));
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //SELECT
    public static DataSet SelectAll(string cpf)
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM end_enderecos where usu_cpf_cnpj = ?usu_cpf_cnpj", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }

    ////select que devolve tudo em 1 obj
    //public Endereco SelectAll(string usu_cpf_cnpj)
    //{
    //    Endereco endereco = null;
    //    System.Data.IDbConnection objConexao;
    //    System.Data.IDbCommand objCommand;
    //    System.Data.IDataReader objDataReader;
    //    objConexao = Mapped.Connection();
    //    objCommand = Mapped.Command("SELECT * FROM end_enderecos WHERE usu_cpf_cnpj = ?usu_cpf_cnpj", objConexao);
    //    objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usu_cpf_cnpj));
    //    objDataReader = objCommand.ExecuteReader();
    //    string cpf = "";
    //    while (objDataReader.Read())
    //    {
    //        endereco = new Endereco();
    //        endereco.End_codigo = Convert.ToInt32(objDataReader["End_codigo"]);
    //        endereco.End_cep = Convert.ToString(objDataReader["End_cep"]);
    //        endereco.End_estado = Convert.ToString(objDataReader["End_estado"]);
    //        endereco.End_cidade = Convert.ToString(objDataReader["End_cidade"]);
    //        endereco.End_bairro = Convert.ToString(objDataReader["End_bairro"]);
    //        endereco.End_endereco = Convert.ToString(objDataReader["End_endereco"]);
    //        endereco.End_referencia = Convert.ToString(objDataReader["End_referencia"]);
    //        endereco.End_numero = Convert.ToInt32(objDataReader["End_numero"]);          
    //        cpf = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
    //    }
    //    objDataReader.Close();
    //    objConexao.Close();
    //    objCommand.Dispose();
    //    if (cpf != "")
    //    {
    //        UsuarioDB db = new UsuarioDB();
    //        db.Select(cpf);
    //        endereco.Usuario = db.Select(cpf);
    //    }
    //    objConexao.Dispose();
    //    objDataReader.Dispose();
    //    return endereco;
    //}
    ////----------------------------
    public static DataSet SelectTemEndereco(string cpf)
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select * from pro_produtos as p where p.usu_cpf_cnpj = ?usu_cpf_cnpj and p.pro_moderacao_status = 1 and p.pro_status = 1 ", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;

    }
    
}