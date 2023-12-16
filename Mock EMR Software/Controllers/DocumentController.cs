using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mock_EMR_Software.DAL;
using Mock_EMR_Software.Models;

    
namespace Mock_EMR_Software.Controllers
{
    public class DocumentController : Controller
    {
        private readonly Context _dbContext;

        public DocumentController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Comment
        public ActionResult Index() 
        {
            var documents = _dbContext.Comments.Include(c => c.Patient);
            return View(documents.ToList());
        }

        // Handles the detailed info of a patient (?)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var documents = await _dbContext.Comments.FirstOrDefaultAsync(m => m.patientGUID == id);
                    
            if (documents == null)
            {   
                return NotFound();  
            }
            return View(documents);
        }

        // GET: Comment/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.patientId = new SelectList(_dbContext.Patients, "patientGUID", "firstName");
            //Redirect to the Patient Details page
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("documentGUID, Body, Date, patientGUID")] Documents documents)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Comments.Add(documents);
                _dbContext.SaveChanges();
                //Redirect to the Patient Details page
                return this.RedirectToAction("Index", "Patient", new { area = "" });
            }

            ViewBag.patientId = new SelectList(_dbContext.Patients, "patientGUID", "firstName", documents.patientGUID);
            return View(documents);

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
