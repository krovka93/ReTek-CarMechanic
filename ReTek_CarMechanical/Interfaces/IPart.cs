using Project_Retek_Store_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Retek_Store_Manager.Interface
{
    interface IPart
    {
        bool GetSinglePart(Part part);

        bool GetAllPart();

        bool AddPart(Part part);

        bool UpdatePart(Part part);
    }
}
