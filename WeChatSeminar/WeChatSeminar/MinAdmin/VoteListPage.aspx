<%@ Page Title="" Language="C#" MasterPageFile="~/MinAdmin/Index.Master" AutoEventWireup="true" CodeBehind="VoteListPage.aspx.cs" Inherits="WeChatSeminar.MinAdmin.VoteListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        body {
            margin: 0px;
            padding: 0px;
        }

        p {
            margin: 0px;
            padding: 0px;
        }

        .font {
            font-size: 20px;
            margin: 10px;
            float: left;
        }

        .insert_btn {
            float: right;
            margin: 10px;
        }

        #clear {
            clear: both;
        }

        .query {
            font-size: 16px;
            margin: 0px auto;
            width: 97%;
            height: 38px;
            line-height: 38px;
            background-image: url('image/chanpinzula.png');
            color: #fff;
            text-align: center;
        }

        .datetime {
            font-size: 14px;
            margin: 0px auto;
            width: 97%;
            height: 38px;
            color: #000;
        }

        .begindatetiem {
            width: 300px;
            float: left;
            height: 38px;
            line-height: 38px;
            text-indent: 15px;
        }

        .enddatetime {
            width: 300px;
            float: left;
            height: 38px;
            line-height: 38px;
        }

        .city {
            width: 250px;
            float: right;
            height: 38px;
            line-height: 38px;
        }

        .content1 {
            width: 97%;
            border: 1px solid #cccccc;
            height: 470px;
            margin: 0px auto;
            overflow-x: hidden;
        }

        .content_top {
            font-size: 14px;
            width: 100%;
            height: 40px;
            line-height: 40px;
            background-color: #F5F5F5;
            border-bottom: 1px solid #cccccc;
        }

        .content_black {
            width: 95%;
            border: 1px solid #cccccc;
            margin: 20px auto;
            padding: 10px;
            font-size: 12px;
            position: relative;
        }

        .content_black_title {
            width: 100%;
        }

        .content_black_dana {
            width: 98%;
            margin-left: 15px;
        }

        .yanshi {
            width: 80px;
            height: 24px;
            background-image: url('image/chakan.png');
            background-repeat: no-repeat;
            position: absolute;
            bottom: 10px;
            right: 35px;
            cursor: pointer;
        }

        .qidong {
            width: 80px;
            height: 24px;
            background-image: url('image/qidong.png');
            background-repeat: no-repeat;
            position: absolute;
            bottom: 10px;
            right: -15px;
            cursor: pointer;
        }

        .qidong_hui {
            width: 80px;
            height: 24px;
            background-image: url('image/qidong_hui.png');
            background-repeat: no-repeat;
            position: absolute;
            bottom: 10px;
            right: -15px;
            cursor: pointer;
        }

        .foot_right {
            width: 887px;
            height: 600px;
        }
    </style>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script src="../Scripts/public.js"></script>
    <script type="text/javascript">
        var vidlist = new Array();
        $(function () {
            Load();
        });
        function Load() {
            var zimu = new Array("A:", "B:", "C:", "D:", "E:");
            var mid = GetQueryString("mid");
            $.ajax({
                type: "post",
                data: { mid: mid },
                url: "../WebService/WebService.asmx/VoteByMid",
                async: false,
                success: function (r) {
                    console.log(r);
                    $(r).each(function (k, e) {
                        //设置投票编号
                        $content_black = $("<div>").addClass("content_black");
                        $content_black_title = $("<div>").addClass("content_black_title");
                        $yanshi = $("<div>").addClass("yanshi");

                        //var $qidong;
                        //if (e.vstate == 1) {
                        //    $qidong = $("<div>").addClass("qidong_hui");
                        //    var isadd = true;
                        //    $.each(vidlist, function (index, item) {
                        //        if (item == e.vid) {
                        //            isadd = false;
                        //        }
                        //    });
                        //    if (isadd) {
                        //        vidlist.push(e.vid);
                        //    }
                        //} else {
                        //    $qidong = $("<div>").addClass("qidong");
                        //    var vid = e.vid;
                        //    $qidong.click(function () {
                        //        $.ajax({
                        //            type: "post",
                        //            contentType: "application/json",
                        //            dataType: 'json',
                        //            data: "{vid:" + vid + "}",
                        //            url: "../WebService1.asmx/UpdateState",
                        //            async: false,
                        //            success: function (p) {
                        //                $(".content1").html("");
                        //                Load();
                        //            },
                        //            error: function (p) {
                        //                alert(r.responseText);
                        //            }
                        //        });
                        //    });
                        //}
                        $yanshi.click(function () {
                            window.location = "VoteHighcharts.html?vidlist=" + e.vid + "";
                        });
                        $content_black_title.html((k + 1) + "." + e.vtopic);
                        $content_black.append($content_black_title);
                        $content_black.append($yanshi);
                        //$content_black.append($qidong);
                        $(".content1").append($content_black);
                        //分割答案字符串
                        var strs = e.vanswer.split("|");
                        for (var i = 0; i < strs.length; i++) {
                            $content_black_dana = $("<div>").addClass("content_black_dana");
                            $content_black_dana.html(zimu[i] + " " + strs[i]);
                            $content_black.append($content_black_dana);

                        }

                    });

                },
                error: function (r) {
                    alert(r.responseText);
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="foot_right">
        <div class="title">
            <div class="font">
                会议互动详情
            </div>
        </div>
        <div id="clear">
        </div>
        <div class="query">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
        <div class="datetime">
            <div class="begindatetiem">
                开始时间:
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </div>
            <div class="enddatetime">
                结束时间:
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            </div>
            <div class="city">
                城市:
                <asp:Literal ID="Literal4" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="content1">
            <div class="content_top">
                现场会议题库
            </div>
        </div>
    </div>
</asp:Content>
