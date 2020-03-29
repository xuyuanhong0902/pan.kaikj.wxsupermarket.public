var pagIndex = 1;  //// 页码
var orderBy = ""; //// 排序方式
var thisPagClass = "pagclass0501";
var app = angular.module("myApp", []);
app.controller("myContro", function ($scope) {
    //// 数据初始化
    $scope.condition = {
        userName: "",
        productname: "",
        orderState: "0",
        groupOrderId: "",
        orderId:""
    }

    //// 单击查询事件
    $scope.selectFun = GetAndShowData;

    $scope.deliveryOpert = DeliveryOpert;

    $scope.batchDeliveryOpert = BatchDeliveryOpert;
    $scope.batchCancleOpert = BatchCancleOpert;
    $scope.batchSendGoodsOpert = BatchSendGoodsOpert;
    
    //// 分页控件页码单击事件
    $scope.SearchFunPageBut = function (butId) {
        orderBy = "";
        pagIndex = $("#" + butId).attr("go_value");

        //// 获取显示数据
        GetAndShowData();
    }

    //// 跳转至指定页码事件
    $scope.SearchFunGoPagBut = function () {
        orderBy = "";
        pagIndex = $("#goPagInput").val();
        var Regx = /^[0-9]+$/;

        if (!Regx.test(pagIndex)) {
            alert("The page must be numeric!");
            return;
        } else {
            //// 获取显示数据
            GetAndShowData();
        }
    }

    //// 分页查询数据
    function GetAndShowData() {
        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        if (startDate && endDate) {
            if (startDate > endDate) {
                alert("开始日期不能大于结束日期！");
                return;
            }
        }

        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminOrder/SelectOrderListMeth",//这是我在后台接受数据的文件名
            data: "pagIndex=" + pagIndex + "&userName=" + $scope.condition.userName
                + "&productname=" + $scope.condition.productname
                + "&groupOrderId=" + $scope.condition.groupOrderId
                + "&orderId=" + $scope.condition.orderId
                + "&orderState=" + $scope.condition.orderState
                + "&startDate=" + startDate
                + "&endDate=" + endDate,//将该表单序列化
            async: true,//设置成true，这标志着在请求开始后，其他代码依然能够执行。如果把这个选项设置成false，这意味着所有的请求都不再是异步的了，这也会导致浏览器被锁死
            error: function (request) {//请求失败之后的操作
                alert("操作失败！");
            },
            success: function (data) {//请求成功之后的操作
                if (data == "-1") {
                    window.location.href = '../Login/Index';
                } else {
                    if (data) {
                        var dataObj = $.parseJSON(data);
                        $scope.$apply(function () {
                            $scope.modelList = dataObj["dataList"];
                            DoPagShow(dataObj);
                        });
                    }
                }
            }
        });
    }

    //// 设置订单已完成
    function DeliveryOpert(orderid) {
        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminOrder/UpdateOrderHasRecepitMeth",//这是我在后台接受数据的文件名
            data: "orderid=" + orderid,//将该表单序列化
            async: true,//设置成true，这标志着在请求开始后，其他代码依然能够执行。如果把这个选项设置成false，这意味着所有的请求都不再是异步的了，这也会导致浏览器被锁死
            error: function (request) {//请求失败之后的操作
                alert("操作失败！");
            },
            success: function (data) {//请求成功之后的操作
                if (data == "-1") {
                    window.location.href = '../Login/Index';
                } else {
                    if (data) {
                        var dataObj = $.parseJSON(data);
                        if (dataObj) {
                            if (dataObj["errcode"] == "0") {
                                //// 操作成功：重新绑定数据
                                $scope.selectFun();
                            }

                            alert(dataObj["errmsg"]);
                        }
                    } else {
                        alert("操作失败！");
                    }
                }
            }
        });
    }

    //// 设置订单已完成(批量)
    function BatchDeliveryOpert() {
        var ids = GetSelectIds();

        if (!ids) {
            alert("请选中需要操作的数据！");
            return;
        }

      

        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminOrder/UpdateOrderHasRecepitByIdsMeth",//这是我在后台接受数据的文件名
            data: "orderidS=" + ids,//将该表单序列化
            async: true,//设置成true，这标志着在请求开始后，其他代码依然能够执行。如果把这个选项设置成false，这意味着所有的请求都不再是异步的了，这也会导致浏览器被锁死
            error: function (request) {//请求失败之后的操作
                alert("操作失败！");
            },
            success: function (data) {//请求成功之后的操作
                if (data == "-1") {
                    window.location.href = '../Login/Index';
                } else {
                    if (data) {
                        var dataObj = $.parseJSON(data);
                        if (dataObj) {
                            if (dataObj["errcode"] == "0") {
                                //// 操作成功：重新绑定数据
                                $scope.selectFun();
                            }

                            alert(dataObj["errmsg"]);
                        }
                    } else {
                        alert("操作失败！");
                    }
                }
            }
        });
    }

    //// 设置送货(批量)
    function BatchSendGoodsOpert() {
        var ids = GetSelectIds();

        if (!ids) {
            alert("请选中需要操作的数据！");
            return;
        }

        if (!$scope.condition.sendGoodsUser) {
            alert("请选择送货员信息！");
            return;
        }

        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminOrder/UdateOrderDeliveryByIds",//这是我在后台接受数据的文件名
            data: "ids=" + ids + "&sendGoodUserId=" + $scope.condition.sendGoodsUser,//将该表单序列化
            async: true,//设置成true，这标志着在请求开始后，其他代码依然能够执行。如果把这个选项设置成false，这意味着所有的请求都不再是异步的了，这也会导致浏览器被锁死
            error: function (request) {//请求失败之后的操作
                alert("操作失败！");
            },
            success: function (data) {//请求成功之后的操作
                if (data == "-1") {
                    window.location.href = '../Login/Index';
                } else {
                    if (data) {
                        var dataObj = $.parseJSON(data);
                        if (dataObj) {
                            if (dataObj["errcode"] == "0") {
                                //// 操作成功：重新绑定数据
                                $scope.selectFun();
                            }

                            alert(dataObj["errmsg"]);
                        }
                    } else {
                        alert("操作失败！");
                    }
                }
            }
        });
    }

    //// 设置订单已取消(批量)
    function BatchCancleOpert() {
        var ids = GetSelectIds();

        if (!ids) {
            alert("请选中需要操作的数据！");
            return;
        }

        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminOrder/UpdateOrderHasCancleByIdsMeth",//这是我在后台接受数据的文件名
            data: "orderidS=" + ids,//将该表单序列化
            async: true,//设置成true，这标志着在请求开始后，其他代码依然能够执行。如果把这个选项设置成false，这意味着所有的请求都不再是异步的了，这也会导致浏览器被锁死
            error: function (request) {//请求失败之后的操作
                alert("操作失败！");
            },
            success: function (data) {//请求成功之后的操作
                if (data == "-1") {
                    window.location.href = '../Login/Index';
                } else {
                    if (data) {
                        var dataObj = $.parseJSON(data);
                        if (dataObj) {
                            if (dataObj["errcode"] == "0") {
                                //// 操作成功：重新绑定数据
                                $scope.selectFun();
                            }

                            alert(dataObj["errmsg"]);
                        }
                    } else {
                        alert("操作失败！");
                    }
                }
            }
        });
    }

    //// 获取所选中的全部ID集合
    function GetSelectIds() {
        var ids = "";
        $('input:checkbox[name=checkBox]:checked').each(function (index, item) {
            ids = ids + ",'" + $(this).attr("id")+"'";
        });

        return ids;
    }
});