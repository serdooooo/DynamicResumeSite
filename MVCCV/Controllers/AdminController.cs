using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class AdminController : Controller
    {
        
        // GET: Admin
        AdminRepository repo = new AdminRepository();
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        public ActionResult AdminAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Login log)
        {
            repo.TAdd(log);

            return RedirectToAction("/Index");
        }

        public ActionResult AdminDelete(int id)
        {
            Login t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("/Index");
        }
        public ActionResult AdminEdit(int id)
        {
            Login t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminEdit(Login log)
        {
            Login t = repo.Find(x => x.ID == log.ID);
            t.Username = log.Username;
            t.Password = log.Password;
            repo.TUpdate(t);
            return RedirectToAction("/Index");
        }
    }
}