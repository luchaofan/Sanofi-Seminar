using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using MySql.Data.MySqlClient;
using WeChatSeminar.WebService.Model;

namespace WeChatSeminar.APP_Code
{
    public class AdminService
    {
        /// <summary>
        /// 获取会议列表
        /// </summary>
        /// <returns></returns>
        public IList<Meeting> GetMeetingList(int PageNumber, string City, string Grade, string Date, string SearchText, int PageSize)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM seminar_meeting WHERE 1=1");
            if (!string.IsNullOrEmpty(City) && !City.Equals("--全部--"))
            {
                stringBuilder.Append(string.Format(" AND mregion LIKE '%{0}%'", City));
            }
            if (!string.IsNullOrEmpty(Grade) && !Grade.Equals("--无--"))
            {
                stringBuilder.Append(string.Format(" AND mgrade LIKE '%{0}%'", Grade));
            }
            if (!string.IsNullOrEmpty(Date) && !Date.Equals("0"))
            {
                stringBuilder.Append(string.Format(" AND  mbegintime LIKE '%{0}%'", Date));
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                stringBuilder.Append(string.Format(" AND  mtitle LIKE '%{0}%'", SearchText));
            }
            var mDt = DB_mysql.ExecuteQueryDT(stringBuilder.ToString());
            IList<Meeting> im = new List<Meeting>();
            if (mDt.Rows.Count > 0)
                im = Common<Meeting>.Dt2List(mDt);
            return im;
        }

        public int GetTotalPageNumber(int PageNumber, string City, string Grade, string Date, string SearchText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM seminar_meeting WHERE 1=1");
            if (!string.IsNullOrEmpty(City) && !City.Equals("--全部--"))
            {
                stringBuilder.Append(string.Format(" AND mregion LIKE '%{0}%'", City));
            }
            if (!string.IsNullOrEmpty(Grade) && !Grade.Equals("--无--"))
            {
                stringBuilder.Append(string.Format(" AND mgrade LIKE '%{0}%'", Grade));
            }
            if (!string.IsNullOrEmpty(Date) && !Date.Equals("0"))
            {
                stringBuilder.Append(string.Format(" AND  mbegintime LIKE '%{0}%'", Date));
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                stringBuilder.Append(string.Format(" AND  mtitle LIKE '%{0}%'", SearchText));
            }
            DataTable dataTable = DB_mysql.ExecuteQueryDT(stringBuilder.ToString());
            return dataTable.Rows.Count;
        }

        public Meeting GetMeetingBaseInfo(int mid)
        {
            string sql = string.Format("select *  from seminar_meeting where mid='{0}'", mid);
            var mDt = DB_mysql.ExecuteQueryDT(sql);
            Meeting m = new Meeting();
            if (mDt.Rows.Count > 0)
                m = Common<Meeting>.Dt2Model(m, mDt);
            return m;
        }

        public IList<Vote> GetVoteList(int mid)
        {
            string sql = string.Format("select * from seminar_vote where mid='{0}' and vstate=1", mid);
            var vDt = DB_mysql.ExecuteQueryDT(sql);
            IList<Vote> vote = new List<Vote>();
            if (vDt.Rows.Count > 0)
                vote = Common<Vote>.Dt2List(vDt);
            return vote;
        }

        public IList<Survey> GetSurveyList(int mid)
        {
            string sql = string.Format("select * from seminar_survey where mid='{0}' and sstate=1", mid);
            var sDt = DB_mysql.ExecuteQueryDT(sql);
            IList<Survey> s = new List<Survey>();
            if (sDt.Rows.Count > 0)
                s = Common<Survey>.Dt2List(sDt);
            return s;
        }

        public bool AddVote(List<Vote> ls)
        {
            List<string> list = new List<string>();
            foreach (Vote current in ls)
            {
                string item = string.Format("INSERT INTO seminar_vote (mid,vtopic,vanswer,vdatetime,vtype) VALUES({0},'{1}','{2}','{3}',{4})", new object[]
				{
					current.mid,
					current.vtopic,
					current.vanswer,
					current.vdatetime,
					current.vtype
				});
                list.Add(item);
            }
            return DB_mysql.Transaction(list);
        }

