$(".pagamentoRecebido").click(function () {
    var cod = $(this).attr("cod");
    var compra = $(this).attr("compra");
    $.ajax({
        type: 'POST',
        url: 'HistoricoVenda.aspx/PagementoFeito',
        data: JSON.stringify({
            'cod': cod,
            'compra': compra         
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

$(".ProdutoEnviado").click(function () {
    var cod = $(this).attr("cod");
    var compra = $(this).attr("compra");
    $.ajax({
        type: 'POST',
        url: 'HistoricoVenda.aspx/ProdutoEnviadoJa',
        data: JSON.stringify({
            'cod': cod,
            'compra': compra
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

$(".recebi").click(function () {
    var cod = $(this).attr("cod");
    var compra = $(this).attr("compra");
    $.ajax({
        type: 'POST',
        url: '/Paginas/Usuário/MeusPedidos.aspx/ProdutoRecebido',
        data: JSON.stringify({
            'cod': cod,
            'compra': compra
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

$(".cancelar").click(function () {
    var cod = $(this).attr("cod");
    var compra = $(this).attr("compra");
    $.ajax({
        type: 'POST',
        url: '/Paginas/Usuário/MeusPedidos.aspx/Cancelamento',
        data: JSON.stringify({
            'cod': cod,
            'compra': compra
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


