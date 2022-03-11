using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository repo = new SocialMediaRepository();
        public ActionResult Index()
        {
            var datas = repo.List();
            return View(datas);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SocialMedia s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var account = repo.Find(x => x.ID == id);
            return View(account);
        }
        [HttpPost]
        public ActionResult Edit(SocialMedia sm)
        {
            var account = repo.Find(x => x.ID == sm.ID);
            account.SocialName = sm.SocialName;
            account.Link = sm.Link;
            account.Icon = sm.Icon;
            account.Status = true;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var account = repo.Find(x => x.ID == id);
            account.Status = false;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
    }
}