using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Component_Bll
    {
        public int? Id { get; set; }
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
    }
}
