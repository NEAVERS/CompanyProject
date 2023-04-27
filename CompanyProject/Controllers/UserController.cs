using Bll;
using Common.Entities;
using Model;
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
    [PermissionFilter]
    public class UserController : Controller
    {

        UserManager _userManager = new UserManager();
        ResponseModel _response = new ResponseModel();
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

        
        [Auth]
        public ActionResult UserList(int index = 1, int size = 15, string key = "")
        {
            var result = _userManager.GetUserInfo(index, size, key);
            ViewBag.List = result.Result == null ? new List<UserInfo>() : (List<UserInfo>)result.Result;
            return View(ViewBag.List) ;
        }

        [Auth]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Auth]
        public ActionResult Create(UserInfo userInfo)
        {
            userInfo.UserId = Guid.NewGuid();
            userInfo.LastLoginTime = DateTime.Now;
            userInfo.CreateTime = DateTime.Now;
            if ( _userManager.AddUser(userInfo))
            {
                return Redirect("/User/UserList");
            }
            else 
                return View();
        }

        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
            string loginResult = "登录失败!";
            Guid userid = Guid.Empty;
            string permissions = "";
            //if (userName == "admin" && password == "123456")
            if ( _userManager.Login(userName, password, ref userid,ref permissions))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                    1,
                                    userName,
                                    DateTime.Now,
                                    DateTime.Now.Add(FormsAuthentication.Timeout),
                                    true,
                                    permissions
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