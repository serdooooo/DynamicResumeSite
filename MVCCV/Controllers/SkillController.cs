using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Repositories;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillRepository srp = new SkillRepository();
        public ActionResult Index()
        {
            var skl = srp.List();
            return View(skl);
        }
        public ActionResult SkillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillAdd(Skills _skill)
        {
            srp.TAdd(_skill);
            return RedirectToAction("Index");
        }
        public ActionResult SkillDelete(int id)
        {
            Skills dlt = srp.Find(x => x.ID == id);
            srp.TDelete(dlt);
            return RedirectToAction("Index");
        }
        public ActionResult SkillGet(int id)
        {
            Skills s = srp.Find(x => x.ID == id);
            return View(s);
        }
        [HttpPost]
        public ActionResult SkillGet(Skills s)
        {
            Skills skl = srp.Find(x => x.ID == s.ID);
            skl.Ratio = s.Ratio;
            skl.Skill = s.Skill;
            srp.TUpdate(skl);
            return RedirectToAction("Index");
        }
    }
}