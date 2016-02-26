using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatSeminar.MinAdmin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text;
            string pwd = this.TextBox2.Text;
            if (string.IsNullOrEmpty(name))
            {
                Response.Write("<script>alert('用户名不能为空');</script>");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                Response.Write("<script>alert('密码不能为空');</script>");
                return;
            }
            if (!name.ToLower().Equals("admin") || !pwd.ToLower().Equals("123456"))
            {
                Response.Write("<script>alert('用户名或密码错误');</script>");
                return;
            }
            else
            {
                //Session["user"] = user[0];
                Response.Redirect("MeetingListPage.aspx");
            }
        }
    }
}