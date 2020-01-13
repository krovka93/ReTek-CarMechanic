using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}