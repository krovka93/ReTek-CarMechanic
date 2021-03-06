﻿using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class PartViewModel : INotifyPropertyChanged
    {

        private string _partName;

        public string PartName
        {
            get { return _partName; }
            set { _partName = value; OnPropertyChanged("PartName"); }
        }


        private int _partPrice;

        public int PartPrice
        {
            get { return _partPrice; }
            set { _partPrice = value; OnPropertyChanged("PartPrice"); }
        }


        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged("Quantity"); }
        }


        private ICommand _addNewPartCommandHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewPartCommandHandler
        {
            get
            {
                return _addNewPartCommandHandler ??
                    (_addNewPartCommandHandler = new CommandHandler(() => AddNewPartCommandAction(),
                    () => (!string.IsNullOrEmpty(PartName) && PartPrice > 0)));
            }
        }

        private void AddNewPartCommandAction()
        {
            var existingPart = BusinessLayer.Instance.GetAllPart().SingleOrDefault(lm => lm.PartName == PartName);
            if (existingPart != null)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Szeretné frissíteni az alkatrész adatokat?", "Meglévő alkatrész adatainak frissítése", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    var result = BusinessLayer.Instance.UpdatePart(new Part()
                    {
                        PartID = existingPart.PartID,
                        PartName = PartName,
                        Price = PartPrice,
                        Quantity = Quantity
                    });
                    MessageBox.Show(result ? "Sikeres frissítés" : "SIKERTELEN frissítés", "Alkatrészadatok frissítése", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var result = BusinessLayer.Instance.AddPart(new Part()
                {
                    PartName = PartName,
                    Price = PartPrice,
                    Quantity = Quantity
                });
                MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Alkatrészadatok hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
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
