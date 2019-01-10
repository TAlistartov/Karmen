using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {

        //Get Data from the necessary table in Db for DropDownList 
        #region
        //T TypeOfData - Type of DAL Model for identify of the necessary table in Db
        public List<T> DalGetAllDataTableFromDb <T> (T TypeOfData)
        {          
            List<T> temp = new List<T>();
            string convertData = TypeOfData.GetType().Name; //Here takes name of Class model
                                                                // Colours, Patterns etc.
            using (KarmenDbContext db = new KarmenDbContext())
            {
                switch (convertData)
                {
                    case "Colours":
                        temp = db.Colour.ToList() as List<T>;
                        break;
                    case "Patterns":
                        temp = db.Pattern.ToList() as List<T>;
                        break;
                    case "Linings":                        
                        temp = db.Lining.ToList() as List<T>;
                        break;
                    case "Footbeds":
                        temp = db.Footbed.ToList() as List<T>;
                        break;
                    case "Pads":
                        temp = db.Pad.ToList() as List<T>;
                        break;
                    case "KindOfBlocks":
                        temp = db.KindOfBlock.ToList() as List<T>;
                        break;
                    case "TopMaterials":
                        temp = db.TopMaterial.ToList() as List<T>;
                        break;
                    case "Furnitures":
                        temp = db.Furniture.ToList() as List<T>;
                        break;
                    case "MaterialsOfSole":
                        temp = db.MaterialOfSole.ToList() as List<T>;
                        break;
                    case "Components":
                        temp = db.Component.ToList() as List<T>;
                        break;
                }               
            }
            return (temp);
        }
        #endregion

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
