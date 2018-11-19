using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CheckInfo
    {
        public Guid Id  { get; set; }

        public Guid TypeId { get; set; }

        public string TypeName { get; set; }

        public DateTime CreateTime { get; set; }

        public int Status { get; set; }

        /// <summary>
        /// 处理人Id
        /// </summary>
        public Guid DealUserId { get; set; }

        /// <summary>
        /// 处理人姓名
        /// </summary>
        public string DealUserName { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime DealTime { get; set; }
        /// <summary>
        /// 分配时间
        /// </summary>
        public DateTime DistributeTime { get; set; }
        public double Lat { get; set; }

        public double Lng { get; set; }

        public string LocationInfo { get; set; }



        public string Name { get; set; }

        public List<CheckItem> CheckItems { get; set; }

        public string Remark { get; set; }

        public CheckInfo()
        {
            this.Id = Guid.NewGuid();

        }



    }
}
