$(".excluir").click(function () {
    var codigo = $(this).attr("rel");
    var id = $(this).attr("id");

    $.ajax({
        type: 'POST',
        url: 'AlteracaoProduto.aspx/ExcluiFoto',
        data: JSON.stringify({
            'codigo': codigo,
            'id': id
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s")
                location.reload();
            else
                //alert("Produto não pode ficar sem foto");
                swal('Erro!!', 'Produto não pode ficar sem foto!!', 'error');
        }
    });
});