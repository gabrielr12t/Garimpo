$(".validarProdutoVenda").click(function () {
    var codigo = $(this).attr("rel");
    var cpf = $(this).attr("id");
    var nome = $(this).attr("nome");

    $.ajax({
        type: 'POST',
        url: 'ModerarProdutos.aspx/Modera',
        //data: "{codigo:" + JSON.stringify(codigo) + "}",
        data: JSON.stringify({
            'codigo': codigo,
            'cpf': cpf,
            'nome':nome
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s") {
                location.reload();
            }
            else
                alert("Não foi possível atualizar este produto");
        }
    });
});

