using ReTek_CarMechanical.Models;
using System.Collections.Generic;

namespace ReTek_CarMechanical.Interfaces
{
    interface IClient
    {
        List<Client> GetAllClient();
        bool UpdateClient(Client client);
        bool AddClient(Client client);
    }
}
