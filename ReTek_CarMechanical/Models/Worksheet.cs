using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Retek_Store_Manager.Models
{
    class Worksheet
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ExpectedEnd { get; set; }
        public int KilometerState { get; set; }
        public string UniqueId { get; set; }

    }
}