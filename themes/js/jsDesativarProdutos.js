$(".validarProdutoVenda").click(function () {
    var codigo = $(this).attr("rel");

    $.ajax({
        type: 'POST',
        url: 'ProdutosVenda.aspx/ValidaProdutos',
        data: "{codigo:" + JSON.stringify(codigo) + "}",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s")
                location.reload();
            else
                alert("Não foi possível atualizar este produto");             
        }
    });

});