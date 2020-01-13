using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Interfaces
{
    interface IPart
    {
        Part GetSinglePart(Part part);

        List<Part> GetAllPart();

        bool AddPart(Part part);

        bool UpdatePart(Part part);
    }
}
