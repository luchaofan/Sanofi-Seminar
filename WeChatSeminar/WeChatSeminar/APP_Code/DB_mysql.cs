using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WeChatSeminar.APP_Code
{
    public class DB_mysql
    {
        public static string conString = ConfigurationManager.ConnectionStrings["conStr"].ToString();

        /// <summary>
        /// 给command对象的属性赋值
        /// </summary>
        /// <param name="Com"></param>
        /// <param name="Con"></param>
        /// <param name="Trans"></param>
        /// <param name="SqlString"></param>
        /// <param name="Pa"></param>
        private static void PrepareCommand(MySqlCommand Com, MySqlConnection Con, MySqlTransaction Trans, string SqlString, params MySqlParameter[] Pa)
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
            Com.Connection = Con;
            if (Trans != null)
            {
                Com.Transaction = Trans;
            }
            Com.CommandText = SqlString;
            if (Pa.Length > 0)
            {
                foreach (MySqlParameter pa in Pa)
                {
                    Com.Parameters.Add(pa);
                }
            }
        }

        public static int ExecuteNonQuery(string sql, MySqlParameter[] parameters)
        {
            //Debug.WriteLine(sql);
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                int rows = 0;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    rows = cmd.ExecuteNonQuery();

                }
                catch 
                {

                }
                finally
                {
                    connection.Close();
                }
                return rows;
            }
        }
        public static object ExecuteScalar(string sql, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                object rows = null;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    rows = cmd.ExecuteScalar();
                }
                catch 
                {

                }
                finally
                {
                    connection.Close();
                }
                return rows;
            }
        }

        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }
        //执行不带参数的sql语句，返回影响的记录数
        //不建议使用拼出来SQL
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }

        //执行查询语句，返回dataset
        public static DataSet ExecuteQuery(string sql, MySqlParameter[] parameters)
        {
            //Debug.WriteLine(sql); 
            using (MySqlConnection connection = new MySqlConnection(conString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                    if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(ds, "ds");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }

        public static DataSet ExecuteQuery(string sql)
        {
            return ExecuteQuery(sql, null);
        }



        public static DataTable ExecuteQueryDT(string sql)
        {
            DataTable thisDT = new DataTable();
            try
            {
                DataSet thisDataSet = DB_mysql.ExecuteQuery(sql);
                thisDT = thisDataSet.Tables[0];
            }
            catch
            {

            }
            return thisDT;
        }


        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="Pa"></param>
        /// <returns></returns>
        public static bool Transaction(List<string> Sql)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand())
                {
                    MySqlTransaction trans = con.BeginTransaction();
                    com.Connection = con;
                    com.Transaction = trans;
                    try
                    {
                        for (int i = 0; i < Sql.Count; i++)
                        {
                            PrepareCommand(com, con, null, Sql[i]);
                            com.ExecuteNonQuery();
                            // com.Parameters.Clear();
                        }
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}