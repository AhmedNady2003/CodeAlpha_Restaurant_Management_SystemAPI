using CodeAlpha_Event_Registration_SystemMVC.DBContext;
using CodeAlpha_Event_Registration_SystemMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_Event_Registration_SystemMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MyDbContext _context;

        public RegistrationController(MyDbContext context)
        {
            _context = context;
        }
        // GET: RegistrationController
        public ActionResult Index()
        {
            var r = _context.Registrations.ToList();
            return View(r);
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            var r = _context.Registrations.FirstOrDefault(e => e.Id == id);
            return View(r);
        }



        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {


            var e = _context.Registrations.FirstOrDefault(e => e.Id == id);

            return View(e);
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration r)
        {
            try
            {
                var NewRegistration = _context.Registrations.Where(e => e.Id == e.Id).FirstOrDefault();
                NewRegistration.UserName = r.UserName;
                NewRegistration.EventId = r.EventId;
                NewRegistration.Email = r.Email;
                _context.Registrations.Update(NewRegistration);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            var r = _context.Registrations.FirstOrDefault(r => r.Id == id);

            return View(r);
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Registration r)
        {
            try
            {
                _context.Registrations.Attach(r);
                _context.Registrations.Remove(r);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: RegistrationController/Create
        
        public IActionResult Create(int id)
        {
            var e = _context.Events.FirstOrDefault(e => e.Id == id);
            var r = new Registration() { EventId = e.Id };
            return View(r);
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Registration registration)
        {

            try
            {
                

                _context.Registrations.Add(registration);
                _context.SaveChangesAsync();
                return RedirectToAction("Details", "Event", new { id = registration.EventId });
            }
            catch
            {
                return View();
            }
            
        }
    }
}
