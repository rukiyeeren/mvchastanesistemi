using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHASTANE.Models.Entity;
namespace MVCHASTANE.Controllers
{
    public class DoktorController : Controller
    {
        // GET: Doktor
        MVCHASTANEEntities db = new MVCHASTANEEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var deger = db.tbl_doktor.ToList();
            return View(deger);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Yenidoktor()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Yenidoktor(tbl_doktor p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenidoktor");
            }

            db.tbl_doktor.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult doktorgetir(int id)
        {
            var dok = db.tbl_doktor.Find(id);
            return View("Doktorgetir", dok);
        }
        [AllowAnonymous]
        public ActionResult Guncelle(tbl_doktor p1)
        {
            var dr = db.tbl_doktor.Find(p1.doktorid);
            dr.doktoradisoyadi = p1.doktoradisoyadi;
            dr.doktorbolum = p1.doktorbolum;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [AllowAnonymous]
        public ActionResult Sil(int id)
        {
            var doktor = db.tbl_doktor.Find(id);
            db.tbl_doktor.Remove(doktor);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }

}
