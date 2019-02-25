using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cor_produto
/// </summary>
public class Cop_cor_produto
{           
    private Cor cor;
    private Produto produto;

    public global::Cor Cor
    {
        get
        {
            return cor;
        }

        set
        {
            cor = value;
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