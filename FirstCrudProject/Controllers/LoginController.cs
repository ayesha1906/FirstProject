using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FirstCrudProject.Context;

namespace FirstCrudProject.Controllers
{
    
    public class LoginController : Controller
    {
        db_coditasEntities dbObj = new db_coditasEntities();
        // GET: Login
        public ActionResult Index()
        {
            //if (Session["userID"] != null)
            //{
            //    Response.Redirect("~/Dashboard");
            //}

            return View();
        }

        [HttpPost]
        public ActionResult Authorize(user_reg model)
        {
            var userDetails = dbObj.user_reg.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if(userDetails == null)
            {
                ViewBag.LoginErrorMessage = "Wrong usermame or password !";
                return View("Index", model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Email , false);

                //Session["userID"] = userDetails.ID;
                Session["userName"] = userDetails.First_Name;
                return RedirectToAction("Index", "Dashboard");
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(HttpPostedFileBase image1, user_reg model)
        {
            if (dbObj.user_reg.Any(x => x.Email == model.Email))
            {
                ViewBag.DuplicateMsg = "Email already exists.";
                return View("Register", model);
            }

            if (image1 != null)
            {
                model.ImageBinary = new byte[image1.ContentLength];
                image1.InputStream.Read(model.ImageBinary, 0, image1.ContentLength);
            }
            dbObj.user_reg.Add(model);
            dbObj.SaveChanges();
            return RedirectToAction("Index", "Login");
        }

        
        public ActionResult LogOut()
        {
            //Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "My application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

    }
}