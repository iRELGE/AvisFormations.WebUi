using AvisFormations.Data;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logique
{
    public class AvisManager
    {
        public void AjouterUnAvis(string user_ids, string descriptions,string notes,string nSeos )
        {
            PersonManager mgr = new PersonManager();
            Avi nouvelAvi = new Avi();
            nouvelAvi.DateAvis = DateTime.Now;
            nouvelAvi.Description = descriptions;

            nouvelAvi.UserId = user_ids;
            double dNote = 0;
            if (!double.TryParse(notes, out dNote))
            {
                throw new Exception("Parse Invalid");
            }
            else
            {
                nouvelAvi.Note = dNote;
            }
            using (var context = new AvisEntities())
            {
                var formation = context.Formations.FirstOrDefault(f => f.NomSeo == nSeos);
                nouvelAvi.IdFormation = formation.Id;
                nouvelAvi.Nom = mgr.GetNameByUserId(user_ids);
                context.Avis.Add(nouvelAvi);
                context.SaveChanges();
            }
        }
        public bool IsLimiterLesAvis(string user_id,int id_formation)
        {
            Avi avi;
            using (var context = new AvisEntities())
            {
                 avi = context.Avis.FirstOrDefault(f => f.IdFormation == id_formation && f.UserId == user_id);
            }
            if (avi != null)return true;
            
            else return false;
        }
    }
}
