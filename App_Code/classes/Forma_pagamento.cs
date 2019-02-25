using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Forma_pagamentos
/// </summary>
public class Forma_pagamento
{
    private int for_codigo;
    private string for_pagamento;

    public int For_codigo
    {
        get
        {
            return for_codigo;
        }

        set
        {
            for_codigo = value;
        }
    }

    public string For_pagamento
    {
        get
        {
            return for_pagamento;
        }

        set
        {
            for_pagamento = value;
        }
    }
}