        public bool UpdateVote(List<Vote> ls)
        {
            List<string> list = new List<string>();
            foreach (Vote current in ls)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("UPDATE seminar_vote SET mid={0}", current.mid));
                if (!string.IsNullOrEmpty(current.vtopic))
                {
                    stringBuilder.Append(string.Format(" ,vtopic='{0}'", current.vtopic));
                }
                if (!string.IsNullOrEmpty(current.vanswer))
                {
                    stringBuilder.Append(string.Format(" ,vanswer='{0}'", current.vanswer));
                }
                if (!string.IsNullOrEmpty(current.vtype.ToString()))
                {
                    stringBuilder.Append(string.Format(",vtype={0}", current.vtype));
                }
                if (!string.IsNullOrEmpty(current.vdatetime))
                {
                    stringBuilder.Append(string.Format(",vdatetime='{0}'", current.vdatetime));
                }
                stringBuilder.Append(string.Format(" WHERE vid={0}", current.vid));
                list.Add(stringBuilder.ToString());
            }
            return DB_mysql.Transaction(list);
        }

        public bool AddSurvey(List<Survey> ls)
        {
            List<string> list = new List<string>();
            foreach (Survey current in ls)
            {
                string item = string.Format("INSERT INTO seminar_survey (mid,stitle,sanswer,sdatatiem) VALUES({0},'{1}','{2}','{3}')", new object[]
				{
					current.mid,
					current.stitle,
					current.sanswer,
					current.sdatatiem
				});
                list.Add(item);
            }
            return DB_mysql.Transaction(list);
        }
        public bool UpdateSurvey(List<Survey> ls)
        {
            List<string> list = new List<string>();
            foreach (Survey current in ls)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("UPDATE seminar_survey SET mid={0}", current.mid));
                if (!string.IsNullOrEmpty(current.stitle))
                {
                    stringBuilder.Append(string.Format(" ,stitle='{0}'", current.stitle));
                }
                if (!string.IsNullOrEmpty(current.sanswer))
                {
                    stringBuilder.Append(string.Format(",sanswer='{0}'", current.sanswer));
                }
                if (!string.IsNullOrEmpty(current.stype.ToString()))
                {
                    stringBuilder.Append(string.Format(",stype={0}", current.stype));
                }
                if (!string.IsNullOrEmpty(current.sdatatiem))
                {
                    stringBuilder.Append(string.Format(",sdatatiem='{0}'", current.sdatatiem));
                }
                stringBuilder.Append(string.Format(" WHERE sid={0}", current.sid));
                list.Add(stringBuilder.ToString());
            }
            return DB_mysql.Transaction(list);
        }
        public bool DeleteVote(int vid)
        {
            string sql = string.Format("DELETE FROM seminar_vote WHERE vid={0}", vid);
            return DB_mysql.ExecuteNonQuery(sql) > 0;
        }
        public bool DeleteSuryvey(int sid)
        {
            string sql = string.Format("DELETE FROM  seminar_survey WHERE sid={0}", sid);
            return DB_mysql.ExecuteNonQuery(sql) > 0;
        }
        public List<Province> GetProvinceList()
        {
            List<Province> list = new List<Province>();
            string sql = "SELECT DISTINCT cspell FROM seminar_city ORDER BY CONVERT(cspell USING gbk) ASC";
            DataTable dataTable = DB_mysql.ExecuteQueryDT(sql);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i <= dataTable.Rows.Count; i++)
                {
                    Province provinceModel = new Province();
                    if (i == 0)
                    {
                        provinceModel.ProvinceName = "--无--";
                        provinceModel.ProvinceID = 0;
                        provinceModel.selected = true;
                    }
                    else
                    {
                        provinceModel.ProvinceID = i;
                        provinceModel.ProvinceName = dataTable.Rows[i - 1][0].ToString();
                    }
                    list.Add(provinceModel);
                }
            }
            else
            {
                list.Add(new Province
                {
                    ProvinceName = "--无--",
                    ProvinceID = 0,
                    selected = true
                });
            }
            return list;
        }
        public List<City> GetCityList(string Province)
        {
            List<City> list = new List<City>();
            string sql = string.Format("SELECT DISTINCT cname FROM  seminar_city WHERE cspell='{0}' ORDER BY CONVERT(cname USING gbk) ASC", Province);
            DataTable dataTable = DB_mysql.ExecuteQueryDT(sql);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i <= dataTable.Rows.Count; i++)
                {
                    City cityModel = new City();
                    if (i == 0)
                    {
                        cityModel.CityID = 0;
                        cityModel.CityName = "--无--";
                        cityModel.selected = true;
                    }
                    else
                    {
                        cityModel.CityID = i;
                        cityModel.CityName = dataTable.Rows[i - 1][0].ToString();
                    }
                    list.Add(cityModel);
                }
            }
            else
            {
                list.Add(new City
                {
                    CityID = 0,
                    CityName = "--无--",
                    selected = true
                });
            }
            return list;
        }
        public string GetProvinceByCity(string city)
        {
            string sql = string.Format("SELECT DISTINCT cspell FROM  seminar_city WHERE cname='{0}'", city);
            return DB_mysql.ExecuteScalar(sql).ToString();
        }
        public bool SaveMeetingBase(Meeting m, int mid)
        {
            MySqlParameter[] pa = new MySqlParameter[]
			{
				new MySqlParameter("?title", m.mtitle),
				new MySqlParameter("?beTime", m.mbegintime),
				new MySqlParameter("?edTime", m.mendtime),
				new MySqlParameter("?city", m.mregion),
				new MySqlParameter("?grade", m.mgrade),
				new MySqlParameter("?address", m.msite),
				new MySqlParameter("?introduction", m.mcontent),
				new MySqlParameter("?mid", mid)
			};
            string sql = "UPDATE seminar_meeting SET mtitle=?title,mcontent=?introduction,mregion=?city,mbegintime=?beTime,mendtime=?edTime,mgrade=?grade,msite=?address WHERE mid=?mid";
            return DB_mysql.ExecuteNonQuery(sql, pa) > 0;
        }




        //
        //
        public bool AddMeeting(Meeting m)
        {
            DateTime dtime = Convert.ToDateTime(m.mbegintime);
            string period = dtime.Year + "-" + dtime.Month;
            MySqlParameter[] pa = new MySqlParameter[]
			{
				new MySqlParameter("?title", m.mtitle),
				new MySqlParameter("?beTime", m.mbegintime),
				new MySqlParameter("?edTime", m.mendtime),
				//new MySqlParameter("?pid", m.Pid),
				new MySqlParameter("?city", m.mregion),
				new MySqlParameter("?grade", m.mgrade),
				new MySqlParameter("?address", m.msite),
                new MySqlParameter("?introduction", m.mcontent),
                new MySqlParameter("?mspot_banner",m.mspot_banner),
                new MySqlParameter("?mhd_img", m.mhd_img)
			};
            string sql = "INSERT INTO seminar_meeting (mtitle,mcontent,mregion,mbegintime,mendtime,mgrade,mspot_banner,mhd_img,msite)VALUES(?title,?introduction,?city,?beTime,?edTime,?grade,?mspot_banner,?mhd_img,?address)";
            return DB_mysql.ExecuteNonQuery(sql, pa) > 0;
        }

        public bool AddMeetingErCode(int mid, string invite, string signIn)
        {
            string sql = string.Format("UPDATE seminar_meeting SET yqhewm_img='{0}',qdewm_img='{1}' WHERE mid={2}", invite, signIn, mid);
            return DB_mysql.ExecuteNonQuery(sql) > 0;
        }
        public int GetLastMid()
        {
            string sql = "SELECT max(mid) FROM seminar_meeting";
            return (int)DB_mysql.ExecuteScalar(sql);
        }
        //
        public List<string> GetErCode(int mid)
        {
            string sql = string.Format("SELECT yqhewm_img,qdewm_img FROM seminar_meeting WHERE mid={0}", mid);
            DataTable dataTable = DB_mysql.ExecuteQueryDT(sql);
            List<string> list = new List<string>();
            if (dataTable.Rows.Count > 0)
            {
                list.Add(dataTable.Rows[0][0].ToString());
                list.Add(dataTable.Rows[0][1].ToString());
            }
            return list;
        }

        public bool DeleteMeeting(int MeetingID)
        {
            string sql = string.Format("DELETE FROM seminar_meeting WHERE mid={0}", MeetingID);
            return DB_mysql.ExecuteNonQuery(sql) > 0;
        }
    }
}