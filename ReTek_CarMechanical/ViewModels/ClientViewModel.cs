﻿using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; OnPropertyChanged("BirthDate"); }
        }

        private string _birthPlace;
        public string BirthPlace
        {
            get { return _birthPlace; }
            set { _birthPlace = value; OnPropertyChanged("BirthPlace"); }
        }

        private string _socialSecNum;
        public string SocialSecNum
        {
            get { return _socialSecNum; }
            set { _socialSecNum = value; OnPropertyChanged("SocialSecNum"); }
        }

        private string _taxNum;
        public string TaxNum
        {
            get { return _taxNum; }
            set { _taxNum = value; OnPropertyChanged("TaxNum"); }
        }


        private ICommand _addNewClientCommandHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewClientCommandHandler
        {
            get
            {
                return _addNewClientCommandHandler ??
                    (_addNewClientCommandHandler = new CommandHandler(() => ClientCommandHandlerAction(),
                    () => (!string.IsNullOrEmpty(FirstName) &&
                    !string.IsNullOrEmpty(LastName) &&
                    !string.IsNullOrEmpty(BirthPlace) &&
                    !string.IsNullOrEmpty(SocialSecNum) &&
                    !string.IsNullOrEmpty(TaxNum))));
            }
        }

        public void ClientCommandHandlerAction()
        {
            var existingUser = BusinessLayer.Instance.GetAllClient().SingleOrDefault(lm => lm.TaxNum == TaxNum && lm.SocialSecNum == SocialSecNum);
            if (existingUser != null)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Szeretné frissíteni a személyes adatokat?", "Meglévő személy adatainak frissítése", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    var result = BusinessLayer.Instance.UpdateClient(new Client()
                    {
                        ClientID = existingUser.ClientID,
                        BirthDate = BirthDate,
                        BirthPlace = BirthPlace,
                        FirstName = FirstName,
                        LastName = LastName,
                        SocialSecNum = SocialSecNum,
                        TaxNum = TaxNum
                    });
                    MessageBox.Show(result ? "Sikeres frissítés" : "SIKERTELEN frissítés", "Ügyféladatok frissítése", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var result = BusinessLayer.Instance.AddClient(new Client()
                {
                    BirthDate = BirthDate,
                    BirthPlace = BirthPlace,
                    FirstName = FirstName,
                    LastName = LastName,
                    SocialSecNum = SocialSecNum,
                    TaxNum = TaxNum
                });
                MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Ügyféladatok hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
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
