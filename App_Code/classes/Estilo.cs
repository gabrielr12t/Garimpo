using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Estilos
/// </summary>
public class Estilo
{
    private int est_codigo;
    private string est_nome;
    private Usuario usuario;

    public int Est_codigo
    {
        get
        {
            return est_codigo;
        }

        set
        {
            est_codigo = value;
        }
    }

    public string Est_nome
    {
        get
        {
            return est_nome;
        }

        set
        {
            est_nome = value;
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