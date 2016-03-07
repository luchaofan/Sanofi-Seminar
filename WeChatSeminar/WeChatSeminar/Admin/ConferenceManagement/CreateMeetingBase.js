function getQueryString(name) {
    var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    }
    return null;
}

function timeFormat(dates) {
    var date = new Date(Date.parse(dates.replace(/-/g, "/").replace(/年/g, "/").replace(/月/g, "/").replace(/日/g, "")));
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    var h = date.getHours();
    var min = date.getMinutes();
    var sec = date.getSeconds();
    var time = y + "-" + (m > 9 ? m : "0" + m) + "-" + (d > 9 ? d : "0" + d) + " " + (h > 9 ? h : "0" + h) + ":" + (min > 9 ? min : "0" + min) + ":" + (sec > 9 ? sec : "0" + sec);
    return time;

}

$.ajaxSetup({ async: false });
var mid = getQueryString("mid");
$(document).ready(function () {
    //LoadProducts();
    LoadGrade();
    LoadCity();
    $("#city").focus(function () {
        if ($("#province").combobox("getValue") == "--无--") {
            $.messager.alert("确定", "请先选择省份");
            return;
        }
    });
    if (mid != undefined) {
        LoadPage();
    }
});

function LoadProducts() {
    $.ajax({
        async: false,
        url: "../MeetingService.asmx/LoadProducts",
        data: { type: "meeting" },
        type: "post",
        success: function (msg) {
            // console.log(msg);
            if (msg.Result == "true") {
                //console.log(msg.Message);
                $("#products").combobox({
                    panelHeight: 150,
                    data: msg.Message,
                    textField: "PName",
                    valueField: "Pid",
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function LoadGrade() {
    $("#grade").combobox({
        panelHeight: 90,
        data: [{ "ID": 0, "GradeName": "--无--", "selected": "true" }, { "ID": 1, "GradeName": "全国" }, { "ID": 2, "GradeName": "区域" }, { "ID": 3, "GradeName": "城市" }, { "ID": 4, "GradeName": "内部" }],
        textField: "GradeName",
        valueField: "GradeName"
    });
}

function LoadCity() {
    $.ajax({
        url: "../MeetingService.asmx/GetProvince",
        async: false,
        data: {},
        success: function (data) {
            if (data.Result == "true") {
                $("#province").combobox({
                    panelHeight: 150,
                    width: 100,
                    data: data.Message,
                    textField: "ProvinceName",
                    valueField: "ProvinceName",
                    onSelect: function (record) {
                        $.ajax({
                            url: "../MeetingService.asmx/GetCityByProvince",
                            data: { Province: record.ProvinceName },
                            type: "post",
                            success: function (datas) {
                                console.log(datas);
                                //console.log(datas);
                                //$("#city").combobox({
                                //    data: datas.Message,
                                //    panelHeight: 150,
                                //    width: 100,
                                //    textField: "CityName",
                                //    valueField: "CityName"
                                //});
                                var item = { width: 100, name: "city", textField: "CityName" };
                                bind_Select(item, datas.Message);
                            },
                            error: function (a, b, c) {
                                console.log(b);
                            }
                        });
                    }
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function submints() {
    if ($("#title").val() == "" || $("#title").val() == undefined) {
        $.messager.alert("提示", "请输入会议名称");
        return;
    }
    if ($("#bgTime").datetimebox("getValue") == "" || $("#bgTime").datetimebox("getValue") == undefined) {
        $.messager.alert("提示", "请选择会议开始时间");
        return;
    }
    if ($("#edTime").datetimebox("getValue") == "" || $("#edTime").datetimebox("getValue") == undefined) {
        $.messager.alert("提示", "请选择会议结束时间");
        return;
    }
    //if ($("#products").combobox("getValue") == "100" || $("#products").combobox("getValue") == undefined) {
    //    $.messager.alert("提示", "请选择产品组");
    //    return;
    //}
    if ($("#grade").combobox("getValue") == "0" || $("#grade").combobox("getValue") == undefined) {
        $.messager.alert("提示", "请选择会议等级");
        return;
    }
    if ($("#city").val() == "--无--" || $("#city").val() == "" || $("#city").val() == undefined) {
        $.messager.alert("提示", "请选择城市");
        return;
    }
    if ($("#address").val() == "" || $("#address").val() == undefined) {
        $.messager.alert("提示", "请输入会议地址");
        return;
    }
    if ($("#introduction").val() == "" || $("#introduction").val() == undefined) {
        $.messager.alert("提示", "请输入会议简介");
        return;
    }
    var urls = "../MeetingService.asmx/AddMeeting_1";
    if (mid != undefined) {
        urls = "../MeetingService.asmx/SaveMeetingBase?mid=" + mid;
    }
    $.ajax({
        url: urls,
        type: "post",
        async: false,
        data: $("#forms").serialize(),
        success: function (data) {
            if (data.Result == "true") {
                //location.href = "CreateMeetingInvite.html?mid=" + data.Message + "&type=first";
                location.href = "ConferenceManagement.html";
            }
            else {
                console.log(data.Message);
            }
        },
        error: function (a, b, c) {
            console.log(c);
        }
    });
}

//function bind_Select(item, data) {
//    if ($("#" + item.name + "").html() != "") {
//        $("#" + item.name + "").html("");
//    }
//    var html;
//    var gg = item.textField;
//    $(data).each(function (index, items) {
//        if (items["selected"] == true) {
//            html += "<option  selected='selected'>" + items[gg] + "</option>"
//        }
//        else {
//            html += "<option>" + items[gg] + "</option>"
//        }
//    });
//    $("#" + item.name + "").append(html);
//}

function bind_Select(item, data) {
    if ($("#" + item.name + "").html() != "") {
        $("#" + item.name + "").html("");
    }
    var html = "";
    var gg = item.textField;
    console.log(data);
    $(data).each(function (index, items) {
        if (items["selected"] == true) {
            html += "<option value='" + items[gg] + "' selected='selected'>" + items[gg] + "</option>"
        }
        else {
            html += "<option value='" + items[gg] + "'>" + items[gg] + "</option>"
        }
    });
    $("#" + (item.name) + "").append(html);
}

function LoadPage() {
    $.ajax({
        url: "../MeetingService.asmx/GetMeetingBaseInfo_T",
        async: false,
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            console.log(data);
            if (data.Result == "true") {
                $.parser.parse($(".Content"));
                $("#title").val(data.Message.mtitle);
                $("#bgTime").datetimebox("setValue", timeFormat(data.Message.mbegintime));
                $("#edTime").datetimebox("setValue", timeFormat(data.Message.mendtime));
                $("#city").focus(function () {
                    if ($("#province").combobox("getValue") == "--无--") {
                        $.messager.alert("确定", "请先选择省份");
                        return;
                    }
                });
                //$("#products").combobox("setValue", data.Message.Product);
                $("#grade").combobox("setValue", data.Message.mgrade);
                $.post(
                    "../MeetingService.asmx/GetProvinceByCity",
                    { city: data.Message.mregion },
                    function (data2) {
                        console.log(data2);
                        if (data2.Result == "true") {
                            $("#province").combobox("select", data2.Message);
                            var _select = document.getElementById('city');
                            console.log($(_select).find("option[value='" + data.Message.mregion + "']"));
                            $(_select).find("option[value='" + data.Message.mregion + "']").attr("selected", "true");
                        }
                    }
                    );
                $("#address").val(data.Message.msite);
                $("#introduction").val(data.Message.mcontent);
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}
