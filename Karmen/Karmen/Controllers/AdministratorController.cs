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
        Bll bll = new Bll();

        ColourModel colour = new ColourModel();
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllColours()

        {
            bll.test();
            var items = new List<SelectListItem>();
            colour.SelectedColour = "1";
            colour.ColourName = "j";
            items.Add(new SelectListItem { Value = colour.SelectedColour, Text = colour.ColourName });
            colour.AllColoursFromDb = items;
            //colour.AllColoursFromDb.Add(new SelectListItem { Value = colour.SelectedColour, Text = colour.ColourName });
            return PartialView(colour);
        }

    }
}
