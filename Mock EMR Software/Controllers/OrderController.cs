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
        private Context _dbContext;

        public OrderController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Order
        public ActionResult Index()
        {
            var orders = _dbContext.Orders.Include(p => p.Patient);
            return View(orders.ToList());
        }

        // GET: Order/Details/5
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

        // GET: Order/Create
        public ActionResult Create(int? id)
        {
            List<string> JsonOrderList = OrderReader.main();
            ViewBag.AvailableOrders = new SelectList(JsonOrderList);
            ViewBag.CurrentDateTime = DateTime.Now;
            ViewBag.patientGUID = id;

            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("orderName, Frequency, DateOrdered, patientGUID")] Orders order)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Patient", new { area = "" });
            }

            return View(order);
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
