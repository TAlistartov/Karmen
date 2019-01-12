using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Interfaces;

namespace Karmen.Models
{
    public class LiningModel:ISelectListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public string AdditionalInformation { get; set; }
        public string CrossReference { get; set; }
        public bool UseUnuse { get; set; }

        public List<SelectListItem> AllLiningsFromDb { get; set; }
        public string SelectedLining { get; set; }

        //Interface realisation
        public SelectListItem MapToSelectListItem()
        {
            return new SelectListItem { Value = this.Id.ToString(), Text = this.Name };
        }
    }
}