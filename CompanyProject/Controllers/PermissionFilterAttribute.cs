using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CompanyProject.Controllers
{
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string userdata = ((FormsIdentity)(filterContext.HttpContext.User.Identity)).Ticket.UserData;
                var data = userdata.Split('_');
                filterContext.Controller.ViewBag.Permission = data[0];
                if(data.Length > 1)
                {
                    filterContext.Controller.ViewBag.UserName = data[1];
                }

            }
        }
    }
}