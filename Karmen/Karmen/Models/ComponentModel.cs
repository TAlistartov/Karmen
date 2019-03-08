using Karmen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class ComponentModel: ISelectListItem
    {
        public int Id { get; set; }
        public string TypeOfComponent { get; set; }
        public int IdColour { get; set; }
        public int Size { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }
        public string AdditionalInformation { get; set; }
        public int? IdMaterilOfCovering { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Form { get; set; }
        public string Type { get; set; }

        public List<SelectListItem> AllComponentsFromDb { get; set; }
        //public string SelectedComponent { get; set; }

        //Interface realisation
        public SelectListItem MapToSelectListItem()
        {
            return new SelectListItem { Value = this.Id.ToString(), Text = this.TypeOfComponent };
        }
    }
}