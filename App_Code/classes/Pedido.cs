using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pedidos
/// </summary>
public class Pedido
{
    private int ped_codigo;
    private string ped_status;      
    private Usuario usuario;
    private Compra compra;

    public int Ped_codigo
    {
        get
        {
            return ped_codigo;
        }

        set
        {
            ped_codigo = value;
        }
    }

    public string Ped_status
    {
        get
        {
            return ped_status;
        }

        set
        {
            ped_status = value;
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
}