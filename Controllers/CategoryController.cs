using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMvc.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace _50DersteMvc.Controllers
{
    public class CategoryController : Controller
    {
       MvcDbStokEntities1 db = new MvcDbStokEntities1();
        

        public ActionResult Index(int sayfa=1)
        {
            //var deger = db.TBLKATEGORILER.ToList();
            var deger = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(deger);
        }

        [HttpGet]
        public ActionResult CategoryEkle() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryEkle(TBLKATEGORILER p1) 
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryEkle");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategorySil(int id) 
        {
            var deger = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryGetir(int id) 
        {
            var deger = db.TBLKATEGORILER.Find(id);
            return  View("CategoryGetir",deger);

        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var deger = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            deger.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}