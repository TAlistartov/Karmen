using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Models;
using BLL;


namespace Karmen.Controllers
{
    public class AdministratorController : Controller
    {
        //Links
        Bll bll = new Bll();       


        [HttpGet]
        public ViewResult Index()
        {
           return View();            
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllColours()
        {
            ColourModel colour = new ColourModel();
            var items = new List<SelectListItem>();
            var allColours = bll.BllGetAllColoursFromDb();
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
            var allPaterns = bll.BllGetAllPatternsFromDb();
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
            var allLinings = bll.BllGetAllLiningsFromDb();
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
            var allFootBeds = bll.BllGetAllFootBedsFromDb();
            foreach (var item in allFootBeds)
            {
                items.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Type });
            }
            footbed.AllFootBedsFromDb = items;
            return PartialView(footbed);
        }
    }
}
