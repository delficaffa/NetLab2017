﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthwindApp;

namespace NorthwindApp.Controllers
{
    public class TerritoriesController : Controller
    {
        private BaseDatos db = new BaseDatos();

        // GET: Territories
        public ActionResult Index()
        {
            var territories = db.Territories.Include(t => t.Region);
            return View(territories.ToList());
        }

        // GET: Territories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territories territories = db.Territories.Find(id);
            if (territories == null)
            {
                return HttpNotFound();
            }
            return View(territories);
        }

        // GET: Territories/Create
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription");
            return View();
        }

        // POST: Territories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerritoryID,TerritoryDescription,RegionID")] Territories territories)
        {
            if (ModelState.IsValid)
            {
                db.Territories.Add(territories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", territories.RegionID);
            return View(territories);
        }

        // GET: Territories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territories territories = db.Territories.Find(id);
            if (territories == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", territories.RegionID);
            return View(territories);
        }

        // POST: Territories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerritoryID,TerritoryDescription,RegionID")] Territories territories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(territories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", territories.RegionID);
            return View(territories);
        }

        // GET: Territories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territories territories = db.Territories.Find(id);
            if (territories == null)
            {
                return HttpNotFound();
            }
            return View(territories);
        }

        // POST: Territories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Territories territories = db.Territories.Find(id);
            db.Territories.Remove(territories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
