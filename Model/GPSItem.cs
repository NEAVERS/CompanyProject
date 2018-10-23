using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    public class GPSItem
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string  Code { get; set; }

        public string Pwd { get; set; }

        public string Name { get; set; }

        public string CardNum { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Speed { get; set; }

        public string Oil { get; set; }

        

        public string LoacationInfo { get; set; }

        public string States { get; set; }

        public DateTime LastUpdateTime { get; set; }

    }
}
