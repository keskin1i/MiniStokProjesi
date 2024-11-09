using _50DersteMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50DersteMvc.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index()
        {
            var deger = db.TBLURUNLER.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger = (from i in db.TBLKATEGORILER.ToList()
                                          select new SelectListItem
                                          {
                                              Text=i.KATEGORIAD,
                                              Value=i.KATEGORIID.ToString()
                                          }).ToList();
            ViewBag.deger = deger;  

            return View(); 
        }

        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var deger = db.TBLKATEGORILER.Where(x=>x.KATEGORIID==p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = deger;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var deger = db.TBLURUNLER.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORILER.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.KATEGORIAD,
                                              Value = i.KATEGORIID.ToString()
                                          }).ToList();
            ViewBag.deger = deger1;
            return View("UrunGetir", deger);

        }

        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var deger = db.TBLURUNLER.Find(p1.URUNID);
            deger.URUNAD = p1.URUNAD;
            deger.MARKA = p1.MARKA;
           // deger.URUNKATEGORI = p1.URUNKATEGORI;
            deger.FIYAT = p1.FIYAT;
            deger.STOK = p1.STOK;
            deger.MARKA = p1.MARKA;
            //Bu kısım Önemli Bak...
            var deger1 = db.TBLKATEGORILER.Where(x => x.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            deger.URUNKATEGORI = deger1.KATEGORIID;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}