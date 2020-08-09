using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstCrudProject.Controllers
{
    public class BaseController : Controller
    {
       protected override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
           

            if (Session["userID"] == null)
            {
                Response.Redirect("~/Login/Index");
            }
        }


    }
}