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
    if (typeof thisPageVlaue != "undefined") {
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
}

//// 绑定底部导航
function initBotom(pagIndex) {
   
    var html = ' <a  href="/market/IndexPage" class="ontCount"><i style = "background-position:' + (pagIndex == 1 ? "-120px -46px" : "-84px -46px") +';" ></i ><span>首页</span></a >\
        <a  href="/market/IndexClass" class="ontCount"><i style = "background-position:' + (pagIndex == 2 ? "-84px -230px" : "-84px -195px") +';" ></i ><span>分类</span></a >\
        <a  href="/market/takeout" class="ontCount"><i style="background-position:' + (pagIndex == 3 ? "-49px -120px" : "-12px -120px") +';"></i><span>购物车</span></a>\
        <a  href="/market/orderList" class="ontCount"><i style="background-position:' + (pagIndex == 4 ? "-120px -120px" : "-83px -120px") +';"></i><span>我的订单</span></a>';
    $("#botCount").html(html);
}

