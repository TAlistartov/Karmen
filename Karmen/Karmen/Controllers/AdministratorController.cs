using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Models;
using BLL;
using DAL;


namespace Karmen.Controllers
{
    public class AdministratorController : Controller
    {
        //Links
        Dal dal = new Dal();
        Bll bll = new Bll();       

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
            var items = new List<SelectListItem>();
            var allColours= bll.BllGetAllDataTableFromDb(new Colours());
            foreach (var item in allColours)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Colour });
            }
            colour.AllColoursFromDb = items;
            return PartialView(colour);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllPatterns()
        {
            PatternModel pattern= new PatternModel();
            var items = new List<SelectListItem>();
            var allPaterns = bll.BllGetAllDataTableFromDb(new Patterns());                       
            foreach (var item in allPaterns)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.CrossReference });
            }
            pattern.AllPatternsFromDb = items;
            return PartialView(pattern);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllLinings()
        {
            LiningModel lining = new LiningModel();            
            var items = new List<SelectListItem>();
            var allLinings = bll.BllGetAllDataTableFromDb(new Linings());            
            foreach (var item in allLinings)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            lining.AllLiningsFromDb = items;
            return PartialView(lining);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllFootbeds()
        {
            FootBedModel footbed = new FootBedModel();
            var items = new List<SelectListItem>();
            var allFootBeds = bll.BllGetAllDataTableFromDb(new Footbeds());
            foreach (var item in allFootBeds)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
            footbed.AllFootBedsFromDb = items;
            return PartialView(footbed);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllPads()
        {
            PadModel pad = new PadModel();
            var items = new List<SelectListItem>();
            var allPads = bll.BllGetAllDataTableFromDb(new Pads());
            foreach (var item in allPads)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Kind });
            }
            pad.AllPadsFromDb = items;
            return PartialView(pad);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllKindOfBlocks()
        {
            KindOfBlockModel kindOfBlock = new KindOfBlockModel();
            var items = new List<SelectListItem>();
            var allKindOfBlocks = bll.BllGetAllDataTableFromDb(new KindOfBlocks());
            foreach (var item in allKindOfBlocks)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            kindOfBlock.AllKindsOfBlockFromDb = items;
            return PartialView(kindOfBlock);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllTopMaterials()
        {
            TopMaterialModel topMaterial = new TopMaterialModel();
            var items = new List<SelectListItem>();
            var allTopMaterials = bll.BllGetAllDataTableFromDb(new TopMaterials());
            foreach (var item in allTopMaterials)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
            topMaterial.AllTopMaterialsFromDb = items;
            return PartialView(topMaterial);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllFurnitures()
        {
            FurnitureModel furniture = new FurnitureModel();
            var items = new List<SelectListItem>();
            var allFurnitures = bll.BllGetAllDataTableFromDb(new Furnitures());
            foreach (var item in allFurnitures)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
            furniture.AllFurnituresFromDb = items;
            return PartialView(furniture);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllMaterialOfSoles()
        {
            MaterialOfSoleModel materialOfSole = new MaterialOfSoleModel();
            var items = new List<SelectListItem>();
            var allMaterialsOfSole = bll.BllGetAllDataTableFromDb(new MaterialsOfSole());
            foreach (var item in allMaterialsOfSole)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            materialOfSole.AllMaterialsOfSoleFromDb = items;
            return PartialView(materialOfSole);
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllComponents()
        {
            ComponentModel component = new ComponentModel();
            var items = new List<SelectListItem>();
            var allComponents = bll.BllGetAllDataTableFromDb(new Components());
            foreach (var item in allComponents)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TypeOfComponent });
            }
            component.AllComponentsFromDb = items;
            return PartialView(component);
        }
        #endregion
    }
}
