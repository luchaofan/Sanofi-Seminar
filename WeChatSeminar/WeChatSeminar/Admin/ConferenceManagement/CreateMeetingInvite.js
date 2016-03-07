function getQueryString(name) {
    var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    }
    return null;
}

var formData = new FormData();
var mid = getQueryString("mid");
var _type = getQueryString("type");
var number = 0;
$(document).ready(function () {
    number = 0;
    formData = new FormData();
    $.ajax({
        url: "../MeetingService.asmx/GetInvitionByMid",
        async: false,
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            if (data.Result == "true") {
                $(data.Message).each(function (index, element) {
                    var htmls = "<div style='width:150px;height:100%;margin-left:20px;float:left;border:1px solid silver;'>" +
                                "<div style='width:100%;height:30px;text-align:center;font-size:12px;border:1px solid silver;'>" +
                                "<a onclick='deleteInvitePic(this," + element.BID + ")'><img src='../Images/Con_MeetDelete.png' /></a></div>" +
                                "<div style='width:100%;height:80%;'><img src='" + element.URL + "' style='width:150px;' /></div></div>";
                    $("#div_ReView").append(htmls);
                });
                $.parser.parse($("#div_ReView"));
                _type = undefined;
            }
        }
    });
    $("#files").change(function () {
        var fiel = this.files[0];
        var res = 0;
        $("input[type=hidden]").each(function (index, element) {
            if (fiel.name == $(element).val()) {
                res = 1;
                return;
            };
        });
        if (res == 1) {
            return;
        }
        formData.append("files", fiel);
        preView(fiel);
    });

    $("#button").click(function () {
        if ($("#div_ReView").children().length == 0) {
            $.messager.alert("提示", "邀请函不能为空");
            return
        }
        var url = "../MeetingService.asmx/AddMeeting_2?mid=" + mid;
        if (_type == undefined)
        {
            var bid = "";
            $("input[name='invite_delete']").each(function (index, element) {
                if (index == 0) {
                    bid += $(element).val();
                }
                else {
                    bid += "," + $(element).val();
                }
            });
            url = "../MeetingService.asmx/SaveInvitionInfo?mid=" + mid + "&bid=" + bid;
        }
        $("input[type=hidden]").each(function (index, element) {
            formData.append("hidden"+index, $(element).val());
        });
        $.ajax({
            url: url,
            type: "post",
            data: formData,
            /**   
          * 必须false才会避开jQuery对 formdata 的默认处理   
          * XMLHttpRequest会对 formdata 进行正确的处理   
          */
            processData: false,
            /**   
             *必须false才会自动加上正确的Content-Type   
             */
            contentType: false,
            success: function (data) {
                if (data.Result == "true") {
                    location.href = "../ConferenceManagement/CreateMeetingBanner.html?mid=" + mid+"&type=first";
                }
                else {
                    console.log(data.Message);
                }
            },
            error: function (a, b, c) {
                console.log(b);
            }
        });
    });

    $("#last").click(function () {
        location.href = "CreateMeetingBase.html?mid=" + mid;
    });
});

//本地图片预览
function preView(file) {
    var url;
    var reader = new FileReader()
    reader.readAsDataURL(file);
    reader.onload = function (e) {
        url = e.target.result;
        var html = "<div style='width:150px;height:255px;margin-left:20px;float:left;border:1px solid silver;'><div style='width:100%;height:30px;text-align:center;font-size:12px;border:1px solid silver;'>" + file.name + "<a onclick='deletePic(this)'><img src='../Images/Con_MeetDelete.png' /></a></div><div style='width:100%;height:225px;'><img src='" + url + "' style='width:150px;height:225px;' /><input type='hidden' name='hidden' value='" + number + "' /></div></div>";
        $("#div_ReView").append(html);
        number = number + 1;
    };
}

function deletePic(e) {
    $.messager.confirm("提示", "确定删除吗？", function (r) {
        if (r) {
            $(e).parent().parent().remove();
        }
        else {
            return;
        }
    });
     
}
