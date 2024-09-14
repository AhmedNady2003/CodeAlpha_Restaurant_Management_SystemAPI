using CodeAlpha_Event_Registration_SystemMVC.DBContext;
using CodeAlpha_Event_Registration_SystemMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_Event_Registration_SystemMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly MyDbContext _context;

        public EventController(MyDbContext context)
        {
            _context = context;
        }
        // GET: EventController
        public ActionResult Index()
        {
            var e = _context.Events.ToList();
            return View(e);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            var e = _context.Events.FirstOrDefault(e => e.Id == id);
            return View(e);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event e)
        {
            try
            {
                _context.Events.Add(e);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {


            var e = _context.Events.FirstOrDefault(e=> e.Id == id);

            return View(e);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Event e)
        {
            try
            {
                var NewEvent = _context.Events.Where(e => e.Id == e.Id).FirstOrDefault();
                NewEvent.Name = e.Name;
                NewEvent.Date = e.Date;
                NewEvent.Location = e.Location;
                _context.Events.Update(NewEvent);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            var e = _context.Events.FirstOrDefault(e => e.Id == id);
            
            return View(e);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Event e)
        {
            try
            {
                _context.Events.Attach(e);
                _context.Events.Remove(e);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
