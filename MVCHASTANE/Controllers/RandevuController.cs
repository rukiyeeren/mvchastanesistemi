using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHASTANE.Models.Entity;

namespace MVCHASTANE.Controllers
{
    public class RandevuController : Controller
    {
        // GET: Randevu
      
        MVCHASTANEEntities db = new MVCHASTANEEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var deger = db.tbl_randevu.ToList();
            return View(deger);
        }
        [AllowAnonymous]
        [HttpGet]

        public ActionResult Yenirandevu()
        {

            List<SelectListItem> doktor = (from i in db.tbl_doktor.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.doktoradisoyadi,
                                               Value = i.doktorid.ToString()
                                           }
                                   ).ToList();
            List<SelectListItem> bolum = (from i in db.tbl_bolum.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.bolumad,
                                              Value = i.bolumid.ToString()
                                          }
                                  ).ToList();


            ViewBag.dok = doktor;
            ViewBag.blm = bolum;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]

        public ActionResult Yenirandevu(tbl_randevu p1)
        {
            if (p1.randevuadsoyad == null || p1.randevutcno == null || p1.randevutel == null || p1.randevutarihsaat == null)
            {
                List<SelectListItem> doktor = (from i in db.tbl_doktor.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.doktoradisoyadi,
                                                   Value = i.doktorid.ToString()
                                               }
                                 ).ToList();
                List<SelectListItem> bolum = (from i in db.tbl_bolum.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.bolumad,
                                                  Value = i.bolumid.ToString()
                                              }
                                      ).ToList();


                ViewBag.dok = doktor;
                ViewBag.blm = bolum;
                return View();
            }
            else
            {
                var dok = db.tbl_doktor.Where(m => m.doktorid == p1.tbl_doktor.doktorid).FirstOrDefault();
                var bol = db.tbl_bolum.Where(m => m.bolumid == p1.tbl_bolum.bolumid).FirstOrDefault();
                p1.tbl_doktor = dok;
                p1.tbl_bolum = bol;
                db.tbl_randevu.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Yenirandevu");
            }


        }

        public ActionResult randevugetir(int id)
        {
            var ran = db.tbl_randevu.Find(id);
            List<SelectListItem> doktor = (from i in db.tbl_doktor.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.doktoradisoyadi,
                                               Value = i.doktorid.ToString()
                                           }
                                   ).ToList();
            List<SelectListItem> bolum = (from i in db.tbl_bolum.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.bolumad,
                                              Value = i.bolumid.ToString()
                                          }
                                  ).ToList();


            ViewBag.dok = doktor;
            ViewBag.blm = bolum;
            return View("randevugetir", ran);

        }
        public ActionResult Guncelle(tbl_randevu p1)
        {
            var dok = db.tbl_doktor.Where(m => m.doktorid == p1.tbl_doktor.doktorid).FirstOrDefault();
            var bol = db.tbl_bolum.Where(m => m.bolumid == p1.tbl_bolum.bolumid).FirstOrDefault();
            var rn = db.tbl_randevu.Find(p1.randevuid);
            rn.randevuadsoyad = p1.randevuadsoyad;
            rn.randevutcno = p1.randevutcno;
            rn.randevutel = p1.randevutel;
            rn.randevudoktorid = p1.randevudoktorid;
            rn.randevubolumid = p1.randevubolumid;
            rn.randevutarihsaat = p1.randevutarihsaat;
            


            db.SaveChanges();
            return View();

        }
        public ActionResult Sil(int id)
        {
            var randevu = db.tbl_randevu.Find(id);
            db.tbl_randevu.Remove(randevu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}