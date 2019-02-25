using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ProdutoDB
/// </summary>
public class ProdutoDB
{
    //ProdutoDB.UpdateQuantidade();
    public static int UpdateQuantidade(Produto produto, int qtd)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE pro_produtos SET pro_codigo = ?pro_codigo, pro_quantidade = (?pro_quantidade - " + qtd + ")  WHERE pro_codigo= ?pro_codigo; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", produto.Pro_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_quantidade", produto.Pro_quantidade));


            //objCommand.Parameters.Add(Mapped.Parameter("?pro_status", produto.Pro_status));
            //objCommand.Parameters.Add(Mapped.Parameter("?pro_moderacao_status", produto.Pro_moderacao_status));                                                
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
    public static int Insert(Produto produto)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "INSERT INTO pro_produtos (pro_nome, pro_descricao, pro_preco, pro_preco_antigo, pro_condicao, pro_quantidade, pro_medida, pro_status,pro_moderacao_status, pro_acesso, sub_codigo, mar_codigo, usu_cpf_cnpj) VALUES (?pro_nome, ?pro_descricao, ?pro_preco, ?pro_preco_antigo, ?pro_condicao, ?pro_quantidade, ?pro_medida, ?pro_status,?pro_moderacao_status, ?pro_acesso, ?sub_codigo, ?mar_codigo, ?usu_cpf_cnpj)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_nome", produto.Pro_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_descricao", produto.Pro_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_preco", produto.Pro_preco));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_preco_antigo", produto.Pro_preco_antigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_condicao", produto.Pro_condicao));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_quantidade", produto.Pro_quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_medida", produto.Pro_medida));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_status", produto.Pro_status));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_moderacao_status", produto.Pro_moderacao_status));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_acesso", produto.Pro_acesso));
            objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", produto.Subcategoria.Sub_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?mar_codigo", produto.Marca.Mar_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", produto.Usuario.Usu_cpf_cnpj));
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
    //------
    public static int Update(Produto produto)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "UPDATE pro_produtos SET pro_codigo = ?pro_codigo, pro_nome = ?pro_nome, pro_descricao = ?pro_descricao ,pro_preco_antigo = ?pro_preco_antigo, pro_preco = ?pro_preco, pro_condicao = ?pro_condicao, pro_quantidade = ?pro_quantidade, pro_status = 0, pro_moderacao_status = 0, sub_codigo=?sub_codigo, mar_codigo = ?mar_codigo WHERE pro_codigo= ?pro_codigo; ";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", produto.Pro_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_nome", produto.Pro_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_descricao", produto.Pro_descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_preco_antigo", produto.Pro_preco_antigo));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_preco", produto.Pro_preco));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_condicao", produto.Pro_condicao));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_quantidade", produto.Pro_quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", produto.Subcategoria.Sub_codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?mar_codigo", produto.Marca.Mar_codigo));

            //objCommand.Parameters.Add(Mapped.Parameter("?pro_status", produto.Pro_status));
            //objCommand.Parameters.Add(Mapped.Parameter("?pro_moderacao_status", produto.Pro_moderacao_status));                                                
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
    public static int Desativar(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;  // Abre a conexao
            IDbCommand objCommand;  // Cria o comando
            string sql = "Update pro_produtos set pro_status = 0 where pro_codigo = ?codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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
    public static int Ativar(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "Update pro_produtos set pro_status = 1 where pro_codigo = ?codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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
    //Moderar Produto
    public static int AceitarModeracao(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "Update pro_produtos set pro_moderacao_status = 1 where pro_codigo = ?codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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
    public static int ProdutoNaoAceito(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "Update pro_produtos set pro_moderacao_status = 2, pro_status = 0 where pro_codigo = ?codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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
    //Produto bloqueado por denuncia
    public static int BloquearProduto(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "Update pro_produtos set pro_moderacao_status = 0, pro_status = 0 where pro_codigo = ?codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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

    //SELECT
    public static DataSet SelectAllAcesso()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select *,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p inner join sub_subcategorias as sub on sub.sub_codigo = p.sub_codigo inner join cat_categorias as c on sub.cat_codigo = c.cat_codigo  where p.pro_moderacao_status = 1 and p.pro_status = 1 and p.pro_quantidade > 0 ORDER BY p.pro_acesso desc", objConnection);
        //objCommand = Mapped.Command("select * ,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p inner join sub_subcategorias as sub on sub.sub_codigo = p.sub_codigo inner join cat_categorias as c on sub.cat_codigo = c.cat_codigo inner join usu_usuarios as u where p.pro_moderacao_status = 1 and p.pro_status = 1 ORDER BY p.pro_acesso desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectAllAcesso(string produtos)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select *,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p inner join sub_subcategorias as sub on sub.sub_codigo = p.sub_codigo inner join cat_categorias as c on sub.cat_codigo = c.cat_codigo  where p.pro_moderacao_status = 1 and p.pro_status = 1 and p.pro_codigo in (" + produtos + ") ORDER BY p.pro_codigo asc", objConnection);
        //objCommand = Mapped.Command("select DISTINCT *,fav.usu_cpf , fav.pro_codigo,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p inner join fav_favoritos as fav inner join sub_subcategorias as sub on sub.sub_codigo = p.sub_codigo inner join cat_categorias as c on sub.cat_codigo = c.cat_codigo  where p.pro_moderacao_status = 1 and p.pro_status = 1 ORDER BY p.pro_acesso desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectAllDS()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select DISTINCT * from pro_produtos as p inner join usu_usuarios as u on u.usu_cpf_cnpj = p.usu_cpf_cnpj order by  p.pro_codigo asc", objConnection);
        //objCommand = Mapped.Command("select DISTINCT *,fav.usu_cpf , fav.pro_codigo,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p inner join fav_favoritos as fav inner join sub_subcategorias as sub on sub.sub_codigo = p.sub_codigo inner join cat_categorias as c on sub.cat_codigo = c.cat_codigo  where p.pro_moderacao_status = 1 and p.pro_status = 1 ORDER BY p.pro_acesso desc", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectAleatorioSubcategoria(int cod)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("select *,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p where p.sub_codigo = ?sub_codigo and p.pro_status = 1 and p.pro_moderacao_status = 1", objConnection);
        objCommand = Mapped.Command("select *,(SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p inner JOIN sub_subcategorias as s on p.sub_codigo = s.sub_codigo where s.cat_codigo = ?cat_codigo and p.pro_status = 1 and p.pro_moderacao_status = 1 and p.pro_quantidade > 0", objConnection);
        objCommand.Parameters.Add(Mapped.Parameter("?cat_codigo", cod));
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectProdutosByEstilos(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();

        //objCommand = Mapped.Command("select e.est_nome,c.cat_nome,s.sub_nome,e.est_codigo,c.cat_codigo,s.sub_codigo,p.pro_codigo, p.pro_nome, p.pro_descricao, p.pro_condicao, p.pro_preco, p.pro_peso, " +
        //    "p.pro_medida, p.pro_quantidade, p.mar_codigo, p.sub_codigo,(select f.fot_url from fot_fotos as f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p" +
        //    " inner join sub_subcategorias as s on s.sub_codigo = p.sub_codigo inner join cat_categorias as c on c.cat_codigo = s.cat_codigo " +
        //    "inner join est_estilos as e on c.est_codigo = e.est_codigo where e.est_codigo = ?est_codigo;", objConnection);
        objCommand = Mapped.Command("select e.est_nome,p.usu_cpf_cnpj,p.pro_status,p.pro_moderacao_status,c.cat_nome,s.sub_nome,e.est_codigo,c.cat_codigo,s.sub_codigo,p.pro_codigo, p.pro_nome, p.pro_descricao, p.pro_condicao, p.pro_preco, p.pro_peso, p.pro_medida, p.pro_quantidade, p.mar_codigo, p.sub_codigo," +
            "(select f.fot_url from fot_fotos as f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p inner join sub_subcategorias as s on s.sub_codigo = p.sub_codigo inner join cat_categorias as c on c.cat_codigo = s.cat_codigo inner join est_estilos as e on c.est_codigo = e.est_codigo " +
            "where e.est_codigo = ?est_codigo and pro_status = 1 and pro_moderacao_status = 1 and pro_quantidade>1", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?est_codigo", id));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    //

    //analisar
    public Produto SelectNew(string cpf)
    {
        Produto produto = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pro_produtos WHERE usu_cpf_cnpj = ?cpf", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataReader = objCommand.ExecuteReader();
        string cpf_cnpj = "";
        while (objDataReader.Read())
        {
            produto = new Produto();
            produto.Pro_codigo = Convert.ToInt32(objDataReader["pro_codigo"]);
            produto.Pro_nome = Convert.ToString(objDataReader["pro_nome"]);
            produto.Pro_descricao = Convert.ToString(objDataReader["pro_descricao"]);
            produto.Pro_condicao = Convert.ToString(objDataReader["pro_condicao"]);
            produto.Pro_preco = Convert.ToDouble(objDataReader["pro_preco"]);
            produto.Pro_medida = Convert.ToString(objDataReader["pro_medida"]);
            produto.Pro_quantidade = Convert.ToInt32(objDataReader["pro_quantidade"]);
            produto.Pro_status = Convert.ToBoolean(objDataReader["pro_status"]);
            cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (cpf_cnpj != "")
        {
            UsuarioDB db = new UsuarioDB();
            db.Select(cpf_cnpj);
            produto.Usuario = db.Select(cpf_cnpj);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return produto;
    }
    //

    //select produto do usuario logado
    public static Produto Select(string cpf)
    {
        Produto produto = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pro_produtos WHERE usu_cpf_cnpj = ?cpf", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cpf", cpf));
        objDataReader = objCommand.ExecuteReader();
        string cpf_cnpj = "";
        while (objDataReader.Read())
        {
            produto = new Produto();
            produto.Pro_codigo = Convert.ToInt32(objDataReader["pro_codigo"]);
            produto.Pro_nome = Convert.ToString(objDataReader["pro_nome"]);
            produto.Pro_descricao = Convert.ToString(objDataReader["pro_descricao"]);
            produto.Pro_condicao = Convert.ToString(objDataReader["pro_condicao"]);
            produto.Pro_preco = Convert.ToDouble(objDataReader["pro_preco"]);
            produto.Pro_medida = Convert.ToString(objDataReader["pro_medida"]);
            produto.Pro_quantidade = Convert.ToInt32(objDataReader["pro_quantidade"]);
            produto.Pro_status = Convert.ToBoolean(objDataReader["pro_status"]);
            cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (cpf_cnpj != "")
        {
            UsuarioDB db = new UsuarioDB();
            db.Select(cpf_cnpj);
            produto.Usuario = db.Select(cpf_cnpj);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return produto;
    }
    //----------------------------

    //public static Produto SelectID(int id)
    public Produto SelectIDQuantidade(int id)
    {
        Produto produto = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pro_produtos WHERE pro_codigo = ?pro_codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", id));
        objDataReader = objCommand.ExecuteReader();
        string cpf_cnpj = "";
        int sub_categoria = 0;
        int marca = 0;
        while (objDataReader.Read())
        {
            produto = new Produto();
            produto.Pro_codigo = Convert.ToInt32(objDataReader["pro_codigo"]);
            produto.Pro_nome = Convert.ToString(objDataReader["pro_nome"]);
            produto.Pro_descricao = Convert.ToString(objDataReader["pro_descricao"]);
            produto.Pro_condicao = Convert.ToString(objDataReader["pro_condicao"]);
            produto.Pro_preco = Convert.ToDouble(objDataReader["pro_preco"]);
            produto.Pro_preco_antigo = Convert.ToDouble(objDataReader["pro_preco_antigo"]);
            produto.Pro_medida = Convert.ToString(objDataReader["pro_medida"]);
            produto.Pro_quantidade = Convert.ToInt32(objDataReader["pro_quantidade"]);
            produto.Pro_status = Convert.ToBoolean(objDataReader["pro_status"]);
            cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
            marca = Convert.ToInt32(objDataReader["mar_codigo"]);
            sub_categoria = Convert.ToInt32(objDataReader["sub_codigo"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (cpf_cnpj != "")
        {
            UsuarioDB db = new UsuarioDB();
            //db.Select(cpf_cnpj);
            produto.Usuario = db.Select(cpf_cnpj);
        }
        if (sub_categoria != 0)
        {
            produto.Subcategoria = SubcategoriaDB.Select(sub_categoria);
        }
        if (marca != 0)
        {
            produto.Marca = MarcasDB.Select(marca);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return produto;
    }
    public static Produto SelectID(int id)
    {
        Produto produto = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pro_produtos WHERE pro_codigo = ?pro_codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", id));
        objDataReader = objCommand.ExecuteReader();
        string cpf_cnpj = "";
        int sub_categoria = 0;
        int marca = 0;
        while (objDataReader.Read())
        {
            produto = new Produto();
            produto.Pro_codigo = Convert.ToInt32(objDataReader["pro_codigo"]);
            produto.Pro_nome = Convert.ToString(objDataReader["pro_nome"]);
            produto.Pro_descricao = Convert.ToString(objDataReader["pro_descricao"]);
            produto.Pro_condicao = Convert.ToString(objDataReader["pro_condicao"]);
            produto.Pro_preco = Convert.ToDouble(objDataReader["pro_preco"]);
            produto.Pro_preco_antigo = Convert.ToDouble(objDataReader["pro_preco_antigo"]);
            produto.Pro_medida = Convert.ToString(objDataReader["pro_medida"]);
            produto.Pro_quantidade = Convert.ToInt32(objDataReader["pro_quantidade"]);
            produto.Pro_status = Convert.ToBoolean(objDataReader["pro_status"]);
            cpf_cnpj = Convert.ToString(objDataReader["usu_cpf_cnpj"]);
            marca = Convert.ToInt32(objDataReader["mar_codigo"]);
            sub_categoria = Convert.ToInt32(objDataReader["sub_codigo"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        if (cpf_cnpj != "")
        {
            UsuarioDB db = new UsuarioDB();
            //db.Select(cpf_cnpj);
            produto.Usuario = db.Select(cpf_cnpj);
        }
        if (sub_categoria != 0)
        {
            produto.Subcategoria = SubcategoriaDB.Select(sub_categoria);
        }
        if (marca != 0)
        {
            produto.Marca = MarcasDB.Select(marca);
        }
        objConexao.Dispose();
        objDataReader.Dispose();
        return produto;
    }
    //select produto pelo codigo
    public Produto SelectCodigo(int codigo)
    {
        Produto produto = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM pro_produtos WHERE pro_codigo = ?codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            produto = new Produto();
            produto.Pro_codigo = Convert.ToInt32(objDataReader["pro_codigo"]);
            produto.Pro_nome = Convert.ToString(objDataReader["pro_nome"]);
            produto.Pro_descricao = Convert.ToString(objDataReader["pro_descricao"]);
            produto.Pro_condicao = Convert.ToString(objDataReader["pro_condicao"]);
            produto.Pro_preco = Convert.ToDouble(objDataReader["pro_preco"]);
            produto.Pro_medida = Convert.ToString(objDataReader["pro_medida"]);
            produto.Pro_quantidade = Convert.ToInt32(objDataReader["pro_quantidade"]);
            produto.Pro_status = Convert.ToBoolean(objDataReader["pro_status"]);
        }
        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return produto;
    }
    //----------------------------

    public static DataSet SelectAllCPFProdutosAtivo(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT pro_codigo, pro_nome, pro_quantidade, pro_descricao, pro_preco,sub_codigo, case when pro_status='0' then'Inativo' else 'Ativo' end pro_status,case when pro_moderacao_status='0' then'Em andamento' when 1 then'Aprovado' else 'Não aprovado'end pro_moderacao_status , usu_cpf_cnpj from pro_produtos where usu_cpf_cnpj = ?usu_cpf_cnpj and pro_status=1 and pro_moderacao_status=1", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectAll(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT (SELECT f.fot_url from fot_fotos as f where f.pro_codigo = p.pro_codigo limit 1) as foto,p.pro_codigo, p.pro_nome, p.pro_quantidade, p.pro_descricao, p.pro_preco,p.sub_codigo,p.usu_cpf_cnpj,i.com_codigo, i.ite_quantidade,forma.for_pagamento, e.end_cep,e.end_estado,e.end_cidade,e.end_bairro,e.end_endereco,e.end_referencia,e.end_numero,e.usu_cpf_cnpj,u.usu_nome,u.usu_email,u.usu_telefone,c.com_data,.i.ite_status from pro_produtos as p inner join ite_itens as i on p.pro_codigo = i.pro_codigo inner JOIN com_compras as c on i.com_codigo = c.com_codigo inner join for_forma_pagamentos as forma on c.for_codigo = forma.for_codigo inner join end_enderecos as e on c.end_codigo = e.end_codigo inner join env_formas_envios env on env.env_codigo = c.env_codigo inner join usu_usuarios as u on u.usu_cpf_cnpj = c.usu_cpf_cnpj where p.usu_cpf_cnpj = ?usu_cpf_cnpj", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //   select *, (SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p ORDER BY p.pro_codigo
    public static DataSet SelectProdutoVendedor(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select *, (SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p inner join sub_subcategorias as s on s.sub_codigo = p.sub_codigo inner join cat_categorias as c on s.cat_codigo = c.cat_codigo where usu_cpf_cnpj = ?usu_cpf_cnpj and pro_status=1 and pro_moderacao_status=1", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet ProdutosNaoModerados(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT pro_codigo, pro_nome, pro_quantidade, pro_descricao, pro_preco, case when pro_status='0' then'Inativo' else 'Ativo' end pro_status,case when pro_moderacao_status='0' then'Em andamento' when 1 then'Aprovado' else 'Não aprovado' end pro_moderacao_status , usu_cpf_cnpj from pro_produtos where usu_cpf_cnpj = ?usu_cpf_cnpj and pro_status=1 and pro_moderacao_status=0", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectAllCPFProdutosInativos(string cpf)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT pro_codigo,pro_nome, pro_quantidade, pro_descricao, pro_preco, case when pro_status='0' then'Inativo' else 'Ativo' end pro_status,case pro_moderacao_status when 0 then'Em andamento' when 1 then'Aprovado' when 2 then'Não aprovado' else'xiii' end pro_moderacao_status , usu_cpf_cnpj from pro_produtos where usu_cpf_cnpj = ?usu_cpf_cnpj and pro_status=0", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?usu_cpf_cnpj", cpf));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectProdutosModerar()
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("SELECT pro_descricao , left(pro_descricao , 20), pro_codigo,pro_nome, pro_quantidade, pro_preco, usu_cpf_cnpj from pro_produtos where pro_moderacao_status = 0", objConnection);
        objCommand = Mapped.Command("SELECT distinct SubString(p.pro_descricao,1,16) descricao ,u.usu_nome, m.mar_nome marca,u.usu_reputacao,p.pro_codigo,p.pro_nome," +
            " p.pro_quantidade, p.pro_preco, p.usu_cpf_cnpj, (SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) foto" +
            " from pro_produtos p inner join fot_fotos as f on f.pro_codigo = p.pro_codigo inner join mar_marcas as m on m.mar_codigo = p.mar_codigo" +
            " inner join usu_usuarios as u on p.usu_cpf_cnpj=u.usu_cpf_cnpj and p.pro_moderacao_status = 0;", objConnection); ;
        //objCommand = Mapped.Command("SELECT p.pro_descricao ,u.usu_nome,u.usu_reputacao, f.fot_url, left(p.pro_descricao , 20), p.pro_codigo,p.pro_nome, p.pro_quantidade, p.pro_preco, p.usu_cpf_cnpj from pro_produtos p inner join fot_fotos as f on f.pro_codigo = p.pro_codigo inner join usu_usuarios as u on p.usu_cpf_cnpj=u.usu_cpf_cnpj and p.pro_moderacao_status = 0;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet selectFoto(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * from fot_fotos where fot_codigo = ?fot_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?fot_codigo", codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectAllDS(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT *, (SELECT f.fot_url from fot_fotos f where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos p where pro_codigo = ?pro_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    //select produto pela categoria selecionado
    public static DataSet SelectPrudutoByCategoria(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("select *,(SELECT f.fot_url From fot_fotos as f LIMIT 1) foto from est_estilos as e inner join cat_categorias as c on e.est_codigo = c.est_codigo inner JOIN sub_subcategorias as s on c.cat_codigo = s.cat_codigo inner join pro_produtos as p on s.sub_codigo=p.sub_codigo where c.cat_codigo = ?cat_codigo;", objConnection);
        objCommand = Mapped.Command("select e.est_nome,p.usu_cpf_cnpj,p.pro_status,p.pro_moderacao_status,c.cat_nome,s.sub_nome,e.est_codigo,c.cat_codigo,s.sub_codigo,p.pro_codigo, p.pro_nome," +
            " p.pro_descricao, p.pro_condicao, p.pro_preco, p.pro_peso, p.pro_medida, p.pro_quantidade, p.mar_codigo, p.sub_codigo,(select f.fot_url from fot_fotos as f " +
            "where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p inner join sub_subcategorias as s on s.sub_codigo = p.sub_codigo inner join " +
            "cat_categorias as c on c.cat_codigo = s.cat_codigo inner join est_estilos as e on c.est_codigo = e.est_codigo where c.cat_codigo = ?cat_codigo and" +
            " pro_status = 1 and pro_moderacao_status =1 and pro_quantidade > 1;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?cat_codigo", id));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectPrudutoBySubcategoria(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select e.est_nome,p.usu_cpf_cnpj,p.pro_status,p.pro_moderacao_status,c.cat_nome,s.sub_nome,e.est_codigo,c.cat_codigo,s.sub_codigo,p.pro_codigo, " +
            "p.pro_nome, p.pro_descricao, p.pro_condicao, p.pro_preco, p.pro_peso, p.pro_medida, p.pro_quantidade, p.mar_codigo, p.sub_codigo,(select f.fot_url from fot_fotos as f" +
            " where p.pro_codigo = f.pro_codigo limit 1) as foto from pro_produtos as p inner join sub_subcategorias as s on s.sub_codigo = p.sub_codigo " +
            "inner join cat_categorias as c on c.cat_codigo = s.cat_codigo inner join est_estilos as e on c.est_codigo = e.est_codigo where s.sub_codigo = ?sub_codigo and pro_status = 1" +
            " and pro_moderacao_status = 1 and pro_quantidade > 1;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", id));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectAlterarProduto(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("SELECT f.fot_url,p.pro_codigo,e.est_nome,c.cat_nome,s.sub_nome,m.mar_nome,p.pro_nome,p.pro_descricao,p.pro_condicao,p.pro_preco,p.pro_medida, p.pro_quantidade,p.pro_status,p.pro_moderacao_status,p.usu_cpf_cnpj,e.est_codigo,c.cat_codigo,s.sub_codigo,p.sub_codigo,p.mar_codigo from pro_produtos as p inner join fot_fotos as f on p.pro_codigo = f.pro_codigo inner join mar_marcas as m on p.mar_codigo = m.mar_codigo inner join sub_subcategorias as s on s.sub_codigo = p.sub_codigo inner join cat_categorias as c on c.cat_codigo = s.cat_codigo inner JOIN est_estilos as e on e.est_codigo = c.est_codigo where p.pro_codigo = ?pro_codigo", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", id));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    //UPDATE `cadastro` SET `pontos` = `pontos` + 1 WHERE id = 102;
    public static int ProdutosMaisAcessados(int codigo)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "Update pro_produtos set pro_acesso = pro_acesso + 1 where pro_codigo = ?codigo";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
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

    public static DataSet selectProdutosInteressados(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        //objCommand = Mapped.Command("select distinct u.sub_codigo,c.cat_codigo,c.cat_nome,p.pro_codigo,p.pro_nome,p.pro_descricao,p.pro_condicao,p.pro_preco,p.pro_medida, p.pro_quantidade ,p.pro_status ,p.pro_moderacao_status ,p.pro_acesso,p.usu_cpf_cnpj,p.mar_codigo,p.sub_codigo,(select f.fot_url from fot_fotos as f where f.pro_codigo = p.pro_codigo LIMIT 1) foto from usu_usuarios as u inner join pro_produtos as p inner join sub_subcategorias as s on s.sub_codigo = u.sub_codigo inner join cat_categorias as c on s.cat_codigo = c.cat_codigo where s.sub_codigo = ?sub_codigo;", objConnection);
        objCommand = Mapped.Command("select *,(SELECT f.fot_url from fot_fotos as f where f.pro_codigo = p.pro_codigo limit 1) foto from pro_produtos as p where p.sub_codigo = ?sub_codigo and p.pro_status = 1 and p.pro_moderacao_status = 1 and p.pro_quantidade > 0;", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?sub_codigo", codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectVisualizarProduto(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select * from pro_produtos as p inner join fot_fotos as f on f.pro_codigo = p.pro_codigo inner join mar_marcas as m on m.mar_codigo = p.mar_codigo inner join cop_cores_produtos as cop on cop.pro_codigo = p.pro_codigo inner join enp_envio_produtos as enp on enp.pro_codigo = p.pro_codigo inner join sub_subcategorias as sub on sub.sub_codigo = p.sub_codigo inner join cat_categorias as cat on cat.cat_codigo = sub.cat_codigo inner join est_estilos as est on est.est_codigo = cat.est_codigo inner join cor_cores as cor on cor.cor_codigo = cop.cor_cod inner join env_formas_envios as env on env.env_codigo = enp.env_codigo  where p.pro_codigo = ?pro_codigo order by p.pro_nome", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
    public static DataSet SelectQuantidade(int codigo)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select p.pro_quantidade from pro_produtos as p where p.pro_codigo = ?pro_codigo ", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", codigo));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    //FILTRO

    public static DataSet SelectFiltroPreco(int pMin, int pMax)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select *,(select f.fot_url from fot_fotos as f where f.pro_codigo = p.pro_codigo limit 1) as foto from pro_produtos as p where p.pro_preco >= " + pMin + " and p.pro_preco <= " + pMax + " and p.pro_status = 1 and p.pro_moderacao_status = 1 and p.pro_quantidade > 0  order by p.pro_preco asc ", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        //objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", pMin));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }

    public static DataSet SelectFiltroMarca(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConnection;
        IDbCommand objCommand;
        IDataAdapter objDataAdapter;
        objConnection = Mapped.Connection();
        objCommand = Mapped.Command("select *,(select f.fot_url from fot_fotos as f where f.pro_codigo = p.pro_codigo limit 1) as foto from pro_produtos as p where p.mar_codigo = " + id+" and p.pro_quantidade > 0 and p.pro_status = 1 and p.pro_moderacao_status =1 ", objConnection);
        objDataAdapter = Mapped.Adapter(objCommand);
        //objCommand.Parameters.Add(Mapped.Parameter("?pro_codigo", pMin));
        objDataAdapter.Fill(ds);
        objConnection.Close();
        objCommand.Dispose();
        objConnection.Dispose();
        return ds;
    }
}