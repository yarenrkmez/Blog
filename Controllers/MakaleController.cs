using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    using Models;
    public class MakaleController : Controller
    {
        // GET: Makale
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detay(int id)
        {
            var data = Context.Link.Makales.FirstOrDefault(x => x.MakaleID == id);
            return View(data);
        }
    }
}