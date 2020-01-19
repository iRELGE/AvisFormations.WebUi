using AvisFormations.Data;
using System.Linq;


namespace AvisFormation.Logique
{
    public class PersonManager
    {
        
        public void InsertPerson(string user_id,string nom)
        {
            using (var context = new AvisEntities())
            {
                var person = context.People.Where(f => f.User_id == user_id).FirstOrDefault();   
                if(person==null)
                {
                    Person p = new Person();
                    p.Nom = nom;
                    p.User_id = user_id;

                    context.People.Add(p);
                    context.SaveChanges();

                }

            }
            


        }

        public string GetNameByUserId(string user_id)
        {
            using (var context = new AvisEntities())
            {
                var namePerson = context.People.Where(f => f.User_id == user_id).FirstOrDefault();
                if (namePerson == null)
                {
                    return "anonyme";
                }
                else
                {
                    return namePerson.Nom;
                }
            }
        }
    }
}
