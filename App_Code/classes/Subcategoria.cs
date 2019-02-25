using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subcategorias
/// </summary>
public class Subcategoria
{
    private int sub_codigo;
    private string sub_nome;
    private string sub_figura;
    private Categoria categoria;

    public int Sub_codigo
    {
        get
        {
            return sub_codigo;
        }

        set
        {
            sub_codigo = value;
        }
    }

    public string Sub_nome
    {
        get
        {
            return sub_nome;
        }

        set
        {
            sub_nome = value;
        }
    }

    public string Sub_figura
    {
        get
        {
            return sub_figura;
        }

        set
        {
            sub_figura = value;
        }
    }

    public global::Categoria Categoria
    {
        get
        {
            return categoria;
        }

        set
        {
            categoria = value;
        }
    }
}