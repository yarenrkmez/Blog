using Blogg.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace Blogg.Controllers
{

    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            List<Yazar> yzr = Context.Link.Yazars.ToList();
            return View(yzr);
        }
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Yazar yzr, HttpPostedFileBase FileUpload)
        {
            Context.Link.Yazars.Add(yzr);

            //return RedirectToAction("Index", "Homee");
            int imgID = -1;
            if (FileUpload != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload.InputStream);

                int width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"].ToString());
                int height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"].ToString());
                string name = "/Content/YazarResim/" + Guid.NewGuid() + Path.GetExtension(FileUpload.FileName);
                Bitmap bm = new Bitmap(img, width, height);
                bm.Save(Server.MapPath(name));
                Resim i = new Resim();
                i.BuyukBoyut = name;
                Context.Link.Resims.Add(i);

                Context.Link.SaveChanges();
                if (i.RID != null)
                {
                    imgID = i.RID;
                }
            }
            if (imgID != -1)
                yzr.ResimID = imgID;


            Context.Link.SaveChanges();
            return RedirectToAction("Index", "Homee");

        }
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]

        public ActionResult GirisYap(string Email, string Sifre)
        {
            Yazar Ykullanici = Context.Link.Yazars.ToList().Where(x => x.Email.Equals(Email) && x.Sifre.Equals(Sifre)).FirstOrDefault();
       

       
            if (Ykullanici!=null)
                {
                //ApplicationUser currentUser = UserManagerExtensions.FindById(User.Identity.GetUserId());

                //string ID = currentUser.Id;
                //string Email = currentUser.Email;
           

                return RedirectToAction("Index", "Homee");
            }


            ViewBag.mesaj = "Kullanici yok.";

            return RedirectToAction("GirisYap", "Yazar");

        }
    }
}