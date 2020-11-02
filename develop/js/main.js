let sliderOne = $('.slider1').slick({
    autoplay: false,
    centerMode: true,
    centerPadding: '80px',
    dots: true,
    arrows: false,
    infinite: false,
    initialSlide: 0,
    asNavFor: '.slider2',
    responsive:[
        {
            breakpoint: 450,
            settings:{
                centerPadding: '34px',
            }
        }
    ]
});
let sliderTwo = $('.slider2').slick({
    autoplay: false,
    infinite: false,
    arrows: false,
    initialSlide: 0,
    asNavFor: '.slider1'
});
$('.slider3').slick({
    autoplay: false,
    initialSlide: 7
});
$('.slider4').slick({
    autoplay: false,
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 1,
    centerPadding: '8.5rem',
    centerMode: true,
    dots: true,
    arrows: true,
    responsive:[
        {
            breakpoint: 1270,
            settings:{
                slidesToShow: 3,
            }
        },
        {
            breakpoint: 900,
            settings:{
                slidesToShow: 2,
                centerPadding: '15.5rem',
            },
        }
    
    ]
});

$(document).ready(function () {

    const select = $('select');

    select.niceSelect();
    select.niceSelect('update');

    //Плавний скрол к ALL ATTRACTIONS UNDER ONE ROOF
    $(".button-link").click(function () {
        var elementClick = $(this).attr("href");
        var destination = $(elementClick).offset().top;
        $('html').animate({ scrollTop: destination }, 1100);
    });

    setTimeout(() => {
        document.getElementById("fileAnimate").remove();
    }, 3500);

    /* Перемикання міст */
    setTimeout(function () {
        const
            oldOpen = document.createElement("div"),
            newOpen = document.createElement("div"),
            oldContactItem = document.createElement("div"),
            newContactItem = document.createElement("div"),
            oldMapParent = document.createElement("div"),
            newMapParent = document.createElement("div");

        oldOpen.classList.add("open");
        newOpen.classList.add("open");

        oldContactItem.classList.add("contact__item-text1");
        newContactItem.classList.add("contact__item-text1");

        oldMapParent.classList.add("map");
        newMapParent.classList.add("map");
        oldMapParent.setAttribute("id", "parentMap");
        newMapParent.setAttribute("id", "parentMap");

        oldOpen.innerHTML = `<div class="open">
\t\t\t\t\t\t\t\t<div class="h1">Hours open <span>365</span> days</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Monday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text firstOpenItemText">10 am – 11 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Tuesday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 11 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Wednesday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 11 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Thursday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 11 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Friday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text center">10 am – 1 am</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Saturday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text center">10 am – 1 am</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Sunday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 11 pm</div>
\t\t\t\t\t\t\t\t</div><br>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text1">Last ticket sold one hour prior<br class="removeBr"> to closing</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t</div>`;
        newOpen.innerHTML = `
                <div class="open">
\t\t\t\t\t\t\t\t<div class="h1">Hours open <span>365</span> days</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Monday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text firstOpenItemText" style="margin-right: 2px;">10 am – 11 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Tuesday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 10 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Wednesday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 10 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Thursday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 10 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Friday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text center">10 am – 10 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Saturday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text center">10 am – 10 pm</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text">Sunday:</div>
\t\t\t\t\t\t\t\t\t<div class="open__item-text">10 am – 10 pm</div>
\t\t\t\t\t\t\t\t</div><br>
\t\t\t\t\t\t\t\t<div class="open__item">
\t\t\t\t\t\t\t\t\t<div class="open__item-text1">Last ticket told one hour prior<br class="removeBr">to closing</div>
\t\t\t\t\t\t\t\t</div>
\t\t\t\t\t\t\t</div>`;

        oldContactItem.innerHTML = `<a title="click to visit map" target="_blank" class="maplink" href="https://goo.gl/maps/11mRJZFuJsZhbc2K9">211 S State St, Chicago, IL<span>60604</span></a>`;
        newContactItem.innerHTML = `<a title="click to visit map" target="_blank" class="maplink" href="https://goo.gl/maps/4gJZzS48vH7bPs9s5">100 St George St, St. Augustine, FL <span>32084</span></a>`;

        oldMapParent.innerHTML = `<iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d5941.280215846711!2d-87.627482!3d41.879089!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x880e2ca33f58ffd1%3A0xf06bc2d1f0d09729!2s211%20S%20State%20St%2C%20Chicago%2C%20IL%2060604%2C%20USA!5e0!3m2!1sen!2sua!4v1597659784049!5m2!1sen!2sua"  width="600" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>`;
        newMapParent.innerHTML = `<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3458.9454919933796!2d-81.3152870848884!3d29.894671181936996!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x88e42795ef799113%3A0x8f4b88d415750502!2sMedieval%20Torture%20Museum!5e0!3m2!1sen!2sua!4v1599847291706!5m2!1sen!2sua"  width="600" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>`;

        let
            counter = 0,
            saveFullRemoveTab = [],
            currentSelectedCity = "Chicago";

        $(".nice-select").on("click", function (e) {
            if (counter) {
                let
                    parentContact = document.querySelector(".contact"),
                    currentItemAddress = document.querySelector(".contact .contact-us .contact__item.address .contact__item-text1"),
                    parentElementItemAddress = currentItemAddress.parentNode,
                    currentOpen = document.querySelector(".contact .open"),
                    parentMap = document.querySelector("#parentMap"),
                    parentParentMap = parentMap.parentElement;

                const
                    currentNiceSelect = $(".nice-select .current"),
                    allRemoveTab = document.querySelectorAll(".removeTab"),
                    allRemoveStyleTab = document.querySelectorAll(".removeStyle"),
                    allTab = document.querySelectorAll(".tab"),
                    cellLineAddSb = document.querySelector(".cell__line.addSb"),
                    visibleTab = document.querySelector(".visibleTab"),
                    allFullRemoveTab = document.querySelectorAll(".fullRemoveTab");


                function ifChicago () {
                        parentContact.removeChild(currentOpen);
                        parentContact.appendChild(oldOpen);

                        const
                            centerElements =  document.querySelectorAll(".open__item-text.center"),
                            firstOpenItemText = document.querySelector(".firstOpenItemText");

                        centerElements.forEach(item => {
                            item.setAttribute("style", "");
                        });
                        firstOpenItemText.setAttribute("style", "");

                        parentElementItemAddress.removeChild(currentItemAddress);
                        parentElementItemAddress.appendChild(oldContactItem);

                        if (parentMap != oldMapParent) {
                            parentParentMap.removeChild(parentMap);
                            parentParentMap.appendChild(oldMapParent);
                        }
                        allRemoveTab.forEach(item => {
                            item.style.display = "block";
                        });
                        // slider1;
                        // slider1;
                        // slider2;
                        // slider2;

                        const
                            slider1 = document.getElementById("slider1"),
                            slider2 = document.getElementById("slider2");

                        if (saveFullRemoveTab[0] && saveFullRemoveTab[1] && saveFullRemoveTab[2] && saveFullRemoveTab[3]) {
                            slider1.querySelector(".slider1__item").parentElement.append(saveFullRemoveTab[0]);
                            slider1.querySelector(".slider1__item").parentElement.append(saveFullRemoveTab[1]);
                            slider2.querySelector(".slider2__item").parentElement.append(saveFullRemoveTab[2]);
                            slider2.querySelector(".slider2__item").parentElement.append(saveFullRemoveTab[3]);
                        }

                        saveFullRemoveTab = [];

                        allRemoveStyleTab.forEach(item => {
                            item.setAttribute("style", "");
                        });
                        allTab.forEach(item => {
                            item.setAttribute("style", "");
                        });
                        cellLineAddSb.setAttribute("style", "");
                        visibleTab.style.display = "none";

                    sessionStorage.setItem("selectCity", "Chicago");
                }

                function ifAugustine () {
                    parentContact.removeChild(currentOpen);
                    parentContact.appendChild(newOpen);

                    const
                        centerElements =  document.querySelectorAll(".open__item-text.center"),
                        firstOpenItemText = document.querySelector(".firstOpenItemText");
                    centerElements.forEach(item => {
                        item.style.marginRight = "0";
                    });
                    firstOpenItemText.style.marginRight = "3px";

                    parentElementItemAddress.removeChild(currentItemAddress);
                    parentElementItemAddress.appendChild(newContactItem);

                    if (parentMap != newMapParent) {
                        parentParentMap.removeChild(parentMap);
                        parentParentMap.appendChild(newMapParent);
                    }
                    allTab.forEach(item => {
                        item.setAttribute("style", "width: 50%;");
                    });
                    allRemoveTab.forEach(item => {
                        item.style.display = "none";
                    });
                    allFullRemoveTab.forEach(item => {
                        saveFullRemoveTab.push(item);
                        item.parentNode.removeChild(item);
                    });

                    visibleTab.querySelector(".cell__line").style.justifyContent = "space-between";
                    visibleTab.style.display = "block";
                    visibleTab.querySelector(".dablticket .blockHover").style.transform = "translateY(-51%)";

                    sessionStorage.setItem("selectCity", "St. Augustine");
                }

                setTimeout(() => {
                    if (document.documentElement.clientWidth > 795) {
                        if (currentNiceSelect[2].innerText === "St. Augustine") {
                            ifAugustine();
                        } else if (currentNiceSelect[2].innerText === "Chicago") {
                            ifChicago();
                        }
                    } else {
                        parentContact = document.querySelector(".contact.mobile");
                        currentItemAddress = document.querySelector(".contact.mobile .contact-us .contact__item.address .contact__item-text1");
                        parentElementItemAddress = currentItemAddress.parentNode;
                        currentOpen = document.querySelector(".contact.mobile .open");
                        parentMap = document.querySelector("#parentMobileMap");
                        parentParentMap = parentMap.parentElement;

                        oldMapParent.setAttribute("id", "parentMobileMap");
                        newMapParent.setAttribute("id", "parentMobileMap");

                        if (currentNiceSelect[3].innerText === "St. Augustine" && e.target !== currentNiceSelect[3] && currentSelectedCity !== "St. Augustine") {

                            sliderOne.slick("unslick");
                            sliderTwo.slick("unslick");
                            ifAugustine();
                            sliderOne.slick({
                                autoplay: false,
                                centerMode: true,
                                centerPadding: '80px',
                                dots: true,
                                arrows: false,
                                infinite: false,
                                initialSlide: 0,
                                asNavFor: '.slider2',
                                responsive:[
                                    {
                                        breakpoint: 450,
                                        settings:{
                                            centerPadding: '34px',
                                        }
                                    }
                                ]
                            });
                            sliderTwo.slick({
                                autoplay: false,
                                infinite: false,
                                arrows: false,
                                initialSlide: 0,
                                asNavFor: '.slider1'
                            });

                        } else if (currentNiceSelect[3].innerText === "Chicago" && e.target !== currentNiceSelect[3] && currentSelectedCity !== "Chicago") {

                            sliderOne.slick("unslick");
                            sliderTwo.slick("unslick");
                            ifChicago();
                            sliderOne.slick({
                                autoplay: false,
                                centerMode: true,
                                centerPadding: '80px',
                                dots: true,
                                arrows: false,
                                infinite: false,
                                initialSlide: 0,
                                asNavFor: '.slider2',
                                responsive:[
                                    {
                                        breakpoint: 450,
                                        settings:{
                                            centerPadding: '34px',
                                        }
                                    }
                                ]
                            });
                            sliderTwo.slick({
                                autoplay: false,
                                infinite: false,
                                arrows: false,
                                initialSlide: 0,
                                asNavFor: '.slider1'
                            });

                        }

                        if (e.target.classList.contains("option")) {
                            currentSelectedCity = e.target.textContent;
                        }
                    }
                }, 50);
            }
            counter++;
        });

        navigator.geolocation.getCurrentPosition(
            function(position) {

                const
                    coordinatesChicago = {
                        latitude: 41.879090,
                        longitude: -87.627480
                    },
                    coordinatesAugustine = {
                        latitude: 29.894616,
                        longitude: -81.313250
                    },
                    distanceChicago = {
                        latitude: position.coords.latitude - coordinatesChicago.latitude,
                        longitude: position.coords.longitude - coordinatesChicago.longitude
                    },
                    distanceAugustine = {
                        latitude: position.coords.latitude - coordinatesAugustine.latitude,
                        longitude: position.coords.longitude - coordinatesAugustine.longitude
                    };

                if (sessionStorage.getItem("selectCity")) {
                    const allNiceSelect = document.querySelectorAll(".nice-select");
                    if (sessionStorage.getItem("selectCity") === "Chicago") {
                        allNiceSelect.forEach(item => {
                            item.querySelector('.option[data-value="1"]').click();
                            item.querySelector('.option[data-value="1"]').click();
                            item.classList.remove("open");
                        })
                    } else {
                        allNiceSelect.forEach(item => {
                            item.querySelector('.option[data-value="2"]').click();
                            item.querySelector('.option[data-value="2"]').click();
                            item.classList.remove("open");
                        })
                    }
                } else if (distanceChicago.latitude > distanceAugustine.latitude || distanceChicago.longitude > distanceAugustine.longitude) {
                    const allNiceSelect = document.querySelectorAll(".nice-select");
                    allNiceSelect.forEach(item => {
                        item.querySelector('.option[data-value="2"]').click();
                        item.querySelector('.option[data-value="2"]').click();
                        item.classList.remove("open");
                    })
                }

            },

            function(error){}
        );
    }, 100);
});
