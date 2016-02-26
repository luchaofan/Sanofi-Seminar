using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WeChatSeminar.APP_Code
{
    public class Common<T> where T : new()
    {
      
        /// <summary>
        /// 将DataTable转换成Model实体
        /// </summary>
        /// <param name="obj">Model名称</param>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static T Dt2Model(T obj, DataTable dt)
        {
            if (dt.Rows.Count <= 0) return (T)obj;
            T t = new T();
            string tempName = "";
            PropertyInfo[] pis = t.GetType().GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                tempName = pi.Name;
                if (dt.Columns.Contains(tempName))
                {
                    if (!pi.CanWrite) continue;
                    object value = dt.Rows[0][tempName];
                    if (value != DBNull.Value)
                    {
                        if (dt.Rows[0][pi.Name].GetType().Name.ToString().ToLower() == "datetime")
                            pi.SetValue(t, Convert.ToDateTime(value).ToString("yyyy年MM月dd日 HH:mm:ss"), null);
                        else
                            pi.SetValue(t, value, null);
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// 将DataTable转换成IList
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>返回IList</returns>
        public static IList<T> Dt2List(DataTable dt)
        {
            IList<T> list = new List<T>();
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                        {
                            if (dr[pi.Name].GetType().Name.ToString().ToLower() == "datetime")
                                pi.SetValue(t, Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss"), null);
                            else
                                pi.SetValue(t, value, null);
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }

    }
    public class Tools
    {
        private static char[] constant =   
      {   
        '1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
      };
        public static void Catch(System.Web.HttpResponse res, Exception ex)
        {
            res.Write("\"Result\":\"false\",\"Message\":\"系统错误:" + ex.Message + "\"");
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="Length">生成的位数</param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(61);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(61)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// AD域身份验证
        /// </summary>
        /// <param name="ComputerName">AD域地址</param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool ValidateUser(string ComputerName, string UserName, string Password)
        {
            try
            {
                string fullPath = "LDAP://" + ComputerName;
                System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(fullPath, UserName, Password);
                Object obj = entry.NativeObject;
                System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + UserName + ")";
                search.PropertiesToLoad.Add("cn");
                System.DirectoryServices.SearchResult result = search.FindOne();
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }
    }
}
