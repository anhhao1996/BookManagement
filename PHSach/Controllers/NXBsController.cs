﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PHSach.Models;

namespace PHSach.Controllers
{
    public class NXBsController : Controller
    {
        private PhatHanhSachEntities db = new PhatHanhSachEntities();

        // GET: NXBs
        public ActionResult Index()
        {
            return View(db.NXBs.ToList());
        }

        // GET: NXBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NXB nXB = db.NXBs.Find(id);
            if (nXB == null)
            {
                return HttpNotFound();
            }
            return View(nXB);
        }

        // GET: NXBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NXBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NXB_id,NXB_name,Address,AcountNumber,Phone,Email")] NXB nXB)
        {
            if (ModelState.IsValid)
            {
                db.NXBs.Add(nXB);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(nXB);
        }

        // GET: NXBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NXB nXB = db.NXBs.Find(id);
            if (nXB == null)
            {
                return HttpNotFound();
            }
            return View(nXB);
        }

        // POST: NXBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NXB_id,NXB_name,Address,AcountNumber,Phone,Email")] NXB nXB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nXB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nXB);
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
