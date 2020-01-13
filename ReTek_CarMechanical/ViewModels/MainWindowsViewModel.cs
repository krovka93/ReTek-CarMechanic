using ReTek_CarMechanical.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.ViewModels
{
    class MainWindowsViewModel
    {
        public string Test { get { return BussinessLayer.Instance.Test(); } }
    }
}
