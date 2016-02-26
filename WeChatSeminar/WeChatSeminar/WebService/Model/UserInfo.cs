using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string OpenID { get; set; }
        public string CreateTime { get; set; }
    }
}