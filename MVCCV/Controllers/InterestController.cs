using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        InterestRepository repo = new InterestRepository();
        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }
        [HttpPost]
        public ActionResult Index(Interest i)
        {
            var h = repo.Find(x => x.ID == 1);
            h.Definition1 = i.Definition1;
            h.Definition2 = i.Definition2;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}