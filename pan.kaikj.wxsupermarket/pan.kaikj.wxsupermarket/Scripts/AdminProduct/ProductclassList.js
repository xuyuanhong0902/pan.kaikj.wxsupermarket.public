var thisPagClass = "pagclass0701";
var app = angular.module("myApp", []);
app.controller("myContro", function ($scope) {

    //// 删除产品分类事件
    $scope.deleteProductClass = deleteProductClassFun;

    //// 获取显示数据
    GetAndShowData();

    //// 分页查询数据
    function GetAndShowData() {
        $.ajax({
            cache: false,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminProduct/GetAllProductclassList",//这是我在后台接受数据的文件名
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
                            $scope.modelList = dataObj;
                        });
                    }
                }
            }
        });
    }

    //// 具体删除方法
    function deleteProductClassFun(classid,supclassid) {
        $.ajax({
            cache: true,//保留缓存数据
            type: "get",//为post请求
            url: "../AdminProduct/DeletProductclassesByIdMeth",//这是我在后台接受数据的文件名
            data: "classid=" + classid + "&supclassid=" + supclassid,//将该表单序列化
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
                                GetAndShowData();
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
});