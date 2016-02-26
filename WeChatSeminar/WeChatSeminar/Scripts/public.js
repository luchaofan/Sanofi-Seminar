var user;
function IsExistSession() {
    $.ajax({
        url: "../WebService/WebService.asmx/IsExistSession",
        data: {},
        async: false,
        type: "post",
        success: function (data) {
            console.log(data);
            if (data == null || data.ID <= 0) {
                window.location.href = "../WebSite/MeetInteract.html";
            }
            else {
                user = data;
            }
        },
        error: function (r) {
            console.log(r.responseText);
        }
    });
}
//模拟登录
function Login() {
    $.ajax({
        url: "../WebService/WebService.asmx/Login",
        data: { UserName: 1, Password: 1 },
        async: false,
        type: "post",
        success: function (data) {
            console.log(data);
            if (data.ID > 0) {
                //window.location.href = "index.html";
                user = data;
                console.log("登录成功！");
            }
            else {
                layer.msg('用户名或者密码错误', {
                    icon: 2,
                    time: 1000
                });
            }
        },
        error: function (r) {
            console.log(r.responseText);
        }
    });
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return r[2]; return null;
}
//把json格式的时间转换成yyyy-MM-dd h:m
function ChangeDateFormat(val) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hour = date.getHours();
        var minutes = date.getMinutes();
        var second = date.getSeconds();
        if (hour < 10) {
            hour = "0" + hour;
        }
        if (minutes < 10) {
            minutes = "0" + minutes;
        }
        if (second < 10) {
            second = "0" + second;
        }
        return date.getFullYear() + "-" + month + "-" + currentDate + " " + hour + ":" + minutes;
    }
    return "";
}