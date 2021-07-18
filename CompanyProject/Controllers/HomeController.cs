using Bll;
using Common.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class HomeController : Controller
    {
        GPSManager _manager = new GPSManager();
        ResponseModel _response = new ResponseModel();
        public ActionResult Index(Guid? id)
        {
            //SetPosition();
            ViewBag.Id = id;
            return View();
        }

        public string GetLocation()
        {
            string url = "http://www.gps902.net/api/GetTracking.aspx?id=356803210132270&mapType=baidu&key=20161222HLXTJDMW730XY";

            string json = Common.HttpHelper.Get(url);
            return json;
        }


        public string GetLocations()
        {
            var list = _manager.GetGpsItems();
            Guid id = Guid.Parse("80dd122e-1418-4965-8f14-245005804d0a");
            //SetPosition(id);
            string url = "http://www.gps902.net/api/GetMonitor.aspx?ids=356803210132270,353507000002012,353507100003389&mapType=baidu&key=20161222HLXTJDMW730XY";

            string json = Common.HttpHelper.Get(url);
            return Common.Utils.SerializeObject(list);
        }

        public string GetLocaHis(Guid itemId)
        {
            var list = _manager.GetGPSHises(itemId);
            return Common.Utils.SerializeObject(list);
        }


        public ActionResult CarList()
        {
            var list = _manager.GetGpsItems();
            ViewBag.List = list;
            return View();
        }


        public ActionResult AddCar()
        {
            return View();
        }


        public string SaveCarNum(string carNum)
        {
            _response = _manager.AddCar(carNum);
            return Common.Utils.SerializeObject(_response);
        }


        public string DeleteCarnum(List<Guid> ids)
        {
            _response = _manager.DeleteCars(ids);
            return Common.Utils.SerializeObject(_response);

        }



        public ActionResult GetLocationTest()
        {
            return View();
        }




        public void SetPosition()
        {
            var userList = _manager.GetGpsItems("2");
            foreach (var item in userList)
            {
                if (item != null)
                {
                    DateTime start = new DateTime(2020,12,1);

                    Random r = new Random();
                    Road road = Common.Utils.DeserializeObject<Road>(item.LoacationInfo);
                    for (int i = 0; i < 50; i++)
                    {
                        List<GPSItem> list = new List<GPSItem>();
                        double lat, lng;
                        road.GetPosi(out lat, out lng);
                        item.Lat = (decimal)lat;
                        item.Lng = (decimal)lng;
                        item.LastUpdateTime = start;
                        start = start.AddMinutes(r.Next(27, 31)).AddSeconds(r.Next(0, 30));

                        list.Add(item);
                        _manager.UpdateLoc(list);
                    }

                }
            }
        }


       
        
    }
}