function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return r[2]; return null;
}
var mid = GetQueryString('mid');
var formData = new FormData();
$.ajaxSetup({ async: false });
var number = 0;
var url1 = "../Images/Meet_Detail_Info1.png";
var url2 = "../Images/Meet_Detail_Info2.png";
var url3 = "../Images/Meet_Detail_Invite1.png";
var url4 = "../Images/Meet_Detail_Invite2.png";
var url5 = "../Images/Meet_Detail_Position1.png";
var url6 = "../Images/Meet_Detail_Position2.png";
var url7 = "../Images/Meet_Detail_HYRC1.png";
var url8 = "../Images/Meet_Detail_HYRC2.png";
var url9 = "../Images/Meet_Detail_Banner1.png";
var url10 = "../Images/Meet_Detail_Banner2.png";
var url11 = "../Images/Meet_Detail_Data1.png";
var url12 = "../Images/Meet_Detail_Data2.png";
//var url13 = "../Images/Meet_Detail_Interact1.png";
//var url14 = "../Images/Meet_Detail_Interact2.png";
var url15 = "../Images/Meet_Detail_ErCode1.png";
var url16 = "../Images/Meet_Detail_ErCode2.png";
$(document).ready(function () {
    PageLoad();

    $("#button1").click(function () {
        if ($(this).children("img:eq(0)").attr("src") == url1) {
            $(this).children("img:eq(0)").attr("src", url2);
            $("#button2").children("img:eq(0)").attr("src", url3);
            $("#button3").children("img:eq(0)").attr("src", url5);
            $("#button4").children("img:eq(0)").attr("src", url7);
            $("#button5").children("img:eq(0)").attr("src", url9);
            $("#button6").children("img:eq(0)").attr("src", url11);
            // $("#button7").children("img:eq(0)").attr("src", url13);
            $("#button8").children("img:eq(0)").attr("src", url15);
            btn1_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url1);
            $(".Content").empty();
        }
    });

    $("#button2").click(function () {

        if ($(this).children("img:eq(0)").attr("src") == url3) {
            $(this).children("img:eq(0)").attr("src", url4);
            $("#button1").children("img:eq(0)").attr("src", url1);
            $("#button3").children("img:eq(0)").attr("src", url5);
            $("#button4").children("img:eq(0)").attr("src", url7);
            $("#button5").children("img:eq(0)").attr("src", url9);
            $("#button6").children("img:eq(0)").attr("src", url11);
            //$("#button7").children("img:eq(0)").attr("src", url13);
            $("#button8").children("img:eq(0)").attr("src", url15);
            btn2_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url3);
        }
    });

    $("#button3").click(function () {

        if ($(this).children("img:eq(0)").attr("src") == url5) {
            $(this).children("img:eq(0)").attr("src", url6);
            $("#button1").children("img:eq(0)").attr("src", url1);
            $("#button2").children("img:eq(0)").attr("src", url3);
            $("#button4").children("img:eq(0)").attr("src", url7);
            $("#button5").children("img:eq(0)").attr("src", url9);
            $("#button6").children("img:eq(0)").attr("src", url11);
            // $("#button7").children("img:eq(0)").attr("src", url13);
            $("#button8").children("img:eq(0)").attr("src", url15);
            btn3_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url5);
        }
    });

    $("#button4").click(function () {

        if ($(this).children("img:eq(0)").attr("src") == url7) {
            $(this).children("img:eq(0)").attr("src", url8);
            $("#button1").children("img:eq(0)").attr("src", url1);
            $("#button2").children("img:eq(0)").attr("src", url3);
            $("#button3").children("img:eq(0)").attr("src", url5);
            $("#button5").children("img:eq(0)").attr("src", url9);
            $("#button6").children("img:eq(0)").attr("src", url11);
            // $("#button7").children("img:eq(0)").attr("src", url13);
            $("#button8").children("img:eq(0)").attr("src", url15);
            btn4_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url7);
        }
    });

    $("#button5").click(function () {

        if ($(this).children("img:eq(0)").attr("src") == url9) {
            $(this).children("img:eq(0)").attr("src", url10);
            $("#button1").children("img:eq(0)").attr("src", url1);
            $("#button2").children("img:eq(0)").attr("src", url3);
            $("#button3").children("img:eq(0)").attr("src", url5);
            $("#button4").children("img:eq(0)").attr("src", url7);
            $("#button6").children("img:eq(0)").attr("src", url11);
            // $("#button7").children("img:eq(0)").attr("src", url13);
            $("#button8").children("img:eq(0)").attr("src", url15);
            bun5_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url9);
        }
    });

    $("#button6").click(function () {

        if ($(this).children("img:eq(0)").attr("src") == url11) {
            $(this).children("img:eq(0)").attr("src", url12);
            $("#button1").children("img:eq(0)").attr("src", url1);
            $("#button2").children("img:eq(0)").attr("src", url3);
            $("#button3").children("img:eq(0)").attr("src", url5);
            $("#button4").children("img:eq(0)").attr("src", url7);
            $("#button5").children("img:eq(0)").attr("src", url9);
            $("#button8").children("img:eq(0)").attr("src", url15);
            btn6_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url11);
        }
    });

    $("#button8").click(function () {

        if ($(this).children("img:eq(0)").attr("src") == url15) {
            $(this).children("img:eq(0)").attr("src", url16);
            $("#button1").children("img:eq(0)").attr("src", url1);
            $("#button2").children("img:eq(0)").attr("src", url3);
            $("#button3").children("img:eq(0)").attr("src", url5);
            $("#button4").children("img:eq(0)").attr("src", url7);
            $("#button5").children("img:eq(0)").attr("src", url9);
            $("#button6").children("img:eq(0)").attr("src", url11);
            btn8_click();
        }
        else {
            $(this).children("img:eq(0)").attr("src", url15);
        }
    });
});

