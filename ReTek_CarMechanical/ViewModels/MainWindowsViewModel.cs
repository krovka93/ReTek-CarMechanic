﻿using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using ReTek_CarMechanical.Views;
using System.Collections.Generic;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class MainWindowsViewModel
    {
        public List<Client> Clients { get { return BusinessLayer.Instance.GetAllClient(); } }
        public List<Car> Cars { get { return BusinessLayer.Instance.GetAllCar(); } }
        public List<Service> Services { get { return BusinessLayer.Instance.GetAllService(); } }
        public List<Part> Parts { get { return BusinessLayer.Instance.GetAllPart(); } }
        public List<Worksheet> Worksheets { get { return BusinessLayer.Instance.GetAllWorksheet(); } }

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
    }
}
