using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioDB
/// </summary>
public class UsuarioDB
{
	//select do usuario com endereço dele
	public static DataSet SelectUsuarioComEndereco(string cpf)
	{
		DataSet ds = new DataSet();
		IDbConnection objConnection;
		IDbCommand objCommand;
		IDataAdapter objDataAdapter;
		objConnection = Mapped.Connection();
		objCommand = Mapped.Command("SELECT *,CONCAT ( e.end_cep,', ', e.end_endereco,', ',  e.end_cidade,', ', e.end_estado,', ', e.end_bairro,', ', e.end_numero ) as endereco FROM usu_usuarios as u INNER JOIN end_enderecos as e on u.usu_cpf_cnpj = e.usu_cpf_cnpj where u.usu_cpf_cnpj = ?cpf;", objConnection);
		objDataAdapter = Mapped.Adapter(objCommand);
		objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
		objDataAdapter.Fill(ds);
		objConnection.Close();
		objCommand.Dispose();
		objConnection.Dispose();
		return ds;
	}

   


    //SELECT verificar se email existe (Recuperar senha)
    public static DataSet SelectEmail(string email)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios WHERE usu_email = ?email", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?email", email));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    //UPDATE senha 
    public static int UpdateSenha(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_senha = ?usu_senha WHERE usu_email= ?usu_email; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuario.Usu_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usuario.Usu_email));
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

    public static int UpdateVendas(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_qtdd_vendas = ?usu_qtdd_vendas, usu_reputacao = ?usu_reputacao WHERE usu_cpf_cnpj= ?usu_cpf_cnpj; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_vendas", usuario.Usu_qtdd_vendas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_vendas", usuario.Usu_reputacao));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
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

    //UPDATE compras 
    public static int UpdateCompras(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_qtdd_compras = ?usu_qtdd_compras WHERE usu_cpf_cnpj= ?usu_cpf_cnpj; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_compras", usuario.Usu_qtdd_compras));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
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
    //--------------------------------------------
    public static int updateSenhaCpf(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_senha = ?usu_senha WHERE usu_cpf_cnpj= ?usu_cpf_cnpj; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuario.Usu_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
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
    public static DataSet SelectTelefone(string telefone)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios WHERE usu_telefone = ?telefone", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?telefone", telefone));
        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //INSERIR CADASTRO COMPLETO
    public static int UpdateUsuarioCompleto(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_sexo = ?usu_sexo ,usu_cadastroCompleto = 2, usu_telefone = ?usu_telefone,usu_data_nasc = ?usu_data_nasc, usu_cadastroCompleto = ?usu_cadastroCompleto," +
                " usu_foto_perfil = ?usu_foto_perfil WHERE usu_cpf_cnpj= ?usu_cpf_cnpj;";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_sexo", usuario.Usu_sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cadastroCompleto", usuario.Usu_cadastroCompleto));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_telefone", usuario.Usu_telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_data_nasc", usuario.Usu_data_nasc));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_foto_perfil", usuario.Usu_foto_perfil));
            //objCommand.Parameters.Add(Mapped.Parameter("?usu_cadastroCompleto", usuario.Usu_cadastroCompleto));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
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
    //-----
    //Udpade cadastroCompleto   
    //---   

    //INSERT CADASTRO RÀPIDO
    public static int Insert(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO usu_usuarios (usu_cpf_cnpj, usu_nome, usu_sexo , usu_email, usu_senha, usu_data_cadastro, usu_status_cadastro,usu_foto_perfil, usu_nome_loja, usu_qtdd_vendas, usu_qtdd_vendas_canceladas, usu_qtdd_denuncia, usu_qtdd_compras, usu_qtdd_compras_canceladas, usu_medida_busto, usu_medida_cintura, usu_medida_calcado, usu_reputacao, usu_cadastroCompleto,usu_tentativas, tip_codigo, sub_codigo) VALUES (?usu_cpf_cnpj, ?usu_nome, ?usu_sexo , ?usu_email, ?usu_senha, ?usu_data_cadastro, ?usu_status_cadastro, ?usu_foto_perfil, ?usu_nome_loja, ?usu_qtdd_vendas, ?usu_qtdd_vendas_canceladas, ?usu_qtdd_denuncia, ?usu_qtdd_compras, ?usu_qtdd_compras_canceladas, ?usu_medida_busto, ?usu_medida_cintura, ?usu_medida_calcado, ?usu_reputacao, ?usu_cadastroCompleto, 0, ?tip_codigo, 25)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_nome", usuario.Usu_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_sexo", usuario.Usu_sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usuario.Usu_email));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usuario.Usu_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_data_cadastro", usuario.Usu_data_cadastro));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_status_cadastro", usuario.Usu_status_cadastro));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_foto_perfil", usuario.Usu_foto_perfil));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_nome_loja", usuario.Usu_nome_loja));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_vendas", usuario.Usu_qtdd_vendas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_vendas_canceladas", usuario.Usu_qtdd_vendas_canceladas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_denuncia", usuario.Usu_qtdd_denuncia));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_compras", usuario.Usu_qtdd_compras));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_compras_canceladas", usuario.Usu_qtdd_compras_canceladas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_medida_busto", usuario.Usu_medida_busto));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_medida_cintura", usuario.Usu_medida_cintura));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_medida_calcado", usuario.Usu_medida_calcado));
            //objCommand.Parameters.Add(Mapped.Parameter("?usu_tentativas", usuario.usu_tentativas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_reputacao", usuario.Usu_reputacao));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cadastroCompleto", usuario.Usu_cadastroCompleto));
            //Chave estrangeira                             
            objCommand.Parameters.Add(Mapped.Parameter("?tip_codigo", usuario.Tipo.Tip_codigo));
            //objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", usuario.Subcategoria.Sub_codigo));
            objCommand.ExecuteNonQuery();
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

    //Select
    public static DataSet SelectAll()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT usu_cpf_cnpj,usu_foto_perfil, usu_nome,(Date_Format(usu_data_cadastro,'%d/%m/%Y')) As data,case when tip_codigo='2'" +
            " then'Usuário' else 'Administrador' end tip_codigo, case when usu_status_cadastro='1' then 'Ativo' else 'Inativo' end usu_status_cadastro" +
            " FROM usu_usuarios ORDER BY usu_nome", objConnection);

        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds); // O objeto DataAdapter vai preencher o 
        // DataSet com os dados do BD, O método Fill é o responsável por 
        // preencher o DataSet
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectAllg()
    {

        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT usu_cpf_cnpj,usu_foto_perfil,usu_email, usu_nome,(Date_Format(usu_data_cadastro,'%d/%m/%Y')) As data,case when tip_codigo='2'" +
            " then'Usuário' else 'Administrador' end tip_codigo, case when usu_status_cadastro='1' then 'Ativo' else 'Inativo' end usu_status_cadastro" +
            " FROM usu_usuarios ORDER BY usu_nome", objConnection);

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
    public static DataSet SelectAId(int cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from usu_usuarios u where u.usu_cpf_cnpj= ?cpf;";
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataAdapter = Mapped.Adapter(objCommand);

        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectAIdUsu(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        string sql = "select * from sub_subcategorias where usu_cpf_cnpj = ?id;";
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
    }//---------------------------------

    //UPDATE
    public static int Update(Usuario user)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_nome = ?usu_nome, usu_email = ?usu_email, usu_telefone = ?usu_telefone, usu_data_nasc = ?usu_data_nasc, usu_sexo = ?usu_sexo, usu_cadastroCompleto = 2 WHERE usu_cpf_cnpj= ?usu_cpf_cnpj; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_nome", user.Usu_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", user.Usu_email));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_telefone", user.Usu_telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_data_nasc", user.Usu_data_nasc));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_sexo", user.Usu_sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", user.Usu_cpf_cnpj));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cadastroCompleto", user.Usu_cadastroCompleto));
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
    //--------------------------------------------

    //UPDATE do cadastro completo
    public static int UpdateCadastro(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_cadastroCompleto = ?usu_cadastroCompleto WHERE usu_cpf_cnpj= ?usu_cpf_cnpj; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cadastroCompleto", usuario.Usu_cadastroCompleto));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
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
    //--------------------------------------------
    //Login para devolver objeto
    public Usuario Autentica(string email, string senha)
    {
        Usuario usuario = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios WHERE usu_email = ?usu_email and usu_senha = ?usu_senha", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_email", email));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", senha));
        objDataReader = objCommand.ExecuteReader();
        int tipo = 0;
        while (objDataReader.Read())
        {
            usuario = new Usuario();
            usuario.Usu_cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
            usuario.Usu_nome = Convert.ToString(objDataReader["usu_nome"]);
            usuario.Usu_sexo = Convert.ToString(objDataReader["usu_sexo"]);
            if (objDataReader["usu_data_nasc"] != DBNull.Value)
            {
                usuario.Usu_data_nasc = Convert.ToDateTime(objDataReader["usu_data_nasc"]);
            }
            usuario.Usu_email = Convert.ToString(objDataReader["usu_email"]);
            usuario.Usu_senha = Convert.ToString(objDataReader["usu_senha"]);
            usuario.Usu_telefone = Convert.ToString(objDataReader["usu_telefone"]);
            usuario.Usu_data_cadastro = Convert.ToDateTime(objDataReader["usu_data_cadastro"]);
            usuario.Usu_status_cadastro = Convert.ToBoolean(objDataReader["usu_status_cadastro"]);
            usuario.Usu_foto_perfil = Convert.ToString(objDataReader["usu_foto_perfil"]);
            usuario.Usu_nome_loja = Convert.ToString(objDataReader["usu_nome_loja"]);
            usuario.Usu_qtdd_vendas = Convert.ToInt32(objDataReader["usu_qtdd_vendas"]);
            usuario.Usu_qtdd_vendas_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_vendas_canceladas"]);
            usuario.Usu_qtdd_denuncia = Convert.ToInt32(objDataReader["usu_qtdd_denuncia"]);
            usuario.Usu_qtdd_compras = Convert.ToInt32(objDataReader["usu_qtdd_compras"]);
            usuario.Usu_qtdd_compras_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_compras_canceladas"]);
            usuario.Usu_medida_busto = Convert.ToString(objDataReader["usu_medida_busto"]);
            usuario.Usu_medida_cintura = Convert.ToString(objDataReader["usu_medida_cintura"]);
            usuario.Usu_medida_calcado = Convert.ToString(objDataReader["usu_medida_calcado"]);
            usuario.Usu_reputacao = Convert.ToDouble(objDataReader["usu_reputacao"]);
            usuario.Usu_cadastroCompleto = Convert.ToInt32(objDataReader["usu_cadastroCompleto"]);
            tipo = Convert.ToInt32(objDataReader["tip_codigo"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (tipo != 0)
        {
            TipoUsuarioDB db = new TipoUsuarioDB();
            db.Select(tipo);
            usuario.Tipo = db.Select(tipo);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return usuario;
    }
    //------------

    //select que devolve tudo em 1 obj
    public Usuario Select(string cpf)
    {
        Usuario usuario = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT *,(select concat(end_cidade,'/',end_estado) from end_enderecos e where e.usu_cpf_cnpj = u.usu_cpf_cnpj limit 1)as cidest FROM usu_usuarios u WHERE u.usu_cpf_cnpj = ?cpf", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataReader = objCommand.ExecuteReader();
        int tipo = 0;
        int sub = 0;
        while (objDataReader.Read())
        {
            usuario = new Usuario();
            usuario.Usu_cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
            usuario.Usu_nome = Convert.ToString(objDataReader["usu_nome"]);
            usuario.Usu_sexo = Convert.ToString(objDataReader["usu_sexo"]);
            if (objDataReader["usu_data_nasc"] != DBNull.Value)
            {
                usuario.Usu_data_nasc = Convert.ToDateTime(objDataReader["usu_data_nasc"]);
            }
            //else
            //{
            //    usuario.Usu_data_nasc = "";
            //}
            usuario.Usu_email = Convert.ToString(objDataReader["usu_email"]);
            usuario.Usu_senha = Convert.ToString(objDataReader["usu_senha"]);
            usuario.Usu_telefone = Convert.ToString(objDataReader["usu_telefone"]);
            usuario.Usu_data_cadastro = Convert.ToDateTime(objDataReader["usu_data_cadastro"]);
            usuario.Usu_status_cadastro = Convert.ToBoolean(objDataReader["usu_status_cadastro"]);
            usuario.Usu_foto_perfil = Convert.ToString(objDataReader["usu_foto_perfil"]);
            usuario.Usu_nome_loja = Convert.ToString(objDataReader["usu_nome_loja"]);
            usuario.Usu_qtdd_vendas = Convert.ToInt32(objDataReader["usu_qtdd_vendas"]);
            usuario.Usu_qtdd_vendas_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_vendas_canceladas"]);
            usuario.Usu_qtdd_denuncia = Convert.ToInt32(objDataReader["usu_qtdd_denuncia"]);
            usuario.Usu_qtdd_compras = Convert.ToInt32(objDataReader["usu_qtdd_compras"]);
            usuario.Usu_qtdd_compras_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_compras_canceladas"]);
            usuario.Usu_medida_busto = Convert.ToString(objDataReader["usu_medida_busto"]);
            usuario.Usu_medida_cintura = Convert.ToString(objDataReader["usu_medida_cintura"]);
            usuario.Usu_medida_calcado = Convert.ToString(objDataReader["usu_medida_calcado"]);
            usuario.Usu_reputacao = Convert.ToDouble(objDataReader["usu_reputacao"]);
            usuario.Usu_cadastroCompleto = Convert.ToInt32(objDataReader["usu_cadastroCompleto"]);
            tipo = Convert.ToInt32(objDataReader["tip_codigo"]);
            sub = Convert.ToInt32(objDataReader["sub_codigo"]);
            usuario.CidadeEstado = Convert.ToString(objDataReader["cidest"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (tipo != 0)
        {
            TipoUsuarioDB db = new TipoUsuarioDB();
            db.Select(tipo);
            usuario.Tipo = db.Select(tipo);
        }
        if (sub != 0)
        {
            SubcategoriaDB data = new SubcategoriaDB();
            data.SelectSubUsuario(sub);
            usuario.Subcategoria = data.SelectSubUsuario(sub);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return usuario;
    }

    public static Usuario SelectUsuario(string cpf)
    {
        Usuario usuario = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT *,(select concat(end_cidade,'/',end_estado) from end_enderecos e where e.usu_cpf_cnpj = u.usu_cpf_cnpj limit 1)as cidest FROM usu_usuarios u WHERE u.usu_cpf_cnpj = ?cpf", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataReader = objCommand.ExecuteReader();
        int tipo = 0;
        while (objDataReader.Read())
        {
            usuario = new Usuario();
            usuario.Usu_cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
            usuario.Usu_nome = Convert.ToString(objDataReader["usu_nome"]);
            usuario.Usu_sexo = Convert.ToString(objDataReader["usu_sexo"]);
            if (objDataReader["usu_data_nasc"] != DBNull.Value)
            {
                usuario.Usu_data_nasc = Convert.ToDateTime(objDataReader["usu_data_nasc"]);
            }
            usuario.Usu_email = Convert.ToString(objDataReader["usu_email"]);
            usuario.Usu_senha = Convert.ToString(objDataReader["usu_senha"]);
            usuario.Usu_telefone = Convert.ToString(objDataReader["usu_telefone"]);
            usuario.Usu_data_cadastro = Convert.ToDateTime(objDataReader["usu_data_cadastro"]);
            usuario.Usu_status_cadastro = Convert.ToBoolean(objDataReader["usu_status_cadastro"]);
            usuario.Usu_foto_perfil = Convert.ToString(objDataReader["usu_foto_perfil"]);
            usuario.Usu_nome_loja = Convert.ToString(objDataReader["usu_nome_loja"]);
            usuario.Usu_qtdd_vendas = Convert.ToInt32(objDataReader["usu_qtdd_vendas"]);
            usuario.Usu_qtdd_vendas_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_vendas_canceladas"]);
            usuario.Usu_qtdd_denuncia = Convert.ToInt32(objDataReader["usu_qtdd_denuncia"]);
            usuario.Usu_qtdd_compras = Convert.ToInt32(objDataReader["usu_qtdd_compras"]);
            usuario.Usu_qtdd_compras_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_compras_canceladas"]);
            usuario.Usu_medida_busto = Convert.ToString(objDataReader["usu_medida_busto"]);
            usuario.Usu_medida_cintura = Convert.ToString(objDataReader["usu_medida_cintura"]);
            usuario.Usu_medida_calcado = Convert.ToString(objDataReader["usu_medida_calcado"]);
            usuario.Usu_reputacao = Convert.ToDouble(objDataReader["usu_reputacao"]);
            usuario.Usu_cadastroCompleto = Convert.ToInt32(objDataReader["usu_cadastroCompleto"]);
            tipo = Convert.ToInt32(objDataReader["tip_codigo"]);
            usuario.CidadeEstado = Convert.ToString(objDataReader["cidest"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (tipo != 0)
        {
            TipoUsuarioDB db = new TipoUsuarioDB();
            db.Select(tipo);
            usuario.Tipo = db.Select(tipo);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return usuario;
    }
    //----------------------------


    //select para a grid usuario 

    //SELECT AIDG
    public static Usuario SelectAidGrid(string id)
    {
        Usuario usuario = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios WHERE usu_cpf_cnpj = ?id", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?id", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            usuario = new Usuario();
            usuario.Usu_cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
        }//While
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return usuario;


    }//Select

    public static DataSet SelectAllGrid()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }
    public static int DesativarUser(string cpf)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_status_cadastro = 0 WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));// PK
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
    public static int AtivarUser(string cpf)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_status_cadastro = 1 WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));// PK
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
    //Desativar usuario
    public static bool UpdateStatusUsuario(Usuario usuario)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE usu_usuarios SET usu_status_cadastro = ?usu_status_cadastro WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_status_cadastro", usuario.Usu_status_cadastro));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }//Update

    //Search
    public static DataSet Search(string termo)
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios WHERE usu_nome LIKE ?nome ORDER BY usu_nome", objConexao);
        //objCommand = Mapped.Command("SELECT usu_cpf_cnpj,usu_foto_perfil,usu_email, usu_nome,(Date_Format(usu_data_cadastro,'%d/%m/%Y')) As data,case when tip_codigo='2'" +
        //  " then'Usuário' else 'Administrador' end tip_codigo, case when usu_status_cadastro='1' then 'Ativo' else 'Inativo' end usu_status_cadastro" +
        //  " FROM usu_usuarios WHERE usu_nome LIKE ?nome ORDER BY usu_nome", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?nome", '%' + termo + '%'));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }
    public static DataSet SelectADM()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM usu_usuarios where tip_codigo = 1", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return ds;
    }
    public static bool updateSubCatAcessada(Usuario usuario)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE usu_usuarios SET sub_codigo = ?sub_codigo WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", usuario.Subcategoria.Sub_codigo));
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        return true;
    }//Update


    //Adicionar ADM
    public static int AdicionarAdministrador(string cpf)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET tip_codigo = 1 WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));// PK
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
    // remover adm
    public static int RemoverAdministrador(string cpf)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET tip_codigo = 2 WHERE usu_cpf_cnpj= ?usu_cpf_cnpj";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));// PK
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

    public static int UpdateTentativa(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_tentativas = ?usu_tentativas WHERE usu_email= ?usu_email; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_tentativas", usuario.usu_tentativas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usuario.Usu_email));
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
    public static int UpdateBanTime(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_tentativas = ?usu_tentativas, usu_tempoSuspenso = ?usu_tempoSuspenso WHERE usu_email= ?usu_email; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_tentativas", usuario.usu_tentativas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_tempoSuspenso", usuario.usu_tempoSuspenso));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usuario.Usu_email));
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

    public static int UpdateRep(Usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE usu_usuarios SET usu_reputacao = ?usu_reputacao ,usu_qtdd_vendas=?usu_qtdd_vendas WHERE usu_cpf_cnpj= ?usu_cpf_cnpj; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_reputacao", usuario.Usu_reputacao));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_qtdd_vendas", usuario.Usu_qtdd_vendas));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuario.Usu_cpf_cnpj));
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






    //public List<Usuario> TesteSelect(string cpf)
    //{
    //    List<Usuario> usuarios = new List<Usuario>();
    //    System.Data.IDbConnection objConexao;
    //    System.Data.IDbCommand objCommand;
    //    System.Data.IDataReader objDataReader;
    //    objConexao = Mapped.Connection();
    //    objCommand = Mapped.Command("SELECT * FROM usu_usuarios", objConexao);
    //    objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", usuarios.Usu_cpf_cnpj));
    //    objDataReader = objCommand.ExecuteReader();
    //    int tipo = 0;
    //    while (objDataReader.Read())
    //    {
    //        Usuario usuario = new Usuario();
    //        usuario.Usu_cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
    //        usuario.Usu_nome = Convert.ToString(objDataReader["usu_nome"]);
    //        usuario.Usu_sexo = Convert.ToString(objDataReader["usu_sexo"]);
    //        if (objDataReader["usu_data_nasc"] != DBNull.Value)
    //        {
    //            usuario.Usu_data_nasc = Convert.ToDateTime(objDataReader["usu_data_nasc"]);
    //        }
    //        usuario.Usu_email = Convert.ToString(objDataReader["usu_email"]);
    //        usuario.Usu_senha = Convert.ToString(objDataReader["usu_senha"]);
    //        usuario.Usu_telefone = Convert.ToString(objDataReader["usu_telefone"]);
    //        usuario.Usu_data_cadastro = Convert.ToDateTime(objDataReader["usu_data_cadastro"]);
    //        usuario.Usu_status_cadastro = Convert.ToBoolean(objDataReader["usu_status_cadastro"]);
    //        usuario.Usu_foto_perfil = Convert.ToString(objDataReader["usu_foto_perfil"]);
    //        usuario.Usu_nome_loja = Convert.ToString(objDataReader["usu_nome_loja"]);
    //        usuario.Usu_qtdd_vendas = Convert.ToInt32(objDataReader["usu_qtdd_vendas"]);
    //        usuario.Usu_qtdd_vendas_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_vendas_canceladas"]);
    //        usuario.Usu_qtdd_denuncia = Convert.ToInt32(objDataReader["usu_qtdd_denuncia"]);
    //        usuario.Usu_qtdd_compras = Convert.ToInt32(objDataReader["usu_qtdd_compras"]);
    //        usuario.Usu_qtdd_compras_canceladas = Convert.ToInt32(objDataReader["usu_qtdd_compras_canceladas"]);
    //        usuario.Usu_medida_busto = Convert.ToString(objDataReader["usu_medida_busto"]);
    //        usuario.Usu_medida_cintura = Convert.ToString(objDataReader["usu_medida_cintura"]);
    //        usuario.Usu_medida_calcado = Convert.ToString(objDataReader["usu_medida_calcado"]);
    //        usuario.Usu_reputacao = Convert.ToDouble(objDataReader["usu_reputacao"]);
    //        usuario.Usu_cadastroCompleto = Convert.ToInt32(objDataReader["usu_cadastroCompleto"]);
    //        tipo = Convert.ToInt32(objDataReader["tip_codigo"]);

    //        usuarios.Add(usuario);
    //    }
    //    objDataReader.Close();
    //    objConexao.Close();
    //    objCommand.Dispose();
         
    //    objConexao.Dispose();
    //    objDataReader.Dispose();
    //    return usuarios;
    //}
}

