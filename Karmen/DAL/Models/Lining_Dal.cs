using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Lining_Dal
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public string AdditionalInformation { get; set; }
        public string CrossReference { get; set; }
        public bool UseUnuse { get; set; }
    }
}
