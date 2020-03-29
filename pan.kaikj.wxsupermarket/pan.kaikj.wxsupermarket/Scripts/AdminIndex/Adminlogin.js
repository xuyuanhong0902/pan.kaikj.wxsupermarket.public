    var app = angular.module("loginApp", []);
    app.controller("loginContro", function ($scope) {
        //// 登录信息初始化
        $scope.user = {
            acount: "",
            pass: "",
            verifiCode: "",
            err: "",
            verifiCodePath: '../Login/GetValidateCode?time=00'
        }

        //// 登录事件
        $scope.subLogin = function () {
        $.ajax({
            type: "GET",
            url: "../Login/SubLoginMeth",
            data: "acount=" + $scope.user.acount + "&pass=" + $scope.user.pass + "&verifiCode=" + $scope.user.verifiCode + "",
            success: function (data) {
                var mwxResult = $.parseJSON(data);
                if (mwxResult["errcode"] == "0") {
                    $scope.user.err = "";
                    //// 跳转至欢迎页面
                    window.location.href = "../AdminIndex/Index";
                } else {
                    $scope.changVerifiCode();
                    $scope.$apply(function () {
                        $scope.user.err = mwxResult["errmsg"];
                    });
                }

            }
        });
    }

    //// 刷新验证码
        $scope.changVerifiCode = function () {
        $scope.user.verifiCodePath = '../Login/GetValidateCode?time=' + Date.parse(new Date());
    }
});
