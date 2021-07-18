using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Street
    {
        public List<Road> List = new List<Road>();

        
        public List<Road> GetPersonRoad()
        {
            List<Road> personRoad = new List<Road>();


            foreach (var item in List)
            {
                double UpTotalLng = (item.Poin1.UpLng - item.Poin2.UpLng) / item.PersonCount;
                double UpTotalLat = (item.Poin1.UpLat - item.Poin2.UpLat) / item.PersonCount;
                double DownTotalLng = (item.Poin1.DownLng - item.Poin2.DownLng) / item.PersonCount;
                double DownTotalLat = (item.Poin1.DownLat - item.Poin2.DownLat) / item.PersonCount;

                Point bottomPoint = item.Poin1;
                for (int i = 0; i < item.PersonCount; i++)
                {
                    Point temp = new Point();
                    temp.UpLng = bottomPoint.UpLng - UpTotalLng;
                    temp.UpLat = bottomPoint.UpLat - UpTotalLat;
                    temp.DownLng = bottomPoint.DownLng - DownTotalLng;
                    temp.DownLat = bottomPoint.DownLat - DownTotalLat;

                    Road t = new Road();
                    t.Poin1 = bottomPoint;
                    t.Poin2 = temp;
                    personRoad.Add(t);

                    bottomPoint = temp;
                }

            }
            return personRoad;
        }


    }

    public class Road
    {
        public Point Poin1;
        public Point Poin2;

        public int PersonCount;



        public void GetPosi(out double lat,out double lng)
        {
            Random r = new Random();
            Double a = Poin1.UpLat - Poin2.DownLat;
            double b = Poin1.UpLng - Poin2.DownLng;
            lat = Poin1.DownLat + (a * r.NextDouble());
            lng = Poin1.DownLng + (b * r.NextDouble());
        }
    }

    public class  Point
    {
        public double UpLat;
        public double UpLng;
        public double DownLat;
        public double DownLng;
    }

}
