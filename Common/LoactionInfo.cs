using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LoactionInfo
    {

        public DateTime positionTime { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }

        public double speed { get; set; }

        public double course { get; set; }

        public bool isStop { get; set; }

        public string satatus { get; set; }
    }
}
