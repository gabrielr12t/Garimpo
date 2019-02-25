using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Denuncias
/// </summary>
public class Denuncia
{
    private int den_codigo;   
    private int den_opcao;
    private int den_tipo;  
    private Usuario usuario;   
    private Produto produto;

    public int Den_codigo
    {
        get
        {
            return den_codigo;
        }

        set
        {
            den_codigo = value;
        }
    }

    public int Den_opcao
    {
        get
        {
            return den_opcao;
        }

        set
        {
            den_opcao = value;
        }
    }

    public int Den_tipo
    {
        get
        {
            return den_tipo;
        }

        set
        {
            den_tipo = value;
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

    public global::Produto Produto
    {
        get
        {
            return produto;
        }

        set
        {
            produto = value;
        }
    }
}