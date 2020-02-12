using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    using Models;
    public class KategoriController : Controller
    {
        // GET: Kategori
        
        public ActionResult Index(int id)
        {

            return View(id);
        }
        public PartialViewResult KategoriWidget()
        {
            return PartialView(Context.Link.Kategoris.ToList());
        }
        public ActionResult MakaleListele(int id)
        {
            var data = Context.Link.Makales.Where(x => x.KategoriID == id).ToList();
            return View("MakaleListeleWidget", data);
        }
    }
}