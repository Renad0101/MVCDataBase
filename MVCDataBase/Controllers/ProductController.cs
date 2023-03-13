using MVCDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataBase.Controllers
{
    public class ProductController : Controller
    {
        DBGR98Entities db = new DBGR98Entities();   
        // GET: Product

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.PRODUCTs.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(PRODUCT prod)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Add(prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            PRODUCT prod = db.PRODUCTs.Where(o => o.ID == id).SingleOrDefault();

            return View(prod);
        }




        [HttpPost]
        public ActionResult Edit(PRODUCT prod, int id)
        {
            PRODUCT realprod = db.PRODUCTs.Where(o => o.ID == id).SingleOrDefault();
            realprod.NAME = prod.NAME;
            realprod.MADED_BY = prod.MADED_BY;
            realprod.PRICE = prod.PRICE;
            realprod.PRODUCT_DATE = prod.PRODUCT_DATE;
            realprod.CATEGORY = prod.CATEGORY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            PRODUCT prod = db.PRODUCTs.Where(o => o.ID == id).SingleOrDefault();
            return View(prod);
        }




        [HttpPost]
        public ActionResult Delete(PRODUCT prod, int id)
        {
            PRODUCT data = db.PRODUCTs.Where(o => o.ID == id).SingleOrDefault();

            db.PRODUCTs.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Details(int id)
        {
            PRODUCT prod = db.PRODUCTs.Where(o => o.ID == id).SingleOrDefault();

            return View(prod);
        }
    }
}