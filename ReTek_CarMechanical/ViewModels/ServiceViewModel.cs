using ReTek_CarMechanical.Helpers;
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
    class ServiceViewModel : INotifyPropertyChanged
    {

        private string _serviceName;

        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; OnPropertyChanged("ServiceName"); }
        }


        private int _servicePrice;

        public int ServicePrice
        {
            get { return _servicePrice; }
            set { _servicePrice = value; OnPropertyChanged("ServicePrice"); }
        }


        private ICommand _addNewServiceCommandHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewServiceCommandHandler
        {
            get
            {
                return _addNewServiceCommandHandler ??
                    (_addNewServiceCommandHandler = new CommandHandler(() => AddNewServiceCommandAction(),
                    () => (!string.IsNullOrEmpty(ServiceName) && ServicePrice > 0)));
            }
        }

        private void AddNewServiceCommandAction()
        {
            var existingService = BusinessLayer.Instance.GetAllService().SingleOrDefault(lm => lm.ServiceName == ServiceName);
            if (existingService != null)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Szeretné frissíteni a szolgáltatás adatokat?", "Meglévő szolgáltatás adatainak frissítése", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    var result = BusinessLayer.Instance.UpdateService(new Service()
                    {
                        ServiceID = existingService.ServiceID,
                        ServiceName = ServiceName,
                        ServicePrice = ServicePrice,

                    });
                    MessageBox.Show(result ? "Sikeres frissítés" : "SIKERTELEN frissítés", "Szolgáltatás frissítése", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var result = BusinessLayer.Instance.AddNewService(new Service()
                {
                    ServiceName = ServiceName,
                    ServicePrice = ServicePrice,

                });
                MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Szolgáltatás hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
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
