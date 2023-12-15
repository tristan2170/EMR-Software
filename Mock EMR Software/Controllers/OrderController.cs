using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Mock_EMR_Software.DAL;
using Mock_EMR_Software.Models;

namespace Mock_EMR_Software.Controllers
{
    public class OrderController : Controller
    {
        private Context _dbContext = new();

        public OrderController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Prescrip
        public ActionResult Index()
        {
            var orders = _dbContext.Orders.Include(p => p.Patient);
            return View(orders.ToList());
        }

        // GET: Prescrip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Orders order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: Prescrip/Create
        public ActionResult Create()
        {
            ViewBag.patientGUID = new SelectList(_dbContext.Patients, "patientGUID", "firstName");
            return View();
        }

        // POST: Prescrip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("orderGUID, Orders, patientGUID")] Orders order)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Patient", new { area = "" });
            }

            ViewBag.patientGUID = new SelectList(_dbContext.Patients, "patientGUID", "firstName", order.patientGUID);
            return View(order);
        }

        // GET: Prescrip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Orders order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }
            ViewBag.patientGUID = new SelectList(_dbContext.Patients, "orderGUID", "firstName", order.patientGUID);
            return View(order);
        }

        // POST: Prescrip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("orderGUID, Orders, patientGUID")] Orders order)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(order).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Details", "Patient", new { area = "" });
            }
            ViewBag.patientId = new SelectList(_dbContext.Patients, "patientGUID", "firstName", order.patientGUID);
            return View(order);
        }

        // GET: Prescrip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Orders order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Prescrip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders order = _dbContext.Orders.Find(id);
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
