/*
 part1
 2- Renommer l'action Index par ToutesLesFormations
 3-instance un variable listFormation list type Formation"sur ado AvisFormationsDbModel.edmx "
 4-fonction auto aplant using pour avoir in (param)variable context plein de donne AviEntities"Formations et Avis" Recuperer la liste des formations a partir du context AvisEntities avec une requete LinQ
 5-remplir listFormations avec context de mai just les Formation comme une list
 6-retourner listFormations
 7-cree VOTRE VUE ToutesLesFormations -->
 part2



*/
using AvisFormations.Data;
using AvisFormations.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AvisFormations.WebUi.Controllers
{
    public class FormationsController : Controller
    {
        // GET: Formations
        //part 1
        public ActionResult ToutesLesFormations()
        {
            var listFormations=new List<Formation>();
            using (var context = new AvisEntities() )
            {
                 listFormations = context.Formations.ToList();
            }
            return View(listFormations);
        }

        //part 2
       
        public  ActionResult DetailsFormation(string nSeo="none")
        {
            var formation = new Formation();
            ViewFormationAvisModel vm = new ViewFormationAvisModel();

            using (var context= new AvisEntities())
            {
                 formation = context.Formations.Where(f => f.NomSeo == nSeo).FirstOrDefault();
                if (formation == null)
                {
                    RedirectToAction("Index", "Home");
                }
                else
                {

                    vm.id = formation.Id;
                    vm.nom = formation.Nom;
                    vm.url = formation.Url;
                    vm.description = formation.Description;
                    vm.nomseo = formation.NomSeo;
                    vm.nombreAvis = formation.Avis.Count();
                    if (formation.Avis.Count > 0)
                    {
                        vm.noteFormation = formation.Avis.Average(f => f.Note);
                    }
                    else
                    {
                        vm.noteFormation = 0;
                    }
                   
                    vm.avis = formation.Avis.ToList();
                }
                
                
            }
                return View(vm);
        }
    }
}