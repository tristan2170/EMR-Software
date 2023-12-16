using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mock_EMR_Software.DAL;
using Mock_EMR_Software.Models;
using Mock_EMR_Software.ViewModel;


namespace Mock_EMR_Software.Controllers
{
    public class PatientController : Controller
    {
        private readonly Context _dbContext;

        public PatientController(Context dbContext)
        {
            _dbContext = dbContext;    
        }


        // GET: Patient
        public ActionResult Index()
        {
            return View(_dbContext.Patients.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Patient patient = _dbContext.Patients
                .Include(a => a.Documents)
                .Include(b => b.Orders)
                .Include(c => c.Patients)
                .Where(a => a.patientGUID == id)
                .Where(b => b.patientGUID == id)
                .Where(c => c.patientGUID == id)
                .FirstOrDefault();
                
                
            if (patient == null)
            {
                return NotFound();
            }

            var view = new DetailView
            {
                Documents = patient.Comments.ToList(),
                Orders = patient.Orders.ToList(),
                Patients = patient.Patients.ToList()
            };
        
            return View(view);
        }

       

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,first_name,last_name,date_admitted")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Patients.Add(patient);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Patient patient = _dbContext.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,first_name,last_name,date_admitted")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(patient);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Patient patient = _dbContext.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = _dbContext.Patients.Find(id);
            _dbContext.Patients.Remove(patient);
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
