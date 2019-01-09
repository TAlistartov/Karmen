using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class MaterialOfSoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdColour { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }

        public List<SelectListItem> AllMaterialsOfSoleFromDb { get; set; }
        public string SelectedMaterialOfSole { get; set; }
    }
}