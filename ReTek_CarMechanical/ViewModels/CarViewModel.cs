﻿using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class CarViewModel : INotifyPropertyChanged
    {
        public List<Client> Clients { get { return BusinessLayer.Instance.GetAllClient(); } }

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

        private string _carType;
        public string CarType
        {
            get { return _carType; }
            set { _carType = value; OnPropertyChanged("CarType"); }
        }

        private DateTime _carDateofProduce;
        public DateTime CarDateofProduce
        {
            get { return _carDateofProduce; }
            set { _carDateofProduce = value; OnPropertyChanged("CarDateofProduce"); }
        }

        private string _carVIN;
        public string CarVIN
        {
            get { return _carVIN; }
            set { _carVIN = value; OnPropertyChanged("CarVIN"); }
        }


        private ICommand _addNewCarCommandHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewCarCommandHandler
        {
            get
            {
                return _addNewCarCommandHandler ??
                    (_addNewCarCommandHandler = new CommandHandler(() => AddNewCarCommandAction(),
                    () => (!string.IsNullOrEmpty(CarVIN) && !string.IsNullOrEmpty(CarType) && !string.IsNullOrEmpty(CarPlateNumber) && SelectedClient != null)));
            }
        }

        private void AddNewCarCommandAction()
        {
            var existingCar = BusinessLayer.Instance.GetAllCar().SingleOrDefault(lm => lm.CarPlateNumber == CarPlateNumber);
            if (existingCar != null)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Szeretné frissíteni a gépjármű adatokat?", "Meglévő gépjármű adatainak frissítése", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    var result = BusinessLayer.Instance.UpdateExistingCar(new Car()
                    {
                        CarID = existingCar.CarID,
                        CarOwner = SelectedClient.ClientID,
                        CarDateofProduce = CarDateofProduce,
                        CarPlateNumber = CarPlateNumber,
                        CarType = CarType,
                        CarVIN = CarVIN
                    });
                    MessageBox.Show(result ? "Sikeres frissítés" : "SIKERTELEN frissítés", "Gépjárműadatok frissítése", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var result = BusinessLayer.Instance.UploadNewCar(new Car()
                {
                    CarOwner = SelectedClient.ClientID,
                    CarDateofProduce = CarDateofProduce,
                    CarPlateNumber = CarPlateNumber,
                    CarType = CarType,
                    CarVIN = CarVIN
                });
                MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Gépjárműadatok hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
