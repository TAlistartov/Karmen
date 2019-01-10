using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class TopMaterialModel
    {
        public int Id { get; set; }
        public int IdColour { get; set; }
        public string Type { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }

        public List<SelectListItem> AllTopMaterialsFromDb { get; set; }
        public string SelectedTopMaterial { get; set; }
    }
}