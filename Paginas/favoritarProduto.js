$(".heart").click(function () {
    var situacao = $(this).attr("rel");

    var logado = $(this).attr("cpf");
    var codProduto = $(this).attr("cod");

    //document.getElementById("cpfUsuario").value = logado;
    //document.getElementById("idProduto").value = codProduto;

    if (logado != "") {
        if (situacao == "vazio") {
            $(this).removeClass("coracaovazio");
            $(this).addClass("coracaocheio");
            $(this).attr("rel", "cheio");
            //mandar que ele favoritou              
            $.ajax({
                type: "POST",
                url: '/Paginas/Produtos/Produto.aspx/Favoritou',
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
            //envia pro banco que ele não quer mais
            $.ajax({
                type: "POST",
                url: '/Paginas/Produtos/Produto.aspx/NaoFavoritou',
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