using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class Meeting
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 产品组
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string mtitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string mcontent { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string mregion { get; set; }
        /// <summary>
        /// 会前资料
        /// </summary>
        public string mfontdata { get; set; }
        /// <summary>
        /// 会后资料
        /// </summary>
        public string mlaterdata { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string mbegintime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string mendtime { get; set; }
        /// <summary>
        /// 资料密码
        /// </summary>
        public string mdatapassword { get; set; }
        /// <summary>
        /// 会议等级
        /// </summary>
        public string mgrade { get; set; }
        /// <summary>
        /// 会议日程的图片
        /// </summary>
        public string mhyrc_img { get; set; }
        /// <summary>
        /// 地图图片
        /// </summary>
        public string mmap_img { get; set; }
        /// <summary>
        /// 我的会议banner
        /// </summary>
        public string mmeet_banner { get; set; }
        /// <summary>
        /// 会议现场banner
        /// </summary>
        public string mspot_banner { get; set; }
        /// <summary>
        /// 会议互动图片
        /// </summary>
        public string mhd_img { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string msite { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string mremark { get; set; }

        /// <summary>
        /// 产品组集合
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// 邀请函二维码
        /// </summary>
        public string yqhewm_img { get; set; }
        /// <summary>
        /// 签到二维码
        /// </summary>
        public string qdewm_img { get; set; }
        /// <summary>
        /// 会议状态
        /// </summary>
        public string mstate { get; set; }
    }
}