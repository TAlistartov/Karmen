using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class ColourModel
    {
        public int Id { get; set; }
        public string ColourName { get; set; }
        public List<SelectListItem> AllColoursFromDb {get;set;}
        public string SelectedColour { get; set; }
    }
}