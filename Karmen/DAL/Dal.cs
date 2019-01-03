using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        public void GTR()
        {
            using (KarmenDbContext db = new KarmenDbContext())
            {
                // добавление элементов
                db.Colours.Add(new Colours { Colour = "серый" });                
                db.SaveChanges();
                // получение элементов
                var users = db.Colours;
                //foreach (User u in users)
                //    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
            }
        }
           
    }
}
