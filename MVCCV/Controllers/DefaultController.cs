using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var degerler = db.About.ToList();
            return View(degerler);
        }
        public PartialViewResult SocialMedia()
        {
            var social = db.SocialMedia.Where
                (x => x.Status == true).ToList();
            return PartialView(social);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Educations()
        {
            var educations = db.Education.ToList();
            return PartialView(educations);
        }
        public PartialViewResult Skills()
        {
            var skills = db.Skills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Interest()
        {
            var interests = db.Interest.ToList();
            return PartialView(interests);
        }
        public PartialViewResult Certificate()
        {
            var certificates = db.Certificate.ToList();
            return PartialView(certificates);
        }
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Communication con)
        {
            con.CommunicationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Communication.Add(con);
            db.SaveChanges();
            return PartialView();
        }
    }
}