using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatSeminar.WebService.Model
{
    public class City
    {
        private bool _Selected;
        public int CityID
        {
            get;
            set;
        }
        public string CityName
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
    }
}