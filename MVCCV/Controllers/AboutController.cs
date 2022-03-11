using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository repo = new AboutRepository();

        public ActionResult Index()
        {
            var interest = repo.List();
            return View(interest);
        }
        [HttpPost]
        public ActionResult Index(About i)
        {
            var h = repo.Find(x => x.ID == 1);
            h.Name = i.Name;
            h.Surname = i.Surname;
            h.Adress = i.Adress;
            h.Phone = i.Phone;
            h.Mail = i.Mail;
            h.Definition = i.Definition;
            h.Photograph = i.Photograph;
            repo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}