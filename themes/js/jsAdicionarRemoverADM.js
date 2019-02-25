$(".adicionar").click(function () {
    var cpf = $(this).attr("cpf");

    $.ajax({
        type: 'POST',
        url: 'ModerarUsuarios.aspx/Adicionar',
        data: "{cpf:" + JSON.stringify(cpf) + "}",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s")
                location.reload();
            else
                alert("Erro");
        }
    });
});

//remover adm
$(".remover").click(function () {
    var cpf = $(this).attr("cpf");

    $.ajax({
        type: 'POST',
        url: 'ModerarUsuarios.aspx/Remover',
        data: "{cpf:" + JSON.stringify(cpf) + "}",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s")
                location.reload();
            else
                alert("Erro");
        }
    });
})