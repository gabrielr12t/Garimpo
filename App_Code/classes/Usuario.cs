using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Usuario
{
    private string usu_cpf_cnpj;       
    private string usu_nome;
    private string usu_sexo;   
    private DateTime usu_data_nasc;    
    private string usu_email;
    private string usu_senha;
    private string usu_telefone;    
    private DateTime usu_data_cadastro;   
    private Boolean usu_status_cadastro;
    private string usu_foto_perfil;
    private string usu_nome_loja;
    private int usu_qtdd_vendas;
    private int usu_qtdd_vendas_canceladas;
    private int usu_qtdd_denuncia;
    private int usu_qtdd_compras;
    private int usu_qtdd_compras_canceladas;
    private string usu_medida_busto;
    private string usu_medida_cintura;
    private string usu_medida_calcado;
    private double usu_reputacao;
    private int usu_cadastroCompleto;
    private Tipo_usuario tipo;
    private Subcategoria subcategoria;
    public DateTime usu_tempoSuspenso { get; set; }
    public int usu_tentativas { get; set; }
    public string CidadeEstado{ get; set; }

    public string Usu_cpf_cnpj
    {
        get
        {
            return usu_cpf_cnpj;
        }

        set
        {
            usu_cpf_cnpj = value;
        }
    }

    public string Usu_nome
    {
        get
        {
            return usu_nome;
        }

        set
        {
            usu_nome = value;
        }
    }

    public string Usu_sexo
    {
        get
        {
            return usu_sexo;
        }

        set
        {
            usu_sexo = value;
        }
    }

    public DateTime Usu_data_nasc
    {
        get
        {
            return usu_data_nasc;
        }

        set
        {
            usu_data_nasc = value;
        }
    }

    public string Usu_email
    {
        get
        {
            return usu_email;
        }

        set
        {
            usu_email = value;
        }
    }

    public string Usu_senha
    {
        get
        {
            return usu_senha;
        }

        set
        {
            usu_senha = value;
        }
    }

    public string Usu_telefone
    {
        get
        {
            return usu_telefone;
        }

        set
        {
            usu_telefone = value;
        }
    }

    public DateTime Usu_data_cadastro
    {
        get
        {
            return usu_data_cadastro;
        }

        set
        {
            usu_data_cadastro = value;
        }
    }

    public bool Usu_status_cadastro
    {
        get
        {
            return usu_status_cadastro;
        }

        set
        {
            usu_status_cadastro = value;
        }
    }

    public string Usu_foto_perfil
    {
        get
        {
            return usu_foto_perfil;
        }

        set
        {
            usu_foto_perfil = value;
        }
    }

    public string Usu_nome_loja
    {
        get
        {
            return usu_nome_loja;
        }

        set
        {
            usu_nome_loja = value;
        }
    }

    public int Usu_qtdd_vendas
    {
        get
        {
            return usu_qtdd_vendas;
        }

        set
        {
            usu_qtdd_vendas = value;
        }
    }

    public int Usu_qtdd_vendas_canceladas
    {
        get
        {
            return usu_qtdd_vendas_canceladas;
        }

        set
        {
            usu_qtdd_vendas_canceladas = value;
        }
    }

    public int Usu_qtdd_denuncia
    {
        get
        {
            return usu_qtdd_denuncia;
        }

        set
        {
            usu_qtdd_denuncia = value;
        }
    }

    public int Usu_qtdd_compras
    {
        get
        {
            return usu_qtdd_compras;
        }

        set
        {
            usu_qtdd_compras = value;
        }
    }

    public int Usu_qtdd_compras_canceladas
    {
        get
        {
            return usu_qtdd_compras_canceladas;
        }

        set
        {
            usu_qtdd_compras_canceladas = value;
        }
    }

    public string Usu_medida_busto
    {
        get
        {
            return usu_medida_busto;
        }

        set
        {
            usu_medida_busto = value;
        }
    }

    public string Usu_medida_cintura
    {
        get
        {
            return usu_medida_cintura;
        }

        set
        {
            usu_medida_cintura = value;
        }
    }

    public string Usu_medida_calcado
    {
        get
        {
            return usu_medida_calcado;
        }

        set
        {
            usu_medida_calcado = value;
        }
    }

    public double Usu_reputacao
    {
        get
        {
            return usu_reputacao;
        }

        set
        {
            usu_reputacao = value;
        }
    }

    public int Usu_cadastroCompleto
    {
        get
        {
            return usu_cadastroCompleto;
        }

        set
        {
            usu_cadastroCompleto = value;
        }
    }

    public global::Tipo_usuario Tipo
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
         
    public Subcategoria Subcategoria
    {
        get
        {
            return subcategoria;
        }

        set
        {
            subcategoria = value;
        }
    }
}