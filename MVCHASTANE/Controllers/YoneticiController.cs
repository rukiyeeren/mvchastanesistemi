using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHASTANE.Controllers
{
    
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        
        public ActionResult yoneticigiris()
        {
            return View();
        }
    }
}