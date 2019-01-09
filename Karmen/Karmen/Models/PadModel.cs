using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class PadModel
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public double PadSize { get; set; }
        public bool UseUnuse { get; set; }
        public string AdditionalInformation { get; set; }

        public List<SelectListItem> AllPadsFromDb { get; set; }
        public string SelectedPad { get; set; }
    }
}