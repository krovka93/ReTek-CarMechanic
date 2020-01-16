using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;

namespace ReTek_CarMechanical.ViewModels
{
    class WorksheetViewModel : INotifyPropertyChanged
    {
        #region properties
        public List<Client> Clients { get { return BusinessLayer.Instance.GetAllClient(); } }

        private List<Car> _cars;
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; OnPropertyChanged("Cars"); }
        }

        public List<Service> Services { get { return BusinessLayer.Instance.GetAllService(); } }
        public List<Part> Parts { get { return BusinessLayer.Instance.GetAllPart(); } }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; OnPropertyChanged("SelectedClient"); Cars = BusinessLayer.Instance.GetAllCarByUser(value);  }
        }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; OnPropertyChanged("SelectedCar"); }
        }

        private Service _selectedService;
        public Service SelectedService
        {
            get { return _selectedService; }
            set { _selectedService = value; OnPropertyChanged("SelectedService"); }
        }

        private Part _selectedPart;
        public Part SelectedPart
        {
            get { return _selectedPart; }
            set { _selectedPart = value; OnPropertyChanged("SelectedPart"); }
        }

        private DateTime _workStart;
        public DateTime WorkStart
        {
            get { return _workStart; }
            set { _workStart = value; OnPropertyChanged("WorkStart"); }
        }

        private DateTime _expectedEnd;
        public DateTime ExpectedEnd
        {
            get { return _expectedEnd; }
            set { _expectedEnd = value; OnPropertyChanged("ExpectedEnd"); }
        }

        private DateTime _workActualEnd;
        public DateTime WorkActualEnd
        {
            get { return _workActualEnd; }
            set { _workActualEnd = value; OnPropertyChanged("WorkActualEnd"); }
        }

        private int _kilometerState;
        public int KilometerState
        {
            get { return _kilometerState; }
            set { _kilometerState = value; OnPropertyChanged("KilometerState"); }
        }
        #endregion

        private ICommand _addNewWorksheetCommandHandler;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewWorksheetCommandHandler
        {
            get
            {
                return _addNewWorksheetCommandHandler ?? (_addNewWorksheetCommandHandler = new CommandHandler(() => AddNewWorksheetCommandAction(), () => true));
            }
        }

        private void AddNewWorksheetCommandAction()
        {
            var result = BusinessLayer.Instance.UploadWorksheet(new Worksheet()
            {
                CarID = SelectedCar.CarID,
                ExpectedEnd = ExpectedEnd,
                KilometerState = KilometerState,
                PartID = SelectedPart.PartID,
                ServiceID = SelectedService.ServiceID,
                UniqueId = "DB_Will_Create_It",
                WorkActualEnd = WorkActualEnd,
                WorkStart = WorkStart,
            });

            MessageBox.Show(result ? "Sikeres hozzáadás" : "SIKERTELEN hozzáadás", "Szolgáltatás hozzáadása", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
