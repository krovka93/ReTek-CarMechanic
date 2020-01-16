using System;

namespace ReTek_CarMechanical.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string CarPlateNumber { get; set; }
        public string CarType { get; set; }
        public DateTime CarDateofProduce { get; set; }
        public string CarVIN { get; set; }
        public int CarOwner { get; set; }
    }
}
