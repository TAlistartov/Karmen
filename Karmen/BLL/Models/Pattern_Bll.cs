using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Pattern_Bll
    {
        public int? Id { get; set; }
        public string CrossReference { get; set; }
        public string AdditionalInformation { get; set; }
        public bool UseUnuse { get; set; }
    }
}
