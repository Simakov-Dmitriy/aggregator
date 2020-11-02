
function fillStorage() {
       var cardData1 = {};
    var cardData2 = {};
     cartCounter1 = 0;
     cartCounter2 = 0;
    var cardId = 0;
    var adultAmount = 0;
    var i = 1;
    var childAmount = 0;
    if ($('.top-content-wrap').hasClass('city-1')) {
        $('.city-2').hide();
        localStorage.removeItem('cartCounter1');
        localStorage.removeItem('cardData1');
        for (i = 1; i <= $(".card").length; i++) {

                cardId = $($(".card")[i - 1]).attr("card-id");

                adultAmount = Number($(".card-" + i + "-i-a").val());
                childAmount = Number($(".card-" + i + "-i-c").val());

                if (!isNaN(adultAmount) && !isNaN(childAmount)) {
                    cartCounter1 += adultAmount + childAmount;
                    cardData1[cardId] = {
                        "adult": adultAmount,
                        "child": childAmount
                    };
                }

        }
        localStorage.setItem("cardData1", JSON.stringify(cardData1));
        localStorage.setItem("cartCounter1", cartCounter1);
        $(".top-header-cart-counter").text(cartCounter1);
        if (cartCounter1 == "0") {
            $('.red-btn').attr('href', '');
        }
        else {
            $('.red-btn').attr('href', '/Home/Basket?Chicago');
        }
    }
    else {
        $('.city-1').hide();
        localStorage.removeItem('cartCounter2');
        localStorage.removeItem('cardData2');
        for (i = 1; i <= 3; i++) {
            cardId = $($(".card")[i - 1]).attr("card-id");

            adultAmount = Number($(".card-" + i + "-i-a").val());
            childAmount = Number($(".card-" + i + "-i-c").val());

            if (!isNaN(adultAmount) && !isNaN(childAmount)) {
                cartCounter2 += adultAmount + childAmount;
                cardData2[cardId] = {
                    "adult": adultAmount,
                    "child": childAmount
                };
            }

        }
        localStorage.setItem("cardData2", JSON.stringify(cardData2));
        localStorage.setItem("cartCounter2", cartCounter2);
        $(".top-header-cart-counter").text(cartCounter2);
        if (cartCounter2 == "0") {
            $('.red-btn').attr('href', '');
        }
        else {
            $('.red-btn').attr('href', '/Home/Basket?St-Augustine');
        }
    } 
}
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
var cityName = "Chicago";
var cartCounter1 = 0;
var cartCounter2 = 0;

