using _50DersteMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50DersteMvc.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(TBLSATISLAR p1)
        {
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}