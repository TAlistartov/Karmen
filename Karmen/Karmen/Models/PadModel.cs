using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karmen.Interfaces;

namespace Karmen.Models
{
    public class PadModel:ISelectListItem
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public double PadSize { get; set; }
        public bool UseUnuse { get; set; }
        public string AdditionalInformation { get; set; }

        public List<SelectListItem> AllPadsFromDb { get; set; }
        public string SelectedPad { get; set; }

        //Interface realisation
        public SelectListItem MapToSelectListItem()
        {
            return new SelectListItem { Value = this.Id.ToString(), Text = this.Kind };
        }
    }
}