<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteResultPage.aspx.cs" Inherits="WeChatSeminar.MinAdmin.VoteResultPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投票结果</title>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return r[2]; return null;
        }
        function getBrowserInfo() {
            var agent = navigator.userAgent.toLowerCase();

            var regStr_ie = /msie [\d.]+;/gi;
            var regStr_ff = /firefox\/[\d.]+/gi
            var regStr_chrome = /chrome\/[\d.]+/gi;
            var regStr_saf = /safari\/[\d.]+/gi;
            //IE
            if (agent.indexOf("msie") > 0) {
                return agent.match(regStr_ie);
            }

            //firefox
            if (agent.indexOf("firefox") > 0) {
                return agent.match(regStr_ff);
            }

            //Chrome
            if (agent.indexOf("chrome") > 0) {
                return agent.match(regStr_chrome);
            }

            //Safari
            if (agent.indexOf("safari") > 0 && agent.indexOf("chrome") < 0) {
                return agent.match(regStr_saf);
            }

        }
        var vidlist = location.href.split('?')[1].split('=')[1].split(',');
        var _cHeight = 22;
        $(function () {
            if (getBrowserInfo()[0].indexOf("chrome") != -1) {
                _cHeight = 16;
            }
            QueryVote();
            Load();
        });


        //查询投票开启状态
        function QueryVote() {
            var vid = vidlist[0];
            $.ajax({
                type: "post",
                data: { vid: vid },
                url: "../WebService/WebService.asmx/VoteByVid",
                async: false,
                success: function (r) {
                    var bool = r.vstate;
                    if (bool) {
                        //设置倒计时
                        ds = 30;
                        //lzx = setInterval('djs()', 1000);
                        $("#next").hide();
                    }
                    else {
                        if (vidlist.length > 0) {
                            $("#next").show();
                            $("#next").click(function () {
                                location.href = "VoteResultPage.aspx?vidlist=" + vidlist + "";
                            });
                        }
                    }
                },
                error: function (r) {
                    console.log(r.responseText);
                }
            });
        }
        var ds;
        //30秒倒计时
        function djs() {
            $("#ds").html(ds);
            if (ds == 0) {
                //清楚定时器
                clearInterval(lzx);
                clearInterval(lcf);
                //关闭投票
                //guanbi();
            }
            ds = ds - 1;


        }

        //30秒钟之后关闭投票
        function guanbi() {
            var vid = vidlist[0];
            $.ajax({
                type: "post",
                contentType: "application/json",
                dataType: 'json',
                data: "{vid:" + vid + "}",
                url: "../WebService/WebService.asmx/GuanBi",
                async: false,
                success: function (r) {
                    var num = r.d;
                    delete vidlist[0];
                    if (num != 0) {
                        alert("投票已关闭");
                        vidlist.shift();
                        if (vidlist.length > 0) {
                            $("#next").show();
                            $("#next").click(function () {
                                location.href = "VoteResultPage.aspx?vidlist=" + vidlist + "";
                            });
                        }
                    }
                },
                error: function (r) {
                    alert(r.responseText);
                }
            });
        }

        function Load() {
            var vid = vidlist[0];
            console.log(vid);
            var zm = new Array("A", "B", "C", "D", "E");
            $.ajax({
                type: "post",
                data: { vid: vid },
                url: "../WebService/WebService.asmx/VoteByVid",
                async: true,
                success: function (r) {
                    var list = r;
                    //总人数  
                    // var mun = list.length - 1;
                    if (list != null) {
                        $(list).each(function (k, e) {
                            $(".title").html("投票题" + "&nbsp;&nbsp;" + (e.vtype == "0" ? "（单选）" : "（多选）"));
                            $(".content").html(e.vtopic.length > 40 ? e.vtopic.substring(0, 40) + "..." : e.vtopic);
                            $(".content").attr("title", e.vtopic);
                            if (k == 0) {
                                //分割答案字符串
                                var strs = e.vanswer.split("|");
                                for (var i = 0; i < strs.length; i++) {
                                    //计算百分比 数量/总数*100
                                    //统计不同选择结果的人数  
                                    var s = count(e.vid, $.trim(strs[i]));
                                    $parent_Imgdiv = $("<div>").addClass("parent_Imgdiv");
                                    $img_div = $("<div>").addClass("img_div" + (i + 1)).attr({ "id": "i" + i, "width": "150" })
                                        .animate({ "height": _cHeight }, 2000, function () {

                                        });
                                    $img_div.html("<p class='spa" + i + "' style='display:none; width:150px; margin:0;background:#fff;font-weight:bold; position: relative; top:0px;'>"
                                     + 0 + (e.vtype == "0" ? "%" : "") + "</p>");
                                    if ($img_div.children().html() == "NaN%") {
                                        $img_div.children().html("0" + (e.vtype == "0" ? "%" : ""));
                                    }
                                    var dn = $.trim(strs[i]);
                                    if (dn.length > 45) {
                                        dn = dn.substring(0, 45) + "...";
                                    }
                                    $span = $("<span>").attr("id", "span" + i).html("<br/>(" + zm[i] + ") " + dn).css("text-align", "center");
                                    $(".font").append($span);
                                    $parent_Imgdiv.append($img_div);
                                    $(".div").append($parent_Imgdiv);
                                }
                                lcf = setInterval('Load1(' + e.vtype + ')', 2010);
                                $('.spa0').show();
                                $('.spa1').show();
                                $('.spa2').show();
                                $('.spa3').show();
                                $('.spa4').show();

                            }
                        });
                    } else {
                        Load();

                    }
                },
                error: function (r) {
                    alert(r.responseText);
                }
            });

        }

        function Load1(type) {
            var vid = vidlist[0];
            var zm = new Array("A", "B", "C", "D", "E");
            $.ajax({
                type: "post",
                data: { vid: +vid },
                url: "../WebService/WebService.asmx/VoteResultByVid",
                async: true,
                success: function (r) {
                    var list = r;
                    console.log(r);
                    if (list != null) {
                        //总票数  
                        var mun = list.length;
                        //总人数
                        var _tNum = _Ncount(list[0].vid);
                        $(list).each(function (k, e) {
                            if (k == 0) {
                                //分割答案字符串
                                var strs = e.vanswer.split("|");
                                for (var i = 0; i < strs.length; i++) {
                                    //统计不同选择结果的人数
                                    var s = count(e.vid, strs[i]);
                                    //单选
                                    if (type == 0) {
                                        var h = (parseInt(s / mun * 100) * 4) + _cHeight;
                                        $("#i" + i).animate({ "height": h }, 300);
                                        var dn = $.trim(strs[i]);
                                        if (dn.length > 45) {
                                            dn = dn.substring(0, 45) + "...";
                                        }
                                        $("#span" + i).html("<br/>(" + zm[i] + ") " + dn).css("text-align", "center");
                                        if (parseInt(s / mun * 100) != 0) {
                                            $('.spa' + i).html(parseInt(s / mun * 100) + "%<a target='_Blank' href='VoteDetailed.aspx?vid=" + e.vid + "&vresult=" + strs[i] + "' >（" + s + "）</a>");
                                        }
                                        if ($('.spa' + i).html() == "NaN%") {
                                            $('.spa' + i).html("0%");
                                        }
                                    }
                                        //多选
                                    else {
                                        var _th = 430;
                                        var h = _th * s / _tNum + _cHeight;
                                        $("#i" + i).animate({ "height": h }, 300);
                                        var dn = $.trim(strs[i]);
                                        if (dn.length > 45) {
                                            dn = dn.substring(0, 45) + "...";
                                        }
                                        $("#span" + i).html("<br/>(" + zm[i] + ") " + dn).css("text-align", "center");
                                        $('.spa' + i).html("<a target='_Blank' href='VoteDetailed.aspx?vid=" + e.vid + "&vresult=" + strs[i] + "' >（" + s + "）</a>");
                                    }
                                }
                            }
                        });
                    }
                },
                error: function (r) {
                    console.log(r);
                }
            });
        }


        //统计不同选择结果的人数
        function count(vid, vresult) {
            var s;
            $.ajax({
                type: "post",
                data: { vid: vid, vresult: $.trim(vresult) },
                url: "../WebService/WebService.asmx/VoteResultCount",
                async: false,
                success: function (r) {
                    s = r;
                },
                error: function (r) {
                    console.log(r.responseText);
                }

            });
            return s;
        }

        //统计不同选择结果的人数
        function _Ncount(vid) {
            var s;
            $.ajax({
                type: "post",
                data: { vid: vid },
                url: "../WebService/WebService.asmx/_NCount",
                async: false,
                success: function (r) {
                    s = r;
                },
                error: function (r) {
                    console.log(r.responseText);
                }

            });
            return s;
        }
    </script>
    <style type="text/css">
        * {
            font-family: 微软雅黑;
        }

        body {
            margin: 0px;
            padding: 0px;
        }

        .top {
            width: 1024px;
            margin: 0px auto;
            height: 98px;
            background-image: url('image/hengla.png');
            position: relative;
        }

        .top_logo {
            width: 277px;
            height: 21px;
            /*background-image: url('image/logo.png');*/
            background-repeat: no-repeat;
            position: absolute;
            left: 720px;
            top: 30px;
        }

        .include {
            margin: 0px auto;
            margin-top: 0px;
            width: 1022px;
            height: 650px;
            border: 1px #cccccc solid;
            position: relative;
        }

        .div {
            position: absolute;
            left: 25px;
            bottom: 90px;
            width: 95%;
            height: 550px;
            border-left: 2px #808080 solid;
            border-bottom: 2px #808080 solid;
        }

        .title {
            position: absolute;
            left: 25px;
            width: 977px;
            height: 50px;
            margin-top: 5px;
            font-size: 24px;
            line-height: 50px;
            background-image: url('image/hengla.png');
            text-indent: 10px;
        }

        .content {
            z-index: 100;
            position: absolute;
            left: 25px;
            top: 50px;
            width: 977px;
            height: 50px;
            margin-top: 5px;
            font-size: 22px;
            line-height: 50px;
            overflow: hidden;
            text-indent: 1em;
        }

        .parent_Imgdiv {
            float: left;
            text-align: center;
        }



        .img_div1 {
            width: 150px;
            background-color: #69b3ee;
            position: absolute;
            bottom: 0px;
            left: 5px;
        }

        .img_div2 {
            width: 150px;
            background-color: #ee6969;
            position: absolute;
            bottom: 0px;
            left: 200px;
        }

        .img_div3 {
            width: 150px;
            background-color: #eee369;
            position: absolute;
            bottom: 0px;
            left: 400px;
        }

        .img_div4 {
            width: 150px;
            background-color: #d069ee;
            position: absolute;
            bottom: 0px;
            left: 600px;
        }

        .img_div5 {
            width: 150px;
            background-color: #69ee82;
            position: absolute;
            bottom: 0px;
            left: 800px;
        }

        #span0 {
            font-size: 14px;
            width: 150px;
            position: absolute;
            bottom: 0px;
            left: 0px;
        }

        #span1 {
            font-size: 14px;
            width: 150px;
            position: absolute;
            bottom: 0px;
            left: 200px;
        }

        #span2 {
            font-size: 14px;
            width: 150px;
            position: absolute;
            bottom: 0px;
            left: 400px;
        }

        #span3 {
            font-size: 14px;
            width: 150px;
            position: absolute;
            bottom: 0px;
            left: 600px;
        }

        #span4 {
            font-size: 14px;
            width: 150px;
            position: absolute;
            bottom: 0px;
            left: 800px;
        }

        .font {
            margin: 0px auto;
            margin-top: 0px;
            width: 977px;
            height: 40px;
            position: relative;
            top: -45px;
        }

        .fanhui {
            margin: 0px auto;
            margin-top: 0px;
            width: 1024px;
            height: 40px;
            position: absolute;
            top: 30px;
            left: 35px;
            display: none;
        }

        #ds {
            color: red;
            font-size: 20px;
            font-weight: bold;
            position: absolute;
            top: 90px;
            right: 30px;
            z-index: 3;
        }

        a {
            color: #2c850d;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            <div class="top_logo">
                <input type="button" value="下一题" id="next" style="float: right;" />
                <div id="ds">
                </div>
            </div>
            <div class="fanhui">
                <img onclick="img_click();" src="image/fanhui.png" style="cursor: pointer;" />
            </div>
        </div>
        <div class="include">
            <div class="title">
                投票题
            </div>
            <div class="content">
            </div>
            <div class="div">
            </div>
        </div>
        <div class="font">
        </div>
    </form>
</body>
</html>
