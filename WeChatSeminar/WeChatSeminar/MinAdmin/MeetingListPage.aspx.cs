using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeChatSeminar.APP_Code;
using WeChatSeminar.WebService.Model;

namespace WeChatSeminar.MinAdmin
{
    public partial class MeetingListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GridView1.AutoGenerateColumns = false;
                InitGridView();
            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Meeting s = (Meeting)e.Row.DataItem;


            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //这是鼠标移到某行时改变某行的背景 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#eaeaea';");
                //鼠标移走时恢复
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            }
        }
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //光棒效果
                e.Row.Attributes.Add("onMouseOver", "t=this.style.backgroundColor;this.style.backgroundColor='#ebebce'");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=t"); e.Row.Attributes.Add("onclick", "if(this.style.backgroundColor=='#ebebce')this.style.backgroundColor=t;else{this.style.backgroundColor='#ebebce'}");
                e.Row.Attributes.CssStyle.Add("cursor", "hand");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            InitGridView();

        }

        private void InitGridView()
        {
            IList<Meeting> me = new MinAdminService().QueryMeeting();
            this.GridView1.DataSource = me;
            this.GridView1.DataBind();
        }
    }
}