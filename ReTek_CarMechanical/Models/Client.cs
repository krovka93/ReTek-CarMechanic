using System;

namespace ReTek_CarMechanical.Models
{
    class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string SocialSecNum { get; set; }
        public string TaxNum { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
