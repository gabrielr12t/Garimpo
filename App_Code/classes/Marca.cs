using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Marcas
/// </summary>
public class Marca
{
    private int mar_codigo;   
    private string mar_nome;
    private Usuario usuario;

    public int Mar_codigo
    {
        get
        {
            return mar_codigo;
        }

        set
        {
            mar_codigo = value;
        }
    }

    public string Mar_nome
    {
        get
        {
            return mar_nome;
        }

        set
        {
            mar_nome = value;
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
}