using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Compras
/// </summary>
public class Compra
{
    private int com_codigo;    
    private DateTime com_data;
    private double com_valor_total;

    private Usuario usuario;
    private Endereco endereco;
    private Env_forma_envio envio;
    private Forma_pagamento forma_pagamento;

    public int Com_codigo
    {
        get
        {
            return com_codigo;
        }

        set
        {
            com_codigo = value;
        }
    }

    public DateTime Com_data
    {
        get
        {
            return com_data;
        }

        set
        {
            com_data = value;
        }
    }

    public double Com_valor_total
    {
        get
        {
            return com_valor_total;
        }

        set
        {
            com_valor_total = value;
        }
    }

    

    public Usuario Usuario
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

    public Endereco Endereco
    {
        get
        {
            return endereco;
        }

        set
        {
            endereco = value;
        }
    }

    public Env_forma_envio Envio
    {
        get
        {
            return envio;
        }

        set
        {
            envio = value;
        }
    }

    public Forma_pagamento Forma_pagamento
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
}