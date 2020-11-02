$(document).ready(function () {
    var x, i, j, selElmnt, a, b, c;
    /*look for any elements with the class "custom-select":*/
    x = document.getElementsByClassName("custom-select");
    for (i = 0; i < x.length; i++) {
        selElmnt = x[i].getElementsByTagName("select")[0];
        /*for each element, create a new DIV that will act as the selected item:*/
        a = document.createElement("DIV");
        a.setAttribute("class", "select-selected");
        a.innerHTML = selElmnt.options[selElmnt.selectedIndex].innerHTML;
        x[i].appendChild(a);
        /*for each element, create a new DIV that will contain the option list:*/
        b = document.createElement("DIV");
        b.setAttribute("class", "select-items select-hide");
        for (j = 1; j < selElmnt.length; j++) {
            /*for each option in the original select element,
            create a new DIV that will act as an option item:*/
            c = document.createElement("a");
            if ($('.section-3').hasClass('city-2')) {
                c.setAttribute("href", "http://aggregatorcore-dev.us-west-2.elasticbeanstalk.com/");

            }
            else if ($('.section-3').hasClass('city-1')) {
                c.setAttribute("href", "http://aggregatorcore-dev.us-west-2.elasticbeanstalk.com/Home/Augustine");
            }
            else if ($('#chosen-city').text() == 'St. Augustine FL') {
                c.setAttribute("href", "http://aggregatorcore-dev.us-west-2.elasticbeanstalk.com/Home/Basket?Chicago");
            }
            else {
                c.setAttribute("href", "http://aggregatorcore-dev.us-west-2.elasticbeanstalk.com/Home/Basket?St-Augustine");
            }
            c.innerHTML = selElmnt.options[j].innerHTML;
            b.appendChild(c);
        }
        x[i].appendChild(b);
        a.addEventListener("click", function (e) {
            /*when the select box is clicked, close any other select boxes,
            and open/close the current select box:*/
            e.stopPropagation();
            closeAllSelect(this);
            this.nextSibling.classList.toggle("select-hide");
            this.classList.toggle("select-arrow-active");
        });
    }
    function closeAllSelect(elmnt) {
        /*a function that will close all select boxes in the document,
        except the current select box:*/
        var x, y, i, arrNo = [];
        x = document.getElementsByClassName("select-items");
        y = document.getElementsByClassName("select-selected");
        for (i = 0; i < y.length; i++) {
            if (elmnt == y[i]) {
                arrNo.push(i)
            } else {
                y[i].classList.remove("select-arrow-active");
            }
        }
        for (i = 0; i < x.length; i++) {
            if (arrNo.indexOf(i)) {
                x[i].classList.add("select-hide");
            }
        }
    }
    /*if the user clicks anywhere outside the select box,
    then close all select boxes:*/
    document.addEventListener("click", closeAllSelect);
    function OpenUrl(url) {
        window.open(url, '_blank');
    }
    $(".menu-btn").click(function () {
        $(".menu-wrap").removeClass("menu-unactive");
    });
    $(".menu-back-btn").click(function () {
        $(".menu-wrap").addClass("menu-unactive");
    });
    $(document).on("click", function (e) {
        if (e.target == $(".body-modal-wrap")[0] || e.target == $(".body-modal-wrap")[1]) {
            hideModal();
        }
    });
    $("#close-index-modal").on("click", function (e) {
        e.preventDefault();
        hideModal();
    });
    function showModal(id) {
        $(id).removeClass("body-modal-wrap-unactive").hide().fadeIn();
        $("body").append("<div class='modal-faded'>");
    }
    function hideModal() {
        $("#basket-modal").addClass("body-modal-wrap-unactive").fadeOut();
        $("#delete-modal").addClass("body-modal-wrap-unactive").fadeOut();
        $("#sale-modal").addClass("body-modal-wrap-unactive").fadeOut();
        $(".modal-faded").remove();
    }
        //SET CHOOSEN CITY
    if (window.location.href.indexOf('Chicago') !== -1) {
            $('#chosen-city').text("Chicago IL");
            $('.top-header-select option:last-child').val('St. Augustine FL');
            $('.top-header-select option:last-child').text('St. Augustine FL');
            $('.top-header-select option:first-child').val('Chicago IL');
            $('.top-header-select option:first-child').text('Chicago IL');
            $('.mobile-title').text('CHICAGO');
        }
        else {
            $('#chosen-city').text("St. Augustine FL");
            $('.top-header-select option:first-child').val('St. Augustine FL');
            $('.top-header-select option:first-child').text('St. Augustine FL');
            $('.top-header-select option:last-child').val('Chicago IL');
            $('.top-header-select option:last-child').text('Chicago IL');
            $('.mobile-title').text('ST AUGUSTINE');
        }
 
    //SHOW CHOSEN CITY
    $(".top-header-select").change(function () {
        $("#chosen-city").text($(this).val());
    });
    //BASKET
    if ($("#payment-modal-slider").length != 0) {
        $("#payment-modal-slider").slick({
            slidesToShow: 1,
            arrows: false,
            dots: false,
            draggable: false,
            infinite: false
        });
    }
    $("#basket-c-next").on("click", function (e) {
        console.log("I am here");
        e.preventDefault();
        if ($("#UserInfo_Name").val() !== "" && $("#UserInfo_Surname").val() !== "" && $("#UserInfo_Phone").val() !== "" && $(".phone-number").val() !== "") {
            if (!validateEmail($("#UserInfo_Email").val())) {
                $("#b-modal-warn").text("Некорректный email");
            }
            else {
                $("#b-modal-warn").css("opacity", 0);
                $("#payment-modal-slider").slick("slickNext");
            }
        } else {

            $("#b-modal-warn").css("opacity", 1);
        }
    });
    //validate Email
    function validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

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
    setTimeout(function () { calculateTotal(); }, 500);
    // CALCULATE TOTAL,SUBTOTAL AND  SALES TAX
    function calculateTotal() {

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
            price = +$('.b-table > div:nth-child(' + i + ') >  div:nth-child(4)').text().slice(1, 6);
            discount = +$('.b-table > div:nth-child(' + i + ') >  div:nth-child(5)').text().slice(1, 7);
            subTotal += count * price - count * discount;
            amountQty += count;

            $('.b-table > div:nth-child(' + i + ') >  div:nth-child(4)').text("$" + discount.toFixed(2));


            sumPrice = count * price - count * discount;

            $('.b-table > div:nth-child(' + i + ') >  div:nth-child(4)').text("$" + price.toFixed(2));
            $('.b-table > div:nth-child(' + i + ') >  div:nth-child(5)').text("$" + discount.toFixed(2));
            $('.b-table > div:nth-child(' + i + ') >  div:nth-child(6)').text("$" + sumPrice.toFixed(2));
        }
        if ($('.sup-checkes-flex input').eq(0).prop('checked')) {
            subTotal += 20 * amountQty;
        }
        if ($('.ins-checkes-flex input').eq(0).prop('checked')) {
            subTotal += 2 * amountQty;
        }

        salesTax = subTotal * 10.25 / 100;
        total = subTotal + salesTax;

        $('#basket-p-subtotal').text(subTotal.toFixed(2));
        $('#basket-p-sale').text(salesTax.toFixed(2));
        $('#basket-p-total').text(total.toFixed(2));
    }
    function gitAudio() {

        calculateTotal();
        let countGid = 0;
        if ($('.audio-checkes input').eq(0).prop('checked')) {

            for (let i = 2; i < $('.b-table div').length; i++) {
                if ($('.b-table > div:nth-child(' + i + ') > div:first-child').text().indexOf('Medieval') !== -1 || $('.b-table > div:nth-child(' + i + ') > div:first-child').text().indexOf('MEDIEVAL') !== -1) {
                    countGid++;
                }

            }


            subTotal += 1.99 * countGid;
            salesTax = subTotal * 10.25 / 100;
            total = subTotal + salesTax;

            $('#basket-p-subtotal').text(subTotal.toFixed(2));
            $('#basket-p-sale').text(salesTax.toFixed(2));
            $('#basket-p-total').text(total.toFixed(2));
        }



        //if ($('.b-checkes-flex input').eq(0).prop('checked')) {
        //    $('#AudioGuide').val('true');
        //}
        //else {
        //    $('#AudioGuide').val('false');
        //}

    }

    var selectedcity = $(".top-header-select option:selected").text();
    $(".top-header-select").change(function () {
        //SET CHOOSEN CITY
        if (selectedcity.indexOf('Chicago') != -1) {

            $('#chosen-city').text("Chicago IL");
            $('#City').val('Chicago');
        }
        else {
            $('#chosen-city').text("St. Augustine FL");
            $('#City').val('Augistine');
        }
    });
    
   
    // SWITCH GIT AUDIO
    $('.b-checkes-flex input[type="radio"]').change(function () { gitAudio() });
    var id = 0;
    var type = "";
    var promoCode =""
    var context = "";
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
            }
        }
        gitAudio($(this).parent().parent().index());
        localStorage["cardData"] = JSON.stringify(cardData);
    });
    let discountGeneral = 0;
    //console.log(urlStr);
    function deleteTicket() {

        $('#delete-modal').hide();
        $('.modal-faded').remove();
        $('.b-table > div').eq(rowDelete).remove();
        $(context).parent().parent().remove();
        cardData[id][type] = 0;
        hideModal();
        localStorage["cardData"] = JSON.stringify(cardData);
        calculateTotal();

    }
    //VALIDATION PAY
    $('.slick-track > div:last-child .b-input').on('input', function () {
        let isValid = true;
        if ($('#txtCardNumber').val().length < $('#txtCardNumber').attr('maxlength')) {
            isValid = false;
            $('.slick-track > div:last-child .green-btn').css('background', 'lightgray');
            $('.slick-track > div:last-child .green-btn').attr('disabled', 'disabled');
        }
        if ($('#txtDate').val().length < 5) {
            isValid = false;
            $('.slick-track > div:last-child .green-btn').css('background', 'lightgray');
            $('.slick-track > div:last-child .green-btn').attr('disabled', 'disabled');
        }
        if ($('#textCvv').val().length < +$('#textCvv').attr('maxlength')) {
            isValid = false;
            $('.slick-track > div:last-child .green-btn').css('background', 'lightgray');
            $('.slick-track > div:last-child .green-btn').attr('disabled', 'disabled');
        }
        if ($('#textZip').val().length < 5) {
            isValid = false;
            $('.slick-track > div:last-child .green-btn').css('background', 'lightgray');
            $('.slick-track > div:last-child .green-btn').attr('disabled', 'disabled');
        }
        if (isValid) {
            $('.slick-track > div:last-child .green-btn').css('background', '#64bb39');
            $('.slick-track > div:last-child .green-btn').removeAttr('disabled');
        }
    });
    function checkFirstModal() {
        let isValid = true;
        setTimeout(function () {
            if ($("#UserInfo_Name").val() !== "" && $("#UserInfo_Surname").val() !== "" && $(".phone-number").val().indexOf('_') == -1 && $(".phone-number").val() !== "") {

                if (!validateEmail($("#UserInfo_Email").val())) {
                    isValid = false;
                    $('.slick-track > div:first-child .green-btn').css('background', 'lightgray');
                    $('.slick-track > div:first-child .green-btn').attr('disabled', 'disabled');
                }
                else {

                    isValid = true;
                }
            } else {
                console.log($(".phone-number").val());
                isValid = false;
                $('.slick-track > div:first-child .green-btn').css('background', 'lightgray');
                $('.slick-track > div:first-child .green-btn').attr('disabled', 'disabled');
            }
            if (isValid) {

                $('.slick-track > div:first-child .green-btn').css('background', '#64bb39');
                $('.slick-track > div:first-child .green-btn').removeAttr('disabled');
            }
        }, 50);
        
        
    }
    $('.slick-track > div:first-child .b-input').on('input', checkFirstModal);
    $('.slick-track > div:first-child .b-input').on('change', checkFirstModal);
    $(document).on('keydown', checkFirstModal);
    //CHANGE CITY
    $('.select-items').on('click', function () {
        if ($('.same-as-selected').text() == "St. Augistine") {
            $('.b-table > div:not(:first-child)').remove();
            city = "Chicago";
            currentCity["city"] = "Chicago";
            url = "GetTikets?сity=" + city + "&PromoCode=" + promoCode;
            UpdateTiketsTable();
            cardData = JSON.parse(localStorage.getItem("cardData1"));
            $('#City').val('Chicago');
            localStorage.setItem("currentCity", JSON.stringify(currentCity));
        }
        if ($('.same-as-selected').text() == "Chicago") {
            $('.b-table > div:not(:first-child)').remove();
            city = "Augistine";
            currentCity["city"] = "Augistine";
            url = "GetTikets?сity=" + city + "&PromoCode=" + promoCode;
            UpdateTiketsTable();
            $(".top-header-cart-counter").text(localStorage.getItem("cartCounter2"));
            $('#City').val('Augistine');
            localStorage.setItem("currentCity", JSON.stringify(currentCity));
        }
    });
    var city = "Chicago";
    var cardData = {};
    var currentCity = {};
    var fullUrl = window.location.href;
    if (fullUrl.indexOf('Chicago') != -1) {
        city = "Chicago";
        url = "GetTikets?сity=" + city + "&PromoCode=" + promoCode;
        cardData = JSON.parse(localStorage.getItem("cardData1"));
        currentCity["city"] = "Chicago";
        localStorage.setItem("currentCity", JSON.stringify(currentCity));
        $(".top-header-cart-counter").text(localStorage.getItem("cartCounter1"));
        $('#City').val('Chicago');
        UpdateTiketsTable();

    }

    if (fullUrl.indexOf('St-Augustine') != -1) {

        city = "Augistine";
        $('.select-items div').click();
        url = "GetTikets?сity=" + city + "&PromoCode=" + promoCode;
        cardData = JSON.parse(localStorage.getItem("cardData2"));
        currentCity["city"] = "Augistine";
        localStorage.setItem("currentCity", JSON.stringify(currentCity));
        $(".top-header-cart-counter").text(localStorage.getItem("cartCounter2"));
        $('#City').val('Augistine');
        
        UpdateTiketsTable();
    }
    $('#messegesModal').on('hidden.bs.modal', function () {
        UpdateTable();
    });
  
    function CloseErrorModal() {
        $('#messegesModal').hide();
        $('.modal-backdrop').remove();
        $('body').removeClass('modal-open');
        UpdateTable();
    }
    function UpdateTable() {
        currentCity = JSON.parse(localStorage.getItem("currentCity"));
        cardData = JSON.parse(localStorage.getItem("cardData1"));
        if (currentCity['city'] == 'Augistine') {
            $('.select-items div').click();
            cardData = JSON.parse(localStorage.getItem("cardData2"));
        }

        url = "GetTikets?сity=" + currentCity['city'] + "&PromoCode=" + promoCode;
        UpdateTiketsTable();
    }

    function UpdateTiketsDictionaries() {
        var tikets = localStorage.getItem("cardData");
        var cardData = JSON.parse(localStorage.getItem("cardData"));
        var output = "[";
        for (variable in cardData) {
            output += '{Id:"' + variable + '","age":{"adult":' + cardData[variable]["adult"] + ',"child":' + cardData[variable]["child"] + '}},';
        }
        output += ']';
        $("#Tikets").val(output);
    }

    function TiketInfo() {
        this.x = 0;
        this.y = 0;
    }
    //INDEX SELECT CITY
    $('.select-items').on('click', function (e) {

        if ($('.same-as-selected').text() == "St. Augistine") {

            cityName = "Chicago";
        }
        if ($('.same-as-selected').text() == "Chicago") {
            cityName = "St-Augustine";

        }
    });

    // UPDATE AFTER ERROR MODAL
    $('#messegesModal .red-btn-cancel,#messegesModal .close').click(function () {
        $('#messegesModal').hide();
        $('.modal-backdrop').remove();
        $('body').removeClass('modal-open');
        UpdateTable();
    });
    function UpdateTiketsTable() {
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                
                var subTotalPrice = 0;
                var quantity = 0;
                if ($('#City').val() == "Chicago") {
                    cardData = JSON.parse(localStorage.getItem("cardData1"));
                }
                if ($('#City').val() == "Augistine") {
                    cardData = JSON.parse(localStorage.getItem("cardData2"));
                }
                if (currentCity['city'] == 'Augistine') {
                    cardData = JSON.parse(localStorage.getItem("cardData2"));
                }
                for (var i = 0; i < response.length; i++) {

                    quantity += cardData[response[i].id]["adult"] + cardData[response[i].id]["child"];
                    if (cardData[response[i].id]["adult"] > 0) {
                        discountGeneral = response[i].discount + response[i].adultSale;
                        $(".b-table").append(`
                    <div>
                        <div class="ticket-name">`+ response[i].text + `</div>
                        <div>Adult</div>
                        <div class="d-flex b-table-q-wrap" qtype="adult" qid="`+ response[i].id + `"><div class="b-table-q-btn" tq="0" onclick="removeTicket(event)">-</div><div class="b-table-q-number">` + cardData[response[i].id]["adult"] + `</div><div class="b-table-q-btn" tq="1">+</div></div>
                        <div>$ `+ response[i].adultCost + `</div>
                        <div class="b-table-green">$ `+ discountGeneral + `</div>
                        <div>$ `+ cardData[response[i].id]["adult"] * (response[i].adultCost - response[i].sale) + `</div>
                    </div>
                    `);
                    }
                    if (cardData[response[i].id]["child"] > 0) {
                        discountGeneral = response[i].discount + response[i].adultSale;
                        $(".b-table").append(`
                    <div>
                        <div class="ticket-name">`+ response[i].text + `</div>
                        <div>Child</div>
                        <div class="d-flex b-table-q-wrap" qtype="child" qid="`+ response[i].id + `"><div class="b-table-q-btn" tq="0" onclick="removeTicket(event)">-</div><div class="b-table-q-number">` + cardData[response[i].id]["child"] + `</div><div class="b-table-q-btn" tq="1">+</div></div>
                        <div>$ `+ response[i].childCost + `</div>
                        <div class="b-table-green">$  `+ discountGeneral + `</div>
                        <div>$ `+ cardData[response[i].id]["child"] * (response[i].childCost - response[i].sale) + `</div>
                    </div>
                    `);
                    }

                    //special if
                    let tmp = response[i];
                    if (city != "Augistine") {
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
                    else {
                        
                        if (cardData["f85d41b3-6abc-4887-929c-5afc8a45f2f6"]["adult"] > 0
                            || cardData["f85d41b3-6abc-4887-929c-5afc8a45f2f6"]["child"] > 0
                            || cardData["8838d436-357c-43fa-addb-4a4f8ec224a2"]["adult"] > 0
                            || cardData["8838d436-357c-43fa-addb-4a4f8ec224a2"]["child"] > 0) {
                            let muz = $(".audio-gide")[0];
                            muz.style.display = "";
                            let i = 23;
                        }
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
});

