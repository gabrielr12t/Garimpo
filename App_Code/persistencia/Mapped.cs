using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//Importa funções do MySQL
using MySql.Data.MySqlClient;
//Trabalhar com Dataset
using System.Data;
//Permite visualizar o web.config
using System.Configuration;



public class Mapped
{
    //Abrir conexao
    public static IDbConnection Connection()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
        objConexao.Open();
        return objConexao;
    }

    //Executa comando no BD
    public static IDbCommand Command(string query, IDbConnection conexao)
    {
        IDbCommand command = conexao.CreateCommand();
        command.CommandText = query;
        return command;
    }

    //Retorna um Adapter (SELECT)
    public static IDataAdapter Adapter(IDbCommand command)
    {
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = command;
        return adap;
    }

    //Cria parametro da SQL
    public static IDbDataParameter Parameter(string nome, object valor)
    {
        return new MySqlParameter(nome, valor);

    }

}
