function UploadTikets(promoCode) {
    //SHOW CHOSEN CITY
    $(".top-header-select").change(function () {
        $("#chosen-city").text($(this).val());
    });

    $("#basket-c-submit").click(function () {
        localStorage.clear();
    });
    var cardData = JSON.parse(localStorage.getItem("cardData"));
    console.log(localStorage);
    $(".top-header-cart-counter").text(localStorage.getItem("cartCounter"));

    var urlStr = "";
    for (var cardId in cardData) {
        urlStr += cardId + ";";
    }
    
    $("#q-cancel").on("click", function () {
        hideModal();
    });
    let
        price = 0;
        count = 0;
        discount = 0;
        total = 0;
        salesTax = 0;
        subTotal = 0;
        amountQty = 0;  
        rowIndex = 0;
    // CALCULATE TOTAL,SUBTOTAL AND  SALES TAX
    function calculateTotal(rowIndex) {
        price = 0;
        count = 0;
        discount = 0;
        total = 0;
        salesTax = 0;
        subTotal = 0;
        amountQty = 0;
        let sumPrice = 0;
        
        for (let i = 2; i < $('.b-table > div').length + 1; i++) {
            count = +$('.b-table > div:nth-child(' + i + ') >  div:nth-child(3)').find('.b-table-q-number').text();
            price = +$('.b-table > div:nth-child(' + i + ') >  div:nth-child(4)').text().slice(1, 4);
            discount = +$('.b-table > div:nth-child(' + i + ') >  div:nth-child(5)').text().slice(1, 4);
            salesTax += count * discount;
            total += count * price - count * discount;
            subTotal += count * price;
            amountQty += count;
            if (rowIndex + 1 == i) {
                sumPrice = count * price - count * discount
                $('.b-table > div:nth-child(' + i + ') >  div:nth-child(6)').text("$" + sumPrice);
            }
        }
        $('#basket-p-subtotal').text(total);
        $('#basket-p-sale').text(salesTax);
        $('#basket-p-total').text(subTotal);
    }
    function gitAudio(rowIndex) {
        debugger;
        calculateTotal(rowIndex); 
        
        if ($('.b-checkes-flex input').eq(0).prop('checked')) {
            total += 1.99 * amountQty;
            console.log(1.99 * amountQty);
            subTotal += 1.99 * amountQty;
            $('#basket-p-subtotal').text(subTotal);
            $('#basket-p-total').text(total);
        }

        

        if ($('.b-checkes-flex input').eq(0).prop('checked')) {
            $('#AudioGuide').val('true');
        }
        else {
            $('#AudioGuide').val('false');
        }
       
    }

    var selectedcity = $(".top-header-select option:selected").text();
    $(".top-header-select").change(function () {
        selectedcity = $(this).children("option:selected").text();
    });
    //SET CHOOSEN CITY
    $('#chosen-city').text(selectedcity);
    // SWITCH GIT AUDIO
    $('.b-checkes-flex input[type="radio"]').change(function () { gitAudio() });
    $(document).on("click", ".b-table-q-btn", function () {
        
        console.log(JSON.parse(localStorage.getItem("cardData")));
        var context = $(this);
        var val = Number($(this).siblings(".b-table-q-number").text());
        var id = $(this).parent().attr("qid");
        var type = $(this).parent().attr("qtype");

        if ($(this).attr("tq") == 1) {
            $(this).siblings(".b-table-q-number").text(++val);
            $(".top-header-cart-counter").text(Number($(".top-header-cart-counter").text()) + 1);
            cardData[id][type] = val;
        }
        else {
            if (val > 1) {
                $(this).siblings(".b-table-q-number").text(--val);
                $(".top-header-cart-counter").text(Number($(".top-header-cart-counter").text()) - 1);
                cardData[id][type] = val;
            }
            else {
                showModal("#delete-modal");
                $("#q-delete").on("click", function () {
                    $(context).parent().parent().remove();
                    cardData[id][type] = 0;
                    hideModal();
                    localStorage["cardData"] = JSON.stringify(cardData);
                });
            }
        }
        gitAudio($(this).parent().parent().index());
        localStorage["cardData"] = JSON.stringify(cardData);
        console.log(JSON.parse(localStorage.getItem("cardData")));
    });

    //console.log(urlStr);
    $.ajax({
        type: "POST",
        url: "GetTikets?id=" + urlStr + "&PromoCode=" + promoCode,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var subTotalPrice = 0;
            var quantity = 0;
            for (var i = 0; i < response.length; i++) {
                quantity += cardData[response[i].id]["adult"] + cardData[response[i].id]["child"];
                if (cardData[response[i].id]["adult"] > 0) {
                    $(".b-table").append(`
                    <div>
                        <div>`+ response[i].text + `</div>
                        <div>Adult</div>
                        <div class="d-flex b-table-q-wrap" qtype="adult" qid="`+ response[i].id + `"><div class="b-table-q-btn" tq="0">-</div><div class="b-table-q-number">` + cardData[response[i].id]["adult"] + `</div><div class="b-table-q-btn" tq="1">+</div></div>
                        <div>$ `+ response[i].adultCost + `</div>
                        <div class="b-table-green">$ `+ response[i].sale + `</div>
                        <div>$ `+ cardData[response[i].id]["adult"] * (response[i].adultCost - response[i].sale) + `</div>
                    </div>
                    `);
                }
                if (cardData[response[i].id]["child"] > 0) {
                    $(".b-table").append(`
                    <div>
                        <div>`+ response[i].text + `</div>
                        <div>Child</div>
                        <div class="d-flex b-table-q-wrap" qtype="child" qid="`+ response[i].id + `"><div class="b-table-q-btn" tq="0">-</div><div class="b-table-q-number">` + cardData[response[i].id]["child"] + `</div><div class="b-table-q-btn" tq="1">+</div></div>
                        <div>$ `+ response[i].childCost + `</div>
                        <div class="b-table-green">$  `+ response[i].sale + `</div>
                        <div>$ `+ cardData[response[i].id]["child"] * (response[i].childCost - response[i].sale) + `</div>
                    </div>
                    `);
                }

                //special if
                let tmp = response[i];
                if (cardData["f85d41b3-6abc-4887-929c-5afc8a45f2f6"]["adult"] > 0
                    || cardData["f85d41b3-6abc-4887-929c-5afc8a45f2f6"]["child"] > 0
                    || cardData["bac57114-9277-457c-accd-06f8f09470d1"]["adult"] > 0
                    || cardData["bac57114-9277-457c-accd-06f8f09470d1"]["child"] > 0
                    || cardData["8dc10747-ac92-4d1f-9ba5-c4bf21c21b3f"]["adult"] > 0
                    || cardData["8dc10747-ac92-4d1f-9ba5-c4bf21c21b3f"]["child"] > 0) {
                    let muz = $(".audio-gide")[0];
                    muz.style.display = "";
                    let i = 23;
                }

            }
            $("#basket-p-subtotal").text(subTotalPrice);
            $("#basket-p-total").text(subTotalPrice);
            $("#basket-c-amount").val(subTotalPrice);
            gitAudio($(this).parent().parent().index());
            //SET BASKET ICON QUANTITY
            $(".top-header-cart-counter").text(quantity);
        },
        failure: function (response) {
            alert(response.id);
        }
    });
   
}


function UpdateTiketsDictionaries()
{
    //debugger;
    var tikets = localStorage.getItem("cardData");
    var cardData = JSON.parse(localStorage.getItem("cardData"));
    var output = "[";
    for (variable in cardData) {
        output += '{Id:"' + variable + '","age":{"adult":' + cardData[variable]["adult"] + ',"child":' + cardData[variable]["child"] + '}},';
    }
    output += ']';
    //debugger;
    $("#Tikets").val(output);
}

function TiketInfo() {
    this.x = 0;
    this.y = 0;
}