﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Interfaces;

namespace Karmen.Models
{
    public class FurnitureModel:ISelectListItem
    {
        public int Id { get; set; }
        public int IdColour { get; set; }
        public string Type { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }

        public List<SelectListItem> AllFurnituresFromDb { get; set; }
        //public string SelectedFurniture { get; set; }

        //Interface realisation
        public SelectListItem MapToSelectListItem()
        {
            return new SelectListItem { Value = this.Id.ToString(), Text = this.Type };
        }
    }
}