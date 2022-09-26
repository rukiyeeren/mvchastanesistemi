using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHASTANE.Models.Entity;

namespace MVCHASTANE.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        MVCHASTANEEntities db = new MVCHASTANEEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult iletisim()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult iletisim(tbl_iletisim p1)
        {
            db.tbl_iletisim.Add(p1);
            db.SaveChanges();
            return RedirectToAction("iletisim");
        }
        [AllowAnonymous]
        public ActionResult hakkımızda()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult doktorlar()
        {
            return View();
        }
    }
}