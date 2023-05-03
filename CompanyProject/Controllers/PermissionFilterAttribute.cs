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
                string userdate = ((FormsIdentity)(filterContext.HttpContext.User.Identity)).Ticket.UserData;
                filterContext.Controller.ViewBag.Permission = userdate;
            }
        }
    }
}