$(function () {

    showThisPageNag();

    $(".nagTitle").click(function () {
        $(".nagSubList").hide();
        $(".nagSubList" + $(this).attr("nag-data")).show();
    });

    $(".oneCont").mousemove(function () {
        $(this).children(".nagTitle").css({ "font-size": "18px", "background-color": "#2d78f4" });
        $(".nagSubList").hide();
        $(".nagSubList" + $(this).children(".nagTitle").attr("nag-data")).show();
        $(".select").removeClass("select");
        $(".liSelect").removeClass("liSelect");
        $("span.nagLog").html("▶");
        $(this).children(".nagTitle").children("span.nagLog").html("▼");
    }).mouseout(function () {
        $(this).children(".nagTitle").css({ "font-size": "16px", "background-color": "" });
        showThisPageNag();
    });

    $(".nagOneList").mousemove(function () {
        $(this).css({ "font-size": "18px", "background-color": "#01204f" });
    }).mouseout(function () {
        $(this).css({ "font-size": "16px", "background-color": "" });
    });
});

function showThisPageNag() {

    if (thisPageVlaue.indexOf("nagTitle") == -1) {
        $(".nagSubList").hide();
        $(".liSelect").removeClass("liSelect");
        $("." + thisPageVlaue).addClass("liSelect");
        $("." + thisPageVlaue).parent().parent().show();
        $("." + thisPageVlaue).parent().parent().prev().addClass("select");
        var nagLog = $("." + thisPageVlaue).parent().parent().prev().children("span.nagLog");
        $("span.nagLog").html("▶");
        $(nagLog).html("▼");
    } else {
        $(".nagSubList").hide();
        $("." + thisPageVlaue).addClass("select");
    }
}