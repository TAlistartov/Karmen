using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Pad_Dal
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public double PadSize { get; set; }
        public bool UseUnuse { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
