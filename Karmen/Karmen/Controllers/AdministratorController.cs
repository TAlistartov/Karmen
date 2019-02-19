using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Models;
using BLL;
using BLL.Models;
using DAL;
using Karmen.Helpers;
using Newtonsoft.Json;

namespace Karmen.Controllers
{
    public class AdministratorController : Controller
    {
        //Links
        Dal dal = new Dal();
        Bll bll = new Bll();
        HelpMethods helpMethod = new HelpMethods();

        [HttpGet]
        public ViewResult Index()
        {
           return View();            
        }

        //Partial Views with DropDownLists for all Navigation Punkts 
        #region
        [HttpGet]
        public PartialViewResult Partial_GetAllColours()
        {
            ColourModel colour = new ColourModel();           
            //Get data from Db
            var allColoursDal = bll.BllGetAllDataTableFromDb(new Colours());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allColoursModel = helpMethod.HandMapper(new ColourModel(), allColoursDal);
            //Here call a function for creating DropDownList             
            DataStorePlace.AllColoursFromDb=helpMethod.MakeDropDownList(DataStorePlace.allColoursModel);
            colour.AllColoursFromDb = DataStorePlace.AllColoursFromDb;
            return PartialView(colour);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllPatterns()
        {
            PatternModel pattern= new PatternModel();            
            //Get data from Db
            var allPaternsDal = bll.BllGetAllDataTableFromDb(new Patterns());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allPatternsModel = helpMethod.HandMapper(new PatternModel(), allPaternsDal);
            //Here call a function for creating DropDownList             
            pattern.AllPatternsFromDb = helpMethod.MakeDropDownList(DataStorePlace.allPatternsModel);           
            return PartialView(pattern);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllLinings()
        {
            LiningModel lining = new LiningModel();
            //Get data from Db
            var allLiningsDal = bll.BllGetAllDataTableFromDb(new Linings());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allLiningsModel = helpMethod.HandMapper(new LiningModel(), allLiningsDal);
            //Here call a function for creating DropDownList             
            lining.AllLiningsFromDb = helpMethod.MakeDropDownList(DataStorePlace.allLiningsModel);
            return PartialView(lining);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllFootBeds()
        {
            FootBedModel footbed = new FootBedModel();
            //Get data from Db
            var allFootBedsDal = bll.BllGetAllDataTableFromDb(new Footbeds());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allFootBesModel = helpMethod.HandMapper(new FootBedModel(), allFootBedsDal);
            //Here call a function for creating DropDownList             
            footbed.AllFootBedsFromDb = helpMethod.MakeDropDownList(DataStorePlace.allFootBesModel);
            return PartialView(footbed);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllPads()
        {
            PadModel pad = new PadModel();
            //Get data from Db
            var allPadsDal = bll.BllGetAllDataTableFromDb(new Pads());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allPadsModel = helpMethod.HandMapper(new PadModel(), allPadsDal);
            //Here call a function for creating DropDownList             
            pad.AllPadsFromDb = helpMethod.MakeDropDownList(DataStorePlace.allPadsModel);
            return PartialView(pad);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllKindOfBlocks()
        {
            KindOfBlockModel kindOfBlock = new KindOfBlockModel();
            //Get data from Db
            var allKindOfBlocksDal = bll.BllGetAllDataTableFromDb(new KindOfBlocks());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allKindOfBlocksModel = helpMethod.HandMapper(new KindOfBlockModel(), allKindOfBlocksDal);
            //Here call a function for creating DropDownList             
            kindOfBlock.AllKindsOfBlockFromDb = helpMethod.MakeDropDownList(DataStorePlace.allKindOfBlocksModel);
            return PartialView(kindOfBlock);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllTopMaterials()
        {
            TopMaterialModel topMaterial = new TopMaterialModel();
            //Get data from Db
            var allTopMaterialsDal = bll.BllGetAllDataTableFromDb(new TopMaterials());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allTopMaterialsModel = helpMethod.HandMapper(new TopMaterialModel(), allTopMaterialsDal);
            //Here call a function for creating DropDownList             
            topMaterial.AllTopMaterialsFromDb = helpMethod.MakeDropDownList(DataStorePlace.allTopMaterialsModel);
            return PartialView(topMaterial);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllFurnitures()
        {
            FurnitureModel furniture = new FurnitureModel();
            //Get data from Db
            var allFurnituresDal = bll.BllGetAllDataTableFromDb(new Furnitures());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allFurnituresModel = helpMethod.HandMapper(new FurnitureModel(), allFurnituresDal);
            //Here call a function for creating DropDownList             
            furniture.AllFurnituresFromDb = helpMethod.MakeDropDownList(DataStorePlace.allFurnituresModel);
            return PartialView(furniture);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllMaterialOfSoles()
        {
            MaterialOfSoleModel materialOfSole = new MaterialOfSoleModel();
            //Get data from Db
            var allMaterialsOfSoleDal = bll.BllGetAllDataTableFromDb(new MaterialsOfSole());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allMaterialsOfSoleModel = helpMethod.HandMapper(new MaterialOfSoleModel(), allMaterialsOfSoleDal);
            //Here call a function for creating DropDownList             
            materialOfSole.AllMaterialsOfSoleFromDb = helpMethod.MakeDropDownList(DataStorePlace.allMaterialsOfSoleModel);
            return PartialView(materialOfSole);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllComponents()
        {
            ComponentModel component = new ComponentModel();
            //Get data from Db
            var allComponentsDal = bll.BllGetAllDataTableFromDb(new Components());
            //Map class on class - return List<1st parameter method>
            DataStorePlace.allComponentsModel = helpMethod.HandMapper(new ComponentModel(), allComponentsDal);
            //Here call a function for creating DropDownList             
            component.AllComponentsFromDb = helpMethod.MakeDropDownList(DataStorePlace.allComponentsModel);
            return PartialView(component);
        }
        #endregion        

        [HttpPost]
        public JsonResult SendDataToUI()
        {
            return Json(DataStorePlace.AllColoursFromDb);
        }

        [HttpPost]
        public JsonResult FilteringStoreData (int? IdOfSelectedItemDDL, string currentPunctId)
        {
            //Create a new local item with object type
            object filteredData=null;
            switch (currentPunctId)
            {
                case "colour":
                    filteredData = DataStorePlace.allColoursModel.Where(t=>t.Id==IdOfSelectedItemDDL);
                    break;
                case "pattern":
                    filteredData = DataStorePlace.allPatternsModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "lining":
                    filteredData = DataStorePlace.allLiningsModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "furniture":
                    filteredData = DataStorePlace.allFurnituresModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "footbed":
                    filteredData = DataStorePlace.allFootBesModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "pad":
                    filteredData = DataStorePlace.allPadsModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "kindOfBlock":
                    filteredData = DataStorePlace.allKindOfBlocksModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "materialOfSole":
                    filteredData = DataStorePlace.allMaterialsOfSoleModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "topMaterial":
                    filteredData = DataStorePlace.allTopMaterialsModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
                case "component":
                    filteredData = DataStorePlace.allComponentsModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
            }            
            return Json(filteredData);
        }

        [HttpPost]
        public JsonResult SaveNewNote (string jsonData, string typeOfSaveData)
        {
            object deserializedDataForSaveInDb=new { };
            switch (typeOfSaveData)
            {
                case "colour":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<Colour_Bll>(jsonData);
                break;

                case "pattern":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<Pattern_Bll>(jsonData);
                break;

                case "lining":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<Lining_Bll>(jsonData);
                break;

                case "footbed":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<FootBed_Bll>(jsonData);
                break;

                case "pad":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<Pad_Bll>(jsonData);                  
                break;

                case "kindOfBlock":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<KindOfBlock_Bll>(jsonData);
                break;

                case "topMaterial":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<TopMaterial_Bll>(jsonData);                   
                break;

                case "furniture":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<Furniture_Bll>(jsonData);                    
                break;

                case "materialOfSole":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<MaterialOfSole_Bll>(jsonData);                    
                break;

                case "component":
                    deserializedDataForSaveInDb = JsonConvert.DeserializeObject<Component_Bll>(jsonData);                    
                break;

            }
            var res = bll.SaveNewNoteBll(deserializedDataForSaveInDb, out string nameOfClass);
            object[] arrValues = new object[] {res,nameOfClass };
            

            return Json(arrValues);

        }
    }
}
