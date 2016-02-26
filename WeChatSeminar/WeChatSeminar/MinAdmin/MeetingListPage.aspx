<%@ Page Title="" Language="C#" MasterPageFile="~/MinAdmin/Index.Master" AutoEventWireup="true" CodeBehind="MeetingListPage.aspx.cs" Inherits="WeChatSeminar.MinAdmin.MeetingListPage" %>

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
            font-size: 14px;
            margin: 0px auto;
            width: 97%;
            height: 35px;
            line-height: 35px;
            background-color: #69B3EE;
            font-size: 12px;
        }

        .query_btn {
            float: right;
            margin-right: 5px;
        }

        .grid {
            font-size: 14px;
        }

        .GirdViewRow {
            text-overflow: ellipsis;
            overflow: hidden;
            white-space: nowrap;
        }

        .foot_right {
            width: 887px;
            height: 600px;
        }
    </style>
    <script type="text/javascript">
        function startSurvey(mid) {
            $.post(
                "StartSurveyOrTopic.ashx",
                {
                    mid: mid,
                    action: "startSurvey"
                },
                function (msg) {
                    alert(msg);
                    $("input[mid=" + mid + "][state=startSurvey]").hide();
                    $("input[mid=" + mid + "][state=closeSurvey]").show();
                }
                );
        }

        function closeSurvey(mid) {
            $.post(
               "StartSurveyOrTopic.ashx",
                {
                    mid: mid,
                    action: "closeSurvey"
                },
                function (msg) {
                    alert(msg);
                    $("input[mid=" + mid + "][state=startSurvey]").show();
                    $("input[mid=" + mid + "][state=closeSurvey]").hide();
                }
                );
        }

      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="foot_right">
        <div class="title">
            <div class="font">
                会议互动管理
            </div>
        </div>
        <div id="clear">
        </div>
        <div class="query">
            <div class="grid">
                <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="0" ForeColor="#333333"
                    GridLines="None" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True"
                    OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="GirdViewRow" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="mid" HeaderText="编号" ReadOnly="True">
                            <ControlStyle Height="20px" />
                            <HeaderStyle VerticalAlign="Middle" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mbegintime" HeaderText="召开时间">
                            <ControlStyle Height="20px" />
                            <HeaderStyle VerticalAlign="Middle" Width="15%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                        </asp:BoundField>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                产品组
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#Eval("Products[0].pname")%>
                            </ItemTemplate>
                            <ControlStyle Height="20px" />
                            <HeaderStyle VerticalAlign="Middle" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="mtitle" HeaderText="会议主题">
                            <ControlStyle Height="20px" />
                            <HeaderStyle VerticalAlign="Middle" Width="40%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                投票题
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="button" value="编辑" onclick="javascript:window.location.href='VoteListPage.aspx?mid=<%#Eval("mid") %>    '">
                            </ItemTemplate>
                            <FooterStyle Height="20px" />
                            <HeaderStyle VerticalAlign="Middle" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="调研">
                            <ItemTemplate>
                                <input type="button" value="开启" onclick="startSurvey(<%#Eval("mid") %>)" mid="<%#Eval("mid") %>"
                                    state="startSurvey" />
                                <input type="button" value="关闭" onclick="closeSurvey(<%#Eval("mid") %>)" mid="<%#Eval("mid") %>"
                                    state="closeSurvey" style="display: none" />
                                <script>
                                    //判断调研是否开启
                                    var mid=<%#Eval("mid") %>;
                                    $.ajax({
                                        url: "../WebService/WebService.asmx/SurveyByMid",
                                        type: "post",
                                        data: { mid:  mid},
                                        success: function (r) {
                                            if (r != null && r.length > 0)
                                            {
                                                if (r[0].sstate=="1") {
                                                    $("input[mid=" + mid + "][state=startSurvey]").hide();
                                                    $("input[mid=" + mid + "][state=closeSurvey]").show();
                                                }
                                                else
                                                {
                                                    $("input[mid=" + mid + "][state=startSurvey]").show();
                                                    $("input[mid=" + mid + "][state=closeSurvey]").hide();
                                                }
                                            }
                                        },
                                        error: function (r) {
                                            console.log(r.responseText);
                                        }
                                    });
                                </script>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Middle" Width="20%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="现场回答">
                            <ItemTemplate>
                                <input type="button" value="查看" onclick="javascript:window.location.href='MeetAnswers.aspx?mid=<%#Eval("mid") %>    '">
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Middle" Width="20%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

