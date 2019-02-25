$(".desativar").click(function () {
    var cpf = $(this).attr("cpf");
    $.ajax({
        type: 'POST',
        url: 'ModerarUsuarios.aspx/Desativar',       
        data: JSON.stringify({
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

$(".ativar").click(function () {
    var cpf = $(this).attr("cpf");
    $.ajax({
        type: 'POST',
        url: 'ModerarUsuarios.aspx/Ativar',        
        data: JSON.stringify({
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

