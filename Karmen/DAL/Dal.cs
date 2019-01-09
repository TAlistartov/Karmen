using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        public List<Colours> DalGetAllColoursFromDb()
        {
            var temp = new List<Colours>();
            using (KarmenDbContext db = new KarmenDbContext())
            {
                 temp= db.Colour.ToList();
            }
            return (temp);
        }

        public List<Patterns> DalGetAllPatternsFromDb()
        {
            var temp = new List<Patterns>();
            using (KarmenDbContext db = new KarmenDbContext())
            {
                temp = db.Pattern.ToList();
            }           
            return (temp);
        }

        public List<Linings> DalGetAllLiningsFromDb()
        {
            var temp = new List<Linings>();
            using (KarmenDbContext db = new KarmenDbContext())
            {
                temp = db.Lining.ToList();
            }
            return (temp);
        }

        public List<Footbeds> DalGetAllFootBedsFromDb()
        {
            var temp = new List<Footbeds>();
            using (KarmenDbContext db = new KarmenDbContext())
            {
                temp = db.Footbed.ToList();
            }
            return (temp);
        }

        public int DalSaveNewColour(string colour)
        {
            int res = 0;
            using (KarmenDbContext db = new KarmenDbContext())
            {
                var temp = db.Colour.Where(c => c.Colour == colour);
                if (temp == null)
                {
                    // Add new element to Db
                    db.Colour.Add(new Colours { Colour = colour });
                    db.SaveChanges();
                    // Get element from Db
                    var users = db.Colour.Where(c => c.Colour == colour);
                    res = (users == null) ? 0 : 1; //0 - Saving Error; 1 - Saving is correct                    
                }
                else
                    res = 2; //This note is already created in Db             
            }
            return (res);
        }
           
    }
}
