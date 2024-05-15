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
            var documents = _dbContext.Documents.Include(c => c.Patient);
            return View(documents.ToList());
        }

        // Detailed info on the instance of this order
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var documents = await _dbContext.Documents.FirstOrDefaultAsync(c => c.patientGUID == id);
                    
            if (documents == null)
            {   
                return NotFound();  
            }
            return View(documents);
        }

        // GET: Comment/Create
        public ActionResult Create(int? id)
        {

            List<string> document_list = DocumentReader.main();

            ViewBag.AvailableDocuments = new SelectList(document_list);
            ViewBag.CurrentDateTime = DateTime.Now;
            ViewBag.patientGUID = id;
            //Redirect to the Patient Details page
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("documentGUID, documentName, Body, Date, patientGUID")] Documents document)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Documents.Add(document);
                _dbContext.SaveChanges();
                //Redirect to the Patient Details page
                return RedirectToAction("Index", "Patient", new { area = "" });
            }

            return View(document);

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
