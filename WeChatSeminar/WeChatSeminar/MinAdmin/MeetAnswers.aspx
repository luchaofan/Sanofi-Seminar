<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetAnswers.aspx.cs" Inherits="WeChatSeminar.MinAdmin.MeetAnswers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script src="../Scripts/public.js"></script>
    <title>现场问答</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            color: #6d6464;
        }

        body {
            overflow: hidden;
        }

        .container {
            border: 1px solid rgb(115,1,1);
            width: 100%;
            max-width: 1440px;
            height: 784px;
            margin: 0 auto;
            position: relative;
            background-image: url('image/lcf.jpg');
        }

        #ly {
            margin: 120px auto 0 auto;
            width: 915px;
            height: 564px;
            overflow: hidden;
        }

        .block {
            width: 910px;
            height: 564px;
            margin: 0 auto;
            position: relative;
            top: 0;
        }

        #block {
        }

        ._transition {
            -webkit-transition: all 1.5s ease-in-out;
            -o-transition: all 1.5s ease-in-out 1s;
            -moz-transition: all 1.5s ease-in-out;
            transition: all 1.5s ease-in-out;
        }

        ul li {
            height: 145px;
            background: rgba(255, 255, 255, 0.5);
            border-width: 1px;
            border: 2px solid #fff;
            cursor: pointer;
            margin-bottom: 20px;
            font-size: 64px;
            padding: 10px;
            overflow: hidden;
            text-overflow: ellipsis;
            display: -webkit-box;
            color: #fff;
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
        }

        ._p {
            overflow: hidden;
            text-overflow: ellipsis;
            display: -webkit-box;
            color: #281313;
            -webkit-line-clamp: 1;
            -webkit-box-orient: vertical;
        }

        ._display {
            display: none;
        }

        #show_ly {
            margin: 60px auto 0 auto;
            width: 895px;
            height: 520px;
            padding: 10px 10px;
            overflow: auto;
            background: rgba(255, 255, 255, 0.5);
            border: 1px solid #fff;
            display: none;
            color: #fff;
            position: relative;
            top: -625px;
            font-size: 64px;
        }

        #close {
            width: 50px;
            height: 50px;
            overflow: hidden;
            float: right;
            background: url('image/btn_close_layer.png');
            background-repeat: no-repeat;
            background-position: 10px -0px;
        }

        #A1 {
            border: 2px solid rgba(255, 255, 255,0.8);
            display: block;
            width: 37px;
            height: 37px;
            margin: 0 5px 0 6px;
            border-radius: 21px;
            -webkit-border-radius: 21px;
            -moz-border-radius: 21px;
            background: url('image/defaultConIconsV1.0.png') -3px -5px no-repeat;
            margin: 0 1100px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div id="ly">
        </div>
        <div id="show_ly">
            <a id="close" href="javasrcript:void(0);"></a><span id="content"></span>
        </div>
        <a id="A1" href="javasrcript:void(0);"></a>
    </div>
    <script>
        var _PageIndex = 0;
        var _PageSize = 3;
        var ds_cx;
        var i = 0;
        var time = 3000;
        var one = 0;
        i = 2;
        $(function () {
            GetCommend();
            //setTimeout('g()', 6000);
            ds_gd = setInterval('g()', 6000);
            $("#close").click(function () {
                $("p").addClass("_p");
                $("#show_ly").css("display", "none");
                $("li").removeClass("_display");
                ds_gd = setInterval('g()', 6000);
            });
        });

        function GetCommend() {
            var html = "";
            $.ajax({
                url: "../WebService/WebService.asmx/GetMeetAnswers",
                type: "post",
                async: false,
                data: { mid: GetQueryString("mid"), PageIndex: _PageIndex, PageSize: _PageSize },
                success: function (data) {
                    console.log(data);
                    var length = data.length;
                    $(data).each(function (i, e) {
                        html += " <li  onclick=\"show(this)\"><p style=\"font-size:45px; padding:12px 0;\">" + this.uid + "</p><p class=\"_p\" style='color:#000;'>" + this.content + "</P></li>";
                    });
                    $("#ly").append(" <div class=\"block\">\
                                <ul>\
                                      " + html + "\
                               </ul>\
                               </div>");
                },
                error: function (r) {
                    console.log(r.responseText);
                }
            });
            if (html != "") {
                _PageIndex += _PageSize;
            }
        }


        var ds_gd;
        var _commendlength = 0;
        var datalength = 0;

        function g() {
            console.log(_PageIndex);
            console.log(_PageSize);
            var html = "";
            $.ajax({
                url: "../WebService/WebService.asmx/GetMeetAnswers",
                type: "post",
                async: false,
                data: { mid: GetQueryString("mid"), PageIndex: _PageIndex, PageSize: _PageSize },
                success: function (data) {
                    console.log(data);
                    $(data).each(function (i, e) {
                        _commendlength = i;
                        html += " <li  onclick=\"show(this)\"><p  style=\"font-size:45px; padding:12px 0;\">" + this.uid + "</p><p class=\"_p\" style='color:#000;'>" + this.content + "</P></li>";
                    });
                    if (html != "") {
                        if ($(".block").length > 1) {
                            $(".block").eq(0).css({ "top": "-564px", "display": "block" }).addClass("_transition");
                            $(".block").eq(1).css({ "top": "-564px", "display": "block" }).addClass("_transition");
                            if (($(".block").length) == 2) {
                                setTimeout(function () {
                                    $(".block").eq(0).remove();
                                    $(".block").eq(0).removeClass("_transition").css("top", "0px");
                                    $("#ly").append(" <div class=\"block\">\
                                <ul>\
                                      " + html + "\
                               </ul>\
                               </div>");
                                }, 5800);
                            }
                        } else {
                            if ($("ul li", $(".block").eq(0)).length == 3 && datalength != 1) {
                                $("#ly").append(" <div class=\"block\">\
                                <ul>\
                                      " + html + "\
                               </ul>\
                               </div>");
                            } else {
                                $("ul", $(".block").eq(0)).html("").append(html);
                            }

                        }
                        datalength = 0;
                        _PageIndex += _PageSize;
                    } else {
                        //没有数据了
                        //_PageIndex--;
                        _PageIndex = 0;
                        //datalength = 1; //判断是否有数据  
                        //if ($(".block").length > 1) {
                        //    $(".block").eq(0).css({ "top": "-564px", "display": "block" }).addClass("_transition");
                        //    $(".block").eq(1).css({ "top": "-564px", "display": "block" }).addClass("_transition");
                        //    setTimeout(function () {
                        //        $(".block").eq(0).remove();
                        //        $(".block").eq(0).removeClass("_transition").css("top", "0px");
                        //    }, 5800);
                        //}
                    }
                },
                error: function (r) {
                    console.log(r.responseText);
                }
            });
        }

        function show(obj) {
            $("p").removeClass("_p");
            $("#show_ly").css("display", "block");
            $("li").addClass("_display");
            $("#content").html($(obj).html());
            clearInterval(ds_gd);
        }
        $('#A1').click(function () {
            _PageIndex = 0;
            _PageSize = 3;
        });
    </script>
</body>
</html>

