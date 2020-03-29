//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg); //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

//// 验证邮箱格式
function CheckEmail(str) {
    var re = /^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/;
    if (re.test(str)) {
        return true;
    } else {
        return false;
    }
}

//// 验证手机号码
function CheckMobile(str) {
    var re = /^1\d{10}$/;
    if (re.test(str)) {
        return true;
    } else {
        return false;
    }
}

//// 验证航班号
function CheckFlightNo(str) {
    while (str.indexOf('/') >= 0) {
        str = str.replace('/', '');
    }

    var re = /^[A-Za-z0-9]*$/;
    if (re.test(str)) {
        return true;
    } else {
        return false;
    }
}

//// 只能输入正整数文本框发送改变事件
function IntNumInputChangeFun() {
    $('.intNumInput').bind('input propertychange keyup', function () {
        var value = $(this).val().toUpperCase();
        value = value.replace(/[^0-9|]/g, '');
        $(this).val(value);
    });
}

$(function () {

    GetAndBinNowYear("copyrightEndDate");

    //// 只能输入大小字母和数字限制文本框
    $('.numberOrCapital').bind('input propertychange keyup', function () {

        var value = $(this).val().toUpperCase();

        if (!value) {
            return;
        }

        var maxLen = $(this).attr("maxlength");
        if (maxLen) {
            if (value.length > maxLen) {
                value = value.substr(0, maxLen);
            }
        }
        value = value.replace(/[^A-Z0-9]/g, '');
        $(this).val(value);
    });

    //// 只能输入大小字母和数字and/ 限制文本框
    $('.numberOrCapitalOrSlash').bind('input propertychange keyup', function () {

        var value = $(this).val().toUpperCase();
        if (!value) {
            return;
        }

        var maxLen = $(this).attr("maxlength");
        if (maxLen) {
            if (value.length > maxLen) {
                value = value.substr(0, maxLen);
            }
        }
        value = value.replace(/[^A-Z0-9/]/g, '');
        $(this).val(value);
    });

    //// 只能输入正整数 限制文本框 
    $('.positInt').bind('input propertychange keyup', function () {
        var value = $(this).val().toUpperCase();
        var maxLen = $(this).attr("maxlength");
        if (maxLen) {
            if (value.length > maxLen) {
                value = value.substr(0, maxLen);
            }
        }
        value = value.replace(/[^0-9]/g, '');
        $(this).val(value);
    });

    //// 只能输入正数字 限制文本框 
    $('.positNum').bind('input propertychange keyup', function () {
        var value = $(this).val().toUpperCase();

        if (!value) {
            return;
        }

        var maxLen = $(this).attr("maxlength");
        if (maxLen) {

            if (value.length > maxLen) {
                value = value.substr(0, maxLen);
            }
        }

        value = value.replace(/[^0-9.]/g, '');
        $(this).val(value);
    });

    //// txtItinerary 文本框输入发送改变事件
    $('#txtItinerary').bind('input propertychange keyup', function () {
        var value = $(this).val();

        if (!value) {
            return;
        }

        var maxLen = $(this).attr("maxlength");
        if (maxLen) {

            if (value.length > maxLen) {
                value = value.substr(0, maxLen);
            }
        }

        value = value.replace(/[&=]/g, '');
        $(this).val(value);
    });
});

//// 或趋势上一个月的今天
function getPreMonth(dateTimes) {
    var arr = dateTimes.split('-');
    var year = arr[0]; //获取当前日期的年份  
    var month = arr[1]; //获取当前日期的月份  
    var day = arr[2]; //获取当前日期的日  
    var days = new Date(year, month, 0);

    days = days.getDate(); //获取当前日期中月的天数  
    var year2 = year;
    var month2 = parseInt(month) - 1;
    if (month2 == 0) {
        year2 = parseInt(year2) - 1;
        month2 = 12;
    }
    var day2 = day;
    var days2 = new Date(year2, month2, 0);
    days2 = days2.getDate();
    if (day2 > days2) {
        day2 = days2;
    }
    if (month2 < 10) {
        month2 = '0' + month2;
    }
    var t2 = year2 + '-' + month2 + '-' + day2;
    return t2;
}

//// 获取系统当天日期
function getNowFormatDate(n) {
    if (!n) {
        n = 0;
    }
    var date = new Date(new Date() - 0 + n * 86400000);
    var seperator = "-";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator + month + seperator + strDate;
    return currentdate;
}

function GetAndBinNowYear(id) {
    $("#" + id).text(new Date().getFullYear());
}

//// 获取系统当天时间
function getNowFormatDateTime(n) {
    if (!n) {
        n = 0;
    }
    var date = new Date(new Date() - 0 + n * 60000);
    var seperator = "-";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();

    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }

    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }

    if (hours >= 0 && hours <= 9) {
        hours = "0" + hours;
    }

    if (minutes >= 0 && minutes <= 9) {
        minutes = "0" + minutes;
    }

    if (seconds >= 0 && seconds <= 9) {
        seconds = "0" + seconds;
    }
    var currentdate = date.getFullYear() + seperator + month + seperator + strDate + " " + hours + ":" + minutes + ":" + seconds;
    return currentdate;
}