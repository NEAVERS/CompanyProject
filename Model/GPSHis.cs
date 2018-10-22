using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GPSHis
    {

        public Guid Id { get; set; }

        public Guid GPSItemId { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string LoactionInfo { get; set; }

        public string States { get; set; }

        public DateTime UploadTime { get; set; }
    }
}
