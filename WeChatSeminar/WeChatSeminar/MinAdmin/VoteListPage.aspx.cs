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
    public partial class VoteListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int mid = Convert.ToInt32(Request.QueryString["mid"]);
                if (mid != 0)
                {
                    Meeting meeting = new MinAdminService().GetMeetingById(mid);
                    this.Literal1.Text = meeting.mtitle;
                    this.Literal2.Text = Convert.ToDateTime(meeting.mbegintime).ToString("yyyy-MM-dd HH:mm");
                    this.Literal3.Text = Convert.ToDateTime(meeting.mendtime).ToString("yyyy-MM-dd HH:mm");
                    this.Literal4.Text = meeting.mregion;
                }
            }
        }
    }
}