using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Enderecos
/// </summary>
public class Endereco
{
    private int end_codigo;
    private string end_cep;
    private string end_estado;
    private string end_cidade;
    private string end_bairro;
    private string end_endereco;
    private string end_referencia;
    private int end_numero;    
    private Usuario usuario;

    public int End_codigo
    {
        get
        {
            return end_codigo;
        }

        set
        {
            end_codigo = value;
        }
    }

    

    public string End_estado
    {
        get
        {
            return end_estado;
        }

        set
        {
            end_estado = value;
        }
    }

    public string End_cidade
    {
        get
        {
            return end_cidade;
        }

        set
        {
            end_cidade = value;
        }
    }

    public string End_bairro
    {
        get
        {
            return end_bairro;
        }

        set
        {
            end_bairro = value;
        }
    }

    public string End_endereco
    {
        get
        {
            return end_endereco;
        }

        set
        {
            end_endereco = value;
        }
    }

    public string End_referencia
    {
        get
        {
            return end_referencia;
        }

        set
        {
            end_referencia = value;
        }
    }

    public int End_numero
    {
        get
        {
            return end_numero;
        }

        set
        {
            end_numero = value;
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

    public string End_cep
    {
        get
        {
            return end_cep;
        }

        set
        {
            end_cep = value;
        }
    }
}