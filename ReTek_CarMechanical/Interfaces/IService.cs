using ReTek_CarMechanical.Models;
using System.Collections.Generic;

namespace ReTek_CarMechanical.Interfaces
{
    interface IService 
    {
        bool UpdateService(Service service);
        bool AddNewService(Service service);
        List<Service> GetAllService();
    }
}
