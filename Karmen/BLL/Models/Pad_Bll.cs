using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Pad_Bll
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public double PadSize { get; set; }
        public bool UseUnuse { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
