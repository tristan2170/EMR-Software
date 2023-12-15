using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientPortalApplication.DAL;
using PatientPortalApplication.Models;

namespace PatientPortalApplication.Controllers
{
    public class PrescripController : Controller
    {
        private Context db = new Context();

        // GET: Prescrip
        public ActionResult Index()
        {
            var prescrips = db.Prescrips.Include(p => p.Patient);
            return View(prescrips.ToList());
        }

        // GET: Prescrip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescrips prescrips = db.Prescrips.Find(id);
            if (prescrips == null)
            {
                return HttpNotFound();
            }
            return View(prescrips);
        }

        // GET: Prescrip/Create
        public ActionResult Create()
        {
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "first_name");
            return View();
        }

        // POST: Prescrip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prescripId,prescriptions,patientId")] Prescrips prescrips)
        {
            if (ModelState.IsValid)
            {
                db.Prescrips.Add(prescrips);
                db.SaveChanges();
                return RedirectToAction("Index", "Patient", new { area = "" });
            }

            ViewBag.patientId = new SelectList(db.Patients, "patientId", "first_name",  prescrips.patientId);
            return View(prescrips);
        }

        // GET: Prescrip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescrips prescrips = db.Prescrips.Find(id);
            if (prescrips == null)
            {
                return HttpNotFound();
            }
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "first_name", prescrips.patientId);
            return View(prescrips);
        }

        // POST: Prescrip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prescripId,prescriptions,patientId")] Prescrips prescrips)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescrips).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Patient", new { area = "" });
            }
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "first_name", prescrips.patientId);
            return View(prescrips);
        }

        // GET: Prescrip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescrips prescrips = db.Prescrips.Find(id);
            if (prescrips == null)
            {
                return HttpNotFound();
            }
            return View(prescrips);
        }

        // POST: Prescrip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescrips prescrips = db.Prescrips.Find(id);
            db.Prescrips.Remove(prescrips);
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
