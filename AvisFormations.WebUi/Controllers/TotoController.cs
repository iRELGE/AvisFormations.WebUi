using AvisFormations.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormations.WebUi.Controllers
{
    public class TotoController : Controller
    {
        // GET: Toto
        public ActionResult Index()
        {
            MyViewModel mv = new MyViewModel();
            mv.message = "Message dynamic";


            return View(mv);
        }

        public ActionResult MyModelViews(string a="")
        {
            
            return View(a);

        }
        
    }
}