using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
using ReTek_CarMechanical.Views;
using System.Collections.Generic;
using System.Windows.Input;

namespace ReTek_CarMechanical.ViewModels
{
    class MainWindowsViewModel
    {
        public List<Client> Clients { get { return BussinessLayer.Instance.GetAllClient(); } }

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
    }
}
