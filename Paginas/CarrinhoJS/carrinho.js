$(".remove-product").click(function () {
    if ($.cookie("produtos") != null) {
     
        valor = $.cookie("produtos");
        var v = $(this).attr("rel");
   
        var v2 = v + ";";
        var v3 = ";" + v;
        if (valor.indexOf(v3) >= 0) {
            valor = valor.replace(v3, '');
        } else if (valor.indexOf(v2) >= 0) {
            valor = valor.replace(v2, '');
        }
        else if (valor.indexOf(d) >= 0) {
            valor = valor.replace(d, '');
        }
        $.cookie("produtos", valor, { path: '/', expires: 7 });
        location.reload();
    }
});


$(document).ready(function () {
    if ($.cookie("produtos") != null) {
        valor = $.cookie("produtos");
        if (valor.indexOf(';') >= 0) {
            var valores = valor.split(';');
            var aux = false;
            $.each(valores, function (i) {
                var a = "q" + valores[i].substr(0, valor.indexOf('-'));
                var b = valores[i].substr(valor.indexOf('-')+1, valores.lenght);

                $(".varrerQnt").each(function () {
                    var c = $(this).attr("rel");
                    if (a == c) {
                        $(this).val(b);
                    }
                })

            });
        }
    }
});

var taxRate = 0.05;
var shippingRate = 15.00;
var fadeTime = 300;


/* Assign actions */
$('.product-quantity input').change(function () {
    updateQuantity(this);
});

$('.product-removal button').click(function () {
    removeItem(this);
});


/* Recalculate cart */
function recalculateCart() {
    var subtotal = 0;

    /* Sum up row totals */
    $('.product').each(function () {
        subtotal += parseFloat($(this).children('.product-line-price').text());
    });

    /* Calculate totals */
    var tax = subtotal * taxRate;
    var shipping = (subtotal > 0 ? shippingRate : 0);
    var total = subtotal + tax + shipping;

    /* Update totals display */
    $('.totals-value').fadeOut(fadeTime, function () {
        $('#cart-subtotal').html(subtotal.toFixed(2));
        $('#cart-tax').html(tax.toFixed(2));
        $('#cart-shipping').html(shipping.toFixed(2));
        $('#cart-total').html(total.toFixed(2));
        if (total == 0) {
            $('.checkout').fadeOut(fadeTime);
        } else {
            $('.checkout').fadeIn(fadeTime);
        }
        $('.totals-value').fadeIn(fadeTime);
    });
}


/* Update quantity */
function updateQuantity(quantityInput) {
    /* Calculate line price */
    var productRow = $(quantityInput).parent().parent();
    var price = parseFloat(productRow.children('.product-price').text());
    var quantity = $(quantityInput).val();
    var linePrice = price * quantity;

    /* Update line price display and recalc cart totals */
    productRow.children('.product-line-price').each(function () {
        $(this).fadeOut(fadeTime, function () {
            $(this).text(linePrice.toFixed(2));
            recalculateCart();
            $(this).fadeIn(fadeTime);
        });
    });
}


/* Remove item from cart */
function removeItem(removeButton) {
    /* Remove row from DOM and recalc cart total */
    var productRow = $(removeButton).parent().parent();
    productRow.slideUp(fadeTime, function () {
        productRow.remove();
        recalculateCart();
    });
}

$("#btnFinalizar").click(function () {    
    var cod=new Array();
    var qtde = new Array();   
    var cpf = new Array();
    var total = $("#cart-total").html();
    $.each($(".product"), function (i) {
        var elemento = $(".varrerQnt", this).val();
        cod[i] = $(".product-id", this).text().trim();
        qtde[i] = $(".varrerQnt", this).val().trim();
        cpf[i] = $(".cpf-vendedor", this).text().trim();
    });
    
    $.ajax({
        type: 'POST',
        url: '/Paginas/Pedidos/GeracaoPedido.aspx/Finalizar',
        data: JSON.stringify({
            'cod': cod,
            'qtde': qtde,
            'cpf': cpf,
            'total':total
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (r) {
            if (r.d == "s") {
                //location.reload();
            }
            else
                swal('Erro!!', 'Não foi possível realizar a operação!!', 'error');
        }
    });
});





