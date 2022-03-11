using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo = new ContactRepository();
        public ActionResult Index()
        {
            var con = repo.List();
            return View(con);
        }
    }
}