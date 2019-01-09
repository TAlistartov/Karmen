using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Bll
    {
        //Links
        Dal dal = new Dal();

        public List<Colours> BllGetAllColoursFromDb ()
        {
            //List<Colours> coloursDb = new List<Colours>();
            var coloursDb = dal.DalGetAllColoursFromDb();
            return (coloursDb);
        }

        public List<Patterns> BllGetAllPatternsFromDb()
        {
            //List<Patterns> patternsDb = new List<Patterns>();
            var patternsDb = dal.DalGetAllPatternsFromDb();
            return (patternsDb);
        }

        public List<Linings> BllGetAllLiningsFromDb()
        {
            var liningsDb = dal.DalGetAllLiningsFromDb();
            return (liningsDb);
        }

        public List<Footbeds> BllGetAllFootBedsFromDb()
        {
            var footbedsDb = dal.DalGetAllFootBedsFromDb();
            return (footbedsDb);
        }


        public void BllSaveNewColour(string colour)
        {
            dal.DalSaveNewColour(colour);
        }
    }
}
