using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class LiningModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public string AdditionalInformation { get; set; }
        public string CrossReference { get; set; }
        public bool UseUnuse { get; set; }

        public List<SelectListItem> AllLiningsFromDb { get; set; }
        public string SelectedLining { get; set; }
    }
}