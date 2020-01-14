using ReTek_CarMechanical.Models;
using System.Collections.Generic;

namespace ReTek_CarMechanical.Interfaces
{
    interface IPart
    {
        List<Part> GetAllPart();

        bool AddPart(Part part);

        bool UpdatePart(Part part);
    }
}
