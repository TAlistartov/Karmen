﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

    }
}
