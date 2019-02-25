using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Env_forma_envio
/// </summary>
public class Env_forma_envio
{
    private int env_codigo;
    private string env_nome;

    public int Env_codigo
    {
        get
        {
            return env_codigo;
        }

        set
        {
            env_codigo = value;
        }
    }

    public string Env_nome
    {
        get
        {
            return env_nome;
        }

        set
        {
            env_nome = value;
        }
    }
}