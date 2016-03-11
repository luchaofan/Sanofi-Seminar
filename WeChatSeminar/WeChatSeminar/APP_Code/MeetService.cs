using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WeChatSeminar.WebService.Model;

namespace WeChatSeminar.APP_Code
{
    public class MeetService
    {

        /// <summary>
        /// 保存登录信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddLoginLog(UserISP u)
        {
            string sql = string.Format("insert into seminar_user_log (mid,Ip,Isp,Browser,OS,CreateTime) values ('{0}','{1}','{2}','{3}','{4}',sysdate())", u.mid, u.Ip, u.Isp, u.Browser, u.OS);
            return DB_mysql.ExecuteNonQuery(sql);
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
        /// 按会议编号查询投票
        /// </summary>
        /// <param name="mid">ID</param>
        /// <returns></returns>
        public IList<Vote> GetVoteByMid(int mid)
        {
            string sql = string.Format("select * from seminar_vote where mid='{0}' and vstate=1", mid);
            var vDt = DB_mysql.ExecuteQueryDT(sql);
            IList<Vote> vote = new List<Vote>();
            if (vDt.Rows.Count > 0)
                vote = Common<Vote>.Dt2List(vDt);
            return vote;

        }

        /// <summary>
        /// 按编号查询投票
        /// </summary>
        /// <param name="iid">编号</param>
        /// <returns></returns>
        public Vote GetVoteById(int vid)
        {

            string sql = string.Format("select * from seminar_vote where vid='{0}'", vid);
            var vDt = DB_mysql.ExecuteQueryDT(sql);
            Vote v = new Vote();
            if (vDt.Rows.Count > 0)
                v = Common<Vote>.Dt2Model(v, vDt);
            return v;

        }
        /// <summary>
        /// 保存投票结果
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        public int AddVoteResult(VoteResult vr)
        {
            string sql = string.Empty;
            sql = string.Format("select count(1) from seminar_vote_result where uid='{0}' and vid='{1}'", vr.uid, vr.vid);
            if (Convert.ToInt32(DB_mysql.ExecuteScalar(sql)) > 0)
                return -1;
            List<string> _lSql = new List<string>();
            string[] _arr = vr.vresult.Split('|');
            foreach (var item in _arr)
            {
                sql = string.Format("insert into seminar_vote_result (uid,vid ,vresult,vdatetime) values ('{0}','{1}','{2}',sysdate())", vr.uid, vr.vid, item);
                _lSql.Add(sql);
            }
            if (DB_mysql.Transaction(_lSql))
                return _lSql.Count;
            return 0;

        }

        /// <summary>
        /// 按会议编号查询调研
        /// </summary>
        /// <param name="mid">ID</param>
        /// <returns></returns>
        public IList<Survey> GetSurveyByMid(int mid)
        {
            string sql = string.Format("select * from seminar_survey where mid='{0}' and sstate=1", mid);
            var sDt = DB_mysql.ExecuteQueryDT(sql);
            IList<Survey> s = new List<Survey>();
            if (sDt.Rows.Count > 0)
                s = Common<Survey>.Dt2List(sDt);
            return s;
        }

        /// <summary>
        /// 保存调研结果
        /// </summary>
        /// <param name="lsr">调研结果集合</param>
        /// <returns></returns>
        public int AddSurveyResult(List<SurveyResult> lsr)
        {
            string sql = string.Empty;
            sql = string.Format("select count(1) from seminar_survey_result where uid='{0}' and sid='{1}'", lsr[0].uid, lsr[0].sid);
            if (Convert.ToInt32(DB_mysql.ExecuteScalar(sql)) > 0)
                return -1;
            List<string> _lSql = new List<string>();
            foreach (var sr in lsr)
            {
                string[] _arr = sr.sresult.Split('|');
                foreach (var item in _arr)
                {
                    sql = string.Format("insert into seminar_survey_result (uid,sid,sresult,sdatatiem) values ('{0}','{1}','{2}',sysdate())", sr.uid, sr.sid, item);
                    _lSql.Add(sql);
                }
            }
            if (DB_mysql.Transaction(_lSql))
                return _lSql.Count;
            return 0;

        }

        /// <summary>
        /// 保存现场问答
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddMeetAnswer(Answer a)
        {
            string sql = string.Format("insert into seminar_answer (uid,mid,content,datetime) values ('{0}','{1}','{2}',sysdate())", a.uid, a.mid, a.content);
            return DB_mysql.ExecuteNonQuery(sql);
        }
    }
}