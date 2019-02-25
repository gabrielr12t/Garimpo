using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class MensagemDB
{
	public static int MensagemADM(Mensagem mensagem)
	{
		int retorno = 0;
		try
		{
			IDbConnection objConexao;  // Abre a conexao
			IDbCommand objCommand;  // Cria o comando
			string sql = "INSERT INTO men_mensagens (men_conteudo,usu_cpf_cnpj, tme_codigo, pro_codigo, men_lida, men_data) VALUES (?men_conteudo, ?usu_cpf_cnpj, ?tme_codigo, ?pro_codigo, ?men_lida, ?men_data)";
			objConexao = Mapped.Connection();
			objCommand = Mapped.Command(sql, objConexao);
			objCommand.Parameters.Add(Mapped.Parameter("?men_conteudo", mensagem.Men_conteudo));
			objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
			objCommand.Parameters.Add(Mapped.Parameter("?tme_codigo", mensagem.Tipo.Tme_codigo));
			objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", mensagem.Produto.Pro_codigo));
			objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
			objCommand.Parameters.Add(Mapped.Parameter("?men_data", mensagem.Men_data));
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
	public static int CadastroProduto(Mensagem mensagem)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO men_mensagens (men_conteudo,usu_cpf_cnpj, tme_codigo, pro_codigo, men_lida, men_data, men_visivel) VALUES (?men_conteudo, ?usu_cpf_cnpj, ?tme_codigo, ?pro_codigo, ?men_lida, ?men_data, true)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?men_conteudo", mensagem.Men_conteudo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?tme_codigo", mensagem.Tipo.Tme_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", mensagem.Produto.Pro_codigo));       
            objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
            objCommand.Parameters.Add(Mapped.Parameter("?men_data", mensagem.Men_data));
            objCommand.Parameters.Add(Mapped.Parameter("?men_visivel", mensagem.Men_visivel));
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

    public static int InsertMensagemParaVendedor(Mensagem mensagem)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO men_mensagens (men_conteudo, men_data, men_lida, usu_cpf_cnpj, pro_codigo, tme_codigo, men_pergunta_codigo, men_cpf_pergunta, men_visivel) VALUES (?men_conteudo, ?men_data, ?men_lida, ?usu_cpf_cnpj, ?pro_codigo, ?tme_codigo, ?men_pergunta_codigo, ?men_cpf_pergunta, true)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?men_conteudo", mensagem.Men_conteudo));        
            objCommand.Parameters.Add(Mapped.Parameter("?men_data", mensagem.Men_data));
            objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", mensagem.Produto.Pro_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?tme_codigo", mensagem.Tipo.Tme_codigo));
			objCommand.Parameters.Add(Mapped.Parameter("?men_pergunta_codigo", mensagem.Men_pergunta_codigo));
			objCommand.Parameters.Add(Mapped.Parameter("?men_cpf_pergunta", mensagem.Men_cpf_pergunta));
            objCommand.Parameters.Add(Mapped.Parameter("?men_visivel", mensagem.Men_visivel));
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

	//Insert mensagem para comprador
	public static int InsertMensagemParaComprador(Mensagem mensagem)
	{
		int retorno = 0;
		try
		{
			IDbConnection objConexao;  // Abre a conexao
			IDbCommand objCommand;  // Cria o comando
			string sql = "INSERT INTO men_mensagens (men_conteudo, men_data, men_lida, usu_cpf_cnpj, pro_codigo, tme_codigo, men_pergunta_codigo, men_visivel) VALUES (?men_conteudo, ?men_data, ?men_lida, ?usu_cpf_cnpj, ?pro_codigo, ?tme_codigo, ?men_pergunta_codigo, true)";
			objConexao = Mapped.Connection();
			objCommand = Mapped.Command(sql, objConexao);
			objCommand.Parameters.Add(Mapped.Parameter("?men_conteudo", mensagem.Men_conteudo));
			objCommand.Parameters.Add(Mapped.Parameter("?men_data", mensagem.Men_data));
			objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
			objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
			objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", mensagem.Produto.Pro_codigo));
			objCommand.Parameters.Add(Mapped.Parameter("?tme_codigo", mensagem.Tipo.Tme_codigo));
			objCommand.Parameters.Add(Mapped.Parameter("?men_pergunta_codigo", mensagem.Men_pergunta_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?men_visivel", mensagem.Men_visivel));
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


	public static int MensagemCadastro(Mensagem mensagem)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO men_mensagens (men_conteudo, men_data, men_lida, usu_cpf_cnpj, tme_codigo, men_visivel) VALUES (?men_conteudo, ?men_data, ?men_lida, ?usu_cpf_cnpj, ?tme_codigo ,true)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?men_conteudo", mensagem.Men_conteudo));
            objCommand.Parameters.Add(Mapped.Parameter("?men_data", mensagem.Men_data));
            objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?tme_codigo", mensagem.Tipo.Tme_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?men_visivel", mensagem.Men_visivel));
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

    public static int InsertCompraProduto(Mensagem mensagem)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO men_mensagens (men_conteudo, men_data, men_visivel, men_lida, tme_codigo, usu_cpf_cnpj) VALUES (?men_conteudo, ?men_data, ?men_visivel, ?men_lida, ?tme_codigo, ?usu_cpf_cnpj)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?men_conteudo", mensagem.Men_conteudo));
            objCommand.Parameters.Add(Mapped.Parameter("?men_data", mensagem.Men_data));
            objCommand.Parameters.Add(Mapped.Parameter("?men_visivel", mensagem.Men_visivel));
            objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
            objCommand.Parameters.Add(Mapped.Parameter("?tme_codigo", mensagem.Tipo.Tme_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
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

    public static DataSet Select(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("SELECT men_visivel,men_codigo, men_conteudo, men_respondida, men_data, men_lida, pro_codigo,case when tme_codigo='2' then 'Pergunta de produto' when tme_codigo='3' then 'resposta do produto' when tme_codigo='4' then 'Produto atualizado' when tme_codigo='5' then 'Produto Aprovado' when tme_codigo='6' then 'Produto recusado' else 'Equipe Garimpo' end tme_codigo, men_pergunta_codigo, pro_codigo, men_cpf_pergunta, usu_cpf_cnpj from men_mensagens where usu_cpf_cnpj = ?usu_cpf_cnpj order by men_data desc", objConnection);
        objCommand = Mapped.Command("SELECT u.sub_codigo,m.men_visivel,m.men_codigo, m.men_conteudo, m.men_respondida, m.men_data, m.men_lida, m.pro_codigo,case when m.tme_codigo = '2' then 'Pergunta de produto' when m.tme_codigo = '3' then 'resposta do produto' when m.tme_codigo = '4' then 'Produto atualizado' when m.tme_codigo = '5' then 'Produto Aprovado' when m.tme_codigo = '6' then 'Produto recusado' when m.tme_codigo = '7' then 'Produto Alterado' when m.tme_codigo = '8' then 'Denúncia de Produto' else 'Equipe Garimpo' end tme_codigo, m.men_pergunta_codigo, m.pro_codigo, m.men_cpf_pergunta, m.usu_cpf_cnpj from men_mensagens as m inner JOIN usu_usuarios as u on u.usu_cpf_cnpj = m.usu_cpf_cnpj where m.usu_cpf_cnpj = ?usu_cpf_cnpj order by men_data desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectProtudoQtdMensagem(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM men_mensagens WHERE pro_codigo = ?pro_codigo ", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", id));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectMensagemProduto(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();		
		objCommand = Mapped.Command("select m.men_codigo,m.men_conteudo,m.men_arquivada,m.men_data,m.men_lida,m.usu_cpf_cnpj,m.pro_codigo,m.tme_codigo, m.men_pergunta_codigo,m.men_cpf_pergunta,m.men_respondida, u.usu_foto_perfil fotoVendedor,(Select u.usu_foto_perfil from usu_usuarios u where m.men_cpf_pergunta = u.usu_cpf_cnpj) as fotoComprador from men_mensagens m join usu_usuarios u on m.usu_cpf_cnpj where u.usu_cpf_cnpj = m.usu_cpf_cnpj and m.pro_codigo = ?pro_codigo order by men_data desc", objConnection);
		objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", id));
		
		//objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
		objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

	//select m.men_codigo,m.usu_cpf_cnpj,m.men_pergunta_codigo, m.men_cpf_pergunta ,u.usu_foto_perfil fotoComprador from men_mensagens as m inner join usu_usuarios as u on(u.usu_cpf_cnpj = "558.498.777-44" and m.pro_codigo = 69) limit 1;

	public static DataSet SelectMensagemLida(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * from men_mensagens where usu_cpf_cnpj = ?usu_cpf_cnpj and men_lida=0 order by men_data desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }   

    public static DataSet SelectMensagensADM()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * from men_mensagens where men_adm = 1 order by men_data desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //update
    public static bool UpdateMensagemLida(Mensagem mensagem)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE men_mensagens SET men_lida = ?men_lida WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?men_lida", mensagem.Men_lida));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", mensagem.Usuario.Usu_cpf_cnpj));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }//Update

    public static bool UpdateMensagemVisivel(Mensagem mensagem)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE men_mensagens SET men_visivel = false WHERE men_codigo= ?men_codigo";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?men_codigo", mensagem.Men_codigo));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }//Update



    public static bool MensagemRespondida(Mensagem mensagem)
	{
		System.Data.IDbConnection objConexao;
		System.Data.IDbCommand objCommand;
		string sql = "UPDATE men_mensagens SET men_respondida = ?men_respondida WHERE men_codigo= ?men_codigo";
		objConexao = Mapped.Connection();
		objCommand = Mapped.Command(sql, objConexao);
		objCommand.Parameters.Add(Mapped.Parameter("?men_respondida", mensagem.Men_respondida));
		objCommand.Parameters.Add(Mapped.Parameter("?men_codigo", mensagem.Men_codigo));
		objCommand.ExecuteNonQuery();
		objConexao.Close();
		objCommand.Dispose();
		objConexao.Dispose();
		return true;
	}//Update

	//public static bool UpdateResposta(Mensagem mensagem)
	//{
	//    System.Data.IDbConnection objConexao;
	//    System.Data.IDbCommand objCommand;
	//    string sql = "UPDATE men_mensagens SET men_resposta = ?men_resposta WHERE men_codigo= ?men_codigo";
	//    objConexao = Mapped.Connection();
	//    objCommand = Mapped.Command(sql, objConexao);
	//    objCommand.Parameters.Add(Mapped.Parameter("?men_resposta", mensagem.Men_resposta));
	//    objCommand.Parameters.Add(Mapped.Parameter("?men_codigo", mensagem.Men_codigo));
	//    objCommand.ExecuteNonQuery();
	//    objConexao.Close();
	//    objCommand.Dispose();
	//    objConexao.Dispose();
	//    return true;
	//}//Update


	public static DataSet SelectMensagemSelecionada(int men_codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * from men_mensagens where men_codigo = ?men_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?men_codigo", men_codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

}