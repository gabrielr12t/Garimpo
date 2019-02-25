using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Favoritos
/// </summary>
public class Favorito
{
    private Usuario usuario;
    private Produto produto;

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