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


        public double Lat { get; set; }

        public double Lng { get; set; }


        public List<CheckItem> CheckItems { get; set; }
    }
}
