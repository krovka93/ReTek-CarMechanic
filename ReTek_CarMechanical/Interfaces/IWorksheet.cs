using ReTek_CarMechanical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Interfaces
{
    interface IWorksheet
    {
        bool UploadWorksheet(Worksheet worksheet);

        Worksheet GetSingleWorksheet(Worksheet worksheet);

        List<Worksheet> GetAllWorksheet();
    }
}
