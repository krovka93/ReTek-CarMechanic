using System;

namespace ReTek_CarMechanical.Models
{
    class Car
    {
        public int CarID { get; set; }
        public string CarPlateNumber { get; set; }
        public string CarType { get; set; }
        public DateTime CarDateofProduce { get; set; }
        public int CarVIN { get; set; }
        public Client CarOwner { get; set; }
    }
}
