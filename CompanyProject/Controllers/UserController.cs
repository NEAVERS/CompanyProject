using Bll;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CompanyProject.Controllers
{
    public class UserController : Controller
    {

        //UserManager _userManager = new UserManager();
        //ResponseModel _response = new ResponseModel();
        // GET: User
        [Auth]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
            string loginResult = "登录失败!";
            Guid userid = Guid.Empty;
            if (userName == "admin" && password == "123456")
            //if ((userName == "admin" && password == "123456" )
            //    || _userManager.Login(userName,password,ref userid))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                    1,
                                    userName,
                                    DateTime.Now,
                                    DateTime.Now.Add(FormsAuthentication.Timeout),
                                    true,
                                    "11111111111"
                                    );
                HttpCookie cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket));
                Response.Cookies.Add(cookie);
                return Redirect("/User/Index");
            }
            ViewBag.loginResult = loginResult;
            return View();
        }

    }
}