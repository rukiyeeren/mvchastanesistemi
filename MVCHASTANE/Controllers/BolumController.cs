using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHASTANE.Models.Entity;

namespace MVCHASTANE.Controllers
{
    public class BolumController : Controller
    {
        // GET: Bolum
        MVCHASTANEEntities db = new MVCHASTANEEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var deger = db.tbl_bolum.ToList();
            return View(deger);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Yenibolum()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Yenibolum(tbl_bolum p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenibolum");
            }

            db.tbl_bolum.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult bolumgetir(int id)
        {
            var bol = db.tbl_bolum.Find(id);
            return View("bolumgetir", bol);
        }
        [AllowAnonymous]
        public ActionResult Guncelle(tbl_bolum p1)
        {
            var dr = db.tbl_bolum.Find(p1.bolumid);
            dr.bolumad = p1.bolumad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [AllowAnonymous]
        public ActionResult Sil(int id)
        {
            var bolum = db.tbl_bolum.Find(id);
            db.tbl_bolum.Remove(bolum);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }

}
