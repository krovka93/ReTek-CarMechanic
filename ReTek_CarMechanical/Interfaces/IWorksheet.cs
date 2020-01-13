using Project_Retek_Store_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Retek_Store_Manager.Interface
{
    interface IWorksheet
    {
        bool UploadWorksheet(Worksheet worksheet);

        bool GetSingleWorksheet(Worksheet worksheet);

        bool GetAllWorksheet();
    }
}
