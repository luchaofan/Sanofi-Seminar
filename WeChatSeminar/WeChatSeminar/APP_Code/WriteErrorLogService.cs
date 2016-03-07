using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.APP_Code
{
    public class WriteErrorLogService
    {
        public void WriteLog(string Log, string MethodName)
        {
            Tools.WriteLog(Log, MethodName);
        }
    }
}