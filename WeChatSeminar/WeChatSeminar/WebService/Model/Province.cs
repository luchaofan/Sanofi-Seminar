using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class Province
    {
        private bool _Selected;
        public string ProvinceName
        {
            get;
            set;
        }
        public bool selected
        {
            get
            {
                return this._Selected;
            }
            set
            {
                this._Selected = value;
            }
        }
        public int ProvinceID
        {
            get;
            set;
        }
    }
}