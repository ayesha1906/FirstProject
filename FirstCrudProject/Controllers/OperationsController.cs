using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstCrudProject.Context;

namespace FirstCrudProject.Controllers
{
  [Authorize]
    public class OperationsController : Controller
    {
      db_coditasEntities dbObj = new db_coditasEntities();

        [Authorize(Roles ="Admin")]
        public ActionResult UserList()
        {
            var res = dbObj.user_reg.ToList();
            return View(res);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            //if(id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var img = dbObj.user_reg.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }

            var base64 = Convert.ToBase64String(img.ImageBinary);
            var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
            ViewBag.ImageData = imgsrc;

            return View(img);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(HttpPostedFileBase image1, user_reg model)
        {

            if (image1 != null)
            {
                model.ImageBinary = new byte[image1.ContentLength];
                image1.InputStream.Read(model.ImageBinary, 0, image1.ContentLength);
            }
            dbObj.Entry(model).State = EntityState.Modified;
            dbObj.SaveChanges();
            TempData["msg"] = "Record Updated";

            return RedirectToAction("UserList", "Operations");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var img = dbObj.user_reg.Find(id);

            if (img == null)
            {
                return HttpNotFound();
            }

            return View(img);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var res = dbObj.user_reg.Where(x => x.ID == id).First();
            dbObj.user_reg.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.user_reg.ToList();

            TempData["msg"] = "Data deleted !";
            return View("UserList", list);
        }

        //[AllowAnonymous]
        //public ActionResult About()
        //{
        //    ViewBag.Message = "My application description page.";

        //    return View();
        //}

        //[AllowAnonymous]
        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Contact page.";

        //    return View();
        //}


    }
}