// animate__animated
$(window).scroll(function() {
    $('.anime1').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeInLeft");
        }
    });
});
$(window).scroll(function() {
    $('.anime2').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeIn");
        }
    });
});
$(window).scroll(function() {
    $('.anime3').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeInUpBig");
        }
    });
});
$(window).scroll(function() {
    $('.anime4').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeInRight");
        }
    });
});
$(window).scroll(function() {
    $('.anime5').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeInDownBig");
        }
    });
});
$(window).scroll(function() {
    $('.anime6').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeInLeftBig");
        }
    });
});
$(window).scroll(function() {
    $('.anime7').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__lightSpeedInRight");
        }
    });
});
$(window).scroll(function() {
    $('.anime8').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__lightSpeedInLeft");
        }
    });
});
$(window).scroll(function() {
    $('.anime9').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__zoomIn");
        }
    });
});
$(window).scroll(function() {
    $('.anime10').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeInRightBig");
        }
    });
});

$(window).scroll(function() {
    $('.path').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeIn faster");
        }
    });
});

$(window).scroll(function() {
    $('.pather').each(function () {
        var imagePos = $(this).offset().top;

        var topOfWindow = $(window).scrollTop();
        if (imagePos < topOfWindow + $(window).innerHeight()) {
            $(this).addClass("animate__animated animate__fadeOut faster");
        }
    });
});
