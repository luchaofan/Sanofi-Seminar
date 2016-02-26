using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class Survey
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int sid { get; set; }
        /// <summary>
        /// 会议编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 大标题
        /// </summary>
        public string smaxtitle { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string stitle { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string sanswer { get; set; }
        /// <summary>
        /// 开启状态
        /// </summary>
        public string sstate { get; set; }
        /// <summary>
        /// 题目类型（0:多选题1：单选题）
        /// </summary>
        public int stype { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string sdatatiem { get; set; }

        /// <summary>
        /// 会议集合
        /// </summary>
        public List<Meeting> Meetings { get; set; }
    }
}