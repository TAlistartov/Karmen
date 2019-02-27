using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MaterialOfSole_Dal
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int IdColour { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }
    }
}
