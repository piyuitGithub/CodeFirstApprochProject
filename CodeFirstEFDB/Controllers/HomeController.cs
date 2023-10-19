using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstEFDB.Models;

namespace CodeFirstEFDB.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Users.ToList();
            return View(data);
           
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(User s)
        {
            db.Users.Add(s);
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["InsertMessage"] = "<script>alert('Data Inserted !!')</script>";

                return RedirectToAction("Index");
            }

            else
            {
                ViewBag.InsertMessage = "<script>('Data Not Inserted !!')</script>";
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Users.Where(model => model.id == id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]

        public ActionResult Edit(User s)
        {
            db.Entry(s).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {

                TempData["UpdatedMessage"] = "<script>alert('Data Updated !!')</script>";
                return RedirectToAction("Index");
            }

            else
            {

                ViewBag.UpdatedMessage = "<script>alert('Data Not Updated !!')</script>";
            }

            return View(s);
        }

        public ActionResult Delete(int id)

        {
            var row = db.Users.Where(model => model.id == id).FirstOrDefault();
            return View();

        }
        [HttpPost]
        public ActionResult Delete(User s)
        {
            db.Entry(s).State = EntityState.Modified;
            int a = db.SaveChanges();

            if (a > 0)
            {
                TempData["DeletedMessage"] = "<script>alert('Data Deleted')</script>";

                return RedirectToAction("Index");

            }

            else
            {
                ViewBag.DeletedMessage = "<script>alert('Data Not Deleted')</script>";

            }
            return View(s);
        }

        public ActionResult Details(int id)
        {
            var DetailsById = db.Users.Where(model => model.id == id).FirstOrDefault();
            return View(DetailsById);
        }
    }
}






   