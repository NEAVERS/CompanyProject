using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CheckItem
    {
        public Guid Id { get; set; }

        public Guid CheckInfoId { get; set; }

        public string ItemName { get; set; }

        public int ItemType { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int Courts { get; set; }


        public string Remark { get; set; }

        public List<PicInfo> Pics { get; set; }

        public CheckItem()
        {

        }

        public CheckItem(CheckSub sub,Guid infoId)
        {
            this.Id = Guid.NewGuid();
            this.CheckInfoId = infoId;
            this.Courts = 0;
            this.ItemName = sub.ToString();
            this.ItemType = (int)sub;
            this.Remark = string.Empty;
            this.Pics = new List<PicInfo>();
        }
    }
}
