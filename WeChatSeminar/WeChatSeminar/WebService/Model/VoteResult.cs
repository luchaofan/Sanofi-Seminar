using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class VoteResult
    {
        public int vrid { get; set; }
        public string uid { get; set; }
        public int vid { get; set; }
        public string vresult { get; set; }
        public string vdatetime { get; set; }

        /// <summary>
        /// 投票集合
        /// </summary>
        public Vote Votes { get; set; }
    }
}