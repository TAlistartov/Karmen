using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        public int SaveNewColour(string colour)
        {
            int res = 0;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Colours.Where(c => c.Colour == colour);
                if (temp == null)
                {
                    // добавление элементов
                    db.Colours.Add(new Colours { Colour = colour });
                    db.SaveChanges();
                    // получение элементов
                    var users = db.Colours.Where(c => c.Colour == colour);
                    res = (users == null) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct
                    
                }
                else
                    res = 2; //This note is already created in Db             
                
            }
            return (res);
        }
           
    }
}
