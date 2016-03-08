using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WeChatSeminar.WebService.Model;

namespace WeChatSeminar.APP_Code
{
    public class MinAdminService
    {
        public IList<Meeting> QueryMeeting()
        {
            string sql = string.Format("select * from seminar_meeting where 1=1");
            var vDt = DB_mysql.ExecuteQueryDT(sql);
            IList<Meeting> meeting = new List<Meeting>();
            if (vDt.Rows.Count > 0)
                meeting = Common<Meeting>.Dt2List(vDt);
            return meeting;
        }

        /// <summary>
        /// 开启调研
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool ZS_StartSurvey(string mid)
        {
            string sql = string.Format(@"update seminar_survey set sstate=1 where mid='{0}'", mid);
            int res = DB_mysql.ExecuteNonQuery(sql);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭调研
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool ZS_CloseSurvey(string mid)
        {
            string sql = string.Format(@"update seminar_survey set sstate=0 where mid='{0}'", mid);
            int res = DB_mysql.ExecuteNonQuery(sql);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 按编号查询会议
        /// </summary>
        /// <param name="mid">会议ID</param>
        /// <returns></returns>
        public Meeting GetMeetingById(int mid)
        {
            string sql = string.Format("select *  from seminar_meeting where mid='{0}'", mid);
            var mDt = DB_mysql.ExecuteQueryDT(sql);
            Meeting m = new Meeting();
            if (mDt.Rows.Count > 0)
                m = Common<Meeting>.Dt2Model(m, mDt);
            return m;
        }
        /// <summary>
        /// 统计投票结果
        /// </summary>
        /// <param name="vid">题目ID</param>
        /// <param name="vresult">选项</param>
        /// <returns></returns>
        public int VoteResultCount(int vid, string vresult)
        {
            string sql = string.Format("select count(1) from seminar_vote_result where vid='{0}' and  vresult='{1}'", vid, vresult);
            return Convert.ToInt32(DB_mysql.ExecuteScalar(sql));
        }
        public int VoteResultCountByVid(int vid)
        {
            string sql = string.Format("select sum(1) from (  SELECT count(1)  FROM  seminar_vote_result where vid='{0}' GROUP BY uid) a", vid);
            return Convert.ToInt32(DB_mysql.ExecuteScalar(sql));
        }
        public IList<VoteResult> VoteResultByVid(int vid)
        {
            string sql = string.Format("select * from seminar_vote_result where vid='{0}'", vid);
            var vDt = DB_mysql.ExecuteQueryDT(sql);
            IList<VoteResult> iv = new List<VoteResult>();
            foreach (DataRow row in vDt.Rows)
            {
                VoteResult ro = new VoteResult()
                {
                    uid = row["uid"].ToString(),
                    vdatetime = row["vdatetime"].ToString(),
                    Votes = new MeetService().GetVoteById(Convert.ToInt32(row["vid"])),
                    vresult = Convert.ToString(row["vresult"]).Trim(),
                    vid = Convert.ToInt32(row["vid"]),
                    vrid = Convert.ToInt32(row["vrid"])

                };
                iv.Add(ro);
            }
            return iv;
        }
        /// <summary>
        /// 根据会议ID获取现场问答
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public IList<Answer> GetMeetAnswers(int mid, int PageIndex, int PageSize)
        {
            string sql = string.Format("select * from seminar_answer where mid='{0}' and state=1 limit {1},{2}", mid, PageIndex, PageSize);
            var aDt = DB_mysql.ExecuteQueryDT(sql);
            IList<Answer> ia = new List<Answer>();
            if (aDt.Rows.Count > 0)
                ia = Common<Answer>.Dt2List(aDt);
            return ia;
        }

    }
}