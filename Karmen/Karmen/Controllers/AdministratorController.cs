using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Models;
using BLL;
using DAL;
using Karmen.Helpers;

namespace Karmen.Controllers
{
    public class AdministratorController : Controller
    {
        //Links
        Dal dal = new Dal();
        Bll bll = new Bll();
        HelpMethods helpMethod = new HelpMethods();

        //Model
        static List<ColourModel> allColoursModel = new List<ColourModel>();
        static List<PatternModel> allPatternsModel = new List<PatternModel>();


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
            allColoursModel = helpMethod.HandMapper(new ColourModel(), allColoursDal);
            //Here call a function for creating DropDownList             
            colour.AllColoursFromDb=helpMethod.MakeDropDownList(allColoursModel);
            return PartialView(colour);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllPatterns()
        {
            PatternModel pattern= new PatternModel();            
            //Get data from Db
            var allPaternsDal = bll.BllGetAllDataTableFromDb(new Patterns());
            //Map class on class - return List<1st parameter method>
            allPatternsModel = helpMethod.HandMapper(new PatternModel(), allPaternsDal);
            //Here call a function for creating DropDownList             
            pattern.AllPatternsFromDb = helpMethod.MakeDropDownList(allPatternsModel);           
            return PartialView(pattern);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllLinings()
        {
            LiningModel lining = new LiningModel();
            //Get data from Db
            var allLiningsDal = bll.BllGetAllDataTableFromDb(new Linings());
            //Map class on class - return List<1st parameter method>
            var allLiningsModel = helpMethod.HandMapper(new LiningModel(), allLiningsDal);
            //Here call a function for creating DropDownList             
            lining.AllLiningsFromDb = helpMethod.MakeDropDownList(allLiningsModel);
            return PartialView(lining);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllFootbeds()
        {
            FootBedModel footbed = new FootBedModel();
            //Get data from Db
            var allFootBedsDal = bll.BllGetAllDataTableFromDb(new Footbeds());
            //Map class on class - return List<1st parameter method>
            var allFootBedsModel = helpMethod.HandMapper(new FootBedModel(), allFootBedsDal);
            //Here call a function for creating DropDownList             
            footbed.AllFootBedsFromDb = helpMethod.MakeDropDownList(allFootBedsModel);
            return PartialView(footbed);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllPads()
        {
            PadModel pad = new PadModel();
            //Get data from Db
            var allPadsDal = bll.BllGetAllDataTableFromDb(new Pads());
            //Map class on class - return List<1st parameter method>
            var allPadsModel = helpMethod.HandMapper(new PadModel(), allPadsDal);
            //Here call a function for creating DropDownList             
            pad.AllPadsFromDb = helpMethod.MakeDropDownList(allPadsModel);
            return PartialView(pad);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllKindOfBlocks()
        {
            KindOfBlockModel kindOfBlock = new KindOfBlockModel();
            //Get data from Db
            var allKindOfBlocksDal = bll.BllGetAllDataTableFromDb(new KindOfBlocks());
            //Map class on class - return List<1st parameter method>
            var allKindOfBlocksModel = helpMethod.HandMapper(new KindOfBlockModel(), allKindOfBlocksDal);
            //Here call a function for creating DropDownList             
            kindOfBlock.AllKindsOfBlockFromDb = helpMethod.MakeDropDownList(allKindOfBlocksModel);
            return PartialView(kindOfBlock);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllTopMaterials()
        {
            TopMaterialModel topMaterial = new TopMaterialModel();
            //Get data from Db
            var allTopMaterialsDal = bll.BllGetAllDataTableFromDb(new TopMaterials());
            //Map class on class - return List<1st parameter method>
            var allTopMaterialsModel = helpMethod.HandMapper(new TopMaterialModel(), allTopMaterialsDal);
            //Here call a function for creating DropDownList             
            topMaterial.AllTopMaterialsFromDb = helpMethod.MakeDropDownList(allTopMaterialsModel);
            return PartialView(topMaterial);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllFurnitures()
        {
            FurnitureModel furniture = new FurnitureModel();
            //Get data from Db
            var allFurnituresDal = bll.BllGetAllDataTableFromDb(new Furnitures());
            //Map class on class - return List<1st parameter method>
            var allFurnituresModel = helpMethod.HandMapper(new FurnitureModel(), allFurnituresDal);
            //Here call a function for creating DropDownList             
            furniture.AllFurnituresFromDb = helpMethod.MakeDropDownList(allFurnituresModel);
            return PartialView(furniture);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllMaterialOfSoles()
        {
            MaterialOfSoleModel materialOfSole = new MaterialOfSoleModel();
            //Get data from Db
            var allMaterialsOfSoleDal = bll.BllGetAllDataTableFromDb(new MaterialsOfSole());
            //Map class on class - return List<1st parameter method>
            var allMaterialsOfSoleModel = helpMethod.HandMapper(new MaterialOfSoleModel(), allMaterialsOfSoleDal);
            //Here call a function for creating DropDownList             
            materialOfSole.AllMaterialsOfSoleFromDb = helpMethod.MakeDropDownList(allMaterialsOfSoleModel);
            return PartialView(materialOfSole);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllComponents()
        {
            ComponentModel component = new ComponentModel();
            //Get data from Db
            var allComponentsDal = bll.BllGetAllDataTableFromDb(new Components());
            //Map class on class - return List<1st parameter method>
            var allComponentsModel = helpMethod.HandMapper(new ComponentModel(), allComponentsDal);
            //Here call a function for creating DropDownList             
            component.AllComponentsFromDb = helpMethod.MakeDropDownList(allComponentsModel);
            return PartialView(component);
        }
        #endregion        

        [HttpPost]
        public JsonResult FilteringStoreData (int? IdOfSelectedItemDDL, string currentPunctId)
        {
            //Create a new local item with object type
            object filteredData=null;
            switch (currentPunctId)
            {
                case "color":
                    filteredData = allColoursModel.Where(t=>t.Id==IdOfSelectedItemDDL);
                    break;
                case "pattern":
                    filteredData = allPatternsModel.Where(t => t.Id == IdOfSelectedItemDDL);
                    break;
            }            
            return Json(filteredData);
        }
    }
}
