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

        //Delete selected note
        public object BllDeleteSelectedNote (int idSelectedNote, string typeOfSaveData)
        {
            //object result = false;
            object[] result=new object[] { };
            switch (typeOfSaveData)
            {
                case "colour":
                    //"Colours" - it's part of Action Name of AdministratorController Partial_GetAllColours(). It's need for calling this method from JS
                    result = new object[] {"Colours", dal.DalDeleteSelectedColour(idSelectedNote) }; 
                    break;
                case "pattern":
                    result = new object[] { "Patterns", dal.DalDeleteSelectedPattern(idSelectedNote) };
                    break;
                case "lining":
                    result = new object[] { "Linings", dal.DalDeleteSelectedLining(idSelectedNote) };
                    break;
                case "footbed":
                    result = new object[] { "FootBeds", dal.DalDeleteSelectedFootBed(idSelectedNote) };
                    break;
                case "pad":
                    result = new object[] { "Pads", dal.DalDeleteSelectedPad(idSelectedNote) };
                    break;
                case "kindOfBlock":
                    result = new object[] { "KindOfBlocks", dal.DalDeleteSelectedKindOfBlock(idSelectedNote) };
                    break;
                case "topMaterial":
                    result = new object[] { "TopMaterials", dal.DalDeleteSelectedTopMaterial(idSelectedNote) };
                    break;
                case "furniture":
                    result = new object[] { "Furnitures", dal.DalDeleteSelectedFurniture(idSelectedNote) };
                    break;
                case "materialOfSole":
                    result = new object[] { "MaterialOfSoles", dal.DalDeleteSelectedMaterialOfSole(idSelectedNote) };
                    break;
                case "component":
                    result = new object[] { "Components", dal.DalDeleteSelectedComponent(idSelectedNote) };
                    break;
            }
            return (result);
    }
    }
}
