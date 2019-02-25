using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tipo
/// </summary>
public class Tipo_usuario
{
    private int tip_codigo;
    private string tip_nome_tipo;

    public int Tip_codigo
    {
        get
        {
            return tip_codigo;
        }

        set
        {
            tip_codigo = value;
        }
    }

    public string Tip_nome_tipo
    {
        get
        {
            return tip_nome_tipo;
        }

        set
        {
            tip_nome_tipo = value;
        }
    }
}