function PageLoad() {
    $.ajax({
        url: "../MeetingService.asmx/GetMeetingBaseInfo_T",
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            console.log(data);
            if (data.Result == "true") {
                $("#title").text(data.Message.mtitle);
                $(".beginTime").text("开始时间：" + data.Message.mbegintime);
                $(".endTime").text("结束时间：" + data.Message.mendtime);
                $(".city").text("城市：" + data.Message.mregion);
                $("#button1 img:eq(0)").attr("src", url2);
                $("#button2").children("img:eq(0)").attr("src", url3);
                $("#button3").children("img:eq(0)").attr("src", url5);
                $("#button4").children("img:eq(0)").attr("src", url7);
                $("#button5").children("img:eq(0)").attr("src", url9);
                $("#button6").children("img:eq(0)").attr("src", url11);
                $("#button8").children("img:eq(0)").attr("src", url15);
                btn1_click();
            }
            if (GetQueryString('qrCode') == "1") {
                $("#button1").children("img:eq(0)").attr("src", url1);
                $("#button2").children("img:eq(0)").attr("src", url3);
                $("#button3").children("img:eq(0)").attr("src", url5);
                $("#button4").children("img:eq(0)").attr("src", url7);
                $("#button5").children("img:eq(0)").attr("src", url9);
                $("#button6").children("img:eq(0)").attr("src", url11);
                $("#button8").children("img:eq(0)").attr("src", url16);
                btn8_click();
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function btn1_click() {
    $(".Content").empty();
    $.ajax({
        url: "../MeetingService.asmx/GetMeetingBaseInfo_T",
        async: false,
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            if (data.Result == "true") {
                $.get("Div/MeetingBaseInfo.html", function (datas) {
                    // console.log(datas);
                    var html = datas;
                    $(".Content").append(html);
                    $.parser.parse($(".Content"));
                    $("#titles").val(data.Message.mtitle);
                    $("#bgTime").datetimebox("setValue", timeFormat(data.Message.mbegintime));
                    $("#edTime").datetimebox("setValue", timeFormat(data.Message.mendtime));
                    //LoadProducts();
                    LoadGrade();
                    LoadCity();
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
                            if (data2.Result == "true") {
                                $("#province").combobox("select", data2.Message);
                                var _select = document.getElementById('city');
                                console.log($(_select).find('option'));
                                $(_select).find("option[value='" + data.Message.mregion + "']").attr("selected", "true");
                            }
                        }
                        );
                    $("#address").val(data.Message.msite);
                    $("#introduction").val(data.Message.mcontent);
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function LoadProducts() {
    $.ajax({
        async: false,
        url: "../MeetingService.asmx/LoadProducts",
        data: { type: "meeting" },
        type: "post",
        success: function (msg) {
            if (msg.Result == "true") {
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
        data: [{ "ID": 0, "GradeName": "--无--", "selected": "true" }, { "ID": 1, "GradeName": "全国" }, { "ID": 2, "GradeName": "区域" }, { "ID": 3, "GradeName": "城市" }],
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
            console.log(data);
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

function submints(type) {
    switch (type) {
        case 1:
            if ($("#titles").val() == "" || $("#titles").val() == undefined) {
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
            //if ($("#products").combobox("getValue") == "0" || $("#products").combobox("getValue") == undefined) {
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
            $.ajax({
                url: "../MeetingService.asmx/SaveMeetingBase?mid=" + mid,
                type: "post",
                async: false,
                data: $("#forms").serialize(),
                success: function (data) {
                    if (data.Result == "true") {
                        // $.messager.alert("提示", "保存成功");
                        location.href = location.href;
                    }
                    else {
                        console.log(data.Message);
                    }
                },
                error: function (a, b, c) {
                    console.log(c);
                }
            });
            break;
        case 2:
            if ($("#div_ReView").children().length == 0) {
                $.messager.alert("提示", "邀请函不能为空,无法保存");
                location.href = location.href;
            }
            else {
                var bid = "";
                $("input[name='invite_delete']").each(function (index, element) {
                    if (index == 0) {
                        bid += $(element).val();
                    }
                    else {
                        bid += "," + $(element).val();
                    }
                });
                $("input[type=hidden]").each(function (index, element) {
                    formData.append("hidden" + index, $(element).val());
                });
                $.ajax({
                    url: "../MeetingService.asmx/SaveInvitionInfo?mid=" + mid + "&bid=" + bid,
                    data: formData,
                    processData: false,
                    contentType: false,
                    type: "post",
                    success: function (data) {
                        if (data.Result == "true") {
                            // $.messager.alert("提示", "保存成功");
                            location.href = location.href;
                        }
                        else {
                            console.log(data.Message);
                        }
                    },
                    errror: function (a, b, c) {
                        console.log(b);
                    }
                });
            }
            break;
        case 3:
            if ($("#longitude").val() == "" || $("#latitude").val() == "") {
                $.messager.alert("提示", "请在地图上标记位置");
                return;
            }
            formData.append("position", $("#position").val());
            formData.append("longitude", $("#longitude").val());
            formData.append("latitude", $("#latitude").val());
            $.ajax({
                url: "../MeetingService.asmx/SavePositionInfo?mid=" + mid,
                type: "post",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.Result == "true") {
                        location.href = location.href;
                    }
                    else {
                        console.log(data.Message);
                    }
                },
                error: function (a, b, c) {
                    console.log(b);
                }
            });
            break;
        case 4:
            $.ajax({
                url: "../MeetingService.asmx/AddMeeting_5?mid=" + mid,
                type: "post",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.Result == "true") {
                        location.href = location.href;
                    }
                    else {
                        console.log(data.Message);
                    }
                },
                error: function (a, b, c) {
                    console.log(b);
                }
            });
            break;
        case 5:
            var file1 = document.getElementById("file_MyMeeting").files[0];
            formData.append("file_MyMeeting", file1);
            var file2 = document.getElementById("file_MeetingSport").files[0];
            formData.append("file_MeetingSport", file2);
            var file3 = document.getElementById("SportInteract").files[0];
            formData.append("SportInteract", file3);
            $.ajax({
                url: "../MeetingService.asmx/AddMeeting_3?mid=" + mid,
                type: "post",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.Result == "true") {
                        location.href = location.href;
                    }
                    else {
                        console.log(data.Message);
                    }
                },
                error: function (a, b, c) {
                    console.log(b);
                }
            });
            break;
        case 6:
            var length = $("#dataList").children().length;
            if (length == 0) {
                $.messager.confirm("提示", "资料为空了，确认保存吗？", function (r) {
                    if (r) {

                    }
                    else {
                        return;
                    }
                });
            }
            $.ajax({
                url: "../MeetingService.asmx/AddMeeting_6?mid=" + mid,
                type: "post",
                data:
                    {
                        action: "next"
                    },
                success: function (data) {
                    if (data.Result == "true") {
                        location.href = location.href;
                    }
                    else {
                        console.log(data.Message);
                    }
                },
                error: function (a, b, c) {
                    console.log(b);
                    console.log(c);
                }
            });
            break;
    }
}

function bind_Select(item, data) {
    if ($("#" + item.name + "").html() != "") {
        $("#" + item.name + "").html("");
    }
    var html = "";
    var gg = item.textField;
    $(data).each(function (index, items) {
        if (items["selected"] == true) {
            html += "<option value='" + items[gg] + "' selected='selected'>" + items[gg] + "</option>"
        }
        else {
            html += "<option value='" + items[gg] + "'>" + items[gg] + "</option>"
        }
    });
    $("#" + (item.name) + "").append(html);
    $.parser.parse($("#" + (item.name) + ""));
    // console.log($("#" + (item.name) + "").html());
}

function btn2_click() {
    number = 0;
    formData = new FormData();
    $(".Content").empty();
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
                $.get("Div/MeetingInvitionInfo.html", function (datas) {
                    var html = datas;
                    $(".Content").append(html);
                    $.parser.parse($(".Content"));
                    $(data.Message).each(function (index, element) {
                        var htmls = "<div style='width:150px;height:100%;margin-left:20px;float:left;border:1px solid silver;'>" +
                                    "<div style='width:100%;height:30px;text-align:center;font-size:12px;border:1px solid silver;'>" +
                                    "<a onclick='deleteInvitePic(this," + element.BID + ")'><img src='../Images/Con_MeetDelete.png' /></a></div>" +
                                    "<div style='width:100%;height:80%;'><img src='" + element.URL + "' style='width:150px;' /></div></div>";
                        $("#div_ReView").append(htmls);
                    });
                    $.parser.parse($("#div_ReView"));
                    $("#files").change(function () {
                        var file = this.files[0];
                        var res = 0;
                        console.log(file.name);
                        $("input[type=hidden]").each(function (index, element) {
                            if (file.name == $(element).val()) {
                                res = 1;
                                return;
                            };
                        });
                        if (res == 1) {
                            return;
                        }
                        var url;
                        var reader = new FileReader()
                        reader.readAsDataURL(file);
                        reader.onload = function (e) {
                            url = e.target.result;
                            var html = "<div style='width:150px;height:255px;margin-left:20px;float:left;border:1px solid silver;'><div style='width:100%;height:30px;text-align:center;font-size:12px;border:1px solid silver;'>" + file.name + "<a onclick='deleteInvitePic(this,0)'><img src='../Images/Con_MeetDelete.png' /></a></div><div style='width:100%;height:225px;'><img src='" + url + "' style='width:150px;height:225px;' /><input type='hidden' name='hidden' value='" + number + "' /></div></div>";
                            $("#div_ReView").append(html);
                            $.parser.parse($("#div_ReView"));
                            number = number + 1;
                            formData.append("file", file);
                        };
                    });
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function deleteInvitePic(e, bid) {
    $.messager.confirm("提示", "确定删除吗？", function (r) {
        if (r) {
            if (bid != 0) {
                var htm = "<input type='hiddden' name='invite_delete' value='" + bid + "' />";
                $(".Content").append(htm);
                $.parser.parse($(".Content"));
            }
            console.log(e);
            $(e).parent().parent().remove();
        }
        else {
            return;
        }
    });
}
var _City = "";
var longitude;
var latitude;
var map;
function btn3_click() {
    $(".Content").empty();
    formData = new FormData();
    $.ajax({
        url: "../MeetingService.asmx/GetPositionByMid",
        async: false,
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            console.log(data);
            if (data.Result == "true") {
                $.get("Div/MeetingPositionInfo.html", function (datas) {
                    var html = datas;
                    $(".Content").append(html);
                    $.parser.parse($(".Content"));
                    //var html = "<div style='width:100%;height:100%; text-align:center;'><img src='" + data.Message.url + "'  style='width:100%;height:100%;'  /></div>";
                    //$("#div_Img").append(html);
                    _City = data.Message.city;
                    if (_City != null && _City != "") {
                        $('#city').html("当前定位城市：" + _City);
                        initMap();
                        var longitude = data.Message.url.substring(0, data.Message.url.indexOf("^"));
                        var latitude = data.Message.url.substring(data.Message.url.indexOf("^") + 1)
                        $("#longitude").val(longitude);
                        $("#latitude").val(latitude);
                        theLocation();
                    }
                    else {
                        $('#city').html("为获取到城市信息").css("color", "red");
                    }
                    $("#position").val(data.Message.address);
                    //                            $("#files").change(function () {
                    //                                var file = this.files[0];
                    //                                var url;
                    //                                var reader = new FileReader()
                    //                                reader.readAsDataURL(file);
                    //                                reader.onload = function (e) {
                    //                                    formData = new FormData();
                    //                                    url = e.target.result;
                    //                                    $("#div_Img").empty();
                    //                                    var html = "<div style='width:100%;height:100%; text-align:center;'><img src='" + url + "' style='width:100%;height:100%;'  /></div>";
                    //                                    $("#div_Img").append(html);
                    //                                    $.parser.parse($("#div_Img"));
                    //                                    formData.append("file", file);
                    //                                };
                    //                            });
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}
function btn4_click() {
    $(".Content").empty();
    formData = new FormData();
    $.ajax({
        url: "../MeetingService.asmx/GetHYRCInfo",
        async: false,
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            console.log(data);
            if (data.Result == "true") {
                $.get("Div/MeetingHYRCIfno.html", function (datas) {
                    console.log(datas);
                    var html = datas;
                    $(".Content").append(html);
                    $.parser.parse($(".Content"));
                    var html = "<div style='width:100%;height:100%; text-align:center;'><img src='" + data.Message + "'  style='width:100%;height:100%;'  /></div>";
                    $("#div_Img").append(html);
                    $("#div_Img").val(data.Message.address);
                    $("#files").change(function () {
                        var file = this.files[0];
                        var url;
                        var reader = new FileReader()
                        reader.readAsDataURL(file);
                        reader.onload = function (e) {
                            formData = new FormData();
                            url = e.target.result;
                            $("#div_Img").empty();
                            var html = "<div style='width:100%;height:100%; text-align:center;'><img src='" + url + "' style='width:100%;height:100%;'  /></div>";
                            $("#div_Img").append(html);
                            $.parser.parse($("#div_Img"));
                            formData.append("file", file);
                        };
                    });
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function bun5_click() {
    $(".Content").empty();
    formData = new FormData();
    $.ajax({
        url: "../MeetingService.asmx/GetBannerInfo",
        async: false,
        data:
            {
                mid: mid
            },
        type: "post",
        success: function (data) {
            console.log(data);
            if (data.Result == "true") {
                $.get("Div/MeetingBanerInfo.html", function (datas) {
                    console.log(datas);
                    var html = datas;
                    $(".Content").append(html);
                    $.parser.parse($(".Content"));
                    var html1 = "<div style='width:90%;height:100%; text-align:center;float:right;margin-right:20px;'><img src='" + data.Message.mymeeting + "' style='width:90%;height:90%;'  /></div>";
                    $(".file_MyMeeting").append(html1);
                    var html2 = "<div style='width:90%;height:100%; text-align:center;float:right;margin-right:20px;'><img src='" + data.Message.meetingsport + "' style='width:90%;height:90%;'  /></div>";
                    $(".file_MeetingSport").append(html2);
                    var html3 = "<div style='width:90%;height:100%; text-align:center;float:right;margin-right:20px;'><img src='" + data.Message.sportinteract + "' style='width:90%;height:90%;'  /></div>";
                    $(".SportInteract").append(html3);
                    $.parser.parse($(".Content"));
                    $("input[name='file_MyMeeting']").change(function () {
                        var file = this.files[0];
                        //formData.append("file_MyMeeting", fiel);
                        preView(file, 'file_MyMeeting');
                    });
                    $("input[name=file_MeetingSport]").change(function () {
                        var file = this.files[0];
                        // formData.append("file_MeetingSport", file);
                        preView(file, 'file_MeetingSport');
                    });
                    $("input[name=SportInteract]").change(function () {
                        var file = this.files[0];
                        //formData.append("SportInteract", file);
                        preView(file, 'SportInteract');
                    });
                });
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
}

function preView(file, name) {
    $("." + name + "").empty();
    var url;
    var reader = new FileReader()
    reader.readAsDataURL(file);
    reader.onload = function (e) {
        url = e.target.result;
        var html = "<div style='width:90%;height:100%; text-align:center;float:right;margin-right:20px;'><img src='" + url + "' name='" + name + "' style='width:90%;height:90%;'  /></div>";
        $("." + name + "").append(html);
    };
}

function btn6_click() {
    $(".Content").empty();
    number = 0;
    formData = new FormData();
    $.ajax({
        url: "../MeetingService.asmx/GetDataInfo",
        type: "post",
        data: { mid: mid },
        success: function (data) {
            $.get("Div/MeetingDataInfo.html", function (datas) {
                console.log(datas);
                var html = datas;
                $(".Content").append(html);
                $.parser.parse($(".Content"));

            });
            if (data.Result == "true") {
                $.each(data.Message, function (index, item) {
                    var html = "<div  style='width:100%;height:10%;font-size:14px;background-color:#f5f5f5;'><input type='hidden' id='types' value='" + item.Type + "' />" +
                               "<div style='width:10%;height:25px;float:left;text-align:center;border-right: 1px solid #eaecf0; border-bottom: 1px solid #eaecf0;background-color:#f2f4f6;'>" + item.Type + "</div>" +
                               "<div style='width:29.7%;height:25px;float:left;text-align:center;border-right: 1px solid #eaecf0; border-bottom: 1px solid #eaecf0;background-color:#f5f5f5;'>" + item.Title + "</div>" +
                               "<div style='width:50%;height:25px;float:left;text-align:center;border-right: 1px solid #eaecf0; border-bottom: 1px solid #eaecf0;background-color:#f5f5f5;'></div>" +
                               "<div style='width:10%;height:25px;float:left;text-align:center;border-bottom: 1px solid #eaecf0;background-color:#f5f5f5;'><div style='width:20px;margin:0px auto;'>" +
                               "<a onclick='DeleteData(this," + item.Did + ")'><img src='../Images/Con_MeetDelete.png' /></a></div></div></div>";
                    $("#dataList").append(html);
                    number++;
                });
                $.parser.parse($("#dataList"));
            }
            $("#titles").focus(function () {
                $("#titles").val("");
            });

            $("#files").click(function () {
                var type = $("#type").val();
                if (type == "Video") {
                    $("#files").attr("accept", "video/MP4");
                }
                if (type == "PDF") {
                    $("#files").attr("accept", "application/pdf");
                }
            });
            $(document).on("change", "#files", function () {
                var formData = new FormData();
                var type = $("#type").val();
                var title = $("#titles").val();
                var file = $("#files").val();
                if (title == "请填写资料标题" || title == undefined || title == "") {
                    $.messager.alert("提示", "请输入资料标题");
                    return;
                }
                $.messager.progress({
                    title: '请稍后,导入数据中...',
                    msg: '请误点击左边导航菜单或关闭网页，以免数据出错！'
                });
                var filepath = $(this).val();
                var extStart = filepath.lastIndexOf(".");
                var ext = filepath.substring(extStart, filepath.length).toUpperCase();
                console.log(ext);
                if (ext != ".MP4" && ext != ".PDF") {
                    $.messager.alert("提示", "导入文件限于mp4,pdf格式");
                    return false;
                }
                else {
                    formData.append("file", $("#files")[0].files[0]);
                    formData.append("action", "fileUp");
                    formData.append("type", type);
                    formData.append("title", title);
                    formData.append("fileIndex", number);
                    $.ajax({
                        url: "../MeetingService.asmx/AddMeeting_6?mid=" + mid,
                        type: "post",
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (data) {
                            $.messager.progress('close');
                            if (data.Result == "false") {
                                return;
                            }
                            var html = "<div  style='width:100%;height:10%;font-size:14px;background-color:#f5f5f5;'><input type='hidden' id='types' value='" + type + "' />" +
                               "<div style='width:10%;height:25px;float:left;text-align:center;border-right: 1px solid #eaecf0; border-bottom: 1px solid #eaecf0;background-color:#f2f4f6;'>" + type + "</div>" +
                               "<div style='width:29.7%;height:25px;float:left;text-align:center;border-right: 1px solid #eaecf0; border-bottom: 1px solid #eaecf0;background-color:#f5f5f5;'>" + title + "</div>" +
                               "<div style='width:50%;height:25px;float:left;text-align:center;border-right: 1px solid #eaecf0; border-bottom: 1px solid #eaecf0;background-color:#f5f5f5;'></div>" +
                               "<div style='width:10%;height:25px;float:left;text-align:center;border-bottom: 1px solid #eaecf0;background-color:#f5f5f5;'><div style='width:20px;margin:0px auto;'>" +
                               "<a onclick='DeleteData(this," + number + ")'><img src='../Images/Con_MeetDelete.png' /></a></div></div></div>";
                            $("#dataList").append(html);
                            number++;
                        },
                        error: function (a, b, c) {
                            console.log(b);
                        }
                    });
                }
                $(this).replaceWith('<input id="files" type="file" name="ExportFile" multiple="multiple" title="'
                                            + Math.random()
                                            + '" accept="video/mp4" style="width: 75px; height: 30px; opacity: 0; filter: alpha(opacity=0);" />');
            });
            //$("#files").change(function () {
            //    var title = $("#titles").val();
            //    console.log(title);
            //    if (title == "请填写资料标题" || title == undefined || title == "") {
            //        $.messager.alert("提示", "请输入资料标题");
            //        return;
            //    }
            //});

            //$("#submit").click(function () {
            //    var formData = new FormData();
            //    var type = $("#type").val();
            //    var title = $("#titles").val();
            //    var file = $("#files").val();
            //    if (title == "请填写资料标题" || title == undefined || title == "") {
            //        $.messager.alert("提示", "请输入资料标题");
            //        return;
            //    }
            //    if (file == "" || file == undefined) {
            //        $.messager.alert("提示", "请选择资料");
            //        return;
            //    }
            //    formData.append("file", $("#files")[0].files[0]);

            //    formData.append("action", "fileUp");
            //    formData.append("type", type);
            //    formData.append("title", title);
            //    formData.append("fileIndex", number);
            //    $.ajax({
            //        url: "../MeetingService.asmx/AddMeeting_6?mid=" + mid,
            //        type: "post",
            //        data: formData,
            //        processData: false,
            //        contentType: false,
            //        success: function (data) {
            //            console.log(data.Message);
            //            if (data.Result == "false") {
            //                return;
            //            }
            //            var html = "<div style='width:100%;height:10%;'><input type='hidden' id='types' value='" + type + "' />" +
            //                       "<span style='width:10%;height:100%;display:inline-block;text-align:center;'>" + type + "</span>" +
            //                       "<span style='width:79%;height:100%;display:inline-block;text-align:center;'>" + title + "</span>" +
            //                       "<span style='width:10%;height:100%;display:inline-block;text-align:center;'><div style='width:20px;margin:0px auto;'>" +
            //                       "<a onclick='DeleteData(this," + number + ")'><img src='../Images/Con_MeetDelete.png' /></a></div></span></div>";
            //            $("#dataList").append(html);
            //            number++;
            //        },
            //        error: function (a, b, c) {
            //            console.log(b);
            //        }
            //    });
            //});
        }
    });
}

function DeleteData(e, index) {
    $.messager.confirm("提示", "您将要删除信息，是否需要删除？", function (r) {
        if (r) {
            var length = $("#dataList").children().length;
            //if (index <= length) {
            var formData = new FormData();
            formData.append("action", "fileDelete");
            formData.append("fileIndex", index);
            $.ajax({
                async: false,
                url: "../MeetingService.asmx/AddMeeting_6?mid=" + mid,
                type: "post",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.Result == "false") {
                        console.log(data.Message);
                        return;
                    }
                    $(e).parent().parent().parent().remove();
                },
                error: function (a, b, c) {
                    console.log(b);
                    console.log(c)
                }
            });
            //}
            //else {
            //$(e).parent().parent().parent().remove();
            //}
        }
    });
}

function btn8_click() {
    $(".Content").empty();
    number = 0;
    formData = new FormData();
    $.ajax({
        url: "../MeetingService.asmx/GetErCode",
        type: "post",
        data: { mid: mid },
        success: function (data) {
            if (data.Result == "true") {
                $.get("Div/MeetingErCodeInfo.html", function (datas) {
                    var html = datas;
                    $(".Content").append(html);
                });
                $.parser.parse($(".Content"));
                $("#invite").attr("src", data.Message.invite);
                $("#signIn").attr("src", data.Message.signIn);
            }
            else {
                console.log(data.Message);
            }
        },
        error: function (a, b, c) {
            console.log(b);
        }
    });
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
    console.log(time);
    return time;

}
