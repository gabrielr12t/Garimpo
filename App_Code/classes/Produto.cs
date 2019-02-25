using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Produtos
/// </summary>
public class Produto
{
    private int pro_codigo;
    private string pro_nome;
    private string pro_descricao;
    private string pro_condicao;
    private double pro_preco;
    private double pro_preco_antigo;
    private double pro_peso;
    private string pro_medida;
    private int pro_quantidade;
    private Boolean pro_status;//revisar
    private int pro_moderacao_status;
    private int pro_acesso;
    private Usuario usuario;
    private Marca marca;
    private Subcategoria subcategoria;

    public int Pro_codigo
    {
        get
        {
            return pro_codigo;
        }

        set
        {
            pro_codigo = value;
        }
    }

    public string Pro_nome
    {
        get
        {
            return pro_nome;
        }

        set
        {
            pro_nome = value;
        }
    }

    public string Pro_descricao
    {
        get
        {
            return pro_descricao;
        }

        set
        {
            pro_descricao = value;
        }
    }

    public string Pro_condicao
    {
        get
        {
            return pro_condicao;
        }

        set
        {
            pro_condicao = value;
        }
    }

    public double Pro_preco
    {
        get
        {
            return pro_preco;
        }

        set
        {
            pro_preco = value;
        }
    }

    public double Pro_peso
    {
        get
        {
            return pro_peso;
        }

        set
        {
            pro_peso = value;
        }
    }


    public int Pro_quantidade
    {
        get
        {
            return pro_quantidade;
        }

        set
        {
            pro_quantidade = value;
        }
    }

    public bool Pro_status
    {
        get
        {
            return pro_status;
        }

        set
        {
            pro_status = value;
        }
    }


    public global::Usuario Usuario
    {
        get
        {
            return usuario;
        }

        set
        {
            usuario = value;
        }
    }

    public global::Marca Marca
    {
        get
        {
            return marca;
        }

        set
        {
            marca = value;
        }
    }

    public global::Subcategoria Subcategoria
    {
        get
        {
            return subcategoria;
        }

        set
        {
            subcategoria = value;
        }
    }

    public int Pro_moderacao_status
    {
        get
        {
            return pro_moderacao_status;
        }

        set
        {
            pro_moderacao_status = value;
        }
    }

    public string Pro_medida
    {
        get
        {
            return pro_medida;
        }

        set
        {
            pro_medida = value;
        }
    }

    public int Pro_acesso
    {
        get
        {
            return pro_acesso;
        }

        set
        {
            pro_acesso = value;
        }
    }

    public double Pro_preco_antigo
    {
        get
        {
            return pro_preco_antigo;
        }

        set
        {
            pro_preco_antigo = value;
        }
    }
}