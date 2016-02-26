using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class Vote
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int vid { get; set; }
        /// <summary>
        /// 会议编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 题目
        /// </summary>
        public string vtopic { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string vanswer { get; set; }
        /// <summary>
        /// 开启状态
        /// </summary>
        public string vstate { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string vdatetime { get; set; }
        /// <summary>
        /// 是否是多选（0：单选 1：多选）
        /// </summary>
        public int vtype { get; set; }
        /// <summary>
        /// 会议集合
        /// </summary>
        public List<Meeting> Meetings { get; set; }
    }
}