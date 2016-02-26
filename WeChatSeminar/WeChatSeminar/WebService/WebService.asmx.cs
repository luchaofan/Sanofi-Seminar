using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WeChatSeminar.APP_Code;
using WeChatSeminar.WebService.Model;

namespace WeChatSeminar.WebService
{
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        MeetService ms = new MeetService();
        MinAdminService mas = new MinAdminService();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        [WebMethod(Description = "登陆", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Login(string UserName, string Password)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                if (Context.Session["user"] != null)
                {
                    res.Write(jss.Serialize((UserInfo)Context.Session["user"]));
                }
                else
                {
                    UserInfo user = new UserInfo() { ID = new Random().Next(1, 999), OpenID = Tools.GenerateRandomNumber(16), CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
                    if (user != null)
                        Context.Session["user"] = user;
                    res.Write(jss.Serialize(user));
                }
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "判断Session", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void IsExistSession()
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                UserInfo user = (UserInfo)Context.Session["user"];
                res.Write(jss.Serialize(user));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "按编号查询会议", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMeetingById(int mid)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                Meeting m = ms.GetMeetingById(mid);
                res.Write(jss.Serialize(m));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "按会议编号查询投票", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void VoteByMid(int mid)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                IList<Vote> v = ms.GetVoteByMid(mid);
                res.Write(jss.Serialize(v));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "按投票编号查询投票", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void VoteByVid(int vid)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                Vote v = ms.GetVoteById(vid);
                res.Write(jss.Serialize(v));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "保存投票结果", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddVoteResult(string jsonVoteResult)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                var vr = jss.Deserialize<VoteResult>(jsonVoteResult);
                res.Write(ms.AddVoteResult(vr));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }

        [WebMethod(Description = "按会议编号查询调研", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SurveyByMid(int mid)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                IList<Survey> v = ms.GetSurveyByMid(mid);
                res.Write(jss.Serialize(v));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "保存调研结果", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddSurveyResult(string jsonSurveyResult)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                var lsr = jss.Deserialize<List<SurveyResult>>(jsonSurveyResult);
                res.Write(ms.AddSurveyResult(lsr));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "保存现场问答", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddMeetAnswer(string jsonAnswer)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                var lsr = jss.Deserialize<Answer>(jsonAnswer);
                res.Write(ms.AddMeetAnswer(lsr));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }



        [WebMethod(Description = "统计投票结果1", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void VoteResultCount(int vid, string vresult)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                res.Write(mas.VoteResultCount(vid, vresult));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "统计投票结果2", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void _NCount(int vid)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                res.Write(mas.VoteResultCountByVid(vid));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "统计投票结果3", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void VoteResultByVid(int vid)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                IList<VoteResult> vr = mas.VoteResultByVid(vid);
                res.Write(jss.Serialize(vr));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }
        [WebMethod(Description = "根据会议ID获取现场问答", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMeetAnswers(int mid, int PageIndex, int PageSize)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                IList<Answer> vr = mas.GetMeetAnswers(mid, PageIndex, PageSize);
                res.Write(jss.Serialize(vr));
            }
            catch (Exception ex)
            {
                Tools.Catch(res, ex);
            }
        }

    }
}
