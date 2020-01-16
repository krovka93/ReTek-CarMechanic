using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using ReTek_CarMechanical.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class MainWindowsViewModel : INotifyPropertyChanged
    {
        public MainWindowsViewModel()
        {
            Clients = BusinessLayer.Instance.GetAllClient();
            Cars = BusinessLayer.Instance.GetAllCar();
            Services = BusinessLayer.Instance.GetAllService();
            Parts = BusinessLayer.Instance.GetAllPart();
            Worksheets = BusinessLayer.Instance.GetAllWorksheet();

        }
        public List<Client> Clients { get; set; }
        public List<Car> Cars { get; set; }
        public List<Service> Services { get; set; }
        public List<Part> Parts { get; set; }
        public List<Worksheet> Worksheets { get; set; }

        private ICommand _clientCommandHandler;
        public ICommand ClientCommandHandler
        {
            get
            {
                return _clientCommandHandler ?? (_clientCommandHandler = new CommandHandler(() => ClientCommandHandlerAction(), () => true));
            }
        }

        public void ClientCommandHandlerAction()
        {
            ClientView view = new ClientView();
            view.Show();
        }

        private ICommand _carCommandHandler;
        public ICommand CarCommandHandler
        {
            get
            {
                return _carCommandHandler ?? (_carCommandHandler = new CommandHandler(() => CarCommandHandlerAction(), () => true));
            }
        }

        public void CarCommandHandlerAction()
        {
            CarView view = new CarView();
            view.Show();
        }
        private ICommand _serviceCommandHandler;
        public ICommand ServiceCommandHandler
        {
            get
            {
                return _serviceCommandHandler ?? (_serviceCommandHandler = new CommandHandler(() => ServiceCommandHandlerAction(), () => true));
            }
        }

        public void ServiceCommandHandlerAction()
        {
            ServiceView view = new ServiceView();
            view.Show();
        }

        private ICommand _partCommandHandler;
        public ICommand PartCommandHandler
        {
            get
            {
                return _partCommandHandler ?? (_partCommandHandler = new CommandHandler(() => PartCommandHandlerAction(), () => true));
            }
        }

        public void PartCommandHandlerAction()
        {
            PartView view = new PartView();
            view.Show();
        }

        private ICommand _worksheetCommandHandler;
        public ICommand WorksheetCommandHandler
        {
            get
            {
                return _worksheetCommandHandler ?? (_worksheetCommandHandler = new CommandHandler(() => WorksheetCommandHandlerAction(), () => true));
            }
        }

        public void WorksheetCommandHandlerAction()
        {
            WorksheetView view = new WorksheetView();
            view.Show();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _updateDataGridsCommandHandler;

        public ICommand UpdateDataGridsCommandHandler
        {
            get
            {
                return _updateDataGridsCommandHandler ?? (_updateDataGridsCommandHandler = new CommandHandler(() => UpdateGridsCommandHandlerAction(), () => true));
            }
        }

        private void UpdateGridsCommandHandlerAction()
        {
            Clients = BusinessLayer.Instance.GetAllClient();
            Cars = BusinessLayer.Instance.GetAllCar();
            Services = BusinessLayer.Instance.GetAllService();
            Parts = BusinessLayer.Instance.GetAllPart();
            Worksheets = BusinessLayer.Instance.GetAllWorksheet();
            OnPropertyChanged(nameof(Clients));
            OnPropertyChanged(nameof(Cars));
            OnPropertyChanged(nameof(Services));
            OnPropertyChanged(nameof(Parts));
            OnPropertyChanged(nameof(Worksheets));
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
