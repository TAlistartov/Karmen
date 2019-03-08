using Karmen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karmen.Models
{
    public class ColourModel : ISelectListItem
    {
        public int Id { get; set; }
        public string Colour { get; set; }


        public int? IdColour { get; set; }       

        public List<SelectListItem> AllColoursFromDb { get; set; }        

        //Interface realisation
        public SelectListItem MapToSelectListItem()
        {
            return new SelectListItem { Value = this.Id.ToString(), Text = this.Colour };
        }
    }
}