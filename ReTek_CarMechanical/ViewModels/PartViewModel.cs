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
    class PartViewModel
    {
        public string PartName { get; set; }
        public int PartPrice { get; set; }
        public int Quantity { get; set; }

        private ICommand _addNewPartCommandHandler;
        public ICommand AddNewPartCommandHandler
        {
            get
            {
                return _addNewPartCommandHandler ?? (_addNewPartCommandHandler = new CommandHandler(() => AddNewPartCommandAction(), () => true));
            }
        }

        private void AddNewPartCommandAction()
        {
            var result = BussinessLayer.Instance.UpdatePart(new Part()
            {
                PartName = PartName,
                Price = PartPrice,
                Quantity = Quantity
                

            });


            MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Alkatrész hozzáadása");
        }
    }
}
