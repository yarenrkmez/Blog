using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blogg.Models;

namespace Blogg.Controllers
{
    using App_Classes;
    public class HomeeController : Controller
    {


        // GET: Homee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MakaleListele()
        {
            var data = Context.Link.Makales.ToList();
            return View("MakaleListeleWidget", data);

        }

        public PartialViewResult PopulerMakaleler()
        {
            var model = Context.Link.Makales.OrderByDescending(x => x.EklenmeTarihi).Take(3).ToList();
            return PartialView(model);
        }

    }
}