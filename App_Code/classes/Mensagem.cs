using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Mensagens
/// </summary>
public class Mensagem
{
    private int men_codigo;
    private string men_conteudo;
    private Boolean men_arquivada;
    private DateTime men_data;
    private Boolean men_lida;       
    private Usuario usuario;
    private Produto produto;
    private Tme_tipo_mensagem tipo;          
    private string men_pergunta_codigo;
	private string men_cpf_pergunta;
	private bool men_respondida;
    private bool men_visivel;

    public int Men_codigo
    {
        get
        {
            return men_codigo;
        }

        set
        {
            men_codigo = value;
        }
    }

    public string Men_conteudo
    {
        get
        {
            return men_conteudo;
        }

        set
        {
            men_conteudo = value;
        }
    }

    public bool Men_arquivada
    {
        get
        {
            return men_arquivada;
        }

        set
        {
            men_arquivada = value;
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
    public DateTime Men_data
    {
        get
        {
            return men_data;
        }
        set
        {
            men_data = value;
        }
    }
    public bool Men_lida
    {
        get
        {
            return men_lida;
        }
        set
        {
            men_lida = value;
        }
    }     
    public Tme_tipo_mensagem Tipo
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }
	

	public string Men_cpf_pergunta
	{
		get
		{
			return men_cpf_pergunta;
		}

		set
		{
			men_cpf_pergunta = value;
		}
	}

	public string Men_pergunta_codigo
	{
		get
		{
			return men_pergunta_codigo;
		}

		set
		{
			men_pergunta_codigo = value;
		}
	}

	public bool Men_respondida
	{
		get
		{
			return men_respondida;
		}

		set
		{
			men_respondida = value;
		}
	}

    public bool Men_visivel
    {
        get
        {
            return men_visivel;
        }

        set
        {
            men_visivel = value;
        }
    }
}