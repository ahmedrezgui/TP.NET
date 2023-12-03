using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MembershipTypeController : Controller
    {
        private readonly AppDbContext _db;

        public MembershipTypeController(AppDbContext db)
        { _db = db; }

        // GET: MembershiptypeController
        public ActionResult Index()
        {
            List<MembershipType> member = _db.MembershipType.ToList();
            return View(member);
        }

        // GET: MembershiptypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershiptypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembershipType m)
        {

            m.Id = new Guid();
            _db.MembershipType.Add(m);
            _db.SaveChanges();


            return RedirectToAction(nameof(Index));


        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembershiptypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembershiptypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
