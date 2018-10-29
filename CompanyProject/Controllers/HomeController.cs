using Bll;
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

        public ActionResult Index()
        {
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

            string url = "http://www.gps902.net/api/GetMonitor.aspx?ids=356803210132270,353507000002012,353507100003389&mapType=baidu&key=20161222HLXTJDMW730XY";

            string json = Common.HttpHelper.Get(url);
            return Common.Utils.SerializeObject(list);
        }

        public string GetLocaHis(Guid itemId)
        {
            var list = _manager.GetGPSHises(itemId);
            return Common.Utils.SerializeObject(list);
        }

    }
}