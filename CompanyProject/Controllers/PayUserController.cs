using Bll;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class PayUserController : Controller
    {
        PayUserManager _manager = new PayUserManager();
        // GET: PayUser
        public ActionResult Index(int index = 1, int size = 15, string key = "")
        {
            var result = _manager.GetUserInfo(index, size, key);
            ViewBag.List = result.Result == null?new List<PayUser>():(List<PayUser>)result.Result;
            return View();
        }


        public  ActionResult  AddPayUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddPayUser(PayUser user)
        {
            var result = _manager.AddPayUserInfo(user);
            return View();
        }


        public string AddPayHis(PayHis his)
        {
            his.PayTime = DateTime.Now;
            his.Id = Guid.NewGuid();
            var res = _manager.AddPayHis(his);
            return Utils.SerializeObject(res);
        }
    }
}