using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatSeminar.MinAdmin
{
    public partial class VoteDetailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string vid = Request.QueryString["vid"].ToString();
                string vresult = Request.QueryString["vresult"].ToString();

                if (!(string.IsNullOrEmpty(vid) && string.IsNullOrEmpty(vresult)))
                {

                    string sql = string.Format("SELECT * FROM seminar_vote_result where vid={0} and  vresult='{1}' ORDER BY vdatetime DESC", vid, vresult);

                    System.Data.DataTable dt = WeChatSeminar.APP_Code.DB_mysql.ExecuteQueryDT(sql);
                    this.ListView1.DataSource = dt;
                    this.ListView1.DataBind();
                }
            }
        }
    }
}