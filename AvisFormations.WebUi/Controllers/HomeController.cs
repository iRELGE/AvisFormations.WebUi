using AvisFormations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvisFormations;
using AvisFormations.WebUi.Models;



namespace AvisFormations.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vml = new List<ViewFormationAvisModel>();
            var listFormations = new List<Formation>();
            using (var context = new AvisEntities())
            {
                listFormations = context.Formations.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
                foreach(var l in listFormations)
                {
                    var vm = new ViewFormationAvisModel();
                    vm.id = l.Id;
                    vm.nom = l.Nom;
                    vm.url = l.Url;
                    vm.description = l.Description;
                    vm.nomseo = l.NomSeo;
                    vm.nombreAvis = l.Avis.Count();
                    if (l.Avis.Count > 0)
                    {
                        vm.noteFormation = l.Avis.Average(f => f.Note);
                    }
                    else
                    {
                        vm.noteFormation = 0;
                    }
                    vm.avis = l.Avis.ToList();
                    vml.Add(vm);
                }
            }
            return View(vml);

          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}