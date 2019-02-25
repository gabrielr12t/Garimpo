using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Itens
/// </summary>
public class Item
{
    private int ite_quantidade;
    private bool ite_avaliacao;
    private int ite_status;
    private Produto produto;
    private Compra compra;
    
    public Vendas venda { get; set; }

    public int Ite_quantidade
    {
        get
        {
            return ite_quantidade;
        }

        set
        {
            ite_quantidade = value;
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

    public global::Compra Compra
    {
        get
        {
            return compra;
        }

        set
        {
            compra = value;
        }
    }

    public int Ite_status
    {
        get
        {
            return ite_status;
        }

        set
        {
            ite_status = value;
        }
    }

    public bool Ite_avaliacao
    {
        get
        {
            return ite_avaliacao;
        }

        set
        {
            ite_avaliacao = value;
        }
    }
}