$(document).ready(function () {
    checkPosition();
    //ANCHOR LINK
    $(".target-link").on("click", function (e) {
        e.preventDefault();
        //var offset = $("." + $(this).attr("href")).offset().top;
        $("html, body").animate({ scrollTop: 579 }, 400);
    });
 
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
    $(".js-link").on("click", function () {
        window.open($(this).attr("href"), "_blank");
    });
    let stopSlick = false;
    $(".s2-social-btn").on("click", function () {
        
        indexSlide = +$(this).parent().attr("slider-def-slide");
        let elem = $($(".section-2-card-slider[slider-def-slide=" + indexSlide + "]").get(1));
        socialIndex = parseInt($(this).attr("sindex"));
        elem.slick('slickGoTo', socialIndex);
        if (!stopSlick) {
            stopSlick = true;
            clearInterval(commentSlick);
            clearTimeout(timer1);
            clearTimeout(timer2);
            clearTimeout(timer3);
            clearTimeout(timer4);
        }

    });
    $(".section-2-card-slider").on("mouseover", function () {

        if (!stopSlick) {
            stopSlick = true;
            clearInterval(commentSlick);
            clearTimeout(timer1);
            clearTimeout(timer2);
            clearTimeout(timer3);
            clearTimeout(timer4);
        }

    });
    //ADD TICKETS TO LOCALSTORAGE
    $(".input-fc-btn").click(function () {
        var id = $(this).attr("fc-btn-target");
        var val = $("." + id).val();
        var counter;
        if ($('.section-3').hasClass('city-1')) {
            counter = localStorage.getItem("cartCounter1");
        }
        else {
            counter = localStorage.getItem("cartCounter2");
        }
        if ($(this).attr("fc-btn-func") === "1" && counter >= 99) {
            $(this).attr('disabled', 'true');
        }
        else if ($(this).attr("fc-btn-func") === "1" && counter < 99) {
            $(this).removeAttr('disabled');
            $("." + id).val(++val);
        }
        else if (val > 0) {
            $("." + id).val(--val);
        }
        fillStorage();
    });
    $(".s-input").keyup(function () {
        var val = $(this).val();
        if (val < 0 || val.search(/[A-z]/) !== -1) $(this).val(0);
        fillStorage();
    });

    //INDEX SELECT CITY
    $('.select-items').on('click', function (e) {

        if ($('.same-as-selected').text() == "St. Augistine") {

            cityName = "Chicago";
        }
        if ($('.same-as-selected').text() == "Chicago") {
            cityName = "St-Augustine";

        }
    });


    var mobileHover = false;

    var resizeCount = false;
    var anchors = [];
    var currentAnchor = -1;
    var cityChoose = false;
    var timeout = true;
    $('.top-card-slider .top-card').click(function () {
        slickIndex = $('.top-card-slider .slick-active').attr('data-slick-index');
        if ($(this).parent().attr('data-slick-index') != slickIndex+1) {
            if ($(this).parent().attr('data-slick-index') > slickIndex) {
                if (timeout) {
                    $('.top-card-wrap').removeClass('slick-selected');
                    $('.top-card-wrap[data-slick-index=' + ++slickIndex + ']').addClass('slick-selected');
                    $('.top-card-slider').slick('slickNext');
                    timeout = false;
                    setTimeout(function () {
                        timeout = true;
                    }, 500);
                } 
            }
            else {    
                if (timeout) {
                    $('.top-card-wrap').removeClass('slick-selected');
                    $('.top-card-wrap[data-slick-index=' + --slickIndex + ']').addClass('slick-selected');
                    $('.top-card-slider').slick('slickPrev');
                    timeout = false;
                    setTimeout(function () {
                        timeout = true;
                    }, 500);
                } 
            }
        }
    });
    $(window).bind('scroll', function(){
        if ($(window).width() < 1055) {
            if (!$(".section-3-slider").hasClass('slick-initialized')) {
                $(".section-3-slider").slick({
                    slidesToShow: 1,
                    dots: false,
                    arrows: true,
                    lazyLoad: 'ondemand',
                });
            }
            $(window).unbind('scroll');
        }
        else {
            $(window).unbind('scroll');
        }
    });
    $(window).bind('touchstart', function () {
        if ($('.section-3').hasClass('city-2')) {
            if (!$(".city-2.section-2-content-wrap").hasClass('slick-initialized')) {
                $(".city-2.section-2-content-wrap").slick({
                    centerMode: true,
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    arrows: false,
                    dots: false,
                    draggable: false
                   
                });
            }
            $(window).unbind('touchstart');
        }
        else {
            $(window).unbind('touchstart');
        }
    });
    var slickIndex = 1;
    var slickPrevCity2 = 2;
    if (!$('.section-3').hasClass('city-2')) {
        slickIndex = 3;
    }
    
    $('.top-card-wrap').on('touchmove', function (e) {
        
     
        let bool = false;
        let elem = $(this);
        let leaveCard = false;
        let elemindex = +$(this).attr('data-slick-index') +1;
        setTimeout(function () {
            
            if (!elem.hasClass('slick-active')) {
                if (!$('.section-3').hasClass('city-2')) {
                    
                    if (elemindex !== 4) {
                        $(".city-1 .top-card-wrap").removeClass('slick-selected');
                        $(".city-1 .top-card-wrap[data-slick-index = " + elemindex + "]").addClass('slick-selected');
                    }
                    else {
                        
                        $(".city-1 .top-card-wrap").removeClass('slick-selected');
                        $(".city-1 .top-card-wrap[data-slick-index = 4]").addClass('slick-selected');
                    }
                }
                else {
                    
                    if (elemindex - 1 == -2) {
                        
                        $(".city-2 .top-card-wrap").removeClass('slick-selected');
                        $(".city-2 .top-card-wrap[data-slick-index = 3]").addClass('slick-selected');
                        $(".city-2 .top-card-wrap[data-slick-index = -1]").addClass('slick-selected');
                    }
                    else if (elemindex - 1 == 3) {
                        
                        $(".city-2 .top-card-wrap").removeClass('slick-selected');
                        $(".city-2 .top-card-wrap[data-slick-index = 2]").addClass('slick-selected');
                        $(".city-2 .top-card-wrap[data-slick-index = -2]").addClass('slick-selected');
                    }
                    else {
                        $(".city-2 .top-card-wrap").removeClass('slick-selected');
                        $(".city-2 .top-card-wrap[data-slick-index =" + elemindex + "]").addClass('slick-selected');
                        elemindex -= 2;
                        $(".city-2 .top-card-wrap[data-slick-index = " + elemindex +"]").addClass('slick-selected');
                    }
                }
            }
           
        }, 50);
    });
    function checkPosition() {
        if ($(window).width() < 1066) {
            mobileHover = true;
            $('.section-3 img').attr('data-src', '');
            
            // CHANGE PADDING AMONG CARDS OF MUSEUMS ON MOBILE
            if ($('.section-3').hasClass('city-1')) {
                
                $('.city-1 .top-card-link').width($('.slick-active .card-img').width() + 'px'); $('.top-card-link').css('left', 'calc(50% - ' + $('.slick-active .card-img').width() / 2 + 'px)');
                if (!$(".city-1.top-card-slider").hasClass('slick-initialized') && $('.city-1').css('display') != 'none') {
                    $(".city-1.top-card-slider").slick({
                        initialSlide: 4,
                        centerMode: true,
                        centerPadding: '2.5vw',
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: false,
                        lazyLoad: 'ondemand',
                        arrows: false,
                        adaptiveHeight: true,
                        responsive: [
                            {
                                breakpoint: 360,
                                settings: {
                                    centerPadding: '2.5vw'
                                }
                            },
                            {
                                breakpoint: 425,
                                settings: {
                                    centerPadding: '8vw'
                                }
                            },
                            {
                                breakpoint: 725,
                                settings: {
                                    centerPadding: '11vw'
                                }
                            },
                            {
                                breakpoint: 1055,
                                settings: {
                                    centerPadding: '17vw'
                                }
                            }
                        ]
                        //asNavFor: ".section-2-content-wrap"
                    });
                }
                $('.top-card-link').width($('.card-img').width() + 'px'); $('.top-card-link').css('left', 'calc(50% - ' + $('.card-img').width() / 2 + 'px)');
            }
            else if ($('.section-3').hasClass('city-2')) {
                if (!$(".city-2.top-card-slider").hasClass('slick-initialized') && $('.city-2').css('display') != 'none') {
                    $(".city-2.top-card-slider").slick({
                        initialSlide: 2,
                        centerMode: true,
                        lazyLoad: 'ondemand',
                        centerPadding: '5vw',
                        slidesToShow: 1,
                        slidesToScroll: 1,
                        arrows: false,
                        infinite: true,
                        dots: false,
                        adaptiveHeight: true,
                        draggable: true,
                        asNavFor: ".section-2-content-wrap",
                        responsive: [
                            {
                                breakpoint: 360,
                                settings: {
                                    centerPadding: '5vw'
                                }
                            },
                            {
                                breakpoint: 425,
                                settings: {
                                    centerPadding: '8vw'
                                }
                            },
                            {
                                breakpoint: 725,
                                settings: {
                                    centerPadding: '11vw'
                                }
                            },
                            {
                                breakpoint: 1055,
                                settings: {
                                    centerPadding: '13vw'
                                }
                            }
                        ]
                    });
                }
            }
         
            $('.top').css('background', 'none');
            $('.section-2').css('background', 'none');
            $('.section-3').css('background', 'none');
          
        }
        else {
            $('.top-card-link').width('99px');
            setTimeout(function () { $("#overlayer1").css("display", 'none') }, 300);
            setTimeout(function () { $("#overlayer2").css("display", 'none') }, 300);
            setTimeout(function () { $("#overlayer3").css("display", 'none') }, 300);
            mobileHover = false;
            setTimeout(function () { $('.section-3-card').css("min-width","initial"); }, 100);
            $(".top-card").hover(function () {
                $(this).toggleClass("top-card-active");
            });
            $(".top-card").mouseleave(function () {
                $(".top-card").removeClass("top-card-active");
            });
            if ($(".city-1.top-card-slider").hasClass('slick-initialized')) {
                $(".city-1.top-card-slider").slick("unslick");
            }
            if ($(".city-2.top-card-slider").hasClass('slick-initialized')) {
                $(".city-2.top-card-slider").slick("unslick");
            }
            if ($(".section-3-slider").hasClass('slick-initialized')) {
                $(".section-3-slider ").slick("unslick");
            }
            if ($(".section-2-content-wrap").hasClass('slick-initialized')) {
                $(".section-2-content-wrap").slick("unslick");
            }
            
            if ($(".section-2-card-slider").hasClass('slick-initialized')) {
                setTimeout(function () {
                    
                $(".section-2-card-slider").slick("unslick");
                
                    $(".section-2-card-slider").slick({
                        arrows: false,
                        dots: false,
                        speed: 500
       
                    });
                    $(".section-2-card-slider[slider-def-slide=1]").slick("slickGoTo", 0);
                    $(".section-2-card-slider[slider-def-slide=2]").slick("slickGoTo", 1);
                    $(".section-2-card-slider[slider-def-slide=3]").slick("slickGoTo", 2);
                    $(".section-2-card-slider[slider-def-slide=4]").slick("slickGoTo", 3);
                }, 500);
            }

        }
        //$('.slick-slide').width($('.slick-slide').width() + 1);

    }
    $(".top-card > div:nth-child(2) img,.card-active .img-first-block").hover(function () {
        if (mobileHover)
            $('.top-content-wrap .slick-active .top-card').addClass("card-active");
            
    });
    $(".top-card ").mouseleave(function () {
        $('.top-content-wrap .slick-active .top-card').removeClass("card-active");
    });
    $(".section-2-card-slider").slick({
        arrows: false,
        dots: false,
        speed: 500

    });
$(".section-2-card-slider[slider-def-slide=1]").slick("slickGoTo", 0);
    $(".section-2-card-slider[slider-def-slide=2]").slick("slickGoTo", 1);
    $(".section-2-card-slider[slider-def-slide=3]").slick("slickGoTo", 2);
    $(".section-2-card-slider[slider-def-slide=4]").slick("slickGoTo", 3);
    let commentSlick;
    let timer1, timer2, timer3, timer4;
    commentSlick = setInterval(function () {
        let child = "first-child";
        function checkSocial(child) {
            $('.section-2-content-wrap .section-2-card:' + child + ' .facebook-icon').css('background', 'url("../images/facebook.svg") no-repeat');
            $('.section-2-content-wrap .section-2-card:' + child + ' .gplus-icon').css('background', 'url("../images/gplus.svg") no-repeat');
            $('.section-2-content-wrap .section-2-card:' + child + ' .trip-advisor-icon').css('background', 'url("../images/trip-advisor.svg") no-repeat');
            $('.section-2-content-wrap .section-2-card:' + child + ' .yelp-icon').css('background', 'url("../images/yekp.png") no-repeat');
            $('.section-2-content-wrap .section-2-card:' + child + ' .yelp-icon').css('opacity', '0.8');
            switch ($('.section-2-content-wrap .section-2-card:' + child + ' .slick-current ').attr('data-slick-index')) {
                case "3": $('.section-2-content-wrap .section-2-card:' + child + ' .facebook-icon').css('background', 'url("../images/facebook-active.svg") no-repeat'); break;
                case "1": $('.section-2-content-wrap .section-2-card:' + child + ' .gplus-icon').css('background', 'url("../images/gplus-active.svg") no-repeat'); break;
                case "0": $('.section-2-content-wrap .section-2-card:' + child + ' .trip-advisor-icon').css('background', 'url("../images/trip-advisor-active.svg") no-repeat'); break;
                case "2": $('.section-2-content-wrap .section-2-card:' + child + ' .yelp-icon').css('opacity', '1');  break;
            }
        }
         timer1 = setTimeout(function () {
            child = "first-child";
             checkSocial(child);
             $(".section-2-card-slider[slider-def-slide=1]").first().slick("slickNext");
        }, 500);

        timer2 = setTimeout(function () {
            child = "nth-child(2)";
            checkSocial(child);
            $(".section-2-card-slider[slider-def-slide=2]").first().slick("slickNext");
            console.log($(".section-2-card-slider[slider-def-slide=2]"));
        }, 1000);
        timer3 = setTimeout(function () {
            if ($('.section-3').hasClass('city-1')) {
                child = "nth-child(3)";
                checkSocial(child);
                $(".section-2-card-slider[slider-def-slide=3]").first().slick("slickNext");
            }
            
        }, 1500);

        timer4 = setTimeout(function () {
            if ($('.section-3').hasClass('city-1')) {
                child = "last-child";
                checkSocial(child);
                $(".section-2-card-slider[slider-def-slide=4]").first().slick("slickNext");
            }
           
        }, 2000);
    }, 4000);
});