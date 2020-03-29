//// 分页控件控制显示
function DoPagShow(resultObj) {
    if (resultObj) {
        pagIndex = parseInt(resultObj["pagIndex"]);
        var totalPage = parseInt(resultObj["totalPage"]);
        $("#goPagInput").val(pagIndex);

        $("#totalNum").html(resultObj["totalNum"]);

        //// 分页控件控制
        if (pagIndex == 1) {
            $("#FirstPage").hide();
            $("#PreviPage").hide();
        } else {
            $("#FirstPage").show();
            $("#PreviPage").show();
            $("#PreviPage").attr("go_value", pagIndex - 1);
        }

        if (pagIndex == totalPage) {
            $("#NextPage").hide();
            $("#LastPage").hide();
        } else {
            $("#NextPage").show();
            $("#LastPage").show();
            $("#NextPage").attr("go_value", pagIndex + 1);
            $("#LastPage").attr("go_value", totalPage);
        }

        if (pagIndex == 1 && pagIndex == totalPage) {
            $("#gotopagCount").hide();
        } else {
            $("#gotopagCount").show();
        }

        if (resultObj["dataList"]) {
            $("#valueListCount").show();
            $("#pagCount").show();
            $("#valueListCount").show();
            $("#answerCount").show();
        } else {
            $("#lblMsg").text("There are totally 0 order records found!");
            $("#valueListCount").hide();
            $("#pagCount").hide();
            $("#valueListCount").hide();
            $("#answerCount").hide();
        }
    }
}