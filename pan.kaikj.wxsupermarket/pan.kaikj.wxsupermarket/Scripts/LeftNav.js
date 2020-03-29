$(function () {
    if ("undefined" != typeof thisPagClass && thisPagClass) {
        $("." + thisPagClass).css("background-color", "#00C1DE");
        if ($("." + thisPagClass).is('li')) {
            $("." + thisPagClass).parent().show();
            var sidebarNav = $("." + thisPagClass).parent().prev();
            var navImg = sidebarNav.children("span.navImg").text();
            var dataNavName = $(navImg).attr("data-navName");
            if (navImg == "▶") {
                $(".inner-Nav-" + dataNavName).show();
                $(sidebarNav).children("span.navImg").text("▼");
                $(sidebarNav).children("span.navImg").css("font-size", "10px");
            } else {
                $(".inner-Nav-" + dataNavName).hide();
                $(sidebarNav).children("span.navImg").text("▶");
                $(sidebarNav).children("span.navImg").css("font-size", "19px");
            }
        }
    }

    $(".sidebar-Nav").click(function () {
        var navImg = $(this).children("span.navImg").text();
        $(".sidebar-trans").hide();
        $(".navImg").text("▶");
        $(".navImg").css("font-size", "19px");

        var dataNavName = $(this).attr("data-navName");
        if (navImg == "▼") {
            $(".inner-Nav-" + dataNavName).hide();
            $(this).children("span.navImg").text("▶");
            $(this).children("span.navImg").css("font-size", "19px");
          
        } else {
            $(".inner-Nav-" + dataNavName).show();
            $(this).children("span.navImg").text("▼");
            $(this).children("span.navImg").css("font-size", "10px");
        }



    });

    $(".sidebar-Nav").hover(function () {
        $(this).css("background-color", "#00C1DE");
    }, function () {
        $(this).css("background-color", "#42485B");
        if ("undefined" != typeof thisPagClass && thisPagClass) {
            $("." + thisPagClass).css("background-color", "#00C1DE");
        }
    });

    $(".nav-item").mousemove(function () {
        $(this).css("background-color", "#525b78");
        if ("undefined" != typeof thisPagClass && thisPagClass) {
            $("." + thisPagClass).css("background-color", "#00C1DE");
        }
    }).mouseout(function () {
        $(this).css("background-color", "");
        if ("undefined" != typeof thisPagClass && thisPagClass) {
            $("." + thisPagClass).css("background-color", "#00C1DE");
        }
    });
});