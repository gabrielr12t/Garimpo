$(".btnHeart").click(function () {
    var situacao = $(this).attr("rel");
    var logado = $(this).attr("cpf");
    var codProduto = $(this).attr("cod");
    if (logado != "") {
        if (situacao == "vazio") {
            $(this).removeClass("coracaovazio");
            $(this).addClass("coracaocheio");
            $(this).attr("rel", "cheio");
            $.ajax({
                type: "POST",
                url: '/Paginas/Index.aspx/Favoritou',
                data: JSON.stringify({
                    'logado': logado,
                    'codProduto': codProduto
                }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
            })
        } else {
            $(this).removeClass("coracaocheio");
            $(this).addClass("coracaovazio");
            $(this).attr("rel", "vazio");
            $.ajax({
                type: "POST",
                url: '/Paginas/Index.aspx/NaoFavoritou',
                data: JSON.stringify({
                    'logado': logado,
                    'codProduto': codProduto
                }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
            })
        }
    } else {
        alert("Para favoritar é necessário estar logado");
    }

});