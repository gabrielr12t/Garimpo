using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fpp_forma_produtos
/// </summary>
public class Fpp_forma_produto
{   
    private Forma_pagamento forma_pagamento;
    private Produto produto;

    public global::Forma_pagamento Forma_pagamento
    {
        get
        {
            return forma_pagamento;
        }

        set
        {
            forma_pagamento = value;
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