using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Models;


namespace Karmen.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial_GetAllColours()
        {
            ColourModel colour = new ColourModel();
            return PartialView(colour);
        }

    }
}
