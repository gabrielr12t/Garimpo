using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cores
/// </summary>
public class Cor
{
    private int cor_codigo;
    private string cor_nome;
    private string cor_imagem;

    public int Cor_codigo
    {
        get
        {
            return cor_codigo;
        }

        set
        {
            cor_codigo = value;
        }
    }

    public string Cor_nome
    {
        get
        {
            return cor_nome;
        }

        set
        {
            cor_nome = value;
        }
    }

    public string Cor_imagem
    {
        get
        {
            return cor_imagem;
        }

        set
        {
            cor_imagem = value;
        }
    }
}