using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class Answer
    {
        public int id { get; set; }
        public string uid { get; set; }
        public int mid { get; set; }
        public string content { get; set; }
        public string datatiem { get; set; }
    }
}