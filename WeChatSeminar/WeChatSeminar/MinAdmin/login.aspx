<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WeChatSeminar.MinAdmin.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        *
        {
            font-family: 微软雅黑;
            font-size: 14px;
        }
        p
        {
            margin: 0px;
            padding: 0px;
        }
        body
        {
            margin: 0px;
            padding: 0px;
            background-color: #EEF3FA;
        }
        #include
        {
            margin: 0px auto;
            width: 1024px;
            height: 600px;
        }
        .top
        {
            width: 100%;
            height: 98px;
            background-image: url('image/hengla.png');
            position: relative;
        }
        
        .top_logo
        {
            width: 174px;
            height: 27px;
            /*background-image: url('image/logo.png');*/
            background-repeat: no-repeat;
            position: absolute;
            left: 810px;
            top: 30px;
        }
        .font
        {
            width: 100%;
            height: 502px;
            background-color: rgb(238,248,250);
        }
        .login
        {
            width: 250px;
            height: 195px;
            margin: 0 auto;
        }
        .login_top
        {
            width: 250px;
            height: 140px;
            background-color: #096ab7;
        }
        .login_font
        {
            width: 100%;
            height: 55px;
            background-color: #e6f0f9;
        }
        .title_text
        {
            color: #fff;
            font-size: 12px;
            width: 100px;
            height: 35px;
            line-height: 35px;
            text-indent: 20px;
        }
        .shuru
        {
            margin: 0px auto;
            font-size: 12px;
            width: 206px;
            height: 68px;
            background-image: url('image/tianxie.png');
            background-repeat: no-repeat;
        }
        .login_top a
        {
            color: #fff;
            font-size: 12px;
            width: 100px;
            margin-left: 20px;
            display: block;
            margin-top: 5px;
        }
        
        
        #TextBox1
        {
            margin-top: 8px;
            margin-left: 5px;
            border: 0px;
        }
        #TextBox2
        {
            margin-top: 8px;
            margin-left: 5px;
            border: 0px;
        }
        
        .btn
        {
            background-image: url('image/denglu.png');
            width:82px;
            height:38px;
            margin-top: 10px;
            margin-left: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="include">
        <div class="top">
            <div class="top_logo">
            </div>
        </div>
        <div class="font">
            <div class="login">
                <div class="login_top">
                    <div class="title_text">
                        现场互动管理</div>
                    <div class="shuru">
                        <asp:TextBox ID="TextBox1" runat="server" Width="165px"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" Width="165px"></asp:TextBox>
                    </div>
                    <a href="#"> </a>
                </div>
                <div class="login_font">
                    <asp:Button ID="Button1" runat="server" Text="" BorderStyle="None"
                        CssClass="btn" onclick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>