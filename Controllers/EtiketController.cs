using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    using Models;
    public class EtiketController : Controller
    {
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult EtiketlerWidget()
        {
            return PartialView(Context.Link.Etikets.ToList());
        }

        public ActionResult MakaleListele(int id)
        {
            var data = Context.Link.Makales.Where
                (x => x.Etikets.Any(y => y.EID == id)).ToList();
            return View("MakaleListeleWidget",data);
        }
    }
}