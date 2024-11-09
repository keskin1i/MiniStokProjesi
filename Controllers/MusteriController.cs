using _50DersteMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50DersteMvc.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();

        public ActionResult Index(string p)
        {
            var deger = from i in db.TBLMUSTERILER select i;
            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(x => x.MUSTERIAD.Contains(p));
            }

            // Materialize the query into a list
            var musteriler = deger.ToList();

            return View(musteriler);
        }

        [HttpGet]
        public ActionResult MusteriEkle() { return View(); }

        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TBLMUSTERILER.Add (p1);
            db.SaveChanges ();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(int id)
        {
            var deger = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var deger = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", deger);

        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var deger = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            deger.MUSTERIAD = p1.MUSTERIAD;
            deger.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }

    
}