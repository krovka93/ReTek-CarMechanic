using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class CarViewModel : INotifyPropertyChanged
    {
        public List<Client> Clients { get { return BussinessLayer.Instance.GetAllClient(); } }

        private Client _selectedClient;

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; OnPropertyChanged("SelectedClient"); }
        }


        private string _carPlateNumber;

        public string CarPlateNumber
        {
            get { return _carPlateNumber; }
            set { _carPlateNumber = value; OnPropertyChanged("CarPlateNumber"); }
        }

        public string CarType { get; set; }
        public DateTime CarDateofProduce { get; set; }
        public int CarVIN { get; set; }

        private ICommand _addNewCarCommandHandler;

        public event PropertyChangedEventHandler PropertyChanged;

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


           MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Gépjármű hozzáadása");
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
