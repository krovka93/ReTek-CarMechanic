using ReTek_CarMechanical.Models;
using System.Collections.Generic;

namespace ReTek_CarMechanical.Interfaces
{
    interface IWorksheet
    {
        bool UploadWorksheet(Worksheet worksheet);

        List<Worksheet> GetAllWorksheet();
    }
}
