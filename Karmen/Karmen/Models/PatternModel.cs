using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class PatternModel
    {
        public int Id { get; set; }
        public string CrossReference { get; set; }
        public string AdditionalInformation { get; set; }
        public bool UseUnuse { get; set; }

        public List<SelectListItem> AllPatternsFromDb { get; set; }
        public string SelectedPattern { get; set; }
    }
}