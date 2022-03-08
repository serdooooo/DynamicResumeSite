using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var exp = repo.List();
            return View(exp);
        }
        public ActionResult ExperienceAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ExperienceAdd(Experiences exp)
        {
            repo.TAdd(exp);

            return RedirectToAction("Index");
        }

        public ActionResult ExperienceDelete(int id)
        {
            Experiences t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceGet(int id)
        {
            Experiences t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult ExperienceGet(Experiences ex)
        {
            Experiences t = repo.Find(x => x.ID == ex.ID);
            t.Title = ex.Title;
            t.Subtitle = ex.Subtitle;
            t.ExperienceDate = ex.ExperienceDate;
            t.Definition = ex.Definition;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}