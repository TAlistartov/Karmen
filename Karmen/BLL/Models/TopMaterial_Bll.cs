using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TopMaterial_Bll
    {
        public int? Id { get; set; }
        public int IdColour { get; set; }
        public string Type { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }
    }
}
