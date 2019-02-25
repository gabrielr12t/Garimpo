using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Vendas
/// </summary>
public class Vendas
{
    public int ven_codigo { get; set; }
    public DateTime ven_data { get; set; }
    public double ven_valor_total { get; set; }
    public bool ven_status { get; set; }
    public Usuario usuario { get; set; }
    public Endereco endereco { get; set; }
    public Env_forma_envio envio { get; set; }
    public Forma_pagamento forma { get; set; }
}