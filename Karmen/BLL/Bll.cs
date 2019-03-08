using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using BLL.Models;
using System.Reflection;
using BLL.Helpers;

namespace BLL
{   

    public class Bll
    {
        //Links
        Dal dal = new Dal();
        HelpMethodsBll help = new HelpMethodsBll();
        
        
        //Get All Data From the necessaary tables in Db for Main DropDownList in all Punkts of Navigation
        public List<T> BllGetAllDataTableFromDb<T>(T TypeOfData)
        {
            List<T> dataDb = dal.DalGetAllDataTableFromDb<T>(TypeOfData);
            return (dataDb);
        }

        //Save or Change Note to||in DB 
        public int SaveNewOrChangeSelectedNoteBll<T> (T someClassForSave, string necessaryAction, out string nameOfClass)
        {          
            var nameOfClassModel = someClassForSave.GetType().Name;
            var temp = nameOfClassModel.Split(new char[] { '_' });
            nameOfClass = temp[0];
            //Get type of incoming anonym class (for example Colour_Bll or Component_Bll etc.)
            var typeOfClass =someClassForSave.GetType();
            //Mapping Bll Class to Dal Class
            var dataToDal = help.HandMappingUseReflection(typeOfClass,someClassForSave,help.matchClassesBllvsClassesDal,false);
            //Call necessary action Method from Dal
            var r=help.SelectActionMethod(typeOfClass, necessaryAction, dataToDal);
            int res = (Int32)r;//Convert object to int

            return res;                    

        }
    }
}
