using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fotos
/// </summary>
public class Foto
{
    private int fot_codigo;
    private string fot_url;    
    private Produto produto;

    public int Fot_codigo
    {
        get
        {
            return fot_codigo;
        }

        set
        {
            fot_codigo = value;
        }
    }

    public string Fot_url
    {
        get
        {
            return fot_url;
        }

        set
        {
            fot_url = value;
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