using Bll;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProject.Controllers
{
    public class UserController : Controller
    {

        UserManager _userManager = new UserManager();
        ResponseModel _response = new ResponseModel();
        // GET: User
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
            if ((userName == "admin" && password == "123456" )
                || _userManager.Login(userName,password,ref userid))
            {
                Session["userid"] = userid;
                loginResult = "登录成功";
                return Redirect("/Home/CarList");
            }
            ViewBag.loginResult = loginResult;
            return View();
        }

    }
}