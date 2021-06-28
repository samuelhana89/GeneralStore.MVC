using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(_db.products.ToList());
        }

        // GET: Product
        public ActionResult Create()
        {
            return View();
        }

        // Post: Product
        [HttpPost]
        public ActionResult Create( Product product)
        {
            if (ModelState.IsValid)
            {
                _db.products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get : Delete : {id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        //post : Delete : {id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int id)
        {
            Product product = _db.products.Find(id);
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Get : Delete : {id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        //post : Edit : {id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //Get : Details : {id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}