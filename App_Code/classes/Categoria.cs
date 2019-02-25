using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Categoria
{
    private int cat_codigo;
    private string cat_nome;    
    private Estilo estilo;

    public int Cat_codigo
    {
        get
        {
            return cat_codigo;
        }

        set
        {
            cat_codigo = value;
        }
    }

    public string Cat_nome
    {
        get
        {
            return cat_nome;
        }

        set
        {
            cat_nome = value;
        }
    }

    public global::Estilo Estilo
    {
        get
        {
            return estilo;
        }

        set
        {
            estilo = value;
        }
    }
}