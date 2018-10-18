using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PayHis
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        public Guid PayUserId { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 缴费月数
        /// </summary>
        public int Months { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Reamrk { get; set; }

    }
}
