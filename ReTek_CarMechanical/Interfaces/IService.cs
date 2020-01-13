using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Interfaces
{
    interface IService 
    {
        bool UpdateService(Service service);
        bool AddNewService(Service service);
        Service GetSingleService(Service service);
        List<Service> GetAllService();
    }
}
