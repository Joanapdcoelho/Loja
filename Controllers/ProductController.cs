using Loja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Loja.Controllers
{
    public class ProductController : Controller
    {
        //database
        private StoreContext db = new StoreContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int ? id)
        {
            //caso não ter id
            if (id == null)
            {
                return new HttpStatusCodeResult (HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
                return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();//guarda na BD
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int ? id) //campo id opcional
        {
            //caso não ter id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("product");
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int ? id)
        {
            //caso não ter id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product = db.Products.Find(id);
                    if (product == null)
                    {
                        return HttpNotFound();
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("product");
            }
            catch
            {
                return View(product);
            }
        }
    }
}
