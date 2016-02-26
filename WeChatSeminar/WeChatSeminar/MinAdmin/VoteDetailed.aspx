<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteDetailed.aspx.cs" Inherits="WeChatSeminar.MinAdmin.VoteDetailed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table.imagetable
        {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            border-color: #999999;
            border-collapse: collapse;
        }
        table.imagetable th
        {
            background: #b5cfd2 url('cell-blue.jpg');
            border-width: 1px;
            padding: 8px;
            border-style: solid;
            border-color: #999999;
        }
        table.imagetable td
        {
            background: #dcddc0 url('cell-grey.jpg');
            border-width: 1px;
            padding: 8px;
            border-style: solid;
            border-color: #999999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="include" style="border: 1px solid red; margin: 0px auto; margin-top: 0px;
        width: 1022px; border: 1px #cccccc solid; position: relative;">
        <asp:ListView ID="ListView1" runat="server">
            <LayoutTemplate>
                <table class="imagetable" width="1022px">
                    <thead>
                        <tr>
                            <th>
                                ETMSCODE
                            </th>
                            <th>
                                手机
                            </th>
                            <th>
                                投票时间
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr align="center">
                    <td>
                        <%# Eval("uid") %>
                    </td>
                    <td>
                    </td>
                    <td>
                        <%# Eval("vdatetime") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
