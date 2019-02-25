
//$(document).ready(function () {
//    var count = 0;
//    $(".comprar").click(function (event) {
//        var prod = $(this).attr('rel');
//        var valor = "";
//        if ($.cookie("produtos") != null) {
//            valor = $.cookie("produtos");   

//            if (valor.indexOf(';') >= 0) {

//                var valores = valor.split(';');
//                var aux = false;
//                $.each(valores, function (i) {
//                    if (valores[i] == prod)
//                        aux = true;
//                });
//                if (!aux)
//                    valor = valor + ';' + $(this).attr('rel');
//            }
//            else {
//                if (valor != $(this).attr('rel'))
//                    valor = valor + ';' + $(this).attr('rel');
//            }
//        }
//        else {
//            valor = $(this).attr('rel');
//        }
//        $.cookie("produtos", valor, { path: '/', expires: 7 });
//    });


$(document).ready(function () {
    var count = 0;
    $(".comprar").click(function (event) {
        var prod = $(this).attr('rel');
        var valor = "";

        if ($.cookie("produtos") != null) {
            valor = $.cookie("produtos");

            if (valor.indexOf(';') >= 0) {
                var valores = valor.split(';');
                var aux = false;
                $.each(valores, function (i) {
                    if (valores[i] == prod)
                        aux = true;
                });
                if (!aux)
                    valor = valor + ';' + $(this).attr('rel');
            }
            else {
                if (valor != $(this).attr('rel'))
                    valor = valor + ';' + $(this).attr('rel');
            }
        }
        else {
            valor = $(this).attr('rel') + ';';
        }

        $.cookie("produtos", valor, { path: '/', expires: 7 });
    });



    $("a.add-to-cart").click(function (event) {
        count++;
        $("a.add-to-cart").addClass("size");

        setTimeout(function () {
            $("a.add-to-cart").addClass("hover");
        }, 200);
        setTimeout(function () {
            $("a.cart > span").addClass("counter");
           // $("a.cart > span.counter").text();
        }, 400);
        setTimeout(function () {
            $("a.add-to-cart").removeClass("hover");
            $("a.add-to-cart").removeClass("size");
        }, 600);
        event.preventDefault();
    });
});