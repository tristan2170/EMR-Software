using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mock_EMR_Software.DAL;
using Mock_EMR_Software.Models;

    
namespace Mock_EMR_Software.Controllers
{
    public class CommentController : Controller
    {
        private readonly Context _dbContext = new();

        public CommentController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Comment
        public ActionResult Index() 
        {
            var comments = _dbContext.Comments.Include(c => c.Patient);
            return View(comments.ToList());
        }

        // Handles the detailed info of a patient (?)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var comments = await _dbContext.Comments.FirstOrDefaultAsync(m => m.patientGUID == id);
                    
            if (comments == null)
            {   
                return NotFound();  
            }
            return View(comments);
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
        public async Task<ActionResult> Create([Bind("commentId,comment,date,patientGUID")] Documents comments)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Comments.Add(comments);
                _dbContext.SaveChanges();
                //Redirect to the Patient Details page
                return this.RedirectToAction("Index", "Patient", new { area = "" });
            }

            ViewBag.patientId = new SelectList(_dbContext.Patients, "patientGUID", "firstName", comments.patientGUID);
            return View(comments);

        }

        // GET: Comment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Documents comments = _dbContext.Comments.Find(id);

            if (comments == null)
            {
                return NotFound();
            }
            ViewBag.patientId = new SelectList(_dbContext.Patients, "patientId", "firstName", comments.patientGUID);
            return View(comments);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("commentId,comment,date,patientId")] Documents comments)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(comments);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Patient", new { area = "" });
            }
            ViewBag.patientId = new SelectList(_dbContext.Patients, "patientGUID", "first_name", comments.patientGUID);
            return View(comments);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Documents comments = _dbContext.Comments.Find(id);

            if (comments == null)
            {
                return NotFound();
            }
            return View(comments);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documents comments = _dbContext.Comments.Find(id);
            _dbContext.Comments.Remove(comments);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Patient", new { area = "" });
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
