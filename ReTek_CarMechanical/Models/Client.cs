using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Retek_Store_Manager.Models
{
    class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int SocialSecNum { get; set; }
        public int TaxNum { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
