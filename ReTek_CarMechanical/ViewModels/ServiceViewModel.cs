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
   class ServiceViewModel
   {
      public string ServiceName { get; set; }
      public int ServicePrice { get; set; }

      private ICommand _addNewServiceCommandHandler;
      public ICommand AddNewServiceCommandHandler
      {
         get
         {
            return _addNewServiceCommandHandler ?? (_addNewServiceCommandHandler = new CommandHandler(() => AddNewServiceCommandAction(), () => true));
         }
      }

      private void AddNewServiceCommandAction()
      {
         var result = BussinessLayer.Instance.UpdateService(new Service()
         {
            ServiceName = ServiceName,
            ServicePrice = ServicePrice,

         });


         MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Szolgáltatás hozzáadása");
      }
   }
}
