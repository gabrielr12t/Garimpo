$(".verifiquei").click(function () {
    var id = $(this).attr("id");
    var denuncia = $(this).attr("denuncia");
    var cpf = $(this).attr("cpf");

    $.ajax({
        type: 'POST',
        url: 'VerificarDenunncias.aspx/Verificado',
        data: JSON.stringify({
            'id': id,
            'denuncia': denuncia,
            'cpf': cpf
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s") {
                location.reload();
            }
            else
                alert("Erro");
        }
    });
});

$(".desativar").click(function () {
    var id = $(this).attr("id");
    var denuncia = $(this).attr("denuncia");
    var cpf = $(this).attr("cpf");

    $.ajax({
        type: 'POST',
        url: 'VerificarDenunncias.aspx/Desativar',
        data: JSON.stringify({
            'id': id,
            'denuncia': denuncia,
            'cpf': cpf
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s") {
                location.reload();
            }
            else
                alert("Erro");
        }
    });
});



