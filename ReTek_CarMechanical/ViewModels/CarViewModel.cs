using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class CarViewModel
    {
        public List<Client> Clients { get { return BussinessLayer.Instance.GetAllClient(); } }

        public Client SelectedClient { get; set; }

        public string CarPlateNumber { get; set; }
        public string CarType { get; set; }
        public DateTime CarDateofProduce { get; set; }
        public int CarVIN { get; set; }

        private ICommand _addNewCarCommandHandler;
        public ICommand AddNewCarCommandHandler
        {
            get
            {
                return _addNewCarCommandHandler ?? (_addNewCarCommandHandler = new CommandHandler(() => AddNewCarCommandAction(), () => true));
            }
        }

        private void AddNewCarCommandAction()
        {
            var result = BussinessLayer.Instance.UploadNewCar(new Car()
            {
                CarOwner = SelectedClient,
                CarDateofProduce = CarDateofProduce,
                CarPlateNumber = CarPlateNumber,
                CarType = CarType,
                CarVIN = CarVIN
            });


            if (result)
            {
                MessageBox.Show("Sikeres hozzáadás", "Gépjármű hozzáadása");
            }
            else
            {
                MessageBox.Show("SIKERTELEN hozzáadás", "Gépjármű hozzáadása");
            }

        }
    }
}
