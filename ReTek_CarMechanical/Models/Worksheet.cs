using System;

namespace ReTek_CarMechanical.Models
{
    class Worksheet
    {
        public int WorksheetID { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkActualEnd { get; set; }
        public DateTime ExpectedEnd { get; set; }
        public int KilometerState { get; set; }
        public string UniqueId { get; set; }
        public int CarID { get; set; }
        public int ServiceID { get; set; }
        public int PartID { get; set; }

    }
}