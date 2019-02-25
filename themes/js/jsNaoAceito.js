$(".NaoAceito").click(function () {
    var codigo = $(this).attr("rel");
    var cpf = $(this).attr("id");
    var nome = $(this).attr("nome");

    $.ajax({
        type: 'POST',
        url: 'ModerarProdutos.aspx/Recusado',
        data: JSON.stringify({
            'codigo': codigo,
            'cpf': cpf,
            'nome': nome
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

