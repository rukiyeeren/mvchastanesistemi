using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCHASTANE.Models.Entity;

namespace MVCHASTANE.Controllers
{
    public class SecurityController : Controller
    {
        MVCHASTANEEntities db = new MVCHASTANEEntities();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
         [AllowAnonymous]
        public ActionResult Login(tbl_giris p)
        {
            var kullanici = db.tbl_giris.FirstOrDefault(x=>x.kullaniciad==p.kullaniciad&&x.kullanicisifre==p.kullanicisifre);
            if (kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.kullaniciad, false);
        
                return RedirectToAction("yoneticigiris","Yonetici");
            }
            ViewBag.mesaj = "kullanıcı adı veya şifreyi doğru giriniz";
            return View();
        }
    }
}