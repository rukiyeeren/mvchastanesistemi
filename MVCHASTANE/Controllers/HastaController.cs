using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHASTANE.Models.Entity;

namespace MVCHASTANE.Controllers
{
    [AllowAnonymous]
    public class HastaController : Controller
    {
        // GET: Hasta
        MVCHASTANEEntities db = new MVCHASTANEEntities();
   
        public ActionResult Index()
        {
            var deger = db.tbl_hasta.ToList();
            return View(deger);
        }
        [HttpGet]

        public ActionResult Yenihasta()
        {

            return View();
        }
        [HttpPost]

        public ActionResult Yenihasta(tbl_hasta p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenihastar");
            }

            db.tbl_hasta.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult hastagetir(int id)
        {
            var dok = db.tbl_hasta.Find(id);
            return View("Hastagetir", dok);
        }
        public ActionResult Guncelle(tbl_hasta p1)
        {
            var dr = db.tbl_hasta.Find(p1.hastaid);
            dr.hastaadsoyad = p1.hastaadsoyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var hasta = db.tbl_hasta.Find(id);
            db.tbl_hasta.Remove(hasta);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }

}