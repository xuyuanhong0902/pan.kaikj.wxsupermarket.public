var pagIndex = 1;  //// 页码
var orderBy = ""; //// 排序方式
var thisPagClass = "pagclass0201";
var app = angular.module("myApp", []);
app.controller("myContro", function ($scope) {
    //// 数据初始化
    $scope.condition = {
        acount: "",
        name: ""
    }

    //// 单击查询事件
    $scope.selectFun = GetAndShowData;

    //// 单击删除事件
    $scope.deleteUser = deleteUser;

    //// 重置密码
    $scope.resetPass = resetPass;

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
        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminIndex/SelectUserListMeth",//这是我在后台接受数据的文件名
            data: "pagIndex=" + pagIndex + "&acount=" + $scope.condition.acount + "&name=" + $scope.condition.name,//将该表单序列化
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

    //// 删除事件
    function deleteUser(adminuserid) {
        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminIndex/DeletUserByIdMeth",//这是我在后台接受数据的文件名
            data: "adminuserid=" + adminuserid,//将该表单序列化
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

    //重置密码
    function resetPass(adminuserid) {
        //// 表单数据真实提交逻辑
        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminIndex/ChangAdminUserPass",//这是我在后台接受数据的文件名
            data: "adminuserid=" + adminuserid,//将该表单序列化
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
                            alert(dataObj["errmsg"]);
                        }
                    } else {
                        alert("操作失败！");
                    }
                }
            }
        });
    }
});