using ReTek_CarMechanical.Models;
using System.Collections.Generic;

namespace ReTek_CarMechanical.Interfaces
{
    interface IWorksheet
    {
        bool UploadWorksheet(Worksheet worksheet);

        Worksheet GetSingleWorksheet(Worksheet worksheet);

        List<Worksheet> GetAllWorksheet();
    }
}
