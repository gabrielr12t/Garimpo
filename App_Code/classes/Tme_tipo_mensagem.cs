using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tme_tipo_mensagem
/// </summary>
public class Tme_tipo_mensagem
{
    private int tme_codigo;
    private string tme_nome_tipo;

    public int Tme_codigo
    {
        get
        {
            return tme_codigo;
        }

        set
        {
            tme_codigo = value;
        }
    }

    public string Tme_nome_tipo
    {
        get
        {
            return tme_nome_tipo;
        }

        set
        {
            tme_nome_tipo = value;
        }
    }
}