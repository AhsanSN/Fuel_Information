using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FuelInformaton.Models;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace FuelInformaton.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        PricesEntities db = new PricesEntities();
        public ActionResult Index(int n=3,string type="Petrol")
        {
            var ls = db.Fuels.Where(q => q.Fuel_type == type).ToList();
            var hs= ls.Take(3);
            if (ls.Count > 3)
            {
                hs = ls.Skip(ls.Count - n);
                hs=hs.Take(n);
            }
            return View(hs);
        }

        // GET: Price/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Price/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            Fuel fuel= new Fuel();
            fuel.Data_modified = DateTime.Today.Date;
            return View(fuel);
        }

        // POST: Price/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                //cagtegory.SecretCode = GenerateSecretCode();
                db.Fuels.Add(fuel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuel);
        }

        // GET: Price/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Price/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Price/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Price/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
