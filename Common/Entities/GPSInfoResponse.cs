using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{

    public class GPSInfoResponse
    {
        public int version { get; set; }

        public bool success { get; set; }

        public List<GPSInfoItem> locs { get; set; }
    }
    public class GPSInfoItem
    {
        public int id { get; set; }

        public string name { get; set; }

        public int recvtime { get; set; }

        public int gpstime { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }

        public double lat_xz { get; set; }

        public double lng_xz { get; set; }

        public string state { get; set; }

        public double speed { get; set; }

        public int direct { get; set; }

        public double temp { get; set; }

        public double oil { get; set; }

        public int oilMN1 { get; set; }

        public int oilMN2 { get; set; }

        public double distance { get; set; }

        public double totalDis { get; set; }

        public string av { get; set; }

        public string info { get; set; }
        public int vhcofflinemin { get; set; }

        public double stopDefDis { get; set; }

        public double stopDefLat { get; set; }

        public double stopDefLng { get; set; }

        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public string temp3 { get; set; }
        public string temp4 { get; set; }


    }
}
