using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Models
{
    class Car
    {
        public int CarID { get; set; }
        public string CarPlateNumber { get; set; }
        public string CarType { get; set; }
        public DateTime CarDateofProduce { get; set; }
        public int CarVIN { get; set; }
    }
}
