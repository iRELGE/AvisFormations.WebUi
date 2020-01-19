/*
 12-Renommer l'action Index par LaisserUnAvis avec parametre type string nSeo
 13- cree une class nommer LaisserUnAvisViewModel -->
 14- instance une variable vm de type LaisserUnAvisViewModel
 15-stocker la variable nSeo dans vm.formationNseo
 16- generer accesseur pour formationNseo
 17-cree une fonction auto-implant using 
 18- Recuperer la liste des formations a partir du context AvisEntities avec une requete LinQ

 
 */


using AvisFormation.Logique;
using AvisFormations.Data;
using AvisFormations.WebUi.Models;

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormations.WebUi.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        [Authorize]
        public ActionResult LaisserUnAvis(string nSeo )
        {
            Formation formation;
            using (var context = new AvisEntities())
            {
                formation = context.Formations.FirstOrDefault(f => f.NomSeo == nSeo);
                
                if (formation == null)
                { 
                    RedirectToAction("ToutesLesFormations", "Formations");
                }
            }
            AvisManager la = new AvisManager();
            var user_id = User.Identity.GetUserId();
            if (!la.IsLimiterLesAvis(user_id, formation.Id))
            {
                LaisserUnAvisViewModel vm = new LaisserUnAvisViewModel();
                vm.formationNseo = nSeo;
                vm.formationName = formation.Nom;
                return View(vm);
            }


            return RedirectToAction("DetailsFormation", "Formations", new { nSeo = nSeo });

           

        }
        [Authorize]
        [HttpPost]
        public ActionResult SaveComment(string note, string description, string nSeo)
        {
           
            string user_id = User.Identity.GetUserId();
            AvisManager avisInformation = new AvisManager();

            avisInformation.AjouterUnAvis(user_id,description,note,nSeo);

            
            // RedirectToAction("DetailsFormation", "Formations",new { nSeo=nSeo});


            return RedirectToAction("DetailsFormation", "Formations", new { nSeo = nSeo });
          //  return RedirectToRoute("DetailsFormation");
        }
    }
}