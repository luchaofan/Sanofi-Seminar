using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeChatSeminar.APP_Code;

namespace WeChatSeminar.MinAdmin
{
    /// <summary>
    /// StartSurveyOrTopic 的摘要说明
    /// </summary>
    public class StartSurveyOrTopic : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            string mid = context.Request["mid"];
            MinAdminService mas = new MinAdminService();
            if (action.Equals("startSurvey"))
            {
                bool res=mas.ZS_StartSurvey(mid);
                if (res)
                {
                    context.Response.Write("开启成功");
                }
                else
                {
                    context.Response.Write("开启失败");
                }
            }
            if (action.Equals("closeSurvey"))
            {
                bool res = mas.ZS_CloseSurvey(mid);
                if (res)
                {
                    context.Response.Write("关闭成功");
                }
                else
                {
                    context.Response.Write("关闭失败");
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}