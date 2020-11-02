
$(function () {
    var element = $("#view2"), display;
    $(window).scroll(function () {
        display = $(this).scrollTop() >= 750;
        if(display){
            element.show();
        }else{
            element.hide();
        }
    });
});
$(function () {
    var element = $("#view3"), display;
    $(window).scroll(function () {
        display = $(this).scrollTop() >= 1450;
        if(display){
            element.show();
        }else{
            element.hide();
        }
    });
});


