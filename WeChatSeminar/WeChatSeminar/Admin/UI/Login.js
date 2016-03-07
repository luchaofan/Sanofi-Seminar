$(document).ready(function () {
    $(".tr2 input[type=button]").click(function () {
        btnLogin_click();
    });

    $(".tr2 span a").click(function () {
        btnForget_click();
    });
});
function btnLogin_click() {
    var username = $(".tr2 input[type=text]").val();
    if (username == "") {
        alert("请输入用户名");
        return;
    }
    var password = $(".tr2 input[type=password]").val();
    if (password == "") {
        alert("请输入密码");
        return;
    }
    $.ajax({
        url: "../MeetingService.asmx/Login",
        type: "post",
        data: { UserName: username, Password: password },
        success: function (msg) {
            console.log(msg);
            if (msg !== null) {
                var uid = msg.ID;
                var uname = msg.OpenID;
                location.href = "../Index.html"
            }
            else {
                alert(msg.Message);
            }
        },
        error: function (r) {
            console.log(rresponseText);
        }   
    });
}

function btnForget_click() {
    var username = $(".tr2 input[type=text]").val();
    if (username == "") {
        alert("请输入用户名");
        return;
    }
    if (confirm("确定重置密码？") == true) {
        $.ajax({
            url: "../MeetingService.asmx/ResetPass",
            data: { UserName: username },
            success: function (msg) {
                alert(msg.Message);
            },
            error: function (XMLHttpRequest, gg, errorThrown) {
                console.log(gg);
                console.log(errorThrown);
                alert("系统错误")
            }
        })
    }
    else {
        return;
    }
}