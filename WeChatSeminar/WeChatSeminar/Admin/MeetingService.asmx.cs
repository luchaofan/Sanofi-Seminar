using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using ThoughtWorks.QRCode.Codec;
using WeChatSeminar.APP_Code;
using WeChatSeminar.WebService.Model;

namespace WeChatSeminar.Admin
{
    [System.Web.Script.Services.ScriptService]
    public class MeetingService : System.Web.Services.WebService
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        WriteErrorLogService log = new WriteErrorLogService();
        AdminService ms = new AdminService();

        [WebMethod(Description = "登录", EnableSession = true)]
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
                log.WriteLog(ex.Message, "Login");
            }
        }

        [WebMethod(Description = "判断session 是否存在", EnableSession = true)]
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
                log.WriteLog(ex.Message, "IsExistSession");
            }
        }

        [WebMethod(Description = "获取会议列表")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMeetingList(string City, string Grade, string Date, string SearchText)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            int PageNumber = Convert.ToInt32(Context.Request["page"]);
            int PageSize = Convert.ToInt32(Context.Request["rows"]);
            try
            {
                int totalPage = ms.GetTotalPageNumber(PageNumber, City, Grade, Date, SearchText);
                if (totalPage > 0)
                {
                    IList<Meeting> list = ms.GetMeetingList(PageNumber, City, Grade, Date, SearchText, PageSize);
                    string json = "{\"total\":\"" + totalPage + "\",\"rows\":" + jss.Serialize(list) + "} ";
                    res.Write(json);
                }
                else
                {
                    res.Write("{\"total\":\"0\",\"rows\":" + jss.Serialize(new List<Meeting>()) + "}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "GetMeetingList");
                res.Write("{\"total\":\"0\",\"rows\":\"系统错误\"}}");
            }
        }

        [WebMethod(Description = "获取某场会议的基本信息")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetMeetingBaseInfo_T()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = Convert.ToInt32(req["mid"]);
                Meeting m = ms.GetMeetingBaseInfo(mid);
                string json = "{\"Result\":\"true\",\"Message\":" + jss.Serialize(m) + "}";
                res.Write(json);
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "获取某场会议的基本信息");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "获取某场会议的投票题")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetVote()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = int.Parse(req["mid"]);
                IList<Vote> list = ms.GetVoteList(mid);
                if (list.Count > 0)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":" + jss.Serialize(list) + "}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"没有相关数据\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "获取某场会议的投票题");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "获取某场会议的调研题")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetSurvey()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = int.Parse(req["mid"]);
                IList<Survey> list = ms.GetSurveyList(mid);
                if (list.Count > 0)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":" + jss.Serialize(list) + "}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"没有相关数据\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "获取某场会议的调研题");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "添加、修改投票题")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddVoteTopic()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = int.Parse(req["mid"]);
                string data = req["data"];
                List<Vote> lis = new List<Vote>();
                XmlDocument docXml = new XmlDocument();
                docXml.LoadXml(data);
                int action = 0;   //添加
                XmlNodeList list = docXml.SelectSingleNode("list").ChildNodes;
                foreach (XmlNode item in list)
                {
                    XmlElement e = item as XmlElement;
                    Vote v = new Vote();
                    v.vtopic = e.GetAttribute("title");
                    v.vanswer = e.GetAttribute("items");
                    v.vdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    v.vtype = int.Parse(e.GetAttribute("type"));
                    v.mid = mid;

                    if (!string.IsNullOrEmpty(e.GetAttribute("vid")))
                    {
                        v.vid = int.Parse(e.GetAttribute("vid"));
                        action = 1;//  修改
                    }
                    lis.Add(v);
                }
                bool ress = action == 0 ? ms.AddVote(lis) : ms.UpdateVote(lis);
                if (ress)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":\"保存成功\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"保存失败\"}");
                }

            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "添加、修改投票题");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "添加、修改调研题")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddSurveyTopics()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = int.Parse(req["mid"]);
                string data = req["data"];
                int action = 0;//添加
                List<Survey> lis = new List<Survey>();
                XmlDocument docXml = new XmlDocument();
                docXml.LoadXml(data);
                XmlNodeList list = docXml.SelectSingleNode("list").ChildNodes;
                foreach (XmlNode item in list)
                {
                    XmlElement e = item as XmlElement;
                    Survey s = new Survey();
                    s.sdatatiem = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    s.sanswer = e.GetAttribute("items");
                    s.mid = mid;
                    s.stitle = e.GetAttribute("title");
                    s.stype = int.Parse(e.GetAttribute("type"));
                    if (!string.IsNullOrEmpty(e.GetAttribute("sid")))
                    {
                        action = 1;//修改
                        s.sid = int.Parse(e.GetAttribute("sid"));
                    }
                    lis.Add(s);
                }
                bool ress = action == 0 ? ms.AddSurvey(lis) : ms.UpdateSurvey(lis);
                if (ress)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":\"保存成功\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"保存失败\"}");
                }

            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "添加、修改调研题");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "删除投票题")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteVoteTopic()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int vid = int.Parse(req["id"]);
                bool ress = ms.DeleteVote(vid);
                if (ress)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":\"删除成功\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"删除失败\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "删除投票题");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "删除调研题")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteSurveyTopic()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int sid = int.Parse(req["id"]);
                bool ress = ms.DeleteSuryvey(sid);
                if (ress)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":\"删除成功\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"删除失败\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "删除调研题");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "获取省份列表", CacheDuration = 600)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetProvince()
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                List<Province> list = ms.GetProvinceList();
                if (list.Count > 0)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":" + jss.Serialize(list) + "}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "GetProvince");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "获取某个省份下的城市列表")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCityByProvince(string Province)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                List<City> list = ms.GetCityList(Province);
                if (list.Count > 0)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":" + jss.Serialize(list) + "}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "GetCityByProvince");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "根据城市名获取省份")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetProvinceByCity()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                string city = req["city"];
                string provice = ms.GetProvinceByCity(city);
                res.Write("{\"Result\":\"true\",\"Message\":\"" + provice + "\"}");
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "GetProvinceByCity");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "保存对某场会议的修改")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SaveMeetingBase()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = Convert.ToInt32(req["mid"]);
                Meeting cm = new Meeting();
                cm.mtitle = req["Title"];
                cm.mbegintime = req["BgTime"];
                cm.mendtime = req["EdTime"];
                //cm.Pid = Convert.ToInt32(req["Products"]);
                cm.mregion = req["City"];
                cm.mgrade = req["Grade"];
                cm.msite = req["Address"];
                cm.mcontent = req["Introduction"];
                bool ress = ms.SaveMeetingBase(cm, mid);
                if (ress)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":\"" + mid + "\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"保存失败\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "保存对某场会议的修改");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }



        //
        //
        [WebMethod(Description = "创建会议 1")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void AddMeeting_1()
        {
            HttpResponse res = Context.Response;
            HttpRequest req = Context.Request;
            res.ContentType = "application/json";
            try
            {
                Meeting cm = new Meeting();
                cm.mtitle = req["Title"];
                cm.mbegintime = req["BgTime"];
                cm.mendtime = req["EdTime"];
                //cm.Pid = Convert.ToInt32(req["Products"]);
                cm.mregion = req["City"];
                cm.mgrade = req["Grade"];
                cm.msite = req["Address"];
                cm.mcontent = req["Introduction"];
                bool ress = ms.AddMeeting(cm);
                if (ress)
                {
                    int mid = ms.GetLastMid();
                    //生成二维码
                    if (!Directory.Exists(Server.MapPath("~/Admin/ErCode")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Admin/ErCode"));
                    }
                    string invite = string.Format("Is working hard to develop...");
                    string signIn = string.Format("http://192.168.1.106:8026/website/MeetInteract.html?mid={0}", mid);
                    string inviteUrl = CreateEnCode(invite);
                    string signInUrl = CreateEnCode(signIn);
                    bool res1 = ms.AddMeetingErCode(mid, inviteUrl, signInUrl);

                    if (res1)
                        res.Write("{\"Result\":\"true\",\"Message\":" + mid + "}");
                    else
                        res.Write("{\"Result\":\"false\",\"Message\":\"请求有误\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"请求有误\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "AddMeeting_1");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }
        //
        [WebMethod(Description = "获取某场会议的二维码")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetErCode()
        {
            HttpRequest req = Context.Request;
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                int mid = int.Parse(req["mid"]);
                List<string> list = ms.GetErCode(mid);
                if (list.Count > 0)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":{\"invite\":\"" + list[0] + "\",\"signIn\":\"" + list[1] + "\"}}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"没有相关数据\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "获取某场会议的资料");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }

        [WebMethod(Description = "删除会议")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DeleteMeeting(int MeetingID)
        {
            HttpResponse res = Context.Response;
            res.ContentType = "application/json";
            try
            {
                bool resu = ms.DeleteMeeting(MeetingID);
                if (resu)
                {
                    res.Write("{\"Result\":\"true\",\"Message\":\"删除成功\"}");
                }
                else
                {
                    res.Write("{\"Result\":\"false\",\"Message\":\"删除失败\"}");
                }
            }
            catch (Exception ex)
            {
                log.WriteLog(ex.Message, "DeleteMeeting");
                res.Write("{\"Result\":\"false\",\"Message\":\"系统错误\"}");
            }
        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content"></param>
        private string CreateEnCode(string contents)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 10;
            qrCodeEncoder.QRCodeVersion = 7;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Drawing.Image myimg = qrCodeEncoder.Encode(contents);
            myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Image img = Image.FromStream(ms);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".png";
            img.Save(Server.MapPath("~/Admin/ErCode/" + fileName));
            return "../ErCode/" + fileName;
        }
    }
}
