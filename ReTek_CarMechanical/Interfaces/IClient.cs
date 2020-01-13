using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Interfaces
{
    interface IClient
    {
        Client GetSingleClient(Client client);
        List<Client> GetAllClient();
        bool UpdateClient(Client client);
        bool AddClient(Client client);
    }
}
