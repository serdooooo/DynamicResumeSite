using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo = new CertificateRepository();
        public ActionResult Index()
        {
            var cer = repo.List();
            return View(cer);
        }
        public ActionResult CertificateGet(int id)
        {
            Certificate c = repo.Find(x => x.ID == id);
            return View(c);
        }
        [HttpPost]
        public ActionResult CertificateGet(Certificate cer)
        {
            Certificate c = repo.Find(x => x.ID == cer.ID);
            c.CertificateDate = cer.CertificateDate;
            c.Definition = cer.Definition;
            repo.TUpdate(c);
            return RedirectToAction("Index");
        }
        public ActionResult CertificateDelete(int id)
        {
            Certificate c = repo.Find(x => x.ID == id);
            repo.TDelete(c);
            return RedirectToAction("Index");
        }
        public ActionResult CertificateAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CertificateAdd(Certificate c)
        {
            repo.TAdd(c);
            return RedirectToAction("Index");
        }
    }
}