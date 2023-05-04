using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    [Auth]
    [PermissionFilter]
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowLocations(string plate)
        {
            ViewBag.Plate = plate;
            return View();
        }


        public string GetLocations(string plate, DateTime stime, DateTime etime)
        {

            string url = "https://api.wuxiakj.com/External/GetGpsList?Cph={0}&STime={1}&ETime={2}&Ident={3}";
            url = string.Format(url, plate, stime.ToString("yyyy-MM-dd HH:mm:ss"), etime.ToString("yyyy-MM-dd HH:mm:ss"), "");
            string json = Common.HttpHelper.Get(url);
            return json;
        }
    }
}