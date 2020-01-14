using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class ClientViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int SocialSecNum { get; set; }
        public int TaxNum { get; set; }


        private ICommand _addNewClientCommandHandler;
        public ICommand AddNewClientCommandHandler
        {
            get
            {
                return _addNewClientCommandHandler ?? (_addNewClientCommandHandler = new CommandHandler(() => ClientCommandHandlerAction(), () => true));
            }
        }

        public void ClientCommandHandlerAction()
        {
           var result = BussinessLayer.Instance.AddClient(new Client() { 
                BirthDate = BirthDate, 
                BirthPlace=BirthPlace, 
                FirstName= FirstName,
                LastName= LastName, 
                SocialSecNum = SocialSecNum,
                TaxNum = TaxNum });

           MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Ügyfél hozzáadása");
        }

    }
}
