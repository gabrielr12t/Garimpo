$(".naofavoritar").click(function () {
    var cpf = $(this).attr("cpf");
    var codigo = $(this).attr("id");   

    $.ajax({
        type: 'POST',
        url: 'Favoritos.aspx/ExcluirFavorito',
        data: JSON.stringify({
            'codigo': codigo,
            'cpf': cpf           
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s") {
                location.reload();
            }
            else
                swal('Erro!!', 'Não foi possível realizar a operação!!', 'error');
        }
    });

});

