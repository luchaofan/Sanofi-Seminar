using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class UserISP
    {
        public int id { get; set; }
        public int mid { get; set; }
        public string Ip { get; set; }
        public string Isp { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string CreateTime { get; set; }
    }
}