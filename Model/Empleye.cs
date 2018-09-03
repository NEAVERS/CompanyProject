using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Empleye
    {
        public Guid Id  { get; set; }

        public string  Name { get; set; }

        public string  Tel { get; set; }



        public double  Lat { get; set; }


        public double Los { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public int Sex { get; set; }

        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 员工类型
        /// </summary>
        public int  EmpleyType { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid DepetId { get; set; }

        public Empleye()
        {
            this.Id = Guid.NewGuid();
            this.LastUpdateTime = DateTime.Now;
            this.BirthDay = DateTime.MinValue;
            this.DepetId = Guid.Empty;
        }

    }
}
