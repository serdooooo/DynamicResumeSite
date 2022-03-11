using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{

    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();

        public ActionResult Index()
        {
            var edu = repo.List();
            return View(edu);
        }
        public ActionResult EducationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EducationAdd(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationAdd");
            }
            repo.TAdd(education);
            return RedirectToAction("Index");
        }
        public ActionResult EducationDelete(int id)
        {
            Education edu = repo.Find(x => x.ID == id);
            repo.TDelete(edu);
            return RedirectToAction("Index");
        }
        public ActionResult EducationGet(int id)
        {
            Education edu = repo.Find(x => x.ID == id);
            return View(edu);
        }
        [HttpPost]
        public ActionResult EducationGet(Education edu)
        {

            if (!ModelState.IsValid)
            {
                return View("EducationGet");
            }
            Education e = repo.Find(x => x.ID == edu.ID);
            e.Title = edu.Title;
            e.Subtitle1 = edu.Subtitle1;
            e.Subtitle2 = edu.Subtitle2;
            e.GNO = edu.GNO;
            e.EducationDate = edu.EducationDate;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}